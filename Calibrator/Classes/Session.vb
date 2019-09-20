Imports System.IO
Imports System.Runtime.Serialization
Imports System.Threading
Imports System.Windows
Imports System.Windows.Media.Media3D
Imports System.Xml
Imports NLog

Public Enum State
    Idle
    FindFloor
    FindRow
    ImproveRow
    FindTargets
    ImproveTargets
    NoTargets
    Measure
End Enum
''' <summary>
''' Represents a camera-calibrating session, where we take measurements of targets at various distances,
''' to try and establish the camera intrinsics
''' </summary>
Public Class Session

    Public Event CameraChanged(sender As Object, oldcamera As Camera, newcamera As Camera)
    Public Event FrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap)
    Public Event PlaneAdded(sender As Object, plane As Plane)
    Public Event StateChanged(sender As Object, state As State)

    Public ReadOnly Property ActiveFloor As Floor
    Public ReadOnly Property ActivePlane As Plane
    Public ReadOnly Property ActiveRow As Row
    Public ReadOnly Property Model As Model
    Public ReadOnly Property Planes As Planes
    Public ReadOnly Property Range As Double
    Public Property TargetHeight As Double
    Public Property TargetWidth As Double

    Private _State As State = State.Idle
    Private _Lock As New ReaderWriterLockSlim
    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Private WithEvents _Cameras As Cameras
    Private WithEvents _Camera As Camera
    Public Sub New()
        _Planes = New Planes
        Ensure64Bit(Me)
    End Sub
    Private Sub CameraFrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap) Handles _Camera.FrameReady

        If _Lock.TryEnterWriteLock(0) Then
            Try
                Dim colourpic As Bitmap = colour
                Dim depthpic As Bitmap = colorised

                If State = State.Idle Then
                    colourpic = Crosshairs(colourpic)
                    depthpic = Crosshairs(depthpic)
                Else
                    Select Case State

                        Case State.FindFloor

                            ActiveFloor.Measure(depthmap)

                        Case State.FindRow

                            If ActiveRow.FindTargets(colour) Then
                                State = State.ImproveRow
                            Else
                                State = State.NoTargets
                            End If

                        Case State.ImproveRow

                            ActiveRow.ImproveTargets(colour, depthmap)

                        Case State.FindTargets

                            If ActivePlane.FindTargets(colour) Then
                                State = State.ImproveTargets
                            Else
                                State = State.NoTargets
                            End If

                        Case State.ImproveTargets

                            ActivePlane.ImproveTargets(colour, depthmap)

                        Case State.Measure

                            ActivePlane.Measure(depthmap)

                    End Select

                    If ActivePlane IsNot Nothing Then
                        colourpic = ActivePlane.Decorate(colour)
                        depthpic = ActivePlane.Decorate(depthpic)
                    End If

                    If ActiveRow IsNot Nothing Then
                        colourpic = ActiveRow.Decorate(colour)
                        depthpic = ActiveRow.Decorate(depthpic)
                    End If

                End If

                RaiseEvent FrameReady(sender, depthmap, colourpic, depthpic)

            Catch ex As Exception
                Throw

            Finally
                _Lock.ExitWriteLock()
            End Try
        End If
    End Sub
    ''' <summary>
    ''' The active camera, the one we are currently measuring
    ''' </summary>
    ''' <returns></returns>
    Public Property Camera As Camera
        Get
            Return _Camera
        End Get
        Set(value As Camera)
            State = State.Idle
            If _Camera?.Streaming Then
                _Camera.StopStreaming()
            End If
            RaiseEvent CameraChanged(Me, _Camera, value)
            _Camera = value
        End Set
    End Property
    ''' <summary>
    ''' All the RealSense cameras connected to this PC
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Cameras As Cameras
        Get
            If _Cameras Is Nothing Then
                _Cameras = New Cameras
            End If
            Return _Cameras
        End Get
    End Property
    ''' <summary>
    ''' Draw LightSkyBlue crosshairs on a bitmap, to help aligning the plane
    ''' </summary>
    ''' <param name="bitmap"></param>
    ''' <returns></returns>
    Private Function Crosshairs(bitmap As Bitmap) As Bitmap
        Dim result As Bitmap = DirectCast(bitmap.Clone, Bitmap)
        Dim centre As New Point((result.Width - 1) / 2, (result.Height - 1) / 2)
        Using g As Graphics = Graphics.FromImage(result)
            GDIBestQuality(g)
            ' Vertical and horizontal
            Using p As New Pen(Color.FromArgb(64, 135, 206, 250), 1)
                DrawLine(g, p, centre.X, centre.Y - 5, centre.X, 0)
                DrawLine(g, p, centre.X, centre.Y + 5, centre.X, result.Height - 1)
                DrawLine(g, p, centre.X - 5, centre.Y, 0, centre.Y)
                DrawLine(g, p, centre.X + 5, centre.Y, result.Width - 1, centre.Y)
            End Using
            ' Diagonals
            Using p As New Pen(Color.FromArgb(32, 135, 206, 250), 1)
                DrawLine(g, p, centre.X - 5, centre.Y - 5, centre.X - TargetWidth, centre.Y - TargetHeight)
                DrawLine(g, p, centre.X + 5, centre.Y - 5, centre.X + TargetWidth, centre.Y - TargetHeight)
                DrawLine(g, p, centre.X - 5, centre.Y + 5, centre.X - TargetWidth, centre.Y + TargetHeight)
                DrawLine(g, p, centre.X + 5, centre.Y + 5, centre.X + TargetWidth, centre.Y + TargetHeight)
            End Using
        End Using
        Return result
    End Function
    ''' <summary>
    ''' Find the 5 targets on the current plane
    ''' </summary>
    Public Sub FindFloor()
        _ActiveFloor = New Floor(Model)
        State = State.FindFloor
    End Sub
    ''' <summary>
    ''' Find the 5 targets on the current plane
    ''' </summary>
    Public Sub FindRow()
        If ActiveRow Is Nothing Then
            _ActiveRow = New Row
        End If
        ActiveRow.Reset()
        State = State.FindRow
    End Sub
    ''' <summary>
    ''' Find the 5 targets on the current plane
    ''' </summary>
    ''' <param name="range">mm</param>
    ''' <param name="targetwidth">mm</param>
    ''' <param name="targetheight">mm</param>
    Public Sub FindTargets(range As Double, targetwidth As Double, targetheight As Double)
        If ActivePlane Is Nothing OrElse ActivePlane.Measuring Then
            _ActivePlane = New Plane(range, targetwidth, targetheight)
            _Planes.Add(_ActivePlane)
            RaiseEvent PlaneAdded(Me, ActivePlane)
        End If
        ActivePlane.Reset()
        State = State.FindTargets
    End Sub
    Public Sub FloorDone(callback As Action(Of Model))
        Idle()
        ActiveFloor.Optimise(callback)
    End Sub
    ''' <summary>
    ''' Go back to 'Idle' mode (no finding targets of measuring)
    ''' </summary>
    Public Sub Idle()
        State = State.Idle
    End Sub
    ''' <summary>
    ''' Load a previously-saved session's data, to continue working with it
    ''' </summary>
    ''' <param name="filename"></param>
    Public Sub Load(filename As String)
        If filename.EndsWith(".xml") Then
            filename = filename.Substring(0, filename.Length - 4)
        End If
        If filename.EndsWith("Planes") Then
            filename = filename.Substring(0, filename.Length - 6)
        End If
        If filename.EndsWith("Model") Then
            filename = filename.Substring(0, filename.Length - 5)
        End If

        Dim pfs As New FileStream(filename & "Planes.xml", FileMode.Open)
        Dim ptr As XmlDictionaryReader = XmlDictionaryReader.CreateTextReader(pfs, New XmlDictionaryReaderQuotas)
        Dim pdcs As New DataContractSerializer(GetType(Planes))
        _Planes = DirectCast(pdcs.ReadObject(ptr, True), Planes)
        pfs.Close()

        Dim mfs As New FileStream(filename & "Model.xml", FileMode.Open)
        Dim mtr As XmlDictionaryReader = XmlDictionaryReader.CreateTextReader(mfs, New XmlDictionaryReaderQuotas)
        Dim mdcs As New DataContractSerializer(GetType(Model))
        _Model = DirectCast(mdcs.ReadObject(mtr, True), Model)
        mfs.Close()
        _Model.Planes = Planes

        _ActivePlane = Planes.FirstOrDefault

        RaiseEvent PlaneAdded(Me, ActivePlane)
    End Sub
    ''' <summary>
    ''' Start measuring the current plane
    ''' </summary>
    Public Sub Measure()
        ActivePlane.Clear()
        ActivePlane.Measuring = True
        State = State.Measure
    End Sub
    ''' <summary>
    ''' Optimise the current model
    ''' </summary>
    ''' <param name="callback"></param>
    Public Sub Optimise(callback As Action(Of Model))
        If _Model Is Nothing Then
            _Model = New Model(Camera, Planes)
        End If
        _Model.Optimise(callback)
    End Sub
    ''' <summary>
    ''' Restart the camera (after a parameter change)
    ''' </summary>
    Public Sub RestartCamera()
        Idle()
        _Camera.Restart()
    End Sub
    ''' <summary>
    ''' Save the solution and create the CSV files with the magic numbers
    ''' </summary>
    ''' <param name="filename"></param>
    Public Sub Save(filename As String)
        Dim sw As StreamWriter
        sw = New StreamWriter($"{filename} Trinsics.csv")
        sw.WriteLine("Camera,HPixels,VPixels,HFov,VFov,Inclination,Deviation,A,B,C")
        sw.Write($"{Camera.UniqueName}")
        sw.Write($",{Camera.DepthIntrinsics.width}")
        sw.Write($",{Camera.DepthIntrinsics.height}")
        sw.Write($",{Model.HFov}")
        sw.Write($",{Model.VFov}")
        sw.Write($",{Model.Inclination}")
        sw.Write($",{Model.Deviation}")
        sw.Write($",{Model.QuadraticA}")
        sw.Write($",{Model.QuadraticB}")
        sw.Write($",{Model.QuadraticC}")
        sw.WriteLine("")
        sw.Close()

        Dim cameramodel As New Model(Camera, Planes)
        ' RealSense D400 Series Product Family Datasheet
        ' Table 4-8. Depth Module Depth Start Point
        If Camera.ModelNumber >= 420 Then
            cameramodel.QuadraticC = 3.2
        Else
            cameramodel.QuadraticC = 0.1
        End If

        sw = New StreamWriter($"{filename} Planes.csv")

        sw.WriteLine("Range,Target,Row,Col,MeanRange,Pixels,Sigma,TrueX,TrueY,TrueZ,OptX,OptY,OptZ,CamX,CamY,CamZ")

        For Each plane As Plane In Model.Planes.OrderBy(Function(q) q.Truth)

            Dim camoffset As Vector3D = plane.Offset(cameramodel)
            Dim optoffset As Vector3D = plane.Offset(Model)

            For Each target As Target In plane.Targets

                sw.Write($"{plane.Truth.ToString}")
                sw.Write($",{target.Name}")
                sw.Write($",{target.Row}")
                sw.Write($",{target.Col}")
                sw.Write($",{target.MeanRange}")
                sw.Write($",{target.Pixels.Count}")
                sw.Write($",{target.Sigma}")

                sw.Write($",{target.Truth.X},{target.Truth.Y},{target.Truth.Z}")

                Dim p As Point3D = Model.Predict(target.Row, target.Col, target.MeanRange) - optoffset
                sw.Write($",{p.X},{p.Y},{p.Z}")

                Dim q As Point3D = cameramodel.Predict(target.Row, target.Col, target.MeanRange) - optoffset
                sw.Write($",{q.X},{q.Y},{q.Z}")

                sw.WriteLine("")

            Next target
        Next plane
        sw.Close()

        If ActiveRow IsNot Nothing Then
            sw = New StreamWriter($"{filename} Rows.csv")
            sw.WriteLine("Row,Col,X,Y,Z")
            For Each target As Target In ActiveRow.Targets
                Dim p As Point3D = Model.Predict(target.Row, target.Col, target.Range)
                sw.Write($",{target.Row}")
                sw.Write($",{target.Col}")
                sw.Write($",{p.X}")
                sw.Write($",{p.Y}")
                sw.Write($",{p.Z}")
                sw.WriteLine("")
            Next
            sw.Close()
        End If

        Dim pfs As New FileStream($"{filename}Planes.xml", FileMode.Create)
        Dim pdcs As New DataContractSerializer(GetType(Planes))
        pdcs.WriteObject(pfs, Planes)
        pfs.Close()

        Dim mfs As New FileStream($"{filename}Model.xml", FileMode.Create)
        Dim mdcs As New DataContractSerializer(GetType(Model))
        mdcs.WriteObject(mfs, Model)
        mfs.Close()

    End Sub
    ''' <summary>
    ''' Start (a previously-idle) cam3era
    ''' </summary>
    Public Sub StartCamera()
        Idle()
        _Camera.Start()
    End Sub
    ''' <summary>
    ''' What we are currently doing
    ''' </summary>
    ''' <returns></returns>
    Public Property State As State
        Get
            Return _State
        End Get
        Friend Set(value As State)
            _State = value
            RaiseEvent StateChanged(Me, _State)
        End Set
    End Property
End Class
