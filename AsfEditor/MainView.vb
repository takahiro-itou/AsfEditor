Public Class MainView

Private m_nInputCount As Integer
Private m_viInputList() As InputInfo


Private Function addFileToList(ByVal fileName As Strign) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    ReDim Preserve m_viInputList(m_nInputCount)
    m_viInputList(m_nInputCount) = New InputInfo()
    With m_viInputList(m_nInputCount)
        .FileName = fileName
        .sStartTime = "00:00:00.000"
        .sEndTime = "00:00:00.000"
        .sTimeDuration = ""
        .bConcat = True
    End With
    m_nInputCount = m_nInputCount + 1

    updateGridView()
    addFileToList = True
End Function


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


Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles _
            mnuFileExit.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------

    Application.Exit()
End Sub

End Class
