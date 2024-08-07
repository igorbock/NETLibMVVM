Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports EntityFrameworkLib.Models
Imports EntityFrameworkLib.Models.DTOs
Imports VisualBasicLib.Abstracts
Imports VisualBasicLib.Classes
Imports VisualBasicLib.Interfaces
Imports VisualBasicLib.Repositories

Namespace ViewModels
  Public Class PessoaViewModel
    Inherits TypeTViewModel(Of Pessoa)

    Private ReadOnly Property _enderecoRepository As RepositoryAbstract(Of Endereco)

    Public Sub New(navManager As INavigationManager)
      MyBase.New(New PessoaRepository(), navManager)

      _enderecoRepository = New EnderecoRepository()
    End Sub

    Public Property Nome() As String
      Get
        Return CurrentItem.Nome
      End Get
      Set(value As String)
        CurrentItem.Nome = value
        OnPropertyChanged(NameOf(Nome))
      End Set
    End Property
    Public Property CPF() As String
      Get
        Return CurrentItem.CPF
      End Get
      Set(value As String)
        CurrentItem.CPF = value
        OnPropertyChanged(NameOf(CPF))
      End Set
    End Property
    Public Property RG() As String
      Get
        Return CurrentItem.RG
      End Get
      Set(value As String)
        CurrentItem.RG = value
        OnPropertyChanged(NameOf(RG))
      End Set
    End Property
    Public Property Nascimento() As Date
      Get
        Return CurrentItem.Nascimento
      End Get
      Set(value As Date)
        CurrentItem.Nascimento = value
        OnPropertyChanged(NameOf(Nascimento))
      End Set
    End Property
    Public Property Endereco As Integer?
      Get
        Return CurrentItem.IdEndereco
      End Get
      Set(value As Integer?)
        CurrentItem.IdEndereco = value
        OnPropertyChanged(NameOf(Endereco))
      End Set
    End Property
    Private _enderecos As ObservableCollection(Of Endereco)
    Public Property Enderecos() As ObservableCollection(Of Endereco)
      Get
        Return _enderecos
      End Get
      Set(value As ObservableCollection(Of Endereco))
        _enderecos = value
        OnPropertyChanged(NameOf(Enderecos))
      End Set
    End Property
    Private Property _pessoas As ObservableCollection(Of PessoaDTO)
    Public Property Pessoas As ObservableCollection(Of PessoaDTO)
      Get
        Return _pessoas
      End Get
      Set(value As ObservableCollection(Of PessoaDTO))
        _pessoas = value
        OnPropertyChanged(NameOf(Pessoas))
      End Set
    End Property
    Private Sub AddEndereco()
      _navigationManager.ShowPage("frmEndereco")
      Load()
    End Sub
    Private Sub Load()
      Try
        Enderecos = _enderecoRepository.GetAll
        Pessoas = New ObservableCollection(Of PessoaDTO)((From p As Pessoa In _typeTRepository.GetAll()
                                                          Join e As Endereco In _enderecoRepository.GetAll() On e.Id Equals p.IdEndereco
                                                          Select New PessoaDTO With {
                                                            .Id = p.Id,
                                                            .CPF = p.CPF,
                                                            .Endereco = e.EnderecoCompleto,
                                                            .IdEndereco = e.Id,
                                                            .Nascimento = p.Nascimento,
                                                            .Nome = p.Nome,
                                                            .RG = p.RG
                                                            }).ToList())
      Catch ex As Exception
        OnErrorOcurred(ex)
      End Try
    End Sub
    Public ReadOnly Property AddEnderecoCommand As ICommand
      Get
        Return New RelayCommand(Sub() AddEndereco())
      End Get
    End Property
    Public ReadOnly Property LoadCommand As ICommand
      Get
        Return New RelayCommand(Sub() Load())
      End Get
    End Property
  End Class
End Namespace
