Imports EntityFrameworkLib.Models
Imports EntityFrameworkLib.Models.DTOs

Namespace Extensions
  Public Module PessoaExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function ToPessoa(ByVal dto As PessoaDTO) As Pessoa
      Return New Pessoa With {
        .CPF = dto.CPF,
        .Id = dto.Id,
        .IdEndereco = dto.IdEndereco,
        .Nascimento = dto.Nascimento,
        .Nome = dto.Nome,
        .RG = dto.RG
      }
    End Function
  End Module
End Namespace
