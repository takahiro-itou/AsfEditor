Public Class MainView

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
