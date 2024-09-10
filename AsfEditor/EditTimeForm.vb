﻿Public Class EditTimeForm

Private m_currentInfo As InputInfo
Private m_savedInfo As InputInfo


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


Public Function setTargetInfo(ByVal targetInfo As InputInfo) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    m_currentInfo = targetInfo
    With m_currentInfo
        txtStartTime.Text = .sStartTime
        txtEndTime.Text = .sEndTime
    End With

    setTargetInfo = True
End Function


Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles _
            btnApply.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    applyEdit()
End Sub


Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles _
            btnCancel.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim msgAns As System.Windows.Forms.DialogResult

    msgAns = MessageBox.Show(
        "途中で保存されたデータがあります。" & vbCrLf &
        "そのデータを採用しますか？",
        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    If (msgAns = Windows.Forms.DialogResult.Cancel) Then
        ' キャンセルされたのでダイアログを閉じるのをやめる
        Exit Sub
    End If

    Me.DialogResult = DialogResult.Cancel
    Me.Close()

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


End Class
