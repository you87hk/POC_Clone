Public Class nbMain

    Dim wsFormID As String
    Dim G As Graphics

    Private Const tcPrev As String = "toolBarPrev"
    Private Const tcNext As String = "toolBarNext"
    Private Const tcOK As String = "toolBarOK"
    Private Const tcCancel As String = "toolBarCancel"
    Private Const tcExit As String = "toolBarExit"

    Dim waFileSub As New System.Data.DataTable
    Dim waMasterSub As New System.Data.DataTable
    Dim waOperationSub As New System.Data.DataTable
    Dim waPOSub As New System.Data.DataTable
    Dim waInventorySub As New System.Data.DataTable
    Dim waACCOUNTSub As New System.Data.DataTable
    Dim waInquirySub As New System.Data.DataTable
    Dim waReportSub As New System.Data.DataTable
    Dim waUtilitySub As New System.Data.DataTable
    Dim waAccRptSub As New System.Data.DataTable
    Dim waListSub As New System.Data.DataTable

    Dim waScrItm As New System.Data.DataTable
    Private waScrToolTip As New System.Data.DataTable

    Private Sub nbMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IniForm()
        Call Ini_Menu()
        'Call Ini_TreeView()
    End Sub

    Private Sub IniForm()
        Me.KeyPreview = True
        Me.Left = 0
        Me.Top = 0
        Me.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        G = Me.CreateGraphics()
        Me.Height = 7500 * G.DpiX / 1024
        G.Dispose()

        wsFormID = "MAIN"

        giCurrIndex = -1

        With tbrMain
            .Items.Item(tcPrev).Enabled = False
            .Items.Item(tcNext).Enabled = False
        End With
    End Sub

    Private Sub ChgPrevPage()
        If giCurrIndex = 0 Then
            tbrMain.Items.Item(tcPrev).Enabled = False
        End If

        If giCurrIndex <> -1 Then

            Call Call_Pgm(waFileSub, 0, UCase(cboCommand.Items(giCurrIndex).Text), 1)
            giCurrIndex = giCurrIndex - 1
            tbrMain.Items.Item(tcNext).Enabled = True

        End If
    End Sub

    Private Sub ChgNextPage()
        giCurrIndex = giCurrIndex + 1

        If giCurrIndex = cboCommand.Items.Count - 1 Then
            tbrMain.Items.Item(tcNext).Enabled = False
        End If

        If giCurrIndex < cboCommand.Items.Count Then

            Call Call_Pgm(waFileSub, 0, UCase(cboCommand.Items(giCurrIndex).Text), 1)
            tbrMain.Items.Item(tcPrev).Enabled = True

        End If
    End Sub

    Private Sub cmdCancel()
        Dim giFormIndex As Object

        cboCommand.Items.Clear()
        cboCommand.Text = ""
        'UPGRADE_WARNING: Couldn't resolve default property of object giFormIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        giFormIndex = 0
        With tbrMain
            .Items.Item(tcPrev).Enabled = False
            .Items.Item(tcNext).Enabled = False
        End With

    End Sub

    Private Sub Call_Pgm(ByVal inArray As System.Data.DataTable, ByRef inPgmIdx As Short, Optional ByRef inPgmName As Object = Nothing, Optional ByRef inNotAdd As Object = Nothing)

        Dim newForm As System.Windows.Forms.Form
        Dim wsFName As String

        On Error GoTo Err_Handler

        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(inPgmName) Then
            wsFName = inArray.Rows(inPgmIdx).Item(0)
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object inPgmName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            wsFName = inPgmName
        End If

        If Chk_PgmExist(wsFName) = False Then
            gsMsg = "畫面不存在!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCommand.Focus()
            Exit Sub
        End If


        If Chk_UserRight(gsUserID, UCase(wsFName)) = False Then
            gsMsg = "使用者權限不足!"
            MsgBox(gsMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsTitle)
            cboCommand.Focus()
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Select Case wsFName
            Case "EXIT"
                Me.Close()

                'Case "CMP001"
                '    newForm = New frmCMP001
                '    newForm.ShowDialog()

                'Case "SYS001"
                '    newForm = New frmSYS001
                '    newForm.ShowDialog()

                'Case "SYS002"
                '    newForm = New frmSYS002
                '    newForm.Show()

                'Case "WS001"
                '    newForm = New frmWS001
                '    newForm.ShowDialog()

                'Case "VOU001"
                '    newForm = New frmVOU001
                '    newForm.Show()


                'Case "OPN001"
                '    newForm = New frmOPN001
                '    newForm.ShowDialog()

                'Case "OPN002"
                '    newForm = New frmOPN002
                '    newForm.ShowDialog()

                'Case "UC001"
                '    newForm = New frmUC001
                '    newForm.ShowDialog()


                ''''
            Case "C001"
                newForm = New frmC001
                newForm.ShowDialog()

                'Case "V001"
                '    newForm = New frmV001
                '    newForm.Show()

                'Case "SLM001"
                '    newForm = New frmSLM001
                '    newForm.Show()

                'Case "STF001"
                '    newForm = New frmSTF001
                '    newForm.Show()


                'Case "ITM001"
                '    newForm = New frmITM001
                '    newForm.Show()



                'Case "PYT001"
                '    newForm = New frmPYT001
                '    newForm.Show()

                'Case "PR001"
                '    newForm = New frmPR001
                '    newForm.Show()

                'Case "EXC001"
                '    newForm = New frmEXC001
                '    newForm.Show()

                'Case "UOM001"
                '    newForm = New frmUOM001
                '    newForm.Show()

                'Case "IP001"
                '    newForm = New frmIP001
                '    newForm.Show()

                'Case "SHP001"
                '    newForm = New frmSHP001
                '    newForm.Show()

                'Case "RMK001"
                '    newForm = New frmRmk001
                '    newForm.Show()

                'Case "WH001"
                '    newForm = New frmWH001
                '    newForm.Show()

                'Case "IT001"
                '    newForm = New frmIT001
                '    newForm.Show()

                'Case "PT001"
                '    newForm = New frmPT001
                '    newForm.Show()

                'Case "RGN001"
                '    newForm = New frmRGN001
                '    newForm.Show()


                'Case "COA001"
                '    newForm = New frmCOA001
                '    newForm.Show()

                'Case "ML001"
                '    newForm = New frmML001
                '    newForm.Show()

                'Case "M001"
                '    newForm = New frmM001
                '    newForm.Show()

                'Case "N001"
                '    newForm = New frmN001
                '    newForm.Show()

                'Case "TERR001"
                '    newForm = New frmTerr001
                '    newForm.Show()


                'Case "SHP001"
                '    newForm = New frmSHP001
                '    newForm.Show()

                'Case "AT001"
                '    newForm = New frmAT001
                '    newForm.Show()

                'Case "CAT001"
                '    newForm = New frmCAT001
                '    newForm.Show()

                '    ''''
            Case "SN001"
                newForm = New frmSN001
                newForm.Show()

                'Case "SO001"
                '    newForm = New frmSO001
                '    newForm.Show()


                'Case "VQ001"
                '    newForm = New frmVQ001
                '    newForm.Show()


                ''     Case "SPL001"
                ''     Set newForm = New frmSPL001
                ''       newForm.Show

                'Case "SDN001"
                '    newForm = New frmSDN001
                '    newForm.Show()

                'Case "INV001"
                '    newForm = New frmINV001
                '    newForm.Show()


                'Case "APR001"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.FormID = "APR001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.TrnCd = "SN"
                '        .Show()
                '    End With


                'Case "APR002"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.FormID = "APR002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.TrnCd = "SO"
                '        .Show()
                '    End With

                'Case "APR003"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.FormID = "APR003"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.TrnCd = "SP"
                '        .Show()
                '    End With

                'Case "APR004"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.FormID = "APR004"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        ''.TrnCd = "SD"
                '        .Show()
                '    End With

                'Case "APR005"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APR005"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "IV"
                '        .Show()
                '    End With


                'Case "APR006"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APR006"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SW"
                '        .Show()
                '    End With

                'Case "APR007"
                '    newForm = New frmAPR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APR007"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "VQ"
                '        .Show()
                '    End With

                'Case "APW001"
                '    newForm = New frmAPW001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APW001"
                '        .Show()
                '    End With


                '    '''' Purchase Order

                'Case "MRP001"
                '    newForm = New frmMRP001
                '    newForm.Show()

                'Case "MRP002"
                '    newForm = New frmMRP002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "MRP002"
                '        .Show()
                '    End With

                'Case "PO001"
                '    newForm = New frmPO001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "PO001"
                '        .Show()
                '    End With

                'Case "PN001"
                '    newForm = New frmPO001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "PN001"
                '        .Show()
                '    End With

                'Case "PGV001"
                '    newForm = New frmPGV001
                '    newForm.Show()

                'Case "GRV001"
                '    newForm = New frmGRV001
                '    newForm.Show()


                'Case "PGR001"
                '    newForm = New frmPGR001
                '    newForm.Show()

                'Case "APV001"
                '    newForm = New frmAPV001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APV001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PO"
                '        .Show()
                '    End With

                'Case "APP001"
                '    newForm = New frmAPP001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APP001"
                '        .Show()
                '    End With


                'Case "APV002"
                '    newForm = New frmAPV001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APV002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PV"
                '        .Show()
                '    End With

                'Case "APV003"
                '    newForm = New frmAPV001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APV003"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PR"
                '        .Show()
                '    End With


                'Case "APV004"
                '    newForm = New frmAPV001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APV004"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "GR"
                '        .Show()
                '    End With

                '    ''''''''''''Inventory


                'Case "TRF001"
                '    newForm = New frmTRF001
                '    newForm.Show()

                'Case "ADJ001"
                '    newForm = New frmADJ001
                '    newForm.Show()

                'Case "SAM001"
                '    newForm = New frmSAM001
                '    newForm.Show()

                'Case "DAM001"
                '    newForm = New frmDAM001
                '    newForm.Show()

                'Case "SKT001"
                '    newForm = New frmSKT001
                '    newForm.Show()

                'Case "SCT001"
                '    newForm = New frmSCT001
                '    newForm.Show()


                'Case "APS001"
                '    newForm = New frmAPS001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APS001"
                '        .Show()
                '    End With

                '    ''''''''''''

                'Case "USR001"
                '    newForm = New frmUSR001
                '    newForm.Show()


                'Case "CHGPWD"
                '    newForm = New frmCHGPWD
                '    newForm.ShowDialog()


                'Case "USRRHT"
                '    newForm = New frmUSRRHT
                '    newForm.ShowDialog()

                'Case "PURGE"
                '    newForm = New frmPURGE
                '    newForm.ShowDialog()

                'Case "HHIM001"
                '    newForm = New frmHHIM001
                '    newForm.ShowDialog()


                '-----------AR

                'Case "AR001"
                '    newForm = New frmAR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "AR001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "62"
                '        .Show()
                '    End With

                'Case "ARDN001"
                '    newForm = New frmAR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "ARDN001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "61"
                '        .Show()
                '    End With

                'Case "ARCN001"
                '    newForm = New frmAR001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "ARCN001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "60"
                '        .Show()
                '    End With

                'Case "AR002"
                '    newForm = New frmAR002
                '    newForm.Show()

                'Case "AR003"
                '    newForm = New frmAR003
                '    newForm.Show()

                'Case "AR003"
                '    newForm = New frmAR003
                '    newForm.Show()

                'Case "AR100"
                '    newForm = New frmAR100
                '    newForm.Show()

                'Case "AR101"
                '    newForm = New frmAR101
                '    newForm.Show()

                'Case "ARPE000"
                '    newForm = New frmARPE000
                '    newForm.Show()

                '    '-----------AP

                'Case "AP001"
                '    newForm = New frmAP001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "AP001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "20"
                '        .Show()
                '    End With

                'Case "APCN001"
                '    newForm = New frmAP001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "APCN001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "21"
                '        .Show()
                '    End With

                'Case "AP002"
                '    newForm = New frmAP002
                '    newForm.Show()

                'Case "AP003"
                '    newForm = New frmAP003
                '    newForm.Show()

                'Case "AP003"
                '    newForm = New frmAP003
                '    newForm.Show()

                'Case "AP100"
                '    newForm = New frmAP100
                '    newForm.Show()

                'Case "AP101"
                '    newForm = New frmAP101
                '    newForm.Show()

                'Case "SIGN002"
                '    newForm = New frmSIGN002
                '    newForm.Show()

                '    '-----------GL

                'Case "GL001"
                '    newForm = New frmGL001
                '    newForm.Show()

                'Case "GL002"
                '    newForm = New frmGL002
                '    newForm.Show()

                '    '----------Acc Prt

                'Case "VOU002"
                '    newForm = New frmVOU002
                '    newForm.ShowDialog()

                'Case "COA002"
                '    newForm = New frmCOA002
                '    newForm.ShowDialog()


                '    '-----------

                'Case "ARL001"
                '    newForm = New frmARL001
                '    newForm.ShowDialog()

                'Case "ARL002"
                '    newForm = New frmARL002
                '    newForm.ShowDialog()

                'Case "ARL003"
                '    newForm = New frmARL003
                '    newForm.ShowDialog()

                'Case "ARL004"
                '    newForm = New frmARL004
                '    newForm.ShowDialog()

                'Case "ARL005"
                '    newForm = New frmARL005
                '    newForm.ShowDialog()

                'Case "ARL006"
                '    newForm = New frmARL006
                '    newForm.ShowDialog()

                'Case "ARL007"
                '    newForm = New frmARL007
                '    newForm.ShowDialog()

                'Case "ARL008"
                '    newForm = New frmARL008
                '    newForm.ShowDialog()

                'Case "ARL009"
                '    newForm = New frmARL009
                '    newForm.ShowDialog()

                'Case "ARL010"
                '    newForm = New frmARL010
                '    newForm.ShowDialog()

                'Case "ARL011"
                '    newForm = New frmARL011
                '    newForm.ShowDialog()

                'Case "ARL012"
                '    newForm = New frmARL012
                '    newForm.ShowDialog()
                '    '-----------

                'Case "APL001"
                '    newForm = New frmAPL001
                '    newForm.ShowDialog()

                'Case "APL002"
                '    newForm = New frmAPL002
                '    newForm.ShowDialog()

                'Case "APL003"
                '    newForm = New frmAPL003
                '    newForm.ShowDialog()

                'Case "APL004"
                '    newForm = New frmAPL004
                '    newForm.ShowDialog()

                'Case "APL005"
                '    newForm = New frmAPL005
                '    newForm.ShowDialog()

                'Case "APL006"
                '    newForm = New frmAPL006
                '    newForm.ShowDialog()

                'Case "APL007"
                '    newForm = New frmAPL007
                '    newForm.ShowDialog()

                'Case "APL008"
                '    newForm = New frmAPL008
                '    newForm.ShowDialog()

                'Case "APL009"
                '    newForm = New frmAPL009
                '    newForm.ShowDialog()

                'Case "APL010"
                '    newForm = New frmAPL010
                '    newForm.ShowDialog()

                '    '-----------------------
                'Case "GLP001"
                '    newForm = New frmGLP001
                '    newForm.ShowDialog()

                'Case "GLP002"
                '    newForm = New frmGLP002
                '    newForm.ShowDialog()

                'Case "GLP003"
                '    newForm = New frmGLP003
                '    newForm.ShowDialog()

                'Case "GLP004"
                '    newForm = New frmGLP004
                '    newForm.ShowDialog()

                'Case "GLP005"
                '    newForm = New frmGLP005
                '    newForm.ShowDialog()

                'Case "GLP006"
                '    newForm = New frmGLP006
                '    newForm.ShowDialog()
                '' Job Cost


                '       Case "CST001"
                '           Set newForm = New frmCST001
                '           newForm.Show

                '       Case "CT001"
                '           Set newForm = New frmCT001
                '           newForm.Show

                '' Reporting

                'Case "SN002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SN002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SN"
                '        .Show()
                '    End With


                'Case "SN002D"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SN002D"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SN"
                '        .Show()
                '    End With

                'Case "SO002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SO002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SO"
                '        .Show()
                '    End With


                'Case "SO002D"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SO002D"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SO"
                '        .Show()
                '    End With

                'Case "SPL002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SPL002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SP"
                '        .Show()
                '    End With


                'Case "SDN002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "SDN002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SD"
                '        .Show()
                '    End With


                'Case "INV002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INV002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "IV"
                '        .Show()
                '    End With

                'Case "PO002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "PO002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PO"
                '        .Show()
                '    End With

                'Case "PGV002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "PGV002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PV"
                '        .Show()
                '    End With

                'Case "GRV002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "GRV002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "GR"
                '        .Show()
                '    End With


                'Case "PGR002"
                '    newForm = New frmSN002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "PGR002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PR"
                '        .Show()
                '    End With

                '    ''''''''''''''''''
                'Case "JOB001"
                '    newForm = New frmJOB002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "JOB001"
                '        .Show()
                '    End With


                'Case "JOB002"
                '    newForm = New frmJOB002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "JOB002"
                '        .Show()
                '    End With


                'Case "JOB003"
                '    newForm = New frmJOB002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "JOB003"
                '        .Show()
                '    End With


                'Case "JOB004"
                '    newForm = New frmJOB002
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "JOB004"
                '        .Show()
                '    End With

                '    ' Case "SOP000B"
                '    '     Set newForm = New frmSOP000B
                '    '     newForm.Show

                'Case "SIGN001"
                '    newForm = New frmSIGN001
                '    newForm.Show()

                'Case "ITM002"
                '    newForm = New frmITM002
                '    newForm.Show()

                '    ''''' Sales Report

                'Case "SOP000"
                '    newForm = New frmSOP000
                '    newForm.Show()

                'Case "SOP003"
                '    newForm = New frmSOP003
                '    newForm.Show()

                'Case "SOP004"
                '    newForm = New frmSOP004
                '    newForm.Show()

                'Case "SOP006"
                '    newForm = New frmSOP006
                '    newForm.Show()

                'Case "SOP008"
                '    newForm = New frmSOP008
                '    newForm.Show()

                'Case "SOP010"
                '    newForm = New frmSOP010
                '    newForm.Show()

                'Case "SOP020"
                '    newForm = New frmSOP020
                '    newForm.Show()

                'Case "SOP030"
                '    newForm = New frmSOP030
                '    newForm.Show()

                'Case "ICP001"
                '    newForm = New frmICP001
                '    newForm.Show()

                'Case "ICP002"
                '    newForm = New frmICP002
                '    newForm.Show()

                'Case "ICP003"
                '    newForm = New frmICP003
                '    newForm.Show()

                'Case "ICP004"
                '    newForm = New frmICP004
                '    newForm.Show()

                'Case "ICP005"
                '    newForm = New frmICP005
                '    newForm.Show()

                'Case "ICP006"
                '    newForm = New frmICP006
                '    newForm.Show()

                '    '''' Inquiry

                'Case "INQ001"
                '    newForm = New frmINQ001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INQ001"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SO"
                '        .Show()
                '    End With

                'Case "INQ002"
                '    newForm = New frmINQ001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INQ002"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "IV"
                '        .Show()
                '    End With


                'Case "INQ003"
                '    newForm = New frmINQ003
                '    newForm.Show()

                'Case "INQ004"
                '    newForm = New frmINQ001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INQ004"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PO"
                '        .Show()
                '    End With

                'Case "INQ005"
                '    newForm = New frmINQ001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INQ005"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "PV"
                '        .Show()
                '    End With


                'Case "INQ006"
                '    newForm = New frmINQ006
                '    newForm.Show()

                'Case "INQ007"
                '    newForm = New frmINQ007
                '    newForm.Show()

                'Case "INQ008"
                '    newForm = New frmINQ008
                '    newForm.Show()

                'Case "INQ009"
                '    newForm = New frmINQ009
                '    newForm.Show()

                'Case "INQ010"
                '    newForm = New frmINQ010
                '    newForm.Show()

                'Case "INQ011"
                '    newForm = New frmINQ001
                '    With newForm
                '        'UPGRADE_ISSUE: Control FormID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.FormID = "INQ011"
                '        'UPGRADE_ISSUE: Control TrnCd could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '        '.TrnCd = "SN"
                '        .Show()
                '    End With

                'Case "INQ012"
                '    newForm = New frmINQ012
                '    newForm.Show()

                'Case "INQ013"
                '    newForm = New frmINQ013
                '    newForm.Show()

                'Case "STKCNT"
                '    newForm = New frmSTKCNT
                '    newForm.Show()

                '    '''' Master Listing
                'Case "AT002"
                '    newForm = New frmAT002
                '    newForm.Show()

                'Case "C002"
                '    newForm = New frmC002
                '    newForm.Show()

                'Case "COA002"
                '    newForm = New frmCOA002
                '    newForm.Show()

                'Case "EXC002"
                '    newForm = New frmEXC002
                '    newForm.Show()

                'Case "IP0022"
                '    newForm = New frmIP0022
                '    newForm.Show()

                'Case "IT002"
                '    newForm = New frmIT002
                '    newForm.Show()

                'Case "ML002"
                '    newForm = New frmML002
                '    newForm.Show()

                'Case "PR002"
                '    newForm = New frmPR002
                '    newForm.Show()

                'Case "PT002"
                '    newForm = New frmPT002
                '    newForm.Show()

                'Case "PYT002"
                '    newForm = New frmPYT002
                '    newForm.Show()

                'Case "RMK002"
                '    newForm = New frmRMK002
                '    newForm.Show()

                'Case "SHP002"
                '    newForm = New frmSHP002
                '    newForm.Show()

                'Case "SLM002"
                '    newForm = New frmSLM002
                '    newForm.Show()

                'Case "STF002"
                '    newForm = New frmSTF002
                '    newForm.Show()

                'Case "UOM002"
                '    newForm = New frmUOM002
                '    newForm.Show()

                'Case "USR002"
                '    newForm = New frmUSR002
                '    newForm.Show()

                'Case "V002"
                '    newForm = New frmV002
                '    newForm.Show()

                'Case "WH002"
                '    newForm = New frmWH002
                '    newForm.Show()

            Case Else
                'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
                'UPGRADE_ISSUE: Form property nbMain.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
                Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal
                Exit Sub

        End Select


        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(inNotAdd) Then
            cboCommand.Items.Add(wsFName)
            tbrMain.Items.Item(tcPrev).Enabled = True
            giCurrIndex = giCurrIndex + 1
        End If

        'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
        'UPGRADE_ISSUE: Form property nbMain.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal

        Exit Sub

