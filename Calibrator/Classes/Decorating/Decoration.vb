''' <summary>
''' A geometrical figure, annotation drawn on a bitmap
''' </summary>
Public MustInherit Class Decoration
    Implements IEquatable(Of Decoration)
    Public ReadOnly Property Priority As Integer ' smaller gets drawn before larger
    Public Sub New(priority As Integer)
        _Priority = priority
    End Sub
    MustOverride Sub Draw(picture As Bitmap)
    MustOverride Function Key() As String
    Public Overrides Function ToString() As String
        Return Key()
    End Function
#Region "IEquatable"
    Public Function Equals1(other As Decoration) As Boolean Implements IEquatable(Of Decoration).Equals
        Return Key() = other.Key
    End Function
    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals1(DirectCast(other, Decoration))
    End Function
    Public Overrides Function GetHashCode() As Integer

        'Return Row.GetHashCode Xor Col.GetHashCode

        ' http://stackoverflow.com/questions/4654227/overriding-gethashcode-in-vb-without-checked-unchecked-keyword-support
        Dim hashCode As HashCodeNoOverflow

        hashCode.Int64 = 17

        hashCode.Int64 = CLng(hashCode.Int32) * 23 + Key.GetHashCode

        Return hashCode.Int32

    End Function
    Public Shared Operator =(a As Decoration, b As Decoration) As Boolean
        Return a.Key = b.Key
    End Operator
    Public Shared Operator <>(a As Decoration, b As Decoration) As Boolean
        Return Not (a = b)
    End Operator
#End Region
End Class
