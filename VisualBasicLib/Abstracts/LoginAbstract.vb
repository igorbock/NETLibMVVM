Imports System.ComponentModel
Imports System.IdentityModel.Tokens.Jwt
Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Interfaces

Namespace Abstracts
  Public MustInherit Class LoginAbstract
    Implements INotifyPropertyChanged
    Private _token As String
    Public Property Token() As String
      Get
        Return _token
      End Get
      Set(value As String)
        _token = value
        OnPropertyChanged(NameOf(Token))
      End Set
    End Property
    Private _user As Usuario
    Public Property User() As Usuario
      Get
        Return _user
      End Get
      Set(value As Usuario)
        _user = value
        OnPropertyChanged(NameOf(User))
      End Set
    End Property
    Private _userName As String
    Public Property UserName() As String
      Get
        Return _userName
      End Get
      Set(value As String)
        _userName = value
        OnPropertyChanged(NameOf(UserName))
      End Set
    End Property
    Private _jwtoken As JwtSecurityToken
    Public Property Jwtoken() As JwtSecurityToken
      Get
        Return _jwtoken
      End Get
      Set(value As JwtSecurityToken)
        _jwtoken = value
        OnPropertyChanged(NameOf(Jwtoken))
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

      User = New Usuario With {.Nome = String.Empty}
      Jwtoken = New JwtSecurityToken
    End Sub
    Public MustOverride Sub SignIn()
    Public MustOverride Sub SignOut()
    Public MustOverride Sub IsAuthenticated()
    Private Sub OnPropertyChanged(propertyName As String)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
  End Class
End Namespace
