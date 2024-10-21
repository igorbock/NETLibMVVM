Imports System.ComponentModel
Imports EntityFrameworkLib.Interfaces

Namespace Classes

  Public Class EntityTypeConverter
    Inherits TypeConverter

    Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection
      Dim modelTypes As New List(Of Type)
      Try
        Dim interfaceType As Type = GetType(IEntity)
        modelTypes = AppDomain.CurrentDomain.GetAssemblies() _
          .SelectMany(Function(a) a.GetTypes()) _
          .Where(Function(a) interfaceType.IsAssignableFrom(a) AndAlso a.IsClass).ToList()
      Catch ex As Reflection.ReflectionTypeLoadException
        Dim loaderExceptions = ex.LoaderExceptions
        For Each innerEx As Exception In loaderExceptions
          IO.File.WriteAllText("D:\Erro.txt", $"{innerEx.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}")
        Next
      End Try

      Return New StandardValuesCollection(modelTypes)
    End Function
    Public Overrides Function GetStandardValuesSupported(context As ITypeDescriptorContext) As Boolean
      Return True
    End Function

    Public Overrides Function GetStandardValuesExclusive(context As ITypeDescriptorContext) As Boolean
      Return True
    End Function
  End Class
End Namespace
