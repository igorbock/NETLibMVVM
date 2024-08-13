Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Abstracts
Imports VisualBasicLib.Interfaces

Namespace ViewModels
  Public Class EnderecoViewModel
    Inherits TypeTViewModel(Of Endereco)

    Public Sub New(repository As RepositoryAbstract(Of Endereco), navManager As INavigationManager)
      MyBase.New(repository, navManager)
    End Sub
  End Class
End Namespace
