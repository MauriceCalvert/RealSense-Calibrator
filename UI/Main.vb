Imports System.Globalization
Imports System.Runtime.ExceptionServices
Imports System.Security
Imports System.Threading
Imports Calibrator
Imports NLog

Public Module Main_

    <HandleProcessCorruptedStateExceptions>
    <SecurityCritical>
    <STAThread>
    Public Sub Main()

        Dim mainform As New Main

        Try
            ' If we're not compiled 64-bit, RealSense will (quite resonably) throw "Cannot load file or assembly".
            ' As is this is a bit misleading, gripe up front if we're not pure 64-bit.
            Ensure64Bit(mainform)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "SNAFU!")
            Exit Sub
        End Try

        ' We use TryParse for numbers. Avoid localisation SNAFUs by enforcing invariant culture
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture

        AddHandler Application.ThreadException, AddressOf ThreadDisaster
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledDisaster

        Application.Run(mainform)

    End Sub
    Private Sub ThreadDisaster(sender As Object, e As ThreadExceptionEventArgs)
        HandleError(e.Exception)
    End Sub
    Private Sub UnhandledDisaster(sender As Object, e As UnhandledExceptionEventArgs)
        MsgBox("Unhandled exception " & e.ExceptionObject.ToString)
    End Sub
End Module
