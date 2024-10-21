Namespace Interfaces
  Public Interface INavigationManager
    Sub ShowDialog(pageName As String)
    Sub ShowPage(pageName As String)
    Sub ClosePage()
    Sub ClosePage(pageName As String)
    Sub CloseAllPages()
    Function GetOpenedOrCreatePage(pageName As String) As Object
  End Interface
End Namespace
