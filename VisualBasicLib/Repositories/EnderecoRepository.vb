Imports System.Collections.ObjectModel
Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Abstracts

Namespace Repositories
  Public Class EnderecoRepository
    Inherits RepositoryAbstract(Of Endereco)

    Public Overrides Sub Insert(entity As Endereco)
      _dbContext.Enderecos.Add(entity)
    End Sub

    Public Overrides Sub Update(entity As Endereco)
      _dbContext.Enderecos.Update(entity)
    End Sub

    Public Overrides Sub Delete(id As Integer)
      Dim endereco As Endereco = _dbContext.Enderecos.Find(id)
      If endereco Is Nothing Then
        Throw New KeyNotFoundException($"A entidade '{NameOf(endereco)}' não foi encontrada com Id '{id}'.")
      Else
        _dbContext.Enderecos.Remove(endereco)
      End If
    End Sub

    Public Overrides Sub Cancel(entity As Endereco)
      _dbContext.Entry(entity).Reload()
    End Sub

    Public Overrides Function GetAll() As ObservableCollection(Of Endereco)
      Return New ObservableCollection(Of Endereco)(_dbContext.Enderecos.ToList().OrderBy(Function(a) a.Id))
    End Function

    Public Overrides Function GetById(id As Integer) As Endereco
      Return _dbContext.Enderecos.Find(id)
    End Function
  End Class
End Namespace