Err_Handler:
        MsgBox(Err.Description)
        'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
        'UPGRADE_ISSUE: Form property nbMain.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        Me.Cursor = System.Windows.Forms.Cursors.Default ' vbNormal

    End Sub

    Private Sub Ini_Menu()

        ' First node with 'Root' as text.
        Call Get_Scr_Item(wsFormID, waScrItm)
        Call Get_Scr_Item("TOOLTIP", waScrToolTip)

        Me.Text = Get_Caption(waScrItm, "SCRHDR")
        mnuFile.Text = Get_Caption(waScrItm, "FILE")
        mnuMaster.Text = Get_Caption(waScrItm, "MASTER")
        mnuOperation.Text = Get_Caption(waScrItm, "OPERATION")
        mnuPO.Text = Get_Caption(waScrItm, "PO")
        mnuInventory.Text = Get_Caption(waScrItm, "INVENTORY")
        mnuAccount.Text = Get_Caption(waScrItm, "ACCOUNT")
        mnuInquiry.Text = Get_Caption(waScrItm, "INQUIRY")
        mnuReport.Text = Get_Caption(waScrItm, "REPORT")
        mnuUtility.Text = Get_Caption(waScrItm, "UTILITY")
        mnuACCRPT.Text = Get_Caption(waScrItm, "ACCRPT")
        mnuList.Text = Get_Caption(waScrItm, "LIST")


        tbrMain.Items.Item(tcOK).ToolTipText = Get_Caption(waScrToolTip, tcOK) & "(F10)"
        tbrMain.Items.Item(tcPrev).ToolTipText = Get_Caption(waScrToolTip, tcPrev) & "(F2)"
        tbrMain.Items.Item(tcNext).ToolTipText = Get_Caption(waScrToolTip, tcNext) & "(F3)"
        tbrMain.Items.Item(tcCancel).ToolTipText = Get_Caption(waScrToolTip, tcCancel) & "(F11)"
        tbrMain.Items.Item(tcExit).ToolTipText = Get_Caption(waScrToolTip, tcExit) & "(F12)"

        Call Ini_PgmMenu(mnuFile, "FILE", waFileSub)
        Call Ini_PgmMenu(mnuMaster, "MASTER", waMasterSub)
        Call Ini_PgmMenu(mnuOperation, "OPERATION", waOperationSub)
        Call Ini_PgmMenu(mnuPO, "PO", waPOSub)
        Call Ini_PgmMenu(mnuInventory, "INVENTORY", waInventorySub)
        Call Ini_PgmMenu(mnuAccount, "ACCOUNT", waACCOUNTSub)
        Call Ini_PgmMenu(mnuInquiry, "INQUIRY", waInquirySub)
        Call Ini_PgmMenu(mnuReport, "REPORT", waReportSub)
        Call Ini_PgmMenu(mnuUtility, "UTILITY", waUtilitySub)
        Call Ini_PgmMenu(mnuACCRPT, "ACCRPT", waAccRptSub)
        Call Ini_PgmMenu(mnuList, "LIST", waListSub)



        ''UPGRADE_WARNING: Lower bound of collection staMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        staMain.Items.Item(0).Text = gsComNam

        'lvwDB.Columns.Clear()
        'lvwDB.Columns.Add("", Get_Caption(waScrItm, "LST01"), CInt(VB6.TwipsToPixelsX(1500)))
        'lvwDB.Columns.Add("", Get_Caption(waScrItm, "LST02"), CInt(VB6.TwipsToPixelsX(5000)))
    End Sub

    Private Sub nbMain_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode

            Case System.Windows.Forms.Keys.F2

                ChgPrevPage()

            Case System.Windows.Forms.Keys.F3

                ChgNextPage()

            Case System.Windows.Forms.Keys.F10

                Call Call_Pgm(waFileSub, 0, UCase(cboCommand.Text))

            Case System.Windows.Forms.Keys.F11

                Call cmdCancel()

            Case System.Windows.Forms.Keys.F12

                Me.Close()

        End Select
    End Sub

    Private Sub nbMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        Dim sMsg As String
        Dim sSQL As String
        On Error GoTo ErrHand

        sMsg = "Are you sure to exit this system?" & Chr(10) & Chr(10)
        sMsg = sMsg & "請問你是不是肯定退出這系統?"

        If MsgBox(sMsg, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsTitle) = MsgBoxResult.No Then

            '       sSQL = "DUMP TRANSACTION CHUNGFAIDB WITH NO_LOG"
            '       cnCon.Execute sSQL
            '
            '
            '   Else
            eventArgs.Cancel = True
        End If

        Exit Sub

