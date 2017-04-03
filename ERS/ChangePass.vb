Public Class ChangePass
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        chapass()
    End Sub

    Private Sub ChangePass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ne1.Text = My.Forms.ForgotV.ne1.Text
    End Sub
End Class