Option Strict Off
Option Explicit On
Module basMain
    Public Sub Main()
        '        Call Get_Login_File
        '        frmOpn.ZOrder 1
        'frmOpn.Show vbModal
        'frmLogin.ShowDialog()
        Dim fLogin As New frmLogin()
        fLogin.ShowDialog()

        '  Call Read_Debug_Ini(App.Path & "\" & "HH_HZ.ini")
        '  gsUserID = "HHUSR"
        '  Call Connect_Database

        gsDteFmt = "YMD"
        Call getHostLogin()
        Call Get_Date_Fmt()
        Call Get_Company_Info()
        Call Get_Company_Default()

        gsWhsCode = "1"
        gsCompID = "1"
        gsSystemDate = Format(Today, "yyyy/mm/dd")
        gsTitle = gsComNam

        'UPGRADE_WARNING: Form method nbMain.ZOrder has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'Form1.Show()
        Dim nM As New nbMain()
        nM.ShowDialog()
        'nbMain.BringToFront()

    End Sub
End Module
