Imports System.Runtime.InteropServices
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished

<ComVisible(True)>
<ProgId(“GetData.SWTaskPane_SwAddin”)>
Public Class GetData
    Private Sub GetDataButton_Click(sender As Object, e As EventArgs) Handles GetDataButton.Click
        MsgBox(“Success”)
    End Sub
    Friend Sub getSwApp(ByRef swAppIn As SldWorks)
        Dim swApp As SldWorks
        swApp = swAppIn
    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

End Class
