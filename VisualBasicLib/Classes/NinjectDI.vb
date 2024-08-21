Imports EntityFrameworkLib.Context
Imports EntityFrameworkLib.Models
Imports Ninject
Imports Ninject.Modules
Imports VisualBasicLib.Abstracts
Imports VisualBasicLib.Repositories
Imports VisualBasicLib.ViewModels

Namespace Classes
  Public Class NinjectDI
    Inherits NinjectModule

    Private Property _kernel As IKernel

    Public Sub New()
      _kernel = New StandardKernel()
    End Sub

    Public Overrides Sub Load()
      Bind(Of LibDbContext).ToSelf()
      Bind(Of RepositoryAbstract(Of Pessoa)).To(Of PessoaRepository)()
      Bind(Of RepositoryAbstract(Of Endereco)).To(Of EnderecoRepository)()
      Bind(Of TypeTViewModel(Of Pessoa)).To(Of PessoaViewModel)()
      Bind(Of TypeTViewModel(Of Endereco)).To(Of EnderecoViewModel)()
    End Sub
  End Class
End Namespace