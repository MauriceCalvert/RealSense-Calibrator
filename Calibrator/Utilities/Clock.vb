''' <summary>
''' Convenience timer that expires at regular intervals
''' </summary>
Public Class Clock

    Private _Last As DateTime
    Private _Interval As Integer
    Private ONEMICROSECOND As New TimeSpan(CLng(TimeSpan.TicksPerSecond / 1000000))
    ' DateTime.Now is expensive with all its timezone calculations.
    ' DateTime.UTCNow is cheap, so do the timezone stuff ourselves
    Private _Offset As TimeSpan = DateTime.Now - DateTime.UtcNow
    Sub New()
        _Last = Stamp()
    End Sub
    Sub New(intervalmS As Integer)
        _Last = Stamp()
        _Interval = intervalmS
    End Sub
    Sub New(intervalmS As Double)
        _Last = Stamp()
        _Interval = Convert.ToInt32(intervalmS)
    End Sub
    Sub New(interval As TimeSpan)
        _Last = Stamp()
        _Interval = CInt(interval.TotalMilliseconds)
    End Sub
    Public Function Elapsed() As TimeSpan ' always returns at least one microsecond
        Dim now As DateTime = Stamp()
        Dim delta As TimeSpan = now - _Last
        If delta < ONEMICROSECOND Then
            delta = ONEMICROSECOND
        End If
        _Last = now
        Return delta
    End Function
    Public Function Expired() As Boolean
        Dim now As DateTime = Stamp()
        Dim delta As TimeSpan = now - _Last
        If delta.Ticks > Interval.Ticks Then
            _Last = now
            Return True
        Else
            Return False
        End If
    End Function
    Public Property Interval() As TimeSpan
        Get
            Return New TimeSpan(0, 0, 0, 0, _Interval)
        End Get
        Set(value As TimeSpan)
            _Interval = Convert.ToInt32(value.TotalMilliseconds)
            _Last = Stamp() - value
        End Set
    End Property
    Public Function Stamp() As DateTime
        Return DateTime.UtcNow + _Offset
    End Function
End Class