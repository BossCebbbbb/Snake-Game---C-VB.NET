Public Class DifficultySelectionForm

    Public Property SelectedDifficulty As String


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SelectedDifficulty = "Hard"
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SelectedDifficulty = "Medium"
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectedDifficulty = "Easy"
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class