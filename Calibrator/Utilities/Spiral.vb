Imports System.Windows
Public Module Spiral_
    ''' <summary>
    ''' O(1) function to get successive points on a spiral.
    ''' https://stackoverflow.com/questions/398299/looping-in-a-spiral
    ''' </summary>
    ''' <param name="n">The number of the desired point. 0= the first one</param>
    ''' <returns>Next RowCol on the spiral (and updates N)</returns>
    Public Function Spiral(ByRef n As Integer) As Drawing.Point
        ' given n an index in the squared spiral
        ' p the sum of point in inner square
        ' a the position on the current square
        ' n = p + a
        ' starts with y 0 x -1
        Dim r As Integer = Convert.ToInt32(Math.Floor((Math.Sqrt(n + 1) - 1) / 2) + 1)

        ' compute radius : inverse arithmetic sum of 8+16+24+...=
        Dim p As Integer = (8 * r * (r - 1)) \ 2
        ' compute total point on radius -1 : arithmetic sum of 8+16+24+...

        Dim en As Integer = r * 2
        ' points by face

        Dim a As Integer = (1 + n - p) Mod (r * 8)
        ' compute the position and shift it so the first is (-r,-r) but (-r+1,-r)
        ' so square can connect

        Dim y As Integer
        Dim x As Integer

        Select Case Math.Floor(a \ (r * 2))
            ' find the face : 0 top, 1 right, 2, bottom, 3 left
            Case 0
                y = a - r
                x = -r
            Case 1
                y = r
                x = (a Mod en) - r
            Case 2
                y = r - (a Mod en)
                x = r
            Case 3
                y = -r
                x = r - (a Mod en)
        End Select
        n += 1
        Return New Drawing.Point(x, y)
    End Function
End Module
