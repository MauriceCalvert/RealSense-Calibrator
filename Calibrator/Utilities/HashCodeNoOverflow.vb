Imports System.Windows
Imports System.Runtime.InteropServices
''' <summary>
''' Hascode 32/64 bit hack
''' </summary>
Public Module HashCodeNoOverflow_

    <StructLayout(LayoutKind.Explicit)>
    Public Structure HashCodeNoOverflow
        <FieldOffset(0)> Public Int64 As Int64
        <FieldOffset(0)> Public Int32 As Int32
    End Structure

End Module
