Imports System.Windows
''' <summary>
''' A circle drawn on a bitmap
''' </summary>
Public Class DecorationCircle
    Inherits Decoration
    Public ReadOnly Property Centre As Point
    Public ReadOnly Property Radius As Double
    Public ReadOnly Property Width As Single
    Public ReadOnly Property Colour As Color

    Sub New(centre As Point, radius As Double, width As Single, colour As Color)
        MyBase.New(1)
        _Centre = centre
        _Radius = radius
        _Width = width
        _Colour = colour
    End Sub
    Public Overrides Sub Draw(picture As Bitmap)
        Using g As Graphics = Graphics.FromImage(picture)
            GDIBestQuality(g)
            Using p As New Pen(Color.Black, Width)
                g.DrawEllipse(p, New RectangleF(CSng(Centre.X - Radius - Width),
                                                CSng(Centre.Y - Radius - Width),
                                                CSng((Radius + Width) * 2),
                                                CSng((Radius + Width) * 2)))
            End Using
            Using p As New Pen(Colour, Width)
                p.DashPattern = {3, 3}
                g.DrawEllipse(p, New RectangleF(CSng(Centre.X - Radius - Width),
                                                CSng(Centre.Y - Radius - Width),
                                                CSng((Radius + Width) * 2),
                                                CSng((Radius + Width) * 2)))
            End Using
        End Using
    End Sub
    Public Overrides Function Key() As String
        Return $"C {Centre.X:0},{Centre.Y:0} {Radius:0}"
    End Function
    Public Overrides Function ToString() As String
        Return Key()
    End Function

End Class
