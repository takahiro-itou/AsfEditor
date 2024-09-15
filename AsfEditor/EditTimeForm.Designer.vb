<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditTimeForm
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = _
            New System.ComponentModel.ComponentResourceManager(GetType(EditTimeForm))
        mnuMain = New MenuStrip()

        pnlVideo = New Panel()
        picVideo = New PictureBox()
        btnPlay = New Button()
        btnStop = New Button()
        trbPos = New TrackBar()
        lblPos = New Label()

        fraNavigate = New GroupBox()
        btnSetStart = New Button()
        btnRewind = New Button()
        btnForward = New Button()
        btnSetEnd = New Button()
        Label1 = New Label()
        txtStartTime = New TextBox()
        btnSeekStart = New Button()
        txtEndTime = New TextBox()
        btnSeekEnd = New Button()
        btnApply = New Button()

        pnlDialog = New Panel()
        btnOK = New Button()
        btnCancel = New Button()
        Label2 = New Label()

        tmrVideo = New Timer(components)
        CType(picVideo, ComponentModel.ISupportInitialize).BeginInit()
        CType(trbPos, ComponentModel.ISupportInitialize).BeginInit()
        mnuMain.SuspendLayout()
        pnlVideo.SuspendLayout()
        fraNavigate.SuspendLayout()
        pnlDialog.SuspendLayout()
        SuspendLayout()

        '
        ' pnlVideo
        '
        pnlVideo.Controls.Add(picVideo)
        pnlVideo.Controls.Add(trbPos)
        pnlVideo.Controls.Add(btnPlay)
        pnlVideo.Controls.Add(btnStop)
        pnlVideo.Controls.Add(lblPos)
        resources.ApplyResources(pnlVideo, "pnlVideo")
        pnlVideo.Name = "pnlVideo"
        '
        ' picVideo
        '
        resources.ApplyResources(picVideo, "picVideo")
        picVideo.BorderStyle = BorderStyle.Fixed3D
        picVideo.Name = "picVideo"
        picVideo.TabStop = False
        '
        ' btnPlay
        '
        resources.ApplyResources(btnPlay, "btnPlay")
        btnPlay.Name = "btnPlay"
        btnPlay.UseVisualStyleBackColor = True
        '
        ' btnStop
        '
        resources.ApplyResources(btnStop, "btnStop")
        btnStop.Name = "btnStop"
        btnStop.UseVisualStyleBackColor = True
        '
        ' trbPos
        '
        resources.ApplyResources(trbPos, "trbPos")
        trbPos.Name = "trbPos"
        '
        ' lblPos
        '
        resources.ApplyResources(lblPos, "lblPos")
        lblPos.BackColor = SystemColors.Window
        lblPos.Name = "lblPos"
        '
        ' fraNavigate
        '
        resources.ApplyResources(fraNavigate, "fraNavigate")
        fraNavigate.Name = "fraNavigate"
        fraNavigate.TabStop = False
        '
        ' btnSetStart
        '
        resources.ApplyResources(btnSetStart, "btnSetStart")
        btnSetStart.Name = "btnSetStart"
        btnSetStart.UseVisualStyleBackColor = True
        '
        ' btnRewind
        '
        resources.ApplyResources(btnRewind, "btnRewind")
        btnRewind.Name = "btnRewind"
        btnRewind.UseVisualStyleBackColor = True
        '
        ' btnForward
        '
        resources.ApplyResources(btnForward, "btnForward")
        btnForward.Name = "btnForward"
        btnForward.UseVisualStyleBackColor = True
        '
        ' btnSetEnd
        '
        resources.ApplyResources(btnSetEnd, "btnSetEnd")
        btnSetEnd.Name = "btnSetEnd"
        btnSetEnd.UseVisualStyleBackColor = True
        '
        ' Label1
        '
        resources.ApplyResources(Label1, "Label1")
        Label1.Name = "Label1"
        '
        ' txtStartTime
        '
        resources.ApplyResources(txtStartTime, "txtStartTime")
        txtStartTime.Name = "txtStartTime"
        '
        ' btnSeekStart
        '
        resources.ApplyResources(btnSeekStart, "btnSeekStart")
        btnSeekStart.Name = "btnSeekStart"
        btnSeekStart.UseVisualStyleBackColor = True
        '
        ' Label2
        '
        resources.ApplyResources(Label2, "Label2")
        Label2.Name = "Label2"
        '
        ' txtEndTime
        '
        resources.ApplyResources(txtEndTime, "txtEndTime")
        txtEndTime.Name = "txtEndTime"
        '
        ' btnSeekEnd
        '
        resources.ApplyResources(btnSeekEnd, "btnSeekEnd")
        btnSeekEnd.Name = "btnSeekEnd"
        btnSeekEnd.UseVisualStyleBackColor = True
        '
        ' pnlDialog
        '
        pnlDialog.Controls.Add(btnApply)
        pnlDialog.Controls.Add(btnOK)
        pnlDialog.Controls.Add(btnCancel)
        resources.ApplyResources(pnlDialog, "pnlDialog")
        pnlDialog.Name = "pnlDialog"
        '
        ' btnApply
        '
        resources.ApplyResources(btnApply, "btnApply")
        btnApply.Name = "btnApply"
        btnApply.UseVisualStyleBackColor = True
        '
        ' btnOK
        '
        resources.ApplyResources(btnOK, "btnOK")
        btnOK.Name = "btnOK"
        btnOK.UseVisualStyleBackColor = True
        '
        ' btnCancel
        '
        resources.ApplyResources(btnCancel, "btnCancel")
        btnCancel.Name = "btnCancel"
        btnCancel.UseVisualStyleBackColor = True

        '
        ' tmrVideo
        '

        '
        ' EditTimeForm
        '
        AcceptButton = btnOK
        AutoScaleMode = AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Controls.Add(mnuMain)
        Controls.Add(pnlVideo)
        Controls.Add(fraNavigate)
        Controls.Add(btnSetStart)
        Controls.Add(btnRewind)
        Controls.Add(btnForward)
        Controls.Add(btnSetEnd)
        Controls.Add(Label1)
        Controls.Add(txtStartTime)
        Controls.Add(btnSeekStart)
        Controls.Add(Label2)
        Controls.Add(txtEndTime)
        Controls.Add(btnSeekEnd)
        Controls.Add(pnlDialog)
        MainMenuStrip = mnuMain
        Name = "EditTimeForm"

        mnuMain.ResumeLayout(False)
        mnuMain.PerformLayout()
        pnlVideo.ResumeLayout(False)
        pnlVideo.PerformLayout()
        fraNavigate.ResumeLayout(False)
        fraNavigate.PerformLayout()
        pnlDialog.ResumeLayout(False)
        pnlDialog.PerformLayout()
        CType(picVideo, ComponentModel.ISupportInitialize).EndInit()
        CType(trbPos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents mnuMain As MenuStrip

    Friend WithEvents pnlVideo As Panel
    Friend WithEvents picVideo As PictureBox
    Friend WithEvents trbPos As TrackBar
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents lblPos As Label
    Friend WithEvents fraNavigate As GroupBox
    Friend WithEvents btnSetStart As Button
    Friend WithEvents btnRewind As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents btnSetEnd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStartTime As TextBox
    Friend WithEvents btnSeekStart As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEndTime As TextBox
    Friend WithEvents btnSeekEnd As Button
    Friend WithEvents pnlDialog As Panel
    Friend WithEvents btnApply As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents tmrVideo As Timer

End Class
