Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Interfaces

Namespace Abstracts
  Public MustInherit Class LoginAbstract
    Private _token As String
    Public Property Token() As String
      Get
        Return _token
      End Get
      Set(value As String)
        _token = value
      End Set
    End Property
    Private _user As Usuario
    Public Property User() As Usuario
      Get
        Return _user
      End Get
      Set(value As Usuario)
        _user = value
      End Set
    End Property
    Private _navigation As INavigationManager
    Public Property Navigation() As INavigationManager
      Get
        Return _navigation
      End Get
      Set(value As INavigationManager)
        _navigation = value
      End Set
    End Property
    Public Sub New(navigation As INavigationManager)
      _navigation = navigation

      User = New Usuario
    End Sub
    Public MustOverride Sub SignIn()
    Public MustOverride Sub IsAuthenticated()
  End Class
End Namespace
