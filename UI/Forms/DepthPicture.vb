Imports System.ComponentModel
Imports Calibrator
Public Class DepthPicture
    Private _Sized As Boolean = False
    Private _DepthMap As DepthMap
    Public Sub New()
        InitializeComponent()
        Picture1.Callback = AddressOf InfoCallback
    End Sub
    Public WriteOnly Property DepthMap As DepthMap
        Set(value As DepthMap)
            _DepthMap = value
        End Set
    End Property
    Private Sub DepthPicture_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Picture1.Callback = Nothing
    End Sub
    Public WriteOnly Property Image As Bitmap
        Set(value As Bitmap)
            Picture1.Image = value
            If Not _Sized Then
                If IsHandleCreated Then
                    BeginInvoke(Sub() ResetSize())
                End If
            End If
        End Set
    End Property
    Private Function InfoCallback(sender As Picture,
                                  buttons As MouseButtons,
                                  clicks As Integer,
                                  x As Double,
                                  y As Double,
                                  delta As Integer) As String
        Try ' Can fail on startup, when resizing, etc., simply ignore
            Dim range As Integer = _DepthMap(Convert.ToInt32(x), Convert.ToInt32(y))
            Return $"{range:#,##0} mm"
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub Picture1_ResetSize() Handles Picture1.ResetSize
        ResetSize()
    End Sub
    Private Sub ResetSize()
        If Picture1.Source Is Nothing Then
            Exit Sub
        End If
        Me.Width = Picture1.Source.Width + (Me.Width - Me.ClientSize.Width) + 2 ' +2 because Picture has a 1-pixel border panel
        Me.Height = Picture1.Source.Height + (Me.Height - Me.ClientSize.Height) + Picture1.pnlInfo.Height + 2
        _Sized = True
    End Sub
End Class