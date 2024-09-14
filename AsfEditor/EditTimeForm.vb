﻿Public Class EditTimeForm

Private m_currentInfo As InputInfo
Private m_savedInfo As InputInfo

Private m_workVideo As MciWrapper
Private m_msVideoLength As Long
Private m_sLengthText As String

Private m_msCurPosition As Long


Private Function applyEdit()
''--------------------------------------------------------------------
''    編集内容を一時保存する
''--------------------------------------------------------------------
Dim workInfo As New InputInfo
Dim bResult As Boolean

    bResult = setTimeInfo(workInfo, txtStartTime.Text, txtEndTime.Text)

    If m_savedInfo Is Nothing Then
        m_savedInfo = New InputInfo()
    End If
    copyInputInfo(m_savedInfo, workInfo)

    applyEdit = bResult
End Function


Private Sub copyInputInfo( _
        ByVal dstInfo As InputInfo, ByVal srcInfo As InputInfo)
''--------------------------------------------------------------------
''    入力情報の構造体をコピーする
''--------------------------------------------------------------------

    With dstInfo
        .bValidData = srcInfo.bValidData
        .sStartTime = srcInfo.sStartTime
        .sEndTime = srcInfo.sEndTime
        .sTimeDuration = srcInfo.sTimeDuration
    End With

End Sub


Private Function handleCancelButton() As Boolean
''--------------------------------------------------------------------
''    キャンセルボタンを押したときの処理
''
''    一時保存されたデータがあるか確認し、
''  それは採用するか、それも破棄するかダイアログを表示する。
''  その時にキャンセルを選んだ場合は、
''  フォームを閉じるのを取り消して、このフォームに留まる。
''
''  @retval     True  : フォームを閉じる処理を継続
''  @retval     False : 閉じる処理をキャンセルした
''--------------------------------------------------------------------
Dim msgAns As System.Windows.Forms.DialogResult

    msgAns = MessageBox.Show(
        "途中で保存されたデータがあります。" & vbCrLf &
        "そのデータを採用しますか？",
        "Discard Modifications",
        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    If (msgAns = Windows.Forms.DialogResult.Cancel) Then
        ' キャンセルされたのでダイアログを閉じるのをやめる
        handleCancelButton = False
        Exit Function
    End If

    If (msgAns =  Windows.Forms.DialogResult.No)
        Me.DialogResult = DialogResult.Cancel
    Else
        Me.DialogResult = DialogResult.OK
    End If
    handleCancelButton = True

End Function


Public Function setTargetInfo(ByVal targetInfo As InputInfo) As Boolean
''--------------------------------------------------------------------
''    設定内容を読み書きするインスタンスを指定する
''--------------------------------------------------------------------
Dim fileName As String

    m_currentInfo = targetInfo
    With m_currentInfo
        fileName = .sFileName
        txtStartTime.Text = .sStartTime
        txtEndTime.Text = .sEndTime
    End With

    If m_workVideo Is Nothing
        m_workVideo = New MciWrapper("", 1)
    End If
    With m_workVideo
        .setFileName(fileName)
        .openAsfFile(picVideo)

        m_msVideoLength = .getVideoLength()
        m_sLengthText = getTimeTextFromMiliSeconds(m_msVideoLength)

        .seekVideo(getMiliSeconds(.sStartTime))
    End With

    setTargetInfo = True
End Function


Private Sub setPositionMiliSeconds(ByVal msCurPos As Long)
Dim tsPos As String

    tsPos = getTimeTextFromMiliSeconds(msCurPos)
    lblPos.Text = String.Format("{0} / {1}", tsPos, m_sLengthText)
    m_msCurPosition = msCurPos
End Sub


Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles _
            btnApply.Click
''--------------------------------------------------------------------
''    「適用」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------
    applyEdit()
End Sub


Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles _
            btnCancel.Click
''--------------------------------------------------------------------
''    「キャンセル」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------
Dim bClosing As Boolean

    bClosing = handleCancelButton()
    If (bClosing = False) Then
        Exit Sub
    End If

    ' 上記の関数内で、ダイアログの戻り値は設定済みなので
    ' ここに来た時は、フォームだけ閉じればよい。
    Me.Close()

End Sub


Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles _
            btnForward.Click

    If (m_msCurPosition >= m_msVideoLength - 100) Then
        setPositionMiliSeconds(m_msVideoLength)
        Exit Sub
    End If
    setPositionMiliSeconds(m_msCurPosition + 100)

End Sub


Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles _
            btnOK.Click
''--------------------------------------------------------------------
''    「OK」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------

    applyEdit()
    copyInputInfo(m_currentInfo, m_savedInfo)

    Me.DialogResult = DialogResult.OK
    Me.Close()

End Sub


Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles _
            btnPlay.Click
    m_workVideo.playVideo()
End Sub


Private Sub btnRewind_Click(sender As Object, e As EventArgs) Handles _
            btnRewind.Click

    If (m_msCurPosition <= 100) Then
        setPositionMiliSeconds(0)
        Exit Sub
    End If
    setPositionMiliSeconds(m_msCurPosition - 100)

End Sub


Private Sub btnSeekEnd_Click(sender As Object, e As EventArgs) Handles _
            btnSeekEnd.Click
Dim msNewPos As Long

    tmrVideo.Enabled = False
    msNewPos = getMiliSeconds(txtEnd.Text)
    m_workVideo.seekVideo(msNewPos)
    setPositionMiliSeconds(msNewPos)

End Sub

Private Sub btnSeekStart_Click(sender As Object, e As EventArgs) Handles _
            btnSeekStart.Click
Dim msNewPos As Long

    tmrVideo.Enabled = False
    msNewPos = getMiliSeconds(txtStart.Text)
    m_workVideo.seekVideo(msNewPos)
    setPositionMiliSeconds(msNewPos)

End Sub


Private Sub btnSetEnd_Click(sender As Object, e As EventArgs) Handles _
            btnSetEnd.Click
    txtEndTime.Text = getTimeTextFromMiliSeconds(m_msCurPosition)
End Sub


Private Sub btnSetStart_Click(sender As Object, e As EventArgs) Handles _
            btnSetStart.Click
    txtStartTime.Text = getTimeTextFromMiliSeconds(m_msCurPosition)
End Sub


Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles _
            btnStop.Click
Dim msCurPos As Long

    tmrVideo.Enabled = False
    With m_workVideo
        msCurPos = .getCurrentPosition()
    End With
    setPositionMiliSeconds(msCurPos)

End Sub


Private Sub tmrVideo_Tick(sender As Object, e As EventArgs) Handles _
            tmrVideo.Tick
''--------------------------------------------------------------------
''    タイマーのイベントハンドラ
''--------------------------------------------------------------------
Dim msCurPos As Long

    With m_workVideo
        msCurPos = .getCurrentPosition()
    End With
    setPositionMiliSeconds(msCurPos)

End Sub

End Class
