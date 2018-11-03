Public Class MenuRenderer
    Inherits ToolStripProfessionalRenderer

    Public Sub New()
        MyBase.New(New DarkRenderer)
    End Sub

    Private Class DarkRenderer
        Inherits ProfessionalColorTable
        Public Overrides ReadOnly Property MenuStripGradientBegin As Color
            Get
                Return Color.FromArgb(255, 32, 32, 32)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuStripGradientEnd As Color
            Get
                Return Color.FromArgb(255, 32, 32, 32)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuBorder As Color
            Get
                Return Color.FromArgb(255, 64, 64, 64)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemBorder As Color ' hover border
            Get
                Return Color.FromArgb(255, 128, 128, 128)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelected As Color ' submenu hover
            Get
                Return Color.FromArgb(255, 32, 32, 32)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
            Get
                Return Color.FromArgb(255, 32, 32, 32)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
            Get
                Return Color.FromArgb(255, 32, 32, 32)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
            Get
                Return Color.Black
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
            Get
                Return Color.Black
            End Get
        End Property
    End Class
End Class
