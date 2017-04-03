Public Class DeleteRegistrar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RegE()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        deleteRegistrarAccounts()
        regdel()
    End Sub
    Private Sub DeleteRegistrar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         Screen_Admin.Show()
        AdminPanel.Show()
        Button2.Show()
    End Sub
End Class