Imports System.Windows
Imports Intel.RealSense
Imports System.Math
Public Module Constants

    Public Const TORADIANS As Single = PI / 180
    Public Const TODEGREES As Single = 180 / PI
    Public Const COLOURSTREAMFORMAT As Intel.RealSense.Format = Format.Bgr8

    Public Enum DepthFilters
        None = 0
        Decimation = 1
        HoleFilling = 2
        Spatial = 4
        Temporal = 8
        All = Decimation Or HoleFilling Or Spatial Or Temporal
        ' (DepthToDisparity is inferred)
    End Enum
End Module
