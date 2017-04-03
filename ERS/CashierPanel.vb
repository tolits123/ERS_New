Imports MySql.Data.MySqlClient
Public Class CashierPanel
    Private Sub CashierPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connection As New MySqlConnection
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(1, 1)
        Me.Size = SystemInformation.PrimaryMonitorSize()
        Me.empl.Text = My.Forms.CashierLogin.en.Text
        Try ' :)
            connection.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';database='" & database & "'"
            Dim reg As String = "SELECT * FROM cashier_account WHERE (EmployeeID ='" & empl.Text & "')"
            connection.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, connection) 'haha :) try naten mag login as cashier
            r = cmd.ExecuteReader()
            If r.Read Then
                n1.Text = r("Surname").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                email.Text = r("Email_Account").ToString() & "."
                cn.Text = r("ContactNumber").ToString() & "."
                pl.Text = r("Photo").ToString()
                PictureBox3.Image = Image.FromFile(pl.Text)
                connection.Close()
            Else
                MsgBox("EmployeeID not Found!")
                connection.Close()
            End If
        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim a As Integer
        a = MsgBox("Are you sure do you want to logout?", MsgBoxStyle.YesNo)
        If (a = MsgBoxResult.Yes) Then
            My.Forms.MainScreen.AdminBtn.Visible = True
            My.Forms.MainScreen.CashierBtn.Visible = True
            My.Forms.MainScreen.RegistrarBtn.Visible = True
            My.Forms.MainScreen.AboutUsBtn.Visible = True
            My.Forms.MainScreen.Button5.Visible = True
            ViewStudentInfo.Close()
            RegistrarCreate.Close()
            CashierCreate.Close()
            AdminCreate.Close()
            StudentCreate.Close()
            LoginAdmin.Close()
            RegistrarLogin.Close()
            CashierLogin.Close()
            Me.Close()
        End If
    End Sub
End Class