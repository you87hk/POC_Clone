Option Strict Off
Option Explicit On
Module NBFunc

    Public Sub getHostLogin()

        Dim cmdHost As New SqlClient.SqlCommand

        cmdHost.Connection = cnCon

        cmdHost.CommandText = "USP_HOSTNAME"
        cmdHost.CommandType = CommandType.StoredProcedure
        'cmdHost.Parameters.refresh() 'Must set up the activeconnection before refresh
        'cmdHost.ExecuteNonQuery()
        SqlClient.SqlCommandBuilder.DeriveParameters(cmdHost)

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gsHostName = GetSPPara(cmdHost, 1)
        gsHostLogin = Dsp_Date(GetSPPara(cmdHost, 2), True)

        'UPGRADE_NOTE: Object cmdHost may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        cmdHost.Dispose()
        cmdHost = Nothing

    End Sub
    Public Function Dsp_Date(ByVal inDate As Object, Optional ByRef ShowTime As Object = Nothing, Optional ByRef NoSlash As Object = Nothing) As String

        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(ShowTime) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object ShowTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ShowTime = False
        End If

        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(NoSlash) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object NoSlash. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NoSlash = False
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDbNull(inDate) Or Trim(inDate) = "" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object NoSlash. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If NoSlash = True Then
                Dsp_Date = ""
            Else
                Select Case gsDteFmt
                    Case "DMY", "MDY"
                        Dsp_Date = "  /  /    "
                    Case Else
                        Dsp_Date = "    /  /  "
                End Select
            End If
            Exit Function
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object ShowTime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If ShowTime = False Then
            Select Case gsDteFmt
                Case "MDY"
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "MM/dd/yyyy")
                Case "YMD"
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "yyyy/MM/dd")
                Case Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "dd/MM/yyyy")
            End Select
        Else
            Select Case gsDteFmt
                Case "MDY"
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "MM/dd/yyyy HH:MM:SS")
                Case "YMD"
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "yyyy/MM/dd HH:MM:SS")
                Case Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object inDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dsp_Date = Format(CDate(inDate), "dd/MM/yyyy HH:MM:SS")
            End Select
        End If

    End Function

    Public Sub Get_Date_Fmt()
        Dim LOCALE_IDATE As Integer

        Dim Symbol As String
        Dim iRet1 As Integer
        Dim iRet2 As Integer
        Dim lpLCDataVar As String = ""
        Dim Pos As Short
        Dim Locale As Integer

        Locale = GetUserDefaultLCID()
        'UPGRADE_WARNING: Couldn't resolve default property of object LOCALE_IDATE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iRet1 = GetLocaleInfo(Locale, LOCALE_IDATE, lpLCDataVar, 0)
        Symbol = New String(Chr(0), iRet1)
        'UPGRADE_WARNING: Couldn't resolve default property of object LOCALE_IDATE. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iRet2 = GetLocaleInfo(Locale, LOCALE_IDATE, Symbol, iRet1)
        Pos = InStr(Symbol, Chr(0))

        If Pos > 0 Then
            Symbol = Left(Symbol, Pos - 1)
        End If

        Select Case Symbol
            Case CStr(0)
                gsDteFmt = "MDY"
            Case CStr(1)
                gsDteFmt = "DMY"
            Case CStr(2)
                gsDteFmt = "YMD"
        End Select

    End Sub

    Public Sub Get_Company_Info()

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsCompany As New System.Data.DataTable
        Dim Criteria As String

        Select Case gsLangID
            Case "1"
                Criteria = "SELECT CmpEngName COMNAM "
            Case "2"
                Criteria = "SELECT CmpChiName COMNAM "
            Case Else
                Criteria = "SELECT CmpEngName COMNAM "

        End Select
        Criteria = Criteria & " FROM mstCompany WHERE CmpID = 1 "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
            dataAdapt.Fill(rsCompany)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsCompany.Rows.Count > 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gsComNam = ReadRs(rsCompany, "COMNAM")
        Else
            MsgBox("Can't Access Company Info!")
        End If

        dataAdapt.Dispose()
        rsCompany.Clear()
        'UPGRADE_NOTE: Object rsCompany may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCompany = Nothing

    End Sub

    Public Sub Get_Company_Default()

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsSysDef As New System.Data.DataTable
        Dim Criteria As String

        Criteria = "SELECT SYPMINDTE, SYPMAXDTE "
        Criteria = Criteria & " FROM SYSCONST WHERE SYPRECID = '01' "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
            dataAdapt.Fill(rsSysDef)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsSysDef.Rows.Count > 0 Then
            gsDateFrom = Dsp_Date(ReadRs(rsSysDef, "SYPMINDTE"))
            gsDateTo = Dsp_Date(ReadRs(rsSysDef, "SYPMAXDTE"))
        Else
            MsgBox("Missing System Profile!")
        End If
        dataAdapt.Dispose()
        rsSysDef.Clear()
        'UPGRADE_NOTE: Object rsSysDef may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsSysDef = Nothing

    End Sub

    Public Function Chk_PgmExist(ByRef InPgmID As String) As Short

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim wsSQL As String
        Dim rsRcd As New System.Data.DataTable

        Chk_PgmExist = False

        wsSQL = "SELECT * FROM sysScrCaption "
        wsSQL = wsSQL & " WHERE ScrFldID = 'SCRHDR'"
        wsSQL = wsSQL & " AND ScrPgmID = '" & Set_Quote(InPgmID) & "' "
        wsSQL = wsSQL & " AND ScrType = 'SCR' "
        wsSQL = wsSQL & " AND ScrLangID = '" & gsLangID & "' "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count > 0 Then
            Chk_PgmExist = True
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Public Function Chk_GrpRight(ByRef inGrpId As String, ByRef InPgmID As String) As Short

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim wsSQL As String
        Dim rsRcd As New System.Data.DataTable

        Chk_GrpRight = False

        wsSQL = "SELECT * FROM sysUserRight "
        wsSQL = wsSQL & " WHERE URGRPCODE = '" & Set_Quote(inGrpId) & "' "
        wsSQL = wsSQL & " AND URPGMID = '" & Set_Quote(InPgmID) & "' "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
            dataAdapt.Fill(rsRcd)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rsRcd.Rows.Count > 0 Then
            Chk_GrpRight = True
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()

        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Public Function Set_Quote(ByVal inText As String) As String
        Dim strPos As Short
        Dim iCtr As Short
        Dim outText As String
        Dim TmpChar As String

        strPos = InStr(inText, "'")
        If strPos <> 0 Then
            outText = Left(inText, strPos - 1)
            For iCtr = strPos To Len(inText)
                TmpChar = Mid(inText, iCtr, 1)
                If TmpChar = "'" Then
                    outText = outText & "''"
                Else
                    outText = outText & TmpChar
                End If
            Next

        Else
            outText = inText
        End If

        Set_Quote = outText

    End Function

    Public Function Chk_UserRight(ByRef inUsrId As String, ByRef InPgmID As String) As Short

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim wsSQL As String
        Dim rsRcd As New System.Data.DataTable

        Chk_UserRight = False

        If inUsrId = "NBASE" Then
            Chk_UserRight = True
        Else
            wsSQL = "SELECT URPGMID FROM sysUserRight, mstUser "
            wsSQL = wsSQL & " WHERE USRGRPCODE = URGRPCODE "
            wsSQL = wsSQL & " AND URPGMID = '" & InPgmID & "' "
            wsSQL = wsSQL & " AND USRCODE = '" & inUsrId & "' "

            Try
                dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
                dataAdapt.Fill(rsRcd)
            Catch ex As SqlClient.SqlException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If rsRcd.Rows.Count > 0 Then
                Chk_UserRight = True
            End If

            dataAdapt.Dispose()
            rsRcd.Clear()
        End If

        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing

    End Function

    Public Function Encrypt(ByRef inVal As String) As String

        ' inVal = the string you wish to encrypt or decrypt.
        ' PassWord = the password with which to encrypt the string.
        ' pass a string for encryption.  Use the return string and call again, it will decrypt.

        Dim PassWord As String
        'UPGRADE_NOTE: Char was upgraded to Char_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Char_Renamed As String
        Dim L As Short
        Dim X As Short

        PassWord = "NBASE2000"

        L = Len(PassWord)
        For X = 1 To Len(inVal)
            Char_Renamed = CStr(Asc(Mid(PassWord, (X Mod L) - L * CShort((X Mod L) = 0), 1)))
            Mid(inVal, X, 1) = Chr(Asc(Mid(inVal, X, 1)) Xor Char_Renamed)
        Next

        Encrypt = inVal

    End Function

    Public Sub Read_Debug_Ini(ByVal TmpFilNam As String)

        Dim TmpAppNam As String
        Dim TmpRetNam As String
        Dim TmpKeyNam As String
        'Dim TmpRetSiz As Short

        Dim TmpStr As String
        Dim tmplen As Short
        Dim TmpNum As Short

        Dim wsLogin As String
        Dim wsPwd As String
        Dim wsServer As String
        Dim wsDatabase As String

        TmpAppNam = "SYSENV"
        TmpRetNam = New String("100", 100)

        TmpKeyNam = "UID"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        wsLogin = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "PWD"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        wsPwd = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "RPTPATH"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsRptPath = Mid(TmpStr, 1, tmplen - 1)


        TmpKeyNam = "DBNAME"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsDBName = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "MODULE"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsMODULE = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "EXCPATH"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsExcPath = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "SQLDB"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        wsDatabase = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "SQLSRV"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        wsServer = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "USER"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsUserID = Mid(TmpStr, 1, tmplen - 1)


        TmpKeyNam = "WSID"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsWorkStationID = Mid(TmpStr, 1, tmplen - 1)


        TmpKeyNam = "RTACCESS"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsRTAccess = Mid(TmpStr, 1, tmplen - 1)

        TmpKeyNam = "RTPATH"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsRTPath = Mid(TmpStr, 1, tmplen - 1)

        '' Tom 090210

        TmpKeyNam = "HHPATH"
        TmpNum = GetPrivateProfileString(TmpAppNam, TmpKeyNam, "", TmpRetNam, Len(TmpRetNam), TmpFilNam)
        TmpStr = TmpRetNam.Substring(0, InStr(TmpRetNam, Chr(0)))
        tmplen = Len(TmpStr)
        gsHHPath = Mid(TmpStr, 1, tmplen - 1)

        gsConnectString = "Data Source=" & wsServer & ";Initial Catalog=" & wsDatabase & ";User ID=" & wsLogin & ";Password=" & wsPwd

    End Sub

    Public Sub Get_Scr_Item(ByVal InPgmID As String, ByRef inArray As System.Data.DataTable)

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim Criteria As String
        Dim rsCaption As New System.Data.DataTable

        Criteria = "SELECT SCRFLDID, SCRFLDNAME "
        Criteria = Criteria & " FROM SYSSCRCAPTION WHERE SCRTYPE = 'SCR' "
        Criteria = Criteria & " AND SCRPGMID = '" & InPgmID & "' "
        Criteria = Criteria & " AND SCRLANGID = '" & gsLangID & "' "

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
            dataAdapt.Fill(rsCaption)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'inArray.ReDim(0, -1, 0, 1)

        'If rsCaption.RecordCount > 0 Then
        '    rsCaption.MoveFirst()

        '    inArray.AppendRows()
        '    inArray.get_Value(inArray.get_UpperBound(1), 0) = InPgmID & " "
        '    inArray.get_Value(inArray.get_UpperBound(1), 1) = "ID"

        '    Do While Not rsCaption.EOF
        '        inArray.AppendRows()
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        inArray.get_Value(inArray.get_UpperBound(1), 0) = ReadRs(rsCaption, "SCRFLDNAME")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        inArray.get_Value(inArray.get_UpperBound(1), 1) = ReadRs(rsCaption, "SCRFLDID")
        '        rsCaption.MoveNext()
        '    Loop
        'End If

        inArray = rsCaption.Copy()

        dataAdapt.Dispose()
        rsCaption.Clear()

        'UPGRADE_NOTE: Object rsCaption may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCaption = Nothing

    End Sub

    Public Function Get_Caption(ByVal inArray As System.Data.DataTable, ByVal inCode As String) As String

        Dim wlFound As Integer
        Dim dr As DataRow

        On Error GoTo Err_Handler

        Get_Caption = ""

        If inCode = "SCRHDR" Then
            Get_Caption = ""
            For Each dr In inArray.Rows
                If dr.Item(0).ToString.ToUpper = "ID" Then
                    Get_Caption = dr.Item(1).ToString
                    Exit For
                End If
            Next
        End If

        For Each dr In inArray.Rows
            If dr.Item(0).ToString.ToUpper = inCode Then
                Get_Caption = Get_Caption & dr.Item(1).ToString
                Exit For
            End If
        Next

        'If inCode = "SCRHDR" Then
        '    wlFound = inArray.Find(0, 1, "ID")
        '    If wlFound < inArray.get_LowerBound(1) Then
        '        Get_Caption = ""
        '    Else
        '        Get_Caption = inArray.get_Value(wlFound, 0)
        '    End If
        'End If

        'wlFound = inArray.Find(0, 1, inCode)


        'If wlFound < inArray.get_LowerBound(1) Then
        '    Exit Function
        'Else
        '    Get_Caption = Get_Caption & inArray.get_Value(wlFound, 0)
        'End If

