Imports MySql.Data.MySqlClient

Public Class ViewStudentInfo

    Dim cn1 As New MySqlConnection

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        add.Enabled = True
        gl.Enabled = True
        con.Enabled = True
        sy.Enabled = True
        bd.Enabled = True
        ag.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = False
    End Sub
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    'eto yung method para i load yung student info. dito may error.
    Private Sub ViewStudentInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                sn.Text = r("Student_ID_No").ToString()
                nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                add.Text = r("Address").ToString()
                bd.Text = r("Birthday").ToString()
                gl.Text = r("GradeLevel").ToString()
                con.Text = r("Contact").ToString()
                sy.Text = r("SchoolYear").ToString()
                pl.Text = r("Photo").ToString()
                ag.Text = r("Age").ToString()
                pl.Text = r("Photo").ToString()
                PictureBox2.Image = Image.FromFile(pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                ' en.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (CheckBox1.Checked = True) Then
            dropstud()
        ElseIf (CheckBox1.Checked = False) Then
            editstud()
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If (CheckBox1.Checked = True) Then
            Button2.Enabled = True
        ElseIf (CheckBox1.Checked = False) Then
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        AdminPanel.Show()
        Me.Close()

    End Sub
End Class