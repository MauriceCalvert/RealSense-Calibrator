Imports NLog

Public Module ErrorHandling

    Private _Logger As Logger = LogManager.GetCurrentClassLogger

    Public Sub HandleError(ex As Exception)
        Dim st As New StackTrace
        Dim msg As String = $"Unanticipated {ex.GetType.Name}: {ex.Message}{vbCr}{st.ToString}"
        If MsgBox(msg, MsgBoxStyle.RetryCancel, "SNAFU!") = MsgBoxResult.Cancel Then
            Application.Exit()
        End If
    End Sub

End Module
