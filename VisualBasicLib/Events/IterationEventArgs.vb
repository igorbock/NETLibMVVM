Namespace Events
  Public Class IterationEventArgs
    Inherits EventArgs

    Public Property Message As String
    Public Property Iteration As Boolean?

    Public Sub New(msg As String)
      Message = msg
      Iteration = Nothing
    End Sub
  End Class
End Namespace
