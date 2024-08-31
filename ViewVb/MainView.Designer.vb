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

        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRunCommand = New System.Windows.Forms.ToolStripMenuItem()

        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()

        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCommand = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()

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

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuRun As ToolStripMenuItem
    Friend WithEvents mnuRunCommand As ToolStripMenuItem

    Friend WithEvents dlgOpen As OpenFileDialog

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCommand As TextBox
    Friend WithEvents btnRun As Button
    Friend WithEvents txtOutput As TextBox

End Class
