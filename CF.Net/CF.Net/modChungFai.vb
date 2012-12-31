Option Strict Off
Option Explicit On
Module modChungFai
    Public Function LoadSaleCodeByID(ByVal inSaleManID As Object) As String
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        wsSQL = "SELECT SaleCode FROM MstSalesman WHERE SaleID =" & To_Value(inSaleManID)

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
            LoadSaleCodeByID = ReadRs(rsRcd, "SaleCode")
        Else
            LoadSaleCodeByID = ""
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Public Function LoadDescByCode(ByRef stblName As String, ByRef sKeyName As String, ByRef sRetName As String, ByRef sValue As String, ByRef bString As Boolean) As String
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String
        Dim wsResult As String

        LoadDescByCode = ""

        If Trim(sValue) = "" Then
            Exit Function
        End If

        wsSQL = "SELECT " & sRetName

        If bString = True Then
            wsSQL = wsSQL & " FROM " & stblName & " WHERE " & sKeyName & " = '" & Set_Quote(sValue) & "' "
        Else
            wsSQL = wsSQL & " FROM " & stblName & " WHERE " & sKeyName & " = " & Set_Quote(sValue)
        End If

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
            wsResult = ReadRs(rsRcd, sRetName)
        Else
            wsResult = ""
            dataAdapt.Dispose()
            rsRcd.Clear()
            'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsRcd = Nothing
            Exit Function
        End If

        LoadDescByCode = wsResult

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Public Sub LoadSaleByID(ByRef outSalesCode As String, ByRef outSalesName As String, ByVal inSaleManID As Object)
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        wsSQL = "SELECT SaleCode, SaleName FROM MstSalesman WHERE SaleID =" & To_Value(inSaleManID)

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
            outSalesCode = ReadRs(rsRcd, "SaleCode")
            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            outSalesName = ReadRs(rsRcd, "SaleName")
        Else
            outSalesCode = ""
            outSalesName = ""
        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Sub

    Public Sub Get_CusSaleInfo(ByVal InCusID As Integer, ByVal inYYYY As String, ByVal inMM As String, ByRef OutCreLmt As Double, ByRef OutCreLft As Double, ByRef OutOpnBal As Double, ByRef OutTotBal As Double, ByRef OutCMQty As Double, ByRef OutCYQty As Double, ByRef OutTotQty As Double, ByRef OutCMSal As Double, ByRef OutCYSal As Double, ByRef OutTotSal As Double, ByRef OutCMNet As Double, ByRef OutCYNet As Double, ByRef OutTotNet As Double)

        Dim adCmd As New SqlClient.SqlCommand

        On Error GoTo Get_CusSaleInfo_Err

        adCmd.Connection = cnCon

        adCmd.CommandText = "USP_GETCUSSALEINFO"
        adCmd.CommandType = CommandType.StoredProcedure
        'adCmd.Parameters.Refresh()
        SqlClient.SqlCommandBuilder.DeriveParameters(adCmd)

        Call SetSPPara(adCmd, 1, InCusID)
        Call SetSPPara(adCmd, 2, inYYYY)
        Call SetSPPara(adCmd, 3, inMM)


        adCmd.ExecuteNonQuery()

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCreLmt = GetSPPara(adCmd, 4)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCreLft = GetSPPara(adCmd, 5)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutOpnBal = GetSPPara(adCmd, 6)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutTotBal = GetSPPara(adCmd, 7)

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCMQty = GetSPPara(adCmd, 8)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCYQty = GetSPPara(adCmd, 9)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutTotQty = GetSPPara(adCmd, 10)

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCMSal = GetSPPara(adCmd, 11)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCYSal = GetSPPara(adCmd, 12)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutTotSal = GetSPPara(adCmd, 13)

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCMNet = GetSPPara(adCmd, 14)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutCYNet = GetSPPara(adCmd, 15)
        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OutTotNet = GetSPPara(adCmd, 16)

        'UPGRADE_NOTE: Object adCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adCmd = Nothing

        Exit Sub

Get_CusSaleInfo_Err:
        MsgBox("Get_CusSaleInfo_Err!")
        'UPGRADE_NOTE: Object adCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adCmd = Nothing

    End Sub

    Public Function Chk_MerchClass(ByVal inCode As String, ByRef OutDesc As String) As Boolean

        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String


        wsSQL = "SELECT MLDesc FROM mstMerchClass WHERE MLCode = '" & Set_Quote(inCode) & "' "
        wsSQL = wsSQL & "And MLStatus = '1' "
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
            OutDesc = ReadRs(rsRcd, "MLDesc")
            Chk_MerchClass = True

        Else

            OutDesc = ""
            Chk_MerchClass = False

        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing


    End Function

    Public Function Chk_Region(ByVal inCode As String, ByRef OutDesc As String) As Boolean
        Dim dataAdapt As SqlClient.SqlDataAdapter = Nothing
        Dim rsRcd As New System.Data.DataTable
        Dim wsSQL As String

        wsSQL = "SELECT RgnDesc FROM MstRegion WHERE RgnCode = '" & Set_Quote(inCode) & "' "
        wsSQL = wsSQL & "And RgnStatus = '1' "
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
            OutDesc = ReadRs(rsRcd, "RgnDesc")
            Chk_Region = True

        Else

            OutDesc = ""
            Chk_Region = False

        End If

        dataAdapt.Dispose()
        rsRcd.Clear()
        'UPGRADE_NOTE: Object rsRcd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsRcd = Nothing
    End Function

    Public Function Get_CusCreditAmt(ByVal InCusID As Integer, ByVal inDate As String) As Double

        Dim adCmd As New SqlClient.SqlCommand

        On Error GoTo Get_CusCreditAmt_Err

        adCmd.Connection = cnCon

        adCmd.CommandText = "USP_GETCUSCREDITAMT"
        adCmd.CommandType = CommandType.StoredProcedure
        'adCmd.Parameters.Refresh()
        SqlClient.SqlCommandBuilder.DeriveParameters(adCmd)

        Call SetSPPara(adCmd, 1, InCusID)
        Call SetSPPara(adCmd, 2, inDate)

        adCmd.ExecuteNonQuery()

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Get_CusCreditAmt = GetSPPara(adCmd, 3)

        'UPGRADE_NOTE: Object adCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adCmd = Nothing

        Exit Function

Get_CusCreditAmt_Err:
        MsgBox("Get_CusCreditAmt_Err!")
        'UPGRADE_NOTE: Object adCmd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adCmd = Nothing

    End Function

End Module