Err_Handler:
        Exit Function

    End Function

    Public Sub Ini_PgmMenu(ByRef inMenuCtl As System.Windows.Forms.ToolStripMenuItem, ByRef InPgmID As String, Optional ByRef inArray As System.Data.DataTable = Nothing)

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim wsSQL As String
        Dim rsRcd As New System.Data.DataTable
        Dim adapter As New System.Data.OleDb.OleDbDataAdapter
        Dim wiMenuItem As Short
        Dim wiCtr As Short
        Dim wiStop As Short

        wiStop = False
        wiCtr = 0

        On Error GoTo Err_Handler

        Do While Not wiStop
            If wiCtr = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'inMenuCtl.Caption = ""
                inMenuCtl.DropDownItems.Clear()
            Else
                'UPGRADE_ISSUE: Unload inMenuCtl() was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
                'Unload(inMenuCtl(wiCtr))
                inMenuCtl.DropDownItems().RemoveAt(wiCtr)
            End If
            wiCtr = wiCtr + 1
        Loop

        'UPGRADE_WARNING: Couldn't resolve default property of object inArray.ReDim. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'inArray.ReDim(0, -1, 0, 2)


        wsSQL = "SELECT SCRFLDID, SCRFLDNAME "
        wsSQL = wsSQL & " FROM SYSSCRCAPTION WHERE SCRTYPE = 'MNU' "
        wsSQL = wsSQL & " AND SCRPGMID = '" & InPgmID & "' "
        wsSQL = wsSQL & " AND SCRLANGID = '" & gsLangID & "' "
        wsSQL = wsSQL & " ORDER BY SCRSEQNO "

        dataAdapt = New SqlClient.SqlDataAdapter(wsSQL, cnCon)
        dataAdapt.Fill(rsRcd)

        If Not IsNothing(inArray) Then
            inArray = rsRcd.Copy()
        End If
        inArray.Columns().Add("SPCMNUSPA")
        Dim rowCount As Integer = 0
        Dim dr As System.Data.DataRow
        For Each dr In inArray.Rows
            inMenuCtl.DropDown.Items.Add(dr.Item(1))
            If Chk_UserRight(gsUserID, dr.Item(0)) = False Then
                'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                inMenuCtl.DropDown.Items(wiMenuItem).Enabled = False
                'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'inArray(.UpperBound(1), 2) = "N"
                inArray.Rows(rowCount).Item(2) = "N"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                inMenuCtl.DropDown.Items(wiMenuItem).Enabled = True
                'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'inArray(.UpperBound(1), 2) = "Y"
                inArray.Rows(rowCount).Item(2) = "Y"
            End If
            rowCount += 1
        Next

        'If rsRcd.RecordCount > 0 Then
        '    rsRcd.MoveFirst()
        '    Do While Not rsRcd.EOF
        '        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        '        If Not IsNothing(inArray) Then
        '            If wiMenuItem > 0 Then inMenuCtl.Load(wiMenuItem)
        '            'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            inMenuCtl(wiMenuItem).Enabled = True
        '            'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl(wiMenuItem).Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            inMenuCtl(wiMenuItem).Caption = ReadRs(rsRcd, "SCRFLDNAME")
        '            With inArray
        '                'UPGRADE_WARNING: Couldn't resolve default property of object inArray.AppendRows. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                .AppendRows()
        '                'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                inArray(.UpperBound(1), 0) = ReadRs(rsRcd, "SCRFLDID")
        '                'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                inArray(.UpperBound(1), 1) = ReadRs(rsRcd, "SCRFLDNAME")

        '                'If ReadRs(rsRcd, "SPCMNUSPA") = "Y" Then
        '                '    Load inMenuCtl(wiMenuItem + 1)
        '                '    inMenuCtl(wiMenuItem + 1).Enabled = True
        '                '    inMenuCtl(wiMenuItem + 1).Caption = "-"
        '                '    .AppendRows
        '                '    inArray(.UpperBound(1), 0) = "-"
        '                'End If
        '                'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                If Chk_UserRight(gsUserID, ReadRs(rsRcd, "SCRFLDID")) = False Then
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    inMenuCtl(wiMenuItem).Enabled = False
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    inArray(.UpperBound(1), 2) = "N"
        '                Else
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    inMenuCtl(wiMenuItem).Enabled = True
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inArray.UpperBound. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object inArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    inArray(.UpperBound(1), 2) = "Y"
        '                End If
        '            End With
        '        Else
        '            If wiMenuItem > 0 Then inMenuCtl.Load(wiMenuItem)
        '            'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            inMenuCtl(wiMenuItem).Enabled = True
        '            'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl(wiMenuItem).Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            inMenuCtl(wiMenuItem).Caption = ReadRs(rsRcd, "SCRFLDNAME")
        '            'If ReadRs(rsRcd, "SPCMNUSPA") = "Y" Then
        '            '    Load inMenuCtl(wiMenuItem + 1)
        '            '    inMenuCtl(wiMenuItem + 1).Enabled = True
        '            '    inMenuCtl(wiMenuItem + 1).Caption = "-"
        '            'End If
        '            'UPGRADE_WARNING: Couldn't resolve default property of object inMenuCtl().Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            inMenuCtl(wiMenuItem).Enabled = True
        '        End If
        '        wiMenuItem = wiMenuItem + 1
        '        rsRcd.MoveNext()
        '    Loop
        'End If

        Exit Sub

