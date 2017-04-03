Public Class UpdateSub_A
    Private Sub SearchSubj_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchSubj_btn.Click
        SearchSubject_A_Update_btn()
    End Sub
    Private Sub UpdateSubj_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSubj_btn.Click
        updateSubjA_btn()
    End Sub
    Private Sub UpdateSub_A_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub
End Class