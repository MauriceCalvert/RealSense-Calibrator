Imports Intel.RealSense
Public Class Intrinsics
    Sub New(intrinsics As Intel.RealSense.Intrinsics)
        InitializeComponent()
        With intrinsics
            Dim coefs(5) As String
            For i As Integer = 0 To intrinsics.coeffs.Count - 1
                coefs(i) = .coeffs(i).ToString
            Next
            txtCoefficient0.Text = coefs(0)
            txtCoefficient1.Text = coefs(1)
            txtCoefficient2.Text = coefs(2)
            txtCoefficient3.Text = coefs(3)
            txtCoefficient4.Text = coefs(4)
            txtCoefficient5.Text = coefs(5)

            txtFOVX.Text = .fx.ToString
            txtFOVY.Text = .fy.ToString
            txtHeight.Text = .height.ToString
            txtModel.Text = [Enum].GetName(GetType(Distortion), .model)
            txtPPX.Text = .ppx.ToString
            txtPPY.Text = .ppy.ToString
            txtWidth.Text = .width.ToString
        End With
    End Sub
End Class