Err_Handler:
        wiStop = True
        Resume Next

    End Sub

    Public Sub Ini_Combo(ByRef inNoOfCol As Short, ByRef inCriteria As String, ByRef Xpos As Integer, ByRef Ypos As Integer, ByRef inGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef InPgmID As String, ByRef inKey As String, ByRef FrmWidth As Integer, ByRef FrmHeight As Integer)

        'inNoOfCol = No. of Columns in the drop down grid
        'inCriteria = Searching Criteria for filling the results to the grid
        'XPos = The left position for displaying the grid
        'YPos = The top position for displaying the grid
        'inGrid = The Grid object needed to be initialized
        'inPgmID = The Program ID for search the description in the SPC table
        'inKey = The key code for search the description in the SPC table

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsCommon As New System.Data.DataTable
        Dim rsSPC As New System.Data.DataTable
        Dim Criteria As String
        ' Dim myColumn As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim waCommon As New System.Data.DataTable
        Dim wiCol As Short
        Dim wiCtr As Short
        Dim wlRecCtr As Integer
        Dim wlWidth As Integer
        'Dim colC As New C1.Win.C1TrueDBGrid.C1DataColumn

        System.Windows.Forms.Application.DoEvents() 'DoEvents is to let the got_focus trigger first
        inGrid.ClearFields()

        With inGrid
            .Height = 2000
            .Width = 3500
            .EmptyRows = True
            .AllowColMove = False
            .AllowColSelect = False
            .AllowUpdate = False
            .MarqueeStyle = 3

            .RecordSelectors = False

            For wiCtr = 0 To .Columns.Count - 1
                '.Columns.Remove(0)
                .Columns.RemoveAt(0)
            Next

            For wiCtr = 0 To inNoOfCol - 1
                'colC = .Columns.Add(wiCtr)
                .Columns.Insert(wiCtr, New C1.Win.C1TrueDBGrid.C1DataColumn)
                .Splits(0).DisplayColumns(wiCtr).Visible = True
            Next

            For wiCtr = 0 To inNoOfCol - 1
                .Splits(0).DisplayColumns(wiCtr).AllowSizing = True
                .Splits(0).DisplayColumns(wiCtr).Visible = True
                '.Columns(wiCtr).Locked = True
            Next

            'Initialize the caption in the drop down grid
            Criteria = "SELECT SCRFLDID, SCRFLDNAME "
            Criteria = Criteria & " FROM SYSSCRCAPTION WHERE SCRTYPE = 'SCR' "
            Criteria = Criteria & " AND SCRPGMID = '" & InPgmID & "' "
            Criteria = Criteria & " AND SCRLANGID = '" & gsLangID & "' "
            Criteria = Criteria & " AND SCRFLDID LIKE '" & inKey & "%' "
            Criteria = Criteria & " ORDER BY SCRSEQNO "


            'rsSPC.Open(Criteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

            Try
                dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
                dataAdapt.Fill(rsSPC)
            Catch ex As SqlClient.SqlException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            wiCol = 0

            If rsSPC.Rows.Count > 0 Then
                wlWidth = 0
                Dim dr As System.Data.DataRow
                For Each dr In rsSPC.Rows
                    If wiCol < inNoOfCol Then
                        .Splits(0).DisplayColumns(wiCol).Width = (Len(dr.Item("SCRFLDNAME")) * 120)
                        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Columns(wiCol).Caption = dr.Item("SCRFLDNAME")
                        wlWidth = wlWidth + .Splits(0).DisplayColumns(wiCol).Width
                    End If
                    wiCol = wiCol + 1
                Next

                'rsSPC.MoveFirst()
                'wlWidth = 0
                'Do While Not rsSPC.EOF
                '    If wiCol < inNoOfCol Then
                '        .Columns(wiCol).Width = (Len(ReadRs(rsSPC, "SCRFLDNAME")) * 120)
                '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '        .Columns(wiCol).Caption = ReadRs(rsSPC, "SCRFLDNAME")
                '        wlWidth = wlWidth + .Columns(wiCol).Width
                '    End If
                '    wiCol = wiCol + 1
                '    rsSPC.MoveNext()
                'Loop
                .Width = wlWidth
            End If

            dataAdapt.Dispose()
            rsSPC.Clear()
            'UPGRADE_NOTE: Object rsSPC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsSPC = Nothing
            'rsCommon.Open(inCriteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

            Try
                dataAdapt = New SqlClient.SqlDataAdapter(inCriteria, cnCon)
                dataAdapt.Fill(rsCommon)
            Catch ex As SqlClient.SqlException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'waCommon.ReDim(0, -1, 0, inNoOfCol - 1)
            For i = 0 To inNoOfCol - 1
                waCommon.Columns.Add(.Columns(i).Caption)
            Next

            If rsCommon.Rows.Count > 0 Then
                wlRecCtr = 0
                Dim dr As System.Data.DataRow
                For Each dr In rsCommon.Rows
                    wlRecCtr = wlRecCtr + 1
                    If wlRecCtr = 1 Then inGrid.Bookmark = inGrid.Row
                    Dim newRow As DataRow = Nothing
                    newRow = waCommon.NewRow()
                    For wiCtr = 0 To inNoOfCol - 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        newRow.Item(wiCtr) = dr.Item(wiCtr)
                    Next
                    waCommon.Rows.Add(newRow)
                Next
                'rsCommon.MoveFirst()
                'Do While Not rsCommon.EOF
                '    waCommon.AppendRows()
                '    wlRecCtr = wlRecCtr + 1
                '    'If wlRecCtr = 1 Then inGrid.Bookmark = inGrid.Row
                '    For wiCtr = 0 To inNoOfCol - 1
                '        'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '        waCommon.get_Value(waCommon.get_UpperBound(1), wiCtr) = ReadRs(rsCommon, wiCtr)
                '    Next
                '    rsCommon.MoveNext()
                'Loop
                .Bookmark = 0

                'rsCommon.MoveFirst()
                'wlWidth = 0
                'For wiCtr = 0 To inNoOfCol - 1
                '    If .Columns(wiCtr).Width < (rsCommon.Fields(wiCtr).DefinedSize * 120) Then
                '        .Columns(wiCtr).Width = (rsCommon.Fields(wiCtr).DefinedSize * 120)
                '    End If
                '    wlWidth = wlWidth + .Columns(wiCtr).Width
                '    Select Case rsCommon.Fields(wiCtr).Type
                '        Case ADODB.DataTypeEnum.adBinary, ADODB.DataTypeEnum.adCurrency, ADODB.DataTypeEnum.adDecimal, ADODB.DataTypeEnum.adDouble, ADODB.DataTypeEnum.adInteger, ADODB.DataTypeEnum.adNumeric, ADODB.DataTypeEnum.adSingle, ADODB.DataTypeEnum.adSmallInt, ADODB.DataTypeEnum.adTinyInt
                '            .Columns(wiCtr).Alignment = TrueDBGrid60.AlignmentConstants.dbgRight
                '            .Columns(wiCtr).NumberFormat = "#,##0.00########"
                '        Case Else
                '            .Columns(wiCtr).Alignment = TrueDBGrid60.AlignmentConstants.dbgLeft
                '    End Select
                'Next wiCtr

                If rsCommon.Rows.Count > 7 Then
                    .Width = (wlWidth + 220)
                Else
                    .Width = wlWidth
                End If

                If .Width > FrmWidth - 300 Then
                    .Width = (FrmWidth - 300)
                End If

            End If
            inGrid.DataSource = waCommon
            .Rebind(True)
            'Resize the combo
            wlWidth = 0
            For wiCtr = 0 To inNoOfCol - 1
                'If .Splits(0).DisplayColumns(wiCtr).Width < (rsCommon.Columns(wiCtr).MaxLength * 120) Then
                '    .Splits(0).DisplayColumns(wiCtr).Width = (rsCommon.Columns(wiCtr).MaxLength * 120)
                'End If
                .Splits(0).DisplayColumns(wiCtr).AutoSize()
                .Splits(0).DisplayColumns(wiCtr).Width += 50
                wlWidth = wlWidth + .Splits(0).DisplayColumns(wiCtr).Width
                Select Case rsCommon.Columns(wiCtr).GetType
                    Case SqlDbType.BigInt.GetType, SqlDbType.Money.GetType, SqlDbType.Decimal.GetType, SqlDbType.Float.GetType, SqlDbType.Int.GetType, SqlDbType.Real.GetType, SqlDbType.SmallInt.GetType, SqlDbType.TinyInt.GetType
                        .Splits(0).DisplayColumns(wiCtr).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        .Columns(wiCtr).NumberFormat = "#,##0.00########"
                    Case Else
                        .Splits(0).DisplayColumns(wiCtr).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                End Select
            Next wiCtr

            dataAdapt.Dispose()
            rsCommon.Clear()
            'UPGRADE_NOTE: Object rsCommon may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsCommon = Nothing

            'If Xpos + .Width > FrmWidth Then
            '    Xpos = FrmWidth - .Width - 100
            'End If

            .Left = Xpos ' * G.DpiX / 1024

            'If Ypos + .Height > FrmHeight Then
            '    'Amended by Lewis at 01082001
            '    'Ypos = FrmHeight - .Height - 100
            '    Ypos = Ypos - .Height - 300
            'End If

            .Top = Ypos ' * G.DpiY / 768
            'UPGRADE_NOTE: Object waCommon may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            waCommon = Nothing
        End With

    End Sub

    Public Sub chk_InpLen(ByRef Cnl As System.Windows.Forms.Control, ByRef Num As Short, ByRef KeyAscii As Short)

        'UPGRADE_WARNING: Couldn't resolve default property of object Cnl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Cnl.SelLength > 0 Then
        '    Exit Sub
        'End If

        If Len(Cnl.Text) > Num - 1 And KeyAscii <> System.Windows.Forms.Keys.Return And KeyAscii <> System.Windows.Forms.Keys.Back Then
            KeyAscii = 0
        End If

    End Sub

    Public Sub Set_CheckValue(ByRef Cnl As System.Windows.Forms.Control, ByRef InValue As String)


        If InValue = "Y" Or InValue = "y" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Cnl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CType(Cnl, CheckBox).Checked = 1
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Cnl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CType(Cnl, CheckBox).Checked = 0
        End If

    End Sub

    Public Function To_Value(ByRef inText As Object) As Double

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDbNull(inText) = True Then
            To_Value = 0
            Exit Function
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object inText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        To_Value = Val(Format(Trim(inText), "############.########"))

    End Function

    Public Function UnLockAll(ByVal inTStamp As String, ByVal inPrgID As String) As Short

        Dim Criteria As String
        Dim rsCmd As New SqlClient.SqlCommand

        UnLockAll = False
        On Error GoTo UnLockAll_Err

        Criteria = "DELETE FROM sysLOCK "
        Criteria = Criteria & " WHERE LocHOST = '" & Set_Quote(gsHostName) & "' "
        Criteria = Criteria & " AND LocLOGIN = '" & Change_SQLDate(gsHostLogin) & "' "
        Criteria = Criteria & " AND LocUSRID = '" & Set_Quote(gsUserID) & "' "
        Criteria = Criteria & " AND LocPGMID = '" & inPrgID & "' "
        Criteria = Criteria & " AND LocLupdte = '" & Change_SQLDate(inTStamp) & "' "
        With rsCmd
            .Connection = cnCon
            .CommandType = CommandType.Text ' ADODB.CommandTypeEnum.adCmdText
            .CommandText = Criteria
            .ExecuteNonQuery()
        End With


        UnLockAll = True
        'UPGRADE_NOTE: Object rsCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCmd = Nothing

        Exit Function

