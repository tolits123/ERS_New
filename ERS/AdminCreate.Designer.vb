﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminCreate))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.rtp = New System.Windows.Forms.MaskedTextBox()
        Me.ans2 = New System.Windows.Forms.MaskedTextBox()
        Me.pw = New System.Windows.Forms.MaskedTextBox()
        Me.eadd = New System.Windows.Forms.TextBox()
        Me.sq2 = New System.Windows.Forms.ComboBox()
        Me.cno = New System.Windows.Forms.MaskedTextBox()
        Me.ans1 = New System.Windows.Forms.MaskedTextBox()
        Me.bd = New System.Windows.Forms.DateTimePicker()
        Me.sq1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.en = New System.Windows.Forms.MaskedTextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ln = New System.Windows.Forms.TextBox()
        Me.fn = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.add = New System.Windows.Forms.TextBox()
        Me.mn = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.statusTxtBoxAdmin = New System.Windows.Forms.TextBox()
        Me.loginAttempt = New System.Windows.Forms.TextBox()
        Me.pl = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(241, 532)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(326, 532)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(7, 182)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(135, 23)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "TakePhoto"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 160)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(135, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "UploadPhoto"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'rtp
        '
        Me.rtp.Location = New System.Drawing.Point(607, 244)
        Me.rtp.Name = "rtp"
        Me.rtp.Size = New System.Drawing.Size(227, 20)
        Me.rtp.TabIndex = 13
        '
        'ans2
        '
        Me.ans2.Location = New System.Drawing.Point(180, 293)
        Me.ans2.Name = "ans2"
        Me.ans2.Size = New System.Drawing.Size(235, 20)
        Me.ans2.TabIndex = 15
        '
        'pw
        '
        Me.pw.Location = New System.Drawing.Point(602, 215)
        Me.pw.Name = "pw"
        Me.pw.Size = New System.Drawing.Size(228, 20)
        Me.pw.TabIndex = 11
        '
        'eadd
        '
        Me.eadd.Location = New System.Drawing.Point(256, 183)
        Me.eadd.Name = "eadd"
        Me.eadd.Size = New System.Drawing.Size(229, 20)
        Me.eadd.TabIndex = 8
        '
        'sq2
        '
        Me.sq2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sq2.FormattingEnabled = True
        Me.sq2.Items.AddRange(New Object() {"sq2"})
        Me.sq2.Location = New System.Drawing.Point(180, 265)
        Me.sq2.Name = "sq2"
        Me.sq2.Size = New System.Drawing.Size(262, 21)
        Me.sq2.TabIndex = 14
        '
        'cno
        '
        Me.cno.Location = New System.Drawing.Point(623, 153)
        Me.cno.Name = "cno"
        Me.cno.Size = New System.Drawing.Size(207, 20)
        Me.cno.TabIndex = 7
        '
        'ans1
        '
        Me.ans1.Location = New System.Drawing.Point(180, 238)
        Me.ans1.Name = "ans1"
        Me.ans1.Size = New System.Drawing.Size(235, 20)
        Me.ans1.TabIndex = 12
        '
        'bd
        '
        Me.bd.CustomFormat = "MM/dd/yyyy"
        Me.bd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.bd.Location = New System.Drawing.Point(240, 154)
        Me.bd.Name = "bd"
        Me.bd.Size = New System.Drawing.Size(260, 20)
        Me.bd.TabIndex = 6
        '
        'sq1
        '
        Me.sq1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sq1.FormattingEnabled = True
        Me.sq1.Items.AddRange(New Object() {"sq1"})
        Me.sq1.Location = New System.Drawing.Point(180, 210)
        Me.sq1.Name = "sq1"
        Me.sq1.Size = New System.Drawing.Size(262, 21)
        Me.sq1.TabIndex = 10
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Male", "Female"})
        Me.ComboBox1.Location = New System.Drawing.Point(696, 123)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(134, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(563, 286)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(12, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'en
        '
        Me.en.Location = New System.Drawing.Point(625, 183)
        Me.en.Name = "en"
        Me.en.Size = New System.Drawing.Size(207, 20)
        Me.en.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(660, 278)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(170, 38)
        Me.Button6.TabIndex = 18
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ln
        '
        Me.ln.Location = New System.Drawing.Point(144, 94)
        Me.ln.Name = "ln"
        Me.ln.Size = New System.Drawing.Size(210, 20)
        Me.ln.TabIndex = 1
        '
        'fn
        '
        Me.fn.Location = New System.Drawing.Point(382, 94)
        Me.fn.Name = "fn"
        Me.fn.Size = New System.Drawing.Size(213, 20)
        Me.fn.TabIndex = 2
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'add
        '
        Me.add.Location = New System.Drawing.Point(259, 122)
        Me.add.Name = "add"
        Me.add.Size = New System.Drawing.Size(350, 20)
        Me.add.TabIndex = 4
        '
        'mn
        '
        Me.mn.Location = New System.Drawing.Point(614, 95)
        Me.mn.Name = "mn"
        Me.mn.Size = New System.Drawing.Size(216, 20)
        Me.mn.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(842, 330)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'statusTxtBoxAdmin
        '
        Me.statusTxtBoxAdmin.Enabled = False
        Me.statusTxtBoxAdmin.Location = New System.Drawing.Point(29, 80)
        Me.statusTxtBoxAdmin.Name = "statusTxtBoxAdmin"
        Me.statusTxtBoxAdmin.Size = New System.Drawing.Size(47, 20)
        Me.statusTxtBoxAdmin.TabIndex = 37
        Me.statusTxtBoxAdmin.Text = "active"
        Me.statusTxtBoxAdmin.Visible = False
        '
        'loginAttempt
        '
        Me.loginAttempt.Location = New System.Drawing.Point(82, 99)
        Me.loginAttempt.Name = "loginAttempt"
        Me.loginAttempt.Size = New System.Drawing.Size(29, 20)
        Me.loginAttempt.TabIndex = 38
        Me.loginAttempt.Text = "0"
        Me.loginAttempt.Visible = False
        '
        'pl
        '
        Me.pl.Location = New System.Drawing.Point(29, 111)
        Me.pl.Multiline = True
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(70, 33)
        Me.pl.TabIndex = 39
        '
        'AdminCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 330)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.loginAttempt)
        Me.Controls.Add(Me.statusTxtBoxAdmin)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.rtp)
        Me.Controls.Add(Me.ans2)
        Me.Controls.Add(Me.pw)
        Me.Controls.Add(Me.eadd)
        Me.Controls.Add(Me.sq2)
        Me.Controls.Add(Me.cno)
        Me.Controls.Add(Me.ans1)
        Me.Controls.Add(Me.bd)
        Me.Controls.Add(Me.sq1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.en)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.ln)
        Me.Controls.Add(Me.fn)
        Me.Controls.Add(Me.add)
        Me.Controls.Add(Me.mn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "AdminCreate"
        Me.Text = "AdminCreate"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents rtp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ans2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pw As System.Windows.Forms.MaskedTextBox
    Friend WithEvents eadd As System.Windows.Forms.TextBox
    Friend WithEvents sq2 As System.Windows.Forms.ComboBox
    Friend WithEvents cno As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ans1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bd As System.Windows.Forms.DateTimePicker
    Friend WithEvents sq1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents en As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ln As System.Windows.Forms.TextBox
    Friend WithEvents fn As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents add As System.Windows.Forms.TextBox
    Friend WithEvents mn As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents statusTxtBoxAdmin As System.Windows.Forms.TextBox
    Friend WithEvents loginAttempt As System.Windows.Forms.TextBox
    Friend WithEvents pl As System.Windows.Forms.TextBox
End Class
