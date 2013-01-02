Option Strict Off
Option Explicit On

Public Class frmC001
    Dim G As Graphics

    Private wsConnTime As String
    Private wsFormID As String
    Private wsTrnCd As String

    Private Const PERIOD As Short = 0
    Private Const SALES As Short = 1
    Private Const DEPOSIT As Short = 2
    Private Const BALID As Short = 3

    Private waResult As New System.Data.DataTable
    Private waScrItm As New System.Data.DataTable
    Private waScrToolTip As New System.Data.DataTable

    Private wsFormCaption As String
    Private wsActNam(4) As String
    Private wsOldTerr As String
    Private wsOldShipTerr As String
    Private wsOldShipTerr2 As String
    Private wsOldPayCode As String
    Private wsOldSaleCode As String

    Private wbErr As Boolean

    Private wiAction As Short
    Private wlKey As Integer
    Private wlSalesmanID As Integer
    Private wcCombo As System.Windows.Forms.Control

    Private Const wsKeyType As String = "MstCustomer"
    Private wsUsrId As String

    Private Const tcOpen As String = "toolBarOpen"
    Private Const tcAdd As String = "toolBarAdd"
    Private Const tcEdit As String = "toolBarEdit"
    Private Const tcDelete As String = "toolBarDelete"
    Private Const tcSave As String = "toolBarSave"
    Private Const tcCancel As String = "toolBarCancel"
    Private Const tcFind As String = "toolBarFind"
    Private Const tcExit As String = "toolBarExit"

    Private Sub frmC001_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call IniForm()
        Call Ini_Scr()
        Call Ini_Grid()
        Call Ini_Caption()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub IniForm()
        Me.KeyPreview = True
        'Me.Left = 0
        'Me.Top = 0
        'Me.Width = Screen.Width
        'Me.Height = Screen.Height
        wsConnTime = Dsp_Date(Now, True)
        wsFormID = "C001"
        wsTrnCd = ""
    End Sub

    Private Sub Ini_Grid()

        Dim wiCtr As Short

        With tblDetail
            .EmptyRows = True
            '.MultipleLines = 0
            .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            .AllowAddNew = True
            .AllowUpdate = True
            .AllowDelete = True
            .AlternatingRows = True
            .RecordSelectors = False
            .AllowColMove = False
            .AllowColSelect = False

            For wiCtr = PERIOD To BALID
                '.Columns(wiCtr).AllowSizing = True
                '.Columns(wiCtr).Visible = True
                '.Columns(wiCtr).Locked = False
                '.Columns(wiCtr).Button = False
                '.Columns(wiCtr).Alignment = TrueDBGrid60.AlignmentConstants.dbgLeft
                '.Columns(wiCtr).HeadAlignment = TrueDBGrid60.AlignmentConstants.dbgLeft
                .Splits(0).DisplayColumns(wiCtr).AllowSizing = True
                .Splits(0).DisplayColumns(wiCtr).Visible = True
                .Splits(0).DisplayColumns(wiCtr).Locked = False
                .Splits(0).DisplayColumns(wiCtr).Button = False
                .Splits(0).DisplayColumns(wiCtr).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns(wiCtr).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                Select Case wiCtr
                    Case PERIOD
                        .Splits(0).DisplayColumns(wiCtr).Width = 1000
                        .Columns(wiCtr).DataWidth = 15
                        .Splits(0).DisplayColumns(wiCtr).Locked = True
                    Case SALES
                        .Splits(0).DisplayColumns(wiCtr).Width = 1200
                        .Columns(wiCtr).DataWidth = 15
                        .Splits(0).DisplayColumns(wiCtr).Locked = True
                    Case DEPOSIT
                        .Splits(0).DisplayColumns(wiCtr).Width = 1200
                        .Columns(wiCtr).DataWidth = 15
                        .Splits(0).DisplayColumns(wiCtr).Locked = True
                    Case BALID
                        .Columns(wiCtr).DataWidth = 4
                        .Splits(0).DisplayColumns(wiCtr).Visible = False
                End Select
            Next
            '.Styles("EvenRow").BackColor = System.Convert.ToUInt32(&H8000000F)
            .Styles("EvenRow").BackColor = System.Drawing.ColorTranslator.FromWin32(&H8000000F)
        End With

    End Sub

    Private Sub Ini_Scr()
        Dim MyControl As System.Windows.Forms.Control

        'waResult.ReDim(0, -1, PERIOD, BALID)
        For i As Short = PERIOD To BALID
            waResult.Columns.Add(New DataColumn())
        Next
        tblDetail.DataSource = waResult
        tblDetail.Rebind(False)
        tblDetail.Bookmark = 0

        For Each MyControl In Me.Controls
            'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            Select Case TypeName(MyControl)
                Case "ComboBox"
                    'UPGRADE_WARNING: Couldn't resolve default property of object MyControl.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CType(MyControl, ComboBox).Items.Clear()
                Case "TextBox"
                    MyControl.Text = ""
                Case "TDBGrid"
                    'UPGRADE_WARNING: Couldn't resolve default property of object 'MyControl.ClearFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CType(MyControl, C1.Win.C1TrueDBGrid.C1TrueDBGrid).ClearFields()
                Case "Label"
                    If UCase(MyControl.Name) Like "LBLDSP*" Then
                        MyControl.Text = ""
                    End If
                Case "RichTextBox"
                    MyControl.Text = ""
                Case "CheckBox"
                    'UPGRADE_WARNING: Couldn't resolve default property of object 'MyControl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CType(MyControl, CheckBox).Checked = 0
            End Select
        Next MyControl


        wiAction = DefaultPage
        wlKey = 0
        wlSalesmanID = 0

        wsTrnCd = "CUS"


        wsOldTerr = ""
        wsOldShipTerr = ""
        wsOldShipTerr2 = ""
        wsOldPayCode = ""
        wsOldSaleCode = ""

        Call SetFieldStatus("Default")
        Call SetButtonStatus("Default")
        tblCommon.Visible = False
        Me.tabDetailInfo.SelectedIndex = 0
        Me.Text = wsFormCaption
    End Sub

    Private Sub Ini_Caption()

        On Error GoTo Ini_Caption_Err

        '   Call Get_Scr_Item("V001", waScrItm)
        Call Get_Scr_Item(wsFormID, waScrItm)
        Call Get_Scr_Item("TOOLTIP", waScrToolTip)

        wsFormCaption = Get_Caption(waScrItm, "SCRHDR")
        Me.Text = wsFormCaption

        'Dim str As String = String.Empty
        'Dim i, j As Integer
        'For i = 0 To waScrItm.Rows.Count - 1
        '    For j = 0 To waScrItm.Columns.Count - 1
        '        str += waScrItm.Rows(i).Item(j) + " | "
        '    Next
        '    str += Environment.NewLine
        'Next

        'MsgBox(str)

        fraCustomerInfo.Text = Get_Caption(waScrItm, "FRACUSTOMERINFO")
        lblCusCode.Text = Get_Caption(waScrItm, "CUSCODE")
        lblCusName.Text = Get_Caption(waScrItm, "CUSNAME")
        chkBadList.Text = Get_Caption(waScrItm, "BADLIST")
        chkInActive.Text = Get_Caption(waScrItm, "INACTIVE")
        lblCusTel.Text = Get_Caption(waScrItm, "CUSTEL")
        lblCusFax.Text = Get_Caption(waScrItm, "CUSFAX")
        lblCusContactPerson.Text = Get_Caption(waScrItm, "CUSCONTACTPERSON")
        lblCusEmail.Text = Get_Caption(waScrItm, "CUSEMAIL")
        lblCusAddress1.Text = Get_Caption(waScrItm, "CUSADDRESS1")
        fraCusShipAddr1.Text = Get_Caption(waScrItm, "FRACUSSHIPADDR1")
        fraCusShipAddr2.Text = Get_Caption(waScrItm, "FRACUSSHIPADDR2")
        lblCusShipAdd1.Text = Get_Caption(waScrItm, "CUSSHIPADD1")
        lblCusShipContactPerson.Text = Get_Caption(waScrItm, "CUSSHIPCONTACTPERSON")
        lblCusShipTel.Text = Get_Caption(waScrItm, "CUSSHIPTEL")
        lblCusShipTerrCode.Text = Get_Caption(waScrItm, "CUSSHIPTERRCODE")
        lblCusShipAdd2.Text = Get_Caption(waScrItm, "CUSSHIPADD2")
        lblCusShipContactPerson2.Text = Get_Caption(waScrItm, "CUSSHIPCONTACTPERSON2")
        lblCusShipTel2.Text = Get_Caption(waScrItm, "CUSSHIPTEL2")
        lblCusShipTerrCode2.Text = Get_Caption(waScrItm, "CUSSHIPTERRCODE2")
        lblCusPayCode.Text = Get_Caption(waScrItm, "CUSPAYCODE")
        lblCusCreditLimit.Text = Get_Caption(waScrItm, "CUSCREDITLIMIT")
        lblCusCurr.Text = Get_Caption(waScrItm, "CUSCURR")
        lblCusSpecDis.Text = Get_Caption(waScrItm, "CUSSPECDIS")
        lblCusRemark.Text = Get_Caption(waScrItm, "CUSREMARK")
        lblCusMLCode.Text = Get_Caption(waScrItm, "CUSMLCODE")
        lblCusRgnCode.Text = Get_Caption(waScrItm, "CUSRGNCODE")
        lblCusSaleName.Text = Get_Caption(waScrItm, "CUSSALENAME")

        lblCusContactPerson1.Text = Get_Caption(waScrItm, "CUSCONTACTPERSON1")

        lblCusLastUpd.Text = Get_Caption(waScrItm, "CUSLASTUPD")
        lblCusLastUpdDate.Text = Get_Caption(waScrItm, "CUSLASTUPDDATE")

        lblCusCrtDate.Text = Get_Caption(waScrItm, "CUSCRTDATE")
        lblAcmSale.Text = Get_Caption(waScrItm, "ACMSALE")
        lblAcmYrSale.Text = Get_Caption(waScrItm, "ACMYRSALE")
        lblAcmMnSale.Text = Get_Caption(waScrItm, "ACMMNSALE")
        lblOpenBal.Text = Get_Caption(waScrItm, "OPENBAL")
        lblCloseBal.Text = Get_Caption(waScrItm, "CLOSEBAL")
        lblARBal.Text = Get_Caption(waScrItm, "ARBAL")
        lblQty.Text = Get_Caption(waScrItm, "QTY")
        lblAmt.Text = Get_Caption(waScrItm, "AMT")
        lblNet.Text = Get_Caption(waScrItm, "NET")

        With tblDetail
            .Columns(PERIOD).Caption = Get_Caption(waScrItm, "PERIOD")
            .Columns(SALES).Caption = Get_Caption(waScrItm, "SALES")
            .Columns(DEPOSIT).Caption = Get_Caption(waScrItm, "DEPOSIT")
        End With

        tabDetailInfo.TabPages.Item(0).Text = Get_Caption(waScrItm, "TABDETAILINFO0")
        tabDetailInfo.TabPages.Item(1).Text = Get_Caption(waScrItm, "TABDETAILINFO1")
        tabDetailInfo.TabPages.Item(2).Text = Get_Caption(waScrItm, "TABDETAILINFO2")
        tabDetailInfo.TabPages.Item(3).Text = Get_Caption(waScrItm, "TABDETAILINFO3")

        tbrProcess.Items.Item(tcOpen).ToolTipText = Get_Caption(waScrToolTip, tcOpen) & "(F6)"
        tbrProcess.Items.Item(tcAdd).ToolTipText = Get_Caption(waScrToolTip, tcAdd) & "(F2)"
        tbrProcess.Items.Item(tcEdit).ToolTipText = Get_Caption(waScrToolTip, tcEdit) & "(F5)"
        tbrProcess.Items.Item(tcDelete).ToolTipText = Get_Caption(waScrToolTip, tcDelete) & "(F3)"
        tbrProcess.Items.Item(tcSave).ToolTipText = Get_Caption(waScrToolTip, tcSave) & "(F10)"
        tbrProcess.Items.Item(tcCancel).ToolTipText = Get_Caption(waScrToolTip, tcCancel) & "(F11)"
        tbrProcess.Items.Item(tcFind).ToolTipText = Get_Caption(waScrToolTip, tcFind) & "(F9)"
        tbrProcess.Items.Item(tcExit).ToolTipText = Get_Caption(waScrToolTip, tcExit) & "(F12)"

        wsActNam(1) = Get_Caption(waScrItm, "CADD")
        wsActNam(2) = Get_Caption(waScrItm, "CEDIT")
        wsActNam(3) = Get_Caption(waScrItm, "CDELETE")

        Exit Sub

