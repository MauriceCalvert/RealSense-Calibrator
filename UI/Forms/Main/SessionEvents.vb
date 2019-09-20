Imports System.ComponentModel
Imports System.Threading
Imports Calibrator
Imports NLog
Partial Public Class Main
    Private Sub Session_CameraChanged(sender As Object, oldcamera As Camera, newcamera As Camera) Handles _Session.CameraChanged
        Try
            _Camera = newcamera
        StartCamera()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Session_FrameReady(sender As Object, depthmap As DepthMap, colour As Bitmap, colorised As Bitmap) Handles _Session.FrameReady
        Try
            If _ColourPicture IsNot Nothing Then
            _ColourPicture.Image = colour
        End If
        If _DepthPicture IsNot Nothing Then
            _DepthPicture.DepthMap = depthmap
            _DepthPicture.Image = colorised
        End If
        If _DGVClock.Expired Then
                BeginInvoke(
                    Sub()
                        Try
                            txtCamHFov.Text = _Camera.DepthHFov.ToString("#,##0.000000")
                            txtCamHFovD.Text = (_Camera.DepthHFov * TODEGREES).ToString("#,##0.000")
                            txtCamVFov.Text = _Camera.DepthVFov.ToString("#,##0.000000")
                            txtCamVFovD.Text = (_Camera.DepthVFov * TODEGREES).ToString("#,##0.000")
                            dgvMeasures.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                            dgvMeasures.AutoGenerateColumns = False
                            dgvMeasures.DataSource = _Session.Planes
                            dgvMeasures.Refresh()
                            If _Session.State = State.ImproveTargets Then
                                Measuring1.ShowSkew()
                            End If

                        Catch ex As Exception
                            HandleError(ex)
                        End Try
                    End Sub)
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub _Session_PlaneAdded(sender As Object, plane As Plane) Handles _Session.PlaneAdded
        Try
            BeginInvoke(
                Sub()
                    Try
                        Measuring1.Plane = plane
                        dgvMeasures.AutoGenerateColumns = False
                        dgvMeasures.DataSource = _Session.Planes
                        dgvMeasures.Refresh()

                    Catch ex As Exception
                        HandleError(ex)
                    End Try
                End Sub)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub AdjustMenus(sender As Object, state As State) Handles _Session.StateChanged
        Try
            BeginInvoke(
                Sub(newstate As State)
                    Try
                        ChartToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                        Select Case state
                            Case State.Idle
                                CrosshairsToolStripMenuItem.Enabled = True
                                FindTargetsToolStripMenuItem.Enabled = True
                                MeasureToolStripMenuItem.Enabled = False
                                FinaliseMeasurementToolStripMenuItem.Enabled = False
                                OptimiseToolStripMenuItem.Enabled = _Session.Planes.Any
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                                ChartToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                            Case State.FindFloor
                                CrosshairsToolStripMenuItem.Enabled = False
                                FindTargetsToolStripMenuItem.Enabled = False
                                MeasureToolStripMenuItem.Enabled = False
                                FinaliseMeasurementToolStripMenuItem.Enabled = True
                                OptimiseToolStripMenuItem.Enabled = False
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                            Case State.FindTargets
                                CrosshairsToolStripMenuItem.Enabled = False
                                FindTargetsToolStripMenuItem.Enabled = True
                                MeasureToolStripMenuItem.Enabled = False
                                FinaliseMeasurementToolStripMenuItem.Enabled = False
                                OptimiseToolStripMenuItem.Enabled = False
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                            Case State.ImproveTargets
                                CrosshairsToolStripMenuItem.Enabled = True
                                FindTargetsToolStripMenuItem.Enabled = True
                                MeasureToolStripMenuItem.Enabled = True
                                FinaliseMeasurementToolStripMenuItem.Enabled = False
                                OptimiseToolStripMenuItem.Enabled = False
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                            Case State.Measure
                                CrosshairsToolStripMenuItem.Enabled = False
                                FindTargetsToolStripMenuItem.Enabled = False
                                MeasureToolStripMenuItem.Enabled = False
                                FinaliseMeasurementToolStripMenuItem.Enabled = True
                                OptimiseToolStripMenuItem.Enabled = False
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                            Case State.NoTargets
                                CrosshairsToolStripMenuItem.Enabled = True
                                FindTargetsToolStripMenuItem.Enabled = True
                                MeasureToolStripMenuItem.Enabled = False
                                FinaliseMeasurementToolStripMenuItem.Enabled = False
                                OptimiseToolStripMenuItem.Enabled = False
                                SaveAsToolStripMenuItem.Enabled = _Session.Model IsNot Nothing
                        End Select

                    Catch ex As Exception
                        HandleError(ex)
                    End Try
                End Sub,
                state)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
End Class
