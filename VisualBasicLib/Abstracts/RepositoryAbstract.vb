Imports System.Collections.ObjectModel
Imports EntityFrameworkLib.Context
Imports Microsoft.EntityFrameworkCore.Storage

Namespace Abstracts
  Public MustInherit Class RepositoryAbstract(Of TypeT)
    Protected ReadOnly Property _dbContext As LibDbContext
    Private Property _transaction As IDbContextTransaction

    Public Sub New(dbContext As LibDbContext)
      _dbContext = dbContext
    End Sub

    Protected Overrides Sub Finalize()
      If _transaction IsNot Nothing Then _transaction.Dispose()
    End Sub

    Public MustOverride Sub Insert(entity As TypeT)
    Public MustOverride Sub Update(entity As TypeT)
    Public MustOverride Sub Delete(id As Integer)
    Public MustOverride Sub Cancel(entity As TypeT)
    Public MustOverride Function GetAll() As ObservableCollection(Of TypeT)
    Public MustOverride Function GetById(id As Integer) As TypeT
    Public Overridable Sub Begin()
      _transaction = _dbContext.Database.BeginTransaction()
    End Sub
    Public Overridable Sub Commit()
      _transaction.Commit()
    End Sub
    Public Overridable Sub Rollback()
      _transaction.Rollback()
    End Sub
    Public Overridable Sub Save()
      _dbContext.SaveChanges()
    End Sub
  End Class
End Namespace
