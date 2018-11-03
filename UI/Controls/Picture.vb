Imports Calibrator
Imports System.Threading
Imports NLog
''' <summary>
''' A callback, rather line MouseEventArgs, which may be registered for mouse events; it returns a text to be displayed in the status line
''' </summary>
''' <param name="sender">This picture</param>
''' <param name="buttons">MouseButtons info</param>
''' <param name="clicks">Number of mouse clicks</param>
''' <param name="x">The X coordinates of the mouse in the full-size image scale</param>
''' <param name="y">The X coordinates of the mouse in the full-size image scale</param>
''' <param name="delta">The number of mousewheel moves</param>
''' <returns></returns>
Public Delegate Function InfoCallback(sender As Picture,
                                      buttons As MouseButtons,
                                      clicks As Integer,
                                      x As Double,
                                      y As Double,
                                      delta As Integer) As String
''' <summary>
''' A PictureBox that:
'''     - Is thread-safe, handling re-entrancy by only allowing one image update at a time
'''     - Draws the incoming image scaled for the best fit without distortion
'''     - Displays the mouse X and Y, correctly scaled
'''     - Displays the FPS
'''     - Optionally invokes a callback on mouse events, to display information about the pixel under the cursor
''' </summary>
Public Class Picture

    Public Event ResetSize() ' User requested resize to 100%

    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Private _Callback As InfoCallback
    Private _Sw As New Stopwatch
    Private _Lock As New ReaderWriterLockSlim
    Private _LastFrame As Double
    Private _Source As Bitmap
    Private Const FPSSAMPLES As Integer = 30
    Private _AverageFPS As Double
    Private _FPSClock As New Clock(1000 \ DISPLAYFRAMERATE)
    Public Sub New()
        InitializeComponent()
        txtFPS.Text = ""
        txtInfo.Text = ""
        txtXY.Text = ""
        txtSize.Text = ""
        _Sw.Start()
        PictureBox1.Image = New Bitmap(Me.Width, Me.Height)
    End Sub
    Private Sub CalculateFPS()
        Dim now As Double = _Sw.ElapsedMilliseconds
        Dim elapsed As Double = now - _LastFrame
        Dim fps As Double = 1000 / Math.Max(1, elapsed)
        ' https://stackoverflow.com/a/23493727/338101
        Dim newfps As Double = (_AverageFPS * (FPSSAMPLES - 1) + fps) / FPSSAMPLES
        _AverageFPS = newfps
        _LastFrame = now
    End Sub
    Public WriteOnly Property Callback As InfoCallback
        Set(value As InfoCallback)
            _Callback = value
        End Set
    End Property
    Public WriteOnly Property Image As Bitmap
        Set(value As Bitmap)

            CalculateFPS()

            If Not _FPSClock.Expired Then
                Exit Property
            End If

            If InvokeRequired Then
                Try
                    If _Lock.TryEnterWriteLock(0) Then

                        Dim semaphore As New AutoResetEvent(False)

                        BeginInvoke(
                            Sub(bitmap As Bitmap)
                                Try
                                    DrawIt(bitmap)
                                Catch ex As Exception
                                    _Logger.Error(ex, "SNAFU setting Picture.Image")
                                Finally
                                    semaphore.Set()
                                End Try
                            End Sub,
                            value)

                        semaphore.WaitOne(500)
                    Else
                        _Logger.Warn("Picture.Image missed writelock!")
                    End If

                Catch ex As Exception
                    Throw

                Finally
                    _Lock.ExitWriteLock()
                End Try
            Else
                DrawIt(value)
            End If
        End Set
    End Property
    Private Sub DoCallback(sender As Object, e As MouseEventArgs)
        If _Callback IsNot Nothing Then
            Dim scale As Double = SizeRatio(_Source, PictureBox1.Image)
            Dim x As Double = e.X / scale
            Dim y As Double = e.Y / scale
            If x <= Source?.Width AndAlso y <= Source.Height Then
                txtInfo.Text = _Callback(Me, e.Button, e.Clicks, x, y, e.Delta)
            Else
                txtInfo.Text = "out of bounds"
            End If
            txtInfo.Invalidate()
        End If
    End Sub
    Private Sub DrawIt(bitmap As Bitmap)
        _Source = bitmap
        DrawScaled(_Source, PictureBox1.Image)
        txtFPS.Text = $"{FPS:0.0}"
        PictureBox1.Invalidate()
        txtFPS.Invalidate()
    End Sub
    Public ReadOnly Property FPS As Double
        Get
            Return _AverageFPS
        End Get
    End Property
    Private Sub Picture_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' UserControl ReSize happens too early to calculate the % correctly
        If IsHandleCreated Then
            BeginInvoke(
                Sub()
                    txtSize.Text = $"{PictureBox1.Width}x{PictureBox1.Height}  {SizeRatio(_Source, PictureBox1.Image) * 100:0}%"
                    lbFPS.Left = pnlInfo.Width - lbFPS.Width - 4
                    txtFPS.Left = lbFPS.Left - txtFPS.Width - 4
                    lnkReset.Left = txtFPS.Left - lnkReset.Width - 8
                    lnkReset.Enabled = SizeRatio(_Source, PictureBox1.Image) <> 1
                    txtSize.Left = lnkReset.Left - txtSize.Width - 4
                    txtInfo.Width = txtSize.Left - txtInfo.Left - 8
                    If PictureBox1.Image IsNot Nothing Then
                        PictureBox1.Image.Dispose()
                    End If
                    PictureBox1.Image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                End Sub)
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim scale As Double = SizeRatio(_Source, PictureBox1.Image)
        Dim x As Double = e.X / scale
        Dim y As Double = e.Y / scale
        If scale = 1 Then
            txtXY.Text = $"X {x:0} Y {y:0}"
        Else
            txtXY.Text = $"X {x:0.0} Y {y:0.0}"
        End If
        txtXY.Invalidate()
        DoCallback(sender, e)
    End Sub
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        DoCallback(sender, e)
    End Sub
    Private Sub lnkReset_Click(sender As Object, e As EventArgs) Handles lnkReset.Click
        RaiseEvent ResetSize()
    End Sub
    Public ReadOnly Property Source As Bitmap
        Get
            Return _Source
        End Get
    End Property
End Class
