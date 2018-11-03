<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Picture
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.lnkReset = New System.Windows.Forms.LinkLabel()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.txtFPS = New System.Windows.Forms.TextBox()
        Me.lbFPS = New System.Windows.Forms.Label()
        Me.txtXY = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pnlInfo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(680, 480)
        Me.Panel1.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(678, 458)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.lnkReset)
        Me.pnlInfo.Controls.Add(Me.txtSize)
        Me.pnlInfo.Controls.Add(Me.txtInfo)
        Me.pnlInfo.Controls.Add(Me.txtFPS)
        Me.pnlInfo.Controls.Add(Me.lbFPS)
        Me.pnlInfo.Controls.Add(Me.txtXY)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInfo.Location = New System.Drawing.Point(0, 458)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(678, 20)
        Me.pnlInfo.TabIndex = 6
        '
        'lnkReset
        '
        Me.lnkReset.AutoSize = True
        Me.lnkReset.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkReset.LinkColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lnkReset.Location = New System.Drawing.Point(302, 3)
        Me.lnkReset.Name = "lnkReset"
        Me.lnkReset.Size = New System.Drawing.Size(76, 13)
        Me.lnkReset.TabIndex = 64
        Me.lnkReset.TabStop = True
        Me.lnkReset.Text = "Reset to 100%"
        Me.lnkReset.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(28, Byte), Integer))
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.Black
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSize.ForeColor = System.Drawing.Color.White
        Me.txtSize.Location = New System.Drawing.Point(407, 3)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(96, 13)
        Me.txtSize.TabIndex = 8
        Me.txtSize.TabStop = False
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.Color.Black
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInfo.ForeColor = System.Drawing.Color.White
        Me.txtInfo.Location = New System.Drawing.Point(116, 3)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(171, 13)
        Me.txtInfo.TabIndex = 7
        Me.txtInfo.TabStop = False
        Me.txtInfo.Text = "Info"
        '
        'txtFPS
        '
        Me.txtFPS.BackColor = System.Drawing.Color.Black
        Me.txtFPS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFPS.ForeColor = System.Drawing.Color.White
        Me.txtFPS.Location = New System.Drawing.Point(570, 3)
        Me.txtFPS.Name = "txtFPS"
        Me.txtFPS.ReadOnly = True
        Me.txtFPS.Size = New System.Drawing.Size(39, 13)
        Me.txtFPS.TabIndex = 6
        Me.txtFPS.TabStop = False
        Me.txtFPS.Text = "999,9"
        Me.txtFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbFPS
        '
        Me.lbFPS.AutoSize = True
        Me.lbFPS.Location = New System.Drawing.Point(623, 3)
        Me.lbFPS.Name = "lbFPS"
        Me.lbFPS.Size = New System.Drawing.Size(27, 13)
        Me.lbFPS.TabIndex = 5
        Me.lbFPS.Text = "FPS"
        Me.lbFPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtXY
        '
        Me.txtXY.BackColor = System.Drawing.Color.Black
        Me.txtXY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtXY.ForeColor = System.Drawing.Color.White
        Me.txtXY.Location = New System.Drawing.Point(3, 3)
        Me.txtXY.Name = "txtXY"
        Me.txtXY.ReadOnly = True
        Me.txtXY.Size = New System.Drawing.Size(107, 13)
        Me.txtXY.TabIndex = 4
        Me.txtXY.TabStop = False
        Me.txtXY.Text = "X 9,999.9 Y 9,999.9"
        Me.txtXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Picture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Picture"
        Me.Size = New System.Drawing.Size(680, 480)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents lnkReset As LinkLabel
    Friend WithEvents txtSize As TextBox
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents txtFPS As TextBox
    Friend WithEvents lbFPS As Label
    Friend WithEvents txtXY As TextBox
End Class
