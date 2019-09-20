<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblLoglevel = New System.Windows.Forms.Label()
        Me.cmbLogLevel = New System.Windows.Forms.ComboBox()
        Me.MyGroupBox4 = New UI.MyGroupBox()
        Me.txtFloorHeight = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFloorAngleD = New System.Windows.Forms.TextBox()
        Me.txtFloorAngle = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCamAverageError = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCamVFovD = New System.Windows.Forms.TextBox()
        Me.txtCamHFovD = New System.Windows.Forms.TextBox()
        Me.txtCamVFov = New System.Windows.Forms.TextBox()
        Me.txtCamHFov = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAverageError = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtVFovD = New System.Windows.Forms.TextBox()
        Me.txtHFovD = New System.Windows.Forms.TextBox()
        Me.txtInclinationD = New System.Windows.Forms.TextBox()
        Me.txtDeviationD = New System.Windows.Forms.TextBox()
        Me.txtC = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtB = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtVFov = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtHFov = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtInclination = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDeviation = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvMeasures = New System.Windows.Forms.DataGridView()
        Me.Truth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sigma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Samples = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MyGroupBox2 = New UI.MyGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTargetHeight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRange = New System.Windows.Forms.TextBox()
        Me.txtTargetWidth = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MyGroupBox1 = New UI.MyGroupBox()
        Me.chkViewDepth = New System.Windows.Forms.CheckBox()
        Me.chkViewColour = New System.Windows.Forms.CheckBox()
        Me.lnkColourIntrinsics = New System.Windows.Forms.LinkLabel()
        Me.lnkDepthIntrinsics = New System.Windows.Forms.LinkLabel()
        Me.lnkColourOptions = New System.Windows.Forms.LinkLabel()
        Me.lnkDepthOptions = New System.Windows.Forms.LinkLabel()
        Me.chkTemporal = New System.Windows.Forms.CheckBox()
        Me.chkSpatial = New System.Windows.Forms.CheckBox()
        Me.chkHoleFilling = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkDecimation = New System.Windows.Forms.CheckBox()
        Me.lblColourWarning = New System.Windows.Forms.Label()
        Me.cmbFrameRate = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbColourFormat = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDepthFormat = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCamera = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Measuring1 = New UI.Measuring()
        Me.rtbMessages = New System.Windows.Forms.RichTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrosshairsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindTargetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MeasureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindFloorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinaliseMeasurementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptimiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPixelAspectRatio = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MyGroupBox4.SuspendLayout()
        CType(Me.dgvMeasures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyGroupBox2.SuspendLayout()
        Me.MyGroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblLoglevel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbLogLevel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyGroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvMeasures)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyGroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyGroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Measuring1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbMessages)
        Me.SplitContainer1.Size = New System.Drawing.Size(1133, 742)
        Me.SplitContainer1.SplitterDistance = 644
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'lblLoglevel
        '
        Me.lblLoglevel.AutoSize = True
        Me.lblLoglevel.ForeColor = System.Drawing.Color.White
        Me.lblLoglevel.Location = New System.Drawing.Point(9, 623)
        Me.lblLoglevel.Name = "lblLoglevel"
        Me.lblLoglevel.Size = New System.Drawing.Size(70, 13)
        Me.lblLoglevel.TabIndex = 67
        Me.lblLoglevel.Text = "Logging level"
        Me.lblLoglevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLogLevel
        '
        Me.cmbLogLevel.BackColor = System.Drawing.Color.Black
        Me.cmbLogLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbLogLevel.ForeColor = System.Drawing.Color.White
        Me.cmbLogLevel.FormattingEnabled = True
        Me.cmbLogLevel.Items.AddRange(New Object() {"Trace", "Debug", "Info", "Warn", "Error"})
        Me.cmbLogLevel.Location = New System.Drawing.Point(85, 619)
        Me.cmbLogLevel.MaxDropDownItems = 50
        Me.cmbLogLevel.Name = "cmbLogLevel"
        Me.cmbLogLevel.Size = New System.Drawing.Size(95, 21)
        Me.cmbLogLevel.TabIndex = 18
        Me.cmbLogLevel.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cmbLogLevel, "Adjust the level of logging that is displayed")
        '
        'MyGroupBox4
        '
        Me.MyGroupBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MyGroupBox4.BorderRadius = 5
        Me.MyGroupBox4.BorderWidth = 1.8!
        Me.MyGroupBox4.Controls.Add(Me.txtPixelAspectRatio)
        Me.MyGroupBox4.Controls.Add(Me.Label33)
        Me.MyGroupBox4.Controls.Add(Me.txtFloorHeight)
        Me.MyGroupBox4.Controls.Add(Me.Label10)
        Me.MyGroupBox4.Controls.Add(Me.Label7)
        Me.MyGroupBox4.Controls.Add(Me.txtFloorAngleD)
        Me.MyGroupBox4.Controls.Add(Me.txtFloorAngle)
        Me.MyGroupBox4.Controls.Add(Me.Label8)
        Me.MyGroupBox4.Controls.Add(Me.Label32)
        Me.MyGroupBox4.Controls.Add(Me.txtCamAverageError)
        Me.MyGroupBox4.Controls.Add(Me.Label31)
        Me.MyGroupBox4.Controls.Add(Me.Label30)
        Me.MyGroupBox4.Controls.Add(Me.Label28)
        Me.MyGroupBox4.Controls.Add(Me.Label29)
        Me.MyGroupBox4.Controls.Add(Me.txtCamVFovD)
        Me.MyGroupBox4.Controls.Add(Me.txtCamHFovD)
        Me.MyGroupBox4.Controls.Add(Me.txtCamVFov)
        Me.MyGroupBox4.Controls.Add(Me.txtCamHFov)
        Me.MyGroupBox4.Controls.Add(Me.Label27)
        Me.MyGroupBox4.Controls.Add(Me.Label26)
        Me.MyGroupBox4.Controls.Add(Me.Label25)
        Me.MyGroupBox4.Controls.Add(Me.Label24)
        Me.MyGroupBox4.Controls.Add(Me.Label23)
        Me.MyGroupBox4.Controls.Add(Me.txtAverageError)
        Me.MyGroupBox4.Controls.Add(Me.Label22)
        Me.MyGroupBox4.Controls.Add(Me.txtVFovD)
        Me.MyGroupBox4.Controls.Add(Me.txtHFovD)
        Me.MyGroupBox4.Controls.Add(Me.txtInclinationD)
        Me.MyGroupBox4.Controls.Add(Me.txtDeviationD)
        Me.MyGroupBox4.Controls.Add(Me.txtC)
        Me.MyGroupBox4.Controls.Add(Me.Label21)
        Me.MyGroupBox4.Controls.Add(Me.txtB)
        Me.MyGroupBox4.Controls.Add(Me.Label20)
        Me.MyGroupBox4.Controls.Add(Me.txtA)
        Me.MyGroupBox4.Controls.Add(Me.Label19)
        Me.MyGroupBox4.Controls.Add(Me.txtVFov)
        Me.MyGroupBox4.Controls.Add(Me.Label18)
        Me.MyGroupBox4.Controls.Add(Me.txtHFov)
        Me.MyGroupBox4.Controls.Add(Me.Label17)
        Me.MyGroupBox4.Controls.Add(Me.txtInclination)
        Me.MyGroupBox4.Controls.Add(Me.Label16)
        Me.MyGroupBox4.Controls.Add(Me.txtDeviation)
        Me.MyGroupBox4.Controls.Add(Me.Label15)
        Me.MyGroupBox4.ForeColor = System.Drawing.Color.White
        Me.MyGroupBox4.LabelIndent = 15
        Me.MyGroupBox4.Location = New System.Drawing.Point(341, 391)
        Me.MyGroupBox4.Name = "MyGroupBox4"
        Me.MyGroupBox4.Size = New System.Drawing.Size(540, 250)
        Me.MyGroupBox4.TabIndex = 102
        Me.MyGroupBox4.TabStop = False
        Me.MyGroupBox4.Text = "Results"
        '
        'txtFloorHeight
        '
        Me.txtFloorHeight.BackColor = System.Drawing.Color.Black
        Me.txtFloorHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFloorHeight.ForeColor = System.Drawing.Color.White
        Me.txtFloorHeight.Location = New System.Drawing.Point(308, 195)
        Me.txtFloorHeight.Name = "txtFloorHeight"
        Me.txtFloorHeight.ReadOnly = True
        Me.txtFloorHeight.Size = New System.Drawing.Size(98, 20)
        Me.txtFloorHeight.TabIndex = 132
        Me.txtFloorHeight.TabStop = False
        Me.txtFloorHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtFloorHeight, "Calculated Vertical deviation, camera centre versus target centre, in radians (ne" &
        "gative=upwards)")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(240, 197)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Floor height"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(516, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "°"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtFloorAngleD
        '
        Me.txtFloorAngleD.BackColor = System.Drawing.Color.Black
        Me.txtFloorAngleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFloorAngleD.ForeColor = System.Drawing.Color.White
        Me.txtFloorAngleD.Location = New System.Drawing.Point(412, 167)
        Me.txtFloorAngleD.Name = "txtFloorAngleD"
        Me.txtFloorAngleD.ReadOnly = True
        Me.txtFloorAngleD.Size = New System.Drawing.Size(98, 20)
        Me.txtFloorAngleD.TabIndex = 129
        Me.txtFloorAngleD.TabStop = False
        Me.txtFloorAngleD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtFloorAngleD, "Calculated Vertical deviation, camera centre versus target centre, in degrees (ne" &
        "gative=upwards)")
        '
        'txtFloorAngle
        '
        Me.txtFloorAngle.BackColor = System.Drawing.Color.Black
        Me.txtFloorAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFloorAngle.ForeColor = System.Drawing.Color.White
        Me.txtFloorAngle.Location = New System.Drawing.Point(308, 167)
        Me.txtFloorAngle.Name = "txtFloorAngle"
        Me.txtFloorAngle.ReadOnly = True
        Me.txtFloorAngle.Size = New System.Drawing.Size(98, 20)
        Me.txtFloorAngle.TabIndex = 128
        Me.txtFloorAngle.TabStop = False
        Me.txtFloorAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtFloorAngle, "Calculated Vertical deviation, camera centre versus target centre, in radians (ne" &
        "gative=upwards)")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(243, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "Floor angle"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(460, 41)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(23, 13)
        Me.Label32.TabIndex = 127
        Me.Label32.Text = "mm"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCamAverageError
        '
        Me.txtCamAverageError.BackColor = System.Drawing.Color.Black
        Me.txtCamAverageError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCamAverageError.ForeColor = System.Drawing.Color.White
        Me.txtCamAverageError.Location = New System.Drawing.Point(356, 37)
        Me.txtCamAverageError.Name = "txtCamAverageError"
        Me.txtCamAverageError.ReadOnly = True
        Me.txtCamAverageError.Size = New System.Drawing.Size(98, 20)
        Me.txtCamAverageError.TabIndex = 22
        Me.txtCamAverageError.TabStop = False
        Me.txtCamAverageError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCamAverageError, "The total 3D error, in mm, of the 5 targets, using the camera intrinsics")
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(371, 18)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(75, 13)
        Me.Label31.TabIndex = 125
        Me.Label31.Text = "Depth Camera"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(153, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(50, 13)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "Optimiser"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(516, 93)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 123
        Me.Label28.Text = "°"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(516, 67)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 122
        Me.Label29.Text = "°"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCamVFovD
        '
        Me.txtCamVFovD.BackColor = System.Drawing.Color.Black
        Me.txtCamVFovD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCamVFovD.ForeColor = System.Drawing.Color.White
        Me.txtCamVFovD.Location = New System.Drawing.Point(412, 89)
        Me.txtCamVFovD.Name = "txtCamVFovD"
        Me.txtCamVFovD.ReadOnly = True
        Me.txtCamVFovD.Size = New System.Drawing.Size(98, 20)
        Me.txtCamVFovD.TabIndex = 37
        Me.txtCamVFovD.TabStop = False
        Me.txtCamVFovD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCamVFovD, "Camera Vertical Field of View in degrees")
        '
        'txtCamHFovD
        '
        Me.txtCamHFovD.BackColor = System.Drawing.Color.Black
        Me.txtCamHFovD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCamHFovD.ForeColor = System.Drawing.Color.White
        Me.txtCamHFovD.Location = New System.Drawing.Point(412, 63)
        Me.txtCamHFovD.Name = "txtCamHFovD"
        Me.txtCamHFovD.ReadOnly = True
        Me.txtCamHFovD.Size = New System.Drawing.Size(98, 20)
        Me.txtCamHFovD.TabIndex = 35
        Me.txtCamHFovD.TabStop = False
        Me.txtCamHFovD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCamHFovD, "Camera Horizontal Field of View in degrees")
        '
        'txtCamVFov
        '
        Me.txtCamVFov.BackColor = System.Drawing.Color.Black
        Me.txtCamVFov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCamVFov.ForeColor = System.Drawing.Color.White
        Me.txtCamVFov.Location = New System.Drawing.Point(308, 89)
        Me.txtCamVFov.Name = "txtCamVFov"
        Me.txtCamVFov.ReadOnly = True
        Me.txtCamVFov.Size = New System.Drawing.Size(98, 20)
        Me.txtCamVFov.TabIndex = 36
        Me.txtCamVFov.TabStop = False
        Me.txtCamVFov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCamVFov, "Camera Vertical Field of View in radians")
        '
        'txtCamHFov
        '
        Me.txtCamHFov.BackColor = System.Drawing.Color.Black
        Me.txtCamHFov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCamHFov.ForeColor = System.Drawing.Color.White
        Me.txtCamHFov.Location = New System.Drawing.Point(308, 63)
        Me.txtCamHFov.Name = "txtCamHFov"
        Me.txtCamHFov.ReadOnly = True
        Me.txtCamHFov.Size = New System.Drawing.Size(98, 20)
        Me.txtCamHFov.TabIndex = 34
        Me.txtCamHFov.TabStop = False
        Me.txtCamHFov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCamHFov, "Camera Horizontal Field of View in radians")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(231, 41)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(23, 13)
        Me.Label27.TabIndex = 117
        Me.Label27.Text = "mm"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(286, 93)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 116
        Me.Label26.Text = "°"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(286, 67)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 115
        Me.Label25.Text = "°"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(286, 145)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 114
        Me.Label24.Text = "°"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(286, 119)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 113
        Me.Label23.Text = "°"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAverageError
        '
        Me.txtAverageError.BackColor = System.Drawing.Color.Black
        Me.txtAverageError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAverageError.ForeColor = System.Drawing.Color.White
        Me.txtAverageError.Location = New System.Drawing.Point(127, 37)
        Me.txtAverageError.Name = "txtAverageError"
        Me.txtAverageError.ReadOnly = True
        Me.txtAverageError.Size = New System.Drawing.Size(98, 20)
        Me.txtAverageError.TabIndex = 21
        Me.txtAverageError.TabStop = False
        Me.txtAverageError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtAverageError, "The total 3D error, in mm, of the 4 outer targets, using the optimised intrinsics" &
        "  (the centre target has no error, the results are centred to it)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(50, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Average error"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtVFovD
        '
        Me.txtVFovD.BackColor = System.Drawing.Color.Black
        Me.txtVFovD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVFovD.ForeColor = System.Drawing.Color.White
        Me.txtVFovD.Location = New System.Drawing.Point(182, 89)
        Me.txtVFovD.Name = "txtVFovD"
        Me.txtVFovD.ReadOnly = True
        Me.txtVFovD.Size = New System.Drawing.Size(98, 20)
        Me.txtVFovD.TabIndex = 26
        Me.txtVFovD.TabStop = False
        Me.txtVFovD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtVFovD, "Optimised Vertical Field of View in degrees")
        '
        'txtHFovD
        '
        Me.txtHFovD.BackColor = System.Drawing.Color.Black
        Me.txtHFovD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHFovD.ForeColor = System.Drawing.Color.White
        Me.txtHFovD.Location = New System.Drawing.Point(182, 63)
        Me.txtHFovD.Name = "txtHFovD"
        Me.txtHFovD.ReadOnly = True
        Me.txtHFovD.Size = New System.Drawing.Size(98, 20)
        Me.txtHFovD.TabIndex = 24
        Me.txtHFovD.TabStop = False
        Me.txtHFovD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtHFovD, "Optimised Horizontal Field of View in degrees")
        '
        'txtInclinationD
        '
        Me.txtInclinationD.BackColor = System.Drawing.Color.Black
        Me.txtInclinationD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInclinationD.ForeColor = System.Drawing.Color.White
        Me.txtInclinationD.Location = New System.Drawing.Point(182, 141)
        Me.txtInclinationD.Name = "txtInclinationD"
        Me.txtInclinationD.ReadOnly = True
        Me.txtInclinationD.Size = New System.Drawing.Size(98, 20)
        Me.txtInclinationD.TabIndex = 30
        Me.txtInclinationD.TabStop = False
        Me.txtInclinationD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtInclinationD, "Calculated Vertical deviation, camera centre versus target centre, in degrees (ne" &
        "gative=upwards)")
        '
        'txtDeviationD
        '
        Me.txtDeviationD.BackColor = System.Drawing.Color.Black
        Me.txtDeviationD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeviationD.ForeColor = System.Drawing.Color.White
        Me.txtDeviationD.Location = New System.Drawing.Point(182, 115)
        Me.txtDeviationD.Name = "txtDeviationD"
        Me.txtDeviationD.ReadOnly = True
        Me.txtDeviationD.Size = New System.Drawing.Size(98, 20)
        Me.txtDeviationD.TabIndex = 28
        Me.txtDeviationD.TabStop = False
        Me.txtDeviationD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtDeviationD, "Calculated Horizontal deviation, camera centre versus target centre, in degrees (" &
        "negative=left)")
        '
        'txtC
        '
        Me.txtC.BackColor = System.Drawing.Color.Black
        Me.txtC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtC.ForeColor = System.Drawing.Color.White
        Me.txtC.Location = New System.Drawing.Point(78, 219)
        Me.txtC.Name = "txtC"
        Me.txtC.ReadOnly = True
        Me.txtC.Size = New System.Drawing.Size(98, 20)
        Me.txtC.TabIndex = 33
        Me.txtC.TabStop = False
        Me.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtC, """C"" value of the quadratic correction. Z = Z + A*Z^Z + B*Z + C. The distance from" &
        " the glass to the focal point of the depth map (positive=behind)")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(58, 223)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(14, 13)
        Me.Label21.TabIndex = 105
        Me.Label21.Text = "C"
        '
        'txtB
        '
        Me.txtB.BackColor = System.Drawing.Color.Black
        Me.txtB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtB.ForeColor = System.Drawing.Color.White
        Me.txtB.Location = New System.Drawing.Point(78, 193)
        Me.txtB.Name = "txtB"
        Me.txtB.ReadOnly = True
        Me.txtB.Size = New System.Drawing.Size(98, 20)
        Me.txtB.TabIndex = 32
        Me.txtB.TabStop = False
        Me.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtB, """B"" value of the quadratic correction. Z = Z + A*Z^Z + B*Z + C")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(58, 197)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(14, 13)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "B"
        '
        'txtA
        '
        Me.txtA.BackColor = System.Drawing.Color.Black
        Me.txtA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtA.ForeColor = System.Drawing.Color.White
        Me.txtA.Location = New System.Drawing.Point(78, 167)
        Me.txtA.Name = "txtA"
        Me.txtA.ReadOnly = True
        Me.txtA.Size = New System.Drawing.Size(98, 20)
        Me.txtA.TabIndex = 31
        Me.txtA.TabStop = False
        Me.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtA, """A"" value of the quadratic correction. Z = Z + A*Z^Z + B*Z + C")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(58, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(14, 13)
        Me.Label19.TabIndex = 101
        Me.Label19.Text = "A"
        '
        'txtVFov
        '
        Me.txtVFov.BackColor = System.Drawing.Color.Black
        Me.txtVFov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVFov.ForeColor = System.Drawing.Color.White
        Me.txtVFov.Location = New System.Drawing.Point(78, 89)
        Me.txtVFov.Name = "txtVFov"
        Me.txtVFov.ReadOnly = True
        Me.txtVFov.Size = New System.Drawing.Size(98, 20)
        Me.txtVFov.TabIndex = 25
        Me.txtVFov.TabStop = False
        Me.txtVFov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtVFov, "Optimised Vertical Field of View in radians")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(40, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 99
        Me.Label18.Text = "VFov"
        '
        'txtHFov
        '
        Me.txtHFov.BackColor = System.Drawing.Color.Black
        Me.txtHFov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHFov.ForeColor = System.Drawing.Color.White
        Me.txtHFov.Location = New System.Drawing.Point(78, 63)
        Me.txtHFov.Name = "txtHFov"
        Me.txtHFov.ReadOnly = True
        Me.txtHFov.Size = New System.Drawing.Size(98, 20)
        Me.txtHFov.TabIndex = 23
        Me.txtHFov.TabStop = False
        Me.txtHFov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtHFov, "Optimised Horizontal Field of View in radians")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(39, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "HFov"
        '
        'txtInclination
        '
        Me.txtInclination.BackColor = System.Drawing.Color.Black
        Me.txtInclination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInclination.ForeColor = System.Drawing.Color.White
        Me.txtInclination.Location = New System.Drawing.Point(78, 141)
        Me.txtInclination.Name = "txtInclination"
        Me.txtInclination.ReadOnly = True
        Me.txtInclination.Size = New System.Drawing.Size(98, 20)
        Me.txtInclination.TabIndex = 29
        Me.txtInclination.TabStop = False
        Me.txtInclination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtInclination, "Calculated Vertical deviation, camera centre versus target centre, in radians (ne" &
        "gative=upwards)")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(17, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Inclination"
        '
        'txtDeviation
        '
        Me.txtDeviation.BackColor = System.Drawing.Color.Black
        Me.txtDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeviation.ForeColor = System.Drawing.Color.White
        Me.txtDeviation.Location = New System.Drawing.Point(78, 115)
        Me.txtDeviation.Name = "txtDeviation"
        Me.txtDeviation.ReadOnly = True
        Me.txtDeviation.Size = New System.Drawing.Size(98, 20)
        Me.txtDeviation.TabIndex = 27
        Me.txtDeviation.TabStop = False
        Me.txtDeviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtDeviation, "Calculated Horizontal deviation, camera centre versus target centre, in radians (" &
        "negative=left)")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(20, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Deviation"
        '
        'dgvMeasures
        '
        Me.dgvMeasures.AllowUserToAddRows = False
        Me.dgvMeasures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMeasures.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMeasures.BackgroundColor = System.Drawing.Color.Black
        Me.dgvMeasures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMeasures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMeasures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeasures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Truth, Me.MeanRange, Me.Sigma, Me.Samples})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMeasures.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMeasures.EnableHeadersVisualStyles = False
        Me.dgvMeasures.GridColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvMeasures.Location = New System.Drawing.Point(13, 314)
        Me.dgvMeasures.Name = "dgvMeasures"
        Me.dgvMeasures.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMeasures.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvMeasures.RowHeadersWidth = 20
        Me.dgvMeasures.Size = New System.Drawing.Size(322, 299)
        Me.dgvMeasures.TabIndex = 20
        Me.dgvMeasures.TabStop = False
        Me.ToolTip1.SetToolTip(Me.dgvMeasures, "Shows the planes (target sets) that have been measured")
        '
        'Truth
        '
        Me.Truth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Truth.DataPropertyName = "Truth"
        DataGridViewCellStyle2.Format = "#,##0.000"
        Me.Truth.DefaultCellStyle = DataGridViewCellStyle2
        Me.Truth.HeaderText = "Truth"
        Me.Truth.MinimumWidth = 50
        Me.Truth.Name = "Truth"
        Me.Truth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Truth.Width = 50
        '
        'MeanRange
        '
        Me.MeanRange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MeanRange.DataPropertyName = "MeanRange"
        DataGridViewCellStyle3.Format = "#,##0.000"
        Me.MeanRange.DefaultCellStyle = DataGridViewCellStyle3
        Me.MeanRange.HeaderText = "Mean Z"
        Me.MeanRange.MinimumWidth = 50
        Me.MeanRange.Name = "MeanRange"
        Me.MeanRange.ReadOnly = True
        Me.MeanRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MeanRange.Width = 50
        '
        'Sigma
        '
        Me.Sigma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Sigma.DataPropertyName = "Sigma"
        DataGridViewCellStyle4.Format = "#,##0.000"
        Me.Sigma.DefaultCellStyle = DataGridViewCellStyle4
        Me.Sigma.HeaderText = "Sigma"
        Me.Sigma.MinimumWidth = 50
        Me.Sigma.Name = "Sigma"
        Me.Sigma.ReadOnly = True
        Me.Sigma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Sigma.Width = 50
        '
        'Samples
        '
        Me.Samples.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Samples.DataPropertyName = "Samples"
        DataGridViewCellStyle5.Format = "#,##0"
        Me.Samples.DefaultCellStyle = DataGridViewCellStyle5
        Me.Samples.HeaderText = "Samples"
        Me.Samples.MinimumWidth = 50
        Me.Samples.Name = "Samples"
        Me.Samples.ReadOnly = True
        Me.Samples.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Samples.Width = 52
        '
        'MyGroupBox2
        '
        Me.MyGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MyGroupBox2.BorderRadius = 5
        Me.MyGroupBox2.BorderWidth = 1.8!
        Me.MyGroupBox2.Controls.Add(Me.Label14)
        Me.MyGroupBox2.Controls.Add(Me.txtTargetHeight)
        Me.MyGroupBox2.Controls.Add(Me.Label9)
        Me.MyGroupBox2.Controls.Add(Me.Label6)
        Me.MyGroupBox2.Controls.Add(Me.txtRange)
        Me.MyGroupBox2.Controls.Add(Me.txtTargetWidth)
        Me.MyGroupBox2.Controls.Add(Me.Label11)
        Me.MyGroupBox2.Controls.Add(Me.Label12)
        Me.MyGroupBox2.Controls.Add(Me.Label13)
        Me.MyGroupBox2.ForeColor = System.Drawing.Color.White
        Me.MyGroupBox2.LabelIndent = 15
        Me.MyGroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.MyGroupBox2.Name = "MyGroupBox2"
        Me.MyGroupBox2.Size = New System.Drawing.Size(324, 75)
        Me.MyGroupBox2.TabIndex = 0
        Me.MyGroupBox2.TabStop = False
        Me.MyGroupBox2.Text = "Target"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(114, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(23, 13)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "mm"
        '
        'txtTargetHeight
        '
        Me.txtTargetHeight.BackColor = System.Drawing.Color.Black
        Me.txtTargetHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTargetHeight.ForeColor = System.Drawing.Color.White
        Me.txtTargetHeight.Location = New System.Drawing.Point(58, 45)
        Me.txtTargetHeight.Name = "txtTargetHeight"
        Me.txtTargetHeight.Size = New System.Drawing.Size(50, 20)
        Me.txtTargetHeight.TabIndex = 2
        Me.txtTargetHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtTargetHeight, "Distance in mm between the centres of the top and bottom red targets")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(14, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Height"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Range"
        '
        'txtRange
        '
        Me.txtRange.BackColor = System.Drawing.Color.Black
        Me.txtRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRange.ForeColor = System.Drawing.Color.White
        Me.txtRange.Location = New System.Drawing.Point(58, 19)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(50, 20)
        Me.txtRange.TabIndex = 1
        Me.txtRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtRange, "Distance in mm from the front glass of the camera to the centre of the target")
        '
        'txtTargetWidth
        '
        Me.txtTargetWidth.BackColor = System.Drawing.Color.Black
        Me.txtTargetWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTargetWidth.ForeColor = System.Drawing.Color.White
        Me.txtTargetWidth.Location = New System.Drawing.Point(188, 45)
        Me.txtTargetWidth.Name = "txtTargetWidth"
        Me.txtTargetWidth.Size = New System.Drawing.Size(50, 20)
        Me.txtTargetWidth.TabIndex = 3
        Me.txtTargetWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtTargetWidth, "Distance in mm between the centres of the left and right red targets")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(147, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Width"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(245, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 24)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "↔"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(113, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 24)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "↕"
        '
        'MyGroupBox1
        '
        Me.MyGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MyGroupBox1.BorderRadius = 8
        Me.MyGroupBox1.BorderWidth = 1.8!
        Me.MyGroupBox1.Controls.Add(Me.chkViewDepth)
        Me.MyGroupBox1.Controls.Add(Me.chkViewColour)
        Me.MyGroupBox1.Controls.Add(Me.lnkColourIntrinsics)
        Me.MyGroupBox1.Controls.Add(Me.lnkDepthIntrinsics)
        Me.MyGroupBox1.Controls.Add(Me.lnkColourOptions)
        Me.MyGroupBox1.Controls.Add(Me.lnkDepthOptions)
        Me.MyGroupBox1.Controls.Add(Me.chkTemporal)
        Me.MyGroupBox1.Controls.Add(Me.chkSpatial)
        Me.MyGroupBox1.Controls.Add(Me.chkHoleFilling)
        Me.MyGroupBox1.Controls.Add(Me.Label5)
        Me.MyGroupBox1.Controls.Add(Me.chkDecimation)
        Me.MyGroupBox1.Controls.Add(Me.lblColourWarning)
        Me.MyGroupBox1.Controls.Add(Me.cmbFrameRate)
        Me.MyGroupBox1.Controls.Add(Me.Label4)
        Me.MyGroupBox1.Controls.Add(Me.cmbColourFormat)
        Me.MyGroupBox1.Controls.Add(Me.Label3)
        Me.MyGroupBox1.Controls.Add(Me.cmbDepthFormat)
        Me.MyGroupBox1.Controls.Add(Me.Label2)
        Me.MyGroupBox1.Controls.Add(Me.cmbCamera)
        Me.MyGroupBox1.Controls.Add(Me.Label1)
        Me.MyGroupBox1.ForeColor = System.Drawing.Color.White
        Me.MyGroupBox1.LabelIndent = 15
        Me.MyGroupBox1.Location = New System.Drawing.Point(12, 86)
        Me.MyGroupBox1.Name = "MyGroupBox1"
        Me.MyGroupBox1.Size = New System.Drawing.Size(324, 222)
        Me.MyGroupBox1.TabIndex = 77
        Me.MyGroupBox1.TabStop = False
        Me.MyGroupBox1.Text = "Camera"
        '
        'chkViewDepth
        '
        Me.chkViewDepth.AutoSize = True
        Me.chkViewDepth.Location = New System.Drawing.Point(218, 152)
        Me.chkViewDepth.Name = "chkViewDepth"
        Me.chkViewDepth.Size = New System.Drawing.Size(89, 17)
        Me.chkViewDepth.TabIndex = 17
        Me.chkViewDepth.Text = "Depth stream"
        Me.ToolTip1.SetToolTip(Me.chkViewDepth, "Display the depth stream in a separate window")
        Me.chkViewDepth.UseVisualStyleBackColor = True
        '
        'chkViewColour
        '
        Me.chkViewColour.AutoSize = True
        Me.chkViewColour.Location = New System.Drawing.Point(217, 126)
        Me.chkViewColour.Name = "chkViewColour"
        Me.chkViewColour.Size = New System.Drawing.Size(90, 17)
        Me.chkViewColour.TabIndex = 16
        Me.chkViewColour.Text = "Colour stream"
        Me.ToolTip1.SetToolTip(Me.chkViewColour, "Display the colour stream in a separate window")
        Me.chkViewColour.UseVisualStyleBackColor = True
        '
        'lnkColourIntrinsics
        '
        Me.lnkColourIntrinsics.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkColourIntrinsics.AutoSize = True
        Me.lnkColourIntrinsics.LinkColor = System.Drawing.Color.White
        Me.lnkColourIntrinsics.Location = New System.Drawing.Point(263, 76)
        Me.lnkColourIntrinsics.Name = "lnkColourIntrinsics"
        Me.lnkColourIntrinsics.Size = New System.Drawing.Size(48, 13)
        Me.lnkColourIntrinsics.TabIndex = 10
        Me.lnkColourIntrinsics.TabStop = True
        Me.lnkColourIntrinsics.Text = "Intrinsics"
        Me.ToolTip1.SetToolTip(Me.lnkColourIntrinsics, "Display the colour camera intrinsics")
        Me.lnkColourIntrinsics.VisitedLinkColor = System.Drawing.Color.White
        '
        'lnkDepthIntrinsics
        '
        Me.lnkDepthIntrinsics.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDepthIntrinsics.AutoSize = True
        Me.lnkDepthIntrinsics.LinkColor = System.Drawing.Color.White
        Me.lnkDepthIntrinsics.Location = New System.Drawing.Point(263, 49)
        Me.lnkDepthIntrinsics.Name = "lnkDepthIntrinsics"
        Me.lnkDepthIntrinsics.Size = New System.Drawing.Size(48, 13)
        Me.lnkDepthIntrinsics.TabIndex = 7
        Me.lnkDepthIntrinsics.TabStop = True
        Me.lnkDepthIntrinsics.Text = "Intrinsics"
        Me.ToolTip1.SetToolTip(Me.lnkDepthIntrinsics, "Display the depth camera intrinsics")
        Me.lnkDepthIntrinsics.VisitedLinkColor = System.Drawing.Color.White
        '
        'lnkColourOptions
        '
        Me.lnkColourOptions.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkColourOptions.AutoSize = True
        Me.lnkColourOptions.LinkColor = System.Drawing.Color.White
        Me.lnkColourOptions.Location = New System.Drawing.Point(214, 76)
        Me.lnkColourOptions.Name = "lnkColourOptions"
        Me.lnkColourOptions.Size = New System.Drawing.Size(43, 13)
        Me.lnkColourOptions.TabIndex = 9
        Me.lnkColourOptions.TabStop = True
        Me.lnkColourOptions.Text = "Options"
        Me.ToolTip1.SetToolTip(Me.lnkColourOptions, "Display/modify the colour camera options")
        Me.lnkColourOptions.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lnkDepthOptions
        '
        Me.lnkDepthOptions.ActiveLinkColor = System.Drawing.Color.White
        Me.lnkDepthOptions.AutoSize = True
        Me.lnkDepthOptions.LinkColor = System.Drawing.Color.White
        Me.lnkDepthOptions.Location = New System.Drawing.Point(214, 49)
        Me.lnkDepthOptions.Name = "lnkDepthOptions"
        Me.lnkDepthOptions.Size = New System.Drawing.Size(43, 13)
        Me.lnkDepthOptions.TabIndex = 6
        Me.lnkDepthOptions.TabStop = True
        Me.lnkDepthOptions.Text = "Options"
        Me.ToolTip1.SetToolTip(Me.lnkDepthOptions, "Display/modify the depth camera options")
        Me.lnkDepthOptions.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'chkTemporal
        '
        Me.chkTemporal.AutoSize = True
        Me.chkTemporal.ForeColor = System.Drawing.Color.White
        Me.chkTemporal.Location = New System.Drawing.Point(86, 195)
        Me.chkTemporal.Name = "chkTemporal"
        Me.chkTemporal.Size = New System.Drawing.Size(70, 17)
        Me.chkTemporal.TabIndex = 15
        Me.chkTemporal.Text = "Temporal"
        Me.ToolTip1.SetToolTip(Me.chkTemporal, "The depthmap will have temporal filtering applied")
        Me.chkTemporal.UseVisualStyleBackColor = True
        '
        'chkSpatial
        '
        Me.chkSpatial.AutoSize = True
        Me.chkSpatial.ForeColor = System.Drawing.Color.White
        Me.chkSpatial.Location = New System.Drawing.Point(86, 172)
        Me.chkSpatial.Name = "chkSpatial"
        Me.chkSpatial.Size = New System.Drawing.Size(58, 17)
        Me.chkSpatial.TabIndex = 14
        Me.chkSpatial.Text = "Spatial"
        Me.ToolTip1.SetToolTip(Me.chkSpatial, "The depthmap will have spatial filtering applied")
        Me.chkSpatial.UseVisualStyleBackColor = True
        '
        'chkHoleFilling
        '
        Me.chkHoleFilling.AutoSize = True
        Me.chkHoleFilling.ForeColor = System.Drawing.Color.White
        Me.chkHoleFilling.Location = New System.Drawing.Point(86, 149)
        Me.chkHoleFilling.Name = "chkHoleFilling"
        Me.chkHoleFilling.Size = New System.Drawing.Size(74, 17)
        Me.chkHoleFilling.TabIndex = 13
        Me.chkHoleFilling.Text = "Hole-filling"
        Me.ToolTip1.SetToolTip(Me.chkHoleFilling, "The depthmap will have holes filled")
        Me.chkHoleFilling.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(46, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Filters"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkDecimation
        '
        Me.chkDecimation.AutoSize = True
        Me.chkDecimation.ForeColor = System.Drawing.Color.White
        Me.chkDecimation.Location = New System.Drawing.Point(86, 126)
        Me.chkDecimation.Name = "chkDecimation"
        Me.chkDecimation.Size = New System.Drawing.Size(79, 17)
        Me.chkDecimation.TabIndex = 12
        Me.chkDecimation.Text = "Decimation"
        Me.ToolTip1.SetToolTip(Me.chkDecimation, "The depth image will be decimated (to half-resolution)")
        Me.chkDecimation.UseVisualStyleBackColor = True
        '
        'lblColourWarning
        '
        Me.lblColourWarning.AutoSize = True
        Me.lblColourWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblColourWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.lblColourWarning.Location = New System.Drawing.Point(214, 75)
        Me.lblColourWarning.Name = "lblColourWarning"
        Me.lblColourWarning.Size = New System.Drawing.Size(0, 13)
        Me.lblColourWarning.TabIndex = 64
        Me.lblColourWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFrameRate
        '
        Me.cmbFrameRate.BackColor = System.Drawing.Color.Black
        Me.cmbFrameRate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFrameRate.ForeColor = System.Drawing.Color.White
        Me.cmbFrameRate.FormattingEnabled = True
        Me.cmbFrameRate.Items.AddRange(New Object() {"6", "15", "30", "60", "90"})
        Me.cmbFrameRate.Location = New System.Drawing.Point(86, 99)
        Me.cmbFrameRate.MaxDropDownItems = 50
        Me.cmbFrameRate.Name = "cmbFrameRate"
        Me.cmbFrameRate.Size = New System.Drawing.Size(57, 21)
        Me.cmbFrameRate.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cmbFrameRate, "The desired framerate. 60 is ideal")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(23, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Frame rate"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbColourFormat
        '
        Me.cmbColourFormat.BackColor = System.Drawing.Color.Black
        Me.cmbColourFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbColourFormat.ForeColor = System.Drawing.Color.White
        Me.cmbColourFormat.FormattingEnabled = True
        Me.cmbColourFormat.Location = New System.Drawing.Point(86, 72)
        Me.cmbColourFormat.MaxDropDownItems = 50
        Me.cmbColourFormat.Name = "cmbColourFormat"
        Me.cmbColourFormat.Size = New System.Drawing.Size(122, 21)
        Me.cmbColourFormat.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbColourFormat, "Select the format of the colour stream, 848x480 is ideal")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Colour Format"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDepthFormat
        '
        Me.cmbDepthFormat.BackColor = System.Drawing.Color.Black
        Me.cmbDepthFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbDepthFormat.ForeColor = System.Drawing.Color.White
        Me.cmbDepthFormat.FormattingEnabled = True
        Me.cmbDepthFormat.Location = New System.Drawing.Point(86, 45)
        Me.cmbDepthFormat.MaxDropDownItems = 50
        Me.cmbDepthFormat.Name = "cmbDepthFormat"
        Me.cmbDepthFormat.Size = New System.Drawing.Size(122, 21)
        Me.cmbDepthFormat.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmbDepthFormat, "Select the format of the depth stream, 848x480 is ideal")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Depth Format"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCamera
        '
        Me.cmbCamera.BackColor = System.Drawing.Color.Black
        Me.cmbCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCamera.ForeColor = System.Drawing.Color.White
        Me.cmbCamera.FormattingEnabled = True
        Me.cmbCamera.Location = New System.Drawing.Point(86, 18)
        Me.cmbCamera.Name = "cmbCamera"
        Me.cmbCamera.Size = New System.Drawing.Size(224, 21)
        Me.cmbCamera.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmbCamera, "Select the camera to calibrate")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(37, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Camera"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Measuring1
        '
        Me.Measuring1.BackColor = System.Drawing.Color.Black
        Me.Measuring1.Location = New System.Drawing.Point(342, 3)
        Me.Measuring1.Name = "Measuring1"
        Me.Measuring1.Plane = Nothing
        Me.Measuring1.Size = New System.Drawing.Size(764, 382)
        Me.Measuring1.TabIndex = 4
        Me.Measuring1.TabStop = False
        '
        'rtbMessages
        '
        Me.rtbMessages.BackColor = System.Drawing.Color.Black
        Me.rtbMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMessages.Location = New System.Drawing.Point(0, 0)
        Me.rtbMessages.Name = "rtbMessages"
        Me.rtbMessages.ReadOnly = True
        Me.rtbMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbMessages.Size = New System.Drawing.Size(1133, 97)
        Me.rtbMessages.TabIndex = 38
        Me.rtbMessages.TabStop = False
        Me.rtbMessages.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.CrosshairsToolStripMenuItem, Me.FindTargetsToolStripMenuItem, Me.MeasureToolStripMenuItem, Me.FindRowToolStripMenuItem, Me.FindFloorToolStripMenuItem, Me.FinaliseMeasurementToolStripMenuItem, Me.OptimiseToolStripMenuItem, Me.ChartToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1133, 24)
        Me.MenuStrip1.TabIndex = 37
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.LoadToolStripMenuItem.Text = "&Load..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.SaveAsToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SaveAsToolStripMenuItem.Text = "&Save as ..."
        Me.SaveAsToolStripMenuItem.ToolTipText = "Save the results to 2 CSV files, XXX Planes.txt and XXXTrinsics.txt"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.QuitToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'CrosshairsToolStripMenuItem
        '
        Me.CrosshairsToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.CrosshairsToolStripMenuItem.Name = "CrosshairsToolStripMenuItem"
        Me.CrosshairsToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.CrosshairsToolStripMenuItem.Text = "&Crosshairs"
        Me.CrosshairsToolStripMenuItem.ToolTipText = "Display the crosshairs, to assist in the initial alignment of the target plane"
        '
        'FindTargetsToolStripMenuItem
        '
        Me.FindTargetsToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.FindTargetsToolStripMenuItem.Name = "FindTargetsToolStripMenuItem"
        Me.FindTargetsToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.FindTargetsToolStripMenuItem.Text = "&Find targets"
        Me.FindTargetsToolStripMenuItem.ToolTipText = "Find the 5 red targets on the plane currently in view"
        '
        'MeasureToolStripMenuItem
        '
        Me.MeasureToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.MeasureToolStripMenuItem.Name = "MeasureToolStripMenuItem"
        Me.MeasureToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.MeasureToolStripMenuItem.Text = "&Measure"
        Me.MeasureToolStripMenuItem.ToolTipText = "Measure the distances, calculating the statistics"
        '
        'FindRowToolStripMenuItem
        '
        Me.FindRowToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.FindRowToolStripMenuItem.Name = "FindRowToolStripMenuItem"
        Me.FindRowToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.FindRowToolStripMenuItem.Text = "Find Row"
        '
        'FindFloorToolStripMenuItem
        '
        Me.FindFloorToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.FindFloorToolStripMenuItem.Name = "FindFloorToolStripMenuItem"
        Me.FindFloorToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.FindFloorToolStripMenuItem.Text = "Find Floor"
        '
        'FinaliseMeasurementToolStripMenuItem
        '
        Me.FinaliseMeasurementToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.FinaliseMeasurementToolStripMenuItem.Name = "FinaliseMeasurementToolStripMenuItem"
        Me.FinaliseMeasurementToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.FinaliseMeasurementToolStripMenuItem.Text = "F&inalise"
        Me.FinaliseMeasurementToolStripMenuItem.ToolTipText = "Stop measuring this plane (before moving the target plane to a different distance" &
    ")"
        '
        'OptimiseToolStripMenuItem
        '
        Me.OptimiseToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.OptimiseToolStripMenuItem.Name = "OptimiseToolStripMenuItem"
        Me.OptimiseToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.OptimiseToolStripMenuItem.Text = "&Optimise"
        Me.OptimiseToolStripMenuItem.ToolTipText = "Compute the optimal intrinsics from the observed measurements"
        '
        'ChartToolStripMenuItem
        '
        Me.ChartToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.ChartToolStripMenuItem.Name = "ChartToolStripMenuItem"
        Me.ChartToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ChartToolStripMenuItem.Text = "Chart"
        Me.ChartToolStripMenuItem.ToolTipText = "Display a chart showing the accuracy using the camera's intrinsics compared to th" &
    "e optimised intrinsics"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuideToolStripMenuItem})
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AboutToolStripMenuItem.Text = "&Help"
        '
        'GuideToolStripMenuItem
        '
        Me.GuideToolStripMenuItem.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.GuideToolStripMenuItem.Name = "GuideToolStripMenuItem"
        Me.GuideToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.GuideToolStripMenuItem.Text = "&Guide"
        '
        'txtPixelAspectRatio
        '
        Me.txtPixelAspectRatio.BackColor = System.Drawing.Color.Black
        Me.txtPixelAspectRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPixelAspectRatio.ForeColor = System.Drawing.Color.White
        Me.txtPixelAspectRatio.Location = New System.Drawing.Point(308, 221)
        Me.txtPixelAspectRatio.Name = "txtPixelAspectRatio"
        Me.txtPixelAspectRatio.ReadOnly = True
        Me.txtPixelAspectRatio.Size = New System.Drawing.Size(98, 20)
        Me.txtPixelAspectRatio.TabIndex = 134
        Me.txtPixelAspectRatio.TabStop = False
        Me.txtPixelAspectRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtPixelAspectRatio, "Calculated Vertical deviation, camera centre versus target centre, in radians (ne" &
        "gative=upwards)")
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(209, 223)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 13)
        Me.Label33.TabIndex = 135
        Me.Label33.Text = "Pixel Aspect Ratio"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1133, 766)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "RealSense Calibrator"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MyGroupBox4.ResumeLayout(False)
        Me.MyGroupBox4.PerformLayout()
        CType(Me.dgvMeasures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyGroupBox2.ResumeLayout(False)
        Me.MyGroupBox2.PerformLayout()
        Me.MyGroupBox1.ResumeLayout(False)
        Me.MyGroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Measuring1 As Measuring
    Friend WithEvents rtbMessages As RichTextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MyGroupBox1 As MyGroupBox
    Friend WithEvents lnkColourOptions As LinkLabel
    Friend WithEvents lnkDepthOptions As LinkLabel
    Friend WithEvents chkTemporal As CheckBox
    Friend WithEvents chkSpatial As CheckBox
    Friend WithEvents chkHoleFilling As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkDecimation As CheckBox
    Friend WithEvents lblColourWarning As Label
    Friend WithEvents cmbFrameRate As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbColourFormat As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDepthFormat As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCamera As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MyGroupBox2 As MyGroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTargetHeight As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtRange As TextBox
    Friend WithEvents txtTargetWidth As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lnkColourIntrinsics As LinkLabel
    Friend WithEvents lnkDepthIntrinsics As LinkLabel
    Friend WithEvents cmbLogLevel As ComboBox
    Friend WithEvents dgvMeasures As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindTargetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinaliseMeasurementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptimiseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MyGroupBox4 As MyGroupBox
    Friend WithEvents txtVFov As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtHFov As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtInclination As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDeviation As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtC As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtB As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtA As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtVFovD As TextBox
    Friend WithEvents txtHFovD As TextBox
    Friend WithEvents txtInclinationD As TextBox
    Friend WithEvents txtDeviationD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtAverageError As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label32 As Label
    Friend WithEvents txtCamAverageError As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtCamVFovD As TextBox
    Friend WithEvents txtCamHFovD As TextBox
    Friend WithEvents txtCamVFov As TextBox
    Friend WithEvents txtCamHFov As TextBox
    Friend WithEvents MeasureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrosshairsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Truth As DataGridViewTextBoxColumn
    Friend WithEvents MeanRange As DataGridViewTextBoxColumn
    Friend WithEvents Sigma As DataGridViewTextBoxColumn
    Friend WithEvents Samples As DataGridViewTextBoxColumn
    Friend WithEvents chkViewDepth As CheckBox
    Friend WithEvents chkViewColour As CheckBox
    Friend WithEvents ChartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblLoglevel As Label
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindFloorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtFloorHeight As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFloorAngleD As TextBox
    Friend WithEvents txtFloorAngle As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPixelAspectRatio As TextBox
    Friend WithEvents Label33 As Label
End Class
