Imports System.ComponentModel
Imports System.Text
Imports Calibrator
Imports Intel
Imports Intel.RealSense

Public Class SensorOptions
    Public ReadOnly Property Result As Calibrator.SensorSettings
    Private _MAXHEIGHT As Integer
    Public Sub New(options As Calibrator.SensorSettings, title As String, maxheight As Integer)
        InitializeComponent()
        _Result = options
        _MAXHEIGHT = maxheight
        Me.Text = title
    End Sub
    Private Sub SensorOptions_Load(sender As Object, e As EventArgs) Handles Me.Load

        Const STARTTOP As Integer = 2
        Const STARTLEFT As Integer = 0
        Const HORIZONTALSPACING As Integer = 5
        Const VERTICALSPACING As Integer = 4
        Const TEXTBOXWIDTH As Integer = 70

        Dim optiontype As Type = GetType(RealSense.Option)

        ' Make pretty (space before capitals), sorted list of names
        Dim names As List(Of String) = [Enum].GetNames(optiontype).OrderBy(Function(x) x).ToList

        ' Find the length of the widest option text
        Dim widest As Integer = 0
        Dim lb As New Label
        Using g As Graphics = Me.CreateGraphics
            widest = names.Select(Function(x) Convert.ToInt32(g.MeasureString(x, lb.Font).Width)).Max + 8
        End Using

        Dim nexttop As Integer = STARTTOP ' pixel row of next checkbox
        Dim nextleft As Integer = STARTLEFT ' idem, column 
        Dim topmax As Integer = 0

        For Each name As String In names

            Dim key As RealSense.Option = DirectCast([Enum].Parse(optiontype, name), RealSense.Option)

            lb = New Label
            With lb
                .AutoSize = False
                .Text = Beautify(name)
                .Top = nexttop
                .Left = nextleft
                .Width = widest
                .BackColor = Me.BackColor
                .ForeColor = Me.ForeColor
                .TextAlign = ContentAlignment.MiddleRight
                Controls.Add(lb)
                .Top = nexttop
                .Left = nextleft
            End With

            Dim tb As New TextBox
            With tb
                .Name = name
                .Text = _Result.Where(Function(x) x.Key = key).SingleOrDefault?.Value.ToString
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.Black
                .ForeColor = Me.ForeColor
                .BorderStyle = BorderStyle.None
                .Width = TEXTBOXWIDTH
                Controls.Add(tb)
                .Top = nexttop + (lb.Height - .Height) \ 2 + 1
                .Left = nextleft + widest + HORIZONTALSPACING
                .Tag = key
                Dim ss As SensorSetting = _Result.Find(Function(q) q.Key = key)
                If ss Is Nothing Then
                    ToolTip1.SetToolTip(tb, name)
                Else
                    ToolTip1.SetToolTip(tb, $"{ss.Min}..{ss.Max} Default={ss.DefValue} {ss.Description}")
                End If
            End With
            AddHandler tb.Validating, AddressOf TextboxValidating

            If nexttop > topmax Then
                topmax = nexttop + lb.Height
            End If

            If name <> names.Last Then
                nexttop = nexttop + tb.Height + VERTICALSPACING
                If nexttop > _MAXHEIGHT Then
                    nexttop = STARTTOP
                    nextleft = nextleft + widest + TEXTBOXWIDTH + HORIZONTALSPACING
                End If
            End If
        Next
        btnSave.Top = topmax + VERTICALSPACING + lb.Height
        btnSave.Left = 2 * HORIZONTALSPACING
        Me.Height = (Me.Height - Me.ClientSize.Height) + btnSave.Top + btnSave.Height + VERTICALSPACING
        Me.Width = (Me.Width - Me.ClientSize.Width) + nextleft + widest + TEXTBOXWIDTH + 3 * HORIZONTALSPACING
        btnCancel.Top = btnSave.Top
        btnCancel.Left = Me.ClientSize.Width - btnCancel.Width - 2 * HORIZONTALSPACING
        btnDefaults.Top = btnSave.Top
        btnDefaults.Left = (btnCancel.Left - btnSave.Left) \ 2
    End Sub
    Private Function Beautify(s As String) As String
        Dim result As New StringBuilder(s.Length * 2)
        For Each ch As String In s
            If result.Length > 0 Then
                If "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ch) >= 0 Then
                    result.Append(" ")
                End If
            End If
            result.Append(ch)
        Next
        Return result.ToString
    End Function
    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnDefaults.Click
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            Dim ss As SensorSetting = CurrentSetting(tb.Name)
            tb.Text = ss?.DefValue.ToString
        Next
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)

            If String.IsNullOrWhiteSpace(tb.Text) Then

                Dim ss As SensorSetting = CurrentSetting(tb.Name)
                If ss IsNot Nothing Then
                    _Result.Update(DirectCast(tb.Tag, RealSense.Option), ss.DefValue)
                End If
            Else
                _Result.Update(DirectCast(tb.Tag, RealSense.Option), Convert.ToSingle(tb.Text))
            End If
        Next
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub RemoveHandlers()
        ' Cleanliness is next to Godliness
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            RemoveHandler tb.Validating, AddressOf TextboxValidating
        Next
    End Sub
    Private Sub TextboxValidating(sender As Object, e As CancelEventArgs)

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim text As String = tb.Text
        If String.IsNullOrWhiteSpace(text) Then
            Exit Sub
        End If

        Dim value As Single = 0
        If Not Single.TryParse(text, value) Then
            MsgBox($"'{text}' is not a valid floating-point number")
            e.Cancel = True
        End If

        Dim ss As SensorSetting = CurrentSetting(tb.Name)
        If ss IsNot Nothing Then
            If Not Between(value, ss.Min, ss.Max) Then
                MsgBox($"{value} must be between {ss.Min} and {ss.Max}")
            End If
        End If

    End Sub
    Private Function CurrentSetting(name As String) As SensorSetting
        Return _Result.Find(Function(q) [Enum].GetName(GetType([Option]), q.Key) = name)
    End Function
End Class