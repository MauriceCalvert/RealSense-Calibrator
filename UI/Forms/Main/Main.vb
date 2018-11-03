Imports System.Globalization
Imports System.Threading
Imports Calibrator
Imports NLog
Imports NLog.Config

Public Class Main

    Private _Logger As Logger
    Private WithEvents _Session As Session
    Private WithEvents _Camera As Camera
    Private _PaintingLock As New ReaderWriterLockSlim
    Private _ColourPicture As ColourPicture
    Private _DepthPicture As DepthPicture
    Private _Populating As Boolean = True
    Private _DGVClock As Clock
    Private _Loglevel As LogLevel = LogLevel.Info

    Public Sub New()

        InitializeComponent()

        MenuStrip1.Renderer = New MenuRenderer
        _DGVClock = New Clock(1000) ' Updating the datagridview is quite expensive

        TheMain = Me
        ConfigurationItemFactory.Default.Targets.RegisterDefinition("CustomTarget", GetType(CustomTarget))
        _Logger = LogManager.GetCurrentClassLogger

        Me.Location = My.Settings.StartPosition
        cmbLogLevel.SelectedItem = "Trace"
    End Sub

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Location = New Point(100, 50)
            _Session = New Session

            _Session.TargetHeight = 380
            txtTargetHeight.Text = _Session.TargetHeight.ToString
            _Session.TargetWidth = 630
            txtTargetWidth.Text = _Session.TargetWidth.ToString
            txtRange.Text = "0"

            SelectFirstCamera()
            _Populating = False
            StartCamera()
            chkViewColour.Checked = True
            cmbLogLevel.SelectedItem = "Info"

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub DisplayColour(show As Boolean)
        If show Then
            If _ColourPicture IsNot Nothing Then
                Exit Sub
            End If
            _ColourPicture = New ColourPicture
            _ColourPicture.Left = Me.Left + Me.Width
            If _DepthPicture Is Nothing Then
                _ColourPicture.Top = Me.Top
            Else
                _ColourPicture.Top = _DepthPicture.Top + _DepthPicture.Height
            End If
            AddHandler _ColourPicture.FormClosing, Sub(sender As Object, e As EventArgs)
                                                       _ColourPicture = Nothing
                                                       chkViewColour.Checked = False
                                                   End Sub
            _ColourPicture.Show(Me)
        Else
            If _ColourPicture IsNot Nothing Then
                _ColourPicture.Close()
            End If
        End If
    End Sub
    Private Sub DisplayDepth(show As Boolean)
        If show Then
            If _DepthPicture IsNot Nothing Then
                Exit Sub
            End If
            _DepthPicture = New DepthPicture
            _DepthPicture.Left = Me.Left + Me.Width
            If _ColourPicture Is Nothing Then
                _DepthPicture.Top = Me.Top
            Else
                _DepthPicture.Top = _ColourPicture.Top + _ColourPicture.Height
            End If
            AddHandler _DepthPicture.FormClosing, Sub(sender As Object, e As EventArgs)
                                                      _DepthPicture = Nothing
                                                      chkViewDepth.Checked = False
                                                  End Sub
            _DepthPicture.Show(Me)
        Else
            If _DepthPicture IsNot Nothing Then
                _DepthPicture.Close()
            End If
        End If
    End Sub
    Public Sub Log(logeventinfo As LogEventInfo)

        If logeventinfo.Level < _Loglevel Then
            Exit Sub
        End If
        Dim colour As Color
        ' For want of a better 'standard', https://github.com/nlog/NLog/wiki/ColoredConsole-target
        Select Case logeventinfo.Level
            Case LogLevel.Trace
                colour = Color.DarkGray
            Case LogLevel.Debug
                colour = Color.Gray
            Case LogLevel.Info
                colour = Color.White
            Case LogLevel.Warn
                colour = Color.Magenta
            Case LogLevel.Error
                colour = Color.Yellow
            Case LogLevel.Fatal
                colour = Color.Red
        End Select
        Status(logeventinfo.FormattedMessage, colour)
        If logeventinfo.Exception IsNot Nothing Then
            Status(logeventinfo.Exception.Message, Color.LightGray)
        End If
    End Sub
    Private Sub PopulateCameras()
        cmbCamera.Items.Clear()
        For Each camera As Camera In _Session.Cameras.OrderBy(Function(x) x.UniqueName)
            cmbCamera.Items.Add(New ComboBoxItem(Of Camera)(camera.UniqueName, camera))
        Next
    End Sub
    Private Sub PopulateColourFormats()
        cmbColourFormat.Items.Clear()
        For Each sf As StreamFormat In _Session.Camera?.ColourFormats.OrderBy(Function(x) x.Key)
            cmbColourFormat.Items.Add(New ComboBoxItem(Of StreamFormat)(sf.ToString, sf))
        Next
    End Sub
    Private Sub PopulateDepthFormats()
        cmbDepthFormat.Items.Clear()
        For Each sf As StreamFormat In _Session.Camera?.DepthFormats.OrderBy(Function(x) x.Key)
            cmbDepthFormat.Items.Add(New ComboBoxItem(Of StreamFormat)(sf.ToString, sf))
        Next
    End Sub
    Private Sub ReStartCamera()

        If _Populating Then Exit Sub

        Dim hadcolour As Boolean = _ColourPicture IsNot Nothing
        Dim haddepth As Boolean = _DepthPicture IsNot Nothing
        chkViewColour.Checked = False
        chkViewDepth.Checked = False
        DisplayDepth(False)
        _Session.RestartCamera()
        chkViewColour.Checked = hadcolour
        chkViewDepth.Checked = haddepth
    End Sub
    Private Sub SelectFirstCamera()

        PopulateCameras()

        Dim cbim As ComboBoxItem(Of Camera) = cmbCamera.Items.Cast(Of ComboBoxItem(Of Camera)).FirstOrDefault
        cmbCamera.SelectedItem = cbim

        ' Automagically choose the ideal resultions
        PopulateDepthFormats()
        Dim cbid As ComboBoxItem(Of StreamFormat) = cmbDepthFormat.
                                                    Items.
                                                    Cast(Of ComboBoxItem(Of StreamFormat)).
                                                    Where(Function(x) x.Name.Contains("848x480")).
                                                    FirstOrDefault
        cmbDepthFormat.SelectedItem = cbid
        _Logger.Trace("DepthFormat defaults to {0}", cmbDepthFormat.SelectedItem?.ToString)

        PopulateColourFormats()
        Dim cbic As ComboBoxItem(Of StreamFormat) = cmbColourFormat.
                                                    Items.
                                                    Cast(Of ComboBoxItem(Of StreamFormat)).
                                                    Where(Function(x) x.Name.Contains("848x480")).
                                                    FirstOrDefault
        cmbColourFormat.SelectedItem = cbic
        _Logger.Trace("ColourFormat defaults to {0}", cmbColourFormat.SelectedItem?.ToString)

        cmbFrameRate.SelectedItem = "60"
        _Session.Camera.Framerate = Convert.ToInt32(cmbFrameRate.SelectedItem)
    End Sub
    Private Sub SetEnabled()
        Select Case _Session.State
            Case State.FindTargets

            Case State.Idle
            Case State.ImproveTargets
            Case State.Measure
            Case State.NoTargets
        End Select
    End Sub
    Private Sub StartCamera()

        If _Populating Then Exit Sub

        _Session.StartCamera()
        DisplayColour(chkViewColour.Checked)
        DisplayDepth(chkViewDepth.Checked)
    End Sub
    Public Sub Status(message As String, colour As Color)
        If IsHandleCreated Then ' should always be, but you never know
            BeginInvoke(
                Sub()
                    rtbMessages.SuspendLayout()
                    rtbMessages.SelectionColor = colour
                    rtbMessages.AppendText(message & vbCr)
                    rtbMessages.ScrollToCaret()
                    rtbMessages.ResumeLayout()
                    rtbMessages.Refresh()
                End Sub)
        End If
    End Sub
End Class
