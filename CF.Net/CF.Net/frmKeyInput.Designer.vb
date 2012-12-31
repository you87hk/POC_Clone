<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmKeyInput
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
	Public WithEvents txtKeyNo As System.Windows.Forms.TextBox
	Public WithEvents lblKeyNo As System.Windows.Forms.Label
	Public WithEvents fraHeader As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmKeyInput))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fraHeader = New System.Windows.Forms.GroupBox
		Me.txtKeyNo = New System.Windows.Forms.TextBox
		Me.lblKeyNo = New System.Windows.Forms.Label
		Me.fraHeader.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "New Key"
		Me.ClientSize = New System.Drawing.Size(385, 159)
		Me.Location = New System.Drawing.Point(66, 161)
		Me.Icon = CType(resources.GetObject("frmKeyInput.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmKeyInput"
		Me.fraHeader.Size = New System.Drawing.Size(365, 136)
		Me.fraHeader.Location = New System.Drawing.Point(8, 8)
		Me.fraHeader.TabIndex = 0
		Me.fraHeader.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fraHeader.BackColor = System.Drawing.SystemColors.Control
		Me.fraHeader.Enabled = True
		Me.fraHeader.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraHeader.Visible = True
		Me.fraHeader.Padding = New System.Windows.Forms.Padding(0)
		Me.fraHeader.Name = "fraHeader"
		Me.txtKeyNo.AutoSize = False
		Me.txtKeyNo.Size = New System.Drawing.Size(131, 21)
		Me.txtKeyNo.Location = New System.Drawing.Point(152, 48)
		Me.txtKeyNo.TabIndex = 1
		Me.txtKeyNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtKeyNo.AcceptsReturn = True
		Me.txtKeyNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKeyNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtKeyNo.CausesValidation = True
		Me.txtKeyNo.Enabled = True
		Me.txtKeyNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKeyNo.HideSelection = True
		Me.txtKeyNo.ReadOnly = False
		Me.txtKeyNo.Maxlength = 0
		Me.txtKeyNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKeyNo.MultiLine = False
		Me.txtKeyNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKeyNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKeyNo.TabStop = True
		Me.txtKeyNo.Visible = True
		Me.txtKeyNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKeyNo.Name = "txtKeyNo"
		Me.lblKeyNo.Text = "NEW KEY:"
		Me.lblKeyNo.Size = New System.Drawing.Size(121, 16)
		Me.lblKeyNo.Location = New System.Drawing.Point(32, 48)
		Me.lblKeyNo.TabIndex = 2
		Me.lblKeyNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblKeyNo.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblKeyNo.BackColor = System.Drawing.SystemColors.Control
		Me.lblKeyNo.Enabled = True
		Me.lblKeyNo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblKeyNo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblKeyNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblKeyNo.UseMnemonic = True
		Me.lblKeyNo.Visible = True
		Me.lblKeyNo.AutoSize = False
		Me.lblKeyNo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblKeyNo.Name = "lblKeyNo"
		Me.Controls.Add(fraHeader)
		Me.fraHeader.Controls.Add(txtKeyNo)
		Me.fraHeader.Controls.Add(lblKeyNo)
		Me.fraHeader.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class