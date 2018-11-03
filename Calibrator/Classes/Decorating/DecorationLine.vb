Imports System.Windows
''' <summary>
''' A Line drawn on a bitmap
''' </summary>
Public Class DecorationLine
    Inherits Decoration

    Public ReadOnly Property Start As Point
    Public ReadOnly Property Finish As Point
    Public ReadOnly Property Width As Single
    Public ReadOnly Property Colour As Color

    Sub New(start As Point, finish As Point, Width As Single, colour As Color)
        MyBase.New(0)
        _Start = start
        _Finish = finish
        _Width = Width
        _Colour = colour
    End Sub

    Public Overrides Sub Draw(picture As Bitmap)
        Using g As Graphics = Graphics.FromImage(picture)
            GDIBestQuality(g)
            Using p As New Pen(Color.Black, Width)
                DrawLine(g, p, Start, Finish)
            End Using
            Using p As New Pen(Colour, Width)
                p.DashPattern = {3, 3}
                DrawLine(g, p, Start, Finish)
            End Using
        End Using
    End Sub
    Public Overrides Function Key() As String
        Return $"L {Start.X:0},{Start.Y:0} {Finish.X:0},{Finish.Y:0}"
    End Function
    Public Overrides Function ToString() As String
        Return Key()
    End Function

End Class