UnLockAll_Err:
        MsgBox("UnLockAll Err!")
        'UPGRADE_NOTE: Object rsCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCmd = Nothing

    End Function

    Public Function RowLock(ByVal inTStamp As String, ByVal inKeyTyp As String, ByVal inKey As String, ByVal inPrgID As String, ByRef outUsrID As String) As Short
        Dim gsUsrID As String = String.Empty

        ' inTStamp    - THE DATETIME STRING OF USER LOAD THE PROGRAM. E.G. 01/09/1998 12:53:00
        ' inKeyTyp  - THE KEY NAME FOR LOCKING. E.G. CUSNO, DOCNO, INVNO
        ' inKey     - THE KEY VALUE FOR LOCKING. E.G. 091230, DOC-00000148
        ' inPrgID    - THE PROGRAM ID WHICH LOCK THE TABLE. E.G. MM06, S010
        ' outUsrID  - THE USER ID WHICH LOCKED THE RECORD. E.G. TRESTEP

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsSysLock As New System.Data.DataTable
        Dim rsCmd As New SqlClient.SqlCommand

        Dim Criteria As String

        RowLock = False
        outUsrID = ""

        On Error GoTo RowLock_Err

        'CHECK WHETHER THE RECORD IS LOCKED BY OTHER USER
        Criteria = " SELECT LocUsrID, LocLupDte "
        Criteria = Criteria & " FROM sysLock, MASTER.DBO.SYSPROCESSES "
        Criteria = Criteria & " WHERE LocKEYTYP = '" & Set_Quote(inKeyTyp) & "' "
        Criteria = Criteria & " AND LocKEY = '" & Set_Quote(inKey) & "' "
        Criteria = Criteria & " AND CONVERT(VARCHAR, LocLOGIN, 120) = CONVERT(VARCHAR, LOGIN_TIME, 120) "
        Criteria = Criteria & " AND LocHOST = HOSTNAME "

        'rsSysLock.Open(Criteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
        dataAdapt.Fill(rsSysLock)

        If rsSysLock.Rows.Count > 0 Then
            'IF THE USRID AND TSTAMP IS SAME AS PARAMETER PASSED, LOCK RECORD IS SUCCESS
            'UPGRADE_WARNING: Couldn't resolve default property of object gsUsrID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Trim(ReadRs(rsSysLock, "LocUSRID")) = Trim(gsUsrID) And Dsp_Date(ReadRs(rsSysLock, "LocLupDte"), True) = inTStamp Then
                RowLock = True
            Else
                'OTHER USER LOCKS THE RECORD
                'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                outUsrID = ReadRs(rsSysLock, "LocUsrID")
            End If

            dataAdapt.Dispose()
            rsSysLock.Clear()
            'UPGRADE_NOTE: Object rsSysLock may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsSysLock = Nothing

            Exit Function
        End If

        dataAdapt.Dispose()
        rsSysLock.Clear()
        'UPGRADE_NOTE: Object rsSysLock may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsSysLock = Nothing


        rsCmd.Connection = cnCon
        rsCmd.CommandType = CommandType.Text ' ADODB.CommandTypeEnum.adCmdText

        'IF NO ONE LOCKS THE FILE OR THE USER ARE ALREADY GONE, THEN LOCK THE RECORD
        Criteria = " INSERT INTO sysLock (LocHOST, LocUSRID, LocLOGIN, "
        Criteria = Criteria & " LocPGMID, LocKEYTYP, LocKEY, LocLupDte)"
        Criteria = Criteria & " VALUES ( '" & Set_Quote(gsHostName) & "', "
        Criteria = Criteria & "'" & Set_Quote(gsUserID) & "', "
        Criteria = Criteria & "'" & Change_SQLDate(gsHostLogin) & "', "
        Criteria = Criteria & "'" & inPrgID & "', "
        Criteria = Criteria & "'" & inKeyTyp & "', "
        Criteria = Criteria & "'" & Set_Quote(inKey) & "', "
        Criteria = Criteria & "'" & Change_SQLDate(inTStamp) & "') "

        rsCmd.CommandText = Criteria
        rsCmd.ExecuteNonQuery()

        'UPGRADE_NOTE: Object rsCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCmd = Nothing

        RowLock = True

        Exit Function

