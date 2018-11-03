Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports System.Windows
Imports System.Windows.Media.Media3D ' in presentationcore.dll
Imports NLog

Public Class Planes
    Inherits BindingList(Of Plane)
End Class
''' <summary>
''' Represents our piece of wood with 5 targets at a certain distance from the camera.
''' </summary>
<DataContract>
Public Class Plane

    Private _TopLeft As Target
    Private _TopRight As Target
    Private _Middle As Target
    Private _BottomLeft As Target
    Private _BottomRight As Target
    Private _TargetHeight As Double
    Private _TargetWidth As Double
    Private _Targets As List(Of Target)
    Private _Truth As Double
    Private _Decorations As List(Of Decoration)
    Private _Logger As Logger
    Public Sub New()
    End Sub
    Friend Sub New(truth As Double, targetwidth As Double, targetheight As Double)
        _Truth = truth
        _TargetWidth = targetwidth
        _TargetHeight = targetheight
        TopLeft = New Target("Top Left", New Point3D(-targetwidth / 2, -targetheight / 2, truth))
        TopRight = New Target("Top Right", New Point3D(targetwidth / 2, -targetheight / 2, truth))
        Middle = New Target("Middle", New Point3D(0, 0, truth))
        BottomLeft = New Target("Bottom Left", New Point3D(-targetwidth / 2, targetheight / 2, truth))
        BottomRight = New Target("Bottom Right", New Point3D(targetwidth / 2, targetheight / 2, truth))
    End Sub
    Private Function AddDecoration(decoration As Decoration) As Decoration
        Decorations.Add(decoration)
        Return decoration
    End Function
    <DataMember>
    Public Property BottomLeft As Target
        Get
            Return _BottomLeft
        End Get
        Private Set(value As Target)
            _BottomLeft = value
        End Set
    End Property
    <DataMember>
    Public Property BottomRight As Target
        Get
            Return _BottomRight
        End Get
        Private Set(value As Target)
            _BottomRight = value
        End Set
    End Property
    Friend Sub Clear()
        For Each target As Target In Targets
            target.Clear()
        Next
    End Sub
    Private Sub CompleteCircle(target As Target, picture As FastPixel, startcol As Double, startrow As Double)

        Logger.Trace("Complete {0} circle from {1},{2}", target.Name, startcol, startrow)

        ImproveCircle(target, picture, startcol, startrow)

        Logger.Trace("Completed {0} circle at {1:#,##0.000},{2:#,##0.000}", target.Name, target.Col, target.Row)

        AddDecoration(New DecorationText(target.Col, target.Row, target.Name, New Font("Sans Serif", 8), Color.LightSkyBlue))
    End Sub
    Private ReadOnly Property Decorations As List(Of Decoration)
        Get
            If _Decorations Is Nothing Then
                _Decorations = New List(Of Decoration)
            End If
            Return _Decorations
        End Get
    End Property
    Friend Function Decorate(picture As Bitmap) As Bitmap
        Dim result As Bitmap = DirectCast(picture.Clone, Bitmap)
        For Each d As Decoration In Decorations.OrderBy(Function(q) q.Priority)
            d.Draw(result)
        Next
        Return result
    End Function
    Private Function DrawPartialLine(a As Point, b As Point, fraction As Double) As DecorationLine
        Dim dx As Double = b.X - a.X
        Dim dy As Double = b.Y - a.Y
        Dim space As Double = (fraction - 1) / fraction / 2
        Dim sx As Double = a.X + space * dx
        Dim sy As Double = a.Y + space * dy
        Dim ex As Double = b.X - space * dx
        Dim ey As Double = b.Y - space * dy
        Dim result As New DecorationLine(New Point(sx, sy), New Point(ex, ey), 1, Color.LightSkyBlue)
        AddDecoration(result)
        Return result
    End Function
    Private Function FindCorner(target As Target, picture As FastPixel, startcol As Double, startrow As Double, dx As Double, dy As Double, name As String) As Boolean

        Logger.Trace("Find {0} corner at {1},{2}", target.Name, startcol, startrow)

        Dim start As New Point(startcol, startrow)
        Dim offscreen As Integer = Math.Max(picture.Width, picture.Height)
        Dim finish As New Point(startcol + dx * offscreen, startrow + dy * offscreen)
        Dim failed As Decoration = AddDecoration(New DecorationLine(start, finish, 3, Color.Red))

        Dim redness As Integer = 0
        Dim n As Integer = 0
        Dim line As IEnumerable(Of Point) = Bresenham(start, finish)

        ' Find the first non-red pixel on the line
        Dim outside As Point = line(n)
        Do
            n += 1
            outside = line(n)
            If Not InBounds(picture, outside) Then
                Logger.Error("Couldn't find {0} circle", target.Name)
                Return False
            End If
        Loop Until Not IsRed(picture, outside, redness)

        ' Find the first red pixel in the circle we're loooking for
        Dim first As Point = line(n)
        Do
            n += 1
            first = line(n)
            If Not InBounds(picture, first) Then
                Logger.Error("Couldn't find {0} circle", target.Name)
                Return False
            End If
        Loop Until IsRed(picture, first, redness)

        ' Find the last red pixel in the circle we're loooking for
        Dim last As Point = line(n)
        Do
            n += 1
            last = line(n)
            If Not InBounds(picture, last) Then
                Logger.Error("Couldn't find {0} circle", target.Name)
                Return False
            End If
        Loop Until Not IsRed(picture, last, redness)

        Dim col As Double = (first.X + last.X) / 2
        Dim row As Double = (first.Y + last.Y) / 2
        IsRed(picture, col.ToInt, row.ToInt, redness)
        target.Add(col, row, redness)

        Logger.Trace("Found {0} corner at {1},{2}", target.Name, col, row)

        Decorations.Remove(failed)

        ' and flesh out the circle from the mid-point
        CompleteCircle(target, picture, col.ToInt, row.ToInt)

        Return True
    End Function
    Private Function FindMiddle(target As Target, picture As FastPixel) As Boolean

        Logger.Trace("Find {0}", target.Name)

        Dim startcol As Double = picture.Width / 2
        Dim startrow As Double = picture.Height / 2
        Dim offset As New Drawing.Point(startcol.ToInt, startrow.ToInt)
        Dim redness As Integer = 0
        Dim n As Integer = 0
        Dim col As Double
        Dim row As Double
        Do
            col = startcol + offset.X
            row = startrow + offset.Y
            If IsRed(picture, col.ToInt, row.ToInt, redness) Then
                Exit Do
            End If
            offset = Spiral(n)
            If offset.Y >= picture.Height \ 4 Then
                Logger.Error("Can't find a central red pixel")
                Return False
            End If
        Loop

        Logger.Trace("Found {0} at {1},{2}", target.Name, col, row)

        target.Add(col, row, redness)
        CompleteCircle(target, picture, col.ToInt, row.ToInt)
        Return True
    End Function
    ''' <summary>
    ''' Find the 5 targets on the plane by looking for red pixels and then improving the red circles.
    ''' We find the middle circle first and then the corners by moving at a diagonal proportional to the widht/height ratio of the target.
    ''' </summary>
    ''' <param name="colour">The colour bitmap, picture of the plane we are examining</param>
    ''' <returns>True if all 5 targets were found</returns>
    Friend Function FindTargets(colour As Bitmap) As Boolean

        Dim success As Boolean = True

        _Decorations = New List(Of Decoration)
        For Each target As Target In Targets
            target.Clear()
        Next

        Dim picture As New FastPixel(DirectCast(colour.Clone, Bitmap), True)

        If Not FindMiddle(Middle, picture) Then
            Logger.Warn("Centre red target not found. Make sure the crosshairs meet at the centre red target")
            Return False
        End If

        success = success And FindCorner(TopLeft, picture, Middle.Col, Middle.Row, -1, -TargetHeight / TargetWidth, "Top Left")
        success = success And FindCorner(TopRight, picture, Middle.Col, Middle.Row, 1, -TargetHeight / TargetWidth, "Top Right")
        success = success And FindCorner(BottomLeft, picture, Middle.Col, Middle.Row, -1, TargetHeight / TargetWidth, "Bottom Left")
        success = success And FindCorner(BottomRight, picture, Middle.Col, Middle.Row, 1, TargetHeight / TargetWidth, "Bottom Right")

        ' Cross-check that the targets are correctly spatially oriented relative to each other
        Dim oriented As Boolean = TopLeft.Col < Middle.Col AndAlso TopLeft.Row < Middle.Row AndAlso
                                  TopRight.Col > Middle.Col AndAlso TopRight.Row < Middle.Row AndAlso
                                  BottomLeft.Col < Middle.Col AndAlso BottomLeft.Row > Middle.Row AndAlso
                                  BottomRight.Col > Middle.Col AndAlso BottomRight.Row > Middle.Row
        If Not oriented Then
            Logger.Warn("Targets mis-oriented. Check that the crosshairs touch the red targets. Increase the ambient lighting?")
            success = False
        End If
        picture.Unlock()
        Return success
    End Function
    Private Sub ImproveCircle(target As Target, picture As FastPixel, startcol As Double, startrow As Double)

        Decorations.Remove(target.Circle)
        Decorations.Remove(target.Line)

        Dim redness As Integer = 0
        Dim n As Integer = 0
        Dim col As Double
        Dim row As Double
        Dim added As Boolean
        Dim turns As Integer = 0

        Do ' spiral until once-round doesn't add anything

            added = False
            Dim previous As Drawing.Point
            Dim offset As Drawing.Point

            Do ' Once round the spiral
                previous = offset
                offset = Spiral(n)
                col = startcol + offset.X
                row = startrow + offset.Y

                If Not InBounds(picture, col.ToInt, row.ToInt) Then
                    Exit Do
                End If

                If IsRed(picture, col.ToInt, row.ToInt, redness) Then
                    added = added Or target.Add(col, row, redness)
                End If

            Loop Until previous.Y = -1 AndAlso offset.Y = 0
            turns += 1
        Loop Until Not added
        target.Circle = AddDecoration(New DecorationCircle(target.Centre, target.Radius, 1, Color.LightSkyBlue))
        target.Line = AddDecoration(New DecorationLine(Middle.Centre, target.Centre, 1, Color.LightSkyBlue))
    End Sub
    ''' <summary>
    ''' Once the targets have been found, try to find further red pixels.
    ''' This is necessary due to noise in the colour images.
    ''' </summary>
    ''' <param name="colour">The colour bitmap, picture of the plane we are examining</param>
    ''' <param name="depthmap">The corresponding depthmap to be updated</param>
    Friend Sub ImproveTargets(colour As Bitmap, depthmap As DepthMap)

        Dim picture As New FastPixel(colour, True)
        For Each target As Target In Targets
            ImproveCircle(target, picture, target.Col, target.Row)
            target.Update(depthmap)
        Next
        picture.Unlock()

    End Sub
    Private Function IsRed(picture As FastPixel, a As Point, ByRef redness As Integer) As Boolean
        Return IsRed(picture, a.X.ToInt, a.Y.ToInt, redness)
    End Function
    Private Function IsRed(picture As FastPixel, col As Integer, row As Integer, ByRef redness As Integer) As Boolean

        If Not InBounds(picture, New Point(col, row)) Then
            Return False
        End If

        Dim pixel As Color = Normalise(picture.GetPixel(col, row))

        Dim hsv As New HSV(pixel)

        If Between(hsv.Hue, 30 / 360, 330 / 360) Then
            Return False ' not red enough
        End If

        If hsv.Saturation < 60 / 100 Then
            Return False ' not deep enough
        End If

        If hsv.Value < 30 / 100 Then
            Return False ' too dark
        End If

        redness = Convert.ToInt32((hsv.Saturation + hsv.Value) * 127) ' two of them so 0..255
        Return True

    End Function
    Public ReadOnly Property Logger As Logger
        Get
            If _Logger Is Nothing Then
                _Logger = LogManager.GetCurrentClassLogger
            End If
            Return _Logger
        End Get
    End Property
    Private Function InBounds(picture As FastPixel, col As Integer, row As Integer) As Boolean
        Return col >= 0 AndAlso col < picture.Width AndAlso row >= 0 AndAlso row < picture.Height
    End Function
    Private Function InBounds(picture As FastPixel, p As Point) As Boolean
        Return InBounds(picture, p.X.ToInt, p.Y.ToInt)
    End Function
    ''' <summary>
    ''' The average Z distance for all pixels of all 5 targets on this plane
    ''' </summary>
    Public ReadOnly Property MeanZ As Double
        Get
            Dim result As Double = Targets.Average(Function(q) q.MeanZ)
            Return result
        End Get
    End Property
    ''' <summary>
    ''' Update the Z statistics of the red pixels of all 5 targets on this plane
    ''' </summary>
    ''' <param name="depthmap">The depthmap with the statistics to be updated</param>
    Friend Sub Measure(depthmap As DepthMap)
        For Each target As Target In Targets
            target.Update(depthmap)
        Next
    End Sub
    ''' <summary>
    ''' We are currently in the process of measuring and improving the depthmap
    ''' </summary>
    ''' <returns></returns>
    Friend Property Measuring As Boolean
    <DataMember>
    Public Property Middle As Target
        Get
            Return _Middle
        End Get
        Private Set(value As Target)
            _Middle = value
        End Set
    End Property
    ''' <summary>
    ''' The X,Y offset of the central target of this plane
    ''' </summary>
    ''' <param name="model"></param>
    ''' <returns></returns>
    Friend ReadOnly Property Offset(model As Model) As Vector3D
        Get
            Dim p As Point3D = model.Predict(Middle.Row, Middle.Col, MeanZ)
            Return New Vector3D(p.X, p.Y, 0)
        End Get
    End Property
    ''' <summary>
    ''' Set all the statistics back to zero
    ''' </summary>
    Friend Sub Reset()
        For Each target As Target In Targets
            target.Reset()
        Next
    End Sub
    ''' <summary>
    ''' The total number of measurements made for all 5 targets on this plane
    ''' </summary>
    Public ReadOnly Property Samples As Integer
        Get
            Return Targets.Sum(Function(q) q.Samples)
        End Get
    End Property
    ''' <summary>
    ''' The standard deviation of all the measurements made for all 5 targets on this plane
    ''' </summary>
    Public ReadOnly Property Sigma As Double
        Get
            Return Math.Sqrt(Targets.Sum(Function(q) q.Variance) / Targets.Count)
        End Get
    End Property
    ''' <summary>
    ''' The distance in mm between the centres of the top and bottom red targets
    ''' </summary>
    ''' <returns>mm</returns>
    <DataMember>
    Friend Property TargetHeight As Double
        Get
            Return _TargetHeight
        End Get
        Private Set(value As Double)
            _TargetHeight = value
        End Set
    End Property
    <DataMember>
    Friend Property Targets As List(Of Target)
        Get
            If _Targets Is Nothing Then
                _Targets = {TopLeft, TopRight, Middle, BottomLeft, BottomRight}.ToList
            End If
            Return _Targets
        End Get
        Private Set(value As List(Of Target))
            _Targets = value
        End Set
    End Property
    ''' <summary>
    ''' The distance in mm between the centres of the left and right red targets
    ''' </summary>
    ''' <returns>mm</returns>
    <DataMember>
    Friend Property TargetWidth As Double
        Get
            Return _TargetWidth
        End Get
        Private Set(value As Double)
            _TargetWidth = value
        End Set
    End Property
    <DataMember>
    Public Property TopLeft As Target
        Get
            Return _TopLeft
        End Get
        Private Set(value As Target)
            _TopLeft = value
        End Set
    End Property
    <DataMember>
    Public Property TopRight As Target
        Get
            Return _TopRight
        End Get
        Private Set(value As Target)
            _TopRight = value
        End Set
    End Property
    ''' <summary>
    ''' The true distance from the camera's glass to the centre of this plane (measured with a ruler)
    ''' </summary>
    ''' <returns></returns>
    <DataMember>
    Public Property Truth As Double
        Get
            Return _Truth
        End Get
        Private Set(value As Double)
            _Truth = value
        End Set
    End Property
End Class
