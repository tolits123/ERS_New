Imports MySql.Data.MySqlClient
Module Payment
    Public Sub SearchAddPayment_A()
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.AddPayment_A.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.AddPayment_A.grade.Text = r("GradeLevel").ToString()
                My.Forms.AddPayment_A.nameOS.Text = r("Lastname").ToString() & ", " & r("GivenName").ToString() & " " & r("Middlename").ToString()

                My.Forms.AddPayment_A.miscellaneous_fee_grp.Enabled = True
                My.Forms.AddPayment_A.Payment_grp.Enabled = True
            Else
                MsgBox("Student Number not Found!")
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub

    Public Sub SearchAddPayment1_A()
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM payment_tbl WHERE (Student_ID_No ='" & My.Forms.AddPayment_A.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                MsgBox("Already added")
            Else
                MsgBox("Not yet added")
                My.Forms.AddPayment_A.Proceed_btn.Enabled = True
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub

    Public Sub FullPayment_A()
        Try
            Dim objConn As New MySqlConnection
            Dim ins As New MySqlCommand
            Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            objConn.ConnectionString = cn
            objConn.Open()
            ins.Connection = objConn
            ins.CommandText = "INSERT INTO payment_tbl VALUES(@Student_ID_No,@Prelim , @Midterm, @Final)"
            ins.Parameters.AddWithValue("@Student_ID_No", My.Forms.AddPayment_A.sn.Text)
            ins.Parameters.AddWithValue("@Prelim", 0)
            ins.Parameters.AddWithValue("@Midterm", 0)
            ins.Parameters.AddWithValue("@Final", 0)
            ins.ExecuteNonQuery()
            MsgBox("Payment Added!")
            objConn.Close()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Public Sub PartialPayment_A()
        Try
            Dim objConn As New MySqlConnection
            Dim ins As New MySqlCommand
            Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            objConn.ConnectionString = cn
            objConn.Open()
            ins.Connection = objConn
            ins.CommandText = "INSERT INTO payment_tbl VALUES(@Student_ID_No,@FirstPayment , @SecondPayment)"
            ins.Parameters.AddWithValue("@Student_ID_No", My.Forms.AddPayment_A.sn.Text)
            ins.Parameters.AddWithValue("@FirstPayment", My.Forms.AddPayment_A.prelim.Text)
            ins.Parameters.AddWithValue("@SecondPayment", My.Forms.AddPayment_A.midterm.Text)
            ins.ExecuteNonQuery()
            MsgBox("Payment Added!")
            objConn.Close()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Public Sub SearchUpdatePayment_A()
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
     
            Try
                'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                Dim r As MySqlDataReader
                Dim reg As String = "SELECT * FROM payment_tbl WHERE (Student_ID_No ='" & My.Forms.UpdatePayment_A.sn.Text & "')"
                conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
                Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
                r = cmd.ExecuteReader()
                If r.Read Then
                My.Forms.UpdatePayment_A.prelim.Text = r("FirstPayment").ToString()
                My.Forms.UpdatePayment_A.midterm.Text = r("SecondPayment").ToString()
                    My.Forms.UpdatePayment_A.pre_btn.Visible = True
                    My.Forms.UpdatePayment_A.Payment_grp.Enabled = True
                    If My.Forms.UpdatePayment_A.prelim.Text = "0" Then
                        My.Forms.UpdatePayment_A.pre_btn.Visible = False
                        My.Forms.UpdatePayment_A.mid_btn.Visible = True
                    End If
                    If My.Forms.UpdatePayment_A.midterm.Text = "0" Then
                        My.Forms.UpdatePayment_A.pre_btn.Visible = False
                        My.Forms.UpdatePayment_A.mid_btn.Visible = False
                    End If
                Else
                    MsgBox("Student Number not Found!")
                    conn.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
            End Try
        conn.Close()
    End Sub
    Public Sub prelimPay_btn()
        Try
       
            Dim reg As String = "UPDATE payment_tbl SET FirstPayment = 0"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn1)
                    cn1.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Prelim Paid!")
                    My.Forms.UpdatePayment_A.pre_btn.Text = "Paid!"
                    cn1.Close()
                End Using
                cn1.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub midtermPay_btn()
        Try

            Dim reg As String = "UPDATE payment_tbl SET SecondPayment = 0"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn1)
                    cn1.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Midterm Paid!")
                    My.Forms.UpdatePayment_A.mid_btn.Text = "Paid!"

                    cn1.Close()
                End Using
                cn1.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchDeletePayment_A()
        Dim conn As New MySqlConnection ' <---


        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM payment_tbl WHERE (Student_ID_No ='" & My.Forms.DeletePayment.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.DeletePayment.prelim.Text = r("FirstPayment").ToString()
                My.Forms.DeletePayment.midterm.Text = r("SecondPayment").ToString()
                My.Forms.DeletePayment.sn.Enabled = False
                My.Forms.DeletePayment.SearchAddpayemt_btn.Enabled = False
                My.Forms.DeletePayment.DeletePayment_btn.Enabled = True
            Else
                MsgBox("Student Number not Found!")
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    Public Sub deletePayment_btn_a()
        '   For Each FRM As Form In Application.OpenForms
        Try
            '  Dim deleteAccountUser As String = "My.Forms." & FRM.Name.ToString & ".en.Text"
            '  Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Dim reg1 As String = "DELETE FROM payment_tbl WHERE Student_ID_No = '" & My.Forms.DeletePayment.sn.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd1 = New MySqlCommand(reg1, cn1)
                    cn1.Open()
                    sqlCmd1.ExecuteNonQuery()
                    MsgBox("Payment record Deleted!")
                    My.Forms.DeletePayment.DeletePayment_btn.Enabled = False
                    My.Forms.DeletePayment.sn.Enabled = True
                    My.Forms.DeletePayment.sn.Text = ""
                    My.Forms.DeletePayment.SearchAddpayemt_btn.Enabled = True
                    cn1.Close()
                End Using
                cn1.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn1.Close()
        End Try
        '  Next
    End Sub
End Module
