Public Class UpdateSub_R

    Private Sub SearchSubj_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchSubj_btn.Click
        SearchSubject_R_Update_btn()
    End Sub

    Private Sub UpdateSubj_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSubj_btn.Click
        updateSubjR_btn()
    End Sub
    Private Sub UpdateSub_R_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Registrar.Show()
        RegistrarPanel.Show()
    End Sub
End Class