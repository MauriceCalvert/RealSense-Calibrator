Imports Calibrator
Public Class Measuring
    Private _Plane As Plane
    Public Property Plane As Plane
        Get
            Return _Plane
        End Get
        Set(value As Plane)
            If value Is Nothing Then
                Exit Property
            End If
            _Plane = value
            rcBottomLeft.Target = Plane.BottomLeft
            rcBottomRight.Target = Plane.BottomRight
            rcMiddle.Target = Plane.Middle
            rcTopLeft.Target = Plane.TopLeft
            rcTopRight.Target = Plane.TopRight
        End Set
    End Property
    Public Sub ShowSkew()
        lblBottom.Text = ""
        lblLeft.Text = ""
        lblRight.Text = ""
        lblTop.Text = ""

        Dim tl As Double = Plane.TopLeft.MeanZ
        Dim tr As Double = Plane.TopRight.MeanZ
        Dim bl As Double = Plane.BottomLeft.MeanZ
        Dim br As Double = Plane.BottomRight.MeanZ

        If tl > bl + 3 AndAlso tr > br + 3 Then ' Top leaning backwards
            lblTop.Text = "Too far"
            lblBottom.Text = "Too close"
        ElseIf tl < bl - 3 AndAlso tr < br - 3 Then ' Top leaning forwards
            lblTop.Text = "Too close"
            lblBottom.Text = "Too far"
        End If

        If tl > tr + 3 AndAlso bl > br + 3 Then
            lblLeft.Text = "Too far"
            lblRight.Text = "Too close"
        ElseIf tl < tr - 3 AndAlso bl < br - 3 Then
            lblLeft.Text = "Too close"
            lblRight.Text = "Too far"
        End If

    End Sub
End Class
