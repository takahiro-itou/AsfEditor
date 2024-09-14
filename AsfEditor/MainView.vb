Public Class MainView

' 入力
Private m_nInputCount As Integer
Private m_viInputList() As InputInfo

' 変更があったかどうかを示すフラグ
Private m_flagModified As Boolean

Private m_workVideo As New MciWrapper("", 0)


Private Function addFileToList(ByVal fileName As String) As Boolean
''--------------------------------------------------------------------
''    ファイルをリストに追加する
''--------------------------------------------------------------------
Dim trgIndex As Integer
Dim msVideoLen As Long

    trgIndex = m_nInputCount
    ReDim Preserve m_viInputList(m_nInputCount)
    m_nInputCount = m_nInputCount + 1

    msVideoLen = 0
    With m_workVideo
        .setFileName(fileName)
        .openAsfFile()
        msVideoLen = .getVideoLength()
    End With

    m_viInputList(trgIndex) = New InputInfo()
    With m_viInputList(trgIndex)
        .bValidData = False
        .sFileName = fileName
        .msLength = msVideoLen
        .sStartTime = "00:00:00.000"
        .sEndTime = getTimeTextFromMiliSeconds(msVideoLen)
        .sTimeDuration = ""
        .bConcat = True
    End With

    updateModifyFlag(True)
    updateGridView(trgIndex)

    addFileToList = True
End Function


Private Sub clearFileList()
''--------------------------------------------------------------------
''    ファイルリストを空にする
''--------------------------------------------------------------------
    m_nInputCount = 0
    updateModifyFlag(False)
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
                 updateModifyFlag(True)
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

    ' 実行前にボタンを無効にし、
    ' 処理中に二度押しされないようにする。
    ' 入出力に変化があるまでは、再実行しても意味がないので
    ' そのまま無効にしたままにしておく。
    updateModifyFlag(False)

    performVideoEdit(
        m_viInputList, txtOutFile.Text, txtWorkDir.Text
    )
End Sub


Private Sub handleUpDownButton(ByVal iDir As Integer)
''--------------------------------------------------------------------
''    「UP」「DOWN」ボタンのクリックイベントを処理する
''--------------------------------------------------------------------
Dim selIndex As Integer

    With dgvInputs
        If .CurrentRow Is Nothing Then
            Exit Sub
        End If
        selIndex = .CurrentRow.Index
    End With

    moveListItem(selIndex, selIndex + iDir)
End Sub


Private Function isRunnable()
''--------------------------------------------------------------------
''    実行可能な状態になっているか確認する
''--------------------------------------------------------------------

    isRunnable = True

    ' 設定が完了していない入力がある場合は、実行ボタンは無効にする
    For i = 0 To m_nInputCount - 1
        If m_viInputList(i).bValidData = False Then
            ' まだ設定が終わっていない入力があるときは、
            ' 実行ボタンを押せないようにしておく
            isRunnable = False
            Exit Function
        End If
    Next i

    ' 出力ファイルが指定されていない時も、実行ボタンは無効にする
    If txtOutFile.Text = "" Or txtWorkDir.Text = "" Then
        isRunnable = False
        Exit Function
    End If

    isRunnable = True
End Function


Private Function moveListItem(
        ByVal posSrc As Integer, ByVal posDst As Integer) As Boolean
''--------------------------------------------------------------------
''    リスト内の項目を並べ替える
''--------------------------------------------------------------------
Dim i As Integer, idxDir As Integer
Dim viSrc As InputInfo

    If (posSrc = posDst) Then
        ' 移動先が移動元と同じなので何もすることがない
        moveListItem = False
        Exit Function
    End If

    If (posSrc < 0) Or (m_nInputCount <= posSrc) Then
        ' 指定した移動元が範囲外
        moveListItem = False
        Exit Function
    End If
    If (posDst < 0) Or (m_nInputCount <= posDst) Then
        ' 指定した移動先が範囲外
        moveListItem = False
        Exit Function
    End If

    updateModifyFlag(True)

    viSrc = m_viInputList(posSrc)
    If (posDst < posSrc) Then
        idxDir = -1
    Else
        idxDir = 1
    End If

    For i = posSrc + idxDir To posDst Step idxDir
        m_viInputList(i - idxDir) = m_viInputList(i)
    Next i
    m_viInputList(posDst) = viSrc

    updateGridView(posDst)
    moveListItem = True
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

    updateModifyFlag(True)

    ' 選択した番号を削除し、後ろのデータを詰める
    lastInputs = m_nInputCount - 1
    For i = selIndex + 1 To lastInputs
        m_viInputList(i - 1) = m_viInputList(i)
    Next i

    m_nInputCount = lastInputs
    ReDim Preserve m_viInputList(lastInputs)

    updateModifyFlag(True)
    updateGridView(0)

    removeFileFromList = True
End Function


Private Function showSaveFileDialog(
        ByRef targetTextBox As TextBox, ByVal bDir As Boolean) As String
''--------------------------------------------------------------------
''    「名前を付けて保存」ダイアログを表示する
''
''    選択したファイル名を指定したテキストボックスに表示する
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

    updateModifyFlag(True)

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


Private Sub updateModifyFlag(ByVal flagNew As Boolean)
''--------------------------------------------------------------------
''    変更ありフラグの状態を設定する
''--------------------------------------------------------------------
Dim flagRunnable As Boolean

    m_flagModified = flagNew
    flagRunnable = flagNew

    If flagRunnable = True Then
        flagRunnable = isRunnable()
    End If

    ' フラグの値に応じて、ボタンやメニューの状態を変更しておく
    btnPerform.Enabled = flagRunnable
    mnuEditPerform.Enabled = flagRunnable
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
''    「DOWN」ボタンのクリックイベントハンドラ。
''--------------------------------------------------------------------
    handleUpDownButton(1)
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
            btnPerform.Click, mnuEditPerform.Click
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
''    「UP」ボタンのクリックイベントハンドラ。
''--------------------------------------------------------------------
    handleUpDownButton(-1)
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

    updateModifyFlag(True)
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
    updateModifyFlag(True)
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


Private Sub MainView_Load(sender As Object, e As EventArgs) Handles _
            MyBase.Load
''--------------------------------------------------------------------
''    フォームのロードイベントハンドラ
''--------------------------------------------------------------------
    updateModifyFlag(False)
End Sub


Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles _
            mnuFileExit.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
    Application.Exit()
End Sub


End Class
