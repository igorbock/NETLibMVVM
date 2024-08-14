Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Interfaces
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt
Imports VisualBasicLib.Extensions

Namespace Services
  Public Class TokenService
    Implements ITokenService

    Public Function CriarToken(jsonWebToken As JsonWebToken) As String Implements ITokenService.CriarToken
      Dim securityKey As New SymmetricSecurityKey(Text.Encoding.UTF8.GetBytes(jsonWebToken.Key))
      Dim credentials As New SigningCredentials(securityKey, jsonWebToken.Algorithm)

      Dim subject As New Claim With {.Key = Security.Claims.ClaimTypes.NameIdentifier, .Value = jsonWebToken.Subject}
      jsonWebToken.Claims.Add(subject)

      Dim jwt As New JwtSecurityToken(
        issuer:=jsonWebToken.Issuer,
        audience:=jsonWebToken.Audience,
        expires:=jsonWebToken.Expiration,
        claims:=jsonWebToken.Claims.ToSystemSecurityClaimsClaim(),
        signingCredentials:=credentials)

      Dim tokenHandler As New JwtSecurityTokenHandler
      Return tokenHandler.WriteToken(jwt)
    End Function
  End Class
End Namespace
