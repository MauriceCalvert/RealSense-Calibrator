'Imports System.Windows.Media.Media3D ' in presentationcore.dll
Imports Calibrator
Partial Public Class RedCircle

    Private WithEvents _Target As Target
    Private _FPSClock As New Clock(1000 / DISPLAYFRAMERATE)
    Public Sub New()
        InitializeComponent()
        pbPixels.Image = New Bitmap(pbPixels.Width, pbPixels.Height, Imaging.PixelFormat.Format24bppRgb)
    End Sub
    Public Property Target As Target
        Get
            Return _Target
        End Get
        Set(value As Target)
            If value Is Nothing Then
                Exit Property
            End If
            If _Target IsNot Nothing Then
                RemoveHandler _Target.Changed, AddressOf Target_Changed
            End If
            _Target = value
            AddHandler _Target.Changed, AddressOf Target_Changed
        End Set
    End Property
    Private Sub Target_Changed(sender As Target)
        If _FPSClock.Expired Then
            BeginInvoke(
                Sub()
                    With Target
                        txtCol.Text = $"{ .Col:#,##0.000}"
                        txtRow.Text = $"{ .Row:#,##0.000}"
                        txtRadius.Text = $"{ .Radius:0.0}"
                        txtRange.Text = $"{ .MeanRange:#,##0.0}"
                        txtSigma.Text = $"{ .Sigma:0.0}"
                        txtSamples.Text = $"{ .Samples:#,##0}"
                        DrawScaled(Target.Bitmap, pbPixels.Image)
                        Refresh()
                    End With
                End Sub)
        End If
    End Sub
End Class
