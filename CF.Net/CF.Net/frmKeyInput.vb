Option Strict Off
Option Explicit On
Friend Class frmKeyInput
	Inherits System.Windows.Forms.Form
	
	
	Public ctlKey As System.Windows.Forms.Control
	
	Private wsFormID As String
    Private waScrItm As New System.Data.DataTable
	
	'variable for new property
	Private msTableID As String
	Private msTableType As String
	Private msTableKey As String
	Private msKeyLen As Short
	
	
	
	Property TableID() As String
		Get
			
			TableID = msTableID
			
		End Get
		Set(ByVal Value As String)
			
			msTableID = Value
			
		End Set
	End Property
	
	
	Property TableKey() As String
		Get
			
			TableKey = msTableKey
			
		End Get
		Set(ByVal Value As String)
			
			msTableKey = Value
			
		End Set
	End Property
	
	
	Property TableType() As String
		Get
			
			TableType = msTableType
			
		End Get
		Set(ByVal Value As String)
			
			msTableType = Value
			
		End Set
	End Property
	
	Property KeyLen() As Short
		Get
			
			KeyLen = msKeyLen
			
		End Get
		Set(ByVal Value As Short)
			
			msKeyLen = Value
			
		End Set
	End Property
	
	Private Sub frmKeyInput_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		
		Call Ini_Form()
		Call Ini_Caption()
		
		
		Cursor = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	
	
	Private Sub frmKeyInput_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		If Chk_txtKeyNo() = False Then
			
			'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            'Cancel = True
			Exit Sub
			
		End If
		
		'UPGRADE_NOTE: Object waScrItm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		waScrItm = Nothing
		'UPGRADE_NOTE: Object frmKeyInput may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Me.Close() ' = Nothing
		
	End Sub
	
	Private Sub txtKeyNo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKeyNo.Enter
        txtKeyNo.SelectAll()
	End Sub
	
	Private Sub txtKeyNo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtKeyNo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Call chk_InpLenA(txtKeyNo, KeyLen, KeyAscii, True)
		
		If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
			
			If Chk_txtKeyNo() = False Then GoTo EventExitSub
			
			'UPGRADE_WARNING: Couldn't resolve default property of object ctlKey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctlKey.Text = txtKeyNo.Text
			Me.Close()
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtKeyNo_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKeyNo.Leave
        txtKeyNo.SelectionLength = 0
	End Sub
	
	Private Sub Ini_Form()
		
		Me.KeyPreview = True
		wsFormID = "KeyInput"
		
		
	End Sub
	
	Private Sub Ini_Caption()
		
		On Error GoTo Ini_Caption_Err
		
		Call Get_Scr_Item(wsFormID, waScrItm)
		
		lblKeyNo.Text = Get_Caption(waScrItm, "KeyNo")
		
		Exit Sub
		
Ini_Caption_Err: 
		
		MsgBox("Please Check ini_Caption!")
		
	End Sub
	
	Private Function Chk_txtKeyNo() As Boolean

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
		Dim wsSQL As String
		Dim wsMsg As String
		
		Chk_txtKeyNo = False
		
		If Trim(txtKeyNo.Text) = "" And Chk_AutoGen(TableType) = "N" Then
			wsMsg = "Key No Must Input!"
			MsgBox(wsMsg, MsgBoxStyle.OKOnly, gsTitle)
			txtKeyNo.Focus()
			Exit Function
		End If
		
		wsSQL = "SELECT * FROM " & TableID & " WHERE " & TableKey & " = '" & Set_Quote(txtKeyNo.Text) & "'"
        'rsRcd.Open(wsSQL, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If rsRcd.Rows.Count > 0 Then

            wsMsg = "Key Already Exist!"
            MsgBox(wsMsg, MsgBoxStyle.OkOnly, gsTitle)
            txtKeyNo.Focus()
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function

        End If
        dataAdapt.Dispose()
        rsRcd.Clear()
		'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsRcd = Nothing
		
		
		Chk_txtKeyNo = True
		
	End Function
End Class