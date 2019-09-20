Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Media.Media3D
Imports Calibrator
Public Class ColourPicture
    Public Model As Model
    Public DepthMap As DepthMap
    Private _Sized As Boolean = False
    Public Sub New()
        InitializeComponent()
        Picture1.Callback = AddressOf InfoCallback
    End Sub
    Private Sub ColourPicture_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Picture1.Callback = Nothing
    End Sub
    Friend WriteOnly Property Image As Bitmap
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
            Dim pixel As Color = Picture1.Source.GetPixel(Convert.ToInt32(x), Convert.ToInt32(y))
            Dim hsv As HSV = ColorToHSV(pixel)
            Dim answer As String = $"RGB {pixel.R},{pixel.G},{pixel.B}  HSV {hsv}"
            Dim more As String = ""
            If Model IsNot Nothing AndAlso DepthMap IsNot Nothing Then
                Dim d As Integer = DepthMap(x.ToInt, y.ToInt)
                If Between(d, 500, 3500) Then
                    Dim p As System.Windows.Media.Media3D.Point3D = Model.Predict(x, y, d)
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub Picture1_ResetSize() Handles Picture1.ResetSize
        ResetSize()
    End Sub
    Private Sub ResetSize() Handles Picture1.ResetSize
        If Picture1.Source Is Nothing Then ' Frame hasn't arrived yet
            Exit Sub
        End If
        Me.Width = Picture1.Source.Width + (Me.Width - Me.ClientSize.Width) + 2 ' +2 because Picture has a 1-pixel border panel
        Me.Height = Picture1.Source.Height + (Me.Height - Me.ClientSize.Height) + Picture1.pnlInfo.Height + 2
        _Sized = True
    End Sub
End Class