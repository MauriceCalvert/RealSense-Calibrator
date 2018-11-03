''' <summary>
''' Helper for populating comboboxes
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class ComboBoxItem(Of T)
    Public ReadOnly Property Name As String
    Public ReadOnly Property Value As T
    Sub New(name As String, value As T)
        _Name = name
        _Value = value
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
