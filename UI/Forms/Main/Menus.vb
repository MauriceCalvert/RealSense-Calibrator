Imports NLog
Imports Calibrator
Imports System.IO

Partial Public Class Main
    Private Sub ChartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChartToolStripMenuItem.Click
        Try
            Dim ec As New ErrorChart(_Session)
            ec.Show()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub CrosshairsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrosshairsToolStripMenuItem.Click
        Try
            _Session.Idle()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub FinaliseMeasurementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinaliseMeasurementToolStripMenuItem.Click
        Try
            txtRange.Text = "0"
            _Session.Idle()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub FindTargetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindTargetsToolStripMenuItem.Click
        Try
            If txtRange.Text = "" OrElse txtRange.Text = "0" Then
                MsgBox("Enter the range of the targets first")
                txtRange.Focus()
                Exit Sub
            End If

            Dim range As Double = 0
            If Not Double.TryParse(txtRange.Text, range) Then
                MsgBox("Invalid range")
                txtRange.Focus()
                Exit Sub
            End If
            If range < 1 Then
                MsgBox("Invalid range")
                txtRange.Focus()
                Exit Sub
            End If

            Dim targetwidth As Double = 0
            If Not Double.TryParse(txtTargetWidth.Text, targetwidth) Then
                MsgBox("Invalid target width")
                txtTargetWidth.Focus()
                Exit Sub
            End If
            If targetwidth < 1 Then
                MsgBox("Invalid target width")
                txtTargetWidth.Focus()
                Exit Sub
            End If

            Dim targetheight As Double = 0
            If Not Double.TryParse(txtTargetHeight.Text, targetheight) Then
                MsgBox("Invalid target height")
                txtTargetWidth.Focus()
                Exit Sub
            End If
            If targetheight < 1 Then
                MsgBox("Invalid target height")
                txtTargetWidth.Focus()
                Exit Sub
            End If

            _Session.TargetHeight = targetheight
            _Session.TargetWidth = targetwidth

            _Session.FindTargets(range, targetwidth, targetheight)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        Try
            Dim ofd As New OpenFileDialog
        With ofd
            .AddExtension = False
            .CheckPathExists = True
            .CheckFileExists = True
            .FileName = Path.Combine(My.Settings.SavePath, _Session.Camera.UniqueName)
            .ValidateNames = True
            Dim clicked As DialogResult = .ShowDialog()
            If clicked = DialogResult.OK Then
                _Session.Load(.FileName)
                My.Settings.SavePath = Path.GetDirectoryName(.FileName)
            End If
        End With
        _Session.Idle()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub MeasureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeasureToolStripMenuItem.Click
        Try
            If _Session.ActivePlane Is Nothing Then
            MsgBox("Find some targets first!")
            Exit Sub
        End If

        _Session.Measure()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub OptimiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptimiseToolStripMenuItem.Click
        Try
            If Not _Session.Planes?.Any Then
            MsgBox("Find some targets first!")
            Exit Sub
        End If

        If _Session.State <> State.Idle Then
            MsgBox("Finalise the current measurement first!")
            Exit Sub
        End If

        ' Force him to see all the gory details whilst we're solving
        Dim oldloglevel As LogLevel = _Loglevel
        _Loglevel = LogLevel.Info

        _Session.Optimise(
            Sub(model As Model)
                BeginInvoke(
                    Sub(m As Model)
                        With model
                            txtA.Text = .QuadraticA.ToString("#,##0.000000")
                            txtB.Text = .QuadraticB.ToString("#,##0.000000")
                            txtC.Text = .QuadraticC.ToString("#,##0.000000")
                            txtDeviation.Text = .Deviation.ToString("#,##0.000000")
                            txtDeviationD.Text = (.Deviation * TODEGREES).ToString("#,##0.000")
                            txtHFov.Text = .HFov.ToString("#,##0.000000")
                            txtHFovD.Text = (.HFov * TODEGREES).ToString("#,##0.000")
                            txtInclination.Text = .Inclination.ToString("#,##0.000000")
                            txtInclinationD.Text = (.Inclination * TODEGREES).ToString("#,##0.000")
                            txtAverageError.Text = .AverageError.ToString("#,##0.0")
                            txtVFov.Text = .VFov.ToString("#,##0.000000")
                            txtVFovD.Text = (.VFov * TODEGREES).ToString("#,##0.000")
                            _Loglevel = oldloglevel
                            _Session.Idle()
                        End With
                    End Sub, model)
            End Sub)

        Dim cammodel As New Model(_Camera, _Session.Model.Planes)
        txtCamAverageError.Text = cammodel.AverageError.ToString("#,##0.0")

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Try
            If _Session?.Planes?.Any Then
                If MsgBox("Are you sure?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Quit without saving") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If
            Me.Close()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            Dim sfd As New SaveFileDialog
        With sfd
            .AddExtension = False
            .CheckPathExists = True
            .InitialDirectory = My.Settings.SavePath
            .FileName = $"{_Session.Camera.ModelNumber}-{_Session.Camera.SerialNumber}"
            .OverwritePrompt = True
            .ValidateNames = True
            Dim clicked As DialogResult = .ShowDialog()
            If clicked = DialogResult.OK Then
                _Session.Save(.FileName)
                My.Settings.SavePath = Path.GetDirectoryName(.FileName)
            End If
        End With

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
End Class