RowLock_Err:
        MsgBox("RowLock Error!")
        'UPGRADE_NOTE: Object rsCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsCmd = Nothing

    End Function

    Public Function Chk_AutoGen(ByVal inDocTyp As String) As String

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rst As New System.Data.DataTable
        Dim Criteria As String

        Chk_AutoGen = "N"

        Criteria = "SELECT DocLastKey FROM sysDocNo "
        Criteria = Criteria & " WHERE DocType = '" & Set_Quote(inDocTyp) & "'"
        'rst.Open(Criteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Try
            dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
            dataAdapt.Fill(rst)
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If rst.Rows.Count > 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Chk_AutoGen = ReadRs(rst, "DocLastKey")
        End If

        dataAdapt.Dispose()
        rst.Clear()
        'UPGRADE_NOTE: Object rst may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rst = Nothing

    End Function

    Public Function ReadOnlyMode(ByVal inTStamp As String, ByVal inKeyTyp As String, ByVal inKey As String, ByVal inPrgID As String) As Short

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim Criteria As String
        Dim rsSysLock As New System.Data.DataTable

        ReadOnlyMode = True

        On Error GoTo ReadOnlyMode_Err

        Criteria = "Select LocUsrID FROM sysLock "
        Criteria = Criteria & " WHERE LocHost = '" & Set_Quote(gsHostName) & "' "
        Criteria = Criteria & " AND LocKeyTyp = '" & Set_Quote(inKeyTyp) & "' "
        Criteria = Criteria & " AND LocKey = '" & Set_Quote(inKey) & "' "
        Criteria = Criteria & " AND LocUsrID = '" & Set_Quote(gsUserID) & "' "
        Criteria = Criteria & " AND LocPgmID = '" & inPrgID & "' "
        Criteria = Criteria & " AND LocLupDte = '" & Change_SQLDate(inTStamp) & "' "
        'rsSysLock.Open(Criteria, cnCon, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        dataAdapt = New SqlClient.SqlDataAdapter(Criteria, cnCon)
        dataAdapt.Fill(rsSysLock)

        If rsSysLock.Rows.Count > 0 Then
            ReadOnlyMode = False
        End If
        dataAdapt.Dispose()
        rsSysLock.Clear()
        'UPGRADE_NOTE: Object rsSysLock may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsSysLock = Nothing

        Exit Function

