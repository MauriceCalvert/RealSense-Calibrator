Imports System.Math
''' <summary>
''' Represents a camera; either a real camera or a synthetic camera whose intrinsics we are trying to find
''' </summary>
Public Class VCamera

    Private _Name As String ' e.g. "D435"
    Private _Cols As Integer ' Horizontal number of pixels
    Private _HFov As Double ' Horizontal field of view
    Private _HPixel As Double ' The width of a pixel, in 'units'
    Private _HSize As Double ' Horizontal aspect ratio; the number of units across at 1 unit away from the camera
    Private _Rows As Integer ' Vertical number of pixels
    Private _VFov As Double ' Vertical field of view
    Private _VPixel As Double ' The height of a pixel, in 'units'
    Private _VSize As Double ' Vertical aspect ratio; the number of units up/down at 1 unit away from the camera
    Private _Synthetic As Boolean ' This is a synthetic camera; its intrinsics can be modified

    ''' <summary>
    ''' Create a new real camera
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="Width">Horizontal number of pixels</param>
    ''' <param name="Height">Vertical number of pixels</param>
    ''' <param name="hfov">Horizontal field of view</param>
    ''' <param name="vfov">Vertical field of view</param>
    Public Sub New(name As String, Width As Integer, Height As Integer, hfov As Double, vfov As Double)
        _Name = name
        _Cols = Width
        _Rows = Height
        _HFov = hfov
        _VFov = vfov
        _Synthetic = False
    End Sub
    ''' <summary>
    ''' Create a synthetic camera from an existing camera
    ''' </summary>
    ''' <param name="model">The existing camera</param>
    Public Sub New(model As VCamera)
        With model
            _Name = $"{ .Name}{Unique():00}"
            _Cols = .Width
            _Rows = .Height
            _HFov = .HFov
            _VFov = .VFov
        End With
        _Synthetic = False
    End Sub
    ''' <summary>
    ''' Horizontal number of pixels
    ''' </summary>
    Public ReadOnly Property Width As Integer
        Get
            Return _Cols
        End Get
    End Property
    ''' <summary>
    ''' Horizontal field of view
    ''' </summary>
    Public ReadOnly Property HFov As Double
        Get
            Return _HFov
        End Get
    End Property
    ''' <summary>
    ''' The width of a pixel, in 'units'.
    ''' There are 99 intervals between 100 pixels, thus the '-1'
    ''' </summary>
    Public ReadOnly Property HPixel As Double
        Get
            Return HSize / (Width - 1)
        End Get
    End Property
    ''' <summary>
    ''' Horizontal aspect ratio; the number of units across at 1 unit away from the camera
    ''' </summary>
    Public ReadOnly Property HSize As Double
        Get
            Return Tan(HFov / 2) * 2
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    ''' <summary>
    ''' Vertical number of pixels
    ''' </summary>
    Public ReadOnly Property Height As Integer
        Get
            Return _Cols
        End Get
    End Property
    Public Sub SetFOV(newhfov As Double, newvfov As Double)
        If Not _Synthetic Then
            Throw New Exception($"{Name} is a real camera, it's FOV cannot be changed")
        End If
        _HFov = newhfov
        _VFov = newvfov
    End Sub
    ''' <summary>
    ''' Vertical field of view
    ''' </summary>
    Public ReadOnly Property VFov As Double
        Get
            Return _VFov
        End Get
    End Property
    ''' <summary>
    ''' The height of a pixel, in 'units'
    ''' There are 99 intervals between 100 pixels, thus the '-1'
    ''' </summary>
    Public ReadOnly Property VPixel As Double
        Get
            Return VSize / (Height - 1)
        End Get
    End Property
    ''' <summary>
    ''' Vertical aspect ratio; the number of units up/down at 1 unit away from the camera
    ''' </summary>
    Public ReadOnly Property VSize As Double
        Get
            Return Tan(VFov / 2) * 2
        End Get
    End Property

End Class
