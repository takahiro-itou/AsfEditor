Public Class MainView

Private m_nInputCount As Integer
Private m_viInputList() As InputInfo


Private Function addFileToList(ByVal fileName As String) As Boolean
''--------------------------------------------------------------------
''    ファイルをリストに追加する
''--------------------------------------------------------------------
Dim trgIndex As Integer

    trgIndex = m_nInputCount
    ReDim Preserve m_viInputList(m_nInputCount)
    m_nInputCount = m_nInputCount + 1

    m_viInputList(trgIndex) = New InputInfo()
    With m_viInputList(trgIndex)
        .bValidData = False
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
''    ファイルリストを空にする
''--------------------------------------------------------------------
    m_nInputCount = 0
    updateGridView(-1)
End Sub


Private Sub handleEditButton()
''--------------------------------------------------------------------
''    編集ボタンまたはメニューのクリックイベントを処理する
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
''    実行ボタンまたはメニューのクリックイベントを処理する
''--------------------------------------------------------------------
    performVideoEdit(
        m_viInputList, txtOutFile.Text, txtWorkDir.Text
    )
End Sub


Private Function moveListItem(
        ByVal posSrc As Integer, ByVal posDst As Integer) As Boolean
''--------------------------------------------------------------------
''    リスト内の項目を並べ替える
''--------------------------------------------------------------------
Dim viSrc As InputInfo

    If (posSrc < 0) Or (m_nInputCount <= posSrc) Then
        ' 指定した移動元が範囲外
        moveListItem = False
        Exit Function
    End If
    If (posDst < 0) Or (m_nInputCount < podDst) Then
        ' 指定した移動先が範囲外
        moveListItem = False
        Exit Function
    End If

    viSrc = m_viInputList(posSrc)
End Function


Private Sub openInputFile()
''--------------------------------------------------------------------
''    入力ファイルを指定する
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
''    選択したファイルをリストから除外する
''
''    リストから除外するだけで、ファイル自体は消さない
''--------------------------------------------------------------------
Dim selIndex As Integer
Dim i As Integer
Dim lastInputs As Integer

    With dgvInputs
        If .CurrentRow Is Nothing Then
            removeFileFromList = False
            Exit Function
        End If
        selIndex = .CurrentRow.Index
    End With

    ' 選択した番号を削除し、後ろのデータを詰める
    lastInputs = m_nInputCount - 1
    For i = selIndex + 1 To lastInputs
        m_viInputList(i - 1) = m_viInputList(i)
    Next i

    m_nInputCount = lastInputs
    ReDim Preserve m_viInputList(lastInputs)
    updateGridView(0)
    removeFileFromList = True
End Function


Private Function showSaveFileDialog(
        ByRef targetTextBox As TextBox, ByVal bDir As Boolean) As String
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim selFile As String

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
        selFile = uniformDirName(System.IO.Path.GetDirectoryName(selFile))
    End If

    targetTextBox.Text = selFile
    showSaveFileDialog = selFile
End Function


Private Sub updateGridView(ByVal selIndex As Integer)
''--------------------------------------------------------------------
''    グリッドビューを更新する
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

        If (0 <= selIndex) And (selIndex < m_nInputCount) Then
            .CurrentCell = .Rows(selIndex).Cells(0)
        End If
    End With

End Sub


Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles _
            btnAdd.Click, mnuFileAdd.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「追加」ボタンのクリックイベント
''    メニュー「ファイル」－「追加」
''--------------------------------------------------------------------
    openInputFile()
End Sub


Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles _
            btnClear.Click, mnuFileClear.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「クリア」ボタンのクリックイベント
''    メニュー「ファイル」－「クリア」
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
            btnRemove.Click, mnuFileRemove.Click
''--------------------------------------------------------------------
''    イベントハンドラ。
''
''    「除外」ボタンのクリックイベント
''    メニュー「ファイル」－「除外」
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
Dim selDir As String

    selFile = showSaveFileDialog(txtOutFile, False)

    If txtWorkDir.Text = "" And selFile <> "" Then
        selDir = uniformDirName(System.IO.Path.GetDirectoryName(selFile))
        txtWorkDir.Text = selDir
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


Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles _
            mnuFileExit.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
    Application.Exit()
End Sub


End Class