ReadOnlyMode_Err:
        MsgBox("ReadOnlyMode Error!")
        'UPGRADE_NOTE: Object rsSysLock may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsSysLock = Nothing

    End Function

    Public Function Get_CheckValue(ByRef Cnl As System.Windows.Forms.Control) As String

        On Error GoTo Get_CheckValue_Err

        'UPGRADE_WARNING: Couldn't resolve default property of object Cnl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If CType(Cnl, CheckBox).Checked = 0 Then
            Get_CheckValue = "N"
        Else
            Get_CheckValue = "Y"
        End If

Get_CheckValue_Err:
        MsgBox("Get_CheckValue Error!")
        Get_CheckValue = "Y"

    End Function

    Public Sub chk_InpLenA(ByRef Cnl As System.Windows.Forms.Control, ByRef Num As Short, ByRef KeyAscii As Short, ByRef isUpper As Boolean)

        On Error GoTo chk_InpLenA_Err

        'UPGRADE_WARNING: Couldn't resolve default property of object Cnl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If CType(Cnl, TextBox).SelectionLength > 0 Then
            Exit Sub
        End If

        If Len(Cnl.Text) > Num - 1 And KeyAscii <> System.Windows.Forms.Keys.Return And KeyAscii <> System.Windows.Forms.Keys.Back Then
            KeyAscii = 0
        End If


        If KeyAscii < 0 And KeyAscii <> System.Windows.Forms.Keys.Return And KeyAscii <> System.Windows.Forms.Keys.Back Then
            KeyAscii = 0
        End If


        '  If (KeyAscii < vbKey0 Or KeyAscii > vbKey9) And _
        ''    (KeyAscii < 65 Or KeyAscii > 90) And _
        ''     (KeyAscii < 97 Or KeyAscii > 122) And KeyAscii <> vbKeyReturn And KeyAscii <> vbKeyBack And KeyAscii <> vbKeySpace Then
        '          KeyAscii = 0
        '  End If

        If isUpper Then
            If KeyAscii >= 97 And KeyAscii <= 122 Then
                KeyAscii = KeyAscii - 32
            End If
        End If

