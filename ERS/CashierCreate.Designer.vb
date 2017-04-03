<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashierCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashierCreate))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pl = New System.Windows.Forms.TextBox()
        Me.add = New System.Windows.Forms.TextBox()
        Me.mn = New System.Windows.Forms.TextBox()
        Me.fn = New System.Windows.Forms.TextBox()
        Me.ln = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.bd = New System.Windows.Forms.DateTimePicker()
        Me.cno = New System.Windows.Forms.MaskedTextBox()
        Me.eadd = New System.Windows.Forms.TextBox()
        Me.ans2 = New System.Windows.Forms.MaskedTextBox()
        Me.sq2 = New System.Windows.Forms.ComboBox()
        Me.ans1 = New System.Windows.Forms.MaskedTextBox()
        Me.sq1 = New System.Windows.Forms.ComboBox()
        Me.en = New System.Windows.Forms.MaskedTextBox()
        Me.rtp = New System.Windows.Forms.MaskedTextBox()
        Me.pw = New System.Windows.Forms.MaskedTextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.statusTextBoxCashier = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(645, 277)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 38)
        Me.Button1.TabIndex = 17
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(12, 77)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'pl
        '
        Me.pl.Enabled = False
        Me.pl.Location = New System.Drawing.Point(32, 115)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(83, 20)
        Me.pl.TabIndex = 8
        '
        'add
        '
        Me.add.Location = New System.Drawing.Point(261, 125)
        Me.add.Name = "add"
        Me.add.Size = New System.Drawing.Size(338, 20)
        Me.add.TabIndex = 4
        '
        'mn
        '
        Me.mn.Location = New System.Drawing.Point(614, 99)
        Me.mn.Name = "mn"
        Me.mn.Size = New System.Drawing.Size(216, 20)
        Me.mn.TabIndex = 3
        '
        'fn
        '
        Me.fn.Location = New System.Drawing.Point(382, 99)
        Me.fn.Name = "fn"
        Me.fn.Size = New System.Drawing.Size(205, 20)
        Me.fn.TabIndex = 2
        '
        'ln
        '
        Me.ln.Location = New System.Drawing.Point(145, 99)
        Me.ln.Name = "ln"
        Me.ln.Size = New System.Drawing.Size(206, 20)
        Me.ln.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(548, 292)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(842, 330)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Male", "Female"})
        Me.ComboBox1.Location = New System.Drawing.Point(696, 125)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(134, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'bd
        '
        Me.bd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bd.CustomFormat = "MM/dd/yyyy"
        Me.bd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.bd.Location = New System.Drawing.Point(240, 159)
        Me.bd.Name = "bd"
        Me.bd.Size = New System.Drawing.Size(260, 20)
        Me.bd.TabIndex = 6
        '
        'cno
        '
        Me.cno.Location = New System.Drawing.Point(623, 162)
        Me.cno.Name = "cno"
        Me.cno.Size = New System.Drawing.Size(207, 20)
        Me.cno.TabIndex = 7
        '
        'eadd
        '
        Me.eadd.Location = New System.Drawing.Point(256, 187)
        Me.eadd.Name = "eadd"
        Me.eadd.Size = New System.Drawing.Size(229, 20)
        Me.eadd.TabIndex = 8
        '
        'ans2
        '
        Me.ans2.Location = New System.Drawing.Point(180, 299)
        Me.ans2.Name = "ans2"
        Me.ans2.Size = New System.Drawing.Size(235, 20)
        Me.ans2.TabIndex = 15
        '
        'sq2
        '
        Me.sq2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sq2.FormattingEnabled = True
        Me.sq2.Items.AddRange(New Object() {"sq2"})
        Me.sq2.Location = New System.Drawing.Point(180, 272)
        Me.sq2.Name = "sq2"
        Me.sq2.Size = New System.Drawing.Size(251, 21)
        Me.sq2.TabIndex = 14
        '
        'ans1
        '
        Me.ans1.Location = New System.Drawing.Point(180, 240)
        Me.ans1.Name = "ans1"
        Me.ans1.Size = New System.Drawing.Size(235, 20)
        Me.ans1.TabIndex = 12
        '
        'sq1
        '
        Me.sq1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sq1.FormattingEnabled = True
        Me.sq1.Items.AddRange(New Object() {"sq1"})
        Me.sq1.Location = New System.Drawing.Point(180, 213)
        Me.sq1.Name = "sq1"
        Me.sq1.Size = New System.Drawing.Size(251, 21)
        Me.sq1.TabIndex = 10
        '
        'en
        '
        Me.en.Location = New System.Drawing.Point(623, 188)
        Me.en.Name = "en"
        Me.en.Size = New System.Drawing.Size(207, 20)
        Me.en.TabIndex = 9
        '
        'rtp
        '
        Me.rtp.Location = New System.Drawing.Point(603, 252)
        Me.rtp.Name = "rtp"
        Me.rtp.Size = New System.Drawing.Size(227, 20)
        Me.rtp.TabIndex = 13
        '
        'pw
        '
        Me.pw.Location = New System.Drawing.Point(602, 215)
        Me.pw.Name = "pw"
        Me.pw.Size = New System.Drawing.Size(228, 20)
        Me.pw.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(4, 162)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(135, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "UploadPhoto"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(4, 184)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(135, 23)
        Me.Button4.TabIndex = 27
        Me.Button4.Text = "TakePhoto"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'statusTextBoxCashier
        '
        Me.statusTextBoxCashier.Location = New System.Drawing.Point(459, 299)
        Me.statusTextBoxCashier.Name = "statusTextBoxCashier"
        Me.statusTextBoxCashier.ShortcutsEnabled = False
        Me.statusTextBoxCashier.Size = New System.Drawing.Size(41, 20)
        Me.statusTextBoxCashier.TabIndex = 28
        Me.statusTextBoxCashier.Text = "active"
        Me.statusTextBoxCashier.Visible = False
        '
        'CashierCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 330)
        Me.Controls.Add(Me.statusTextBoxCashier)
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
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.en)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ln)
        Me.Controls.Add(Me.fn)
        Me.Controls.Add(Me.add)
        Me.Controls.Add(Me.mn)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "CashierCreate"
        Me.Text = "CashierCreate"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pl As System.Windows.Forms.TextBox
    Friend WithEvents add As System.Windows.Forms.TextBox
    Friend WithEvents mn As System.Windows.Forms.TextBox
    Friend WithEvents fn As System.Windows.Forms.TextBox
    Friend WithEvents ln As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents bd As System.Windows.Forms.DateTimePicker
    Friend WithEvents cno As System.Windows.Forms.MaskedTextBox
    Friend WithEvents eadd As System.Windows.Forms.TextBox
    Friend WithEvents ans2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents sq2 As System.Windows.Forms.ComboBox
    Friend WithEvents ans1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents sq1 As System.Windows.Forms.ComboBox
    Friend WithEvents en As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rtp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pw As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents statusTextBoxCashier As System.Windows.Forms.TextBox
End Class
