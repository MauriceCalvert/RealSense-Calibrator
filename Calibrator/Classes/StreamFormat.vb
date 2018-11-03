Imports System.Windows
Imports Intel.RealSense
''' <summary>
''' Helper for sorting, comparing and displaying stream formats
''' </summary>
Public Class StreamFormat
    Implements IEquatable(Of StreamFormat)

    Public ReadOnly Property Format As Format
    Public ReadOnly Property Height As Integer
    Public ReadOnly Property Width As Integer

    Public Sub New(format As Format, width As Integer, height As Integer)
        _Format = format
        _Width = width
        _Height = height
    End Sub
    Public ReadOnly Property FormatName As String
        Get
            Return [Enum].GetName(GetType(Format), Format)
        End Get
    End Property
    Public ReadOnly Property Key As String
        Get
            Return $"{FormatName.PadRight(LongestFormatName)} {Width:D4} {Height:D3}"
        End Get
    End Property
    Public Function LongestFormatName() As Integer
        Return [Enum].GetNames(GetType(Format)).Select(Function(x) x.Length).Max
    End Function
    Public Overrides Function ToString() As String
        Return $"{[Enum].GetName(GetType(Format), Format)} {Width}x{Height}"
    End Function

#Region "IEquatable"
    Public Function Equals1(other As StreamFormat) As Boolean Implements IEquatable(Of StreamFormat).Equals
        Return Me.ToString = other.ToString ' cheap, cheerful and LAZY
    End Function
    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals1(DirectCast(other, StreamFormat))
    End Function
    Public Overrides Function GetHashCode() As Integer

        ' http://stackoverflow.com/questions/4654227/overriding-gethashcode-in-vb-without-checked-unchecked-keyword-support
        Dim hashCode As HashCodeNoOverflow

        hashCode.Int64 = 17

        hashCode.Int64 = CLng(hashCode.Int32) * 23 + ToString.GetHashCode

        Return hashCode.Int32

    End Function
    Public Shared Operator =(a As StreamFormat, b As StreamFormat) As Boolean
        Return a.ToString = b.ToString
    End Operator
    Public Shared Operator <>(a As StreamFormat, b As StreamFormat) As Boolean
        Return Not (a = b)
    End Operator
#End Region
End Class
