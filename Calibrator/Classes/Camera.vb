Imports System.Windows
Imports System.Threading
Imports Intel.RealSense
Imports System.Drawing
Imports NLog
Imports System.Threading.Tasks
''' <summary>
''' A physical RealSense camera, with a colour and a depth sensor.
''' This is simply a wrapper around RealSense.Device that exposes easier-to-use methods.
''' </summary>
Public Class Camera

    ''' <summary>
    ''' Raised every time the device has a colour+depth frame ready for processing
    ''' </summary>
    ''' <param name="sender">This camera</param>
    ''' <param name="depthmap"></param>
    ''' <param name="colour"></param>
    ''' <param name="colorised"></param>
    Public Event FrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap)

    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Private _Streaming As Boolean
    Private _Cancel As CancellationTokenSource
    Private WithEvents _FrameProcessor As FrameProcessor
    Private _Device As Device
    Private _Semaphore As AutoResetEvent
    Private _Sw As New Stopwatch
    Private _ColourSettings As SensorSettings
    Private _DepthSettings As SensorSettings
    Private _FPS As Double
    Private Const FPSSAMPLES As Integer = 10
    Private _Lastframe As Double

    Public Sub New(device As Device)
        _Device = device
        _Sw.Start()
        Dim failure As String = "Eh?"
        Try
            failure = "No colour sensor"
            _ColourSettings = New SensorSettings(ColourSensor.Options)
            failure = "No depth sensor"
            _DepthSettings = New SensorSettings(DepthSensor.Options)
        Catch ex As Exception
            Throw New Exception(failure, ex)
        End Try
    End Sub
    ''' <summary>
    ''' Apply settings to a sensor (depth or colour).
    ''' We only apply settings that are supported and not read-only.
    ''' </summary>
    Private Sub ApplySettings(sensor As Sensor, settings As IEnumerable(Of SensorSetting))
        If settings Is Nothing Then
            Exit Sub
        End If
        For Each setting As SensorSetting In settings
            If sensor.Options(setting.Key).Supported AndAlso Not sensor.Options(setting.Key).ReadOnly Then
                sensor.Options(setting.Key).Value = setting.Value
            End If
        Next setting
    End Sub
    Public Property ColourFormat As StreamFormat
    ''' <summary>
    ''' The available and supported colour stream formats of this camera.
    ''' The StreamProfiles data structures are ghastly, mixing up streams of different fundamental types.
    ''' (e.g. a depth stream is a VideoStream, when there's nothing 'video' about it at all).
    ''' This is a more platable version for human consumption.
    ''' Also, only take BGR8 streams, we don't know how to deal with the others.
    ''' The stream in .Net actually is RGB8, but the wrapper seems to get it the other way around, presumably an endianness issue
    ''' </summary>
    Public ReadOnly Property ColourFormats As IEnumerable(Of StreamFormat)
        Get
            Return ColourSensor.
                   StreamProfiles.
                   Where(Function(profile As StreamProfile) profile.Format = COLOURSTREAMFORMAT).
                   Cast(Of VideoStreamProfile).
                   Select(Function(vsp) New StreamFormat(vsp.Format, vsp.Width, vsp.Height)).
                   Distinct.
                   OrderBy(Function(vp) vp.ToString)
        End Get
    End Property
    ''' <summary>
    ''' Colour sensor intrinsics
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ColourIntrinsics As Intrinsics
    ''' <summary>
    ''' The colour sensor of this camera.
    ''' We only support a single colour sensor.
    ''' </summary>
    Public ReadOnly Property ColourSensor As Sensor
        Get
            Dim coloursensors As IEnumerable(Of Sensor) = _Device.Sensors.Where(Function(q) q.StreamProfiles.Any(Function(w) w.Stream = Stream.Color))
            If coloursensors.Any Then
                If coloursensors.Count > 1 Then
                    _Logger.Warn("Multiple colour sensors not supported, using first sensor")
                End If
                Return coloursensors.First
            End If
            _Logger.Warn("No colour sensors")
            Return Nothing
        End Get
    End Property
    ''' <summary>
    ''' The colour sensor settings
    ''' </summary>
    ''' <returns></returns>
    Public Property ColourSettings As SensorSettings
        Get
            Return _ColourSettings
        End Get
        Set(value As SensorSettings)
            _ColourSettings = value
        End Set
    End Property
    Public Property DepthFilters As DepthFilters
    Public Property DepthFormat As StreamFormat
    ''' <summary>
    ''' The depth sensor's formats.
    ''' See comments about colour formats above.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property DepthFormats As IEnumerable(Of StreamFormat)
        Get
            Return DepthSensor.
                   StreamProfiles.
                   Where(Function(profile) profile.Stream = Stream.Depth).
                   Cast(Of VideoStreamProfile).
                   Select(Function(videoprofile) New StreamFormat(videoprofile.Format, videoprofile.Width, videoprofile.Height)).
                   Distinct.
                   OrderBy(Function(astext) astext.ToString)
        End Get
    End Property
    Public ReadOnly Property DepthHFov As Double
        Get
            Return F2FOV(DepthIntrinsics.fx, DepthIntrinsics.width)
        End Get
    End Property
    Public ReadOnly Property DepthIntrinsics As Intrinsics
    ''' <summary>
    ''' The depth sensor of this camera.
    ''' We only support a single depth sensor.
    ''' </summary>
    Public ReadOnly Property DepthSensor As Sensor
        Get
            Dim depthsensors As IEnumerable(Of Sensor) = _Device.Sensors.Where(Function(q) q.StreamProfiles.Any(Function(w) w.Stream = Stream.Depth))
            If depthsensors.Any Then
                If depthsensors.Count > 1 Then
                    _Logger.Warn("Multiple depth sensors not supported, using first sensor")
                End If
                Return depthsensors.First
            End If
            _Logger.Warn("No depth sensors")
            Return Nothing
        End Get
    End Property
    Public Property DepthSettings As SensorSettings
        Get
            Return _DepthSettings
        End Get
        Set(value As SensorSettings)
            _DepthSettings = value
        End Set
    End Property
    Public ReadOnly Property DepthStream As Stream
    Public ReadOnly Property DepthVFov As Double
        Get
            Return F2FOV(DepthIntrinsics.fy, DepthIntrinsics.height)
        End Get
    End Property
    Public ReadOnly Property FirmwareVersion As String
        Get
            Return Info(CameraInfo.FirmwareVersion).ToString
        End Get
    End Property
    ''' <summary>
    ''' Prepare the colour / depth sensors and start a FrameProcessor to stream the data.
    ''' The actual frame processing code is in a separate source file to ease readability.
    ''' </summary>
    Private Sub FrameGrabber()

        ApplySettings(DepthSensor, DepthSettings)
        ApplySettings(ColourSensor, ColourSettings)

        Dim cfg As New Config()
        Dim pipeline As Pipeline
        Dim pipelineprofile As PipelineProfile

        ' Do this step by step to try and provide the most helpful message when there's a SNAFU
        Try
            cfg.EnableDevice(SerialNumber)
        Catch ex As Exception
            _Logger.Error(ex, "Failed to enable the device {0}", UniqueName)
            Exit Sub
        End Try

        Try
            cfg.EnableStream(Stream.Depth, DepthFormat.Width, DepthFormat.Height, DepthFormat.Format, Framerate)
        Catch ex As Exception
            _Logger.Error(ex, "Failed to enable the {0} depth stream", DepthFormat.FormatName)
            Exit Sub
        End Try

        Try
            cfg.EnableStream(Stream.Color, ColourFormat.Width, ColourFormat.Height, ColourFormat.Format, Framerate)
        Catch ex As Exception
            _Logger.Error(ex, "Failed to enable the {0} colour stream", ColourFormat.FormatName)
            Exit Sub
        End Try

        Try
            pipeline = New Pipeline
            pipelineprofile = pipeline.Start(cfg)
        Catch ex As Exception
            _Logger.Error(ex, "Failed to start the pipeline with {0} {1} at {2} FPS", DepthFormat.FormatName, ColourFormat.FormatName, Framerate)
            Exit Sub
        End Try

        Dim profiles As StreamProfileList = pipelineprofile.Streams

        ' Get the streams and intrinsics
        Dim cp As VideoStreamProfile = DirectCast(profiles.Where(Function(x As StreamProfile) x.Stream = Stream.Color).Single, VideoStreamProfile)
        _ColourIntrinsics = cp.GetIntrinsics

        Dim dp As VideoStreamProfile = DirectCast(profiles.Where(Function(x As StreamProfile) x.Stream = Stream.Depth).Single, VideoStreamProfile)
        _DepthStream = dp.Stream
        _DepthIntrinsics = dp.GetIntrinsics

        ' Fire up our frame processor
        _FrameProcessor = New FrameProcessor(Me)
        Dim block As New CustomProcessingBlock(AddressOf _FrameProcessor.Filtering)
        block.Start(AddressOf _FrameProcessor.Process)

        _Cancel = New CancellationTokenSource

        While Not _Cancel.Token.IsCancellationRequested

            _Streaming = True

            Dim frames As FrameSet

            Try
                ' When this breaks on exception in debugging, Options->Debug->clear "break when exceptions cross app domain"
                frames = pipeline.WaitForFrames(1000)
                If frames Is Nothing Then
                    _Logger.Debug("WaitForFrames returned nothing")
                Else
                    block.ProcessFrames(frames)
                End If

            Catch ex As Exception
                ' WaitForFrames throws vanilla "Exception" with varied texts, instead of a specific exception
                ' according to what really went wrong. Beurk.
                ' For the moment:
                '   "Frame did not arrive in time" in rs.cpp
                '   "Frame didn't arrive in time" in pipeline.cpp
                ' maybe there are others... 
                ' Thus the following hack.
                If ex.Message.StartsWith("Frame did") Then ' "not arrive in time", "n't arrive in time", ...
                    _Logger.Warn(ex.Message)
                    Continue While
                Else
                    Throw
                End If
            End Try
        End While
        _Cancel.Dispose()
        _Streaming = False
        _Semaphore.Set()
    End Sub
    ''' <summary>
    ''' The desired framerate, when starting the camera
    ''' </summary>
    ''' <returns></returns>
    Public Property Framerate As Integer
    Private Sub FrameProcessorFrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap) Handles _FrameProcessor.FrameReady

        Dim now As Double = _Sw.ElapsedMilliseconds
        Dim elapsed As Double = now - _Lastframe
        Dim fps As Double = 1000 / Math.Max(1, elapsed)
        ' https://stackoverflow.com/a/23493727/338101
        Dim newfps As Double = (_FPS * (FPSSAMPLES - 1) + fps) / FPSSAMPLES
        _FPS = newfps
        _Lastframe = now

        RaiseEvent FrameReady(sender, depthmap, colour, colorised)
    End Sub
    ''' <summary>
    ''' Convert a VideoFrame into a windows bitmap
    ''' </summary>
    ''' <param name="frame"></param>
    ''' <returns></returns>
    Public Shared Function FrameToBitmap(frame As VideoFrame) As Bitmap
        If frame.Width = 0 Then Return Nothing
        Return New Bitmap(frame.Width, frame.Height, frame.Stride, Imaging.PixelFormat.Format24bppRgb, frame.Data)
    End Function
    ''' <summary>
    ''' Shorthand to get device info
    ''' </summary>
    Public ReadOnly Property Info(ci As CameraInfo) As Object
        Get
            Return _Device.Info(ci)
        End Get
    End Property
    Public ReadOnly Property ModelNumber As Integer
        Get
            ' Not pretty, but there doesn't seem to be a better way
            Dim dpos As Integer = Name.IndexOf("D")
            If dpos < 0 Then
                Return -1
            End If
            Dim digits As String = Name.Substring(dpos + 1, 3)
            Dim result As Integer = 0
            If Integer.TryParse(digits, result) Then
                Return result
            Else
                Return -1
            End If
        End Get
    End Property
    ''' <summary>
    ''' The camera's name.
    ''' This is NOT unique, see UniqueName
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Name As String
        Get
            Return Info(CameraInfo.Name).ToString
        End Get
    End Property
    Public ReadOnly Property ProductId As String
        Get
            Return Info(CameraInfo.ProductId).ToString
        End Get
    End Property
    Public ReadOnly Property RecommendedFirmwareVersion As String
        Get
            Return Info(CameraInfo.RecommendedFirmwareVersion).ToString
        End Get
    End Property
    Friend Sub Restart()
        StopStreaming()
        Start()
    End Sub
    Public ReadOnly Property SerialNumber As String
        Get
            Return Info(CameraInfo.SerialNumber).ToString
        End Get
    End Property
    Friend Sub Start()
        _Logger.Debug("Starting the camera...")
        Task.Run(Sub() FrameGrabber())
        'Task.Factory.StartNew(Sub() FrameGrabber(), Nothing, TaskCreationOptions.None, PriorityScheduler.BelowNormal)
    End Sub
    ''' <summary>
    ''' Stop a running camera.
    ''' As the frame processor is running on its own thread, ask it to stop by signalling the cancellation token
    ''' and wait for it to do so with a semaphore.
    ''' </summary>
    Public Sub StopStreaming()

        If Not Streaming Then
            Exit Sub
        End If

        _Logger.Debug("Stopping the camera...")

        Try
            _Semaphore = New AutoResetEvent(False)
            _Cancel.Cancel()
            If _Semaphore.WaitOne(1000) Then
                _Logger.Debug("Camera has stopped")
            Else
                _Logger.Fatal("Camera failed to stop in a timely manner")
            End If

        Catch ex As Exception
            _Logger.Fatal(ex, "SNAFU stopping camera")

        Finally
            _Semaphore.Dispose()
            _Semaphore = Nothing
        End Try
    End Sub
    Public ReadOnly Property Streaming As Boolean
        Get
            Return _Streaming
        End Get
    End Property
    Public ReadOnly Property UniqueName As String
        Get
            Return $"{Name} {SerialNumber}"
        End Get
    End Property
End Class