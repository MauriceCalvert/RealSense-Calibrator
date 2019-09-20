''' <summary>
''' Depthmap with facilities to access by row and column
''' </summary>
Public Class DepthMap

    Public ReadOnly Data As UShort()

    Public ReadOnly Property Height As Integer
    Public ReadOnly Property Width As Integer

    Public Sub New(width As Integer, height As Integer)
        _Width = width
        _Height = height
        ReDim Data(width * height - 1)
    End Sub
    Default Public ReadOnly Property Item(x As Integer, y As Integer) As Integer
        Get
            Debug.Assert(Between(x, 0, Width - 1))
            Debug.Assert(Between(y, 0, Height - 1))
            Return Data(y * Width + x)
        End Get
    End Property
End Class
