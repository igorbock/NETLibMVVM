Imports System.ComponentModel
Imports VisualBasicLib.Abstracts
Imports VisualBasicLib.Interfaces

Namespace ViewModels
  Public Class HomeViewModel
    Implements INotifyPropertyChanged

    Private ReadOnly Property _navigator As INavigationManager
    Private ReadOnly Property _login As LoginAbstract

    Private Property _usuario As String
    Public Property Usuario As String
      Get
        Return _usuario
      End Get
      Set(value As String)
        _usuario = $"Usuário | {value}"
        OnPropertyChanged(NameOf(Usuario))
      End Set
    End Property
    Private Property _expiraEm As Date
    Public Property ExpiraEm As Date
      Get
        Return _expiraEm
      End Get
      Set(value As Date)
        _expiraEm = value
        OnPropertyChanged(NameOf(ExpiraEm))
      End Set
    End Property

    Public Sub New(navigator As INavigationManager, login As LoginAbstract)
      _navigator = navigator
      _login = login
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(propertyName As String)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
  End Class
End Namespace
