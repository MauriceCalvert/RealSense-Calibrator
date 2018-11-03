Imports System.Windows
Public Module JaggedArrays
    ''' <summary>
    ''' Create and initialise arbitrary jagged arrays
    ''' </summary>
    Public Function CreateJaggedArray(Of T)(ParamArray lengths As Integer()) As T
        Return DirectCast(InitializeJaggedArray(GetType(T).GetElementType(), 0, lengths), T)
    End Function

    Private Function InitializeJaggedArray(type As Type, index As Integer, lengths As Integer()) As Object
        Dim result As Array = Array.CreateInstance(type, lengths(index))
        Dim elementType As Type = type.GetElementType()

        If elementType IsNot Nothing Then
            For i As Integer = 0 To lengths(index) - 1
                result.SetValue(InitializeJaggedArray(elementType, index + 1, lengths), i)
            Next
        End If

        Return result
    End Function
End Module
