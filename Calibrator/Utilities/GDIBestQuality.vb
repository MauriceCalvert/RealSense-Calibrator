Imports System.Windows
Imports System.Drawing

Public Module GDIBestQuality_
    ''' <summary>
    ''' Set the best possible GDI quality
    ''' </summary>
    ''' <param name="g">The Graphics to improve</param>
    Public Sub GDIBestQuality(g As Graphics)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
    End Sub

End Module
