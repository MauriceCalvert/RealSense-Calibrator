Imports NLog
Imports System.ComponentModel
Imports Calibrator
Imports System.IO

Partial Public Class Main
    Private Sub Camera_DropDown(sender As Object, e As EventArgs) Handles cmbCamera.DropDown
        Try
            PopulateCameras()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Camera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCamera.SelectedIndexChanged
        If Not IsHandleCreated Then Exit Sub
        Try
            _Session.Camera = DirectCast(cmbCamera.SelectedItem, ComboBoxItem(Of Camera)).Value

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub CheckMatchingResolutions(sender As Object, e As EventArgs) Handles cmbColourFormat.SelectedIndexChanged,
                                                                                   cmbDepthFormat.SelectedValueChanged
        If Not IsHandleCreated Then Exit Sub
        Try
            _Session.Camera.ColourFormat = DirectCast(cmbColourFormat.SelectedItem, ComboBoxItem(Of StreamFormat))?.Value
            _Session.Camera.DepthFormat = DirectCast(cmbDepthFormat.SelectedItem, ComboBoxItem(Of StreamFormat))?.Value

            If _Session.Camera?.ColourFormat?.Width <> _Session.Camera?.DepthFormat?.Width OrElse
           _Session.Camera?.ColourFormat?.Height <> _Session.Camera?.DepthFormat?.Height Then
                _Logger.Warn("Width/Height mistmatch between depth and colour!")
            End If
            ReStartCamera()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub ColourFormat_DropDown(sender As Object, e As EventArgs) Handles cmbColourFormat.DropDown
        Try
            PopulateColourFormats()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub ColourIntrinsics_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColourIntrinsics.LinkClicked
        Try
            Dim fi As New Intrinsics(_Session.Camera.ColourIntrinsics)
            fi.ShowDialog(Me)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub ColourOptions_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColourOptions.LinkClicked
        Try
            Dim so As New SensorOptions(_Session.Camera.ColourSettings,
                                     "Colour sensor options",
                                     (Me.Height - lnkColourOptions.Top) \ 2)

            so.Location = Me.PointToScreen(New Point(lnkColourOptions.Left + lnkColourOptions.Width, lnkColourOptions.Height))
            so.ShowDialog(Me)
            If so.DialogResult = DialogResult.OK Then
                _Session.Camera.ColourSettings = so.Result
                ReStartCamera()
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Decimation_CheckedChanged(sender As Object, e As EventArgs) Handles chkDecimation.CheckedChanged
        Try
            SetFilter(DepthFilters.Decimation, chkDecimation.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub DepthFormat_DropDown(sender As Object, e As EventArgs) Handles cmbDepthFormat.DropDown
        Try
            PopulateDepthFormats()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub DepthIntrinsics_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDepthIntrinsics.LinkClicked
        Try
            Dim fi As New Intrinsics(_Session.Camera.DepthIntrinsics)
            fi.ShowDialog(Me)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub DepthOptions_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDepthOptions.LinkClicked
        Try
            Dim so As New SensorOptions(_Session.Camera.DepthSettings,
                                     "Depth sensor options",
                                     (Me.Height - lnkDepthOptions.Top) \ 2)

            so.Location = Me.PointToScreen(New Point(lnkDepthOptions.Left + lnkDepthOptions.Width, lnkDepthOptions.Height))
            so.ShowDialog(Me)
            If so.DialogResult = DialogResult.OK Then
                _Session.Camera.DepthSettings = so.Result
                ReStartCamera()
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub FrameRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFrameRate.SelectedIndexChanged
        If Not IsHandleCreated Then Exit Sub
        Try
            _Session.Camera.Framerate = Convert.ToInt32(cmbFrameRate.SelectedItem)
            ReStartCamera()

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub GuideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuideToolStripMenuItem.Click
        Try
            Process.Start(Path.Combine(GetExecutingPath, "Help", "index.html"))

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub HoleFilling_CheckedChanged(sender As Object, e As EventArgs) Handles chkHoleFilling.CheckedChanged
        Try
            SetFilter(DepthFilters.HoleFilling, chkHoleFilling.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub LogLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLogLevel.SelectedIndexChanged
        Try
            _Loglevel = LogLevel.FromString(cmbLogLevel.SelectedItem.ToString)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Main_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Try
            cmbLogLevel.Top = SplitContainer1.Panel1.Height - cmbLogLevel.Height
            cmbLogLevel.Left = lblLoglevel.Left + lblLoglevel.Width + 4

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub NumericTextBoxValidating(sender As Object, e As CancelEventArgs) Handles txtRange.Validating,
                                                                                         txtTargetWidth.Validating,
                                                                                         txtTargetHeight.Validating
        Try
            If Not IsHandleCreated Then Exit Sub

            Dim textbox As TextBox = DirectCast(sender, TextBox)
            Dim junk As Double
            If Not Double.TryParse(textbox.Text, junk) Then
                e.Cancel = True
                MsgBox($"{textbox.Text} is not a valid number")
                textbox.Focus()
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub SetFilter(filter As DepthFilters, checked As Boolean)
        Try
            If checked Then
                _Session.Camera.DepthFilters = _Session.Camera.DepthFilters Or filter
            Else
                _Session.Camera.DepthFilters = _Session.Camera.DepthFilters And Not filter
            End If
            If filter = DepthFilters.Decimation Then
                ReStartCamera()
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Spatial_CheckedChanged(sender As Object, e As EventArgs) Handles chkSpatial.CheckedChanged
        Try
            SetFilter(DepthFilters.Spatial, chkSpatial.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub TargetHeight_Validated(sender As Object, e As EventArgs) Handles txtTargetHeight.Validated
        Try
            _Session.TargetHeight = Convert.ToDouble(txtTargetHeight.Text)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub TargetWidth_Validated(sender As Object, e As EventArgs) Handles txtTargetWidth.Validated
        Try
            _Session.TargetWidth = Convert.ToDouble(txtTargetWidth.Text)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub Temporal_CheckedChanged(sender As Object, e As EventArgs) Handles chkTemporal.CheckedChanged
        Try
            SetFilter(DepthFilters.Temporal, chkTemporal.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub ViewColour_CheckedChanged(sender As Object, e As EventArgs) Handles chkViewColour.CheckedChanged
        If Not IsHandleCreated Then Exit Sub
        Try
            DisplayColour(chkViewColour.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
    Private Sub ViewDepth_CheckedChanged(sender As Object, e As EventArgs) Handles chkViewDepth.CheckedChanged
        If Not IsHandleCreated Then Exit Sub
        Try
            DisplayDepth(chkViewDepth.Checked)

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
End Class
