Imports System.Windows.Input

Namespace Classes
  Public Class RelayCommand
    Implements ICommand

    Private ReadOnly _execute As Action(Of Object)
    Private ReadOnly _canExecute As Func(Of Object, Boolean)

    Public Sub New(execute As Action(Of Object), Optional canExecute As Func(Of Object, Boolean) = Nothing)
      _execute = execute
      _canExecute = canExecute
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
      _execute(parameter)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
      Return _canExecute Is Nothing OrElse _canExecute(parameter)
    End Function
  End Class
End Namespace
