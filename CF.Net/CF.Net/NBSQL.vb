Option Strict Off
Option Explicit On

Module NBSQL

    Public Function GetSPPara(ByRef incmd As SqlClient.SqlCommand, ByVal inPara As Short) As Object

        'UPGRADE_WARNING: Couldn't resolve default property of object GetSPPara. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetSPPara = incmd.Parameters(inPara).Value

    End Function

    Public Function ReadRs(ByVal inRs As System.Data.DataTable, ByRef inCol As Object) As String

        'inCol is the column no (0 based) or column name

        Dim TmpCol As Object

        On Error GoTo ReadRs_Err

        'UPGRADE_WARNING: Couldn't resolve default property of object inCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object TmpCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        TmpCol = inCol

        If inRs Is Nothing Then
            Return ""
            Exit Function
        End If

        If inRs.Rows.Count <= 0 Then
            Return ""
            Exit Function
        End If

        If IsNumeric(TmpCol) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object inCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object TmpCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TmpCol = inCol
            Select Case TmpCol
                Case Is < 0
                    'UPGRADE_WARNING: Couldn't resolve default property of object TmpCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    TmpCol = 0
            End Select


        End If

        'UPGRADE_WARNING: Couldn't resolve default prope=rty of object ReadRs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ReadRs = inRs.Rows(0).Item(TmpCol).ToString

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If IsDBNull(ReadRs) Then
        '    Select Case inRs.Fields(TmpCol).Type
        '        Case ADODB.DataTypeEnum.adChar, ADODB.DataTypeEnum.adVarChar, ADODB.DataTypeEnum.adVarWChar, ADODB.DataTypeEnum.adWChar
        '            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            ReadRs = ""
        '        Case ADODB.DataTypeEnum.adCurrency, ADODB.DataTypeEnum.adDecimal, ADODB.DataTypeEnum.adDouble, ADODB.DataTypeEnum.adInteger, ADODB.DataTypeEnum.adNumeric, ADODB.DataTypeEnum.adSingle
        '            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            ReadRs = "0"
        '        Case Else
        '            'UPGRADE_WARNING: Couldn't resolve default property of object ReadRs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            ReadRs = ""
        '    End Select
        'End If

        Exit Function

ReadRs_Err:
        MsgBox(Err.Description)
        Exit Function

    End Function

    Public Function Connect_Database() As Short
        Dim giTimeOut As Integer

        Connect_Database = True

        On Error GoTo Err_Handler

        With cnCon
            .ConnectionString = gsConnectString
            .Open()
        End With

        Exit Function

Err_Handler:
        Connect_Database = False
        MsgBox("Err Connecting Database! " & Err.Description & " " & Err.Number)

    End Function

    Public Sub Disconnect_Database()

        cnCon.Close()

        'UPGRADE_NOTE: Object cnCon may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        cnCon = Nothing

    End Sub

    Public Function SetSPPara(ByRef incmd As SqlClient.SqlCommand, ByVal inPara As Short, ByVal InValue As Object) As Object

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'UPGRADE_WARNING: IsEmpty was upgraded to IsNothing and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If IsNothing(InValue) Or IsDBNull(InValue) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            InValue = ""
        End If

        With incmd.Parameters(inPara)
            Select Case .DbType
                Case SqlDbType.Char, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NChar
                    If Len(InValue) > .Size Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        InValue = Left(InValue, .Size)
                    End If
                Case SqlDbType.Money, SqlDbType.Decimal, SqlDbType.Float, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.Real
                    If IsNumeric(InValue) Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        InValue = To_Value(InValue)
                    Else
                        'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        InValue = 0
                    End If
                Case SqlDbType.Date, SqlDbType.DateTime, SqlDbType.Time, SqlDbType.Timestamp
                    'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If InValue = "" Then
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        InValue = System.DBNull.Value
                    End If
            End Select

        End With

        'UPGRADE_WARNING: Couldn't resolve default property of object InValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        incmd.Parameters(inPara).Value = InValue

        Return incmd
    End Function
End Module
