Imports System.Windows
Imports System.Windows.Media.Media3D
Module Extensions

    ''' <summary>
    ''' Convenience functions, to ease coding and readability (by avoiding CSng, Convert.ToXXX etc.)
    ''' </summary>
    <System.Runtime.CompilerServices.Extension>
    Public Function ToPointf(point As Point) As System.Drawing.PointF
        Return New System.Drawing.PointF(CSng(point.X), CSng(point.Y))
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToInt(x As Double) As Integer
        Return Convert.ToInt32(x)
    End Function

    Public Sub DrawLine(g As Graphics, p As Pen, x1 As Double, y1 As Double, x2 As Double, y2 As Double)
        g.DrawLine(p, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
    End Sub
    Public Sub DrawLine(g As Graphics, p As Pen, a As Point, b As Point)
        g.DrawLine(p, CSng(a.X), CSng(a.Y), CSng(b.X), CSng(b.Y))
    End Sub
    Public Function IntegerRectangle(r As RectangleF) As Rectangle
        Return New Rectangle(Convert.ToInt32(r.X),
                             Convert.ToInt32(r.Y),
                             Convert.ToInt32(r.Width),
                             Convert.ToInt32(r.Height))
    End Function

End Module
