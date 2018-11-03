Imports System.Windows
Public Module Bresenham_
    ''' <summary>
    ''' Get a line of pixels between two 2D points.
    ''' </summary>
    ''' <param name="a">Start point</param>
    ''' <param name="b">Finish point</param>
    ''' <returns>Shortest possible list of points from a to b whe each pixel touches the next one</returns>
    Public Function Bresenham(a As Point, b As Point) As IEnumerable(Of Point)
        Return Bresenham(a.X.ToInt, a.Y.ToInt, b.X.ToInt, b.Y.ToInt)
    End Function

    Public Function Bresenham(y As Integer, x As Integer, y2 As Integer, x2 As Integer) As IEnumerable(Of Point)
        If y = y2 AndAlso x = x2 Then
            Throw New Exception("Bresenham start=finish")
        End If
        ' Bresenham's algorithm
        ' http://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        Dim w As Integer = x2 - x
        Dim h As Integer = y2 - y
        Dim dx1 As Integer = 0, dy1 As Integer = 0, dx2 As Integer = 0, dy2 As Integer = 0
        If w < 0 Then
            dx1 = -1
        ElseIf w > 0 Then
            dx1 = 1
        End If
        If h < 0 Then
            dy1 = -1
        ElseIf h > 0 Then
            dy1 = 1
        End If
        If w < 0 Then
            dx2 = -1
        ElseIf w > 0 Then
            dx2 = 1
        End If
        Dim integerest As Integer = Math.Abs(w)
        Dim shortest As Integer = Math.Abs(h)
        If Not (integerest > shortest) Then
            integerest = Math.Abs(h)
            shortest = Math.Abs(w)
            If h < 0 Then
                dy2 = -1
            ElseIf h > 0 Then
                dy2 = 1
            End If
            dx2 = 0
        End If
        Dim numerator As Integer = integerest >> 1
        Dim previousx As Integer = Integer.MinValue
        Dim previousy As Integer = Integer.MinValue
        Dim result(integerest) As Point
        For i As Integer = 0 To integerest
            result(i) = New Point(y, x)
            numerator += shortest
            If Not (numerator < integerest) Then
                numerator -= integerest
                x += dx1
                y += dy1
            Else
                x += dx2
                y += dy2
            End If
        Next
        Return result
    End Function

End Module
