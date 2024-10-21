Namespace Extensions
  Public Module StringExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function ToFormName(formName As String) As String
      Dim typeName As String = formName.
        Replace("ç", "c").
        Replace("Ç", "C").
        Replace("ã", "a").
        Replace("Ã", "A").
        Replace("í", "i").
        Replace("Í", "I")

      Return $"frm{typeName}"
    End Function
  End Module
End Namespace
