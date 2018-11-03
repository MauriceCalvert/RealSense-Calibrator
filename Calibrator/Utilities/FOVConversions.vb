Public Module FOVConversions
    ''' <summary>
    ''' Convert to/from 'F' values and fields-of-view
    ''' </summary>
    Public Function F2FOV(f As Double, pixels As Double) As Double
        Return 2 * Math.Atan(pixels / (2 * f))
    End Function
    Public Function FOV2F(fov As Double, pixels As Double) As Double
        Return 0.5 * pixels * 1 / Math.Tan(fov / 2)
    End Function

End Module
