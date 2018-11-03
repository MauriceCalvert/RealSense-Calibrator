Imports System.Windows
Imports System.Runtime.InteropServices
''' <summary>
''' Convenience class to hold rows and columns.
''' Identical to a 2D point, but with nicer names
''' </summary>
Public Structure RowCol
    Implements IEquatable(Of RowCol)

    Private _Row As Integer

    Private _Col As Integer

    Public Sub New(nrow As Integer, ecol As Integer)
        _Row = nrow
        _Col = ecol
    End Sub
    Public ReadOnly Property Col As Integer
        Get
            Return _Col
        End Get
    End Property
    Public ReadOnly Property Length As Integer
        Get
            Return Convert.ToInt32(Math.Sqrt(_Row * _Row + _Col * _Col))
        End Get
    End Property
    Public ReadOnly Property Row As Integer
        Get
            Return _Row
        End Get
    End Property
    Public Shared Operator -(a As RowCol, b As RowCol) As Integer
        Dim dn As Integer = a.Row - b.Row
        Dim de As Integer = a.Col - b.Col
        Return Convert.ToInt32(Math.Abs(Math.Sqrt(dn * dn + de * de)))
    End Operator

#Region "IEquatable"
    Public Function Equals1(other As RowCol) As Boolean Implements IEquatable(Of RowCol).Equals
        Return Row = other.Row AndAlso Col = other.Col
    End Function
    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals1(DirectCast(other, RowCol))
    End Function
    Public Overrides Function GetHashCode() As Integer

        'Return Row.GetHashCode Xor Col.GetHashCode

        ' http://stackoverflow.com/questions/4654227/overriding-gethashcode-in-vb-without-checked-unchecked-keyword-support
        Dim hashCode As HashCodeNoOverflow

        hashCode.Int64 = 17

        hashCode.Int64 = CLng(hashCode.Int32) * 23 + Row.GetHashCode
        hashCode.Int64 = CLng(hashCode.Int32) * 23 + Col.GetHashCode

        Return hashCode.Int32

    End Function
    Public Shared Operator =(a As RowCol, b As RowCol) As Boolean
        Return a.Row = b.Row AndAlso a.Col = b.Col
    End Operator
    Public Shared Operator <>(a As RowCol, b As RowCol) As Boolean
        Return Not (a = b)
    End Operator
#End Region
    Public Overrides Function ToString() As String
        Return String.Format("{0},{1}", Row, Col)
    End Function

End Structure
