Imports EntityFrameworkLib.Context
Imports EntityFrameworkLib.Models.Academia
Imports VisualBasicLib.Abstracts

Namespace Repositories
  Public Class TreinoRepository
    Inherits RepositoryAbstract(Of Treino)

    Public Sub New(dbContext As LibDbContext)
      MyBase.New(dbContext)
    End Sub

    Public Overrides Sub Insert(entity As Treino)
      _dbContext.Treinos.AddRange(entity)
    End Sub

    Public Overrides Sub Update(entity As Treino)
      _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified
    End Sub

    Public Overrides Sub Delete(id As Integer)
      _dbContext.Treinos.Remove(GetById(id))
    End Sub

    Public Overrides Sub Cancel(entity As Treino)
      _dbContext.Entry(entity).Reload()
    End Sub

    Public Overrides Function GetAll() As ObjectModel.ObservableCollection(Of Treino)
      Return New ObjectModel.ObservableCollection(Of Treino)(_dbContext.Treinos.ToList())
    End Function

    Public Overrides Function GetById(id As Integer) As Treino
      Return _dbContext.Treinos.Find(id)
    End Function
  End Class
End Namespace
