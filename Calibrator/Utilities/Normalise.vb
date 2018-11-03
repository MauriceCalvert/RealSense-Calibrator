Imports System.Windows
Public Module Normalise_
    ''' <summary>
    ''' Normalise an RGB colour
    ''' </summary>
    Public Function Normalise(colour As Color) As Color
        Dim alpha As Integer = colour.A
        Dim red As Integer = colour.R
        Dim green As Integer = colour.G
        Dim blue As Integer = colour.B
        Dim total As Integer = red + green + blue
        If total = 0 Then
            Return Color.FromArgb(alpha, 0, 0, 0)
        End If
        Dim newred As Integer = ((red / total) * 255).ToInt
        Dim newgreen As Integer = ((green / total) * 255).ToInt
        Dim newblue As Integer = ((blue / total) * 255).ToInt
        Return Color.FromArgb(alpha, newred, newgreen, newblue)
    End Function

End Module
