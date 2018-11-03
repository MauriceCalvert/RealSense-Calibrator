Imports System.Windows
Public Module Between_
    ''' <summary>
    ''' Determine if a value is in a certain range
    ''' </summary>
    ''' <param name="x">the value</param>
    ''' <param name="min">the minimum</param>
    ''' <param name="max">the maximum</param>
    ''' <returns>TRUE if value is strictly with min...max</returns>
    Public Function Between(x As Double, min As Double, max As Double) As Boolean
        If min <= max Then
            Return x >= min AndAlso x <= max
        Else
            Return x >= max AndAlso x <= min
        End If
    End Function

End Module
