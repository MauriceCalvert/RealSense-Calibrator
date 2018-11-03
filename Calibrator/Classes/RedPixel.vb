Imports System.Runtime.Serialization
''' <summary>
''' A red pixel on a target, on a plane.
''' By making a large number of measurements, we can gather accurate statistics about the Z distance.
''' </summary>
<DataContract>
Friend Class RedPixel
    Implements IEquatable(Of RedPixel)

    <DataMember>
    Private _Col As Integer
    Private _Row As Integer
    Private _Redness As Integer
    Private _Statistic As Statistic
    Public Sub New()
    End Sub
    Friend Sub New(row As Integer, col As Integer, redness As Integer)
        _Row = row
        _Col = col
        Debug.Assert(redness > 0)
        _Redness = redness
    End Sub
    Friend Sub Clear()
        Statistic.Clear()
    End Sub
    <DataMember>
    Friend Property Col As Integer
        Get
            Return _Col
        End Get
        Private Set(value As Integer)
            _Col = value
        End Set
    End Property
    Friend Shared Function GetKey(col As Integer, row As Integer) As Long
        Return CLng(col) << 32 Or row
    End Function
    Friend ReadOnly Property Key As Long
        Get
            Return GetKey(Col, Row)
        End Get
    End Property
    Friend Sub Update(value As Double)
        Statistic.Add(value)
    End Sub
    <DataMember>
    Friend Property Redness As Integer
        Get
            Return _Redness
        End Get
        Set(value As Integer)
            _Redness = value
        End Set
    End Property
    <DataMember>
    Friend Property Row As Integer
        Get
            Return _Row
        End Get
        Private Set(value As Integer)
            _Row = value
        End Set
    End Property
    Friend ReadOnly Property Samples As Integer
        Get
            Return Statistic.Count
        End Get
    End Property
    Friend ReadOnly Property Sigma As Double
        Get
            Return Statistic.Sigma
        End Get
    End Property
    <DataMember>
    Friend Property Statistic As Statistic
        Get
            If _Statistic Is Nothing Then
                _Statistic = New Statistic
            End If
            Return _Statistic
        End Get
        Private Set(value As Statistic)
            _Statistic = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return $"R{Row},C{Col}={Z}"
    End Function
    Friend ReadOnly Property Variance As Double
        Get
            Return Statistic.Variance
        End Get
    End Property
    Friend ReadOnly Property Z As Double
        Get
            Return Statistic.Average
        End Get
    End Property
#Region "IEquatable"
    Public Function Equals1(other As RedPixel) As Boolean Implements IEquatable(Of RedPixel).Equals
        Return Key = other.Key
    End Function
    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals1(DirectCast(other, RedPixel))
    End Function
    Public Overrides Function GetHashCode() As Integer

        'Return Y.GetHashCode Xor X.GetHashCode

        ' http://stackoverflow.com/questions/4654227/overriding-gethashcode-in-vb-without-checked-unchecked-keyword-support
        Dim hashCode As HashCodeNoOverflow

        hashCode.Int64 = 17

        hashCode.Int64 = CLng(hashCode.Int32) * 23 + Key.GetHashCode

        Return hashCode.Int32

    End Function
    Public Shared Operator =(a As RedPixel, b As RedPixel) As Boolean
        Return a.Key = b.Key
    End Operator
    Public Shared Operator <>(a As RedPixel, b As RedPixel) As Boolean
        Return Not (a = b)
    End Operator
#End Region
End Class
