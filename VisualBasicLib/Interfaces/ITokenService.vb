Imports EntityFrameworkLib.Models

Namespace Interfaces
  Public Interface ITokenService
    Function CriarToken(jsonWebToken As JsonWebToken) As String
  End Interface
End Namespace
