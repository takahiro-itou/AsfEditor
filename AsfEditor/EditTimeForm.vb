Public Class EditTimeForm

Private m_currentInfo As InputInfo

Private Function applyEdit()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim workInfo As New InputInfo

    If setTimeInfo(workInfo, txtStartTime.Text, txtEndTime.Text) = False Then
        MessageBox.Show("Invalid Input")
        applyEdit = False
        Exit Function
    End If

    With m_currentInfo
        .sStartTime = workInfo.sStartTime
        .sEndTime = workInfo.sEndTime
        .sTimeDuration = workInfo.sTimeDuration
    End With

    applyEdit = True
End Function


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

    Me.DialogResult = DialogResult.Cancel
    Me.Close()

End Sub


Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles _
            btnOK.Click
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    If applyEdit() = False Then
        Exit Sub
    End If

    Me.DialogResult = DialogResult.OK
    Me.Close()

End Sub


End Class
