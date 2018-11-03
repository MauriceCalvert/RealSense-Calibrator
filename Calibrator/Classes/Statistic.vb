Imports System.Runtime.Serialization
''' <summary>
''' Helper to hold and calculate statistics about measurements: Min, Max, Mean, Variance and Standard Deviation.
''' Uses Welford's method, much more efficient and accurate.
''' </summary>
<DataContract>
Public Class Statistic

    Private _Count As Integer
    Private _Min As Double
    Private _Max As Double

    Public Sub New()
        Clear()
    End Sub
    Public Sub Add(value As Double)
        _Total += value
        _Count += 1
        If value < Min Then
            Min = value
        End If
        If value > Max Then
            Max = value
        End If
        ' Welford's algorithm for variance
        ' https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance
        ' http://jonisalonen.com/2013/deriving-welfords-method-for-computing-variance/
        Dim oldm As Double = M
        M = M + (value - M) / Count
        S = S + (value - M) * (value - oldm)
    End Sub
    Public ReadOnly Property Average As Double
        Get
            If Count = 0 Then
                Return 0
            End If
            Return Total / Count
        End Get
    End Property
    Public Sub Clear()
        Total = 0
        Count = 0
        Min = Double.MaxValue
        Max = Double.MinValue
        M = 0
        S = 0
    End Sub
    <DataMember>
    Public Property Count As Integer
        Get
            Return _Count
        End Get
        Private Set(value As Integer)
            _Count = value
        End Set
    End Property
    <DataMember>
    Private Property M As Double
    <DataMember>
    Public Property Max As Double
        Get
            Return _Max
        End Get
        Private Set(value As Double)
            _Max = value
        End Set
    End Property
    <DataMember>
    Public Property Min As Double
        Get
            Return _Min
        End Get
        Private Set(value As Double)
            _Min = value
        End Set
    End Property
    <DataMember>
    Private Property S As Double
    Public ReadOnly Property Sigma As Double
        Get
            If Count < 2 Then
                Return 0
            End If
            Return Math.Sqrt(Variance)
        End Get
    End Property
    <DataMember>
    Private Property Total As Double
    Public ReadOnly Property Variance As Double
        Get
            If Count < 2 Then
                Return 0
            End If
            Return S / (Count - 1)
        End Get
    End Property
End Class
