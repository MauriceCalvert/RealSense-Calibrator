Imports System.Windows
Public Module Distance_
    ''' <summary>
    ''' Calculate the distance between 2 2D points
    ''' </summary>
    Public Function Distance(n1 As Integer, e1 As Integer, n2 As Integer, e2 As Integer) As Integer
        Dim dn As Long = n1 - n2
        Dim de As Long = e1 - e2
        Return (Math.Sqrt(dn * dn + de * de)).ToInt
    End Function
    Public Function Distance2(n1 As Integer, e1 As Integer, n2 As Integer, e2 As Integer) As Long
        Dim dn As Long = n1 - n2
        Dim de As Long = e1 - e2
        Return dn * dn + de * de
    End Function
End Module
