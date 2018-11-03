Imports System.Windows
Imports Intel.RealSense
Imports NLog
''' <summary>
''' Represents the cameras currently connected to the PC
''' </summary>
Public Class Cameras
    Inherits List(Of Camera)
    Private _Logger As Logger = LogManager.GetCurrentClassLogger
    Sub New()
        FindCameras()
    End Sub
    Private Sub FindCameras()
        Dim context As Context = Nothing
        Try
            context = New Context

        Catch ex As DllNotFoundException
            _Logger.Error(ex, "This might be due to the camera not being plugged in. Check that it really is with the RealSense Viewer!")
            Exit Sub

        Catch ex As Exception
            Throw
        End Try
        Dim devices As DeviceList = context.QueryDevices
        For id As Integer = 0 To devices.Count - 1
            Dim device As Device = devices(id)
            MyBase.Add(New Camera(device))
        Next
        _Logger.Info("{0} camera{1} detected", devices.Count, If(devices.Count > 1, "s", ""))
    End Sub
End Class