ErrHand:
        MsgBox(Err.Description)
        eventArgs.Cancel = True
    End Sub

    Private Sub nbMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)

        Dim f As System.Windows.Forms.Form

        For Each f In System.Windows.Forms.Application.OpenForms

            If f.Name <> Me.Name Then
                MsgBox("Please Contact Nbase : Can't Close " & f.Name)
                f.Close()
                'UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                f = Nothing
            End If

        Next f

        Call Disconnect_Database()

        'UPGRADE_NOTE: Object waFileSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waFileSub = Nothing
        'UPGRADE_NOTE: Object waMasterSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waMasterSub = Nothing
        'UPGRADE_NOTE: Object waOperationSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waOperationSub = Nothing
        'UPGRADE_NOTE: Object waPOSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waPOSub = Nothing
        'UPGRADE_NOTE: Object waInventorySub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waInventorySub = Nothing
        'UPGRADE_NOTE: Object waACCOUNTSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waACCOUNTSub = Nothing
        'UPGRADE_NOTE: Object waInquirySub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waInquirySub = Nothing
        'UPGRADE_NOTE: Object waReportSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waReportSub = Nothing
        'UPGRADE_NOTE: Object waUtilitySub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waUtilitySub = Nothing
        'UPGRADE_NOTE: Object waAccRptSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waAccRptSub = Nothing
        'UPGRADE_NOTE: Object waListSub may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waListSub = Nothing
        'UPGRADE_NOTE: Object waScrItm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waScrItm = Nothing
        'UPGRADE_NOTE: Object waScrToolTip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        waScrToolTip = Nothing
        'UPGRADE_NOTE: Object nbMain may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Me.Close() ' = Nothing

    End Sub

    Public Sub mnuACCRPTSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuACCRPT.DropDownItemClicked
        Dim Index As Short = mnuACCRPT.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waAccRptSub, Index)
    End Sub

    Public Sub mnuListSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuList.DropDownItemClicked
        Dim Index As Short = mnuList.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waListSub, Index)
    End Sub

    Public Sub mnuFileSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuFile.DropDownItemClicked
        Dim Index As Short = mnuFile.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waFileSub, Index)
    End Sub

    Public Sub mnuMasterSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuMaster.DropDownItemClicked
        Dim Index As Short = mnuMaster.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waMasterSub, Index)
    End Sub

    Public Sub mnuOperationSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuOperation.DropDownItemClicked
        Dim Index As Short = mnuOperation.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waOperationSub, Index)
    End Sub

    Public Sub mnuInventorySub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuInventory.DropDownItemClicked
        Dim Index As Short = mnuInventory.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waInventorySub, Index)
    End Sub
    Public Sub mnuinquirySub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuInquiry.DropDownItemClicked
        Dim Index As Short = mnuInquiry.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waInquirySub, Index)
    End Sub

    Public Sub mnuPOSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuPO.DropDownItemClicked
        Dim Index As Short = mnuPO.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waPOSub, Index)
    End Sub

    Public Sub mnureportSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuReport.DropDownItemClicked
        Dim Index As Short = mnuReport.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waReportSub, Index)
    End Sub

    Public Sub mnuACCOUNTSub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuAccount.DropDownItemClicked
        Dim Index As Short = mnuAccount.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waACCOUNTSub, Index)
    End Sub

    Public Sub mnuutilitySub_Click(ByVal eventSender As System.Object, ByVal eventArgs As ToolStripItemClickedEventArgs) Handles mnuUtility.DropDownItemClicked
        Dim Index As Short = mnuUtility.DropDownItems.IndexOf(eventArgs.ClickedItem)
        Call Call_Pgm(waUtilitySub, Index)
    End Sub
End Class