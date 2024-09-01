Public Class MainView

Private m_nInputCount As Integer
Private m_viInputList() As InputInfo


Private Function addFileToList(ByVal fileName As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim trgIndex As Integer

    trgIndex = m_nInputCount
    ReDim Preserve m_viInputList(m_nInputCount)
    m_nInputCount = m_nInputCount + 1

    m_viInputList(trgIndex) = New InputInfo()
    With m_viInputList(trgIndex)
        .sFileName = fileName
        .sStartTime = "00:00:00.000"
        .sEndTime = "00:00:00.000"
        .sTimeDuration = ""
        .bConcat = True
    End With

    updateGridView(trgIndex)
    addFileToList = True
End Function


Private Sub clearFileList()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Private Sub handleEditButton()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim selIndex As Integer

    With dgvInputs
        selIndex = .CurrentRow.Index
        For Each r As DataGridViewRow In .SelectedRows
            selIndex = r.Index
        Next r
    End With

    Using frmEdit As New EditTimeForm()
        With frmEdit
             .setTargetInfo(m_viInputList(selIndex))
            .ShowDialog(Me)

             If .DialogResult = DialogResult.OK Then

             End If

            .Dispose()
        End With
    End Using

    updateGridView(selIndex)
End Sub


Private Sub handlePerformButton()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    performVideoEdit(
        m_viInputList, txtOutFile.Text, txtWorkDir.Text
    )
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


Private Function showSaveFileDialog(
        ByRef targetTextBox As TextBox, ByVal bDir As Boolean) As String
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim selFile As String
Dim sepDir As String = "\"  ' " ディレクトリの区切り

    With dlgSave
        .DefaultExt = ".wmv"
        .Filter = "asf file(*.wmv;*.asf)|*.wmv;*.asf|All files(*.*)|*.*"
        .FilterIndex = 1

        If .ShowDialog() <> DialogResult.OK Then
            showSaveFileDialog = ""
            Exit Function
        End If
        selFile = .FileName
    End With

    If bDir Then
        selFile = System.IO.Path.GetDirectoryName(selFile) & sepDir
    End If

    targetTextBox.Text = selFile
    showSaveFileDialog = selFile
End Function


Private Sub updateGridView(ByVal selIndex As Integer)
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

        .CurrentCell = .Rows(selIndex).Cells(0)
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


Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles _
            btnEdit.Click, mnuEditTime.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「編集」ボタンのクリックイベント
''    メニュー「編集」－「時間範囲を指定」
''--------------------------------------------------------------------
    handleEditButton()
End Sub


Private Sub btnPerform_Click(sender As Object, e As EventArgs) Handles _
            btnPerform.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「実行」ボタンのクリックイベント
''    メニュー「編集」－「実行」
''--------------------------------------------------------------------
    handlePerformButton()
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
            btnOutput.Click, mnuFileOutput.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「出力ファイル」の参照ボタンのクリックイベント
''    メニュー「ファイル」－「出力」
''--------------------------------------------------------------------
Dim selFile As String
Dim sepDir As String = "\"  ' " ディレクトリの区切り

    selFile = showSaveFileDialog(txtOutFile, False)
    If txtWorkDir.Text = "" And selFile <> "" Then
        txtWorkDir.Text = System.IO.Path.GetDirectoryName(selFile) & sepDir
    End If

End Sub


Private Sub btnWorkDir_Click(sender As Object, e As EventArgs) Handles _
            btnWorkDir.Click, mnuFileWorkDir.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「作業ディレクトリ」の参照ボタンのクリックイベント
''    メニュー「ファイル」－「作業ディレクトリ」
''--------------------------------------------------------------------
    showSaveFileDialog(txtWorkDir, True)
End Sub


Private Sub dgvInputs_CellDoubleClick(
        sender As Object, e As DataGridViewCellEventArgs) _
    Handles dgvInputs.CellDoubleClick
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    グリッドビューのセルをダブルクリック
''--------------------------------------------------------------------
    handleEditButton()
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


Private Sub mnuFileRemove_Click(sender As Object, e As EventArgs) Handles _
            mnuFileRemove.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「削除」
''--------------------------------------------------------------------
    removeFileFromList()
End Sub


End Class
