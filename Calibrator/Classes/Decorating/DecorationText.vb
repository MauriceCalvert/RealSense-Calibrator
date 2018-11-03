Imports System.Windows
''' <summary>
''' A Text drawn on a bitmap
''' </summary>
Public Class DecorationText
    Inherits Decoration
    Public ReadOnly Property X As Double
    Public ReadOnly Property Y As Double
    Public ReadOnly Property Text As String
    Public ReadOnly Property Colour As Color
    Public ReadOnly Property Font As Font

    Sub New(x As Double, y As Double, text As String, font As Font, colour As Color)
        MyBase.New(2)
        _X = x
        _Y = y
        _Text = text
        _Font = font
        _Colour = colour
    End Sub
    Public Overrides Sub Draw(picture As Bitmap)
        Using g As Graphics = Graphics.FromImage(picture)
            GDIBestQuality(g)
            Dim size As SizeF = g.MeasureString(Text, Me.Font)
            Using b As New SolidBrush(Color.FromArgb(255, 32, 32, 32))
                g.FillRectangle(b, New Rectangle(CInt(X - size.Width / 2) - 2, CInt(Y - size.Height * 1.5) - 2, CInt(size.Width) + 4, CInt(size.Height) + 4))
            End Using
            Using b As New SolidBrush(Colour)
                g.DrawString(Text, Font, b, CSng(X - size.Width / 2), CSng(Y - size.Height * 1.5))
            End Using
        End Using
    End Sub
    Public Overrides Function Key() As String
        Return $"T {X:0},{Y:0} {Text}"
    End Function
    Public Overrides Function ToString() As String
        Return Key()
    End Function

End Class
