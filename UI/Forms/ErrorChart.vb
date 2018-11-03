Imports Calibrator
Imports System.Windows.Forms.DataVisualization.Charting
Public Class ErrorChart
    Public Sub New(session As Session)
        InitializeComponent()
        Dim planes As List(Of Plane) = session.Planes.OrderBy(Function(q) q.Truth).ToList
        Dim interval As Integer = 0
        If planes.Count > 1 Then
            For i As Integer = 0 To planes.Count - 2
                interval = Convert.ToInt32(Math.Max(interval, planes(i + 1).Truth - planes(i).Truth))
            Next
            Chart1.ChartAreas.First.AxisX.Minimum = Math.Floor(planes.First.Truth / interval) * interval
            Chart1.ChartAreas.First.AxisX.Interval = interval
        End If
        Chart1.ChartAreas.First.AxisX.Maximum = planes.Last.Truth
        Dim cameramodel As New Model(session.Camera, session.Planes)

        ' RealSense D400 Series Product Family Datasheet
        ' Table 4-8. Depth Module Depth Start Point
        If session.Camera.ModelNumber >= 420 Then
            cameramodel.QuadraticC = -3.2
        Else
            cameramodel.QuadraticC = -0.1
        End If

        Dim cameraseries As Series = Chart1.Series("Camera")
        For Each plane As Plane In planes
            cameraseries.Points.AddXY(plane.Truth, cameramodel.AverageError(plane))
        Next

        Dim optimiserseries As Series = Chart1.Series("Optimiser")
        For Each plane As Plane In planes
            optimiserseries.Points.AddXY(plane.Truth, session.Model.AverageError(plane))
        Next
    End Sub

End Class