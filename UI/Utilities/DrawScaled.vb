Imports System.Drawing

Public Module DrawScaled_

    Public Sub DrawScaled(source As Bitmap, ByVal target As Image)
        Dim scale As Double = SizeRatio(source, target)
        Dim x As Integer = Math.Max(0, (target.Width - Convert.ToInt32(source.Width * scale)) \ 2)
        Dim y As Integer = 0
        Using g As Graphics = Graphics.FromImage(target)
            g.Clear(Color.Black)
            g.DrawImage(source, x, y, Convert.ToInt32(source.Width * scale), Convert.ToInt32(source.Height * scale))
        End Using
    End Sub
    Public Function SizeRatio(source As Bitmap, ByVal target As Image) As Double
        If source Is Nothing OrElse target Is Nothing Then
            Return 1
        End If
        Return Math.Min(target.Width / source.Width, target.Height / source.Height)
    End Function

End Module
