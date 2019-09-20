Imports System.Windows
''' <summary>
''' A circle drawn on a bitmap
''' </summary>
Public Class DecorationCircle
    Inherits Decoration
    Public ReadOnly Property Centre As Point
    Public ReadOnly Property Thickness As Single
    Public ReadOnly Property Height As Double
    Public ReadOnly Property Width As Double
    Public ReadOnly Property Colour As Color

    Sub New(centre As Point, radius As Double, Thickness As Single, colour As Color)
        MyBase.New(1)
        _Centre = centre
        Width = CSng(radius * 2)
        _Height = Width
        _Thickness = Thickness
        _Height = Thickness
        _Colour = colour
    End Sub
    Sub New(centre As Point, width As Double, height As Double, Thickness As Single, colour As Color)
        MyBase.New(1)
        _Centre = centre
        _Width = width
        _Height = height
        _Thickness = Thickness
        _Height = height
        _Colour = colour
    End Sub
    Public Overrides Sub Draw(picture As Bitmap)
        Using g As Graphics = Graphics.FromImage(picture)
            GDIBestQuality(g)
            Using p As New Pen(Color.Black, Thickness)
                g.DrawEllipse(p, New RectangleF(CSng(Centre.X - Width / 2 - Thickness),
                                                CSng(Centre.Y - Height / 2 - Thickness),
                                                CSng(Width + Thickness * 2),
                                                CSng(Height + Thickness * 2)))
            End Using
            Using p As New Pen(Colour, Thickness)
                p.DashPattern = {3, 3}
                g.DrawEllipse(p, New RectangleF(CSng(Centre.X - Width / 2 - Thickness),
                                                CSng(Centre.Y - Height / 2 - Thickness),
                                                CSng(Width + Thickness * 2),
                                                CSng(Height + Thickness * 2)))
            End Using
        End Using
    End Sub
    Public Overrides Function Key() As String
        Return $"C {Centre.X:0},{Centre.Y:0} {Width:0} {Height:0}"
    End Function
    Public Overrides Function ToString() As String
        Return Key()
    End Function

End Class
