Imports EntityFrameworkLib.Models
Imports VisualBasicLib.Abstracts
Imports VisualBasicLib.Interfaces
Imports VisualBasicLib.Repositories

Namespace ViewModels
  Public Class EnderecoViewModel
    Inherits TypeTViewModel(Of Endereco)

    Public Sub New(navManager As INavigationManager)
      MyBase.New(New EnderecoRepository, navManager)
    End Sub
  End Class
End Namespace
