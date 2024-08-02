Imports System.Collections.ObjectModel
Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Abstracts

Namespace Repositories
  Public Class PessoaRepository
    Inherits RepositoryAbstract(Of Pessoa)

    Public Overrides Sub Insert(entity As Pessoa)
      _dbContext.Pessoas.Add(entity)
    End Sub

    Public Overrides Sub Update(entity As Pessoa)
      _dbContext.Pessoas.Update(entity)
    End Sub

    Public Overrides Sub Delete(id As Integer)
      Dim pessoa As Pessoa = _dbContext.Pessoas.Find(id)
      If pessoa Is Nothing Then
        Throw New KeyNotFoundException($"A entidade '{NameOf(pessoa)}' não foi encontrada com Id '{id}'.")
      Else
        _dbContext.Pessoas.Remove(pessoa)
      End If
    End Sub

    Public Overrides Sub Cancel(entity As Pessoa)
      _dbContext.Entry(entity).Reload()
    End Sub

    Public Overrides Function GetAll() As ObservableCollection(Of Pessoa)
      Return New ObservableCollection(Of Pessoa)(_dbContext.Pessoas.ToList().OrderBy(Function(a) a.Id))
    End Function

    Public Overrides Function GetById(id As Integer) As Pessoa
      Return _dbContext.Pessoas.Find(id)
    End Function
  End Class
End Namespace
