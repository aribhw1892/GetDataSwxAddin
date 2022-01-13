Imports System.Runtime.InteropServices
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished


<Guid("ECE6BAEE-B111-4314-B6E9-3367C41E4C07")>
<ComVisible(True)>
<SwAddin(
        Description:="GetData2017VS description",
        Title:="GetData",
        LoadAtStartup:=True
        )>
Public Class SwAddin
    Implements SolidWorks.Interop.swpublished.SwAddin

#Region "Local Variables"
    Dim WithEvents iSwApp As SldWorks
    Dim iCmdMgr As ICommandManager
    Dim addinID As Integer
    Dim openDocs As Hashtable
    Dim swTaskPane As TaskpaneView
    Dim taskPaneHost As GetData

    Public Const mainCmdGroupID As Integer = 0
    Public Const mainItemID1 As Integer = 0
    Public Const mainItemID2 As Integer = 1
    Public Const flyoutGroupID As Integer = 91

    ' Public Properties
    ReadOnly Property SwApp() As SldWorks
        Get
            Return iSwApp
        End Get
    End Property


    ReadOnly Property OpenDocumentsTable() As Hashtable
        Get
            Return openDocs
        End Get
    End Property
#End Region

#Region "ISwAddin Implementation"

    Function ConnectToSW(ByVal ThisSW As Object, ByVal Cookie As Integer) As Boolean Implements ISwAddin.ConnectToSW
        iSwApp = ThisSW
        addinID = Cookie
        AddTaskPane()
        ConnectToSW = True
    End Function

    Function DisconnectFromSW() As Boolean Implements ISwAddin.DisconnectFromSW
        RemoveTaskPane()
        iSwApp = Nothing

        'The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        DisconnectFromSW = True

    End Function
#End Region
    Public Sub AddTaskPane()
        'TestCommit
        Dim bitmap As String
        bitmap = "GetData.png"
        swTaskPane = SwApp.CreateTaskpaneView2(bitmap, "Get Data")
        taskPaneHost = swTaskPane.AddControl("GetData.SWTaskPane_SwAddin", "")
        taskPaneHost.getSwApp(SwApp)
    End Sub

    Public Sub RemoveTaskPane()
        Try
            taskPaneHost = Nothing
            swTaskPane.DeleteView()
            Marshal.ReleaseComObject(taskPaneHost)
            taskPaneHost = Nothing
        Catch ex As Exception

        End Try
    End Sub
#Region "Event Methods"
    Sub AttachEventsToAllDocuments()
        Dim modDoc As ModelDoc2
        modDoc = iSwApp.GetFirstDocument()
        While Not modDoc Is Nothing
            If Not openDocs.Contains(modDoc) Then
                AttachModelDocEventHandler(modDoc)
            End If
            modDoc = modDoc.GetNext()
        End While
    End Sub

    Function AttachModelDocEventHandler(ByVal modDoc As ModelDoc2) As Boolean
        If modDoc Is Nothing Then
            Return False
        End If
        Dim docHandler As DocumentEventHandler = Nothing

        If Not openDocs.Contains(modDoc) Then
            Select Case modDoc.GetType
                Case swDocumentTypes_e.swDocPART
                    docHandler = New PartEventHandler()
                Case swDocumentTypes_e.swDocASSEMBLY
                    docHandler = New AssemblyEventHandler()
                Case swDocumentTypes_e.swDocDRAWING
                    docHandler = New DrawingEventHandler()
            End Select

            docHandler.Init(iSwApp, Me, modDoc)
            docHandler.AttachEventHandlers()
            openDocs.Add(modDoc, docHandler)
        End If
    End Function

    Sub DetachModelEventHandler(ByVal modDoc As ModelDoc2)
        Dim docHandler As DocumentEventHandler
        docHandler = openDocs.Item(modDoc)
        openDocs.Remove(modDoc)
        modDoc = Nothing
        docHandler = Nothing
    End Sub
#End Region
#Region "UI Callbacks"
    Function PMPEnable() As Integer
        If iSwApp.ActiveDoc Is Nothing Then
            PMPEnable = 0
        Else
            PMPEnable = 1
        End If
    End Function
#End Region

End Class

