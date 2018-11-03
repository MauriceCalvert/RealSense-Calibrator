Imports System.Windows
Imports System.Threading

Public Module Unique_

    Private _Unique As Integer = 0

    ''' <summary>
    ''' Return a unique, negative number in a thread-safe manner
    ''' </summary>
    ''' <remarks>This function is thread-safe</remarks>
    Public Function Unique() As Integer

        Dim initialvalue As Integer
        Dim computedvalue As Integer

        Do
            initialvalue = _Unique

            computedvalue = initialvalue - 1

        Loop While initialvalue <> Interlocked.CompareExchange(_Unique, computedvalue, initialvalue)

        Return computedvalue

    End Function

End Module
