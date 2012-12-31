Option Strict Off
Option Explicit On

Public Class frmLogin

    Private wsINIFile As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sBuffer As String
        Dim lSize As Integer
        'Dim wiCtr As Integer

        sBuffer = Space(255)
        lSize = Len(sBuffer)
        Call GetUserName(sBuffer, lSize)
        If lSize > 0 Then
            txtUserID.Text = sBuffer.PadLeft(lSize)
        Else
            txtUserID.Text = vbNullString
        End If

        Call Ini_Scr()

        Call GetCompanyList()
        Call GetLanugaeList()
    End Sub

    Private Sub Ini_Scr()

        Me.Text = "Log In"
        cmdOK.Text = "OK"
        cmdCancel.Text = "Cancel"

    End Sub

    Private Sub GetCompanyList()

        Dim sBuffer As String
        Dim lSize As Integer
        Dim SystemPath As String
        Dim CompanyEntries As String = ""

        On Error GoTo Err_GetCompanyList

        SystemPath = My.Application.Info.DirectoryPath

        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Dir(SystemPath & "\COMPANY.LST") = "" Then
            MsgBox("My.Resources.str113")
            End
        Else
            FileOpen(1, SystemPath & "\COMPANY.LST", OpenMode.Input)
            cboCompany.Items.Clear()
            Do While Not EOF(1)
                Input(1, CompanyEntries)
                If InStr(1, CompanyEntries, ";") > 0 Then
                    cboCompany.Items.Add(CompanyEntries.Remove(InStr(1, CompanyEntries, ";") - 1))
                End If
            Loop
            FileClose(1)
            cboCompany.SelectedIndex = 0
        End If

        Exit Sub

Err_GetCompanyList:

        gsMsg = "找不到公司清單!"
        MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

    End Sub

    Private Sub GetLanugaeList()

        Dim sBuffer As String
        Dim lSize As Integer
        Dim SystemPath As String
        Dim LangEntries As String = ""

        On Error GoTo Err_GetLanugaeList

        SystemPath = My.Application.Info.DirectoryPath

        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Dir(SystemPath & "\LANG.LST") = "" Then
            MsgBox("My.Resources.str113")
            End
        Else
            FileOpen(1, SystemPath & "\LANG.LST", OpenMode.Input)
            cboLangID.Items.Clear()
            Do While Not EOF(1)
                Input(1, LangEntries)
                If InStr(1, LangEntries, ";") > 0 Then
                    cboLangID.Items.Add(LangEntries.Remove(InStr(1, LangEntries, ";") - 1))
                End If
            Loop
            FileClose(1)
            cboLangID.SelectedIndex = 0
        End If

        Exit Sub

Err_GetLanugaeList:

        gsMsg = "找不到語種清單!"
        MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

    End Sub

    Private Sub cboLangID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLangID.Enter
        cboLangID.SelectAll()
    End Sub

    Private Sub cboCompany_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCompany.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            txtUserID.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboLangID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboLangID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            cmdOK.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboLangID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLangID.Leave
        cboLangID.SelectionLength = 0
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        'To Do - create test for correct password
        'check for correct password

        Dim Chk_Login_Result As Short

        Dim wiIndex As Short

        If cboCompany.SelectedIndex = -1 Then
            For wiIndex = 0 To cboCompany.Items.Count - 1
                If Trim(UCase(cboCompany.Text)) = UCase(cboCompany.Items(wiIndex).Text) Then
                    cboCompany.SelectedIndex = wiIndex
                    Exit For
                End If
            Next
        End If

        Call Get_Selected_INI((cboCompany.SelectedIndex))

        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Dir(wsINIFile) = "" Or Trim(wsINIFile) = "" Then
            MsgBox("Can't Find ini File!")
            End
        Else
            Call Read_Debug_Ini(wsINIFile)
        End If

        If cboLangID.SelectedIndex = -1 Then
            For wiIndex = 0 To cboLangID.Items.Count - 1
                If Trim(UCase(cboLangID.Text)) = UCase(cboLangID.Items(wiIndex).text) Then
                    cboLangID.SelectedIndex = wiIndex
                    Exit For
                End If
            Next
        End If

        Call Get_Selected_Lang((cboLangID.SelectedIndex))

        If Connect_Database() = False Then End

        Chk_Login_Result = Chk_Login((txtUserID.Text), (txtPassword.Text))

        Select Case Chk_Login_Result
            'Case 0
            '    Me.Hide()
            Case 1
                gsMsg = "沒有此用戶!"
                MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                txtUserID.Focus()
                GoTo Login_Err
            Case 2
                gsMsg = "密碼錯誤!"
                MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                txtPassword.Focus()
                GoTo Login_Err
        End Select

        '   If UCase(txtUserID.Text) = "NBASE" Then
        '       gsWorkStationID = "01"
        '   Else
        '        Call GetSystemData
        '   End If

        '   Call Get_Company_Info

        '  Call Write_Login_File

        ' frmInfo.Show
        Me.Close()
        Exit Sub

