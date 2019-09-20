Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports System.Windows
Imports System.Windows.Media.Media3D ' in presentationcore.dll
Imports NLog

''' <summary>
''' Represents our piece of wood with 5 targets at a certain distance from the camera.
''' </summary>
<DataContract>
Public Class Row

    Private _Targets As List(Of Target)
    Private _Decorations As List(Of Decoration)
    Private _Logger As Logger
    Private Function AddDecoration(decoration As Decoration) As Decoration
        Decorations.Add(decoration)
        Return decoration
    End Function
    Private Sub CompleteCircle(target As Target, picture As FastPixel, startcol As Integer, startrow As Integer)

        Logger.Trace("Complete {0} circle from {1},{2}", target.Name, startcol, startrow)

        ImproveCircle(target, picture, startcol, startrow)

        Logger.Trace("Completed {0} circle at {1:#,##0.000},{2:#,##0.000}", target.Name, target.Col, target.Row)

        AddDecoration(New DecorationText(target.Col, target.Row, target.Name, New Font("Sans Serif", 8), Color.LightSkyBlue))
    End Sub
    Private ReadOnly Property Decorations As List(Of Decoration)
        Get
            If _Decorations Is Nothing Then
                _Decorations = New List(Of Decoration)
            End If
            Return _Decorations
        End Get
    End Property
    Friend Function Decorate(picture As Bitmap) As Bitmap
        Dim result As Bitmap = DirectCast(picture.Clone, Bitmap)
        For Each d As Decoration In Decorations.OrderBy(Function(q) q.Priority)
            d.Draw(result)
        Next
        Return result
    End Function
    ''' <summary>
    ''' Find the 5 targets on the plane by looking for red pixels and then improving the red circles.
    ''' We find the middle circle first and then the corners by moving at a diagonal proportional to the widht/height ratio of the target.
    ''' </summary>
    ''' <param name="colour">The colour bitmap, picture of the plane we are examining</param>
    ''' <returns>True if all 5 targets were found</returns>
    Friend Function FindTargets(colour As Bitmap) As Boolean

        Logger.Trace("Finding cricles")

        Dim picture As New FastPixel(DirectCast(colour.Clone, Bitmap), True)
        Dim start As New Point(picture.Width \ 2, picture.Height - 1)
        Dim finish As New Point(picture.Width \ 2, 0)
        Dim failed As Decoration = AddDecoration(New DecorationLine(start, finish, 3, Color.Red))

        Dim success As Boolean = False
        _Decorations = New List(Of Decoration)
        _Targets = New List(Of Target)
        Dim n As Integer = 0
        Dim redness As Integer = 0
        Dim line As IEnumerable(Of Point) = Bresenham(start, finish)


        Do
            ' Find the next non-red pixel on the line
            Dim outside As Point = line(n)
            Do While Not Not IsRed(picture, outside, redness)
                n += 1
                outside = line(n)
                If n >= line.Count Then
                    Return success
                End If
            Loop

            ' Find the first red pixel in the circle we're loooking for
            Dim first As Point = line(n)
            Do
                n += 1
                first = line(n)
                If n >= line.Count Then
                    Return success
                End If
            Loop Until IsRed(picture, first, redness)

            ' Find the last red pixel in the circle we're loooking for
            Dim last As Point = line(n)
            Do
                n += 1
                last = line(n)
                If n >= line.Count Then
                    Logger.Error("Unfinished circle")
                    Return False
                End If
            Loop Until Not IsRed(picture, last, redness)

            success = True
            Decorations.Remove(failed)
            Dim col As Double = (first.X + last.X) / 2
            Dim row As Double = (first.Y + last.Y) / 2
            IsRed(picture, col.ToInt, row.ToInt, redness)
            Dim target As New Target(Targets.Count.ToString, Nothing)
            target.Add(col, row, redness)
            ' and flesh out the circle from the mid-point
            CompleteCircle(target, picture, col.ToInt, row.ToInt)

            If target.Height < 5 Then
                Return success
            End If

            Targets.Add(target)
            Logger.Trace("Found target at {0},{1}", col, row)
        Loop

        picture.Unlock()
        Return success
    End Function
    Private Sub ImproveCircle(target As Target, picture As FastPixel, startcol As Integer, startrow As Integer)

        Decorations.Remove(target.Circle)

        Dim queue As New Queue(Of RowCol)
        Dim seen As New Dictionary(Of RowCol, Boolean)
        Dim start As New RowCol(startrow, startcol)
        queue.Enqueue(start)
        seen(start) = True
        Dim redness As Integer = 0

        Do While queue.Any

            Dim here As RowCol = queue.Dequeue

            If IsRed(picture, here.Col, here.Row, redness) Then

                target.Add(here.Col, here.Row, redness)

                For r As Integer = -1 To 1
                    For c As Integer = -1 To 1
                        If (r = 0) Xor (c = 0) Then
                            Dim rr As Integer = here.Row + r
                            Dim cc As Integer = here.Col + c
                            If InBounds(picture, New Point(cc, rr)) Then
                                Dim added As New RowCol(rr, cc)
                                If Not seen.ContainsKey(added) AndAlso IsRed(picture, cc, rr, redness) Then
                                    seen(added) = True
                                    queue.Enqueue(added)
                                End If
                            End If
                        End If
                    Next
                Next
            End If

        Loop

        target.Circle = AddDecoration(New DecorationCircle(target.Centre, target.Width, target.Height, 1, Color.LightSkyBlue))
    End Sub
    ''' <summary>
    ''' Once the targets have been found, try to find further red pixels.
    ''' This is necessary due to noise in the colour images.
    ''' </summary>
    ''' <param name="colour">The colour bitmap, picture of the plane we are examining</param>
    ''' <param name="depthmap">The corresponding depthmap to be updated</param>
    Friend Sub ImproveTargets(colour As Bitmap, depthmap As DepthMap)

        Dim picture As New FastPixel(colour, True)
        For Each target As Target In Targets
            ImproveCircle(target, picture, target.Col.ToInt, target.Row.ToInt)
            target.Update(depthmap)
        Next
        picture.Unlock()

    End Sub
    Private Function IsRed(picture As FastPixel, a As Point, ByRef redness As Integer) As Boolean
        Return IsRed(picture, a.X.ToInt, a.Y.ToInt, redness)
    End Function
    Private Function IsRed(picture As FastPixel, col As Integer, row As Integer, ByRef redness As Integer) As Boolean

        If Not InBounds(picture, New Point(col, row)) Then
            Return False
        End If

        Dim pixel As Color = Normalise(picture.GetPixel(col, row))

        Dim hsv As New HSV(pixel)

        If Between(hsv.Hue, 30 / 360, 330 / 360) Then
            Return False ' not red enough
        End If

        If hsv.Saturation < 60 / 100 Then
            Return False ' not deep enough
        End If

        If hsv.Value < 30 / 100 Then
            Return False ' too dark
        End If

        redness = Convert.ToInt32((hsv.Saturation + hsv.Value) * 127) ' two of them so 0..255
        Return True

    End Function
    Public ReadOnly Property Logger As Logger
        Get
            If _Logger Is Nothing Then
                _Logger = LogManager.GetCurrentClassLogger
            End If
            Return _Logger
        End Get
    End Property
    Private Function InBounds(picture As FastPixel, col As Integer, row As Integer) As Boolean
        Return col >= 0 AndAlso col < picture.Width AndAlso row >= 0 AndAlso row < picture.Height
    End Function
    Private Function InBounds(picture As FastPixel, p As Point) As Boolean
        Return InBounds(picture, p.X.ToInt, p.Y.ToInt)
    End Function
    ''' <summary>
    ''' Update the Z statistics of the red pixels of all 5 targets on this plane
    ''' </summary>
    ''' <param name="depthmap">The depthmap with the statistics to be updated</param>
    Friend Sub Measure(depthmap As DepthMap)
        For Each target As Target In Targets
            target.Update(depthmap)
        Next
    End Sub
    ''' <summary>
    ''' We are currently in the process of measuring and improving the depthmap
    ''' </summary>
    ''' <returns></returns>
    Friend Property Measuring As Boolean
    ''' <summary>
    ''' Set all the statistics back to zero
    ''' </summary>
    Friend Sub Reset()
        Targets = New List(Of Target)
    End Sub
    ''' <summary>
    ''' The total number of measurements made for all 5 targets on this plane
    ''' </summary>
    Public ReadOnly Property Samples As Integer
        Get
            Return Targets.Sum(Function(q) q.Samples)
        End Get
    End Property
    ''' <summary>
    ''' The standard deviation of all the measurements made for all 5 targets on this plane
    ''' </summary>
    Public ReadOnly Property Sigma As Double
        Get
            Return Math.Sqrt(Targets.Sum(Function(q) q.Variance) / Targets.Count)
        End Get
    End Property
    <DataMember>
    Friend Property Targets As List(Of Target)
        Get
            Return _Targets
        End Get
        Private Set(value As List(Of Target))
            _Targets = value
        End Set
    End Property
End Class
