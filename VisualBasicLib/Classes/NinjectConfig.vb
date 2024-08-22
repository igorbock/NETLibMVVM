Imports Ninject
Imports Ninject.Modules
Imports Ninject.Planning.Bindings

Public Module NinjectConfig
  Private Property _dependencies As NinjectModule()
  Public Function CreateKernel(modules As NinjectModule()) As IKernel
    Dim kernel As IKernel = New StandardKernel()
    _dependencies = modules
    For Each md As NinjectModule In _dependencies
      md.OnLoad(kernel)
    Next
    Return kernel
  End Function
  Public Function GetBinds() As ICollection(Of IBinding)
    Dim collection As New List(Of IBinding)
    For Each md As NinjectModule In _dependencies
      collection.AddRange(md.Bindings)
    Next
    Return collection
  End Function
End Module
