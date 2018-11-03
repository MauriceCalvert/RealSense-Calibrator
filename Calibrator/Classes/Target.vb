Imports System.Runtime.Serialization
Imports System.Windows
Imports System.Windows.Media.Media3D ' in presentationcore.dll
Imports System.Math
Imports NLog
Imports System.Collections.Concurrent
''' <summary>
''' Where this tartget is on the plane.
''' This is (and has to be) thread-safe, we update in parallel.
''' </summary>
Public Enum Position
    TopLeft
    TopRight
    Middle
    BottomLeft
    BottomRight
End Enum
''' <summary>
''' Represents a circle of red pixels
''' </summary>
<DataContract>
Public Class Target

    Public Event Changed(sender As Target)
    Friend Property Circle As Decoration
    Friend Property Line As Decoration

    Private _Name As String
    Private _Logger As Logger
    Private _Truth As Point3D
    Private _Pixel As ConcurrentDictionary(Of Long, RedPixel)
    Public Sub New() ' for serialisation
    End Sub
    Friend Sub New(name As String, truth As Point3D)
        _Name = name
        _Truth = truth
    End Sub
    Friend Function Add(col As Double, row As Double, redness As Integer) As Boolean
        Return Add(col.ToInt, row.ToInt, redness)
    End Function
    Friend Function Add(col As Integer, row As Integer, redness As Integer) As Boolean
        Dim key As Long = RedPixel.GetKey(col, row)
        Dim existing As RedPixel = Nothing
        If Pixel.TryGetValue(key, existing) Then
            If redness > existing.Redness Then
                existing.Redness = redness
            Else
                Return True ' no change
            End If
        Else
            Pixel.TryAdd(key, New RedPixel(row, col, redness))
        End If
        RaiseEvent Changed(Me)
        Return True
    End Function
    Friend ReadOnly Property Bounds As RectangleF
        Get
            If Not Pixels.Any Then
                Return New RectangleF(0, 0, 1, 1)
            End If
            Dim xmin As Single = Single.MaxValue
            Dim xmax As Single = Single.MinValue
            Dim ymin As Single = Single.MaxValue
            Dim ymax As Single = Single.MinValue
            For Each p As RedPixel In Pixels
                If p.Col < xmin Then xmin = p.Col
                If p.Col > xmax Then xmax = p.Col
                If p.Row < ymin Then ymin = p.Row
                If p.Row > ymax Then ymax = p.Row
            Next
            Return New RectangleF(xmin, ymin, xmax - xmin + 1, ymax - ymin + 1)
        End Get
    End Property
    Public ReadOnly Property Bitmap As Bitmap
        Get
            Dim pix As List(Of RedPixel) = Pixels.ToList ' Pixels get added on other threads
            With IntegerRectangle(Bounds)
                Dim result As New Bitmap(.Width + 2, .Height + 2)
                Dim fp As New FastPixel(result, True)
                For Each p As RedPixel In pix
                    fp.SetPixel(p.Col - .X + 1, p.Row - .Y + 1, Color.FromArgb(255, p.Redness, 0, 0))
                Next
                fp.Unlock()
                Return result
            End With
        End Get
    End Property
    Public ReadOnly Property Col As Double
        Get
            If Pixels.Any Then
                Return Pixels.Average(Function(q) q.Col)
            Else
                Return 0
            End If
        End Get
    End Property
    Friend ReadOnly Property Centre As Point
        Get
            If Pixels.Any Then
                Return New Point(Col, Row)
            Else
                Return New Point(0, 0)
            End If
        End Get
    End Property
    Friend Sub Clear()
        For Each rp As RedPixel In Pixels
            rp.Clear()
        Next
        RaiseEvent Changed(Me)
    End Sub
    Public ReadOnly Property Logger As Logger
        Get
            If _Logger Is Nothing Then
                _Logger = LogManager.GetCurrentClassLogger
            End If
            Return _Logger
        End Get
    End Property
    Public ReadOnly Property MeanZ As Double
        Get
            If Pixels.Any Then
                Dim result As Double = Pixels.Average(Function(q) q.Z)
                Return result
            Else
                Return 0
            End If
        End Get
    End Property
    <DataMember>
    Friend Property Name As String
        Get
            Return _Name
        End Get
        Private Set(value As String)
            _Name = value
        End Set
    End Property
    <DataMember>
    Private Property Pixel As ConcurrentDictionary(Of Long, RedPixel)
        Get
            If _Pixel Is Nothing Then
                _Pixel = New ConcurrentDictionary(Of Long, RedPixel)
            End If
            Return _Pixel
        End Get
        Set(value As ConcurrentDictionary(Of Long, RedPixel))
            _Pixel = value
            RaiseEvent Changed(Me)
        End Set
    End Property
    Friend ReadOnly Property Pixels As IEnumerable(Of RedPixel)
        Get
            Return Pixel.Values
        End Get
    End Property
    Public ReadOnly Property Radius As Double
        Get
            Dim b As RectangleF = Bounds
            Return (b.Width + b.Height) / 4
        End Get
    End Property
    Friend Sub Reset()
        Pixel = New ConcurrentDictionary(Of Long, RedPixel)
        RaiseEvent Changed(Me)
    End Sub
    Public ReadOnly Property Row As Double
        Get
            If Pixels.Any Then
                Return Pixels.Average(Function(q) q.Row)
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property Samples As Integer
        Get
            Return Pixels.Sum(Function(q) q.Samples)
        End Get
    End Property
    Public ReadOnly Property Sigma As Double
        Get
            If Pixels.Any Then
                ' https://stats.stackexchange.com/questions/25848/how-to-sum-a-standard-deviation
                Dim result As Double = Sqrt(Pixels.Sum(Function(q) q.Variance) / Pixels.Count)
                Return result
            Else
                Return 0
            End If
        End Get
    End Property
    <DataMember>
    Friend Property Truth As Point3D
        Get
            Return _Truth
        End Get
        Private Set(value As Point3D)
            _Truth = value
        End Set
    End Property
    Friend Sub Update(depthmap As DepthMap)
        For Each rp As RedPixel In Pixels
            Dim d As Integer = depthmap(rp.Col, rp.Row)
            If Between(d, 1, 65535) Then
                rp.Update(d)
            End If
        Next
        RaiseEvent Changed(Me)
    End Sub
    Friend ReadOnly Property Z As Double
        Get
            If Pixels.Any Then
                Return Pixels.Average(Function(q) q.Z)
            Else
                Return 0
            End If
        End Get
    End Property
    Friend ReadOnly Property Variance As Double
        Get
            If Pixels.Any Then
                Return Pixels.Average(Function(q) q.Variance)
            Else
                Return 0
            End If
        End Get
    End Property
End Class
