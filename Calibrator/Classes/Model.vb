Imports System.Windows.Media.Media3D
Imports System.Math
Imports NLog

''' <summary>
''' Statistical representation of a camera's intrinsics and extrinsics.
''' </summary>
Public Class Model
    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Public Sub New(camera As Camera, planes As Planes)

        _Camera = camera
        _Planes = planes

        _HPixels = camera.DepthFormat.Width
        _VPixels = camera.DepthFormat.Height

        Debug.Assert(HPixels = camera.DepthIntrinsics.width)
        Debug.Assert(VPixels = camera.DepthIntrinsics.height)

        ' Start with the camera's reported FOVs
        _HFov = camera.DepthHFov
        _VFov = camera.DepthVFov
    End Sub
    ''' <summary>
    ''' The camera that we're modelling
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property Camera As Camera
    ''' <summary>
    ''' The horizontal deviation of the camera relative to the targets.
    ''' </summary>
    ''' <returns>Radians, positive = The camera is pointing to the right of the target's centre</returns>
    Public ReadOnly Property Deviation As Double
    ''' <summary>
    ''' The centre (pixel) column of the camera.
    ''' </summary>
    ''' <returns>A real value; if the camera has an even number of columns there is no integer centre column</returns>
    Friend ReadOnly Property HCentre As Double
        Get
            Return (HPixels - 1) / 2
        End Get
    End Property
    ''' <summary>
    ''' Horizontal field of view
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property HFov As Double
    ''' <summary>
    ''' Half the horizontal field of view
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property HFov2 As Double
        Get
            Return HFov / 2
        End Get
    End Property
    ''' <summary>
    ''' The width of a pixel
    ''' </summary>
    ''' <returns>real-world units</returns>
    Friend ReadOnly Property HPixel As Double
        Get
            Return HSize / (HPixels - 1)
        End Get
    End Property
    ''' <summary>
    ''' The number of columns
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property HPixels As Double
    ''' <summary>
    ''' The horizontal size of the image.
    ''' AKA Fx
    ''' </summary>
    Friend ReadOnly Property HSize As Double
        Get
            Return Tan(HFov / 2) * 2
        End Get
    End Property
    ''' <summary>
    ''' The up/down inclination of the camera relative to the targets.
    ''' </summary>
    ''' <returns>Radians, positive = The camera is pointing to above the target</returns>
    Public ReadOnly Property Inclination As Double
    ''' <summary>
    ''' The Planes measured so far
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Planes As Planes
    ''' <summary>
    ''' Calculate the coordinates, in mm, of a 3Dpoint in space in front of the camera,
    ''' given the row, column and range.
    ''' </summary>
    Friend ReadOnly Property Predict(row As Double, col As Double, range As Double) As Point3D
        Get
            Dim vratio As Double = (VCentre - row) * VPixel
            Dim hratio As Double = (col - HCentre) * HPixel
            Dim z As Double = range + QuadraticA * range * range + QuadraticB * range + QuadraticC
            Dim y As Double = range * -vratio
            Dim x As Double = range * hratio
            Return New Point3D(x, y, z)
        End Get
    End Property
    'Friend ReadOnly Property PredictOld(row As Double, col As Double, range As Double) As Point3D
    '    Get
    '        Dim voffset As Double = VCentre - row
    '        Dim vratio As Double = voffset * VPixel
    '        Dim vangle As Double = -Atan(vratio) - Inclination
    '        Dim hyp As Double = range / Cos(Inclination - vangle)
    '        Dim ground As Double = hyp * Cos(vangle)
    '        Dim hoffset As Double = col - HCentre
    '        Dim hratio As Double = hoffset * HPixel
    '        Dim hangle As Double = Atan(hratio) + Deviation
    '        Dim z As Double = ground + QuadraticA * ground * ground + QuadraticB * ground + QuadraticC
    '        Dim y As Double = ground * Tan(vangle)
    '        Dim x As Double = ground * Tan(hangle)
    '        Return New Point3D(x, y, z)
    '    End Get
    'End Property
    ''' <summary>
    ''' The 'A' value - the squared part - of the quadratic correction of the Z values
    ''' </summary>
    Public ReadOnly Property QuadraticA As Double
    ''' <summary>
    ''' The 'B' value - the linear part - of the quadratic correction of the Z values
    ''' </summary>
    Public ReadOnly Property QuadraticB As Double
    ''' <summary>
    ''' The 'C' value - the distance of the from the front of the camera glass to the depthmap focal point.
    ''' Positive = behind the glass (it usually is).
    ''' </summary>
    Public Property QuadraticC As Double
    ''' <summary>
    ''' The average measurement error for all targets of all planes
    ''' </summary>
    Public ReadOnly Property AverageError As Double
        Get
            Return Planes.Average(Function(q) AverageError(q))
        End Get
    End Property
    ''' <summary>
    ''' The average measurement error for all targets of a single plane
    ''' </summary>
    Public ReadOnly Property AverageError(plane As Plane) As Double
        Get
            Dim result As Double = 0
            Dim offset As Vector3D = plane.Offset(Me)

            For Each target As Target In plane.Targets.Where(Function(q) q IsNot plane.Middle)

                Dim truth As Point3D = target.Truth
                Dim prediction As Point3D = Predict(target.Row, target.Col, target.Z)
                Dim mismatch As Vector3D = prediction - truth - offset

                result += mismatch.Length
            Next

            Return result / (plane.Targets.Count - 1) ' Middle plane has no error, it's in the centre!
        End Get
    End Property
    ''' <summary>
    ''' Total error, squared, used solely by the optimiser
    ''' </summary>
    Friend ReadOnly Property TotalErrorSquared As Double
        Get
            Dim result As Double = 0

            For Each plane As Plane In Planes

                Dim offset As Vector3D = plane.Offset(Me)

                For Each target As Target In plane.Targets

                    Dim truth As Point3D = target.Truth
                    Dim prediction As Point3D = Predict(target.Row, target.Col, target.Z)
                    Dim mismatch As Vector3D = prediction - truth - offset

                    result += mismatch.LengthSquared
                Next
            Next
            Return result
        End Get
    End Property
    ''' <summary>
    ''' The vertical (pixel) centre.
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property VCentre As Double
        Get
            Return (VPixels - 1) / 2
        End Get
    End Property
    ''' <summary>
    ''' Vertical field of view
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property VFov As Double
    ''' <summary>
    ''' Half the vertical field of view
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property VFov2 As Double
        Get
            Return VFov / 2
        End Get
    End Property
    ''' <summary>
    ''' The height of a pixel
    ''' </summary>
    ''' <returns>real-world units</returns>
    Friend ReadOnly Property VPixel As Double
        Get
            Return VSize / (VPixels - 1)
        End Get
    End Property
    ''' <summary>
    ''' The number of vertical pixels, or rows
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property VPixels As Double
    ''' <summary>
    ''' The vertical size of the image.
    ''' AKA Fy
    ''' </summary>
    Friend ReadOnly Property VSize As Double
        Get
            Return Tan(VFov / 2) * 2
        End Get
    End Property
End Class
