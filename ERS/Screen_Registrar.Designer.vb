<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Screen_Registrar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcademeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStudentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateStudentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteStudentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewStudentRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarPanelPictureBox = New System.Windows.Forms.PictureBox()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.RegistrarPanelPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1020, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AcademeToolStripMenuItem, Me.SearchToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1020, 24)
        Me.MenuStrip2.TabIndex = 1
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateAccountToolStripMenuItem, Me.ToolStripSeparator1, Me.LogoutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'UpdateAccountToolStripMenuItem
        '
        Me.UpdateAccountToolStripMenuItem.Name = "UpdateAccountToolStripMenuItem"
        Me.UpdateAccountToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.UpdateAccountToolStripMenuItem.Text = "Update Account"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AcademeToolStripMenuItem
        '
        Me.AcademeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentRecordToolStripMenuItem, Me.SubjectsToolStripMenuItem})
        Me.AcademeToolStripMenuItem.Name = "AcademeToolStripMenuItem"
        Me.AcademeToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.AcademeToolStripMenuItem.Text = "Academe"
        '
        'StudentRecordToolStripMenuItem
        '
        Me.StudentRecordToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStudentRecordToolStripMenuItem, Me.UpdateStudentRecordToolStripMenuItem, Me.DeleteStudentRecordToolStripMenuItem, Me.ToolStripSeparator2, Me.ViewStudentRecordToolStripMenuItem})
        Me.StudentRecordToolStripMenuItem.Name = "StudentRecordToolStripMenuItem"
        Me.StudentRecordToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.StudentRecordToolStripMenuItem.Text = "Student Record"
        '
        'AddStudentRecordToolStripMenuItem
        '
        Me.AddStudentRecordToolStripMenuItem.Name = "AddStudentRecordToolStripMenuItem"
        Me.AddStudentRecordToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AddStudentRecordToolStripMenuItem.Text = "Add Student Record"
        '
        'UpdateStudentRecordToolStripMenuItem
        '
        Me.UpdateStudentRecordToolStripMenuItem.Name = "UpdateStudentRecordToolStripMenuItem"
        Me.UpdateStudentRecordToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.UpdateStudentRecordToolStripMenuItem.Text = "Update Student Record"
        '
        'DeleteStudentRecordToolStripMenuItem
        '
        Me.DeleteStudentRecordToolStripMenuItem.Name = "DeleteStudentRecordToolStripMenuItem"
        Me.DeleteStudentRecordToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.DeleteStudentRecordToolStripMenuItem.Text = "Delete Student Record"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(193, 6)
        '
        'ViewStudentRecordToolStripMenuItem
        '
        Me.ViewStudentRecordToolStripMenuItem.Name = "ViewStudentRecordToolStripMenuItem"
        Me.ViewStudentRecordToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ViewStudentRecordToolStripMenuItem.Text = "View Student Record"
        '
        'SubjectsToolStripMenuItem
        '
        Me.SubjectsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSubjectToolStripMenuItem, Me.UpdateSubjectToolStripMenuItem, Me.DeleteSubjectToolStripMenuItem, Me.ToolStripSeparator3, Me.ViewSubjectToolStripMenuItem})
        Me.SubjectsToolStripMenuItem.Name = "SubjectsToolStripMenuItem"
        Me.SubjectsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SubjectsToolStripMenuItem.Text = "Subjects"
        '
        'AddSubjectToolStripMenuItem
        '
        Me.AddSubjectToolStripMenuItem.Name = "AddSubjectToolStripMenuItem"
        Me.AddSubjectToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AddSubjectToolStripMenuItem.Text = "Add Subject"
        '
        'UpdateSubjectToolStripMenuItem
        '
        Me.UpdateSubjectToolStripMenuItem.Name = "UpdateSubjectToolStripMenuItem"
        Me.UpdateSubjectToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.UpdateSubjectToolStripMenuItem.Text = "Update Subject"
        '
        'DeleteSubjectToolStripMenuItem
        '
        Me.DeleteSubjectToolStripMenuItem.Name = "DeleteSubjectToolStripMenuItem"
        Me.DeleteSubjectToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DeleteSubjectToolStripMenuItem.Text = "Delete Subject"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(151, 6)
        '
        'ViewSubjectToolStripMenuItem
        '
        Me.ViewSubjectToolStripMenuItem.Name = "ViewSubjectToolStripMenuItem"
        Me.ViewSubjectToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ViewSubjectToolStripMenuItem.Text = "View Subject"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentToolStripMenuItem, Me.SubjectToolStripMenuItem, Me.PaymentsToolStripMenuItem})
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchStudentToolStripMenuItem})
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StudentToolStripMenuItem.Text = "Search Student"
        '
        'SearchStudentToolStripMenuItem
        '
        Me.SearchStudentToolStripMenuItem.Name = "SearchStudentToolStripMenuItem"
        Me.SearchStudentToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SearchStudentToolStripMenuItem.Text = "Search Student"
        '
        'SubjectToolStripMenuItem
        '
        Me.SubjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubjectToolStripMenuItem1})
        Me.SubjectToolStripMenuItem.Name = "SubjectToolStripMenuItem"
        Me.SubjectToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SubjectToolStripMenuItem.Text = "Search Subject"
        '
        'SubjectToolStripMenuItem1
        '
        Me.SubjectToolStripMenuItem1.Name = "SubjectToolStripMenuItem1"
        Me.SubjectToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.SubjectToolStripMenuItem1.Text = "Subject"
        '
        'PaymentsToolStripMenuItem
        '
        Me.PaymentsToolStripMenuItem.Name = "PaymentsToolStripMenuItem"
        Me.PaymentsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PaymentsToolStripMenuItem.Text = "Search Payments"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.AboutUsToolStripMenuItem.Text = "About Us"
        '
        'RegistrarPanelPictureBox
        '
        Me.RegistrarPanelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RegistrarPanelPictureBox.Location = New System.Drawing.Point(0, 48)
        Me.RegistrarPanelPictureBox.Name = "RegistrarPanelPictureBox"
        Me.RegistrarPanelPictureBox.Size = New System.Drawing.Size(1020, 453)
        Me.RegistrarPanelPictureBox.TabIndex = 2
        Me.RegistrarPanelPictureBox.TabStop = False
        '
        'Screen_Registrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 501)
        Me.Controls.Add(Me.RegistrarPanelPictureBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Screen_Registrar"
        Me.Text = "Registrar"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.RegistrarPanelPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcademeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddStudentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateStudentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteStudentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewStudentRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarPanelPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents SubjectToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
