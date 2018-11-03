Imports System.Windows
Imports Intel.RealSense
Imports Intel.RealSense.Sensor

Public Class SensorSettings
    Inherits UniqueList(Of SensorSetting)
    Public Sub New()
        MyBase.New
    End Sub
    Public Sub New(options As Sensor.SensorOptions)
        MyBase.New
        For Each o As CameraOption In options
            Me.Add(New SensorSetting(o.Key, o.Value, o.Description, o.Min, o.Max, o.Default))
        Next
    End Sub
    Public Sub Update(key As [Option], value As Single)
        Dim ss As SensorSetting = Me.Where(Function(q) q.Key = key).SingleOrDefault
        If ss Is Nothing Then
            Add(New SensorSetting(key, value, "new", -99999, 99999, 0))
        Else
            ss.Value = value
        End If
    End Sub
End Class
''' <summary>
''' An easier-to-use sensor setting (than the RealSense Enum)
''' </summary>
Public Class SensorSetting
    Implements IEquatable(Of SensorSetting)
    Public ReadOnly Property Key As [Option]
    Public Property Value As Single
    Public ReadOnly Property Description As String
    Public ReadOnly Property Min As Single
    Public ReadOnly Property Max As Single
    Public ReadOnly Property DefValue As Single

    Public Sub New(key As [Option], value As Single, description As String, min As Single, max As Single, defvalue As Single)
        _Key = key
        _Value = value
        _Description = description
        _Min = min
        _Max = max
        _DefValue = defvalue
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Key}={Value}"
    End Function
#Region "IEquatable"
    Public Function Equals1(other As SensorSetting) As Boolean Implements IEquatable(Of SensorSetting).Equals
        Return Key = other.Key
    End Function
    Public Overrides Function Equals(other As Object) As Boolean
        Return Equals1(DirectCast(other, SensorSetting))
    End Function
    Public Overrides Function GetHashCode() As Integer

        'Return Key.GetHashCode Xor Col.GetHashCode

        ' http://stackoverflow.com/questions/4654227/overriding-gethashcode-in-vb-without-checked-unchecked-keyword-support
        Dim hashCode As HashCodeNoOverflow

        hashCode.Int64 = 17

        hashCode.Int64 = CLng(hashCode.Int32) * 23 + Key.GetHashCode

        Return hashCode.Int32

    End Function
    Public Shared Operator =(a As SensorSetting, b As SensorSetting) As Boolean
        Return a.Key = b.Key
    End Operator
    Public Shared Operator <>(a As SensorSetting, b As SensorSetting) As Boolean
        Return Not (a = b)
    End Operator
#End Region
End Class
