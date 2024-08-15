Imports EntityFrameworkLib.Models

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
    Public MustOverride Sub Login(usuario As Usuario)
  End Class
End Namespace
