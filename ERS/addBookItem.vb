Public Class addBookItem

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If gradelvl.SelectedItem = "" Or price.Text = "" Or subjectBookname.Text = "" Then
            MsgBox("Please enter the empty fields!")
        Else
            addBook()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gradelvl.SelectedItem = ""
        price.Text = ""
        subjectBookname.Text = ""
    End Sub
End Class