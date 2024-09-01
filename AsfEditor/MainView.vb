Public Class MainView

Private m_nInputCount As Integer
Private m_viInputList() As InputInfo


Private Function addFileToList(ByVal fileName As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    ReDim Preserve m_viInputList(m_nInputCount)
    m_viInputList(m_nInputCount) = New InputInfo()
    With m_viInputList(m_nInputCount)
        .sFileName = fileName
        .sStartTime = "00:00:00.000"
        .sEndTime = "00:00:00.000"
        .sTimeDuration = ""
        .bConcat = True
    End With
    m_nInputCount = m_nInputCount + 1

    updateGridView()
    addFileToList = True
End Function


Private Sub clearFileList()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub openInputFile()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    With dlgOpen
        .DefaultExt = ".wmv"
        .Filter = "asf file(*.wmv;*.asf)|*.wmv;*.asf|All files(*.*)|*.*"
        .FilterIndex = 1

        If .ShowDialog() = DialogResult.OK Then
            addFileToList(.FileName)
        End If
    End With

End Sub


Private Function removeFileFromList() As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Function


Private Sub showSaveFileDialog(ByRef targetTextBox As TextBox)
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub updateGridView()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim i As Integer
Dim srcInfo As InputInfo

    With dgvInputs
        .Rows.Clear()

        For i = 0 To m_nInputCount - 1
            srcInfo = m_viInputList(i)
            .Rows.Add(
                srcInfo.bConcat,
                srcInfo.sFileName,
                srcInfo.sStartTime,
                srcInfo.sEndTime,
                srcInfo.sTimeDuration
            )
        Next i
    End With

End Sub


Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles _
            btnAdd.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    openInputFile()
End Sub


Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles _
            btnClear.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    clearFileList()
End Sub


Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles _
            btnDown.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub btnPerform_Click(sender As Object, e As EventArgs) Handles _
            btnPerform.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles _
            btnRemove.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    removeFileFromList()
End Sub


Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles _
            btnUp.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles _
            btnOutput.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    showSaveFileDialog(txtOutFile)
End Sub


Private Sub btnWorkDir_Click(sender As Object, e As EventArgs) Handles _
            btnWorkDir.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    showSaveFileDialog(txtWorkDir)
End Sub


Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles _
            btnEdit.Click, mnuEditTime.Click
''--------------------------------------------------------------------
''    「編集」ボタンのクリックイベントハンドラ。
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
Dim selIndex As Integer

    For Each r As DataGridViewRow In dgvInputs.SelectedRows
        selIndex = r.Index - 1
    Next r

    Using frmEdit As New EditTimeForm()
        With frmEdit
            .ShowDialog(Me)

            .Dispose()
        End With
    End Using

End Sub


Private Sub mnuFileAdd_Click(sender As Object, e As EventArgs) Handles _
            mnuFileAdd.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「追加」
''--------------------------------------------------------------------
    openInputFile()
End Sub


Private Sub mnuFileClear_Click(sender As Object, e As EventArgs) Handles _
            mnuFileClear.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「クリア」
''--------------------------------------------------------------------
    clearFileList()
End Sub


Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles _
            mnuFileExit.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
    Application.Exit()
End Sub


Private Sub mnuFileOutput_Click(sender As Object, e As EventArgs) Handles _
    mnuFileOutput.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「出力」
''--------------------------------------------------------------------
    showSaveFileDialog(txtOutFile)
End Sub


Private Sub mnuFileRemove_Click(sender As Object, e As EventArgs) Handles _
            mnuFileRemove.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「削除」
''--------------------------------------------------------------------
    removeFileFromList()
End Sub


Private Sub mnuFileWorkDir_Click(sender As Object, e As EventArgs) Handles _
            mnuFileWorkDir.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「作業ディレクトリ」
''--------------------------------------------------------------------
    showSaveFileDialog(txtWorkDir)
End Sub


End Class
