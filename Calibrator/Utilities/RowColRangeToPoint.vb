Imports System.Math
Imports System.Windows.Media.Media3D
''' <summary>
''' Template code to determine 3D point from Row, Column and Depth
''' </summary>
Module RowColRangeToPoint_
    Const Cols As Integer = 848
    Const Rows As Integer = 480
    Const HFov As Double = 1.52723940226235
    Const VFov As Double = 1.00013130431485
    Const A As Double = -0.0000196355121038795
    Const B As Double = -0.0217963791803833
    Const C As Double = 5.91108175482591

    Const VCentre As Double = (Rows - 1) / 2
    Const HCentre As Double = (Cols - 1) / 2
    Const HFov2 As Double = HFov / 2
    Const VFov2 As Double = HFov / 2
    Private ReadOnly Property VSize As Double = Tan(VFov / 2) * 2
    Private ReadOnly Property HSize As Double = Tan(HFov / 2) * 2
    Private ReadOnly Property VPixel As Double = VSize / (Rows - 1)
    Private ReadOnly Property HPixel As Double = HSize / (Cols - 1)

    Public Function RowColRangeToPoint(row As Double, col As Double, range As Double) As Point3D
        Dim vratio As Double = (VCentre - row) * VPixel
        Dim hratio As Double = (col - HCentre) * HPixel
        Dim z As Double = range + A * range * range + B * range + C
        Dim y As Double = range * -vratio
        Dim x As Double = range * hratio
        Return New Point3D(x, y, z)
    End Function
End Module
