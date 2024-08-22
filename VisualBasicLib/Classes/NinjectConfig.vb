Imports Ninject
Imports VisualBasicLib.Classes

Public Module NinjectConfig
  Public Function CreateKernel() As IKernel
    Dim kernel As IKernel = New StandardKernel()
    Dim dependencies As New NinjectDI()
    dependencies.OnLoad(kernel)
    Return kernel
  End Function
End Module
