Option Strict Off
Option Explicit On
Module NBVar
	
	Declare Function GetUserName Lib "advapi32.dll"  Alias "GetUserNameA"(ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
	Declare Function GetWindowsDirectory Lib "kernel32"  Alias "GetWindowsDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
	Declare Function GetSystemDirectory Lib "kernel32"  Alias "GetSystemDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
	Declare Function GetUserDefaultLCID Lib "kernel32" () As Integer
	Declare Function GetLocaleInfo Lib "kernel32"  Alias "GetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
	Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hwndInsertAfter As Integer, ByVal x As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
	Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Integer) As Integer
	Declare Function IsIconic Lib "user32" (ByVal hwnd As Integer) As Integer
	Declare Function ShowWindow Lib "user32" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
	
	
	
#Const DEBUG_FLAG = True
	
	Public giCurrIndex As Short
	
	
	Public gsMODULE As String
	Public gsExcPath As String
	Public gsRptPath As String
	Public gsComNam As String
	Public gsDteFmt As String
	Public gsHostName As String
	Public gsHostLogin As String
	
	'Global Minimum Date and Maximum Date
	Public gsDateFrom As String
	Public gsDateTo As String
	
	
    Public cnCon As New SqlClient.SqlConnection '-- ADO connection for manual use.
	
	Public gsLangID As String
	Public gsTitle As String
	Public gsConnectString As String '-- Connection string.
	Public gsUserID As String
	Public gsSystemDate As String
	Public gsWorkStationID As String
	Public gsCompID As String
	Public gsMsg As String
	Public gsDBName As String
	Public gsWhsCode As String
	Public gsRTAccess As String
	Public gsRTPath As String
	Public gsHHPath As String
	
	
	
	Public Const DefaultPage As Short = -1
	Public Const AddRec As Short = 1
	Public Const CorRec As Short = 2
	Public Const DelRec As Short = 3
	Public Const RevRec As Short = 4
	Public Const CorRO As Short = 5
	
	
	Public Const gsQtyFmt As String = "#,##0"
	Public Const gsAmtFmt As String = "#,##0.00"
	Public Const gsUprFmt As String = "#,##0.0000"
	Public Const gsExrFmt As String = "#,##0.000000"
	
	Public Const giAmtDp As Short = 2
	Public Const giUprDp As Short = 4
	Public Const giExrDp As Short = 6
	Public Const giQtyDp As Short = 0
	
	
	Public Const HWND_BOTTOM As Short = 1
	Public Const HWND_BROADCAST As Integer = &HFFFF
	Public Const HWND_DESKTOP As Short = 0
	Public Const HWND_NOTOPMOST As Short = -2
	Public Const HWND_TOP As Short = 0
	Public Const HWND_TOPMOST As Short = -1
	
	Public Const SWP_DRAWFRAME As Integer = &H20
	Public Const SWP_HIDEWINDOW As Integer = &H80
	Public Const SWP_NOACTIVATE As Integer = &H10
	Public Const SWP_NOCOPYBITS As Integer = &H100
	Public Const SWP_NOMOVE As Integer = &H2
	Public Const SWP_NOREDRAW As Integer = &H8
	Public Const SWP_NOREPOSITION As Integer = &H200
	Public Const SWP_NOSIZE As Integer = &H1
	Public Const SWP_NOZORDER As Integer = &H4
	Public Const SWP_SHOWWINDOW As Integer = &H40
	
	
	'Global Minimum Value and Maximum Value
	Public Const gsMinVal As String = "-9999999999999.99"
	Public Const gsMaxVal As String = "9999999999999.99"
	
	'Global Const giTimeOut = 0
End Module