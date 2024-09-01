<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = _
            New System.ComponentModel.ComponentResourceManager(GetType(MainView))

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()

        mnuMain = New System.Windows.Forms.MenuStrip()
        mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileAdd = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileRemove = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileClear = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileSep0 = New System.Windows.Forms.ToolStripSeparator()
        mnuFileOutput = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileWorkDir = New System.Windows.Forms.ToolStripMenuItem()
        mnuFileSep1 = New System.Windows.Forms.ToolStripSeparator()
        mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        mnuEditTime = New System.Windows.Forms.ToolStripMenuItem()
        mnuEditPerform = New System.Windows.Forms.ToolStripMenuItem()
        mnuHelp = New System.Windows.Forms.ToolStripMenuItem()

        dlgOpen = New System.Windows.Forms.OpenFileDialog()
        dlgSave = New System.Windows.Forms.SaveFileDialog()

        fraInput = New System.Windows.Forms.GroupBox()
        colConcat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        dgvInputs = New System.Windows.Forms.DataGridView()
        btnAdd = New System.Windows.Forms.Button()
        btnRemove = New System.Windows.Forms.Button()
        btnClear = New System.Windows.Forms.Button()
        btnUp = New System.Windows.Forms.Button()
        btnDown = New System.Windows.Forms.Button()
        btnEdit = New System.Windows.Forms.Button()

        fraOutput = New System.Windows.Forms.GroupBox()
        lblOutFile = New System.Windows.Forms.Label()
        txtOutFile = New System.Windows.Forms.TextBox()
        btnOutput = New System.Windows.Forms.Button()
        lblWorkDir = New System.Windows.Forms.Label()
        txtWorkDir = New System.Windows.Forms.TextBox()
        btnWorkDir = New System.Windows.Forms.Button()
        btnPerform = New System.Windows.Forms.Button()

        mnuMain.SuspendLayout()
        fraInput.SuspendLayout()
        fraOutput.SuspendLayout()
        CType(dgvInputs, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

        '
        ' mnuMain
        '
        Me.mnuMain.Items.AddRange(New ToolStripItem() {mnuFile, mnuEdit, mnuHelp})
        resources.ApplyResources(Me.mnuMain, "mnuMain")
        Me.mnuMain.Name = "mnuMain"
        '
        ' mnuFile
        '
        resources.ApplyResources(mnuFile, "mnuFile")
        mnuFile.DropDownItems.AddRange(New ToolStripItem() {mnuFileAdd, mnuFileRemove, mnuFileClear, mnuFileSep0, mnuFileOutput, mnuFileWorkDir, mnuFileSep1, mnuFileExit})
        mnuFile.Name = "mnuFile"
        '
        ' mnuFileAdd
        '
        mnuFileAdd.Name = "mnuFileAdd"
        resources.ApplyResources(mnuFileAdd, "mnuFileAdd")
        '
        ' mnuFileRemove
        '
        mnuFileRemove.Name = "mnuFileRemove"
        resources.ApplyResources(mnuFileRemove, "mnuFileRemove")
        '
        ' mnuFileClear
        '
        mnuFileClear.Name = "mnuFileClear"
        resources.ApplyResources(mnuFileClear, "mnuFileClear")
        '
        ' mnuFileSep0
        '
        mnuFileSep0.Name = "mnuFileSep0"
        resources.ApplyResources(mnuFileSep0, "mnuFileSep0")
        '
        ' mnuFileOutput
        '
        mnuFileOutput.Name = "mnuFileOutput"
        resources.ApplyResources(mnuFileOutput, "mnuFileOutput")
        '
        ' mnuFileWorkDir
        '
        mnuFileWorkDir.Name = "mnuFileWorkDir"
        resources.ApplyResources(mnuFileWorkDir, "mnuFileWorkDir")
        '
        ' mnuFileSep1
        '
        mnuFileSep1.Name = "mnuFileSep1"
        resources.ApplyResources(mnuFileSep1, "mnuFileSep1")
        '
        ' mnuFileExit
        '
        mnuFileExit.Name = "mnuFileExit"
        resources.ApplyResources(mnuFileExit, "mnuFileExit")
        '
        ' mnuEdit
        '
        mnuEdit.DropDownItems.AddRange(New ToolStripItem() {mnuEditTime, mnuEditPerform})
        mnuEdit.Name = "mnuEdit"
        resources.ApplyResources(mnuEdit, "mnuEdit")
        '
        ' mnuEditTime
        '
        mnuEditTime.Name = "mnuEditTime"
        resources.ApplyResources(mnuEditTime, "mnuEditTime")
        '
        ' mnuEditPerform
        '
        mnuEditPerform.Name = "mnuEditPerform"
        resources.ApplyResources(mnuEditPerform, "mnuEditPerform")
        '
        ' mnuHelp
        '
        mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(mnuHelp, "mnuHelp")

        '
        ' dlgOpen
        '
        resources.ApplyResources(Me.dlgOpen, "dlgOpen")
        '
        ' dlgSave
        '
        dlgSave.DefaultExt = ".wmv"

        '
        ' fraInput
        '
        resources.ApplyResources(fraInput, "fraInput")
        fraInput.Controls.Add(dgvInputs)
        fraInput.Controls.Add(btnAdd)
        fraInput.Controls.Add(btnRemove)
        fraInput.Controls.Add(btnClear)
        fraInput.Controls.Add(btnUp)
        fraInput.Controls.Add(btnDown)
        fraInput.Controls.Add(btnEdit)
        fraInput.Name = "fraInput"
        fraInput.TabStop = False
        '
        ' dgvInputs
        '
        resources.ApplyResources(dgvInputs, "dgvInputs")
        dgvInputs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInputs.Columns.AddRange(New DataGridViewColumn() {colConcat, colFileName, colStart, colEnd, colDuration})
        dgvInputs.Name = "dgvInputs"
        dgvInputs.RowTemplate.Height = 25
        '
        ' btnAdd
        '
        resources.ApplyResources(btnAdd, "btnAdd")
        btnAdd.Name = "btnAdd"
        btnAdd.UseVisualStyleBackColor = True
        '
        ' btnRemove
        '
        resources.ApplyResources(btnRemove, "btnRemove")
        btnRemove.Name = "btnRemove"
        btnRemove.UseVisualStyleBackColor = True
        '
        ' btnClear
        '
        resources.ApplyResources(btnClear, "btnClear")
        btnClear.Name = "btnClear"
        btnClear.UseVisualStyleBackColor = True
        '
        ' btnUp
        '
        resources.ApplyResources(btnUp, "btnUp")
        btnUp.Name = "btnUp"
        btnUp.UseVisualStyleBackColor = True
        '
        ' btnDown
        '
        resources.ApplyResources(btnDown, "btnDown")
        btnDown.Name = "btnDown"
        btnDown.UseVisualStyleBackColor = True
        '
        ' btnEdit
        '
        resources.ApplyResources(btnEdit, "btnEdit")
        btnEdit.Name = "btnEdit"
        btnEdit.UseVisualStyleBackColor = True

        '
        ' fraOutput
        '
        resources.ApplyResources(fraOutput, "fraOutput")
        fraOutput.Controls.Add(lblOutFile)
        fraOutput.Controls.Add(txtOutFile)
        fraOutput.Controls.Add(btnOutput)
        fraOutput.Controls.Add(lblWorkDir)
        fraOutput.Controls.Add(txtWorkDir)
        fraOutput.Controls.Add(btnWorkDir)
        fraOutput.Controls.Add(btnPerform)
        fraOutput.Name = "fraOutput"
        fraOutput.TabStop = False
        '
        ' lblOutFile
        '
        resources.ApplyResources(lblOutFile, "lblOutFile")
        lblOutFile.Name = "lblOutFile"
        '
        ' txtOutFile
        '
        resources.ApplyResources(txtOutFile, "txtOutFile")
        txtOutFile.Name = "txtOutFile"
        '
        ' btnOutput
        '
        resources.ApplyResources(btnOutput, "btnOutput")
        btnOutput.Name = "btnOutput"
        btnOutput.UseVisualStyleBackColor = True
        '
        ' lblWorkDir
        '
        resources.ApplyResources(lblWorkDir, "lblWorkDir")
        lblWorkDir.Name = "lblWorkDir"
        '
        ' txtWorkDir
        '
        resources.ApplyResources(txtWorkDir, "txtWorkDir")
        txtWorkDir.Name = "txtWorkDir"
        '
        ' btnWorkDir
        '
        resources.ApplyResources(btnWorkDir, "btnWorkDir")
        btnWorkDir.Name = "btnWorkDir"
        btnWorkDir.UseVisualStyleBackColor = True
        '
        ' btnPerform
        '
        resources.ApplyResources(btnPerform, "btnPerform")
        btnPerform.Name = "btnPerform"
        btnPerform.UseVisualStyleBackColor = True

        '
        ' colConcat
        '
        resources.ApplyResources(colConcat, "colConcat")
        colConcat.Name = "colConcat"
        colConcat.Resizable = DataGridViewTriState.True
        colConcat.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        ' colFileName
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        colFileName.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(colFileName, "colFileName")
        colFileName.Name = "colFileName"
        colFileName.ReadOnly = True
        colFileName.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        ' colStart
        '
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStart.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(colStart, "colStart")
        colStart.Name = "colStart"
        colStart.ReadOnly = True
        colStart.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        ' colEnd
        '
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        colEnd.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(colEnd, "colEnd")
        colEnd.Name = "colEnd"
        colEnd.ReadOnly = True
        colEnd.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        ' colDuration
        '
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        colDuration.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(colDuration, "colDuration")
        colDuration.Name = "colDuration"
        colDuration.ReadOnly = True
        colDuration.SortMode = DataGridViewColumnSortMode.NotSortable

        '
        ' MainView
        '
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.None
        Controls.Add(mnuMain)
        Controls.Add(fraOutput)
        Controls.Add(fraInput)
        MainMenuStrip = mnuMain
        Name = "MainView"

        mnuMain.ResumeLayout(False)
        mnuMain.PerformLayout()
        fraOutput.ResumeLayout(False)
        fraOutput.PerformLayout()
        fraInput.ResumeLayout(False)
        CType(dgvInputs, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileSep0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileOutput As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileWorkDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPerform As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As SaveFileDialog

    Friend WithEvents fraInput As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInputs As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents fraOutput As System.Windows.Forms.GroupBox
    Friend WithEvents lblOutFile As System.Windows.Forms.Label
    Friend WithEvents txtOutFile As System.Windows.Forms.TextBox
    Friend WithEvents btnOutput As System.Windows.Forms.Button
    Friend WithEvents lblWorkDir As System.Windows.Forms.Label
    Friend WithEvents txtWorkDir As System.Windows.Forms.TextBox
    Friend WithEvents btnWorkDir As System.Windows.Forms.Button
    Friend WithEvents btnPerform As System.Windows.Forms.Button

    Friend WithEvents colConcat As DataGridViewCheckBoxColumn
    Friend WithEvents colFileName As DataGridViewTextBoxColumn
    Friend WithEvents colStart As DataGridViewTextBoxColumn
    Friend WithEvents colEnd As DataGridViewTextBoxColumn
    Friend WithEvents colDuration As DataGridViewTextBoxColumn

End Class
