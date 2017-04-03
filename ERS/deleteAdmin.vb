Public Class deleteAdmin
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        delad()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAccount_btn.Click
        delad1()
        deleteAdminAccounts()
    End Sub
    Private Sub deleteAdmin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
        DeleteAccount_btn.Show()
    End Sub

End Class