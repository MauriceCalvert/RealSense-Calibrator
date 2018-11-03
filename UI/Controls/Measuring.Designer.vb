<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Measuring
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
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblBottom = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.rcBottomLeft = New UI.RedCircle()
        Me.rcTopRight = New UI.RedCircle()
        Me.rcBottomRight = New UI.RedCircle()
        Me.rcMiddle = New UI.RedCircle()
        Me.rcTopLeft = New UI.RedCircle()
        Me.SuspendLayout()
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblTop.Location = New System.Drawing.Point(356, 59)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(0, 13)
        Me.lblTop.TabIndex = 5
        '
        'lblBottom
        '
        Me.lblBottom.AutoSize = True
        Me.lblBottom.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblBottom.Location = New System.Drawing.Point(356, 309)
        Me.lblBottom.Name = "lblBottom"
        Me.lblBottom.Size = New System.Drawing.Size(0, 13)
        Me.lblBottom.TabIndex = 6
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblRight.Location = New System.Drawing.Point(619, 179)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(0, 13)
        Me.lblRight.TabIndex = 7
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblLeft.Location = New System.Drawing.Point(86, 179)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(0, 13)
        Me.lblLeft.TabIndex = 8
        '
        'rcBottomLeft
        '
        Me.rcBottomLeft.BackColor = System.Drawing.Color.Black
        Me.rcBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rcBottomLeft.ForeColor = System.Drawing.Color.White
        Me.rcBottomLeft.Location = New System.Drawing.Point(0, 254)
        Me.rcBottomLeft.Name = "rcBottomLeft"
        Me.rcBottomLeft.Size = New System.Drawing.Size(255, 128)
        Me.rcBottomLeft.TabIndex = 4
        Me.rcBottomLeft.TabStop = False
        Me.rcBottomLeft.Target = Nothing
        '
        'rcTopRight
        '
        Me.rcTopRight.BackColor = System.Drawing.Color.Black
        Me.rcTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rcTopRight.ForeColor = System.Drawing.Color.White
        Me.rcTopRight.Location = New System.Drawing.Point(509, 0)
        Me.rcTopRight.Name = "rcTopRight"
        Me.rcTopRight.Size = New System.Drawing.Size(255, 128)
        Me.rcTopRight.TabIndex = 3
        Me.rcTopRight.TabStop = False
        Me.rcTopRight.Target = Nothing
        '
        'rcBottomRight
        '
        Me.rcBottomRight.BackColor = System.Drawing.Color.Black
        Me.rcBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rcBottomRight.ForeColor = System.Drawing.Color.White
        Me.rcBottomRight.Location = New System.Drawing.Point(509, 254)
        Me.rcBottomRight.Name = "rcBottomRight"
        Me.rcBottomRight.Size = New System.Drawing.Size(255, 128)
        Me.rcBottomRight.TabIndex = 2
        Me.rcBottomRight.TabStop = False
        Me.rcBottomRight.Target = Nothing
        '
        'rcMiddle
        '
        Me.rcMiddle.BackColor = System.Drawing.Color.Black
        Me.rcMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rcMiddle.ForeColor = System.Drawing.Color.White
        Me.rcMiddle.Location = New System.Drawing.Point(254, 127)
        Me.rcMiddle.Name = "rcMiddle"
        Me.rcMiddle.Size = New System.Drawing.Size(255, 128)
        Me.rcMiddle.TabIndex = 1
        Me.rcMiddle.TabStop = False
        Me.rcMiddle.Target = Nothing
        '
        'rcTopLeft
        '
        Me.rcTopLeft.BackColor = System.Drawing.Color.Black
        Me.rcTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rcTopLeft.ForeColor = System.Drawing.Color.White
        Me.rcTopLeft.Location = New System.Drawing.Point(0, 0)
        Me.rcTopLeft.Name = "rcTopLeft"
        Me.rcTopLeft.Size = New System.Drawing.Size(255, 128)
        Me.rcTopLeft.TabIndex = 0
        Me.rcTopLeft.TabStop = False
        Me.rcTopLeft.Target = Nothing
        '
        'Measuring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.lblBottom)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.rcBottomLeft)
        Me.Controls.Add(Me.rcTopRight)
        Me.Controls.Add(Me.rcBottomRight)
        Me.Controls.Add(Me.rcMiddle)
        Me.Controls.Add(Me.rcTopLeft)
        Me.Name = "Measuring"
        Me.Size = New System.Drawing.Size(764, 382)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rcTopLeft As RedCircle
    Friend WithEvents rcMiddle As RedCircle
    Friend WithEvents rcBottomRight As RedCircle
    Friend WithEvents rcTopRight As RedCircle
    Friend WithEvents rcBottomLeft As RedCircle
    Friend WithEvents lblTop As Label
    Friend WithEvents lblBottom As Label
    Friend WithEvents lblRight As Label
    Friend WithEvents lblLeft As Label
End Class
