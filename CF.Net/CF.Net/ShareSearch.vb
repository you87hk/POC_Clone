Option Strict Off
Option Explicit On
Friend Class frmShareSearch
	Inherits System.Windows.Forms.Form

    Dim G As Graphics

	'Dim wrsTbl As rdoResultset
	Dim clmX As System.Windows.Forms.ColumnHeader
	Dim itmX As System.Windows.Forms.ListViewItem
    Dim waScrItm As New System.Data.DataTable
    Private waScrToolTip As New System.Data.DataTable
	
	
	'Criteria variables
	Public sBindSQL As String '-- SQL to bind to the ADO control.
	Public sBindWhereSQL As String
	Public sBindOrderSQL As String
	Private wsWhereSql As String
	
	'List header array
	Public vHeadDataAry As Object '-- Two dimension arary. 1-Field description; 2-Field name.
	'Filter field combo array
	Public vFilterAry As Object '-- Two dimension arary. 1-Field description; 2-Field name.
	'Search field combo array
	Public vSearchAry As Object '-- Two dimension arary. 1-Field description; 2-Field name.
	
	Private wsFormCaption As String
	Private wsFormID As String
	Private wiExit As Boolean
	
	Private Const tcGo As String = "Go"
	Private Const tcRefresh As String = "Refresh"
	Private Const tcCancel As String = "Cancel"
    Private Const tcExit As String = "Exit"
	
	Private Sub cboSearchField_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboSearchField.Enter
        cboSearchField.SelectAll()
	End Sub
	
	Private Sub cboSearchField_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboSearchField.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
			txtOutput.Focus()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cboSearchField_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboSearchField.Leave
        cboSearchField.SelectionLength = 0
	End Sub
	
	'UPGRADE_WARNING: Form event frmShareSearch.Deactivate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmShareSearch_Deactivate(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Deactivate
		
		Me.Close()
	End Sub
	
	Private Sub frmShareSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F2
				lsvContent_DoubleClick(lsvContent, New System.EventArgs())
				
			Case System.Windows.Forms.Keys.F3
				Call cmdCancel()
				
			Case System.Windows.Forms.Keys.F12
				Me.Close()
				
			Case System.Windows.Forms.Keys.F5
				Edt_Lst()
				
			Case System.Windows.Forms.Keys.Escape
                KeyCode = 0 ' System.Windows.Forms.Cursors.Default
				Me.Close()
		End Select
	End Sub
	
	Private Sub frmShareSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		IniForm()
		Ini_Caption()
		Ini_Scr()
		IniCombo()
		
		Cursor = System.Windows.Forms.Cursors.Default
		
		
	End Sub
	
	Private Sub cmdCancel()
		
		
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		Ini_Scr()
		
		Cursor = System.Windows.Forms.Cursors.Default
		
		
	End Sub
	
	Private Sub IniCombo()
		Dim wiCounter As Short
		
		With cboSearchField
			For wiCounter = 1 To UBound(vFilterAry)
				'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Items.Add(vFilterAry(wiCounter, 1))
			Next 
		End With
		
		cboSearchField.SelectedIndex = 0
		
		
	End Sub
	
	Private Sub Ini_Scr()
		
		Dim MyControl As System.Windows.Forms.Control
		
		For	Each MyControl In Me.Controls
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			Select Case TypeName(MyControl)
				'         Case "ComboBox"
				'             MyControl.Clear
				Case "TextBox"
					MyControl.Text = ""
				Case "TDBGrid"
					'UPGRADE_WARNING: Couldn't resolve default property of object MyControl.ClearFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CType(MyControl, C1.Win.C1TrueDBGrid.C1TrueDBGrid).ClearFields()
				Case "Label"
					If UCase(MyControl.Name) Like "LBLDSP*" Then
						MyControl.Text = ""
					End If
				Case "RichTextBox"
					MyControl.Text = ""
				Case "CheckBox"
					'UPGRADE_WARNING: Couldn't resolve default property of object MyControl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CType(MyControl, CheckBox).Checked = 0
			End Select
		Next MyControl
		
		Me.Text = wsFormCaption
		wsWhereSql = ""
		wiExit = False
		
		Call Ini_LstView()
	End Sub
	
	Private Sub frmShareSearch_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		If wiExit = False Then
			'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            'Cancel = True
			wiExit = True
			Me.Hide()
			Exit Sub
		End If
		
		'UPGRADE_NOTE: Object clmX may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		clmX = Nothing
		'UPGRADE_NOTE: Object itmX may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		itmX = Nothing
		'UPGRADE_NOTE: Object waScrItm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		waScrItm = Nothing
		'UPGRADE_NOTE: Object waScrToolTip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		waScrToolTip = Nothing
		'UPGRADE_NOTE: Object frmShareSearch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Me.Close() ' = Nothing
		
		
	End Sub
	
	Private Sub lsvContent_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lsvContent.DoubleClick
		If Not lsvContent.FocusedItem Is Nothing Then
			Me.Tag = lsvContent.FocusedItem.Text
		Else
			gsMsg = "請先選取一項!"
			MsgBox(gsMsg, MsgBoxStyle.OKOnly, gsTitle)
			
			Exit Sub
		End If
		'Me.Hide
		Me.Close()
	End Sub
	
	Private Sub lsvContent_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lsvContent.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
			Call lsvContent_DoubleClick(lsvContent, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Private Sub Edt_Lst()
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim Criteria As String
        Dim inpData As System.Data.DataTable = Nothing
        Dim wsRows As String
        Dim rsSearch As New System.Data.DataTable
        Dim iCounter As Short

        On Error GoTo Edt_Lst_Err

        lsvContent.Enabled = True
        lsvContent.Items.Clear()
        lsvContent.Refresh()

        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Criteria = Criteria & " CusName LIKE '%" & Set_Quote(txtCustomerName.Text) & "%'"

        Criteria = sBindSQL & sBindWhereSQL & wsWhereSql & sBindOrderSQL

        'rsSearch.Open(Criteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)


        dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
        dataAdapt.Fill(rsSearch)

        If rsSearch.Rows.Count = 0 Then
            lsvContent.Enabled = False
            dataAdapt.Dispose()
            rsSearch.Clear()
            'UPGRADE_NOTE: Object rsSearch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsSearch = Nothing
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If Not IsNothing(inpData) Then
            inpData = rsSearch.Copy()
        End If

        Dim rowCount As Integer = 0
        Dim dr As System.Data.DataRow
        For Each dr In inpData.Rows
            itmX = lsvContent.Items.Add(dr.Item(0))
            For iCounter = 1 To rsSearch.Columns.Count() - 1
                If itmX.SubItems.Count > iCounter Then
                    itmX.SubItems(iCounter).Text = IIf(IsDBNull(inpData), "", dr.Item(iCounter))
                Else
                    itmX.SubItems.Insert(iCounter, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(inpData), "", dr.Item(iCounter))))
                End If
            Next
        Next

        'rsSearch.MoveFirst()

        'Do Until rsSearch.EOF
        '    'inpData = rsSearch("CusCode").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object inpData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    inpData = rsSearch.Fields.Item(0).Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object inpData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    itmX = lsvContent.Items.Add(inpData)

        '    'inpData = rsSearch("CusName").Value
        '    For iCounter = 1 To rsSearch.Fields.Count - 1
        '        'UPGRADE_WARNING: Couldn't resolve default property of object inpData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        inpData = rsSearch.Fields.Item(iCounter).Value
        '        'UPGRADE_WARNING: Lower bound of collection itmX has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        '        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '        If itmX.SubItems.Count > iCounter Then
        '            itmX.SubItems(iCounter).Text = IIf(IsDBNull(inpData), "", inpData)
        '        Else
        '            itmX.SubItems.Insert(iCounter, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(inpData), "", inpData)))
        '        End If
        '    Next

        '    rsSearch.MoveNext()
        'Loop

        lsvContent.Focus()

        Cursor = System.Windows.Forms.Cursors.Default

        Exit Sub

