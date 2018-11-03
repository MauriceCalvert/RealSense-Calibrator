Imports System.Windows
Imports System.Uri
Imports System.IO.Path
Imports System.Reflection

Public Module GetExecutingPath_
    ''' <summary>
    ''' Get the path to the currently executing assembly
    ''' </summary>
    ''' <returns>Path, without the leading "file:", without any leading "\" and without any trailing "\"</returns>
    Public Function GetExecutingPath() As String
        Dim sf() As StackFrame = New StackTrace().GetFrames()
        Dim toplevel As Assembly = sf.Select(Function(q) q.GetMethod.ReflectedType.Assembly).Last
        Dim codeBase As String = toplevel.CodeBase
        Dim uri As New UriBuilder(codeBase)
        Dim path As String = UnescapeDataString(uri.Path)
        Dim result As String = GetDirectoryName(path)
        Return result

    End Function

End Module
