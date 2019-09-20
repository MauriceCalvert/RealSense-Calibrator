Imports System.Threading.Tasks
Imports System.Windows.Media.Media3D
Imports NLog
Imports NLoptNet

Public Class Floor
    Private Logger As Logger = LogManager.GetCurrentClassLogger
    Private Property Pixel As Dictionary(Of Long, RedPixel) = Nothing
    Private Property Model As Model
    Private Property Iterations As Integer
    Private Property Clock As Clock
    Private Property AverageY As Double
    Public Sub New(model As Model)
        _Model = model
    End Sub
    Public Sub Measure(depthmap As DepthMap)
        If Pixel Is Nothing Then
            Pixel = New Dictionary(Of Long, RedPixel)
        End If
        Dim col As Integer = depthmap.Width \ 2
        For r As Integer = 0 To depthmap.Height - 1
            Dim d As Integer = depthmap(col, r)
            If Between(d, Model.Planes.Min(Function(x) x.Truth).ToInt, Model.Planes.Max(Function(x) x.Truth).ToInt) Then
                Dim key As Long = RedPixel.GetKey(depthmap.Width \ 2, r)
                Dim rp As RedPixel = Nothing
                If Not Pixel.TryGetValue(key, rp) Then
                    rp = New RedPixel(r, col, 1)
                    Pixel.Add(key, rp)
                End If
                rp.Update(d)
            End If
        Next
    End Sub
    ''' <summary>
    ''' Find the floor angle
    ''' </summary>
    ''' <param name="callback"></param>
    Public Sub Optimise(callback As Action(Of Model))
        Task.Run(Sub() Optimise1(callback))
    End Sub
    Private Sub Optimise1(callback As Action(Of Model))

        Dim varcount As Integer = 1
        Dim lower(varcount - 1) As Double
        Dim upper(varcount - 1) As Double
        Dim oldinclination As Double = Model.Inclination
        lower(0) = -20 * TORADIANS
        upper(0) = -8 * TORADIANS

        Iterations = 0
        Clock = New Clock(1000) ' show progress regularly

        Using solver As New NLoptSolver(NLoptAlgorithm.LN_NELDERMEAD, CUInt(varcount), Double.Epsilon, 10_000)

            solver.SetLowerBounds(lower)
            solver.SetUpperBounds(upper)
            solver.SetMinObjective(AddressOf FloorMin)
            Dim finalScore? As Double
            Dim initialValue As Double() = {(lower(0) + upper(0)) / 2}
            Dim result As NloptResult = solver.Optimize(initialValue, finalScore)
            Dim final As Double = If(finalScore, 0)
            For Each rp As RedPixel In Pixel.Values
                Dim p As Point3D = rp.Point(Model)
                Debug.WriteLine($"{rp.Row} {rp.Col} {p.X} {p.Y} {p.Z}")
            Next
            Model.FloorAngle = Model.Inclination
            Model.Inclination = oldinclination
            Logger.Info("Floor completed, {0}. {1} iterations angle {2} {3}° height {4} score {5}",
                         [Enum].GetName(GetType(NloptResult), result),
                         Iterations,
                         Model.FloorAngle,
                         Model.FloorAngle * TODEGREES,
                         AverageY,
                         Math.Sqrt(final))
            Model.FloorHeight = AverageY
        End Using
        callback(Model)
    End Sub
    Private Function FloorMin(variables() As Double) As Double

        Model.Inclination = variables(0)
        Dim id As Double = Model.Inclination * TODEGREES

        AverageY = Pixel.Values.Average(Function(q) q.Point(Model).Y)
        Dim miny As Double = Pixel.Values.Min(Function(q) q.Point(Model).Y)
        Dim maxy As Double = Pixel.Values.Max(Function(q) q.Point(Model).Y)

        Dim answer As Double = Pixel.Values.Sum(Function(q)
                                                    Dim y As Double = q.Point(Model).Y
                                                    Return (y - averagey) * (y - averagey)
                                                End Function)
        iterations += 1
        'If Clock.Expired Then
        Logger.Info("After {0:#,##0} iterations angle {1} height {2} error is {3}",
                     Iterations,
                     Model.Inclination * TODEGREES,
                     AverageY,
                     Math.Sqrt(answer))
        'End If
        Return answer
    End Function
End Class
