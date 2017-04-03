<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSubject
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
        Me.gl = New System.Windows.Forms.ComboBox()
        Me.sec = New System.Windows.Forms.ComboBox()
        Me.sy = New System.Windows.Forms.MaskedTextBox()
        Me.tme = New System.Windows.Forms.TextBox()
        Me.nm = New System.Windows.Forms.MaskedTextBox()
        Me.subjname = New System.Windows.Forms.ComboBox()
        Me.teacher = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'gl
        '
        Me.gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.gl.FormattingEnabled = True
        Me.gl.Items.AddRange(New Object() {"GradeLevel"})
        Me.gl.Location = New System.Drawing.Point(131, 61)
        Me.gl.Name = "gl"
        Me.gl.Size = New System.Drawing.Size(121, 21)
        Me.gl.TabIndex = 1
        '
        'sec
        '
        Me.sec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sec.FormattingEnabled = True
        Me.sec.Items.AddRange(New Object() {"Sec"})
        Me.sec.Location = New System.Drawing.Point(131, 100)
        Me.sec.Name = "sec"
        Me.sec.Size = New System.Drawing.Size(121, 21)
        Me.sec.TabIndex = 2
        '
        'sy
        '
        Me.sy.Location = New System.Drawing.Point(131, 139)
        Me.sy.Name = "sy"
        Me.sy.Size = New System.Drawing.Size(121, 20)
        Me.sy.TabIndex = 3
        '
        'tme
        '
        Me.tme.Location = New System.Drawing.Point(131, 185)
        Me.tme.Name = "tme"
        Me.tme.Size = New System.Drawing.Size(121, 20)
        Me.tme.TabIndex = 4
        '
        'nm
        '
        Me.nm.Location = New System.Drawing.Point(131, 221)
        Me.nm.Name = "nm"
        Me.nm.Size = New System.Drawing.Size(121, 20)
        Me.nm.TabIndex = 5
        '
        'subjname
        '
        Me.subjname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subjname.FormattingEnabled = True
        Me.subjname.Items.AddRange(New Object() {"Subj"})
        Me.subjname.Location = New System.Drawing.Point(131, 260)
        Me.subjname.Name = "subjname"
        Me.subjname.Size = New System.Drawing.Size(121, 21)
        Me.subjname.TabIndex = 6
        '
        'teacher
        '
        Me.teacher.Location = New System.Drawing.Point(131, 301)
        Me.teacher.Name = "teacher"
        Me.teacher.Size = New System.Drawing.Size(121, 20)
        Me.teacher.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(60, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Add Subject"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "GradeLevel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Section"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "SchoolYear"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Number of Minutes:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "SubjectName:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Teacher's Name"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(205, 352)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 31)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AddSubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.teacher)
        Me.Controls.Add(Me.subjname)
        Me.Controls.Add(Me.nm)
        Me.Controls.Add(Me.tme)
        Me.Controls.Add(Me.sy)
        Me.Controls.Add(Me.sec)
        Me.Controls.Add(Me.gl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "AddSubject"
        Me.Text = "AddSubject"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gl As System.Windows.Forms.ComboBox
    Friend WithEvents sec As System.Windows.Forms.ComboBox
    Friend WithEvents sy As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tme As System.Windows.Forms.TextBox
    Friend WithEvents nm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents subjname As System.Windows.Forms.ComboBox
    Friend WithEvents teacher As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
