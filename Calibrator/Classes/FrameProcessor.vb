Imports System.Windows
Imports Intel.RealSense
Imports NLog
''' <summary>
''' Apply selected filters to the depth frame, build a composite frame with the result
''' and the colour frame, align them and raise a FrameReady event.
''' Cribbed from cs-tutorial-3-processing example inside the csharp wrapper folder of librealsense
''' </summary>
Friend Class FrameProcessor

    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Friend Event FrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap)
    Friend ReadOnly Property Camera As Camera

    Private align As Align
    Private Decimation As New DecimationFilter()
    Private depthtodisparity As New DisparityTransform(True)
    Private spatial As New SpatialFilter
    Private temporal As New TemporalFilter
    Private holefilling As New HoleFillingFilter
    Dim coloriser As New Colorizer()
    Private disparitytodepth As New DisparityTransform(False)

    Friend Sub New(camera As Camera)
        _Camera = camera
        align = New Align(camera.DepthStream)
    End Sub
    Friend Sub Filtering(f As Frame, src As FrameSource)

        Using releaser As New FramesReleaser

            Dim frames As FrameSet = FrameSet.FromFrame(f, releaser)
            Dim depth As VideoFrame = FramesReleaser.ScopedReturn(releaser, frames.DepthFrame)
            Dim color As VideoFrame = FramesReleaser.ScopedReturn(releaser, frames.ColorFrame)

            ' Decimate (to 320x240)
            If (_Camera.DepthFilters And DepthFilters.Decimation) <> 0 Then
                depth = Decimation.ApplyFilter(depth)
            End If

            Dim disparitytodepthrequired As Boolean = ((_Camera.DepthFilters And DepthFilters.HoleFilling) <> 0) OrElse
                                                      ((_Camera.DepthFilters And DepthFilters.Spatial) <> 0) OrElse
                                                      ((_Camera.DepthFilters And DepthFilters.Temporal) <> 0)

            If disparitytodepthrequired Then ' transform the scene into disparity domain 
                depth = depthtodisparity.ApplyFilter(depth)
            End If

            If (_Camera.DepthFilters And DepthFilters.Spatial) <> 0 Then
                depth = spatial.ApplyFilter(depth)
            End If

            If (_Camera.DepthFilters And DepthFilters.Temporal) <> 0 Then
                depth = temporal.ApplyFilter(depth)
            End If

            If (_Camera.DepthFilters And DepthFilters.HoleFilling) <> 0 Then
                ' Hole filling is best done in the disparity domain https://github.com/IntelRealSense/librealsense/issues/1591
                depth = holefilling.ApplyFilter(depth)
            End If

            If disparitytodepthrequired Then
                ' Revert back to depth domain
                depth = disparitytodepth.ApplyFilter(depth)
            End If

            Dim res As FrameSet = src.AllocateCompositeFrame(releaser, depth, color)
            src.FramesReady(res)
        End Using
    End Sub
    Sub Process(f As Frame)

        Using releaser As New FramesReleaser()

            Dim frames As FrameSet = FrameSet.FromFrame(f, releaser)

            Try
                ' When this breaks on exception, Options->Debug->clear "break when exceptions cross app domain"
                frames = align.Process(frames, releaser)
            Catch ex As Exception
                If ex.Message.StartsWith("Frame did") Then
                    _Logger.Warn(ex.Message)
                    Exit Sub
                Else
                    Throw
                End If
            End Try

            Dim depthframe As DepthFrame = FramesReleaser.ScopedReturn(releaser, frames.DepthFrame)
            Dim depthmap As New DepthMap(depthframe.Width, depthframe.Height)
            depthframe.CopyTo(depthmap.Data)

            Dim coloriseddepth As VideoFrame = coloriser.Colorize(depthframe)
            Dim colorised As Bitmap = Camera.FrameToBitmap(coloriseddepth)

            Dim colourframe As VideoFrame = FramesReleaser.ScopedReturn(releaser, frames.ColorFrame)
            Dim colour As Bitmap = Camera.FrameToBitmap(colourframe)

            RaiseEvent FrameReady(Me, depthmap, colour, colorised)
        End Using
    End Sub

End Class
