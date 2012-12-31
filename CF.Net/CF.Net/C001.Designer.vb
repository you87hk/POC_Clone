<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmC001
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmC001))
        Me.tblDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbrProcess = New System.Windows.Forms.ToolStrip()
        Me.iglProcess = New System.Windows.Forms.ImageList(Me.components)
        Me._tbrProcess_Button1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarOpen = New System.Windows.Forms.ToolStripButton()
        Me.toolBarAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolBarEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolBarDelete = New System.Windows.Forms.ToolStripButton()
        Me._tbrProcess_Button6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBarCancel = New System.Windows.Forms.ToolStripButton()
        Me._tbrProcess_Button9 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarFind = New System.Windows.Forms.ToolStripButton()
        Me._tbrProcess_Button11 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarExit = New System.Windows.Forms.ToolStripButton()
        Me.fraCustomerInfo = New System.Windows.Forms.GroupBox()
        Me.txtCusTel = New System.Windows.Forms.TextBox()
        Me.txtCusName = New System.Windows.Forms.TextBox()
        Me.txtCusFax = New System.Windows.Forms.TextBox()
        Me.txtCusEmail = New System.Windows.Forms.TextBox()
        Me.txtCusContactPerson1 = New System.Windows.Forms.TextBox()
        Me.txtCusContactPerson = New System.Windows.Forms.TextBox()
        Me.lblCusTel = New System.Windows.Forms.Label()
        Me.lblCusName = New System.Windows.Forms.Label()
        Me.lblCusFax = New System.Windows.Forms.Label()
        Me.lblCusEmail = New System.Windows.Forms.Label()
        Me.lblCusContactPerson1 = New System.Windows.Forms.Label()
        Me.lblCusContactPerson = New System.Windows.Forms.Label()
        Me.chkInActive = New System.Windows.Forms.CheckBox()
        Me.chkBadList = New System.Windows.Forms.CheckBox()
        Me.cboCusCode = New System.Windows.Forms.ComboBox()
        Me.txtCusCode = New System.Windows.Forms.TextBox()
        Me.lblCusCode = New System.Windows.Forms.Label()
        Me.tabDetailInfo = New System.Windows.Forms.TabControl()
        Me._tabDetailInfo_TabPage0 = New System.Windows.Forms.TabPage()
        Me.txtCusAddress4 = New System.Windows.Forms.TextBox()
        Me.txtCusAddress3 = New System.Windows.Forms.TextBox()
        Me.txtCusAddress2 = New System.Windows.Forms.TextBox()
        Me.txtCusAddress1 = New System.Windows.Forms.TextBox()
        Me.lblDspCusRgnDesc = New System.Windows.Forms.Label()
        Me.lblCusRgnCode = New System.Windows.Forms.Label()
        Me.lblCusAddress1 = New System.Windows.Forms.Label()
        Me.cboCusRgnCode = New System.Windows.Forms.ComboBox()
        Me._tabDetailInfo_TabPage1 = New System.Windows.Forms.TabPage()
        Me.fraCusShipAddr2 = New System.Windows.Forms.GroupBox()
        Me.txtCusShipTerrName2 = New System.Windows.Forms.TextBox()
        Me.txtCusShipTel2 = New System.Windows.Forms.TextBox()
        Me.txtCusShipFax2 = New System.Windows.Forms.TextBox()
        Me.txtCusShipContactPerson2 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd42 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd32 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd22 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd12 = New System.Windows.Forms.TextBox()
        Me.lblCusShipTerrCode2 = New System.Windows.Forms.Label()
        Me.lblCusShipTel2 = New System.Windows.Forms.Label()
        Me.lblCusShipContactPerson2 = New System.Windows.Forms.Label()
        Me.lblCusShipAdd2 = New System.Windows.Forms.Label()
        Me.cboCusShipTerrCode2 = New System.Windows.Forms.ComboBox()
        Me.fraCusShipAddr1 = New System.Windows.Forms.GroupBox()
        Me.txtCusShipTerrName = New System.Windows.Forms.TextBox()
        Me.txtCusShipTel = New System.Windows.Forms.TextBox()
        Me.txtCusShipFax = New System.Windows.Forms.TextBox()
        Me.txtCusShipContactPerson = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd4 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd3 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd2 = New System.Windows.Forms.TextBox()
        Me.txtCusShipAdd1 = New System.Windows.Forms.TextBox()
        Me.lblCusShipTerrCode = New System.Windows.Forms.Label()
        Me.lblCusShipTel = New System.Windows.Forms.Label()
        Me.lblCusShipContactPerson = New System.Windows.Forms.Label()
        Me.lblCusShipAdd1 = New System.Windows.Forms.Label()
        Me.cboCusShipTerrCode = New System.Windows.Forms.ComboBox()
        Me._tabDetailInfo_TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtCusSpecDis = New System.Windows.Forms.TextBox()
        Me.txtCusRemark = New System.Windows.Forms.TextBox()
        Me.txtCusPayDesc = New System.Windows.Forms.TextBox()
        Me.txtCusCreditLimit = New System.Windows.Forms.TextBox()
        Me.lblDspCusSaleName = New System.Windows.Forms.Label()
        Me.lblDspCusMLDesc = New System.Windows.Forms.Label()
        Me.lblDspCusLastUpdDate = New System.Windows.Forms.Label()
        Me.lblDspCusLastUpd = New System.Windows.Forms.Label()
        Me.lblCusSpecDis = New System.Windows.Forms.Label()
        Me.lblCusSaleName = New System.Windows.Forms.Label()
        Me.lblCusRemark = New System.Windows.Forms.Label()
        Me.lblCusPayCode = New System.Windows.Forms.Label()
        Me.lblCusMLCode = New System.Windows.Forms.Label()
        Me.lblCusLastUpdDate = New System.Windows.Forms.Label()
        Me.lblCusLastUpd = New System.Windows.Forms.Label()
        Me.lblCusCurr = New System.Windows.Forms.Label()
        Me.lblCusCreditLimit = New System.Windows.Forms.Label()
        Me.cboCusSaleCode = New System.Windows.Forms.ComboBox()
        Me.cboCusPayCode = New System.Windows.Forms.ComboBox()
        Me.cboCusMLCode = New System.Windows.Forms.ComboBox()
        Me.cboCusCurr = New System.Windows.Forms.ComboBox()
        Me._tabDetailInfo_TabPage3 = New System.Windows.Forms.TabPage()
        Me.tblCommon = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblOpenBal = New System.Windows.Forms.Label()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.lblDspOpenBal = New System.Windows.Forms.Label()
        Me.lblDspCrtDate = New System.Windows.Forms.Label()
        Me.lblDspCloseBal = New System.Windows.Forms.Label()
        Me.lblDspARBal = New System.Windows.Forms.Label()
        Me.lblDspAcmYrSaleQty = New System.Windows.Forms.Label()
        Me.lblDspAcmYrSaleNet = New System.Windows.Forms.Label()
        Me.lblDspAcmYrSaleAmt = New System.Windows.Forms.Label()
        Me.lblDspAcmSaleQty = New System.Windows.Forms.Label()
        Me.lblDspAcmSaleNet = New System.Windows.Forms.Label()
        Me.lblDspAcmSaleAmt = New System.Windows.Forms.Label()
        Me.lblDspAcmMnSaleQty = New System.Windows.Forms.Label()
        Me.lblDspAcmMnSaleNet = New System.Windows.Forms.Label()
        Me.lblDspAcmMnSaleAmt = New System.Windows.Forms.Label()
        Me.lblCusCrtDate = New System.Windows.Forms.Label()
        Me.lblCloseBal = New System.Windows.Forms.Label()
        Me.lblARBal = New System.Windows.Forms.Label()
        Me.lblAmt = New System.Windows.Forms.Label()
        Me.lblAcmYrSale = New System.Windows.Forms.Label()
        Me.lblAcmSale = New System.Windows.Forms.Label()
        Me.lblAcmMnSale = New System.Windows.Forms.Label()
        Me.txtSaleID = New System.Windows.Forms.TextBox()
        CType(Me.tblDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrProcess.SuspendLayout()
        Me.fraCustomerInfo.SuspendLayout()
        Me.tabDetailInfo.SuspendLayout()
        Me._tabDetailInfo_TabPage0.SuspendLayout()
        Me._tabDetailInfo_TabPage1.SuspendLayout()
        Me.fraCusShipAddr2.SuspendLayout()
        Me.fraCusShipAddr1.SuspendLayout()
        Me._tabDetailInfo_TabPage2.SuspendLayout()
        Me._tabDetailInfo_TabPage3.SuspendLayout()
        CType(Me.tblCommon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblDetail
        '
        Me.tblDetail.Location = New System.Drawing.Point(0, 0)
        Me.tblDetail.Name = "tblDetail"
        Me.tblDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblDetail.PreviewInfo.ZoomFactor = 75.0R
        Me.tblDetail.PrintInfo.PageSettings = CType(resources.GetObject("tblDetail.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblDetail.PropBag = resources.GetString("tblDetail.PropBag")
        Me.tblDetail.Size = New System.Drawing.Size(75, 23)
        Me.tblDetail.TabIndex = 0
        '
        'tbrProcess
        '
        Me.tbrProcess.ImageList = Me.iglProcess
        Me.tbrProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tbrProcess_Button1, Me.toolBarOpen, Me.toolBarAdd, Me.toolBarEdit, Me.toolBarDelete, Me._tbrProcess_Button6, Me.toolBarSave, Me.toolBarCancel, Me._tbrProcess_Button9, Me.toolBarFind, Me._tbrProcess_Button11, Me.toolBarExit})
        Me.tbrProcess.Location = New System.Drawing.Point(0, 0)
        Me.tbrProcess.Name = "tbrProcess"
        Me.tbrProcess.Size = New System.Drawing.Size(663, 25)
        Me.tbrProcess.TabIndex = 43
        '
        'iglProcess
        '
        Me.iglProcess.ImageStream = CType(resources.GetObject("iglProcess.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iglProcess.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.iglProcess.Images.SetKeyName(0, "")
        Me.iglProcess.Images.SetKeyName(1, "")
        Me.iglProcess.Images.SetKeyName(2, "")
        Me.iglProcess.Images.SetKeyName(3, "")
        Me.iglProcess.Images.SetKeyName(4, "")
        Me.iglProcess.Images.SetKeyName(5, "")
        Me.iglProcess.Images.SetKeyName(6, "")
        Me.iglProcess.Images.SetKeyName(7, "")
        Me.iglProcess.Images.SetKeyName(8, "")
        Me.iglProcess.Images.SetKeyName(9, "")
        Me.iglProcess.Images.SetKeyName(10, "")
        Me.iglProcess.Images.SetKeyName(11, "")
        '
        '_tbrProcess_Button1
        '
        Me._tbrProcess_Button1.AutoSize = False
        Me._tbrProcess_Button1.Name = "_tbrProcess_Button1"
        Me._tbrProcess_Button1.Size = New System.Drawing.Size(24, 22)
        '
        'toolBarOpen
        '
        Me.toolBarOpen.AutoSize = False
        Me.toolBarOpen.ImageIndex = 11
        Me.toolBarOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarOpen.Name = "toolBarOpen"
        Me.toolBarOpen.Size = New System.Drawing.Size(24, 22)
        Me.toolBarOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarOpen.ToolTipText = "開新視窗 (F8)"
        '
        'toolBarAdd
        '
        Me.toolBarAdd.AutoSize = False
        Me.toolBarAdd.ImageIndex = 0
        Me.toolBarAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarAdd.Name = "toolBarAdd"
        Me.toolBarAdd.Size = New System.Drawing.Size(24, 22)
        Me.toolBarAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarAdd.ToolTipText = "新增 (F2)"
        '
        'toolBarEdit
        '
        Me.toolBarEdit.AutoSize = False
        Me.toolBarEdit.ImageIndex = 1
        Me.toolBarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarEdit.Name = "toolBarEdit"
        Me.toolBarEdit.Size = New System.Drawing.Size(24, 22)
        Me.toolBarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarEdit.ToolTipText = "修改 (F5)"
        '
        'toolBarDelete
        '
        Me.toolBarDelete.AutoSize = False
        Me.toolBarDelete.ImageIndex = 2
        Me.toolBarDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarDelete.Name = "toolBarDelete"
        Me.toolBarDelete.Size = New System.Drawing.Size(24, 22)
        Me.toolBarDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarDelete.ToolTipText = "刪除 (F3)"
        '
        '_tbrProcess_Button6
        '
        Me._tbrProcess_Button6.AutoSize = False
        Me._tbrProcess_Button6.Name = "_tbrProcess_Button6"
        Me._tbrProcess_Button6.Size = New System.Drawing.Size(24, 22)
        '
        'toolBarSave
        '
        Me.toolBarSave.AutoSize = False
        Me.toolBarSave.ImageIndex = 3
        Me.toolBarSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarSave.Name = "toolBarSave"
        Me.toolBarSave.Size = New System.Drawing.Size(24, 22)
        Me.toolBarSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarSave.ToolTipText = "儲存 (F10)"
        '
        'toolBarCancel
        '
        Me.toolBarCancel.AutoSize = False
        Me.toolBarCancel.ImageIndex = 4
        Me.toolBarCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarCancel.Name = "toolBarCancel"
        Me.toolBarCancel.Size = New System.Drawing.Size(24, 22)
        Me.toolBarCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarCancel.ToolTipText = "取消 (F11)"
        '
        '_tbrProcess_Button9
        '
        Me._tbrProcess_Button9.AutoSize = False
        Me._tbrProcess_Button9.Name = "_tbrProcess_Button9"
        Me._tbrProcess_Button9.Size = New System.Drawing.Size(24, 22)
        '
        'toolBarFind
        '
        Me.toolBarFind.AutoSize = False
        Me.toolBarFind.ImageIndex = 6
        Me.toolBarFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarFind.Name = "toolBarFind"
        Me.toolBarFind.Size = New System.Drawing.Size(24, 22)
        Me.toolBarFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarFind.ToolTipText = "尋找 (F9)"
        '
        '_tbrProcess_Button11
        '
        Me._tbrProcess_Button11.AutoSize = False
        Me._tbrProcess_Button11.Name = "_tbrProcess_Button11"
        Me._tbrProcess_Button11.Size = New System.Drawing.Size(24, 22)
        '
        'toolBarExit
        '
        Me.toolBarExit.AutoSize = False
        Me.toolBarExit.ImageIndex = 8
        Me.toolBarExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolBarExit.Name = "toolBarExit"
        Me.toolBarExit.Size = New System.Drawing.Size(24, 22)
        Me.toolBarExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBarExit.ToolTipText = "退出 (F12)"
        '
        'fraCustomerInfo
        '
        Me.fraCustomerInfo.BackColor = System.Drawing.SystemColors.Control
        Me.fraCustomerInfo.Controls.Add(Me.txtCusTel)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusName)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusFax)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusEmail)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusContactPerson1)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusContactPerson)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusTel)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusName)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusFax)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusEmail)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusContactPerson1)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusContactPerson)
        Me.fraCustomerInfo.Controls.Add(Me.chkInActive)
        Me.fraCustomerInfo.Controls.Add(Me.chkBadList)
        Me.fraCustomerInfo.Controls.Add(Me.cboCusCode)
        Me.fraCustomerInfo.Controls.Add(Me.txtCusCode)
        Me.fraCustomerInfo.Controls.Add(Me.lblCusCode)
        Me.fraCustomerInfo.Location = New System.Drawing.Point(8, 48)
        Me.fraCustomerInfo.Name = "fraCustomerInfo"
        Me.fraCustomerInfo.Size = New System.Drawing.Size(633, 113)
        Me.fraCustomerInfo.TabIndex = 44
        Me.fraCustomerInfo.TabStop = False
        Me.fraCustomerInfo.Text = "客戶資料"
        '
        'txtCusTel
        '
        Me.txtCusTel.AcceptsReturn = True
        Me.txtCusTel.Enabled = False
        Me.txtCusTel.Location = New System.Drawing.Point(80, 64)
        Me.txtCusTel.MaxLength = 0
        Me.txtCusTel.Name = "txtCusTel"
        Me.txtCusTel.Size = New System.Drawing.Size(159, 20)
        Me.txtCusTel.TabIndex = 4
        '
        'txtCusName
        '
        Me.txtCusName.AcceptsReturn = True
        Me.txtCusName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCusName.Enabled = False
        Me.txtCusName.Location = New System.Drawing.Point(80, 40)
        Me.txtCusName.MaxLength = 0
        Me.txtCusName.Name = "txtCusName"
        Me.txtCusName.Size = New System.Drawing.Size(423, 20)
        Me.txtCusName.TabIndex = 3
        '
        'txtCusFax
        '
        Me.txtCusFax.AcceptsReturn = True
        Me.txtCusFax.Enabled = False
        Me.txtCusFax.Location = New System.Drawing.Point(352, 64)
        Me.txtCusFax.MaxLength = 0
        Me.txtCusFax.Name = "txtCusFax"
        Me.txtCusFax.Size = New System.Drawing.Size(151, 20)
        Me.txtCusFax.TabIndex = 5
        '
        'txtCusEmail
        '
        Me.txtCusEmail.AcceptsReturn = True
        Me.txtCusEmail.Enabled = False
        Me.txtCusEmail.Location = New System.Drawing.Point(352, 16)
        Me.txtCusEmail.MaxLength = 0
        Me.txtCusEmail.Name = "txtCusEmail"
        Me.txtCusEmail.Size = New System.Drawing.Size(239, 20)
        Me.txtCusEmail.TabIndex = 2
        '
        'txtCusContactPerson1
        '
        Me.txtCusContactPerson1.AcceptsReturn = True
        Me.txtCusContactPerson1.Enabled = False
        Me.txtCusContactPerson1.Location = New System.Drawing.Point(352, 88)
        Me.txtCusContactPerson1.MaxLength = 0
        Me.txtCusContactPerson1.Name = "txtCusContactPerson1"
        Me.txtCusContactPerson1.Size = New System.Drawing.Size(151, 20)
        Me.txtCusContactPerson1.TabIndex = 7
        '
        'txtCusContactPerson
        '
        Me.txtCusContactPerson.AcceptsReturn = True
        Me.txtCusContactPerson.Enabled = False
        Me.txtCusContactPerson.Location = New System.Drawing.Point(80, 88)
        Me.txtCusContactPerson.MaxLength = 0
        Me.txtCusContactPerson.Name = "txtCusContactPerson"
        Me.txtCusContactPerson.Size = New System.Drawing.Size(159, 20)
        Me.txtCusContactPerson.TabIndex = 6
        '
        'lblCusTel
        '
        Me.lblCusTel.Location = New System.Drawing.Point(16, 68)
        Me.lblCusTel.Name = "lblCusTel"
        Me.lblCusTel.Size = New System.Drawing.Size(60, 16)
        Me.lblCusTel.TabIndex = 48
        Me.lblCusTel.Text = "電話 :"
        '
        'lblCusName
        '
        Me.lblCusName.Location = New System.Drawing.Point(16, 44)
        Me.lblCusName.Name = "lblCusName"
        Me.lblCusName.Size = New System.Drawing.Size(60, 16)
        Me.lblCusName.TabIndex = 49
        Me.lblCusName.Text = "名稱 :"
        '
        'lblCusFax
        '
        Me.lblCusFax.Location = New System.Drawing.Point(248, 68)
        Me.lblCusFax.Name = "lblCusFax"
        Me.lblCusFax.Size = New System.Drawing.Size(92, 16)
        Me.lblCusFax.TabIndex = 47
        Me.lblCusFax.Text = "傳真 :"
        '
        'lblCusEmail
        '
        Me.lblCusEmail.Location = New System.Drawing.Point(248, 20)
        Me.lblCusEmail.Name = "lblCusEmail"
        Me.lblCusEmail.Size = New System.Drawing.Size(84, 16)
        Me.lblCusEmail.TabIndex = 45
        Me.lblCusEmail.Text = "電郵 :"
        '
        'lblCusContactPerson1
        '
        Me.lblCusContactPerson1.Location = New System.Drawing.Point(248, 92)
        Me.lblCusContactPerson1.Name = "lblCusContactPerson1"
        Me.lblCusContactPerson1.Size = New System.Drawing.Size(100, 16)
        Me.lblCusContactPerson1.TabIndex = 102
        Me.lblCusContactPerson1.Text = "CUSCONTACTPERSON1"
        '
        'lblCusContactPerson
        '
        Me.lblCusContactPerson.Location = New System.Drawing.Point(16, 92)
        Me.lblCusContactPerson.Name = "lblCusContactPerson"
        Me.lblCusContactPerson.Size = New System.Drawing.Size(60, 16)
        Me.lblCusContactPerson.TabIndex = 46
        Me.lblCusContactPerson.Text = "聯絡人 :"
        '
        'chkInActive
        '
        Me.chkInActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInActive.Location = New System.Drawing.Point(512, 67)
        Me.chkInActive.Name = "chkInActive"
        Me.chkInActive.Size = New System.Drawing.Size(81, 17)
        Me.chkInActive.TabIndex = 9
        Me.chkInActive.Text = "有效 :"
        Me.chkInActive.UseVisualStyleBackColor = False
        '
        'chkBadList
        '
        Me.chkBadList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBadList.Location = New System.Drawing.Point(512, 43)
        Me.chkBadList.Name = "chkBadList"
        Me.chkBadList.Size = New System.Drawing.Size(81, 17)
        Me.chkBadList.TabIndex = 8
        Me.chkBadList.Text = "黑名單 :"
        Me.chkBadList.UseVisualStyleBackColor = False
        '
        'cboCusCode
        '
        Me.cboCusCode.DropDownWidth = 159
        Me.cboCusCode.Location = New System.Drawing.Point(80, 16)
        Me.cboCusCode.Name = "cboCusCode"
        Me.cboCusCode.Size = New System.Drawing.Size(159, 22)
        Me.cboCusCode.TabIndex = 1
        '
        'txtCusCode
        '
        Me.txtCusCode.AcceptsReturn = True
        Me.txtCusCode.Enabled = False
        Me.txtCusCode.Location = New System.Drawing.Point(80, 16)
        Me.txtCusCode.MaxLength = 0
        Me.txtCusCode.Name = "txtCusCode"
        Me.txtCusCode.Size = New System.Drawing.Size(159, 20)
        Me.txtCusCode.TabIndex = 0
        '
        'lblCusCode
        '
        Me.lblCusCode.Font = New System.Drawing.Font("細明體", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCusCode.Location = New System.Drawing.Point(16, 16)
        Me.lblCusCode.Name = "lblCusCode"
        Me.lblCusCode.Size = New System.Drawing.Size(84, 16)
        Me.lblCusCode.TabIndex = 50
        Me.lblCusCode.Text = "編號 :"
        '
        'tabDetailInfo
        '
        Me.tabDetailInfo.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabDetailInfo.Controls.Add(Me._tabDetailInfo_TabPage0)
        Me.tabDetailInfo.Controls.Add(Me._tabDetailInfo_TabPage1)
        Me.tabDetailInfo.Controls.Add(Me._tabDetailInfo_TabPage2)
        Me.tabDetailInfo.Controls.Add(Me._tabDetailInfo_TabPage3)
        Me.tabDetailInfo.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabDetailInfo.Location = New System.Drawing.Point(8, 168)
        Me.tabDetailInfo.Name = "tabDetailInfo"
        Me.tabDetailInfo.SelectedIndex = 0
        Me.tabDetailInfo.Size = New System.Drawing.Size(633, 225)
        Me.tabDetailInfo.TabIndex = 51
        Me.tabDetailInfo.TabStop = False
        '
        '_tabDetailInfo_TabPage0
        '
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.txtCusAddress4)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.txtCusAddress3)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.txtCusAddress2)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.txtCusAddress1)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.lblDspCusRgnDesc)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.lblCusRgnCode)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.lblCusAddress1)
        Me._tabDetailInfo_TabPage0.Controls.Add(Me.cboCusRgnCode)
        Me._tabDetailInfo_TabPage0.Location = New System.Drawing.Point(4, 4)
        Me._tabDetailInfo_TabPage0.Name = "_tabDetailInfo_TabPage0"
        Me._tabDetailInfo_TabPage0.Padding = New System.Windows.Forms.Padding(3)
        Me._tabDetailInfo_TabPage0.Size = New System.Drawing.Size(625, 199)
        Me._tabDetailInfo_TabPage0.TabIndex = 0
        Me._tabDetailInfo_TabPage0.Text = "附加通訊資料"
        '
        'txtCusAddress4
        '
        Me.txtCusAddress4.AcceptsReturn = True
        Me.txtCusAddress4.Location = New System.Drawing.Point(80, 92)
        Me.txtCusAddress4.MaxLength = 0
        Me.txtCusAddress4.Name = "txtCusAddress4"
        Me.txtCusAddress4.Size = New System.Drawing.Size(513, 20)
        Me.txtCusAddress4.TabIndex = 13
        '
        'txtCusAddress3
        '
        Me.txtCusAddress3.AcceptsReturn = True
        Me.txtCusAddress3.Location = New System.Drawing.Point(80, 68)
        Me.txtCusAddress3.MaxLength = 0
        Me.txtCusAddress3.Name = "txtCusAddress3"
        Me.txtCusAddress3.Size = New System.Drawing.Size(513, 20)
        Me.txtCusAddress3.TabIndex = 12
        '
        'txtCusAddress2
        '
        Me.txtCusAddress2.AcceptsReturn = True
        Me.txtCusAddress2.Location = New System.Drawing.Point(80, 44)
        Me.txtCusAddress2.MaxLength = 0
        Me.txtCusAddress2.Name = "txtCusAddress2"
        Me.txtCusAddress2.Size = New System.Drawing.Size(513, 20)
        Me.txtCusAddress2.TabIndex = 11
        '
        'txtCusAddress1
        '
        Me.txtCusAddress1.AcceptsReturn = True
        Me.txtCusAddress1.Location = New System.Drawing.Point(80, 20)
        Me.txtCusAddress1.MaxLength = 0
        Me.txtCusAddress1.Name = "txtCusAddress1"
        Me.txtCusAddress1.Size = New System.Drawing.Size(513, 20)
        Me.txtCusAddress1.TabIndex = 10
        '
        'lblDspCusRgnDesc
        '
        Me.lblDspCusRgnDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCusRgnDesc.Location = New System.Drawing.Point(240, 116)
        Me.lblDspCusRgnDesc.Name = "lblDspCusRgnDesc"
        Me.lblDspCusRgnDesc.Size = New System.Drawing.Size(351, 20)
        Me.lblDspCusRgnDesc.TabIndex = 70
        '
        'lblCusRgnCode
        '
        Me.lblCusRgnCode.Location = New System.Drawing.Point(8, 120)
        Me.lblCusRgnCode.Name = "lblCusRgnCode"
        Me.lblCusRgnCode.Size = New System.Drawing.Size(69, 16)
        Me.lblCusRgnCode.TabIndex = 71
        Me.lblCusRgnCode.Text = "CUSRGNCODE"
        '
        'lblCusAddress1
        '
        Me.lblCusAddress1.Location = New System.Drawing.Point(16, 24)
        Me.lblCusAddress1.Name = "lblCusAddress1"
        Me.lblCusAddress1.Size = New System.Drawing.Size(57, 17)
        Me.lblCusAddress1.TabIndex = 64
        Me.lblCusAddress1.Text = "發票地址 :"
        '
        'cboCusRgnCode
        '
        Me.cboCusRgnCode.DropDownWidth = 157
        Me.cboCusRgnCode.Enabled = False
        Me.cboCusRgnCode.Location = New System.Drawing.Point(80, 116)
        Me.cboCusRgnCode.Name = "cboCusRgnCode"
        Me.cboCusRgnCode.Size = New System.Drawing.Size(157, 22)
        Me.cboCusRgnCode.TabIndex = 14
        '
        '_tabDetailInfo_TabPage1
        '
        Me._tabDetailInfo_TabPage1.Controls.Add(Me.fraCusShipAddr2)
        Me._tabDetailInfo_TabPage1.Controls.Add(Me.fraCusShipAddr1)
        Me._tabDetailInfo_TabPage1.Location = New System.Drawing.Point(4, 4)
        Me._tabDetailInfo_TabPage1.Name = "_tabDetailInfo_TabPage1"
        Me._tabDetailInfo_TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me._tabDetailInfo_TabPage1.Size = New System.Drawing.Size(625, 199)
        Me._tabDetailInfo_TabPage1.TabIndex = 1
        Me._tabDetailInfo_TabPage1.Text = "貨運資料"
        '
        'fraCusShipAddr2
        '
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipTerrName2)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipTel2)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipFax2)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipContactPerson2)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipAdd42)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipAdd32)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipAdd22)
        Me.fraCusShipAddr2.Controls.Add(Me.txtCusShipAdd12)
        Me.fraCusShipAddr2.Controls.Add(Me.lblCusShipTerrCode2)
        Me.fraCusShipAddr2.Controls.Add(Me.lblCusShipTel2)
        Me.fraCusShipAddr2.Controls.Add(Me.lblCusShipContactPerson2)
        Me.fraCusShipAddr2.Controls.Add(Me.lblCusShipAdd2)
        Me.fraCusShipAddr2.Controls.Add(Me.cboCusShipTerrCode2)
        Me.fraCusShipAddr2.Location = New System.Drawing.Point(304, 8)
        Me.fraCusShipAddr2.Name = "fraCusShipAddr2"
        Me.fraCusShipAddr2.Padding = New System.Windows.Forms.Padding(0)
        Me.fraCusShipAddr2.Size = New System.Drawing.Size(297, 185)
        Me.fraCusShipAddr2.TabIndex = 57
        Me.fraCusShipAddr2.TabStop = False
        Me.fraCusShipAddr2.Text = "地址 (二)"
        '
        'txtCusShipTerrName2
        '
        Me.txtCusShipTerrName2.AcceptsReturn = True
        Me.txtCusShipTerrName2.Enabled = False
        Me.txtCusShipTerrName2.Location = New System.Drawing.Point(160, 160)
        Me.txtCusShipTerrName2.MaxLength = 0
        Me.txtCusShipTerrName2.Name = "txtCusShipTerrName2"
        Me.txtCusShipTerrName2.Size = New System.Drawing.Size(129, 20)
        Me.txtCusShipTerrName2.TabIndex = 32
        '
        'txtCusShipTel2
        '
        Me.txtCusShipTel2.AcceptsReturn = True
        Me.txtCusShipTel2.Enabled = False
        Me.txtCusShipTel2.Location = New System.Drawing.Point(80, 136)
        Me.txtCusShipTel2.MaxLength = 0
        Me.txtCusShipTel2.Name = "txtCusShipTel2"
        Me.txtCusShipTel2.Size = New System.Drawing.Size(95, 20)
        Me.txtCusShipTel2.TabIndex = 29
        '
        'txtCusShipFax2
        '
        Me.txtCusShipFax2.AcceptsReturn = True
        Me.txtCusShipFax2.Enabled = False
        Me.txtCusShipFax2.Location = New System.Drawing.Point(184, 136)
        Me.txtCusShipFax2.MaxLength = 0
        Me.txtCusShipFax2.Name = "txtCusShipFax2"
        Me.txtCusShipFax2.Size = New System.Drawing.Size(105, 20)
        Me.txtCusShipFax2.TabIndex = 30
        '
        'txtCusShipContactPerson2
        '
        Me.txtCusShipContactPerson2.AcceptsReturn = True
        Me.txtCusShipContactPerson2.Enabled = False
        Me.txtCusShipContactPerson2.Location = New System.Drawing.Point(80, 112)
        Me.txtCusShipContactPerson2.MaxLength = 0
        Me.txtCusShipContactPerson2.Name = "txtCusShipContactPerson2"
        Me.txtCusShipContactPerson2.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipContactPerson2.TabIndex = 28
        '
        'txtCusShipAdd42
        '
        Me.txtCusShipAdd42.AcceptsReturn = True
        Me.txtCusShipAdd42.Enabled = False
        Me.txtCusShipAdd42.Location = New System.Drawing.Point(80, 88)
        Me.txtCusShipAdd42.MaxLength = 0
        Me.txtCusShipAdd42.Name = "txtCusShipAdd42"
        Me.txtCusShipAdd42.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd42.TabIndex = 27
        '
        'txtCusShipAdd32
        '
        Me.txtCusShipAdd32.AcceptsReturn = True
        Me.txtCusShipAdd32.Enabled = False
        Me.txtCusShipAdd32.Location = New System.Drawing.Point(80, 64)
        Me.txtCusShipAdd32.MaxLength = 0
        Me.txtCusShipAdd32.Name = "txtCusShipAdd32"
        Me.txtCusShipAdd32.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd32.TabIndex = 26
        '
        'txtCusShipAdd22
        '
        Me.txtCusShipAdd22.AcceptsReturn = True
        Me.txtCusShipAdd22.Enabled = False
        Me.txtCusShipAdd22.Location = New System.Drawing.Point(80, 40)
        Me.txtCusShipAdd22.MaxLength = 0
        Me.txtCusShipAdd22.Name = "txtCusShipAdd22"
        Me.txtCusShipAdd22.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd22.TabIndex = 25
        '
        'txtCusShipAdd12
        '
        Me.txtCusShipAdd12.AcceptsReturn = True
        Me.txtCusShipAdd12.Enabled = False
        Me.txtCusShipAdd12.Location = New System.Drawing.Point(80, 16)
        Me.txtCusShipAdd12.MaxLength = 0
        Me.txtCusShipAdd12.Name = "txtCusShipAdd12"
        Me.txtCusShipAdd12.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd12.TabIndex = 24
        '
        'lblCusShipTerrCode2
        '
        Me.lblCusShipTerrCode2.Location = New System.Drawing.Point(8, 164)
        Me.lblCusShipTerrCode2.Name = "lblCusShipTerrCode2"
        Me.lblCusShipTerrCode2.Size = New System.Drawing.Size(68, 16)
        Me.lblCusShipTerrCode2.TabIndex = 58
        Me.lblCusShipTerrCode2.Text = "分區代號 :"
        '
        'lblCusShipTel2
        '
        Me.lblCusShipTel2.Location = New System.Drawing.Point(8, 140)
        Me.lblCusShipTel2.Name = "lblCusShipTel2"
        Me.lblCusShipTel2.Size = New System.Drawing.Size(68, 16)
        Me.lblCusShipTel2.TabIndex = 59
        Me.lblCusShipTel2.Text = "電話 / 傳真 :"
        '
        'lblCusShipContactPerson2
        '
        Me.lblCusShipContactPerson2.Location = New System.Drawing.Point(8, 115)
        Me.lblCusShipContactPerson2.Name = "lblCusShipContactPerson2"
        Me.lblCusShipContactPerson2.Size = New System.Drawing.Size(60, 16)
        Me.lblCusShipContactPerson2.TabIndex = 60
        Me.lblCusShipContactPerson2.Text = "聯絡人 :"
        '
        'lblCusShipAdd2
        '
        Me.lblCusShipAdd2.Location = New System.Drawing.Point(8, 20)
        Me.lblCusShipAdd2.Name = "lblCusShipAdd2"
        Me.lblCusShipAdd2.Size = New System.Drawing.Size(60, 40)
        Me.lblCusShipAdd2.TabIndex = 61
        Me.lblCusShipAdd2.Text = "送貨地址 :"
        '
        'cboCusShipTerrCode2
        '
        Me.cboCusShipTerrCode2.Location = New System.Drawing.Point(80, 160)
        Me.cboCusShipTerrCode2.Name = "cboCusShipTerrCode2"
        Me.cboCusShipTerrCode2.Size = New System.Drawing.Size(77, 22)
        Me.cboCusShipTerrCode2.TabIndex = 31
        '
        'fraCusShipAddr1
        '
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipTerrName)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipTel)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipFax)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipContactPerson)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipAdd4)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipAdd3)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipAdd2)
        Me.fraCusShipAddr1.Controls.Add(Me.txtCusShipAdd1)
        Me.fraCusShipAddr1.Controls.Add(Me.lblCusShipTerrCode)
        Me.fraCusShipAddr1.Controls.Add(Me.lblCusShipTel)
        Me.fraCusShipAddr1.Controls.Add(Me.lblCusShipContactPerson)
        Me.fraCusShipAddr1.Controls.Add(Me.lblCusShipAdd1)
        Me.fraCusShipAddr1.Controls.Add(Me.cboCusShipTerrCode)
        Me.fraCusShipAddr1.Location = New System.Drawing.Point(8, 8)
        Me.fraCusShipAddr1.Name = "fraCusShipAddr1"
        Me.fraCusShipAddr1.Padding = New System.Windows.Forms.Padding(0)
        Me.fraCusShipAddr1.Size = New System.Drawing.Size(297, 185)
        Me.fraCusShipAddr1.TabIndex = 52
        Me.fraCusShipAddr1.TabStop = False
        Me.fraCusShipAddr1.Text = "地址 (一) "
        '
        'txtCusShipTerrName
        '
        Me.txtCusShipTerrName.AcceptsReturn = True
        Me.txtCusShipTerrName.Enabled = False
        Me.txtCusShipTerrName.Location = New System.Drawing.Point(160, 160)
        Me.txtCusShipTerrName.MaxLength = 0
        Me.txtCusShipTerrName.Name = "txtCusShipTerrName"
        Me.txtCusShipTerrName.Size = New System.Drawing.Size(129, 20)
        Me.txtCusShipTerrName.TabIndex = 23
        '
        'txtCusShipTel
        '
        Me.txtCusShipTel.AcceptsReturn = True
        Me.txtCusShipTel.Enabled = False
        Me.txtCusShipTel.Location = New System.Drawing.Point(80, 136)
        Me.txtCusShipTel.MaxLength = 0
        Me.txtCusShipTel.Name = "txtCusShipTel"
        Me.txtCusShipTel.Size = New System.Drawing.Size(95, 20)
        Me.txtCusShipTel.TabIndex = 20
        '
        'txtCusShipFax
        '
        Me.txtCusShipFax.AcceptsReturn = True
        Me.txtCusShipFax.Enabled = False
        Me.txtCusShipFax.Location = New System.Drawing.Point(184, 136)
        Me.txtCusShipFax.MaxLength = 0
        Me.txtCusShipFax.Name = "txtCusShipFax"
        Me.txtCusShipFax.Size = New System.Drawing.Size(105, 20)
        Me.txtCusShipFax.TabIndex = 21
        '
        'txtCusShipContactPerson
        '
        Me.txtCusShipContactPerson.AcceptsReturn = True
        Me.txtCusShipContactPerson.Enabled = False
        Me.txtCusShipContactPerson.Location = New System.Drawing.Point(80, 112)
        Me.txtCusShipContactPerson.MaxLength = 0
        Me.txtCusShipContactPerson.Name = "txtCusShipContactPerson"
        Me.txtCusShipContactPerson.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipContactPerson.TabIndex = 19
        '
        'txtCusShipAdd4
        '
        Me.txtCusShipAdd4.AcceptsReturn = True
        Me.txtCusShipAdd4.Enabled = False
        Me.txtCusShipAdd4.Location = New System.Drawing.Point(80, 88)
        Me.txtCusShipAdd4.MaxLength = 0
        Me.txtCusShipAdd4.Name = "txtCusShipAdd4"
        Me.txtCusShipAdd4.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd4.TabIndex = 18
        '
        'txtCusShipAdd3
        '
        Me.txtCusShipAdd3.AcceptsReturn = True
        Me.txtCusShipAdd3.Enabled = False
        Me.txtCusShipAdd3.Location = New System.Drawing.Point(80, 64)
        Me.txtCusShipAdd3.MaxLength = 0
        Me.txtCusShipAdd3.Name = "txtCusShipAdd3"
        Me.txtCusShipAdd3.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd3.TabIndex = 17
        '
        'txtCusShipAdd2
        '
        Me.txtCusShipAdd2.AcceptsReturn = True
        Me.txtCusShipAdd2.Enabled = False
        Me.txtCusShipAdd2.Location = New System.Drawing.Point(80, 40)
        Me.txtCusShipAdd2.MaxLength = 0
        Me.txtCusShipAdd2.Name = "txtCusShipAdd2"
        Me.txtCusShipAdd2.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd2.TabIndex = 16
        '
        'txtCusShipAdd1
        '
        Me.txtCusShipAdd1.AcceptsReturn = True
        Me.txtCusShipAdd1.Enabled = False
        Me.txtCusShipAdd1.Location = New System.Drawing.Point(80, 16)
        Me.txtCusShipAdd1.MaxLength = 0
        Me.txtCusShipAdd1.Name = "txtCusShipAdd1"
        Me.txtCusShipAdd1.Size = New System.Drawing.Size(209, 20)
        Me.txtCusShipAdd1.TabIndex = 15
        '
        'lblCusShipTerrCode
        '
        Me.lblCusShipTerrCode.Location = New System.Drawing.Point(8, 164)
        Me.lblCusShipTerrCode.Name = "lblCusShipTerrCode"
        Me.lblCusShipTerrCode.Size = New System.Drawing.Size(68, 16)
        Me.lblCusShipTerrCode.TabIndex = 56
        Me.lblCusShipTerrCode.Text = "分區代號 :"
        '
        'lblCusShipTel
        '
        Me.lblCusShipTel.Location = New System.Drawing.Point(8, 140)
        Me.lblCusShipTel.Name = "lblCusShipTel"
        Me.lblCusShipTel.Size = New System.Drawing.Size(68, 16)
        Me.lblCusShipTel.TabIndex = 55
        Me.lblCusShipTel.Text = "電話 / 傳真 :"
        '
        'lblCusShipContactPerson
        '
        Me.lblCusShipContactPerson.Location = New System.Drawing.Point(8, 115)
        Me.lblCusShipContactPerson.Name = "lblCusShipContactPerson"
        Me.lblCusShipContactPerson.Size = New System.Drawing.Size(60, 16)
        Me.lblCusShipContactPerson.TabIndex = 54
        Me.lblCusShipContactPerson.Text = "聯絡人 :"
        '
        'lblCusShipAdd1
        '
        Me.lblCusShipAdd1.Location = New System.Drawing.Point(8, 20)
        Me.lblCusShipAdd1.Name = "lblCusShipAdd1"
        Me.lblCusShipAdd1.Size = New System.Drawing.Size(60, 40)
        Me.lblCusShipAdd1.TabIndex = 53
        Me.lblCusShipAdd1.Text = "送貨地址 :"
        '
        'cboCusShipTerrCode
        '
        Me.cboCusShipTerrCode.Location = New System.Drawing.Point(80, 160)
        Me.cboCusShipTerrCode.Name = "cboCusShipTerrCode"
        Me.cboCusShipTerrCode.Size = New System.Drawing.Size(77, 22)
        Me.cboCusShipTerrCode.TabIndex = 22
        '
        '_tabDetailInfo_TabPage2
        '
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.txtCusSpecDis)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.txtCusRemark)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.txtCusPayDesc)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.txtCusCreditLimit)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblDspCusSaleName)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblDspCusMLDesc)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblDspCusLastUpdDate)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblDspCusLastUpd)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusSpecDis)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusSaleName)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusRemark)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusPayCode)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusMLCode)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusLastUpdDate)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusLastUpd)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusCurr)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.lblCusCreditLimit)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.cboCusSaleCode)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.cboCusPayCode)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.cboCusMLCode)
        Me._tabDetailInfo_TabPage2.Controls.Add(Me.cboCusCurr)
        Me._tabDetailInfo_TabPage2.Location = New System.Drawing.Point(4, 4)
        Me._tabDetailInfo_TabPage2.Name = "_tabDetailInfo_TabPage2"
        Me._tabDetailInfo_TabPage2.Size = New System.Drawing.Size(625, 199)
        Me._tabDetailInfo_TabPage2.TabIndex = 2
        Me._tabDetailInfo_TabPage2.Text = "其他資料"
        '
        'txtCusSpecDis
        '
        Me.txtCusSpecDis.AcceptsReturn = True
        Me.txtCusSpecDis.Enabled = False
        Me.txtCusSpecDis.Location = New System.Drawing.Point(408, 40)
        Me.txtCusSpecDis.MaxLength = 0
        Me.txtCusSpecDis.Name = "txtCusSpecDis"
        Me.txtCusSpecDis.Size = New System.Drawing.Size(89, 20)
        Me.txtCusSpecDis.TabIndex = 38
        '
        'txtCusRemark
        '
        Me.txtCusRemark.AcceptsReturn = True
        Me.txtCusRemark.Enabled = False
        Me.txtCusRemark.Location = New System.Drawing.Point(112, 88)
        Me.txtCusRemark.MaxLength = 0
        Me.txtCusRemark.Multiline = True
        Me.txtCusRemark.Name = "txtCusRemark"
        Me.txtCusRemark.Size = New System.Drawing.Size(511, 68)
        Me.txtCusRemark.TabIndex = 40
        '
        'txtCusPayDesc
        '
        Me.txtCusPayDesc.AcceptsReturn = True
        Me.txtCusPayDesc.Enabled = False
        Me.txtCusPayDesc.Location = New System.Drawing.Point(200, 16)
        Me.txtCusPayDesc.MaxLength = 0
        Me.txtCusPayDesc.Name = "txtCusPayDesc"
        Me.txtCusPayDesc.Size = New System.Drawing.Size(116, 20)
        Me.txtCusPayDesc.TabIndex = 34
        '
        'txtCusCreditLimit
        '
        Me.txtCusCreditLimit.AcceptsReturn = True
        Me.txtCusCreditLimit.Enabled = False
        Me.txtCusCreditLimit.Location = New System.Drawing.Point(240, 40)
        Me.txtCusCreditLimit.MaxLength = 0
        Me.txtCusCreditLimit.Name = "txtCusCreditLimit"
        Me.txtCusCreditLimit.Size = New System.Drawing.Size(77, 20)
        Me.txtCusCreditLimit.TabIndex = 37
        '
        'lblDspCusSaleName
        '
        Me.lblDspCusSaleName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCusSaleName.Location = New System.Drawing.Point(496, 16)
        Me.lblDspCusSaleName.Name = "lblDspCusSaleName"
        Me.lblDspCusSaleName.Size = New System.Drawing.Size(127, 20)
        Me.lblDspCusSaleName.TabIndex = 101
        '
        'lblDspCusMLDesc
        '
        Me.lblDspCusMLDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCusMLDesc.Location = New System.Drawing.Point(240, 64)
        Me.lblDspCusMLDesc.Name = "lblDspCusMLDesc"
        Me.lblDspCusMLDesc.Size = New System.Drawing.Size(384, 20)
        Me.lblDspCusMLDesc.TabIndex = 69
        '
        'lblDspCusLastUpdDate
        '
        Me.lblDspCusLastUpdDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCusLastUpdDate.Location = New System.Drawing.Point(496, 176)
        Me.lblDspCusLastUpdDate.Name = "lblDspCusLastUpdDate"
        Me.lblDspCusLastUpdDate.Size = New System.Drawing.Size(129, 20)
        Me.lblDspCusLastUpdDate.TabIndex = 95
        '
        'lblDspCusLastUpd
        '
        Me.lblDspCusLastUpd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCusLastUpd.Location = New System.Drawing.Point(168, 176)
        Me.lblDspCusLastUpd.Name = "lblDspCusLastUpd"
        Me.lblDspCusLastUpd.Size = New System.Drawing.Size(121, 20)
        Me.lblDspCusLastUpd.TabIndex = 96
        '
        'lblCusSpecDis
        '
        Me.lblCusSpecDis.Location = New System.Drawing.Point(320, 44)
        Me.lblCusSpecDis.Name = "lblCusSpecDis"
        Me.lblCusSpecDis.Size = New System.Drawing.Size(116, 16)
        Me.lblCusSpecDis.TabIndex = 62
        Me.lblCusSpecDis.Text = "特別折扣 :"
        '
        'lblCusSaleName
        '
        Me.lblCusSaleName.Location = New System.Drawing.Point(320, 21)
        Me.lblCusSaleName.Name = "lblCusSaleName"
        Me.lblCusSaleName.Size = New System.Drawing.Size(63, 16)
        Me.lblCusSaleName.TabIndex = 67
        Me.lblCusSaleName.Text = "營業員 :"
        '
        'lblCusRemark
        '
        Me.lblCusRemark.Location = New System.Drawing.Point(16, 88)
        Me.lblCusRemark.Name = "lblCusRemark"
        Me.lblCusRemark.Size = New System.Drawing.Size(60, 16)
        Me.lblCusRemark.TabIndex = 72
        Me.lblCusRemark.Text = "備註 :"
        '
        'lblCusPayCode
        '
        Me.lblCusPayCode.Location = New System.Drawing.Point(16, 21)
        Me.lblCusPayCode.Name = "lblCusPayCode"
        Me.lblCusPayCode.Size = New System.Drawing.Size(84, 16)
        Me.lblCusPayCode.TabIndex = 65
        Me.lblCusPayCode.Text = "付款條款 :"
        '
        'lblCusMLCode
        '
        Me.lblCusMLCode.Location = New System.Drawing.Point(16, 68)
        Me.lblCusMLCode.Name = "lblCusMLCode"
        Me.lblCusMLCode.Size = New System.Drawing.Size(93, 16)
        Me.lblCusMLCode.TabIndex = 68
        Me.lblCusMLCode.Text = "CUSMLCODE"
        '
        'lblCusLastUpdDate
        '
        Me.lblCusLastUpdDate.Location = New System.Drawing.Point(304, 181)
        Me.lblCusLastUpdDate.Name = "lblCusLastUpdDate"
        Me.lblCusLastUpdDate.Size = New System.Drawing.Size(172, 16)
        Me.lblCusLastUpdDate.TabIndex = 97
        Me.lblCusLastUpdDate.Text = "最後修改日期 :"
        '
        'lblCusLastUpd
        '
        Me.lblCusLastUpd.Location = New System.Drawing.Point(16, 181)
        Me.lblCusLastUpd.Name = "lblCusLastUpd"
        Me.lblCusLastUpd.Size = New System.Drawing.Size(143, 16)
        Me.lblCusLastUpd.TabIndex = 98
        Me.lblCusLastUpd.Text = "最後修改人 :"
        '
        'lblCusCurr
        '
        Me.lblCusCurr.Location = New System.Drawing.Point(16, 44)
        Me.lblCusCurr.Name = "lblCusCurr"
        Me.lblCusCurr.Size = New System.Drawing.Size(61, 16)
        Me.lblCusCurr.TabIndex = 63
        Me.lblCusCurr.Text = "貨幣 :"
        '
        'lblCusCreditLimit
        '
        Me.lblCusCreditLimit.Location = New System.Drawing.Point(176, 44)
        Me.lblCusCreditLimit.Name = "lblCusCreditLimit"
        Me.lblCusCreditLimit.Size = New System.Drawing.Size(68, 16)
        Me.lblCusCreditLimit.TabIndex = 66
        Me.lblCusCreditLimit.Text = "信用限度 :"
        '
        'cboCusSaleCode
        '
        Me.cboCusSaleCode.DropDownWidth = 85
        Me.cboCusSaleCode.Location = New System.Drawing.Point(408, 16)
        Me.cboCusSaleCode.Name = "cboCusSaleCode"
        Me.cboCusSaleCode.Size = New System.Drawing.Size(85, 22)
        Me.cboCusSaleCode.TabIndex = 35
        '
        'cboCusPayCode
        '
        Me.cboCusPayCode.DropDownWidth = 85
        Me.cboCusPayCode.Location = New System.Drawing.Point(112, 16)
        Me.cboCusPayCode.Name = "cboCusPayCode"
        Me.cboCusPayCode.Size = New System.Drawing.Size(85, 22)
        Me.cboCusPayCode.TabIndex = 33
        '
        'cboCusMLCode
        '
        Me.cboCusMLCode.DropDownWidth = 125
        Me.cboCusMLCode.Enabled = False
        Me.cboCusMLCode.Location = New System.Drawing.Point(112, 64)
        Me.cboCusMLCode.Name = "cboCusMLCode"
        Me.cboCusMLCode.Size = New System.Drawing.Size(125, 22)
        Me.cboCusMLCode.TabIndex = 39
        '
        'cboCusCurr
        '
        Me.cboCusCurr.DropDownWidth = 61
        Me.cboCusCurr.Enabled = False
        Me.cboCusCurr.Location = New System.Drawing.Point(112, 40)
        Me.cboCusCurr.Name = "cboCusCurr"
        Me.cboCusCurr.Size = New System.Drawing.Size(61, 22)
        Me.cboCusCurr.TabIndex = 36
        '
        '_tabDetailInfo_TabPage3
        '
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.tblCommon)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblQty)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblOpenBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblNet)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspOpenBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspCrtDate)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspCloseBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspARBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmYrSaleQty)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmYrSaleNet)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmYrSaleAmt)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmSaleQty)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmSaleNet)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmSaleAmt)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmMnSaleQty)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmMnSaleNet)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblDspAcmMnSaleAmt)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblCusCrtDate)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblCloseBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblARBal)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblAmt)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblAcmYrSale)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblAcmSale)
        Me._tabDetailInfo_TabPage3.Controls.Add(Me.lblAcmMnSale)
        Me._tabDetailInfo_TabPage3.Location = New System.Drawing.Point(4, 4)
        Me._tabDetailInfo_TabPage3.Name = "_tabDetailInfo_TabPage3"
        Me._tabDetailInfo_TabPage3.Size = New System.Drawing.Size(625, 199)
        Me._tabDetailInfo_TabPage3.TabIndex = 3
        Me._tabDetailInfo_TabPage3.Text = "備註"
        '
        'tblCommon
        '
        Me.tblCommon.Location = New System.Drawing.Point(0, 0)
        Me.tblCommon.Name = "tblCommon"
        Me.tblCommon.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblCommon.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblCommon.PreviewInfo.ZoomFactor = 75.0R
        Me.tblCommon.PrintInfo.PageSettings = CType(resources.GetObject("tblCommon.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblCommon.PropBag = resources.GetString("tblCommon.PropBag")
        Me.tblCommon.Size = New System.Drawing.Size(81, 33)
        Me.tblCommon.TabIndex = 0
        Me.tblCommon.Visible = False
        '
        'lblQty
        '
        Me.lblQty.Location = New System.Drawing.Point(144, 40)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(37, 16)
        Me.lblQty.TabIndex = 75
        Me.lblQty.Text = "QTY"
        '
        'lblOpenBal
        '
        Me.lblOpenBal.Location = New System.Drawing.Point(16, 132)
        Me.lblOpenBal.Name = "lblOpenBal"
        Me.lblOpenBal.Size = New System.Drawing.Size(141, 16)
        Me.lblOpenBal.TabIndex = 100
        Me.lblOpenBal.Text = "OPENBAL"
        '
        'lblNet
        '
        Me.lblNet.Location = New System.Drawing.Point(288, 40)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(37, 16)
        Me.lblNet.TabIndex = 78
        Me.lblNet.Text = "NET"
        '
        'lblDspOpenBal
        '
        Me.lblDspOpenBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspOpenBal.Location = New System.Drawing.Point(232, 128)
        Me.lblDspOpenBal.Name = "lblDspOpenBal"
        Me.lblDspOpenBal.Size = New System.Drawing.Size(103, 20)
        Me.lblDspOpenBal.TabIndex = 99
        '
        'lblDspCrtDate
        '
        Me.lblDspCrtDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCrtDate.Location = New System.Drawing.Point(120, 16)
        Me.lblDspCrtDate.Name = "lblDspCrtDate"
        Me.lblDspCrtDate.Size = New System.Drawing.Size(103, 20)
        Me.lblDspCrtDate.TabIndex = 73
        '
        'lblDspCloseBal
        '
        Me.lblDspCloseBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspCloseBal.Location = New System.Drawing.Point(232, 152)
        Me.lblDspCloseBal.Name = "lblDspCloseBal"
        Me.lblDspCloseBal.Size = New System.Drawing.Size(103, 20)
        Me.lblDspCloseBal.TabIndex = 91
        '
        'lblDspARBal
        '
        Me.lblDspARBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspARBal.Location = New System.Drawing.Point(232, 176)
        Me.lblDspARBal.Name = "lblDspARBal"
        Me.lblDspARBal.Size = New System.Drawing.Size(103, 20)
        Me.lblDspARBal.TabIndex = 93
        '
        'lblDspAcmYrSaleQty
        '
        Me.lblDspAcmYrSaleQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmYrSaleQty.Location = New System.Drawing.Point(120, 80)
        Me.lblDspAcmYrSaleQty.Name = "lblDspAcmYrSaleQty"
        Me.lblDspAcmYrSaleQty.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmYrSaleQty.TabIndex = 82
        '
        'lblDspAcmYrSaleNet
        '
        Me.lblDspAcmYrSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmYrSaleNet.Location = New System.Drawing.Point(264, 80)
        Me.lblDspAcmYrSaleNet.Name = "lblDspAcmYrSaleNet"
        Me.lblDspAcmYrSaleNet.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmYrSaleNet.TabIndex = 84
        '
        'lblDspAcmYrSaleAmt
        '
        Me.lblDspAcmYrSaleAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmYrSaleAmt.Location = New System.Drawing.Point(192, 80)
        Me.lblDspAcmYrSaleAmt.Name = "lblDspAcmYrSaleAmt"
        Me.lblDspAcmYrSaleAmt.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmYrSaleAmt.TabIndex = 83
        '
        'lblDspAcmSaleQty
        '
        Me.lblDspAcmSaleQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmSaleQty.Location = New System.Drawing.Point(120, 56)
        Me.lblDspAcmSaleQty.Name = "lblDspAcmSaleQty"
        Me.lblDspAcmSaleQty.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmSaleQty.TabIndex = 76
        '
        'lblDspAcmSaleNet
        '
        Me.lblDspAcmSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmSaleNet.Location = New System.Drawing.Point(264, 56)
        Me.lblDspAcmSaleNet.Name = "lblDspAcmSaleNet"
        Me.lblDspAcmSaleNet.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmSaleNet.TabIndex = 80
        '
        'lblDspAcmSaleAmt
        '
        Me.lblDspAcmSaleAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmSaleAmt.Location = New System.Drawing.Point(192, 56)
        Me.lblDspAcmSaleAmt.Name = "lblDspAcmSaleAmt"
        Me.lblDspAcmSaleAmt.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmSaleAmt.TabIndex = 79
        '
        'lblDspAcmMnSaleQty
        '
        Me.lblDspAcmMnSaleQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmMnSaleQty.Location = New System.Drawing.Point(120, 104)
        Me.lblDspAcmMnSaleQty.Name = "lblDspAcmMnSaleQty"
        Me.lblDspAcmMnSaleQty.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmMnSaleQty.TabIndex = 86
        '
        'lblDspAcmMnSaleNet
        '
        Me.lblDspAcmMnSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmMnSaleNet.Location = New System.Drawing.Point(264, 104)
        Me.lblDspAcmMnSaleNet.Name = "lblDspAcmMnSaleNet"
        Me.lblDspAcmMnSaleNet.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmMnSaleNet.TabIndex = 88
        '
        'lblDspAcmMnSaleAmt
        '
        Me.lblDspAcmMnSaleAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDspAcmMnSaleAmt.Location = New System.Drawing.Point(192, 104)
        Me.lblDspAcmMnSaleAmt.Name = "lblDspAcmMnSaleAmt"
        Me.lblDspAcmMnSaleAmt.Size = New System.Drawing.Size(71, 20)
        Me.lblDspAcmMnSaleAmt.TabIndex = 87
        '
        'lblCusCrtDate
        '
        Me.lblCusCrtDate.Location = New System.Drawing.Point(16, 20)
        Me.lblCusCrtDate.Name = "lblCusCrtDate"
        Me.lblCusCrtDate.Size = New System.Drawing.Size(61, 16)
        Me.lblCusCrtDate.TabIndex = 74
        Me.lblCusCrtDate.Text = "CUSCRTDATE"
        '
        'lblCloseBal
        '
        Me.lblCloseBal.Location = New System.Drawing.Point(16, 156)
        Me.lblCloseBal.Name = "lblCloseBal"
        Me.lblCloseBal.Size = New System.Drawing.Size(141, 16)
        Me.lblCloseBal.TabIndex = 90
        Me.lblCloseBal.Text = "CLOSEBAL"
        '
        'lblARBal
        '
        Me.lblARBal.Location = New System.Drawing.Point(16, 180)
        Me.lblARBal.Name = "lblARBal"
        Me.lblARBal.Size = New System.Drawing.Size(141, 16)
        Me.lblARBal.TabIndex = 92
        Me.lblARBal.Text = "ARBAL"
        '
        'lblAmt
        '
        Me.lblAmt.Location = New System.Drawing.Point(216, 40)
        Me.lblAmt.Name = "lblAmt"
        Me.lblAmt.Size = New System.Drawing.Size(37, 16)
        Me.lblAmt.TabIndex = 77
        Me.lblAmt.Text = "AMT"
        '
        'lblAcmYrSale
        '
        Me.lblAcmYrSale.Location = New System.Drawing.Point(16, 84)
        Me.lblAcmYrSale.Name = "lblAcmYrSale"
        Me.lblAcmYrSale.Size = New System.Drawing.Size(101, 16)
        Me.lblAcmYrSale.TabIndex = 85
        Me.lblAcmYrSale.Text = "ACMYRSALE"
        '
        'lblAcmSale
        '
        Me.lblAcmSale.Location = New System.Drawing.Point(16, 60)
        Me.lblAcmSale.Name = "lblAcmSale"
        Me.lblAcmSale.Size = New System.Drawing.Size(101, 16)
        Me.lblAcmSale.TabIndex = 81
        Me.lblAcmSale.Text = "ACMSALE"
        '
        'lblAcmMnSale
        '
        Me.lblAcmMnSale.Location = New System.Drawing.Point(16, 108)
        Me.lblAcmMnSale.Name = "lblAcmMnSale"
        Me.lblAcmMnSale.Size = New System.Drawing.Size(101, 16)
        Me.lblAcmMnSale.TabIndex = 89
        Me.lblAcmMnSale.Text = "ACMMNSALE"
        '
        'txtSaleID
        '
        Me.txtSaleID.AcceptsReturn = True
        Me.txtSaleID.Location = New System.Drawing.Point(608, 40)
        Me.txtSaleID.MaxLength = 0
        Me.txtSaleID.Name = "txtSaleID"
        Me.txtSaleID.Size = New System.Drawing.Size(33, 20)
        Me.txtSaleID.TabIndex = 41
        Me.txtSaleID.Visible = False
        '
        'frmC001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(663, 405)
        Me.Controls.Add(Me.txtSaleID)
        Me.Controls.Add(Me.tabDetailInfo)
        Me.Controls.Add(Me.fraCustomerInfo)
        Me.Controls.Add(Me.tbrProcess)
        Me.Controls.Add(Me.tblDetail)
        Me.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(44, 85)
        Me.Name = "frmC001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "客戶資料"
        CType(Me.tblDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrProcess.ResumeLayout(False)
        Me.tbrProcess.PerformLayout()
        Me.fraCustomerInfo.ResumeLayout(False)
        Me.fraCustomerInfo.PerformLayout()
        Me.tabDetailInfo.ResumeLayout(False)
        Me._tabDetailInfo_TabPage0.ResumeLayout(False)
        Me._tabDetailInfo_TabPage0.PerformLayout()
        Me._tabDetailInfo_TabPage1.ResumeLayout(False)
        Me.fraCusShipAddr2.ResumeLayout(False)
        Me.fraCusShipAddr2.PerformLayout()
        Me.fraCusShipAddr1.ResumeLayout(False)
        Me.fraCusShipAddr1.PerformLayout()
        Me._tabDetailInfo_TabPage2.ResumeLayout(False)
        Me._tabDetailInfo_TabPage2.PerformLayout()
        Me._tabDetailInfo_TabPage3.ResumeLayout(False)
        CType(Me.tblCommon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents tbrProcess As System.Windows.Forms.ToolStrip
    Public WithEvents iglProcess As System.Windows.Forms.ImageList
    Public WithEvents _tbrProcess_Button1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarOpen As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarAdd As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents _tbrProcess_Button6 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarSave As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarCancel As System.Windows.Forms.ToolStripButton
    Public WithEvents _tbrProcess_Button9 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarFind As System.Windows.Forms.ToolStripButton
    Public WithEvents _tbrProcess_Button11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarExit As System.Windows.Forms.ToolStripButton
    Public WithEvents fraCustomerInfo As System.Windows.Forms.GroupBox
    Public WithEvents cboCusCode As System.Windows.Forms.ComboBox
    Public WithEvents tabDetailInfo As System.Windows.Forms.TabControl
    Public WithEvents cboCusRgnCode As System.Windows.Forms.ComboBox
    Public WithEvents chkBadList As System.Windows.Forms.CheckBox
    Public WithEvents chkInActive As System.Windows.Forms.CheckBox
    Public WithEvents _tabDetailInfo_TabPage0 As System.Windows.Forms.TabPage
    Public WithEvents _tabDetailInfo_TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents _tabDetailInfo_TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents _tabDetailInfo_TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents fraCusShipAddr1 As System.Windows.Forms.GroupBox
    Public WithEvents fraCusShipAddr2 As System.Windows.Forms.GroupBox
    Public WithEvents cboCusSaleCode As System.Windows.Forms.ComboBox
    Public WithEvents cboCusPayCode As System.Windows.Forms.ComboBox
    Public WithEvents cboCusMLCode As System.Windows.Forms.ComboBox
    Public WithEvents cboCusCurr As System.Windows.Forms.ComboBox
    Public WithEvents cboCusShipTerrCode2 As System.Windows.Forms.ComboBox
    Public WithEvents cboCusShipTerrCode As System.Windows.Forms.ComboBox
    Public WithEvents lblAcmMnSale As System.Windows.Forms.Label
    Public WithEvents lblAmt As System.Windows.Forms.Label
    Public WithEvents lblAcmYrSale As System.Windows.Forms.Label
    Public WithEvents lblAcmSale As System.Windows.Forms.Label
    Public WithEvents lblARBal As System.Windows.Forms.Label
    Public WithEvents lblCloseBal As System.Windows.Forms.Label
    Public WithEvents lblCusContactPerson1 As System.Windows.Forms.Label
    Public WithEvents lblCusContactPerson As System.Windows.Forms.Label
    Public WithEvents lblCusCode As System.Windows.Forms.Label
    Public WithEvents lblCusAddress1 As System.Windows.Forms.Label
    Public WithEvents lblCusCreditLimit As System.Windows.Forms.Label
    Public WithEvents lblCusCrtDate As System.Windows.Forms.Label
    Public WithEvents lblCusEmail As System.Windows.Forms.Label
    Public WithEvents lblCusCurr As System.Windows.Forms.Label
    Public WithEvents lblCusFax As System.Windows.Forms.Label
    Public WithEvents lblCusLastUpd As System.Windows.Forms.Label
    Public WithEvents lblCusMLCode As System.Windows.Forms.Label
    Public WithEvents lblCusLastUpdDate As System.Windows.Forms.Label
    Public WithEvents lblCusName As System.Windows.Forms.Label
    Public WithEvents lblCusPayCode As System.Windows.Forms.Label
    Public WithEvents lblCusRgnCode As System.Windows.Forms.Label
    Public WithEvents lblCusRemark As System.Windows.Forms.Label
    Public WithEvents lblCusShipTerrCode2 As System.Windows.Forms.Label
    Public WithEvents lblCusShipTel2 As System.Windows.Forms.Label
    Public WithEvents lblCusShipContactPerson2 As System.Windows.Forms.Label
    Public WithEvents lblCusShipAdd2 As System.Windows.Forms.Label
    Public WithEvents lblCusShipTerrCode As System.Windows.Forms.Label
    Public WithEvents lblCusShipTel As System.Windows.Forms.Label
    Public WithEvents lblCusShipContactPerson As System.Windows.Forms.Label
    Public WithEvents lblCusShipAdd1 As System.Windows.Forms.Label
    Public WithEvents lblCusSpecDis As System.Windows.Forms.Label
    Public WithEvents lblCusSaleName As System.Windows.Forms.Label
    Public WithEvents lblCusTel As System.Windows.Forms.Label
    Public WithEvents lblDspAcmSaleNet As System.Windows.Forms.Label
    Public WithEvents lblDspAcmSaleAmt As System.Windows.Forms.Label
    Public WithEvents lblDspAcmMnSaleQty As System.Windows.Forms.Label
    Public WithEvents lblDspAcmMnSaleNet As System.Windows.Forms.Label
    Public WithEvents lblDspAcmMnSaleAmt As System.Windows.Forms.Label
    Public WithEvents lblDspCusRgnDesc As System.Windows.Forms.Label
    Public WithEvents lblDspCusSaleName As System.Windows.Forms.Label
    Public WithEvents lblDspCusMLDesc As System.Windows.Forms.Label
    Public WithEvents lblDspCusLastUpdDate As System.Windows.Forms.Label
    Public WithEvents lblDspCusLastUpd As System.Windows.Forms.Label
    Friend WithEvents tblCommon As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Public WithEvents lblQty As System.Windows.Forms.Label
    Public WithEvents lblOpenBal As System.Windows.Forms.Label
    Public WithEvents lblNet As System.Windows.Forms.Label
    Public WithEvents lblDspOpenBal As System.Windows.Forms.Label
    Public WithEvents lblDspCrtDate As System.Windows.Forms.Label
    Public WithEvents lblDspCloseBal As System.Windows.Forms.Label
    Public WithEvents lblDspARBal As System.Windows.Forms.Label
    Public WithEvents lblDspAcmYrSaleQty As System.Windows.Forms.Label
    Public WithEvents lblDspAcmYrSaleNet As System.Windows.Forms.Label
    Public WithEvents lblDspAcmYrSaleAmt As System.Windows.Forms.Label
    Public WithEvents lblDspAcmSaleQty As System.Windows.Forms.Label
    Public WithEvents txtCusAddress1 As System.Windows.Forms.TextBox
    Public WithEvents txtCusContactPerson As System.Windows.Forms.TextBox
    Public WithEvents txtCusCode As System.Windows.Forms.TextBox
    Public WithEvents txtCusAddress4 As System.Windows.Forms.TextBox
    Public WithEvents txtCusAddress3 As System.Windows.Forms.TextBox
    Public WithEvents txtCusAddress2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusContactPerson1 As System.Windows.Forms.TextBox
    Public WithEvents txtCusEmail As System.Windows.Forms.TextBox
    Public WithEvents txtCusCreditLimit As System.Windows.Forms.TextBox
    Public WithEvents txtCusName As System.Windows.Forms.TextBox
    Public WithEvents txtCusFax As System.Windows.Forms.TextBox
    Public WithEvents txtCusTel As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipTerrName2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipTel2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipFax2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipContactPerson2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd42 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd32 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd22 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd12 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipTerrName As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipTel As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipFax As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipContactPerson As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd4 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd3 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd2 As System.Windows.Forms.TextBox
    Public WithEvents txtCusShipAdd1 As System.Windows.Forms.TextBox
    Public WithEvents txtCusSpecDis As System.Windows.Forms.TextBox
    Public WithEvents txtCusRemark As System.Windows.Forms.TextBox
    Public WithEvents txtCusPayDesc As System.Windows.Forms.TextBox
    Public WithEvents txtSaleID As System.Windows.Forms.TextBox
    Public WithEvents tblDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