Ini_Caption_Err:
        MsgBox(Err.Description)
        MsgBox("Please Check ini_Caption!")

    End Sub

    Public Sub SetFieldStatus(ByVal sStatus As String)
        Select Case sStatus
            Case "Default"
                Me.cboCusCode.Enabled = False
                Me.txtCusCode.Enabled = False

                Me.txtCusName.Enabled = False
                Me.chkBadList.Enabled = False
                Me.chkInActive.Enabled = False
                Me.txtCusTel.Enabled = False
                Me.txtCusFax.Enabled = False
                Me.txtCusContactPerson.Enabled = False
                Me.txtCusContactPerson1.Enabled = False
                Me.txtCusEmail.Enabled = False
                Me.txtCusAddress1.Enabled = False
                Me.txtCusAddress2.Enabled = False
                Me.txtCusAddress3.Enabled = False
                Me.txtCusAddress4.Enabled = False

                Me.txtCusShipAdd1.Enabled = False
                Me.txtCusShipAdd2.Enabled = False
                Me.txtCusShipAdd3.Enabled = False
                Me.txtCusShipAdd4.Enabled = False
                Me.txtCusShipContactPerson.Enabled = False
                Me.txtCusShipTel.Enabled = False
                Me.txtCusShipFax.Enabled = False
                Me.txtCusShipTerrName.Enabled = False

                Me.txtCusShipAdd12.Enabled = False
                Me.txtCusShipAdd22.Enabled = False
                Me.txtCusShipAdd32.Enabled = False
                Me.txtCusShipAdd42.Enabled = False
                Me.txtCusShipContactPerson2.Enabled = False
                Me.txtCusShipTel2.Enabled = False
                Me.txtCusShipFax2.Enabled = False
                Me.txtCusShipTerrName2.Enabled = False

                Me.txtCusPayDesc.Enabled = False
                Me.txtCusCreditLimit.Enabled = False
                Me.txtCusSpecDis.Enabled = False
                Me.txtCusRemark.Enabled = False

                Me.cboCusCurr.Enabled = False
                Me.cboCusShipTerrCode.Enabled = False
                Me.cboCusShipTerrCode2.Enabled = False
                Me.cboCusPayCode.Enabled = False
                Me.cboCusSaleCode.Enabled = False

                Me.cboCusMLCode.Enabled = False
                Me.cboCusRgnCode.Enabled = False


            Case "AfrActAdd"
                Me.cboCusCode.Enabled = False
                Me.cboCusCode.Visible = False

                Me.txtCusCode.Enabled = True
                Me.txtCusCode.Visible = True

            Case "AfrActEdit"
                Me.cboCusCode.Enabled = True
                Me.cboCusCode.Visible = True

                Me.txtCusCode.Enabled = False
                Me.txtCusCode.Visible = False


            Case "AfrKey"
                Me.cboCusCode.Enabled = False
                Me.txtCusCode.Enabled = False

                Me.txtCusName.Enabled = True
                Me.chkBadList.Enabled = True
                Me.chkInActive.Enabled = True
                Me.txtCusTel.Enabled = True
                Me.txtCusFax.Enabled = True
                Me.txtCusContactPerson.Enabled = True
                Me.txtCusContactPerson1.Enabled = True
                Me.txtCusEmail.Enabled = True

                Me.txtCusAddress1.Enabled = True
                Me.txtCusAddress2.Enabled = True
                Me.txtCusAddress3.Enabled = True
                Me.txtCusAddress4.Enabled = True
                Me.txtCusShipAdd1.Enabled = True
                Me.txtCusShipAdd2.Enabled = True
                Me.txtCusShipAdd3.Enabled = True
                Me.txtCusShipAdd4.Enabled = True
                Me.txtCusShipContactPerson.Enabled = True
                Me.txtCusShipTel.Enabled = True
                Me.txtCusShipFax.Enabled = True
                Me.txtCusShipTerrName.Enabled = True

                Me.txtCusShipAdd12.Enabled = True
                Me.txtCusShipAdd22.Enabled = True
                Me.txtCusShipAdd32.Enabled = True
                Me.txtCusShipAdd42.Enabled = True
                Me.txtCusShipContactPerson2.Enabled = True
                Me.txtCusShipTel2.Enabled = True
                Me.txtCusShipFax2.Enabled = True
                Me.txtCusShipTerrName2.Enabled = True
                Me.txtCusPayDesc.Enabled = True
                Me.txtCusCreditLimit.Enabled = True

                Me.txtCusSpecDis.Enabled = True
                Me.txtCusRemark.Enabled = True

                Me.cboCusCurr.Enabled = True
                Me.cboCusShipTerrCode.Enabled = True
                Me.cboCusShipTerrCode2.Enabled = True
                Me.cboCusPayCode.Enabled = True
                Me.cboCusSaleCode.Enabled = True

                Me.cboCusMLCode.Enabled = True
                Me.cboCusRgnCode.Enabled = True

        End Select
    End Sub

    Public Sub SetButtonStatus(ByVal sStatus As String)
        Select Case sStatus
            Case "Default"
                With tbrProcess
                    .Items.Item(tcOpen).Enabled = True
                    .Items.Item(tcAdd).Enabled = True
                    .Items.Item(tcEdit).Enabled = True
                    .Items.Item(tcDelete).Enabled = True
                    .Items.Item(tcSave).Enabled = False
                    .Items.Item(tcCancel).Enabled = False
                    .Items.Item(tcFind).Enabled = False
                    .Items.Item(tcExit).Enabled = True
                End With



            Case "AfrActAdd"
                With tbrProcess
                    .Items.Item(tcOpen).Enabled = True
                    .Items.Item(tcAdd).Enabled = False
                    .Items.Item(tcEdit).Enabled = False
                    .Items.Item(tcDelete).Enabled = False
                    .Items.Item(tcSave).Enabled = False
                    .Items.Item(tcCancel).Enabled = True
                    .Items.Item(tcFind).Enabled = False
                    .Items.Item(tcExit).Enabled = True
                End With

            Case "AfrActEdit"
                With tbrProcess
                    .Items.Item(tcOpen).Enabled = True
                    .Items.Item(tcAdd).Enabled = False
                    .Items.Item(tcEdit).Enabled = False
                    .Items.Item(tcDelete).Enabled = False
                    .Items.Item(tcSave).Enabled = False
                    .Items.Item(tcCancel).Enabled = True
                    .Items.Item(tcFind).Enabled = True
                    .Items.Item(tcExit).Enabled = True
                End With


            Case "AfrKey"
                With tbrProcess
                    .Items.Item(tcOpen).Enabled = True
                    .Items.Item(tcAdd).Enabled = False
                    .Items.Item(tcEdit).Enabled = False
                    .Items.Item(tcDelete).Enabled = False
                    .Items.Item(tcSave).Enabled = True
                    .Items.Item(tcCancel).Enabled = True
                    .Items.Item(tcFind).Enabled = False
                    .Items.Item(tcExit).Enabled = True
                End With


            Case "ReadOnly"
                With tbrProcess
                    .Items.Item(tcOpen).Enabled = True
                    .Items.Item(tcAdd).Enabled = False
                    .Items.Item(tcDelete).Enabled = False
                    .Items.Item(tcSave).Enabled = False
                    .Items.Item(tcCancel).Enabled = False
                    .Items.Item(tcFind).Enabled = True
                    .Items.Item(tcExit).Enabled = True

                End With



        End Select
    End Sub

    Private Sub cboCusMLCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusMLCode

        wsSQL = "SELECT MLCode, MLDesc FROM MstMerchClass WHERE MLStatus = '1'"
        wsSQL = wsSQL & "ORDER BY MLCode "
        location = Get_Control_Location(cboCusMLCode)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusMLCode.Height, tblCommon, "C001", "TBLCUSML", Me.Width, Me.Height)


        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusMLCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cboCusMLCode.SelectAll()
    End Sub

    Private Sub cboCusMLCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ' Dim wsDesc As String

        Call chk_InpLen(cboCusMLCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusMLCode() = False Then
                GoTo EventExitSub
            End If

            tabDetailInfo.SelectedIndex = 2
            txtCusRemark.Focus()
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusMLCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cboCusMLCode.SelectionLength = 0
    End Sub


    Private Sub cboCusRgnCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusRgnCode

        wsSQL = "SELECT RgnCode, RgnDesc FROM MstRegion WHERE RgnStatus = '1'"
        wsSQL = wsSQL & "ORDER BY RgnCode "
        location = Get_Control_Location(cboCusRgnCode)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusRgnCode.Height, tblCommon, "C001", "TBLCUSRGN", Me.Width, Me.Height)
        
        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusRgnCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cboCusRgnCode.SelectAll()
    End Sub


    Private Sub cboCusRgnCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ' Dim wsDesc As String

        Call chk_InpLen(cboCusRgnCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusRgnCode() = False Then
                GoTo EventExitSub
            End If

            tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd1.Focus()

        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusRgnCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cboCusRgnCode.SelectionLength = 0
    End Sub

    Private Sub frmC001_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.PageDown
                KeyCode = 0
                If tabDetailInfo.SelectedIndex < tabDetailInfo.TabPages.Count() - 1 Then
                    tabDetailInfo.SelectedIndex = tabDetailInfo.SelectedIndex + 1
                    Exit Sub
                End If
            Case System.Windows.Forms.Keys.PageUp
                KeyCode = 0
                If tabDetailInfo.SelectedIndex > 0 Then
                    tabDetailInfo.SelectedIndex = tabDetailInfo.SelectedIndex - 1
                    Exit Sub
                End If

            Case System.Windows.Forms.Keys.F8
                Call cmdOpen()


            Case System.Windows.Forms.Keys.F2
                If wiAction = DefaultPage Then Call cmdNew()


            Case System.Windows.Forms.Keys.F5
                If wiAction = DefaultPage Then Call cmdEdit()


            Case System.Windows.Forms.Keys.F3
                If wiAction = DefaultPage Then Call cmdDel()

            Case System.Windows.Forms.Keys.F9
                If tbrProcess.Items.Item(tcFind).Enabled = True Then
                    Call cmdFind()
                End If

            Case System.Windows.Forms.Keys.F10
                If tbrProcess.Items.Item(tcSave).Enabled = True Then
                    Call cmdSave()
                End If

            Case System.Windows.Forms.Keys.F11

                If wiAction = AddRec Or wiAction = CorRec Or wiAction = DelRec Then Call cmdCancel()

            Case System.Windows.Forms.Keys.F12

                Me.Close()

        End Select
    End Sub

    'UPGRADE_WARNING: Event frmC001.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmC001_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '-- Resize, not maximum and minimax.
        If Me.WindowState = 0 Then
            G = Me.CreateGraphics()
            Me.Height = 6660 * G.DpiY / 1024
            Me.Width = 10020 * G.DpiX / 1024
            G.Dispose()
        End If
    End Sub

    '-- Input validation checking.
    Private Function InputValidation() As Boolean
        Dim sTmp As String = String.Empty

        InputValidation = False

        If Chk_txtCusName = False Then
            Exit Function
        End If

        If Chk_cboCusShipTerrCode(sTmp) = False Then
            Exit Function
        End If

        'If Chk_cboCusShipTerrCode2(sTmp) = False Then
        '    Exit Function
        'End If

        If Chk_cboCusSaleCode(sTmp) = False Then
            Exit Function
        End If

        If Chk_cboCusPayCode(sTmp) = False Then
            Exit Function
        End If

        If Chk_cboCusCurr = False Then
            Exit Function
        End If

        If Chk_cboCusMLCode = False Then
            Exit Function
        End If

        If Chk_cboCusRgnCode = False Then
            Exit Function
        End If



        InputValidation = True
    End Function

    Public Function LoadRecord() As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim wsSQL As String
        Dim wsSaleName As String = String.Empty
        Dim wsSaleCode As String = String.Empty
        Dim rsRcd As New System.Data.DataTable

        wsSQL = "SELECT MstCustomer.* "
        wsSQL = wsSQL & "From MstCustomer "
        wsSQL = wsSQL & "WHERE (((MstCustomer.CusCode)='" & cboCusCode.Text & "') AND ((MstCustomer.CusStatus)='1'));"


        'rsRcd.Open(wsSQL, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count = 0 Then
            LoadRecord = False
            wlKey = 0
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            wlKey = ReadRs(rsRcd, "CusID")

            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusName.Text = ReadRs(rsRcd, "CusName")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call Set_CheckValue(chkBadList, ReadRs(rsRcd, "CusBadList"))
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call Set_CheckValue(chkInActive, ReadRs(rsRcd, "CusInActive"))

            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusTel.Text = ReadRs(rsRcd, "CusTel")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusFax.Text = ReadRs(rsRcd, "CusFax")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusContactPerson.Text = ReadRs(rsRcd, "CusContactPerson")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusEmail.Text = ReadRs(rsRcd, "CusEmail")

            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusContactPerson1.Text = ReadRs(rsRcd, "CusContactPerson1")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusAddress1.Text = ReadRs(rsRcd, "CusAddress1")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusAddress2.Text = ReadRs(rsRcd, "CusAddress2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusAddress3.Text = ReadRs(rsRcd, "CusAddress3")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusAddress4.Text = ReadRs(rsRcd, "CusAddress4")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusRgnCode.Text = ReadRs(rsRcd, "CusRgnCode")

            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd1.Text = ReadRs(rsRcd, "CusShipAdd1")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd2.Text = ReadRs(rsRcd, "CusShipAdd2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd3.Text = ReadRs(rsRcd, "CusShipAdd3")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd4.Text = ReadRs(rsRcd, "CusShipAdd4")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipContactPerson.Text = ReadRs(rsRcd, "CusShipContactPerson")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipTel.Text = ReadRs(rsRcd, "CusShipTel")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipFax.Text = ReadRs(rsRcd, "CusShipFax")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusShipTerrCode.Text = ReadRs(rsRcd, "CusShipTerrCode")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipTerrName.Text = ReadRs(rsRcd, "CusShipTerrName")

            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd12.Text = ReadRs(rsRcd, "CusShipAdd12")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd22.Text = ReadRs(rsRcd, "CusShipAdd22")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd32.Text = ReadRs(rsRcd, "CusShipAdd32")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipAdd42.Text = ReadRs(rsRcd, "CusShipAdd42")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipContactPerson2.Text = ReadRs(rsRcd, "CusShipContactPerson2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipTel2.Text = ReadRs(rsRcd, "CusShipTel2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipFax2.Text = ReadRs(rsRcd, "CusShipFax2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusShipTerrCode2.Text = ReadRs(rsRcd, "CusShipTerrCode2")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusShipTerrName2.Text = ReadRs(rsRcd, "CusShipTerrName2")


            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusPayCode.Text = ReadRs(rsRcd, "CusPayCode")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusPayDesc.Text = ReadRs(rsRcd, "CusPayTerm")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            wlSalesmanID = ReadRs(rsRcd, "CusSaleID")
            Me.cboCusSaleCode.Text = LoadSaleCodeByID(wlSalesmanID)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusCurr.Text = ReadRs(rsRcd, "CusCurr")
            Me.txtCusCreditLimit.Text = Format(To_Value(ReadRs(rsRcd, "CusCreditLimit")), gsAmtFmt)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.cboCusMLCode.Text = ReadRs(rsRcd, "CusMLCode")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusSpecDis.Text = Format(ReadRs(rsRcd, "CusSpecDis"), gsAmtFmt)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Me.txtCusRemark.Text = ReadRs(rsRcd, "CusRemark")

            lblDspCusMLDesc.Text = LoadDescByCode("MstMerchClass", "MLCode", "MLDesc", cboCusMLCode.Text, True)
            lblDspCusRgnDesc.Text = LoadDescByCode("MstRegion", "RgnCode", "RgnDesc", cboCusRgnCode.Text, True)

            lblDspCrtDate.Text = Dsp_Date(ReadRs(rsRcd, "CusCrtDate"))

            LoadSaleByID(wsSaleCode, wsSaleName, wlSalesmanID)
            cboCusSaleCode.Text = wsSaleCode
            lblDspCusSaleName.Text = wsSaleName

            wsOldShipTerr = cboCusShipTerrCode.Text
            wsOldShipTerr2 = cboCusShipTerrCode2.Text
            wsOldPayCode = cboCusPayCode.Text
            wsOldSaleCode = cboCusSaleCode.Text

            Call LoadSaleInfo()
            LoadRecord = True
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()

        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function


    Private Sub frmC001_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)
        If SaveData() = True Then
            'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            'Cancel = True
            Exit Sub
        End If
        Call UnLockAll(wsConnTime, wsFormID)
        'UPGRADE_NOTE: Object waScrItm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waScrItm = Nothing
        'UPGRADE_NOTE: Object waScrToolTip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waScrToolTip = Nothing
        'UPGRADE_NOTE: Object frmC001 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Me.Close() ' = Nothing

    End Sub

    Private Sub tabDetailInfo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Static PreviousTab As Short = tabDetailInfo.SelectedIndex()
        If tabDetailInfo.SelectedIndex = 0 Then
            If txtCusAddress1.Enabled And txtCusAddress1.Visible Then
                txtCusAddress1.Focus()
            End If
        ElseIf tabDetailInfo.SelectedIndex = 1 Then
            If txtCusShipAdd1.Enabled And txtCusShipAdd1.Visible Then
                txtCusShipAdd1.Focus()
            End If
        ElseIf tabDetailInfo.SelectedIndex = 2 Then
            If cboCusPayCode.Enabled And cboCusPayCode.Visible Then
                cboCusPayCode.Focus()
            End If
        ElseIf tabDetailInfo.SelectedIndex = 3 Then
            'If txtCusRemark.Enabled And txtCusRemark.Visible Then
            '    tblDetail.SetFocus
            'End If
        End If
        PreviousTab = tabDetailInfo.SelectedIndex()
    End Sub

    Private Sub tblDetail_AfterColUpdate(ByVal eventSender As System.Object, ByVal eventArgs As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tblDetail.AfterColUpdate
        With tblDetail
            'UPGRADE_NOTE: Update was upgraded to CtlUpdate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            .Update()
        End With
    End Sub

    Private Sub tblDetail_BeforeColUpdate(ByVal eventSender As System.Object, ByVal eventArgs As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tblDetail.BeforeColUpdate
        Dim wsBookID As String
        Dim wsBookCode As String
        Dim wsBarCode As String
        Dim wsBookName As String
        Dim wsPub As String
        Dim wdPrice As Double
        Dim wdDisPer As Double
        Dim wsLotNo As String
        Dim wsWhsCode As String
        Dim wdQty As Double

        On Error GoTo tblDetail_BeforeColUpdate_Err

        If tblCommon.Visible = True Then
            eventArgs.Cancel = False
            'UPGRADE_WARNING: Couldn't resolve default property of object OldValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            tblDetail.Columns(eventArgs.ColIndex).Text = eventArgs.OldValue
            Exit Sub
        End If

        With tblDetail
            Select Case eventArgs.ColIndex
                'Case SONO
                '    If Not Chk_NoDup(.Row + To_Value(.FirstRow)) Then
                '        GoTo Tbl_BeforeColUpdate_Err
                '    End If
                '
                '    If Chk_grdSoNo(.Columns(ColIndex).Text) = False Then
                '       GoTo Tbl_BeforeColUpdate_Err
                '    End If
            End Select
        End With

        Exit Sub

Tbl_BeforeColUpdate_Err:
        'UPGRADE_WARNING: Couldn't resolve default property of object OldValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        tblDetail.Columns(eventArgs.ColIndex).Text = eventArgs.OldValue
        eventArgs.Cancel = True
        Exit Sub

tblDetail_BeforeColUpdate_Err:

        MsgBox("Check tblDeiail BeforeColUpdate!")
        'UPGRADE_WARNING: Couldn't resolve default property of object OldValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        tblDetail.Columns(eventArgs.ColIndex).Text = eventArgs.OldValue
        eventArgs.Cancel = True

    End Sub

    Private Sub tblDetail_BeforeRowColChange(ByVal eventSender As System.Object, ByVal eventArgs As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tblDetail.BeforeRowColChange

        On Error GoTo tblDetail_BeforeRowColChange_Err
        With tblDetail
            '  If .Bookmark <> .DestinationRow Then
            '      If Chk_GrdRow(To_Value(.Bookmark)) = False Then
            '          'Cancel = True
            '          Exit Sub
            '      End If
            '  End If
        End With

        Exit Sub

tblDetail_BeforeRowColChange_Err:

        MsgBox("Check tblDeiail BeforeRowColChange!")
        eventArgs.Cancel = True

    End Sub

    Private Sub tblDetail_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tblDetail.ButtonClick

        Dim wsSQL As String
        Dim wiTop As Integer

        On Error GoTo tblDetail_ButtonClick_Err


        With tblDetail
            Select Case eventArgs.ColIndex
                'Case SONO
                '
                '    wsSql = "SELECT SOHDDOCNO, SOHDDOCDATE FROM soaSOHD "
                '    wsSql = wsSql & " WHERE SOHDSTATUS = '1' "
                '    wsSql = wsSql & " AND SOHDDOCNO LIKE '%" & Set_Quote(.Columns(SONO).Text) & "%' "
                '    wsSql = wsSql & " AND SOHDCUSID = " & wlCusID
                '    wsSql = wsSql & " ORDER BY SOHDDOCNO "
                '
                '    Call Ini_Combo(2, wsSql, .Columns(ColIndex).Left + .Left + .Columns(ColIndex).Top + tabDetailInfo.Left, .Top + .RowTop(.Row) + .RowHeight + tabDetailInfo.Top, tblCommon, wsFormID, "TBLSONO", Me.Width, Me.Height)
                '    tblCommon.Visible = True
                '    tblCommon.SetFocus
                '    Set wcCombo = tblDetail
                '
            End Select
        End With

        Exit Sub

tblDetail_ButtonClick_Err:
        MsgBox("Check tblDeiail ButtonClick!")
    End Sub

    Private Sub tblDetail_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles tblDetail.KeyDown

        Dim wlRet As Short
        Dim wlRow As Integer

        On Error GoTo tblDetail_KeyDown_Err

        With tblDetail
            Select Case eventArgs.KeyCode
                Case System.Windows.Forms.Keys.F4 ' CALL COMBO BOX
                    'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
                    'Call tblDetail_ButtonClick(tblDetail, New C1.Win.C1TrueDBGrid.ColEventArgs(.Col))

                Case System.Windows.Forms.Keys.F5 ' INSERT LINE
                    'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
                    If .Bookmark = waResult.Columns.Count() Then Exit Sub
                    If IsEmptyRow() Then Exit Sub
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    waResult.Rows.Add(IIf(IsDBNull(.Bookmark), 0, .Bookmark))
                    .Rebind(True)
                    .Focus()

                Case System.Windows.Forms.Keys.F8 ' DELETE LINE
                    'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If IsDBNull(.Bookmark) Then Exit Sub
                    If .EditActive = True Then Exit Sub
                    gsMsg = "你是否確定要刪除此列?"
                    If MsgBox(gsMsg, MsgBoxStyle.OkCancel, gsTitle) = MsgBoxResult.Cancel Then Exit Sub
                    .Delete()
                    'UPGRADE_NOTE: Update was upgraded to CtlUpdate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                    .Update()
                    If .Row = -1 Then
                        .Row = 0
                    End If
                    'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                    .Refresh()
                    .Focus()

                Case System.Windows.Forms.Keys.Return
                    Select Case .Col
                        'Case sono
                        '    KeyCode = vbDefault
                        '       .Col = BOOKCODE
                        'Case SALES
                        '    KeyCode = vbDefault
                        '       .Col = WhsCode
                        ' KeyCode = vbKeyDown
                        ' .Col = BOOKCODE
                        'Case BOOKNAME, BARCODE, WhsCode, LOTNO, PUBLISHER, Qty, DisPer, Amt, Dis
                        '    KeyCode = vbDefault
                        '    .Col = .Col + 1
                        'Case Price, Net, Amtl
                        '    KeyCode = vbKeyDown
                        '    .Col = BOOKCODE
                    End Select
                Case System.Windows.Forms.Keys.Left
                    'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
                    If .Col <> PERIOD Then
                        .Col = .Col - 1
                    End If

                Case System.Windows.Forms.Keys.Right
                    'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
                    If .Col <> DEPOSIT Then
                        .Col = .Col + 1
                    End If

            End Select
        End With

        Exit Sub

tblDetail_KeyDown_Err:
        MsgBox("Check tblDeiail KeyDown")

    End Sub

    'Private Sub tblDetail_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxTrueDBGrid60.TrueDBGridEvents_KeyPressEvent) Handles tblDetail.KeyPressEvent
    '    Select Case tblDetail.Col

    '    End Select
    'End Sub

    'Private Sub tblDetail_MouseUpEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxTrueDBGrid60.TrueDBGridEvents_MouseUpEvent) Handles tblDetail.MouseUpEvent
    '    'If Button = 2 Then
    '    '    PopupMenu mnuPopUp
    '    'End If
    'End Sub

    Private Sub tblDetail_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblDetail.RowColChange

        wbErr = False
        On Error GoTo RowColChange_Err

        'UPGRADE_ISSUE: Control Name could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
        If ActiveControl.Name <> tblDetail.Name Then Exit Sub

        With tblDetail
            If IsEmptyRow() Then
                .Col = PERIOD
            End If

            If Trim(.Columns(.Col).Text) <> "" Then
                Select Case .Col
                    'Case SONO
                    '    Call Chk_grdSoNo(.Columns(SONO).Text)
                    'Case BOOKCODE
                    '    Call Chk_grdBookCode(.Columns(SONO).Text, .Columns(BOOKCODE).Text, "", "", "", "", "", 0, 0, "", "", 0)
                    'Case WhsCode
                    '    Call Chk_grdWhsCode(.Columns(WhsCode).Text)
                    ' Case LOTNO
                    '    Call Chk_grdLotNo(.Columns(LOTNO).Text)
                    'Case Qty
                    '    Call Chk_grdQty(.Columns(Qty).Text)
                    'Case DisPer
                    '    Call Chk_grdDisPer(.Columns(DisPer).Text)

                End Select
            End If
        End With

        Exit Sub

RowColChange_Err:

        MsgBox("Check tblDeiail RowColChange")
        wbErr = True

    End Sub

    Private Sub tbrProcess_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles toolBarOpen.Click, toolBarAdd.Click, toolBarEdit.Click, toolBarDelete.Click, toolBarSave.Click, toolBarCancel.Click, toolBarFind.Click, toolBarExit.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case tcOpen
                Call cmdOpen()

            Case tcAdd
                Call cmdNew()

            Case tcEdit
                Call cmdEdit()

            Case tcDelete

                Call cmdDel()

            Case tcSave

                Call cmdSave()

            Case tcCancel

                If tbrProcess.Items.Item(tcSave).Enabled = True Then
                    gsMsg = "你是否確定儲存現時之變更而離開?"
                    If MsgBox(gsMsg, MsgBoxStyle.YesNo, gsTitle) = MsgBoxResult.No Then
                        Call cmdCancel()
                    End If
                Else
                    Call cmdCancel()
                End If

            Case tcFind

                Call OpenPromptForm()

            Case tcExit

                Me.Close()

        End Select
    End Sub

    Private Sub Ini_Scr_AfrAct()
        Select Case wiAction
            Case AddRec
                Call SetFieldStatus("AfrActAdd")
                Call SetButtonStatus("AfrActAdd")
                txtCusCode.Focus()

            Case CorRec
                Call SetFieldStatus("AfrActEdit")
                Call SetButtonStatus("AfrActEdit")
                cboCusCode.Focus()

            Case DelRec
                Call SetFieldStatus("AfrActEdit")
                Call SetButtonStatus("AfrActEdit")
                cboCusCode.Focus()

        End Select

        Me.Text = wsFormCaption & " - " & wsActNam(wiAction)
    End Sub
    Private Sub Ini_Scr_AfrKey()
        ' Dim Ctrl As System.Windows.Forms.Control

        Select Case wiAction

            Case CorRec, DelRec

                If LoadRecord() = False Then
                    gsMsg = "存取檔案失敗! 請聯絡系統管理員或無限系統顧問!"
                    MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
                    tblDetail.Rebind(True)
                    Exit Sub
                Else
                    If RowLock(wsConnTime, wsKeyType, cboCusCode.Text, wsFormID, wsUsrId) = False Then
                        gsMsg = "記錄已被以下使用者鎖定 : " & wsUsrId
                        MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
                    End If
                End If
        End Select
        Call SetFieldStatus("AfrKey")
        Call SetButtonStatus("AfrKey")
        txtCusEmail.Focus()
    End Sub

    Private Function Chk_CusCode(ByVal inCode As String, ByRef outCode As String) As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        Chk_CusCode = False

        If Trim(inCode) = "" Then
            Exit Function
        End If

        wsSQL = "SELECT CusStatus "
        wsSQL = wsSQL & " FROM MstCustomer WHERE CusCode = '" & Set_Quote(inCode) & "' And CusStatus = '1'"

        'rsRcd.Open(wsSQL, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count <= 0 Then
            outCode = ""

            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        outCode = ReadRs(rsRcd, "CusStatus")

        Chk_CusCode = True

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Private Function Chk_CusSaleCode(ByVal inCode As String, ByRef OutID As Integer, ByRef OutName As String) As Boolean

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        Chk_CusSaleCode = False

        If Trim(inCode) = "" Then
            Exit Function
        End If

        wsSQL = "SELECT SaleID, SaleName "
        wsSQL = wsSQL & " FROM MstSalesman WHERE SaleCode = '" & Set_Quote(inCode) & "' "
        wsSQL = wsSQL & " AND SaleStatus = '1' "

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
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OutName = ReadRs(rsRcd, "SaleName")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OutID = ReadRs(rsRcd, "SaleID")
        Else
            OutName = ""
            OutID = 0
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function
        End If

        Chk_CusSaleCode = True

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Private Function Chk_CusPayCode(ByVal inCode As String, ByRef OutName As String) As Boolean

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        Chk_CusPayCode = False

        If Trim(inCode) = "" Then
            Exit Function
        End If

        wsSQL = "SELECT PayDesc "
        wsSQL = wsSQL & " FROM MstPayTerm WHERE PayCode = '" & Set_Quote(inCode) & "' "
        wsSQL = wsSQL & " AND PayStatus = '1' "

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
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OutName = ReadRs(rsRcd, "PayDesc")
        Else
            OutName = ""
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function
        End If

        Chk_CusPayCode = True

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Private Function chk_cboCusCode() As Boolean
        Dim wsStatus As String = String.Empty

        chk_cboCusCode = False

        If Trim(cboCusCode.Text) = "" And Chk_AutoGen(wsTrnCd) = "N" Then
            gsMsg = "沒有輸入須要之資料!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusCode.Focus()
            Exit Function
        End If

        If Chk_CusCode(cboCusCode.Text, wsStatus) = False Then
            gsMsg = "客戶編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusCode.Focus()
            Exit Function
        Else
            If wsStatus = "2" Then
                gsMsg = "客戶編碼已存在但已無效!"
                MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
                cboCusCode.Focus()
                Exit Function
            End If
        End If

        chk_cboCusCode = True
    End Function

    Private Function Chk_txtCusCode() As Boolean
        Dim wsStatus As String = String.Empty

        Chk_txtCusCode = False

        If Trim(txtCusCode.Text) = "" And Chk_AutoGen(wsTrnCd) = "N" Then
            gsMsg = "沒有輸入須要之資料!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            txtCusCode.Focus()
            Exit Function
        End If

        If Chk_CusCode(txtCusCode.Text, wsStatus) = True Then
            If wsStatus = "2" Then
                gsMsg = "客戶編碼已存在但已無效!"
            Else
                gsMsg = "客戶編碼已存在!"
            End If

            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            txtCusCode.Focus()
            Exit Function
        End If

        Chk_txtCusCode = True
    End Function


    Private Function Chk_txtCusName() As Boolean
        Chk_txtCusName = False

        If Trim(txtCusName.Text) = "" Then
            gsMsg = "沒有輸入須要之資料!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            txtCusName.Focus()
            Exit Function
        End If

        Chk_txtCusName = True

    End Function

    Private Function Chk_cboCusSaleCode(ByRef sOutName As Object) As Boolean
        Dim sRetName As String

        sRetName = ""

        Chk_cboCusSaleCode = False

        If Trim(cboCusSaleCode.Text) <> "" Then
            If Chk_CusSaleCode(cboCusSaleCode.Text, wlSalesmanID, sRetName) = False Then
                Me.tabDetailInfo.SelectedIndex = 2
                gsMsg = "營業員編碼不存在!"
                MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
                cboCusSaleCode.Focus()
                Exit Function
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object sOutName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sOutName = sRetName
                Chk_cboCusSaleCode = True
            End If
        Else
            Me.tabDetailInfo.SelectedIndex = 2
            gsMsg = "營業員編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusSaleCode.Focus()
            Exit Function
        End If
    End Function

    Private Function Chk_cboCusPayCode(ByRef sOutName As Object) As Boolean
        Dim sRetName As String

        sRetName = ""

        Chk_cboCusPayCode = False

        If Trim(cboCusPayCode.Text) <> "" Then
            If Chk_CusPayCode(cboCusPayCode.Text, sRetName) = False Then
                Me.tabDetailInfo.SelectedIndex = 2
                gsMsg = "付款條款編碼不存在!"
                MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
                cboCusPayCode.Focus()
                Exit Function
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object sOutName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sOutName = sRetName
            End If
        Else
            Me.tabDetailInfo.SelectedIndex = 2
            gsMsg = "沒有輸入須要資料!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusPayCode.Focus()
            Exit Function
        End If

        Chk_cboCusPayCode = True
    End Function

    Private Function Chk_cboCusShipTerrCode(ByRef sOutName As Object) As Boolean
        Dim sRetName As String

        sRetName = ""

        Chk_cboCusShipTerrCode = False

        If Trim(cboCusShipTerrCode.Text) = "" Then
            Me.tabDetailInfo.SelectedIndex = 1
            gsMsg = "地區編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusShipTerrCode.Focus()
            Exit Function
        End If

        If Chk_CusTerrCode(cboCusShipTerrCode.Text, sRetName) = False Then
            Me.tabDetailInfo.SelectedIndex = 1
            gsMsg = "地區編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusShipTerrCode.Focus()
            Exit Function
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object sOutName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sOutName = sRetName
            Chk_cboCusShipTerrCode = True
        End If
    End Function

    Private Function Chk_CusTerrCode(ByVal inCode As Object, ByRef OutName As String) As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        Chk_CusTerrCode = False

        'UPGRADE_WARNING: Couldn't resolve default property of object inCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Trim(inCode) = "" Then
            Exit Function
        End If

        wsSQL = "SELECT TerrDesc "
        'UPGRADE_WARNING: Couldn't resolve default property of object inCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        wsSQL = wsSQL & " FROM MstTerritory WHERE TerrCode = '" & Set_Quote(inCode) & "' AND TerrStatus='1'"

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
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OutName = ReadRs(rsRcd, "TerrDesc")
        Else
            OutName = ""
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function
        End If

        Chk_CusTerrCode = True

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Private Function Chk_cboCusShipTerrCode2(ByRef OutName As Object) As Boolean
        Dim sRetName As String

        sRetName = ""

        Chk_cboCusShipTerrCode2 = False

        If Trim(cboCusShipTerrCode2.Text) = "" Then
            Me.tabDetailInfo.SelectedIndex = 1
            gsMsg = "地區編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusShipTerrCode2.Focus()
            Exit Function
        End If

        If Chk_CusTerrCode(cboCusShipTerrCode2.Text, sRetName) = False Then
            Me.tabDetailInfo.SelectedIndex = 1
            gsMsg = "地區編碼不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCusShipTerrCode2.Focus()
            Exit Function
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object OutName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OutName = sRetName
            Chk_cboCusShipTerrCode2 = True
        End If
    End Function

    Private Sub cmdOpen()

        Dim newForm As New frmC001

        G = Me.CreateGraphics
        newForm.Top = ((Me.Top * G.DpiY / 1024) + 200) * G.DpiY / 1024
        newForm.Left = ((Me.Left * G.DpiX / 1024) + 200) * G.DpiX / 1024
        G.Dispose()

        newForm.Show()

    End Sub

    Private Sub cmdNew()

        wiAction = AddRec
        Ini_Scr_AfrAct()

    End Sub

    Private Sub cmdEdit()

        wiAction = CorRec
        Ini_Scr_AfrAct()

    End Sub

    Private Sub cmdFind()
        Call OpenPromptForm()
    End Sub

    Private Sub cmdDel()

        wiAction = DelRec
        Ini_Scr_AfrAct()

    End Sub
    Private Sub cmdCancel()
        If tbrProcess.Items.Item(tcSave).Enabled = True Then
            Select Case wiAction
                Case AddRec
                    Call Ini_Scr()
                    Call cmdNew()

                Case CorRec
                    Call UnLockAll(wsConnTime, wsFormID)
                    Call Ini_Scr()
                    Call cmdEdit()

                Case DelRec
                    Call UnLockAll(wsConnTime, wsFormID)
                    Call Ini_Scr()
                    Call cmdDel()
            End Select
        Else
            Call Ini_Scr()
        End If
    End Sub

    Private Function cmdSave() As Boolean
        Dim wsGenDte As String
        Dim wsNo As String
        Dim adcmdSave As New SqlClient.SqlCommand
        Dim wsCode As String
        Dim transaction As SqlClient.SqlTransaction

        On Error GoTo cmdSave_Err

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        wsGenDte = Format(Today, "YYYY/MM/DD")

        If wiAction <> AddRec Then
            If ReadOnlyMode(wsConnTime, wsKeyType, cboCusCode.Text, wsFormID) Then
                gsMsg = "記錄已被鎖定, 現在以唯讀模式開啟!"
                MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
                Cursor = System.Windows.Forms.Cursors.Default
                Return False
            End If
        End If

        If wiAction = DelRec Then
            If MsgBox("你是否確定要刪除此檔案?", MsgBoxStyle.YesNo, gsTitle) = MsgBoxResult.No Then
                cmdCancel()
                Cursor = System.Windows.Forms.Cursors.Default
                Return False
            End If
        Else
            If InputValidation() = False Then
                Cursor = System.Windows.Forms.Cursors.Default
                Return False
            End If
        End If

        If wiAction = AddRec Then
            If Chk_KeyExist() = True Then
                Call GetNewKey()
            End If
        End If

        transaction = cnCon.BeginTransaction()
        adcmdSave.Connection = cnCon

        adcmdSave.CommandText = "USP_C001"
        adcmdSave.CommandType = CommandType.StoredProcedure
        'adcmdSave.Parameters.Refresh()
        SqlClient.SqlCommandBuilder.DeriveParameters(adcmdSave)

        Call SetSPPara(adcmdSave, 1, wiAction)
        Call SetSPPara(adcmdSave, 2, wlKey)
        Call SetSPPara(adcmdSave, 3, IIf(wiAction = AddRec, UCase(txtCusCode.Text), UCase(cboCusCode.Text)))
        Call SetSPPara(adcmdSave, 4, txtCusName.Text)
        Call SetSPPara(adcmdSave, 5, Get_CheckValue(chkInActive))
        Call SetSPPara(adcmdSave, 6, Get_CheckValue(chkBadList))
        Call SetSPPara(adcmdSave, 7, txtCusContactPerson.Text)
        Call SetSPPara(adcmdSave, 8, txtCusTel.Text)
        Call SetSPPara(adcmdSave, 9, txtCusFax.Text)
        Call SetSPPara(adcmdSave, 10, txtCusEmail.Text)

        Call SetSPPara(adcmdSave, 11, txtCusContactPerson1.Text)
        Call SetSPPara(adcmdSave, 12, txtCusAddress1.Text)
        Call SetSPPara(adcmdSave, 13, txtCusAddress2.Text)
        Call SetSPPara(adcmdSave, 14, txtCusAddress3.Text)
        Call SetSPPara(adcmdSave, 15, txtCusAddress4.Text)
        Call SetSPPara(adcmdSave, 16, cboCusRgnCode.Text)
        Call SetSPPara(adcmdSave, 17, "")
        Call SetSPPara(adcmdSave, 18, "")

        Call SetSPPara(adcmdSave, 19, txtCusShipAdd1.Text)
        Call SetSPPara(adcmdSave, 20, txtCusShipAdd2.Text)
        Call SetSPPara(adcmdSave, 21, txtCusShipAdd3.Text)
        Call SetSPPara(adcmdSave, 22, txtCusShipAdd4.Text)
        Call SetSPPara(adcmdSave, 23, txtCusShipContactPerson.Text)
        Call SetSPPara(adcmdSave, 24, txtCusShipTel.Text)
        Call SetSPPara(adcmdSave, 25, txtCusShipFax.Text)
        Call SetSPPara(adcmdSave, 26, cboCusShipTerrCode.Text)
        Call SetSPPara(adcmdSave, 27, txtCusShipTerrName.Text)

        Call SetSPPara(adcmdSave, 28, txtCusShipAdd12.Text)
        Call SetSPPara(adcmdSave, 29, txtCusShipAdd22.Text)
        Call SetSPPara(adcmdSave, 30, txtCusShipAdd32.Text)
        Call SetSPPara(adcmdSave, 31, txtCusShipAdd42.Text)
        Call SetSPPara(adcmdSave, 32, txtCusShipContactPerson2.Text)
        Call SetSPPara(adcmdSave, 33, txtCusShipTel2.Text)
        Call SetSPPara(adcmdSave, 34, txtCusShipFax2.Text)
        Call SetSPPara(adcmdSave, 35, cboCusShipTerrCode2.Text)
        Call SetSPPara(adcmdSave, 36, txtCusShipTerrName2.Text)

        Call SetSPPara(adcmdSave, 37, cboCusPayCode.Text)
        Call SetSPPara(adcmdSave, 38, txtCusPayDesc.Text)
        Call SetSPPara(adcmdSave, 39, wlSalesmanID)
        Call SetSPPara(adcmdSave, 40, cboCusCurr.Text)
        Call SetSPPara(adcmdSave, 41, txtCusCreditLimit.Text)
        Call SetSPPara(adcmdSave, 42, cboCusMLCode.Text)
        Call SetSPPara(adcmdSave, 43, txtCusSpecDis.Text)
        Call SetSPPara(adcmdSave, 44, txtCusRemark.Text)

        Call SetSPPara(adcmdSave, 45, gsUserID)
        Call SetSPPara(adcmdSave, 46, wsGenDte)

        Call SetSPPara(adcmdSave, 47, "CUS")
        Call SetSPPara(adcmdSave, 48, "")

        adcmdSave.ExecuteNonQuery()
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        wsCode = GetSPPara(adcmdSave, 49)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        wsNo = GetSPPara(adcmdSave, 50)

        'cnCon.BeginTrans()
        transaction.Commit()

        If wiAction = AddRec And Trim(wsNo) = "" Then
            gsMsg = "儲存失敗, 請檢查 Store Procedure - C001!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
        Else
            gsMsg = "已成功儲存!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
        End If

        Call cmdCancel()

        'UPGRADE_NOTE: Object adcmdSave may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adcmdSave = Nothing
        cmdSave = True

        Cursor = System.Windows.Forms.Cursors.Default

        Exit Function

cmdSave_Err:
        MsgBox(Err.Description)
        Cursor = System.Windows.Forms.Cursors.Default
        transaction.Rollback()
        'UPGRADE_NOTE: Object adcmdSave may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adcmdSave = Nothing

    End Function

    Private Function SaveData() As Boolean
        SaveData = False

        If (wiAction = AddRec Or wiAction = CorRec Or wiAction = DelRec) And tbrProcess.Items.Item(tcSave).Enabled = True Then
            gsMsg = "你是否確定要儲存現時之作業?"
            If MsgBox(gsMsg, MsgBoxStyle.YesNo, gsTitle) = MsgBoxResult.No Then
                Exit Function
            Else
                If cmdSave() = True Then
                    Exit Function
                End If
            End If
            SaveData = True
        Else
            SaveData = False
        End If
    End Function

    Private Sub txtCusAddress1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress1.Leave
        txtCusAddress1.SelectionLength = 0
    End Sub

    Private Sub txtCusAddress2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress2.Leave
        txtCusAddress2.SelectionLength = 0
    End Sub

    Private Sub txtCusAddress3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress3.Leave
        txtCusAddress3.SelectionLength = 0
    End Sub

    Private Sub txtCusAddress4_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress4.Leave
        txtCusAddress4.SelectionLength = 0
    End Sub

    Private Sub txtCusCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusCode.Enter
        'Call SelObj(txtCusCode)
        txtCusCode.SelectAll()
    End Sub

    Private Sub txtCusCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLenA(txtCusCode, 10, KeyAscii, True)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            If Chk_txtCusCode() = True Then
                Call Ini_Scr_AfrKey()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusCode.Leave
        txtCusCode.SelectionLength = 0
    End Sub

    Private Sub txtCusContactPerson_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusContactPerson.Leave
        txtCusContactPerson.SelectionLength = 0
    End Sub

    Private Sub txtCusContactPerson1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusContactPerson1.Enter
        txtCusContactPerson1.SelectAll()
    End Sub

    Private Sub txtCusContactPerson1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusContactPerson1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusContactPerson1, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            chkBadList.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusContactPerson1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusContactPerson1.Leave
        txtCusContactPerson1.SelectionLength = 0
    End Sub

    Private Sub txtCusCreditLimit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusCreditLimit.Leave
        txtCusCreditLimit.Text = Format(txtCusCreditLimit.Text, gsAmtFmt)
        txtCusContactPerson.SelectionLength = 0
    End Sub

    Private Sub txtCusEmail_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusEmail.Leave
        txtCusEmail.SelectionLength = 0
    End Sub

    Private Sub txtCusFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusFax.Leave
        txtCusFax.SelectionLength = 0
    End Sub

    Private Sub txtCusName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusName.Enter
        txtCusName.SelectAll()
    End Sub

    Private Sub txtCusName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusName, 60, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_txtCusName() = True Then
                txtCusTel.Focus()
            End If

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusName_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusName.Leave
        txtCusName.SelectionLength = 0
    End Sub

    Private Sub txtCusPayDesc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusPayDesc.Leave
        txtCusPayDesc.SelectionLength = 0
    End Sub

    Private Sub txtCusRemark_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusRemark.Leave
        txtCusRemark.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd1.Leave
        txtCusShipAdd1.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd12_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd12.Leave
        txtCusShipAdd12.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd2.Leave
        txtCusShipAdd2.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd22_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd22.Leave
        txtCusShipAdd22.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd3.Leave
        txtCusShipAdd3.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd32_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd32.Leave
        txtCusShipAdd32.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd4_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd4.Leave
        txtCusShipAdd4.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd42_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd42.Leave
        txtCusShipAdd42.SelectionLength = 0
    End Sub

    Private Sub txtCusShipContactPerson_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipContactPerson.Leave
        txtCusShipContactPerson.SelectionLength = 0
    End Sub

    Private Sub txtCusShipContactPerson2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipContactPerson2.Leave
        txtCusShipContactPerson2.SelectionLength = 0
    End Sub

    Private Sub txtCusShipFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipFax.Leave
        txtCusShipFax.SelectionLength = 0
    End Sub

    Private Sub txtCusShipFax2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipFax2.Leave
        txtCusShipFax2.SelectionLength = 0
    End Sub

    Private Sub txtCusShipTel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTel.Leave
        txtCusShipTel.SelectionLength = 0
    End Sub

    Private Sub txtCusShipTel2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTel2.Leave
        txtCusShipTel2.SelectionLength = 0
    End Sub

    Private Sub txtCusShipTerrName_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTerrName.Leave
        txtCusShipTerrName.SelectionLength = 0
    End Sub

    Private Sub txtCusShipTerrName2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTerrName2.Leave
        txtCusShipTerrName2.SelectionLength = 0
    End Sub

    Private Sub txtCusSpecDis_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusSpecDis.Enter
        txtCusSpecDis.SelectAll()
    End Sub

    Private Sub txtCusSpecDis_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusSpecDis.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call Chk_InpNum(KeyAscii, txtCusSpecDis.Text, False, True)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 2
            cboCusMLCode.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusSpecDis_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusSpecDis.Leave
        txtCusSpecDis.Text = Format(txtCusSpecDis.Text, gsAmtFmt)
        txtCusSpecDis.SelectionLength = 0
    End Sub

    Private Sub txtCusTel_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusTel.Enter
        txtCusTel.SelectAll()
    End Sub

    Private Sub txtCusTel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusTel.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusTel, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            txtCusFax.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusFax.Enter
        txtCusFax.SelectAll()
    End Sub

    Private Sub txtCusFax_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusFax.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusFax, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            txtCusContactPerson.Focus()

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusContactPerson_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusContactPerson.Enter
        'Call SelObj(txtCusContactPerson)
        txtCusContactPerson.SelectAll()
    End Sub

    Private Sub txtCusContactPerson_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusContactPerson.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusContactPerson, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            txtCusContactPerson1.Focus()

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusEmail_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusEmail.Enter
        'Call SelObj(txtCusEmail)
        txtCusEmail.SelectAll()
    End Sub

    Private Sub txtCusEmail_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusEmail.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusEmail, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            txtCusName.Focus()

        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkBadList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkBadList.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            chkInActive.Focus()

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkInActive_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkInActive.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 0
            txtCusAddress1.Focus()
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusAddress1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress1.Enter
        If tabDetailInfo.SelectedIndex <> 0 Then tabDetailInfo.SelectedIndex = 0
        txtCusAddress1.SelectAll()
    End Sub

    Private Sub txtCusAddress1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusAddress1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusAddress1, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 0
            txtCusAddress2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusAddress2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress2.Enter
        If tabDetailInfo.SelectedIndex <> 0 Then tabDetailInfo.SelectedIndex = 0
        txtCusAddress2.SelectAll()
    End Sub

    Private Sub txtCusAddress2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusAddress2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusAddress2, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 0
            txtCusAddress3.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusAddress3_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress3.Enter
        If tabDetailInfo.SelectedIndex <> 0 Then tabDetailInfo.SelectedIndex = 0
        txtCusAddress3.SelectAll()
    End Sub

    Private Sub txtCusAddress3_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusAddress3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusAddress3, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 0
            txtCusAddress4.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusAddress4_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusAddress4.Enter
        If tabDetailInfo.SelectedIndex <> 0 Then tabDetailInfo.SelectedIndex = 0
        txtCusAddress4.SelectAll()
    End Sub

    Private Sub txtCusAddress4_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusAddress4.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusAddress4, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 0
            cboCusRgnCode.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusTel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusTel.Leave
        txtCusTel.SelectionLength = 0
    End Sub

    Private Sub txtCusShipAdd1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd1.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd1.SelectAll()
    End Sub

    Private Sub txtCusShipAdd1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd1, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd2.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd2.SelectAll()
    End Sub

    Private Sub txtCusShipAdd2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd2, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd3.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd3_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd3.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd3.SelectAll()
    End Sub

    Private Sub txtCusShipAdd3_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd3, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd4.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd4_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd4.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd4.SelectAll()
    End Sub

    Private Sub txtCusShipAdd4_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd4.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd4, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipContactPerson.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipContactPerson_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipContactPerson.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipContactPerson.SelectAll()
    End Sub

    Private Sub txtCusShipContactPerson_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipContactPerson.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipContactPerson, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipTel.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipTel_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTel.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipTel.SelectAll()
    End Sub

    Private Sub txtCusShipTel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipTel.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipTel, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipFax.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipFax.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipFax.SelectAll()
    End Sub

    Private Sub txtCusShipFax_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipFax.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipFax, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            cboCusShipTerrCode.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipTerrName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTerrName.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipTerrName.SelectAll()
    End Sub

    Private Sub txtCusShipTerrName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipTerrName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipTerrName, 50, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd12.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd12_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd12.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd12.SelectAll()
    End Sub

    Private Sub txtCusShipAdd12_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd12.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd12, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd22.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd22_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd22.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd22.SelectAll()
    End Sub

    Private Sub txtCusShipAdd22_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd22.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd22, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd32.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd32_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd32.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd32.SelectAll()
    End Sub

    Private Sub txtCusShipAdd32_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd32.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd32, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipAdd42.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipAdd42_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipAdd42.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipAdd42.SelectAll()
    End Sub

    Private Sub txtCusShipAdd42_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipAdd42.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipAdd42, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipContactPerson2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipContactPerson2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipContactPerson2.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipContactPerson2.SelectAll()
    End Sub

    Private Sub txtCusShipContactPerson2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipContactPerson2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipContactPerson2, 30, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipTel2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipTel2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTel2.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipTel2.SelectAll()
    End Sub

    Private Sub txtCusShipTel2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipTel2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipTel2, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipFax2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipFax2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipFax2.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipFax2.SelectAll()
    End Sub

    Private Sub txtCusShipFax2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipFax2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipFax2, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 1
            cboCusShipTerrCode2.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusShipTerrName2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusShipTerrName2.Enter
        If tabDetailInfo.SelectedIndex <> 1 Then tabDetailInfo.SelectedIndex = 1
        txtCusShipTerrName2.SelectAll()
    End Sub

    Private Sub txtCusShipTerrName2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusShipTerrName2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusShipTerrName2, 50, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 2
            cboCusPayCode.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusPayDesc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusPayDesc.Enter
        If tabDetailInfo.SelectedIndex <> 2 Then tabDetailInfo.SelectedIndex = 2
        txtCusPayDesc.SelectAll()
    End Sub

    Private Sub txtCusPayDesc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusPayDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusPayDesc, 20, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 2
            cboCusSaleCode.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusCreditLimit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusCreditLimit.Enter
        If tabDetailInfo.SelectedIndex <> 2 Then tabDetailInfo.SelectedIndex = 2
        txtCusCreditLimit.SelectAll()
    End Sub

    Private Sub txtCusCreditLimit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusCreditLimit.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call Chk_InpNum(KeyAscii, txtCusCreditLimit.Text, False, True)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default
            Me.tabDetailInfo.SelectedIndex = 2
            txtCusSpecDis.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCusRemark_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCusRemark.Enter
        If tabDetailInfo.SelectedIndex <> 2 Then tabDetailInfo.SelectedIndex = 2
        txtCusRemark.SelectAll()
    End Sub

    Private Sub txtCusRemark_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCusRemark.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(txtCusRemark, 100, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            txtCusEmail.Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'UPGRADE_WARNING: Event txtSaleID.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtSaleID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSaleID.TextChanged

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        If txtSaleID.Text = "" Then
            Exit Sub
        End If

        wsSQL = "SELECT MstSalesman.SaleCode "
        wsSQL = wsSQL & "From MstSalesman "
        wsSQL = CStr(CDbl(wsSQL & "WHERE (((MstSalesman.SaleID)=") + To_Value(txtSaleID) + CDbl("));"))

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
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboCusSaleCode.Text = ReadRs(rsRcd, "SaleCode")
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Sub

    Private Sub OpenPromptForm()
        ' Dim wsOutCode As String
        Dim sSQL As String

        Dim vFilterAry(9, 2) As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(1, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(1, 1) = "編碼"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(1, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(1, 2) = "CusCode"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(2, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(2, 1) = "名稱"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(2, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(2, 2) = "CusName"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(3, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(3, 1) = "無效"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(3, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(3, 2) = "CusInActive"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(4, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(4, 1) = "黑名單"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(4, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(4, 2) = "CusBadList"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(5, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(5, 1) = "聯絡人"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(5, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(5, 2) = "CusContactPerson"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(6, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(6, 1) = "電話"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(6, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(6, 2) = "CusTel"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(7, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(7, 1) = "傳真"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(7, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(7, 2) = "CusFax"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(8, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(8, 1) = "電郵"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(8, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(8, 2) = "CusEmail"

        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(9, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(9, 1) = "地區"
        'UPGRADE_WARNING: Couldn't resolve default property of object vFilterAry(9, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vFilterAry(9, 2) = "CusTerritory"

        Dim vAry(9, 3) As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(1, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(1, 1) = "編碼"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(1, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(1, 2) = "CusCode"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(1, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(1, 3) = "800"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(2, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(2, 1) = "名稱"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(2, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(2, 2) = "CusName"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(2, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(2, 3) = "2000"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(3, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(3, 1) = "聯絡人"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(3, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(3, 2) = "CusContactPerson"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(3, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(3, 3) = "2000"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(4, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(4, 1) = "電話"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(4, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(4, 2) = "CusTel"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(4, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(4, 3) = "1000"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(5, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(5, 1) = "傳真"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(5, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(5, 2) = "CusFax"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(5, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(5, 3) = "1000"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(6, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(6, 1) = "電郵"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(6, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(6, 2) = "CusEmail"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(6, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(6, 3) = "0"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(7, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(7, 1) = "地區"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(7, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(7, 2) = "CusTerritory"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(7, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(7, 3) = "1600"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(8, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(8, 1) = "無效"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(8, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(8, 2) = "CusInActive"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(8, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(8, 3) = "550"

        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(9, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(9, 1) = "黑名單"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(9, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(9, 2) = "CusBadList"
        'UPGRADE_WARNING: Couldn't resolve default property of object vAry(9, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vAry(9, 3) = "550"

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        With New frmShareSearch
            sSQL = "SELECT MstCustomer.CusCode, MstCustomer.CusName, "
            sSQL = sSQL & "MstCustomer.CusContactPerson, MstCustomer.CusTel, MstCustomer.CusFax, MstCustomer.CusEmail, "
            sSQL = sSQL & "MstCustomer.CusTerritory, MstCustomer.CusInActive, MstCustomer.CusBadList "
            sSQL = sSQL & "FROM MstCustomer "
            .sBindSQL = sSQL
            .sBindWhereSQL = "WHERE MstCustomer.CusStatus = '1' "
            .sBindOrderSQL = "ORDER BY MstCustomer.CusName"
            'UPGRADE_WARNING: Couldn't resolve default property of object frmShareSearch.vHeadDataAry. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '.vHeadDataAry = VB6.CopyArray(vAry)
            vAry.CopyTo(.vHeadDataAry, 0)
            'UPGRADE_WARNING: Couldn't resolve default property of object frmShareSearch.vFilterAry. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '.vFilterAry = VB6.CopyArray(vFilterAry)
            vFilterAry.CopyTo(.vFilterAry, 0)
            .ShowDialog()

            'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
            'UPGRADE_ISSUE: Form property frmC001.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
            Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal
            If Trim(.Tag) <> "" And Trim(.Tag) <> cboCusCode.Text Then
                cboCusCode.Text = Trim(.Tag)
                System.Windows.Forms.SendKeys.Send("{ENTER}")
            End If
            .Close()
        End With
    End Sub

    Public Function Chk_cboCusCurr() As Boolean
        Chk_cboCusCurr = False

        If Trim(cboCusCurr.Text) = "" Then
            Me.tabDetailInfo.SelectedIndex = 2
            gsMsg = "沒有輸入須要之資料!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            cboCusCurr.Focus()
            Exit Function
        End If

        If Chk_CusCurr() = False Then
            gsMsg = "貨幣不存在!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            cboCusCurr.Focus()
            Exit Function
        End If

        Chk_cboCusCurr = True
    End Function

    Public Function Chk_CusCurr() As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim sSQL As String

        sSQL = "SELECT ExcCurr FROM MstExchangeRate WHERE ExcCurr='" & Set_Quote(cboCusCurr.Text) & "' And ExcStatus = '1'"

        'rsRcd.Open(sSQL, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(sSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count < 1 Then
            Chk_CusCurr = False
        Else
            Chk_CusCurr = True
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Private Sub tblCommon_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tblCommon.DoubleClick
        wcCombo.Text = tblCommon.Columns(0).Text
        wcCombo.Focus()
        tblCommon.Visible = False
        System.Windows.Forms.SendKeys.Send("{Enter}")
    End Sub

    Private Sub tblCommon_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles tblCommon.KeyDown
        If eventArgs.KeyCode = System.Windows.Forms.Keys.Escape Then
            'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
            tblCommon.Visible = False
            wcCombo.Focus()
        ElseIf eventArgs.KeyCode = System.Windows.Forms.Keys.Return Then
            'eventArgs.KeyCode = 0 ' System.Windows.Forms.Cursors.Default
            wcCombo.Text = tblCommon.Columns(0).Text

            tblCommon.Visible = False
            wcCombo.Focus()
            System.Windows.Forms.SendKeys.Send("{Enter}")
        End If
    End Sub

    Private Sub tblCommon_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tblCommon.Leave


        On Error GoTo tblCommon_LostFocus_Err

        tblCommon.Visible = False
        If wcCombo.Enabled = True Then
            wcCombo.Focus()
        Else
            'UPGRADE_NOTE: Object wcCombo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            wcCombo = Nothing
        End If

        Exit Sub
tblCommon_LostFocus_Err:

        'UPGRADE_NOTE: Object wcCombo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        wcCombo = Nothing

    End Sub

    Private Sub cboCusCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCode.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusCode

        wsSQL = "SELECT CusCode, CusName FROM MstCustomer WHERE CusStatus = '1'"
        wsSQL = wsSQL & " AND CusCode LIKE '%" & IIf(cboCusCode.SelectionLength > 0, "", Set_Quote(cboCusCode.Text)) & "%' "

        wsSQL = wsSQL & "ORDER BY CusCode "

        location = Get_Control_Location(cboCusCode)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusCode.Height, tblCommon, "C001", "TBLC", Me.Width, Me.Height)

        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(cboCusCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If chk_cboCusCode() = True Then
                Call Ini_Scr_AfrKey()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCode.Enter
        cboCusCode.SelectAll()
    End Sub

    Private Sub cboCusCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCode.Leave
        cboCusCode.SelectionLength = 0
    End Sub

    Private Sub cboCusShipTerrCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusShipTerrCode

        wsSQL = "SELECT TerrCode, TerrDesc FROM MstTerritory WHERE TerrStatus = '1'"
        wsSQL = wsSQL & "ORDER BY TerrCode "
        location = Get_Control_Location(cboCusShipTerrCode)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusShipTerrCode.Height, tblCommon, "C001", "TBLTERR", Me.Width, Me.Height)

        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusShipTerrCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusShipTerrCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim sShipTerritory As String = String.Empty

        Call chk_InpLen(cboCusShipTerrCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusShipTerrCode(sShipTerritory) = True Then
                If wsOldShipTerr <> cboCusShipTerrCode.Text Then
                    txtCusShipTerrName.Text = sShipTerritory
                    wsOldShipTerr = cboCusShipTerrCode.Text
                End If
                Me.tabDetailInfo.SelectedIndex = 1
                txtCusShipTerrName.Focus()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusShipTerrCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode.Enter
        cboCusShipTerrCode.SelectAll()
    End Sub

    Private Sub cboCusShipTerrCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode.Leave
        cboCusShipTerrCode.SelectionLength = 0
    End Sub

    Private Sub cboCusShipTerrCode2_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode2.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusShipTerrCode2

        wsSQL = "SELECT TerrCode, TerrDesc FROM MstTerritory WHERE TerrStatus = '1'"
        wsSQL = wsSQL & "ORDER BY TerrCode "
        location = Get_Control_Location(cboCusShipTerrCode2)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusShipTerrCode2.Height, tblCommon, "C001", "TBLTERR", Me.Width, Me.Height)

        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusShipTerrCode2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusShipTerrCode2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim sShipTerritory2 As String = String.Empty

        Call chk_InpLen(cboCusShipTerrCode2, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            'If Chk_cboCusShipTerrCode2(sShipTerritory2) = True Then
            If wsOldShipTerr2 <> cboCusShipTerrCode2.Text Then
                txtCusShipTerrName2.Text = sShipTerritory2
                wsOldShipTerr2 = cboCusShipTerrCode2.Text
            End If
            Me.tabDetailInfo.SelectedIndex = 1
            txtCusShipTerrName2.Focus()
            'End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusShipTerrCode2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode2.Enter
        cboCusShipTerrCode2.SelectAll()
    End Sub

    Private Sub cboCusShipTerrCode2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusShipTerrCode2.Leave
        cboCusShipTerrCode2.SelectionLength = 0
    End Sub

    Private Sub cboCusPayCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusPayCode.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusPayCode

        wsSQL = "SELECT PayCode, PayDesc, PayDay FROM MstPayTerm WHERE PayStatus = '1'"
        wsSQL = wsSQL & "ORDER BY PayCode "
        location = Get_Control_Location(cboCusPayCode)
        Call Ini_Combo(3, wsSQL, location.X, location.Y + cboCusPayCode.Height, tblCommon, "C001", "TBLPYT", Me.Width, Me.Height)
        
        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusPayCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusPayCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim sPayDesc As String = String.Empty

        Call chk_InpLen(cboCusPayCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusPayCode(sPayDesc) = True Then
                If wsOldPayCode <> cboCusPayCode.Text Then
                    txtCusPayDesc.Text = sPayDesc
                    wsOldPayCode = cboCusPayCode.Text
                End If
                Me.tabDetailInfo.SelectedIndex = 2
                txtCusPayDesc.Focus()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusPayCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusPayCode.Enter
        cboCusPayCode.SelectAll()
    End Sub

    Private Sub cboCusPayCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusPayCode.Leave
        cboCusPayCode.SelectionLength = 0
    End Sub

    Private Sub cboCusCurr_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCurr.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusCurr

        wsSQL = "SELECT DISTINCT ExcCurr FROM MstExchangeRate WHERE ExcStatus = '1'"
        wsSQL = wsSQL & "ORDER BY ExcCurr "
        location = Get_Control_Location(cboCusCurr)
        Call Ini_Combo(1, wsSQL, location.X, location.Y + cboCusCurr.Height, tblCommon, "C001", "TBLCUR", Me.Width, Me.Height)
        
        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusCurr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusCurr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Call chk_InpLen(cboCusCurr, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusCurr() = True Then
                txtCusCreditLimit.Focus()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusCurr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCurr.Enter
        cboCusCurr.SelectAll()
    End Sub

    Private Sub cboCusCurr_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusCurr.Leave
        cboCusCurr.SelectionLength = 0
    End Sub

    Private Sub cboCusSaleCode_DropDown(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusSaleCode.DropDown
        Dim wsSQL As String
        Dim location As Point

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        wcCombo = cboCusSaleCode

        wsSQL = "SELECT SaleCode, SaleName FROM MstSalesman WHERE SaleStatus = '1'"
        wsSQL = wsSQL & " and SaleType = 'S' "
        wsSQL = wsSQL & "ORDER BY SaleCode "
        location = Get_Control_Location(cboCusSaleCode)
        Call Ini_Combo(2, wsSQL, location.X, location.Y + cboCusSaleCode.Height, tblCommon, "C001", "TBLSLM", Me.Width, Me.Height)

        tblCommon.Visible = True
        tblCommon.BringToFront()
        tblCommon.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCusSaleCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboCusSaleCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim sSalesName As String = String.Empty

        Call chk_InpLen(cboCusSaleCode, 10, KeyAscii)

        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0 ' System.Windows.Forms.Cursors.Default

            If Chk_cboCusSaleCode(sSalesName) = True Then
                If wsOldSaleCode <> cboCusSaleCode.Text Then
                    lblDspCusSaleName.Text = sSalesName
                    wsOldSaleCode = cboCusSaleCode.Text
                End If
                Me.tabDetailInfo.SelectedIndex = 2
                cboCusCurr.Focus()
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cboCusSaleCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusSaleCode.Enter
        cboCusSaleCode.SelectAll()
    End Sub

    Private Sub cboCusSaleCode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCusSaleCode.Leave
        cboCusSaleCode.SelectionLength = 0
    End Sub

    Private Function Chk_KeyExist() As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        wsSQL = "SELECT CusStatus FROM MstCustomer WHERE CusCode = '" & Set_Quote(txtCusCode.Text) & "'"
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
            Chk_KeyExist = True
        Else
            Chk_KeyExist = False
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Private Sub GetNewKey()
        Dim Newfrm As New frmKeyInput

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Create Selection Criteria
        With Newfrm
            .TableID = wsKeyType
            .TableType = wsTrnCd
            .TableKey = "CusCode"
            .KeyLen = 10
            .ctlKey = txtCusCode
            .ShowDialog()
        End With

        'UPGRADE_NOTE: Object Newfrm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Newfrm = Nothing
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Function Chk_cboCusMLCode() As Boolean
        Dim wsDesc As String = String.Empty
        Chk_cboCusMLCode = False

        If Trim(cboCusMLCode.Text) = "" Then
            gsMsg = "必須輸入會計號!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            tabDetailInfo.SelectedIndex = 2
            cboCusMLCode.Focus()
            Exit Function
        End If

        If Chk_MerchClass(cboCusMLCode.Text, wsDesc) = False Then
            gsMsg = "無此會計號!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            tabDetailInfo.SelectedIndex = 2
            cboCusMLCode.Focus()
            lblDspCusMLDesc.Text = ""
            Exit Function
        End If

        lblDspCusMLDesc.Text = wsDesc

        Chk_cboCusMLCode = True
    End Function

    Private Function Chk_cboCusRgnCode() As Boolean
        Dim wsDesc As String = String.Empty
        Chk_cboCusRgnCode = False

        If Trim(cboCusRgnCode.Text) = "" Then
            gsMsg = "必須輸入銷售區域!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            tabDetailInfo.SelectedIndex = 0
            cboCusRgnCode.Focus()
            Exit Function
        End If


        If Chk_Region(cboCusRgnCode.Text, wsDesc) = False Then
            gsMsg = "無此銷售區域!"
            MsgBox(gsMsg, MsgBoxStyle.OkOnly, gsTitle)
            tabDetailInfo.SelectedIndex = 0
            cboCusRgnCode.Focus()
            lblDspCusRgnDesc.Text = ""
            Exit Function
        End If

        lblDspCusRgnDesc.Text = wsDesc

        Chk_cboCusRgnCode = True
    End Function

    Private Function IsEmptyRow(Optional ByRef inRow As Object = Nothing) As Boolean

        IsEmptyRow = True

        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(inRow) Then
            With tblDetail
                If Trim(.Columns(PERIOD).Text) = "" Then
                    Exit Function
                End If
            End With
        Else
            If waResult.Columns.Count >= 0 Then
                If Trim(waResult.Rows(inRow).Item(PERIOD)) = "" And Trim(waResult.Rows(inRow).Item(SALES)) = "" And Trim(waResult.Rows(inRow).Item(DEPOSIT)) = "" And Trim(waResult.Rows(inRow).Item(BALID)) = "" Then
                    Exit Function
                End If
            End If
        End If

        IsEmptyRow = False

    End Function

    Private Function LoadSaleInfo() As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String
        'Dim wiCtr As Integer
        Dim wsYYYY As String
        Dim wsMM As String

        'Dim wdARBal As Double
        Dim wdOpnBal As Double
        Dim wdTotBal As Double
        Dim wdCMQty As Double
        Dim wdCYQty As Double
        Dim wdTotQty As Double
        Dim wdCMSal As Double
        Dim wdCYSal As Double
        Dim wdTotSal As Double
        Dim wdCMNet As Double
        Dim wdCYNet As Double
        Dim wdTotNet As Double
        Dim wdAmt As Double


        wsYYYY = gsSystemDate.Substring(0, 4)
        wsMM = Mid(gsSystemDate, 6, 2)


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LoadSaleInfo = False

        Call Get_CusSaleInfo(wlKey, wsYYYY, wsMM, 0, 0, wdOpnBal, wdTotBal, wdCMQty, wdCYQty, wdTotQty, wdCMSal, wdCYSal, wdTotSal, wdCMNet, wdCYNet, wdTotNet)

        lblDspARBal.Text = Format(wdTotBal, gsAmtFmt)
        lblDspOpenBal.Text = Format(wdOpnBal, gsAmtFmt)
        lblDspCloseBal.Text = Format(wdTotBal, gsAmtFmt)

        lblDspAcmSaleQty.Text = Format(wdTotQty, gsQtyFmt)
        lblDspAcmSaleNet.Text = Format(wdTotNet, gsAmtFmt)
        lblDspAcmSaleAmt.Text = Format(wdTotSal, gsAmtFmt)

        lblDspAcmYrSaleQty.Text = Format(wdCYQty, gsQtyFmt)
        lblDspAcmYrSaleNet.Text = Format(wdCYNet, gsAmtFmt)
        lblDspAcmYrSaleAmt.Text = Format(wdCYSal, gsAmtFmt)

        lblDspAcmMnSaleQty.Text = Format(wdCMQty, gsQtyFmt)
        lblDspAcmMnSaleNet.Text = Format(wdCMNet, gsAmtFmt)
        lblDspAcmMnSaleAmt.Text = Format(wdCMSal, gsAmtFmt)


        wsSQL = "SELECT SOHDCTLPRD, SUM(SODTNETL) NETL "
        wsSQL = wsSQL & " FROM SOASOHD, SOASODT "
        wsSQL = wsSQL & " WHERE SOHDCUSID = " & wlKey
        wsSQL = wsSQL & " AND SOHDDOCID = SODTDOCID "
        wsSQL = wsSQL & " AND SOHDSTATUS IN ('1','4') "
        wsSQL = wsSQL & " AND SOHDCTLPRD >= '" & wsYYYY & "01" & "'"
        wsSQL = wsSQL & " GROUP BY SOHDCTLPRD "
        wsSQL = wsSQL & " ORDER BY SOHDCTLPRD "

        'rsRcd.Open(wsSQL, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count <= 0 Then
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            'waResult.ReDim(0, -1, PERIOD, BALID)
            tblDetail.Rebind(True)
            tblDetail.Bookmark = 0
            'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
            'UPGRADE_ISSUE: Form property frmC001.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
            Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal
            Exit Function
        End If


        Dim dr As System.Data.DataRow
        For Each dr In waResult.Rows
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            wdAmt = Get_CusCreditAmt(wlKey, ReadRs(rsRcd, "SOHDCTLPRD"))

            Dim newRow As System.Data.DataRow = waResult.NewRow()
            newRow(PERIOD) = ReadRs(rsRcd, "SOHDCTLPRD")
            newRow(BALID) = ReadRs(rsRcd, "SOHDCTLPRD")
            newRow(SALES) = Format(To_Value(ReadRs(rsRcd, "NETL")), gsAmtFmt)
            newRow(DEPOSIT) = Format(wdAmt, gsAmtFmt)
            waResult.Rows.Add(newRow)
        Next


        'With waResult
        '    .ReDim(0, -1, PERIOD, BALID)
        '    rsRcd.MoveFirst()
        '    Do Until rsRcd.EOF

        '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        wdAmt = Get_CusCreditAmt(wlKey, ReadRs(rsRcd, "SOHDCTLPRD"))

        '        .AppendRows()
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        waResult.get_Value(.get_UpperBound(1), PERIOD) = ReadRs(rsRcd, "SOHDCTLPRD")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        waResult.get_Value(.get_UpperBound(1), BALID) = ReadRs(rsRcd, "SOHDCTLPRD")
        '        waResult.get_Value(.get_UpperBound(1), SALES) = VB6.Format(To_Value(ReadRs(rsRcd, "NETL")), gsAmtFmt)
        '        waResult.get_Value(.get_UpperBound(1), DEPOSIT) = VB6.Format(wdAmt, gsAmtFmt)
        '        rsRcd.MoveNext()
        '    Loop
        'End With

        tblDetail.Rebind(True)
        tblDetail.Bookmark = 0



        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing


        LoadSaleInfo = True
        'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
        'UPGRADE_ISSUE: Form property frmC001.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal

    End Function
End Class