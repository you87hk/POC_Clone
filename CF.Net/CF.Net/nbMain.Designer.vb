<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class nbMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(nbMain))
        Me.tbrMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarPrev = New System.Windows.Forms.ToolStripButton()
        Me.toolBarNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboCommand = New System.Windows.Forms.ToolStripComboBox()
        Me.toolBarOK = New System.Windows.Forms.ToolStripButton()
        Me.toolBarCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarExit = New System.Windows.Forms.ToolStripButton()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPO = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInquiry = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuACCRPT = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUtility = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuList = New System.Windows.Forms.ToolStripMenuItem()
        Me.staMain = New System.Windows.Forms.StatusStrip()
        Me._staMain_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbrMain.SuspendLayout()
        Me.MainMenu1.SuspendLayout()
        Me.staMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbrMain
        '
        Me.tbrMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolBarPrev, Me.toolBarNext, Me.ToolStripSeparator2, Me.cboCommand, Me.toolBarOK, Me.toolBarCancel, Me.ToolStripSeparator3, Me.toolBarExit})
        Me.tbrMain.Location = New System.Drawing.Point(0, 24)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.Size = New System.Drawing.Size(792, 25)
        Me.tbrMain.TabIndex = 4
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolBarPrev
        '
        Me.toolBarPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBarPrev.Image = CType(resources.GetObject("toolBarPrev.Image"), System.Drawing.Image)
        Me.toolBarPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBarPrev.Name = "toolBarPrev"
        Me.toolBarPrev.Size = New System.Drawing.Size(23, 22)
        Me.toolBarPrev.Text = "Prev"
        '
        'toolBarNext
        '
        Me.toolBarNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBarNext.Image = CType(resources.GetObject("toolBarNext.Image"), System.Drawing.Image)
        Me.toolBarNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBarNext.Name = "toolBarNext"
        Me.toolBarNext.Size = New System.Drawing.Size(23, 22)
        Me.toolBarNext.Text = "Next"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cboCommand
        '
        Me.cboCommand.Name = "cboCommand"
        Me.cboCommand.Size = New System.Drawing.Size(121, 25)
        '
        'toolBarOK
        '
        Me.toolBarOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBarOK.Image = CType(resources.GetObject("toolBarOK.Image"), System.Drawing.Image)
        Me.toolBarOK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBarOK.Name = "toolBarOK"
        Me.toolBarOK.Size = New System.Drawing.Size(23, 22)
        Me.toolBarOK.Text = "OK"
        '
        'toolBarCancel
        '
        Me.toolBarCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBarCancel.Image = CType(resources.GetObject("toolBarCancel.Image"), System.Drawing.Image)
        Me.toolBarCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBarCancel.Name = "toolBarCancel"
        Me.toolBarCancel.Size = New System.Drawing.Size(23, 22)
        Me.toolBarCancel.Text = "Cancel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolBarExit
        '
        Me.toolBarExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBarExit.Image = CType(resources.GetObject("toolBarExit.Image"), System.Drawing.Image)
        Me.toolBarExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBarExit.Name = "toolBarExit"
        Me.toolBarExit.Size = New System.Drawing.Size(23, 22)
        Me.toolBarExit.Text = "Exit"
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuMaster, Me.mnuOperation, Me.mnuPO, Me.mnuInventory, Me.mnuAccount, Me.mnuInquiry, Me.mnuReport, Me.mnuACCRPT, Me.mnuUtility, Me.mnuList})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(792, 24)
        Me.MainMenu1.TabIndex = 5
        '
        'mnuFile
        '
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuMaster
        '
        Me.mnuMaster.Name = "mnuMaster"
        Me.mnuMaster.Size = New System.Drawing.Size(55, 20)
        Me.mnuMaster.Text = "&Master"
        '
        'mnuOperation
        '
        Me.mnuOperation.Name = "mnuOperation"
        Me.mnuOperation.Size = New System.Drawing.Size(72, 20)
        Me.mnuOperation.Text = "&Operation"
        '
        'mnuPO
        '
        Me.mnuPO.Name = "mnuPO"
        Me.mnuPO.Size = New System.Drawing.Size(35, 20)
        Me.mnuPO.Text = "&PO"
        '
        'mnuInventory
        '
        Me.mnuInventory.Name = "mnuInventory"
        Me.mnuInventory.Size = New System.Drawing.Size(70, 20)
        Me.mnuInventory.Text = "In&Ventory"
        '
        'mnuAccount
        '
        Me.mnuAccount.Name = "mnuAccount"
        Me.mnuAccount.Size = New System.Drawing.Size(64, 20)
        Me.mnuAccount.Text = "&Account"
        '
        'mnuInquiry
        '
        Me.mnuInquiry.Name = "mnuInquiry"
        Me.mnuInquiry.Size = New System.Drawing.Size(56, 20)
        Me.mnuInquiry.Text = "&Inquiry"
        '
        'mnuReport
        '
        Me.mnuReport.Name = "mnuReport"
        Me.mnuReport.Size = New System.Drawing.Size(54, 20)
        Me.mnuReport.Text = "&Report"
        '
        'mnuACCRPT
        '
        Me.mnuACCRPT.Name = "mnuACCRPT"
        Me.mnuACCRPT.Size = New System.Drawing.Size(77, 20)
        Me.mnuACCRPT.Text = "Acc Report"
        '
        'mnuUtility
        '
        Me.mnuUtility.Name = "mnuUtility"
        Me.mnuUtility.Size = New System.Drawing.Size(50, 20)
        Me.mnuUtility.Text = "&Utility"
        '
        'mnuList
        '
        Me.mnuList.Name = "mnuList"
        Me.mnuList.Size = New System.Drawing.Size(37, 20)
        Me.mnuList.Text = "List"
        '
        'staMain
        '
        Me.staMain.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._staMain_Panel1, Me._staMain_Panel2, Me._staMain_Panel3})
        Me.staMain.Location = New System.Drawing.Point(0, 48)
        Me.staMain.Name = "staMain"
        Me.staMain.Size = New System.Drawing.Size(792, 26)
        Me.staMain.TabIndex = 3
        '
        '_staMain_Panel1
        '
        Me._staMain_Panel1.AutoSize = False
        Me._staMain_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel1.Name = "_staMain_Panel1"
        Me._staMain_Panel1.Size = New System.Drawing.Size(585, 26)
        Me._staMain_Panel1.Spring = True
        Me._staMain_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_staMain_Panel2
        '
        Me._staMain_Panel2.AutoSize = False
        Me._staMain_Panel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel2.Name = "_staMain_Panel2"
        Me._staMain_Panel2.Size = New System.Drawing.Size(96, 26)
        Me._staMain_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_staMain_Panel3
        '
        Me._staMain_Panel3.AutoSize = False
        Me._staMain_Panel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel3.Name = "_staMain_Panel3"
        Me._staMain_Panel3.Size = New System.Drawing.Size(96, 26)
        Me._staMain_Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nbMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 74)
        Me.Controls.Add(Me.staMain)
        Me.Controls.Add(Me.tbrMain)
        Me.Controls.Add(Me.MainMenu1)
        Me.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(49, 176)
        Me.MainMenuStrip = Me.MainMenu1
        Me.Name = "nbMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Main Menu"
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.staMain.ResumeLayout(False)
        Me.staMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tbrMain As System.Windows.Forms.ToolStrip
    Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOperation As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPO As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuInventory As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAccount As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuInquiry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuACCRPT As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarPrev As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents toolBarOK As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarCancel As System.Windows.Forms.ToolStripButton
    Public WithEvents toolBarExit As System.Windows.Forms.ToolStripButton
    Public WithEvents cboCommand As System.Windows.Forms.ToolStripComboBox
    Public WithEvents staMain As System.Windows.Forms.StatusStrip
    Public WithEvents _staMain_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _staMain_Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _staMain_Panel3 As System.Windows.Forms.ToolStripStatusLabel
End Class
