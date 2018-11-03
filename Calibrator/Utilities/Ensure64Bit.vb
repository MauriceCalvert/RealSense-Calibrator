Imports System.Reflection
Imports NLog
Public Module Ensure64Bit_
    ''' <summary>
    ''' Throw an exception if the assembly containg an object is not 64-bit.
    ''' </summary>
    ''' <param name="o"></param>
    Public Sub Ensure64Bit(o As Object)

        Dim t As Type = o.GetType
        Dim assembly As Assembly = t.Assembly
        Dim name As AssemblyName = assembly.GetName
        Dim pa As ProcessorArchitecture = name.ProcessorArchitecture

        If pa <> ProcessorArchitecture.Amd64 AndAlso
           pa <> ProcessorArchitecture.IA64 Then

            Dim msg As String = $"{name.Name} processor architecture is {pa}. This won't work, re-compile as 64-bit"
            Throw New Exception(msg)
        End If
    End Sub
End Module
