Imports System.ComponentModel
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Cryptography
Imports System.Timers
Imports EntityFrameworkLib.Context
Imports EntityFrameworkLib.Models
Imports EntityFrameworkLib.Models.DTOs
Imports VisualBasicLib.Interfaces

Namespace Abstracts
  Public MustInherit Class LoginAbstract
    Implements INotifyPropertyChanged

    Private WithEvents timer As Timer

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
    Private _registroDTO As SignUpDTO
    Public Property RegistroDTO() As SignUpDTO
      Get
        Return _registroDTO
      End Get
      Set(value As SignUpDTO)
        _registroDTO = value
        OnPropertyChanged(NameOf(RegistroDTO))
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
    Private _dbContext As LibDbContext
    Public Property DbContext() As LibDbContext
      Get
        Return _dbContext
      End Get
      Set(value As LibDbContext)
        _dbContext = value
      End Set
    End Property
    Public Sub New(navigation As INavigationManager, context As LibDbContext)
      Me.Navigation = navigation
      DbContext = context

      User = New Usuario With {.Nome = String.Empty}
      Jwtoken = New JwtSecurityToken
      RegistroDTO = New SignUpDTO

      timer = New Timer(10000) With {
        .Enabled = True
      }

      AddHandler timer.Elapsed, AddressOf IsAuthenticated
    End Sub
    Protected Sub StartTimer()
      timer.Start()
    End Sub
    Protected Sub StopTimer()
      timer.Stop()
    End Sub
    Public MustOverride Sub SignIn()
    Public MustOverride Sub SignUp()
    Public MustOverride Sub SignOut()
    Public MustOverride Sub IsAuthenticated()
    Public MustOverride Sub HasUserInDatabase()
    Protected Overridable Function HashPassword(password As String, salt As Byte()) As String
      Dim pbkdf2 As New Rfc2898DeriveBytes(password, salt, 10000)
      Dim hash As Byte() = pbkdf2.GetBytes(32)
      Return Convert.ToBase64String(hash)
    End Function
    Protected Function VerifyPassword(password As String, storedHash As String, salt As Byte()) As Boolean
      Dim inputHash As String = HashPassword(password, salt)
      Return storedHash.Equals(inputHash)
    End Function
    Private Sub OnPropertyChanged(propertyName As String)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
  End Class
End Namespace
