<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RedCircle
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbPixels = New System.Windows.Forms.PictureBox()
        Me.txtRange = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSigma = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSamples = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbPixels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(31, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Col"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCol
        '
        Me.txtCol.BackColor = System.Drawing.Color.Black
        Me.txtCol.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCol.ForeColor = System.Drawing.Color.White
        Me.txtCol.Location = New System.Drawing.Point(59, 4)
        Me.txtCol.Name = "txtCol"
        Me.txtCol.ReadOnly = True
        Me.txtCol.Size = New System.Drawing.Size(60, 13)
        Me.txtCol.TabIndex = 1
        Me.txtCol.TabStop = False
        Me.txtCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCol, "The column of the centre of this target; the average of the columns of all the re" &
        "d pixels in this target")
        '
        'txtRow
        '
        Me.txtRow.BackColor = System.Drawing.Color.Black
        Me.txtRow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRow.ForeColor = System.Drawing.Color.White
        Me.txtRow.Location = New System.Drawing.Point(59, 25)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.ReadOnly = True
        Me.txtRow.Size = New System.Drawing.Size(60, 13)
        Me.txtRow.TabIndex = 3
        Me.txtRow.TabStop = False
        Me.txtRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtRow, "The row of the centre of this target; the average of the rows of all the red pixe" &
        "ls in this target")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Row"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRadius
        '
        Me.txtRadius.BackColor = System.Drawing.Color.Black
        Me.txtRadius.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRadius.ForeColor = System.Drawing.Color.White
        Me.txtRadius.Location = New System.Drawing.Point(59, 46)
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.ReadOnly = True
        Me.txtRadius.Size = New System.Drawing.Size(60, 13)
        Me.txtRadius.TabIndex = 5
        Me.txtRadius.TabStop = False
        Me.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtRadius, "The radius, in pixels, of this red circle")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Radius"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbPixels
        '
        Me.pbPixels.Location = New System.Drawing.Point(125, 4)
        Me.pbPixels.Name = "pbPixels"
        Me.pbPixels.Size = New System.Drawing.Size(126, 118)
        Me.pbPixels.TabIndex = 8
        Me.pbPixels.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbPixels, "The shape of the red pixels which the camera sees at this target")
        '
        'txtRange
        '
        Me.txtRange.BackColor = System.Drawing.Color.Black
        Me.txtRange.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRange.ForeColor = System.Drawing.Color.White
        Me.txtRange.Location = New System.Drawing.Point(59, 67)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.ReadOnly = True
        Me.txtRange.Size = New System.Drawing.Size(60, 13)
        Me.txtRange.TabIndex = 10
        Me.txtRange.TabStop = False
        Me.txtRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtRange, "The camera-reported range to this target, averaged over all the red pixels")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Range"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSigma
        '
        Me.txtSigma.BackColor = System.Drawing.Color.Black
        Me.txtSigma.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSigma.ForeColor = System.Drawing.Color.White
        Me.txtSigma.Location = New System.Drawing.Point(59, 88)
        Me.txtSigma.Name = "txtSigma"
        Me.txtSigma.ReadOnly = True
        Me.txtSigma.Size = New System.Drawing.Size(60, 13)
        Me.txtSigma.TabIndex = 12
        Me.txtSigma.TabStop = False
        Me.txtSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtSigma, "The Standard Deviation of the camera's range measurements, averaged over all the " &
        "red pixels in this target")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(17, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Sigma"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSamples
        '
        Me.txtSamples.BackColor = System.Drawing.Color.Black
        Me.txtSamples.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSamples.ForeColor = System.Drawing.Color.White
        Me.txtSamples.Location = New System.Drawing.Point(59, 109)
        Me.txtSamples.Name = "txtSamples"
        Me.txtSamples.ReadOnly = True
        Me.txtSamples.Size = New System.Drawing.Size(60, 13)
        Me.txtSamples.TabIndex = 20
        Me.txtSamples.TabStop = False
        Me.txtSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtSamples, "The number of measurements for this target; the number of frames times the number" &
        " of red pixels")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Samples"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RedCircle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtSamples)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSigma)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRange)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pbPixels)
        Me.Controls.Add(Me.txtRadius)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCol)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Name = "RedCircle"
        Me.Size = New System.Drawing.Size(255, 128)
        CType(Me.pbPixels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCol As TextBox
    Friend WithEvents txtRow As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRadius As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pbPixels As PictureBox
    Friend WithEvents txtRange As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSigma As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSamples As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
