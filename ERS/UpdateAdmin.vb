Public Class UpdateAdmin

    Private Sub ValidateAccountUpdate_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidateAccountUpdate_btn.Click
        vadmmin_btn()
    End Sub

    Private Sub UpdateAdmin_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAdmin_btn.Click
        updateAccntAdmin_btn()
    End Sub

    Private Sub UpdateAdmin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub
End Class