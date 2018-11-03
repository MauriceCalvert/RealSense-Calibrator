Imports System.Windows
''' <summary>
''' A list which won't contain any duplicates
''' </summary>
''' <typeparam name="T">Must implement IEquatable(Of T)</typeparam>
Public Class UniqueList(Of T As {IEquatable(Of T)})
    Inherits List(Of T)

    Overloads Sub Add(item As T)
        If Not MyBase.Contains(item) Then
            MyBase.Add(item)
        End If
    End Sub
    Overloads Sub AddRange(items As IEnumerable(Of T))
        For Each item As T In items
            Add(item)
        Next
    End Sub
    Overloads Sub Insert(item As T)
        Throw New NotImplementedException("Can't Insert into a UniqueList >;-(")
    End Sub
    Overloads Sub InsertRange(items As IEnumerable(Of T))
        Throw New NotImplementedException("Can't InsertRange into a UniqueList >;-(")
    End Sub

End Class
