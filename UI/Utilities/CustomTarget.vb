Imports NLog
Imports NLog.Targets

<Target("CustomTarget")>
Public NotInheritable Class CustomTarget
    Inherits TargetWithLayout

    Public Sub New()
    End Sub

    Protected Overrides Sub Write(logEvent As LogEventInfo)
        TheMain.Log(logEvent)
    End Sub

End Class

' Yes, this 'Shared' stuff is a ghastly hack, but there's no easy way to pass things to an NLog custom target
Public Module NLogHook
    Public TheMain As Main
End Module


