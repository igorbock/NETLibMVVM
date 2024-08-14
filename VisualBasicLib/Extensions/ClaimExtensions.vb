Imports System.Collections.ObjectModel

Namespace Extensions
  Public Module ClaimExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function ToSystemSecurityClaimsClaim(claims As ObservableCollection(Of EntityFrameworkLib.Models.Claim))
      Dim returnValue As New ObservableCollection(Of Security.Claims.Claim)
      For Each claim In claims
        returnValue.Add(New Security.Claims.Claim(claim.Key, claim.Value))
      Next

      Return returnValue
    End Function
  End Module
End Namespace
