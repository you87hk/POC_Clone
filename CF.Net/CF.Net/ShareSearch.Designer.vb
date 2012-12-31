<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmShareSearch
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cboSearchField As System.Windows.Forms.ComboBox
	Public WithEvents lsvContent As System.Windows.Forms.ListView
	Public WithEvents txtOutput As System.Windows.Forms.TextBox
	Public WithEvents fraFind As System.Windows.Forms.GroupBox
	Public WithEvents iglProcess As System.Windows.Forms.ImageList
	Public WithEvents _tbrProcess_Button1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbrProcess_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbrProcess_Button3 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbrProcess_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbrProcess_Button5 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbrProcess_Button6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbrProcess_Button7 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbrProcess As System.Windows.Forms.ToolStrip
	Public WithEvents lblDspCrt As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShareSearch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cboSearchField = New System.Windows.Forms.ComboBox
		Me.lsvContent = New System.Windows.Forms.ListView
		Me.fraFind = New System.Windows.Forms.GroupBox
		Me.txtOutput = New System.Windows.Forms.TextBox
		Me.iglProcess = New System.Windows.Forms.ImageList
		Me.tbrProcess = New System.Windows.Forms.ToolStrip
		Me._tbrProcess_Button1 = New System.Windows.Forms.ToolStripSeparator
		Me._tbrProcess_Button2 = New System.Windows.Forms.ToolStripButton
		Me._tbrProcess_Button3 = New System.Windows.Forms.ToolStripButton
		Me._tbrProcess_Button4 = New System.Windows.Forms.ToolStripSeparator
		Me._tbrProcess_Button5 = New System.Windows.Forms.ToolStripButton
		Me._tbrProcess_Button6 = New System.Windows.Forms.ToolStripSeparator
		Me._tbrProcess_Button7 = New System.Windows.Forms.ToolStripButton
		Me.lblDspCrt = New System.Windows.Forms.Label
		Me.fraFind.SuspendLayout()
		Me.tbrProcess.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "快速搜尋"
		Me.ClientSize = New System.Drawing.Size(513, 449)
		Me.Location = New System.Drawing.Point(5, 67)
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Icon = CType(resources.GetObject("frmShareSearch.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmShareSearch"
		Me.cboSearchField.Size = New System.Drawing.Size(201, 20)
		Me.cboSearchField.Location = New System.Drawing.Point(24, 56)
		Me.cboSearchField.TabIndex = 0
		Me.cboSearchField.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboSearchField.BackColor = System.Drawing.SystemColors.Window
		Me.cboSearchField.CausesValidation = True
		Me.cboSearchField.Enabled = True
		Me.cboSearchField.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboSearchField.IntegralHeight = True
		Me.cboSearchField.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboSearchField.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboSearchField.Sorted = False
		Me.cboSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboSearchField.TabStop = True
		Me.cboSearchField.Visible = True
		Me.cboSearchField.Name = "cboSearchField"
		Me.lsvContent.Size = New System.Drawing.Size(486, 337)
		Me.lsvContent.Location = New System.Drawing.Point(16, 80)
		Me.lsvContent.TabIndex = 2
		Me.lsvContent.LabelWrap = True
		Me.lsvContent.HideSelection = True
		Me.lsvContent.FullRowSelect = True
		Me.lsvContent.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lsvContent.BackColor = System.Drawing.SystemColors.Window
		Me.lsvContent.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lsvContent.LabelEdit = True
		Me.lsvContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lsvContent.Name = "lsvContent"
		Me.fraFind.Text = "搜尋"
		Me.fraFind.Size = New System.Drawing.Size(484, 54)
		Me.fraFind.Location = New System.Drawing.Point(16, 24)
		Me.fraFind.TabIndex = 3
		Me.fraFind.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fraFind.BackColor = System.Drawing.SystemColors.Control
		Me.fraFind.Enabled = True
		Me.fraFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFind.Visible = True
		Me.fraFind.Padding = New System.Windows.Forms.Padding(0)
		Me.fraFind.Name = "fraFind"
		Me.txtOutput.AutoSize = False
		Me.txtOutput.Size = New System.Drawing.Size(257, 18)
		Me.txtOutput.Location = New System.Drawing.Point(216, 32)
		Me.txtOutput.TabIndex = 1
		Me.txtOutput.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtOutput.AcceptsReturn = True
		Me.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtOutput.BackColor = System.Drawing.SystemColors.Window
		Me.txtOutput.CausesValidation = True
		Me.txtOutput.Enabled = True
		Me.txtOutput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtOutput.HideSelection = True
		Me.txtOutput.ReadOnly = False
		Me.txtOutput.Maxlength = 0
		Me.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtOutput.MultiLine = False
		Me.txtOutput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtOutput.TabStop = True
		Me.txtOutput.Visible = True
		Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtOutput.Name = "txtOutput"
		Me.iglProcess.ImageSize = New System.Drawing.Size(16, 16)
		Me.iglProcess.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.iglProcess.ImageStream = CType(resources.GetObject("iglProcess.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
		Me.iglProcess.Images.SetKeyName(12, "")
		Me.tbrProcess.ShowItemToolTips = True
		Me.tbrProcess.Dock = System.Windows.Forms.DockStyle.Top
		Me.tbrProcess.Size = New System.Drawing.Size(513, 24)
		Me.tbrProcess.Location = New System.Drawing.Point(0, 0)
		Me.tbrProcess.TabIndex = 4
		Me.tbrProcess.ImageList = iglProcess
		Me.tbrProcess.Name = "tbrProcess"
		Me._tbrProcess_Button1.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button1.AutoSize = False
		Me._tbrProcess_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button1.ImageIndex = 4
		Me._tbrProcess_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button2.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button2.AutoSize = False
		Me._tbrProcess_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button2.Name = "Go"
		Me._tbrProcess_Button2.ToolTipText = "選取 (F2)"
		Me._tbrProcess_Button2.ImageIndex = 12
		Me._tbrProcess_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button3.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button3.AutoSize = False
		Me._tbrProcess_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button3.Name = "Cancel"
		Me._tbrProcess_Button3.ToolTipText = "取消 (F3)"
		Me._tbrProcess_Button3.ImageIndex = 4
		Me._tbrProcess_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button4.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button4.AutoSize = False
		Me._tbrProcess_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button4.Visible = 0
		Me._tbrProcess_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button5.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button5.AutoSize = False
		Me._tbrProcess_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button5.Name = "Exit"
		Me._tbrProcess_Button5.ToolTipText = "退出 (F12)"
		Me._tbrProcess_Button5.ImageIndex = 8
		Me._tbrProcess_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button6.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button6.AutoSize = False
		Me._tbrProcess_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbrProcess_Button7.Size = New System.Drawing.Size(24, 22)
		Me._tbrProcess_Button7.AutoSize = False
		Me._tbrProcess_Button7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbrProcess_Button7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbrProcess_Button7.Name = "Refresh"
		Me._tbrProcess_Button7.ToolTipText = "重新整理 (F5)"
		Me._tbrProcess_Button7.ImageIndex = 7
		Me._tbrProcess_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.lblDspCrt.BackColor = System.Drawing.SystemColors.ActiveBorder
		Me.lblDspCrt.ForeColor = System.Drawing.Color.Blue
		Me.lblDspCrt.Size = New System.Drawing.Size(487, 20)
		Me.lblDspCrt.Location = New System.Drawing.Point(16, 424)
		Me.lblDspCrt.TabIndex = 5
		Me.lblDspCrt.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDspCrt.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDspCrt.Enabled = True
		Me.lblDspCrt.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDspCrt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDspCrt.UseMnemonic = True
		Me.lblDspCrt.Visible = True
		Me.lblDspCrt.AutoSize = False
		Me.lblDspCrt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDspCrt.Name = "lblDspCrt"
		Me.Controls.Add(cboSearchField)
		Me.Controls.Add(lsvContent)
		Me.Controls.Add(fraFind)
		Me.Controls.Add(tbrProcess)
		Me.Controls.Add(lblDspCrt)
		Me.fraFind.Controls.Add(txtOutput)
		Me.tbrProcess.Items.Add(_tbrProcess_Button1)
		Me.tbrProcess.Items.Add(_tbrProcess_Button2)
		Me.tbrProcess.Items.Add(_tbrProcess_Button3)
		Me.tbrProcess.Items.Add(_tbrProcess_Button4)
		Me.tbrProcess.Items.Add(_tbrProcess_Button5)
		Me.tbrProcess.Items.Add(_tbrProcess_Button6)
		Me.tbrProcess.Items.Add(_tbrProcess_Button7)
		Me.fraFind.ResumeLayout(False)
		Me.tbrProcess.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class