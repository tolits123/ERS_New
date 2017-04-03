Public Class DeleteStudent_A

    Private Sub SearchStudent_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStudent_btn.Click
        SearchStudent_A_Delete_btn()
    End Sub
    Private Sub DeleteButton_a_Student_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton_a_Student.Click
        dropstud()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Screen_Registrar.Show()
        RegistrarPanel.Show()
        Me.Close()
    End Sub
    Private Sub DeleteStudent_A_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub
End Class