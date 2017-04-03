Public Class RegistrarPanel

    Private Sub RegistrarPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(1, 1)
        Me.Size = SystemInformation.PrimaryMonitorSize()
        Me.empl.Text = My.Forms.RegistrarLogin.en.Text
        registrarPanelDisplay()
    End Sub
End Class