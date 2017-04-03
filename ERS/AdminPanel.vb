Public Class AdminPanel
    Private Sub AdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(1, 1)
        Me.Size = SystemInformation.PrimaryMonitorSize()
        Me.empl.Text = My.Forms.LoginAdmin.en.Text
        adminPan()
    End Sub
End Class