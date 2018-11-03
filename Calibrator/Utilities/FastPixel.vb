Imports System.Windows
' https://www.codeproject.com/Articles/15192/FastPixel-A-much-faster-alternative-to-Bitmap-SetP
''' <summary>
''' Hack to quickly access individual pixels of a bitmap
''' </summary>
Public Class FastPixel
    Private _rgbvalues() As Byte
    Private _bmtdata As Imaging.BitmapData
    Private _bmpptr As IntPtr
    Private _locked As Boolean = False

    Private _isAlpha As Boolean = False
    Private _bitmap As Bitmap
    Private _width As Integer
    Private _height As Integer
    Public ReadOnly Property Width() As Integer
        Get
            Return _width
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return _height
        End Get
    End Property
    Public ReadOnly Property IsAlphaBitmap() As Boolean
        Get
            Return _isAlpha
        End Get
    End Property
    Public ReadOnly Property Bitmap() As Bitmap
        Get
            Return _bitmap
        End Get
    End Property
    Public Sub New(bitmap As Bitmap, locked As Boolean)
        Init(bitmap)
        If locked Then
            Lock()
        End If
    End Sub
    Public Sub New(bitmap As Bitmap)
        Init(bitmap)
    End Sub
    Private Sub Init(bitmap As Bitmap)
        If (bitmap.PixelFormat = (bitmap.PixelFormat Or Imaging.PixelFormat.Indexed)) Then
            Throw New Exception("Cannot lock an Indexed image.")
            Return
        End If
        _bitmap = bitmap
        ' _isalpha = (_bitmap.PixelFormat = (_bitmap.PixelFormat Or Imaging.PixelFormat.Alpha)) ' WRONG
        _isAlpha = Image.GetPixelFormatSize(_bitmap.PixelFormat) = 32
        _width = bitmap.Width
        _height = bitmap.Height
    End Sub
    Public Sub Lock()
        If _locked Then
            Throw New Exception("Bitmap already locked.")
            Return
        End If

        Dim rect As New Rectangle(0, 0, Width, Height)
        _bmtdata = _bitmap.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, _bitmap.PixelFormat)
        _bmpptr = _bmtdata.Scan0

        If IsAlphaBitmap Then
            Dim bytes As Integer = (Width * Height) * 4
            ReDim _rgbvalues(bytes - 1)
            System.Runtime.InteropServices.Marshal.Copy(_bmpptr, _rgbvalues, 0, _rgbvalues.Length)
        Else
            Dim bytes As Integer = (Width * Height) * 3
            ReDim _rgbvalues(bytes - 1)
            System.Runtime.InteropServices.Marshal.Copy(_bmpptr, _rgbvalues, 0, _rgbvalues.Length)
        End If

        _locked = True
    End Sub
    Public Sub Unlock()
        If Not _locked Then
            Throw New Exception("Bitmap not locked.")
            Return
        End If
        ' Copy the RGB values back to the bitmap
        System.Runtime.InteropServices.Marshal.Copy(_rgbvalues, 0, _bmpptr, _rgbvalues.Length)
        ' Unlock the bits.
        _bitmap.UnlockBits(_bmtdata)
        _locked = False
    End Sub

    Public Sub Clear(colour As Color)
        If Not _locked Then
            Throw New Exception("Bitmap not locked.")
            Return
        End If

        If IsAlphaBitmap Then
            For index As Integer = 0 To _rgbvalues.Length - 1 Step 4
                _rgbvalues(index) = colour.B
                _rgbvalues(index + 1) = colour.G
                _rgbvalues(index + 2) = colour.R
                _rgbvalues(index + 3) = colour.A
            Next index
        Else
            For index As Integer = 0 To _rgbvalues.Length - 1 Step 3
                _rgbvalues(index) = colour.B
                _rgbvalues(index + 1) = colour.G
                _rgbvalues(index + 2) = colour.R
            Next index
        End If
    End Sub
    Public Sub SetPixel(location As Point, colour As Color)
        SetPixel(location.X.ToInt, location.Y.ToInt, colour)
    End Sub
    Public Sub SetPixel(x As Integer, y As Integer, colour As Color)
        If Not _locked Then
            Throw New Exception("Bitmap not locked.")
            Return
        End If

        If IsAlphaBitmap Then
            Dim index As Integer = ((y * Width + x) * 4)
            _rgbvalues(index) = colour.B
            _rgbvalues(index + 1) = colour.G
            _rgbvalues(index + 2) = colour.R
            _rgbvalues(index + 3) = colour.A
        Else
            Dim index As Integer = ((y * Width + x) * 3)
            _rgbvalues(index) = colour.B
            _rgbvalues(index + 1) = colour.G
            _rgbvalues(index + 2) = colour.R
        End If
    End Sub
    Public Function GetPixel(location As Point) As Color
        Return GetPixel(location.X.ToInt, location.Y.ToInt)
    End Function
    Public Function GetPixel(x As Integer, y As Integer) As Color
        If Not _locked Then
            Throw New Exception("Bitmap not locked.")
            Return Nothing
        End If

        If IsAlphaBitmap Then
            Dim index As Integer = ((y * Width + x) * 4)
            Dim b As Integer = _rgbvalues(index)
            Dim g As Integer = _rgbvalues(index + 1)
            Dim r As Integer = _rgbvalues(index + 2)
            Dim a As Integer = _rgbvalues(index + 3)
            Return Color.FromArgb(a, r, g, b)
        Else
            Dim index As Integer = ((y * Width + x) * 3)
            Dim b As Integer = _rgbvalues(index)
            Dim g As Integer = _rgbvalues(index + 1)
            Dim r As Integer = _rgbvalues(index + 2)
            Return Color.FromArgb(r, g, b)
        End If
    End Function
End Class