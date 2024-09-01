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

        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSep0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileWorkDir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSep0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPerform = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()

        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()

        Me.fraInput = New System.Windows.Forms.GroupBox()
        Me.colConcat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvInputs = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()

        Me.fraOutput = New System.Windows.Forms.GroupBox()
        Me.lblOutFile = New System.Windows.Forms.Label()
        Me.txtOutFile = New System.Windows.Forms.TextBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.lblWorkDir = New System.Windows.Forms.Label()
        Me.txtWorkDir = New System.Windows.Forms.TextBox()
        Me.btnWorkDir = New System.Windows.Forms.Button()
        Me.btnPerform = New System.Windows.Forms.Button()

        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()

        '
        ' mnuMain
        '
        resources.ApplyResources(Me.mnuMain, "mnuMain")
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuRun})
        Me.mnuMain.Name = "mnuMain"
        '
        ' mnuFile
        '
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        '
        ' mnuFileExit
        '
        resources.ApplyResources(Me.mnuFileExit, "mnuFileExit")
        Me.mnuFileExit.Name = "mnuFileExit"
        '
        ' mnuRun
        '
        resources.ApplyResources(Me.mnuRun, "mnuRun")
        Me.mnuRun.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRunCommand})
        Me.mnuRun.Name = "mnuRun"
        '
        ' mnuRunCommand
        '
        resources.ApplyResources(Me.mnuRunCommand, "mnuRunCommand")
        Me.mnuRunCommand.Name = "mnuRunCommand"

        '
        ' dlgOpen
        '
        resources.ApplyResources(Me.dlgOpen, "dlgOpen")
        Me.dlgOpen.FileName = "dlgOpen"

        '
        ' Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        ' txtCommand
        '
        resources.ApplyResources(Me.txtCommand, "txtCommand")
        Me.txtCommand.Name = "txtCommand"
        '
        ' btnRun
        '
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.Name = "btnRun"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        ' txtOutput
        '
        resources.ApplyResources(Me.txtOutput, "txtOutput")
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.BackColor = SystemColors.Window
        Me.txtOutput.ReadOnly = True

        '
        ' MainView
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.txtOutput)
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "MainView"

        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
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