chk_InpLenA_Err:
        MsgBox("chk_InpLenA Error!")

    End Sub

    Public Sub Chk_InpNum(ByRef KeyAscii As Short, ByRef inText As String, ByRef inSign As Short, ByRef inDot As Short)

        Dim iCtr As Integer
        Dim iDotCtr As Integer

        If inSign = True Then
            If KeyAscii = 45 Then
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(Form.ActiveForm.ActiveControl()) = "TDBGrid" Then
                    'UPGRADE_ISSUE: Control EditActive could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                    If CType(Form.ActiveForm.ActiveControl(), C1.Win.C1TrueDBGrid.C1TrueDBGrid).EditActive = True Then
                        If InStr(inText, "-") <> 0 Then
                            KeyAscii = 0
                        Else
                            If Len(inText) > 0 Then
                                KeyAscii = 0
                            End If
                        End If
                    End If
                Else
                    'UPGRADE_ISSUE: Control SelLength could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                    If CType(Form.ActiveForm.ActiveControl(), TextBox).SelectionLength <> Len(inText) Then
                        If Len(inText) > 0 Then
                            KeyAscii = 0
                        End If
                    End If
                End If
                Exit Sub
            End If
        End If

        If inDot = True Then
            iDotCtr = 0
            For iCtr = 1 To Len(inText)
                If Mid(inText, iCtr, 1) = "." Then
                    iDotCtr = iDotCtr + 1
                End If
            Next
            If KeyAscii = 46 Then
                iDotCtr = iDotCtr + 1
            End If

            If (KeyAscii < System.Windows.Forms.Keys.D0 Or KeyAscii > System.Windows.Forms.Keys.D9) And KeyAscii <> Asc(".") And KeyAscii <> System.Windows.Forms.Keys.Return And KeyAscii <> System.Windows.Forms.Keys.Back And KeyAscii <> System.Windows.Forms.Keys.Escape Then
                KeyAscii = 0
            End If
            If iDotCtr > 1 Then
                KeyAscii = 0
            End If
        Else
            If (KeyAscii < System.Windows.Forms.Keys.D0 Or KeyAscii > System.Windows.Forms.Keys.D9) And KeyAscii <> System.Windows.Forms.Keys.Return And KeyAscii <> System.Windows.Forms.Keys.Back And KeyAscii <> System.Windows.Forms.Keys.Escape Then
                KeyAscii = 0
            End If
        End If

    End Sub

    Public Function Change_SQLDate(ByVal inDate As String) As String

        ' Parameters :
        ' inDate          - The Date in win system date format
        '                   (e.g. 09/01/1997 or 09/01/1999 12:31:14)
        ' Chg_SQL_Date    - in SQL Server date format

        ' Description: Convert date from win system date format to
        '              SQL Server date format

        On Error GoTo Change_SQLDate_Err

        Change_SQLDate = ""

        'CHECK VALID DATE
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDbNull(inDate) Or Trim(inDate) = "" Then
            'Call Dsp_Err("E0048")
            Exit Function
        End If

        Select Case Left(inDate, 10)
            ' For Report Date Range
            Case "00/00/0000", "0000/00/00"
                Change_SQLDate = "1950/01/01 00:00:00"

                ' For Report Date Range
            Case "99/99/9999", "9999/99/99"
                Change_SQLDate = "3000/12/31 00:00:00"

            Case Else
                Change_SQLDate = Format(inDate, "YYYY/MM/DD HH:MM:SS")

        End Select

        Exit Function

Change_SQLDate_Err:
        MsgBox(Err.Description)

    End Function

    Public Function Get_Control_Location(ByVal control As Control) As Point
        If control.Equals(control.TopLevelControl) Then
            Return New Point(0, 0)
        End If

        Return control.Location + Get_Control_Location(control.Parent)
    End Function
End Module