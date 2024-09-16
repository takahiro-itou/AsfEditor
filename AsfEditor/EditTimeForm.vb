Public Class EditTimeForm

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

    If m_savedInfo Is Nothing Then
        ' 一時保存されたデータはない
        Me.DialogResult = DialogResult.Cancel
        handleCancelButton = True
        Exit Function
    End If

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
        copyInputInfo(m_currentInfo, m_savedInfo)
        Me.DialogResult = DialogResult.OK
    End If
    handleCancelButton = True

End Function


Public Function setTargetInfo(ByVal targetInfo As InputInfo) As Boolean
''--------------------------------------------------------------------
''    設定内容を読み書きするインスタンスを指定する
''--------------------------------------------------------------------
Dim fileName As String
Dim msFirstPos As Long

    m_currentInfo = targetInfo
    With m_currentInfo
        fileName = .sFileName
        txtStartTime.Text = .sStartTime
        txtEndTime.Text = .sEndTime
        msFirstPos = getMiliSeconds(.sStartTime)
    End With

    If m_workVideo Is Nothing
        m_workVideo = New MciWrapper("", 1)
    End If
    With m_workVideo
        .setFileName(fileName)
        .openAsfFile(picVideo)

        m_msVideoLength = .getVideoLength()
        m_sLengthText = getTimeTextFromMiliSeconds(m_msVideoLength)

        setPositionMiliSeconds(msFirstPos, True)
    End With

    setTargetInfo = True
End Function


Private Sub setPositionMiliSeconds(
        ByVal msCurPos As Long, ByVal bSeek As Boolean)
''--------------------------------------------------------------------
''    位置をミリ秒で指定する
''
''  @param [in] msCurPos    ミリ秒
''  @param [in] bSeek       Trueならシークも行う
''--------------------------------------------------------------------
Dim tsPos As String

    If m_msVideoLength <= msCurPos Then
        tmrVideo.Enabled = False
        msCurPos = m_msVideoLength
    End If

    If bSeek Then
        m_workVideo.seekVideo(msCurPos)
    End If

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
''--------------------------------------------------------------------
''    「>」 ボタンのクリックイベントハンドラ
''
''    100 ミリ秒だけ進める
''--------------------------------------------------------------------
Dim msStep As Long

    msStep = CLng(Val(cmbStep.Text) * 1000)

    If (m_msCurPosition >= m_msVideoLength - msStep) Then
        setPositionMiliSeconds(m_msVideoLength, True)
        Exit Sub
    End If
    setPositionMiliSeconds(m_msCurPosition + msStep, True)

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
''--------------------------------------------------------------------
''    「再生」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------
    m_workVideo.playVideo()
    tmrVideo.Enabled = True
End Sub


Private Sub btnRewind_Click(sender As Object, e As EventArgs) Handles _
            btnRewind.Click
''--------------------------------------------------------------------
''    「<」 ボタンのクリックイベントハンドラ
''
''    100 ミリ秒だけ戻す
''--------------------------------------------------------------------
Dim msStep As Long

    msStep = CLng(Val(cmbStep.Text) * 1000)
    If (m_msCurPosition <= msStep) Then
        setPositionMiliSeconds(0, True)
        Exit Sub
    End If
    setPositionMiliSeconds(m_msCurPosition - msStep, True)

End Sub


Private Sub btnSeekEnd_Click(sender As Object, e As EventArgs) Handles _
            btnSeekEnd.Click
''--------------------------------------------------------------------
''    「Seek」ボタンのクリックイベントハンドラ
''
''    テキストボックス End Time 左の Seek ボタン
''    テキストボックスで指定された位置にシーク
''--------------------------------------------------------------------
Dim msNewPos As Long

    tmrVideo.Enabled = False
    msNewPos = getMiliSeconds(txtEndTime.Text)
    setPositionMiliSeconds(msNewPos, True)

End Sub

Private Sub btnSeekStart_Click(sender As Object, e As EventArgs) Handles _
            btnSeekStart.Click
''--------------------------------------------------------------------
''    「Seek」ボタンのクリックイベントハンドラ
''
''    テキストボックス Start Time 右の Seek ボタン
''    テキストボックスで指定された位置にシーク
''--------------------------------------------------------------------
Dim msNewPos As Long

    tmrVideo.Enabled = False
    msNewPos = getMiliSeconds(txtStartTime.Text)
    setPositionMiliSeconds(msNewPos, True)

End Sub


Private Sub btnSetEnd_Click(sender As Object, e As EventArgs) Handles _
            btnSetEnd.Click
''--------------------------------------------------------------------
''    「Set End」 ボタンのクリックイベントハンドラ
''
''    現在位置を Start Time テキストボックスにセットする
''--------------------------------------------------------------------
    txtEndTime.Text = getTimeTextFromMiliSeconds(m_msCurPosition)
End Sub


Private Sub btnSetStart_Click(sender As Object, e As EventArgs) Handles _
            btnSetStart.Click
''--------------------------------------------------------------------
''    「Set Start」 ボタンのクリックイベントハンドラ
''
''    現在位置を Start Time テキストボックスにセットする
''--------------------------------------------------------------------
    txtStartTime.Text = getTimeTextFromMiliSeconds(m_msCurPosition)
End Sub


Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles _
            btnStop.Click
''--------------------------------------------------------------------
''    「停止」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------
Dim msCurPos As Long

    tmrVideo.Enabled = False
    With m_workVideo
        .stopVideo()
        msCurPos = .getCurrentPosition()
    End With
    setPositionMiliSeconds(msCurPos, False)

End Sub


Private Sub EditTimeForm_Closed(sender As Object, e As EventArgs) Handles _
            Me.Closed
''--------------------------------------------------------------------
''    フォームが閉じられた時のイベントハンドラ
''--------------------------------------------------------------------

    With m_workVideo
        .stopVideo()
        .closeVideo()
    End With
    m_workVideo = Nothing

End Sub


Private Sub EditTimeForm_Load(sender As Object, e As EventArgs) Handles _
            MyBase.Load
''--------------------------------------------------------------------
''    フォームがロードされた時のイベントハンドラ
''--------------------------------------------------------------------

    With cmbStep
        With .Items
            .Clear()
            .Add(" 0.100 s")
            .Add("12.000 s")
            .Add("30.000 s")
            .Add("60.000 s")
        End With
        .SelectedIndex = 0
    End With

End Sub


Private Sub EditTimeForm_Shown(sender As Object, e As EventArgs) Handles _
            Me.Shown
''--------------------------------------------------------------------
''    フォームが最初に表示された時のイベントハンドラ
''--------------------------------------------------------------------

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
    setPositionMiliSeconds(msCurPos, False)

End Sub

End Class
