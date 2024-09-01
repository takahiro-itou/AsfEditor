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
        Dim resources As System.ComponentModel.ComponentResourceManager = _
            New System.ComponentModel.ComponentResourceManager(GetType(EditTimeForm))

        picVideo = New PictureBox()
        btnPlay = New Button()
        btnStop = New Button()
        trbPos = New TrackBar()
        lblPos = New Label()
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
        btnOK = New Button()
        btnCancel = New Button()
        Label2 = New Label()

        CType(picVideo, ComponentModel.ISupportInitialize).BeginInit()
        CType(trbPos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

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
        ' EditTimeForm
        '
        AcceptButton = btnOK
        AutoScaleMode = AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Controls.Add(picVideo)
        Controls.Add(btnPlay)
        Controls.Add(btnStop)
        Controls.Add(trbPos)
        Controls.Add(lblPos)
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
        Controls.Add(btnApply)
        Controls.Add(btnOK)
        Controls.Add(btnCancel)
        Name = "EditTimeForm"

        CType(picVideo, ComponentModel.ISupportInitialize).EndInit()
        CType(trbPos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents picVideo As PictureBox
    Friend WithEvents trbPos As TrackBar
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents lblPos As Label
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
    Friend WithEvents btnApply As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button

End Class
