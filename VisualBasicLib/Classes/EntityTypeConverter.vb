Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports EntityFrameworkLib.Interfaces

Namespace Classes

  Public Class EntityTypeConverter
    Inherits TypeConverter

    Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection
      Dim modelAssembly As Assembly
      Dim modelTypes As New List(Of Type)
      Try
        modelAssembly = Assembly.GetAssembly(GetType(IEntity))
        modelTypes = modelAssembly.GetTypes() _
            .Where(Function(t) t.IsClass AndAlso Not t.IsAbstract AndAlso t.IsSubclassOf(GetType(IEntity))).ToList()
      Catch ex As Reflection.ReflectionTypeLoadException
        Dim loaderExceptions = ex.LoaderExceptions
        For Each innerEx As Exception In loaderExceptions
          System.IO.File.WriteAllText("D:\Erro.txt", $"{innerEx.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}O Assembly foi:{modelAssembly.FullName}")
          'Console.WriteLine(innerEx.Message) ' Ou logue em algum lugar
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
