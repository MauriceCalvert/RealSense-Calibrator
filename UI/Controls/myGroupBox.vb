Imports System
Imports System.Drawing
Imports System.Windows.Forms
' https://stackoverflow.com/a/51663475/338101
Partial Public Class MyGroupBox
    Inherits GroupBox

    Private _borderColor As Color = Color.FromArgb(255, 64, 64, 64)
    Private _borderWidth As Single = 1.8
    Private _borderRadius As Integer = 5
    Private _textIndent As Integer = 15

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddHandler Me.Paint, AddressOf Me.BorderedGroupBox_Paint
        ForeColor = Color.White
    End Sub

    Public Sub New(ByVal width As Integer, ByVal radius As Single, ByVal color As Color)
        MyBase.New()
        Me._borderWidth = Math.Max(1, width)
        Me._borderColor = color
        Me._borderRadius = CInt(Math.Max(0, radius))
        InitializeComponent()
        AddHandler Me.Paint, AddressOf Me.BorderedGroupBox_Paint
    End Sub

    Public Property BorderColor As Color
        Get
            Return Me._borderColor
        End Get
        Set(ByVal value As Color)
            Me._borderColor = value
            DrawGroupBox()
        End Set
    End Property

    Public Property BorderWidth As Single
        Get
            Return Me._borderWidth
        End Get
        Set(ByVal value As Single)

            If value > 0 Then
                Me._borderWidth = Math.Min(value, 10)
                DrawGroupBox()
            End If
        End Set
    End Property

    Public Property BorderRadius As Integer
        Get
            Return Me._borderRadius
        End Get
        Set(ByVal value As Integer)

            If value >= 0 Then
                Me._borderRadius = value
                Me.DrawGroupBox()
            End If
        End Set
    End Property

    Public Property LabelIndent As Integer
        Get
            Return Me._textIndent
        End Get
        Set(ByVal value As Integer)
            Me._textIndent = value
            Me.DrawGroupBox()
        End Set
    End Property

    Private Sub BorderedGroupBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        DrawGroupBox(e.Graphics)
    End Sub

    Private Sub DrawGroupBox()
        DrawGroupBox(Me.CreateGraphics())
    End Sub

    Private Sub DrawGroupBox(ByVal g As Graphics)
        Dim textBrush As Brush = New SolidBrush(Me.ForeColor)
        Dim strSize As SizeF = g.MeasureString(Me.Text, Me.Font)
        Dim borderBrush As Brush = New SolidBrush(Me.BorderColor)
        Dim borderPen As Pen = New Pen(borderBrush, Me._borderWidth)
        Dim rect As Rectangle = New Rectangle(Me.ClientRectangle.X,
                                              Me.ClientRectangle.Y + CInt((strSize.Height / 2)),
                                              CInt(Me.ClientRectangle.Width - BorderWidth - 2),
                                              Me.ClientRectangle.Height - CInt((strSize.Height / 2)) - 1)
        Dim labelBrush As Brush = New SolidBrush(Me.BackColor)
        g.Clear(Me.BackColor)
        Dim rectX As Integer = CInt(If((0 = Me._borderWidth Mod 2), rect.X + Me._borderWidth / 2, rect.X + 1 + Me._borderWidth / 2))
        Dim rectHeight As Integer = CInt(If((0 = Me._borderWidth Mod 2), rect.Height - Me._borderWidth / 2, rect.Height - 1 - Me._borderWidth / 2))
        g.DrawRoundedRectangle(borderPen, rectX, rect.Y, rect.Width, rectHeight, Me._borderRadius)

        If Me.Text.Length > 0 Then
            Dim posX As Integer, width As Integer = CInt(rect.Width)
            posX = If((Me._textIndent < 0), Math.Max(0 - width, Me._textIndent), Math.Min(width, Me._textIndent))
            posX = If((posX < 0), rect.Width + posX - CInt(strSize.Width), posX)
            g.FillRectangle(labelBrush, posX, 0, strSize.Width, strSize.Height)
            g.DrawString(Me.Text, Me.Font, textBrush, posX, 0)
        End If
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private components As System.ComponentModel.IContainer = Nothing
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub
End Class
