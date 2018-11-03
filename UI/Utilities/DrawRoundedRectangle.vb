Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Module DrawRoundedRectangle_

    <Extension()>
    Private Function GenerateRoundedRectangle(ByVal graphics As Graphics, ByVal rectangle As RectangleF, ByVal radius As Single) As GraphicsPath
        Dim diameter As Single
        Dim path As GraphicsPath = New GraphicsPath()

        If radius <= 0.0F Then
            path.AddRectangle(rectangle)
            path.CloseFigure()
            Return path
        Else
            If radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0 Then Return graphics.GenerateCapsule(rectangle)
            diameter = radius * 2.0F
            Dim sizeF As SizeF = New SizeF(diameter, diameter)
            Dim arc As RectangleF = New RectangleF(rectangle.Location, sizeF)
            path.AddArc(arc, 180, 90)
            arc.X = rectangle.Right - diameter
            path.AddArc(arc, 270, 90)
            arc.Y = rectangle.Bottom - diameter
            path.AddArc(arc, 0, 90)
            arc.X = rectangle.Left
            path.AddArc(arc, 90, 90)
            path.CloseFigure()
        End If

        Return path
    End Function

    <Extension()>
    Private Function GenerateCapsule(ByVal graphics As Graphics, ByVal baseRect As RectangleF) As GraphicsPath
        Dim diameter As Single
        Dim arc As RectangleF
        Dim path As GraphicsPath = New GraphicsPath()

        Try

            If baseRect.Width > baseRect.Height Then
                diameter = baseRect.Height
                Dim sizeF As SizeF = New SizeF(diameter, diameter)
                arc = New RectangleF(baseRect.Location, sizeF)
                path.AddArc(arc, 90, 180)
                arc.X = baseRect.Right - diameter
                path.AddArc(arc, 270, 180)
            ElseIf baseRect.Width < baseRect.Height Then
                diameter = baseRect.Width
                Dim sizeF As SizeF = New SizeF(diameter, diameter)
                arc = New RectangleF(baseRect.Location, sizeF)
                path.AddArc(arc, 180, 180)
                arc.Y = baseRect.Bottom - diameter
                path.AddArc(arc, 0, 180)
            Else
                path.AddEllipse(baseRect)
            End If

        Catch
            path.AddEllipse(baseRect)
        Finally
            path.CloseFigure()
        End Try

        Return path
    End Function

    <Extension()>
    Sub DrawRoundedRectangle(ByVal graphics As Graphics, ByVal pen As Pen, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        Dim rectangle As RectangleF = New RectangleF(x, y, width, height)
        Dim path As GraphicsPath = graphics.GenerateRoundedRectangle(rectangle, radius)
        Dim old As SmoothingMode = graphics.SmoothingMode
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        graphics.DrawPath(pen, path)
        graphics.SmoothingMode = old
    End Sub

    <Extension()>
    Sub DrawRoundedRectangle(ByVal graphics As Graphics, ByVal pen As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal radius As Integer)
        graphics.DrawRoundedRectangle(pen, Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(width), Convert.ToSingle(height), Convert.ToSingle(radius))
    End Sub
End Module
