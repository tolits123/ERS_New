Public Class Screen_Admin

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click

        My.Application.OpenForms.Cast(Of Form)() _
        .Except({My.Forms.MainScreen}) _
          .ToList() _
      .ForEach(Sub(form) form.Close())
        My.Forms.MainScreen.Show()

        'My.Forms.MainScreen.AdminBtn.Visible = True
        'My.Forms.MainScreen.CashierBtn.Visible = True
        'My.Forms.MainScreen.RegistrarBtn.Visible = True
        'My.Forms.MainScreen.AboutUsBtn.Visible = True
        'My.Forms.MainScreen.PictureBox1.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim a As Integer
        a = MsgBox("Are you sure do you want to exit?", MsgBoxStyle.YesNo)
        If (a = MsgBoxResult.Yes) Then
            close1()
        End If
    End Sub

    Private Sub Screen_Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = SystemInformation.PrimaryMonitorSize()
        AdminPanelPictureBox.Size = Me.Size
        Me.Location = New Point(0, 0)
    End Sub

    Private Sub AddStudentRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddStudentRecordToolStripMenuItem.Click
        StudentCreate.TopLevel = False
        AdminPanelPictureBox.Controls.Add(StudentCreate)
        AdminPanel.Hide()
        StudentCreate.Show()
    End Sub

    Private Sub AddSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSubjectToolStripMenuItem.Click
        AddSubject.TopLevel = False
        AdminPanelPictureBox.Controls.Add(AddSubject)
        AdminPanel.Hide()
        AddSubject.Show()
    End Sub

    Private Sub AddAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAdminToolStripMenuItem.Click
        AdminCreate_1.TopLevel = False
        AdminPanelPictureBox.Controls.Add(AdminCreate_1)
        AdminPanel.Hide()
        AdminCreate_1.Show()
    End Sub

    Private Sub AddRegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRegistrarToolStripMenuItem.Click
        RegistrarCreate.TopLevel = False
        AdminPanelPictureBox.Controls.Add(RegistrarCreate)
        AdminPanel.Hide()
        RegistrarCreate.Show()
    End Sub

    Private Sub AddCashierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCashierToolStripMenuItem.Click
        CashierCreate.TopLevel = False
        AdminPanelPictureBox.Controls.Add(CashierCreate)
        AdminPanel.Hide()
        CashierCreate.Show()
    End Sub

    Private Sub DeleteAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAdminToolStripMenuItem.Click
        deleteAdmin.TopLevel = False
        AdminPanelPictureBox.Controls.Add(deleteAdmin)
        AdminPanel.Hide()
        deleteAdmin.Show()
    End Sub

    Private Sub DeleteRegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRegistrarToolStripMenuItem.Click
        DeleteRegistrar.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteRegistrar)
        AdminPanel.Hide()
        DeleteRegistrar.Show()
    End Sub

    Private Sub DeleteCashierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCashierToolStripMenuItem.Click
        DeleteCashier.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteCashier)
        AdminPanel.Hide()
        DeleteCashier.Show()
    End Sub

    Private Sub UpdateStudentRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStudentRecordToolStripMenuItem.Click
        UpdateStudent_A.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateStudent_A)
        AdminPanel.Hide()
        UpdateStudent_A.Show()
    End Sub

    Private Sub ViewStudentRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewStudentRecordToolStripMenuItem.Click
        ViewStudentInfo.TopLevel = False
        AdminPanelPictureBox.Controls.Add(ViewStudentInfo)
        AdminPanel.Hide()
        ViewStudentInfo.Show()
    End Sub

    Private Sub UpdateAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAccountToolStripMenuItem.Click
        UpdateAdmin.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateAdmin)
        AdminPanel.Hide()
        UpdateAdmin.Show()
    End Sub

    Private Sub UpdateSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSubjectToolStripMenuItem.Click
        UpdateSub_A.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateSub_A)
        AdminPanel.Hide()
        UpdateSub_A.Show()
    End Sub

    Private Sub DeleteSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSubjectToolStripMenuItem.Click
        DeleteSub_A.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteSub_A)
        AdminPanel.Hide()
        DeleteSub_A.Show()
    End Sub

    Private Sub DeleteStudentRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteStudentRecordToolStripMenuItem.Click
        DeleteStudent_R.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteStudent_R)
        AdminPanel.Hide()
        DeleteStudent_R.Show()
    End Sub

    Private Sub ViewRegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewRegistrarToolStripMenuItem.Click
        DeleteRegistrar.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteRegistrar)
        AdminPanel.Hide()
        My.Forms.DeleteRegistrar.Button2.Hide()
        My.Forms.DeleteRegistrar.Text = "View Registrar Account"
        DeleteRegistrar.Show()
    End Sub

    Private Sub ViewAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAdminToolStripMenuItem.Click
        deleteAdmin.TopLevel = False
        AdminPanelPictureBox.Controls.Add(deleteAdmin)
        AdminPanel.Hide()
        My.Forms.deleteAdmin.DeleteAccount_btn.Hide()
        My.Forms.deleteAdmin.Text = "View Admin Account"
        deleteAdmin.Show()
    End Sub

    Private Sub SearchAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAdminToolStripMenuItem.Click
        deleteAdmin.TopLevel = False
        AdminPanelPictureBox.Controls.Add(deleteAdmin)
        AdminPanel.Hide()
        My.Forms.deleteAdmin.DeleteAccount_btn.Hide()
        My.Forms.deleteAdmin.Text = "View Admin Account"
        deleteAdmin.Show()
    End Sub

    Private Sub SearchRegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchRegistrarToolStripMenuItem.Click
        DeleteRegistrar.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteRegistrar)
        AdminPanel.Hide()
        My.Forms.DeleteRegistrar.Button2.Hide()
        My.Forms.DeleteRegistrar.Text = "View Registrar Account"
        DeleteRegistrar.Show()
    End Sub

    Private Sub SearchCashierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchCashierToolStripMenuItem.Click
        DeleteCashier.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteCashier)
        AdminPanel.Hide()
        My.Forms.DeleteCashier.Button2.Hide()
        My.Forms.DeleteCashier.Text = "View Cashier Account"
        DeleteCashier.Show()
    End Sub

    Private Sub ViewCashierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewCashierToolStripMenuItem.Click
        DeleteCashier.TopLevel = False
        AdminPanelPictureBox.Controls.Add(DeleteCashier)
        AdminPanel.Hide()
        My.Forms.DeleteCashier.Button2.Hide()
        My.Forms.DeleteCashier.Text = "View Cashier Account"
        DeleteCashier.Show()
    End Sub

    Private Sub SearchStudentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStudentToolStripMenuItem.Click
        ViewStudentInfo.TopLevel = False
        AdminPanelPictureBox.Controls.Add(ViewStudentInfo)
        AdminPanel.Hide()
        ViewStudentInfo.Show()
    End Sub

    Private Sub SearchSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchSubjectToolStripMenuItem.Click
        ViewSubject.TopLevel = False
        AdminPanelPictureBox.Controls.Add(ViewSubject)
        AdminPanel.Hide()
        ViewSubject.Show()
    End Sub

    Private Sub ViewSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewSubjectToolStripMenuItem.Click
        ViewSubject.TopLevel = False
        AdminPanelPictureBox.Controls.Add(ViewSubject)
        AdminPanel.Hide()
        ViewSubject.Show()
    End Sub

    Private Sub UpdateAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAdminToolStripMenuItem.Click
        UpdateAdmin.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateAdmin)
        AdminPanel.Hide()
        UpdateAdmin.Show()
    End Sub

    Private Sub UpdateRegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateRegistrarToolStripMenuItem.Click
        UpdateRegistrar.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateRegistrar)
        AdminPanel.Hide()
        UpdateRegistrar.Show()
    End Sub

    Private Sub UpdateCashierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCashierToolStripMenuItem.Click
        UpdateCashier.TopLevel = False
        AdminPanelPictureBox.Controls.Add(UpdateCashier)
        AdminPanel.Hide()
        UpdateCashier.Show()
    End Sub
End Class