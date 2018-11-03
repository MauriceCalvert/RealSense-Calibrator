Imports System.Threading.Tasks
Imports System.Windows.Media.Media3D
Imports NLoptNet
Partial Public Class Model

    Enum Variable
        Deviation
        Inclination
        HFoV
        VFoV
        QuadraticA
        QuadraticB
        QuadraticC
    End Enum
    ''' <summary>
    ''' Using the values of a model, determine the optimal values for the 7 variables.
    ''' Logs Info messages once a second to report progress.
    ''' 
    ''' This uses the brilliant NLOpt https://nlopt.readthedocs.io/en/latest/ package.
    ''' I tried all the optimisers; they all produced correct results but Nelder-Mead was an order of magniture
    ''' faster than the others.
    ''' 
    ''' </summary>
    ''' <param name="callback">A "Sub(model as Model)" that is called when the optimisation has finished.</param>
    Friend Sub Optimise(callback As Action(Of Model))
        Task.Run(Sub() Optimise1(callback))
    End Sub
    Private Sub Optimise1(callback As Action(Of Model))

        Dim iterations As Integer = 0
        Dim varcount As Integer = [Enum].GetNames(GetType(Variable)).Count
        Dim lower(varcount - 1) As Double
        Dim upper(varcount - 1) As Double

        lower(Variable.Deviation) = -5 * TORADIANS
        lower(Variable.Inclination) = -5 * TORADIANS
        lower(Variable.HFoV) = HFov - HFov * 0.03
        lower(Variable.VFoV) = VFov - VFov * 0.03
        lower(Variable.QuadraticA) = -0.001
        lower(Variable.QuadraticB) = -0.1
        lower(Variable.QuadraticC) = -50

        upper(Variable.Deviation) = 5 * TORADIANS
        upper(Variable.Inclination) = 5 * TORADIANS
        upper(Variable.HFoV) = HFov + HFov * 0.03
        upper(Variable.VFoV) = VFov + VFov * 0.03
        upper(Variable.QuadraticA) = 0.001
        upper(Variable.QuadraticB) = 0.1
        upper(Variable.QuadraticC) = 50

        Dim clock As New Clock(1000) ' show progress regularly

        Using solver As New NLoptSolver(NLoptAlgorithm.LN_NELDERMEAD, CUInt(varcount), Double.Epsilon, 10_000)

            solver.SetLowerBounds(lower)
            solver.SetUpperBounds(upper)

            solver.SetMinObjective(Function(variables)
                                       _Deviation = variables(Variable.Deviation)
                                       _Inclination = variables(Variable.Inclination)
                                       _HFov = variables(Variable.HFoV)
                                       _VFov = variables(Variable.VFoV)
                                       _QuadraticA = variables(Variable.QuadraticA)
                                       _QuadraticB = variables(Variable.QuadraticB)
                                       _QuadraticC = variables(Variable.QuadraticC)
                                       Dim answer As Double = TotalErrorSquared
                                       iterations += 1
                                       If clock.Expired Then
                                           _Logger.Info("After {0:#,##0} iterations average error is {1}",
                                                        iterations, AverageError)
                                       End If
                                       Return answer
                                   End Function)

            Dim finalScore? As Double
            Dim initialValue As Double() = {0, 0, HFov, VFov, 0, 0, 0}

            Dim result As NloptResult = solver.Optimize(initialValue, finalScore)

            _Logger.Info("Solver completed, {0}. {1} iterations average error {2:##0.0} total error {3:##0.0}",
                         [Enum].GetName(GetType(NloptResult), result),
                         iterations,
                         AverageError,
                         Math.Sqrt(TotalErrorSquared))

            If Math.Round(QuadraticA, 6) <= lower(Variable.QuadraticA) OrElse Math.Round(QuadraticA, 6) >= upper(Variable.QuadraticA) OrElse
                Math.Round(QuadraticB, 6) <= lower(Variable.QuadraticB) OrElse Math.Round(QuadraticB, 6) >= upper(Variable.QuadraticB) OrElse
                Math.Round(QuadraticC, 6) <= lower(Variable.QuadraticC) OrElse Math.Round(QuadraticC, 6) >= upper(Variable.QuadraticC) Then
                _QuadraticA = 0
                _QuadraticB = 0
                _QuadraticC = 0
                _Logger.Warn("Quadratic terms cannot be determined. Make more measurements!")
            End If
        End Using
        callback(Me)
    End Sub

End Class
