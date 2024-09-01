Imports EntityFrameworkLib.Context
Imports EntityFrameworkLib.Models.Academia
Imports VisualBasicLib.Abstracts

Namespace Repositories
  Public Class ExercicioRepository
    Inherits RepositoryAbstract(Of Exercicio)

    Public Sub New(dbContext As LibDbContext)
      MyBase.New(dbContext)
    End Sub

    Public Overrides Sub Insert(entity As Exercicio)
      _dbContext.Exercicios.Add(entity)
    End Sub

    Public Overrides Sub Update(entity As Exercicio)
      _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified
    End Sub

    Public Overrides Sub Delete(id As Integer)
      _dbContext.Exercicios.Remove(GetById(id))
    End Sub

    Public Overrides Sub Cancel(entity As Exercicio)
      _dbContext.Entry(entity).Reload()
    End Sub

    Public Overrides Function GetAll() As ObjectModel.ObservableCollection(Of Exercicio)
      Return New ObjectModel.ObservableCollection(Of Exercicio)(_dbContext.Exercicios.ToList())
    End Function

    Public Overrides Function GetById(id As Integer) As Exercicio
      Return _dbContext.Exercicios.Find(id)
    End Function
  End Class
End Namespace
