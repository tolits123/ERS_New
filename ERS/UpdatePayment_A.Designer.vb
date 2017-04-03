<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdatePayment_A
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
        Me.SearchAddpayemt_btn = New System.Windows.Forms.Button()
        Me.sn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Payment_grp = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mid_btn = New System.Windows.Forms.Button()
        Me.pre_btn = New System.Windows.Forms.Button()
        Me.midterm = New System.Windows.Forms.Label()
        Me.prelim = New System.Windows.Forms.Label()
        Me.miscellaneous_fee_grp = New System.Windows.Forms.GroupBox()
        Me.tf = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mf = New System.Windows.Forms.Label()
        Me.gf = New System.Windows.Forms.Label()
        Me.ef = New System.Windows.Forms.Label()
        Me.lf = New System.Windows.Forms.Label()
        Me.rf = New System.Windows.Forms.Label()
        Me.total = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Payment_grp.SuspendLayout()
        Me.miscellaneous_fee_grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchAddpayemt_btn
        '
        Me.SearchAddpayemt_btn.Location = New System.Drawing.Point(278, 6)
        Me.SearchAddpayemt_btn.Name = "SearchAddpayemt_btn"
        Me.SearchAddpayemt_btn.Size = New System.Drawing.Size(75, 23)
        Me.SearchAddpayemt_btn.TabIndex = 5
        Me.SearchAddpayemt_btn.Text = "Search"
        Me.SearchAddpayemt_btn.UseVisualStyleBackColor = True
        '
        'sn
        '
        Me.sn.Location = New System.Drawing.Point(142, 6)
        Me.sn.Name = "sn"
        Me.sn.Size = New System.Drawing.Size(130, 20)
        Me.sn.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search Student Number:"
        '
        'Payment_grp
        '
        Me.Payment_grp.Controls.Add(Me.Label10)
        Me.Payment_grp.Controls.Add(Me.Label8)
        Me.Payment_grp.Controls.Add(Me.mid_btn)
        Me.Payment_grp.Controls.Add(Me.pre_btn)
        Me.Payment_grp.Controls.Add(Me.midterm)
        Me.Payment_grp.Controls.Add(Me.prelim)
        Me.Payment_grp.Enabled = False
        Me.Payment_grp.Location = New System.Drawing.Point(353, 83)
        Me.Payment_grp.Name = "Payment_grp"
        Me.Payment_grp.Size = New System.Drawing.Size(233, 89)
        Me.Payment_grp.TabIndex = 7
        Me.Payment_grp.TabStop = False
        Me.Payment_grp.Text = "Partial Payment"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "SecondPayment:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "First Payment::"
        '
        'mid_btn
        '
        Me.mid_btn.Location = New System.Drawing.Point(152, 47)
        Me.mid_btn.Name = "mid_btn"
        Me.mid_btn.Size = New System.Drawing.Size(49, 23)
        Me.mid_btn.TabIndex = 2
        Me.mid_btn.Text = "Pay"
        Me.mid_btn.UseVisualStyleBackColor = True
        Me.mid_btn.Visible = False
        '
        'pre_btn
        '
        Me.pre_btn.Location = New System.Drawing.Point(152, 20)
        Me.pre_btn.Name = "pre_btn"
        Me.pre_btn.Size = New System.Drawing.Size(49, 23)
        Me.pre_btn.TabIndex = 2
        Me.pre_btn.Text = "Pay"
        Me.pre_btn.UseVisualStyleBackColor = True
        Me.pre_btn.Visible = False
        '
        'midterm
        '
        Me.midterm.AutoSize = True
        Me.midterm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.midterm.Location = New System.Drawing.Point(115, 52)
        Me.midterm.Name = "midterm"
        Me.midterm.Size = New System.Drawing.Size(14, 18)
        Me.midterm.TabIndex = 1
        Me.midterm.Text = "-"
        '
        'prelim
        '
        Me.prelim.AutoSize = True
        Me.prelim.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prelim.Location = New System.Drawing.Point(115, 25)
        Me.prelim.Name = "prelim"
        Me.prelim.Size = New System.Drawing.Size(19, 18)
        Me.prelim.TabIndex = 1
        Me.prelim.Text = "- "
        '
        'miscellaneous_fee_grp
        '
        Me.miscellaneous_fee_grp.Controls.Add(Me.tf)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label9)
        Me.miscellaneous_fee_grp.Controls.Add(Me.mf)
        Me.miscellaneous_fee_grp.Controls.Add(Me.gf)
        Me.miscellaneous_fee_grp.Controls.Add(Me.ef)
        Me.miscellaneous_fee_grp.Controls.Add(Me.lf)
        Me.miscellaneous_fee_grp.Controls.Add(Me.rf)
        Me.miscellaneous_fee_grp.Controls.Add(Me.total)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label7)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label6)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label5)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label4)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label3)
        Me.miscellaneous_fee_grp.Controls.Add(Me.Label2)
        Me.miscellaneous_fee_grp.Location = New System.Drawing.Point(45, 45)
        Me.miscellaneous_fee_grp.Name = "miscellaneous_fee_grp"
        Me.miscellaneous_fee_grp.Size = New System.Drawing.Size(286, 212)
        Me.miscellaneous_fee_grp.TabIndex = 6
        Me.miscellaneous_fee_grp.TabStop = False
        Me.miscellaneous_fee_grp.Text = "Miscellaneous Fee:"
        '
        'tf
        '
        Me.tf.AutoSize = True
        Me.tf.Location = New System.Drawing.Point(167, 156)
        Me.tf.Name = "tf"
        Me.tf.Size = New System.Drawing.Size(25, 13)
        Me.tf.TabIndex = 3
        Me.tf.Text = "800"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Tuition Fee:"
        '
        'mf
        '
        Me.mf.AutoSize = True
        Me.mf.Location = New System.Drawing.Point(167, 132)
        Me.mf.Name = "mf"
        Me.mf.Size = New System.Drawing.Size(25, 13)
        Me.mf.TabIndex = 1
        Me.mf.Text = "500"
        '
        'gf
        '
        Me.gf.AutoSize = True
        Me.gf.Location = New System.Drawing.Point(167, 105)
        Me.gf.Name = "gf"
        Me.gf.Size = New System.Drawing.Size(25, 13)
        Me.gf.TabIndex = 1
        Me.gf.Text = "200"
        '
        'ef
        '
        Me.ef.AutoSize = True
        Me.ef.Location = New System.Drawing.Point(167, 81)
        Me.ef.Name = "ef"
        Me.ef.Size = New System.Drawing.Size(25, 13)
        Me.ef.TabIndex = 1
        Me.ef.Text = "200"
        '
        'lf
        '
        Me.lf.AutoSize = True
        Me.lf.Location = New System.Drawing.Point(167, 55)
        Me.lf.Name = "lf"
        Me.lf.Size = New System.Drawing.Size(25, 13)
        Me.lf.TabIndex = 1
        Me.lf.Text = "200"
        '
        'rf
        '
        Me.rf.AutoSize = True
        Me.rf.Location = New System.Drawing.Point(167, 33)
        Me.rf.Name = "rf"
        Me.rf.Size = New System.Drawing.Size(25, 13)
        Me.rf.TabIndex = 1
        Me.rf.Text = "300"
        '
        'total
        '
        Me.total.AutoSize = True
        Me.total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total.Location = New System.Drawing.Point(167, 179)
        Me.total.Name = "total"
        Me.total.Size = New System.Drawing.Size(16, 16)
        Me.total.TabIndex = 0
        Me.total.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Total:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Medical Fee:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Guidance Fee:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Energy Fee:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Library Fee:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Registration Fee:"
        '
        'UpdatePayment_A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 302)
        Me.Controls.Add(Me.Payment_grp)
        Me.Controls.Add(Me.miscellaneous_fee_grp)
        Me.Controls.Add(Me.SearchAddpayemt_btn)
        Me.Controls.Add(Me.sn)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "UpdatePayment_A"
        Me.Text = "UpdatePayment_A"
        Me.Payment_grp.ResumeLayout(False)
        Me.Payment_grp.PerformLayout()
        Me.miscellaneous_fee_grp.ResumeLayout(False)
        Me.miscellaneous_fee_grp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SearchAddpayemt_btn As System.Windows.Forms.Button
    Friend WithEvents sn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Payment_grp As System.Windows.Forms.GroupBox
    Friend WithEvents mid_btn As System.Windows.Forms.Button
    Friend WithEvents pre_btn As System.Windows.Forms.Button
    Friend WithEvents midterm As System.Windows.Forms.Label
    Friend WithEvents prelim As System.Windows.Forms.Label
    Friend WithEvents miscellaneous_fee_grp As System.Windows.Forms.GroupBox
    Friend WithEvents tf As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents mf As System.Windows.Forms.Label
    Friend WithEvents gf As System.Windows.Forms.Label
    Friend WithEvents ef As System.Windows.Forms.Label
    Friend WithEvents lf As System.Windows.Forms.Label
    Friend WithEvents rf As System.Windows.Forms.Label
    Friend WithEvents total As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