Login_Err:
        Call Disconnect_Database()

    End Sub

    Private Function Get_Selected_INI(ByRef inListindex As Short) As String

        Dim compLine As String
        Dim Counter As Short
        Dim EndofFirstPart As Short

        Counter = 0
        Get_Selected_INI = ""

        FileOpen(1, My.Application.Info.DirectoryPath & "\COMPANY.LST", OpenMode.Input)
        Do While Not EOF(1) And Counter <= inListindex
            compLine = LineInput(1)
            If Counter = inListindex Then
                EndofFirstPart = InStr(1, compLine, ";")
                Get_Selected_INI = My.Application.Info.DirectoryPath & "\" & Mid(compLine, EndofFirstPart + 1)
            End If
            Counter = Counter + 1
        Loop
        FileClose(1)
        wsINIFile = Get_Selected_INI

    End Function

    Private Function Get_Selected_Lang(ByRef inListindex As Short) As String

        Dim compLine As String
        Dim Counter As Short
        Dim EndofFirstPart As Short

        Counter = 0
        Get_Selected_Lang = ""

        FileOpen(1, My.Application.Info.DirectoryPath & "\LANG.LST", OpenMode.Input)
        Do While Not EOF(1) And Counter <= inListindex
            compLine = LineInput(1)
            If Counter = inListindex Then
                EndofFirstPart = InStr(1, compLine, ";")
                Get_Selected_Lang = Mid(compLine, EndofFirstPart + 1)
            End If
            Counter = Counter + 1
        Loop
        FileClose(1)
        gsLangID = Get_Selected_Lang

    End Function

    Private Function Chk_Login(ByRef inUser As Object, ByRef inPassword As Object) As Short

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsLogin As New System.Data.DataTable
        Dim Criteria As String

        Chk_Login = 0

        'UPGRADE_WARNING: Couldn't resolve default property of object inUser. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Criteria = "SELECT USRPWD, USRNAME FROM MSTUSER WHERE USRCODE = '" & Set_Quote(inUser) & "' "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
            dataAdapt.Fill(rsLogin)
        Catch ex As Exception

        End Try

        If rsLogin.Rows.Count > 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object inPassword. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Encrypt(rsLogin.Rows(0).Item("USRPWD")) <> UCase(inPassword) Then
                Chk_Login = 2
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object inUser. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gsUserID = inUser
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object inPassword. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object inUser. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If UCase(inUser) = "NBASE" And UCase(inPassword) = "NBTEL" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object inUser. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gsUserID = UCase(inUser)
            Else
                Chk_Login = 1
            End If
        End If

        'rsLogin.Close()

    End Function

    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            cmdOK_Click(cmdOK, New System.EventArgs())
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPassword_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Leave
        txtPassword.SelectionLength = 0
    End Sub

    Private Sub txtUserID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserID.Enter
        txtUserID.SelectAll()
    End Sub

    Private Sub txtUserID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUserID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            txtPassword.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtUserID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserID.Leave
        txtUserID.SelectionLength = 0
    End Sub
End Class