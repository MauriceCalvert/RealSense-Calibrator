Imports System.Windows
''' <summary>
''' An HSV value
''' </summary>
''' <remarks></remarks>
Public Structure HSV
    Implements IEquatable(Of HSV)

    Public Hue As Double
    Public Saturation As Double
    Public Value As Double

    Shared Sub New()
    End Sub
    Public Sub New(color As Color)
        Dim result As HSV = ColorToHSV(color)
        Hue = result.Hue
        Saturation = result.Saturation
        Value = result.Value
    End Sub
    Public Sub New(ByVal H As Double, ByVal S As Double, ByVal V As Double)
        Hue = H
        Saturation = S
        Value = V
    End Sub

    Public Function Equals1(other As HSV) As Boolean Implements IEquatable(Of HSV).Equals
        ' Converting to/from coloours creates rounding errors, sometimes quite ugly.
        ' As this is purely for human consumption, we don't give a fuck
        Return Math.Abs(Hue - other.Hue) < 0.000001 AndAlso
               Math.Abs(Saturation - other.Saturation) < 0.000001 AndAlso
               Math.Abs(Value - other.Value) < 0.000001
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals1(DirectCast(obj, HSV))
    End Function

    Public Shared Operator =(a As HSV, b As HSV) As Boolean
        Return a.Equals(b)
    End Operator
    Public Shared Operator <>(a As HSV, b As HSV) As Boolean
        Return Not a.Equals(b)
    End Operator
    Public Overrides Function ToString() As String
        Return $"{Hue * 360:0.0}° {Saturation * 100:0.0}% {Value * 100:0.0}%"
    End Function
End Structure

''' <summary>
''' Convert between RGB an HSV
''' </summary>
''' <remarks></remarks>
Public Module RGBHSV

    ''' <summary>
    ''' Convert a System.Color to an HSV value
    ''' </summary>
    ''' <param name="color">any colour</param>
    ''' <returns>the HSV equivalent</returns>
    ''' <remarks>Converting between RGB and HSV always works, but it is not guaranteed to be reflexive.
    ''' IOW, converting colour C to an HSV value H and then converting H back to C doesn't always
    ''' give the original value
    ''' </remarks>
    Public Function ColorToHSV(ByVal color As Color) As HSV
        Dim max As Double = Math.Max(color.R, Math.Max(color.G, color.B))
        Dim min As Double = Math.Min(color.R, Math.Min(color.G, color.B))
        Dim result As New HSV
        With result
            .Hue = color.GetHue() / 360
            .Saturation = If((max = 0), 0, 1.0 - (min / max))
            .Value = max / 255
        End With
        Return result
    End Function

    ''' <summary>
    ''' Convert an HSV value to a System.Color
    ''' </summary>
    ''' <param name="hsv">an HSV value</param>
    ''' <returns>the corresponding colour</returns>
    ''' <remarks>Converting between RGB and HSV always works, but it is not guaranteed to be reflexive.
    ''' IOW, converting colour C to an HSV value H and then converting H back to C doesn't always
    ''' give the original value
    ''' </remarks>
    Public Function HSVToColour(ByVal hsv As HSV) As Color
        Dim hi As Double
        Dim f As Double

        With hsv
            Dim hu As Double = .Hue * 360
            hi = Convert.ToInt32(Math.Floor(hu / 60)) Mod 6
            f = hu / 60 - Math.Floor(hu / 60)
            Dim v255 As Double = .Value * 255
            Dim v As Integer = Convert.ToInt32(v255)
            Dim p As Integer = Convert.ToInt32(v255 * (1 - .Saturation))
            Dim q As Integer = Convert.ToInt32(v255 * (1 - f * .Saturation))
            Dim t As Integer = Convert.ToInt32(v255 * (1 - (1 - f) * .Saturation))

            If v < 0 Then v = 0
            If v > 255 Then v = 255

            If p < 0 Then p = 0
            If p > 255 Then p = 255

            If q < 0 Then q = 0
            If q > 255 Then q = 255

            If t < 0 Then t = 0
            If t > 255 Then t = 255

            If hi = 0 Then
                Return Color.FromArgb(255, v, t, p)
            ElseIf hi = 1 Then
                Return Color.FromArgb(255, q, v, p)
            ElseIf hi = 2 Then
                Return Color.FromArgb(255, p, v, t)
            ElseIf hi = 3 Then
                Return Color.FromArgb(255, p, q, v)
            ElseIf hi = 4 Then
                Return Color.FromArgb(255, t, p, v)
            Else
                Return Color.FromArgb(255, v, p, q)
            End If
        End With
    End Function

End Module
