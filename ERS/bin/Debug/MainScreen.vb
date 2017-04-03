Public Class MainScreen
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        DateTimePicker1.Value = DateTime.Now
        datelbl.Text = DateTimePicker1.Value
    End Sub
    Private Sub MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = SystemInformation.PrimaryMonitorSize()
        Me.Location = New Point(0, 0)
    End Sub
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim a As Integer
        a = MsgBox("Are you sure do you want to exit?", MsgBoxStyle.YesNo)
        If (a = MsgBoxResult.Yes) Then
            close1()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsBtn.Click
        PictureBox1.Visible = False
        AboutBox1.TopLevel = False
        AdminBtn.Visible = False
        CashierBtn.Visible = False
        RegistrarBtn.Visible = False
        AboutUsBtn.Visible = False
        PictureBox1.Visible = False
        RegistrarLogin.Close()
        LoginAdmin.Close()
        Pi.Controls.Add(AboutBox1)
        AboutBox1.Show()

    End Sub
    Private Sub MainScreen_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        close1()
    End Sub

    Private Sub CashierBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashierBtn.Click
        PictureBox1.Visible = False
        CashierLogin.TopLevel = False
        AdminBtn.Visible = False
        CashierBtn.Visible = False
        RegistrarBtn.Visible = False
        AboutUsBtn.Visible = False
        PictureBox1.Visible = False
        RegistrarLogin.Close()
        LoginAdmin.Close()
        Pi.Controls.Add(CashierLogin)
        CashierLogin.Show()
    End Sub

    Private Sub RegistrarBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarBtn.Click
        RegistrarLogin.TopLevel = False
        Pi.Controls.Add(RegistrarLogin)
        PictureBox1.Visible = False
        AdminBtn.Visible = False
        CashierBtn.Visible = False
        RegistrarBtn.Visible = False
        AboutUsBtn.Visible = False
        LoginAdmin.Close()
        CashierLogin.Close()
        RegistrarLogin.Show()
    End Sub

    Private Sub AdminBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminBtn.Click
        PictureBox1.Visible = False
        LoginAdmin.TopLevel = False
        AdminBtn.Visible = False
        CashierBtn.Visible = False
        RegistrarBtn.Visible = False
        AboutUsBtn.Visible = False
        RegistrarLogin.Close()
        CashierLogin.Close()
        Pi.Controls.Add(LoginAdmin)
        LoginAdmin.Show()
    End Sub
End Class