Edt_Lst_Err:
        'Dsp_Err "", Err.Description, "E", Me.Caption
        gsMsg = "Err in Edt_Lst_Err!"
        MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
	
	Private Sub Ini_LstView()
		Dim iCounter As Short
		
		lsvContent.Items.Clear()
		lsvContent.Columns.Clear()
		
		With lsvContent
			'UPGRADE_WARNING: Untranslated statement in Ini_LstView. Please check source code.
			clmX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
			
			For iCounter = 2 To UBound(vHeadDataAry)
				'UPGRADE_WARNING: Untranslated statement in Ini_LstView. Please check source code.
				clmX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
			Next 
			
			.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle ' Set BorderStyle property.
			.View = System.Windows.Forms.View.Details ' Set View property to Report.
			'UPGRADE_WARNING: Only TrueType and OpenType fonts are supported in Windows Forms. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="971F4DF4-254E-44F4-861D-3AA0031FE361"'
            .Font = New Font("MS Sans Serif", 8, FontStyle.Regular)
            '.Font = VB6.FontChangeBold(.Font, False)
            '.Font = VB6.FontChangeSize(.Font, 8)
			.ForeColor = System.Drawing.ColorTranslator.FromOle(&HC00000)
            'UPGRADE_ISSUE: MSComctlLib.ListView method lsvContent.DragMode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'DragMode = 0
            .AllowDrop = 0
            'UPGRADE_ISSUE: MSComctlLib.ListView property lsvContent.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '.Sorted = False
            .Sorting = System.Windows.Forms.SortOrder.None
		End With
		lsvContent.Items.Clear()
		lsvContent.Enabled = False
	End Sub
	
	Private Sub lsvContent_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lsvContent.ColumnClick
		Dim columnheader As System.Windows.Forms.ColumnHeader = lsvContent.Columns(eventArgs.Column)
		' When a ColumnHeader object is clicked, the ListView control is
		' sorted by the subitems of that column.
		' Set the SortKey to the Index of the ColumnHeader - 1
		
		'UPGRADE_ISSUE: MSComctlLib.ListView property lsvContent.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'lsvContent.SortKey = columnheader.Index - 1
        lsvContent.ListViewItemSorter = New ListViewItemComparer(columnheader.Index - 1)
        lsvContent.Sorting = 1 - lsvContent.Sorting
		' Set Sorted to True to sort the list.
        lsvContent.Sort()
    End Sub

    Class ListViewItemComparer
        Implements IComparer

        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Function
    End Class
	
	Private Sub IniForm()
		Me.KeyPreview = True

        G = Me.CreateGraphics()
        Me.Left = (((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * G.DpiX / 1024) - (Me.Width * G.DpiX / 1024)) / 2) * G.DpiX / 1024
        Me.Top = (((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * G.DpiY / 1024) - (Me.Height * G.DpiY / 1024)) / 2) * G.DpiY / 1024
        G.Dispose()
		
		wsFormID = "ShareSrch"
	End Sub
	
	Private Sub Ini_Caption()
		Call Get_Scr_Item(wsFormID, waScrItm)
		Call Get_Scr_Item("TOOLTIP", waScrToolTip)
		
		wsFormCaption = Get_Caption(waScrItm, "SCRHDR")
		
		tbrProcess.Items.Item(tcGo).ToolTipText = Get_Caption(waScrToolTip, tcGo) & "(F2)"
		tbrProcess.Items.Item(tcRefresh).ToolTipText = Get_Caption(waScrToolTip, tcRefresh) & "(F5)"
		tbrProcess.Items.Item(tcCancel).ToolTipText = Get_Caption(waScrToolTip, tcCancel) & "(F3)"
		tbrProcess.Items.Item(tcExit).ToolTipText = Get_Caption(waScrToolTip, tcExit) & "(F12)"
		
		
		fraFind.Text = Get_Caption(waScrItm, "FRAFIND")
	End Sub
	
	Private Sub tbrProcess_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbrProcess_Button1.Click, _tbrProcess_Button2.Click, _tbrProcess_Button3.Click, _tbrProcess_Button4.Click, _tbrProcess_Button5.Click, _tbrProcess_Button6.Click, _tbrProcess_Button7.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		Select Case Button.Name
			Case "Go"
				lsvContent_DoubleClick(lsvContent, New System.EventArgs())
				
			Case "Cancel"
				
				Call cmdCancel()
				
			Case "Exit"
				Me.Close()
				
			Case "Refresh"
				Edt_Lst()
				
		End Select
	End Sub
	
	Private Sub txtOutput_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOutput.Enter
        txtOutput.SelectAll()
	End Sub
	
	
	
	Private Sub setCriteria1()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(cboSearchField.ListIndex + 1, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If InStr(1, UCase(sBindWhereSQL), vFilterAry(cboSearchField.SelectedIndex + 1, 2), CompareMethod.Text) <> 0 Then
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(cboSearchField.ListIndex + 1, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If InStr(1, UCase(wsWhereSql), vFilterAry(cboSearchField.SelectedIndex + 1, 2), CompareMethod.Text) <> 0 Then
			wsWhereSql = ""
			lblDspCrt.Text = ""
		End If
		
		If Trim(txtOutput.Text) = "" Then
			Exit Sub
		End If
		
		If InStr(1, UCase(sBindWhereSQL), "WHERE", CompareMethod.Text) <> 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			wsWhereSql = wsWhereSql & " AND " + vFilterAry(cboSearchField.SelectedIndex + 1, 2) & " LIKE '%" & Set_Quote(txtOutput.Text) & "%'"
		Else
			If InStr(1, UCase(wsWhereSql), "WHERE", CompareMethod.Text) <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				wsWhereSql = wsWhereSql & " AND " + vFilterAry(cboSearchField.SelectedIndex + 1, 2) & " LIKE '%" & Set_Quote(txtOutput.Text) & "%'"
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				wsWhereSql = " WHERE " + vFilterAry(cboSearchField.SelectedIndex + 1, 2) & " LIKE '%" & Set_Quote(txtOutput.Text) & "%'"
			End If
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lblDspCrt.Text = lblDspCrt.Text & " " & vFilterAry(cboSearchField.SelectedIndex + 1, 1) & " = " & Set_Quote(txtOutput.Text) & ": "
		
	End Sub
	
	Private Sub txtOutput_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOutput.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
			cboSearchField.Focus()
			setCriteria1()
			Edt_Lst()
			
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtOutput_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOutput.Leave
        txtOutput.SelectionLength = 0
	End Sub
End Class