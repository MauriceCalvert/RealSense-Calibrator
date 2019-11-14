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
        Dim cameras As Integer = 0
        For id As Integer = 0 To devices.Count - 1
            Dim device As Device = devices(id)
            Try
                MyBase.Add(New Camera(device))
                cameras += 1
            Catch ex As Exception
                _Logger.Warn(ex, $"Device {id} skipped")
            End Try
        Next
        _Logger.Info("{0} camera{1} detected", cameras, If(devices.Count > 1, "s", ""))
    End Sub
End Class
