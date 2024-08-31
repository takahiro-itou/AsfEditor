Public Class MainView

Private Sub RunCommand(ByVal command As String)
''--------------------------------------------------------------------
''    指定したコマンドを実行する。
''--------------------------------------------------------------------

    Using process As New System.Diagnostics.Process()
        process.StartInfo.FileName = "ipconfig.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = False
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardError = False
        process.Start()

        Dim Reader As System.IO.StreamReader = process.StandardOutput
        Dim output As String = Reader.ReadToEnd()

        txtOutput.Text = output
        process.WaitForExit()
        process.Close()
    End Using

End Sub


Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles _
            btnRun.Click
''--------------------------------------------------------------------
''    「実行」ボタンのクリックイベントハンドラ。
''
''    入力したコマンドを実行する。
''--------------------------------------------------------------------

    RunCommand(txtCommand.Text)
End Sub

Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles _
            mnuFileExit.Click
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------

    Application.Exit()
End Sub


Private Sub mnuRunCommand_Click(sender As Object, e As EventArgs) Handles _
            mnuRunCommand.Click
''--------------------------------------------------------------------
''    メニュー「実行」－「コマンドを実行」
''--------------------------------------------------------------------

    RunCommand(txtCommand.Text)
End Sub

End Class
