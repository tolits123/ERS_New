Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Module Module1
    Public cn1 As New MySqlConnection
    Public cn As New MySqlConnection
    Public r As MySqlDataReader
    Public ins As New MySqlCommand
    Public objConn As New MySqlConnection
    Public server As String = "127.0.0.1" 'papalitan to ng ip address ng server pag need na siya i connect sa LAN
    Public port As String = "3306" 'gagawing 3306 to pag need na i connect sa LAN, or kung anong port yung na set natin
    Public user As String = "ers_admin" 'for now, root yung user, pero, magdadagdag tayo ng new username pag LAN
    Public password As String = "12345" 'no password si root dun sa wamp natin, so leave it empty
    Public database As String = "ers" ' eto yung name ng database natin, ers.
    Public Sub splash()
        'connection string na ginagamit ng system natin para mag connect sa database
        cn.ConnectionString = "server= '" & server & "';port= '" & port & "';userid= '" & user & "';password= '" & password & "';database='" & database & "'"
        cn.Open()

        'change
        'Splash screen if database is null
        Dim stm As String = "SELECT * FROM admin WHERE EmployeeID IS NOT NULL"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, cn)
        Dim r As MySqlDataReader
        r = cmd.ExecuteReader()
        'pag may laman si admin table sa database natin, show yung MainScreen para makapag login
        If r.Read Then
            MainScreen.Show()
            My.Forms.SplashScreen1.Close()
            cn.Close()
            'else, show yung AdminCreate para magcreate ng Admin Account.
        Else
            My.Forms.AdminCreate.Button5.Visible = False 'hina hide nito yung cancel button'
            AdminCreate.Show()
            My.Forms.SplashScreen1.Close()
            cn.Close()
        End If
    End Sub
    Public Sub registrarPanelDisplay()
        'Registrar panel. To display Picture of Admin, Name, ContactNumber, etc.
        cn.Close()
        insert() 'okay andito nanaman tong insert() na to, para san nga ulit to guys? remember! hehe

        'meron tayong SQL Query, SELECT * FROM registrar_account <-- eto kasi yung method pag successfully na nakapag login si registrar
        'ididisplay niya yung information nung registrar na nag login, so select all from registrar_account(table) where is yung EmployeeID
        'is equals dun sa employee id na nasa text.
        Dim reg As String = "SELECT * FROM registrar_account WHERE (EmployeeID ='" & My.Forms.RegistrarPanel.empl.Text & "')"
        cn1.Open() 'open database connection ulit para maka connect tayo sa databae.

        Dim cmd As MySqlCommand = New MySqlCommand(reg, cn1)
        r = cmd.ExecuteReader() 'execute sql query
        'alam na natin kung ano ibig sabihin ng r.Read diba guys? ibig sabihin, meron nun sa database. so,
        'ididisplay niya kung ano yung nakita niya sa database na under nung employee id
        If r.Read Then
            My.Forms.RegistrarPanel.n1.Text = r("Surname").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
            My.Forms.RegistrarPanel.email.Text = r("Email_Account").ToString() & "."
            My.Forms.RegistrarPanel.cn.Text = r("ContactNumber").ToString() & "."
            My.Forms.RegistrarPanel.pl.Text = r("Photo").ToString()
            My.Forms.RegistrarPanel.PictureBox3.Image = Image.FromFile(My.Forms.RegistrarPanel.pl.Text)
            cn1.Close() 'remember na laging icclose yung database connection. parang sa pag ibig, dapat laging may closure kayo ng x mo. hahaha
        Else
            MsgBox("Employee number not Found!")
            cn1.Close()
        End If
    End Sub
    Public Sub createAdmin()

        'reSurname as Regex, nire require si user na alpha number yung itype sa password para
        'atleast strong yung password (kaya ka ipaglaban) haha.
        Dim reSurname As New Regex("^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-]).*$")

        If Not reSurname.IsMatch(My.Forms.AdminCreate.pw.Text) Then
            MsgBox("AlphaNumericSymbol needed to Password!")
            My.Forms.AdminCreate.pw.Clear()

        ElseIf (My.Forms.AdminCreate.pl.Text = "" Or My.Forms.AdminCreate.ln.Text = "" Or My.Forms.AdminCreate.fn.Text = "" Or My.Forms.AdminCreate.mn.Text = "" Or My.Forms.AdminCreate.bd.Text = "" Or My.Forms.AdminCreate.add.Text = "" Or My.Forms.AdminCreate.eadd.Text = "" Or My.Forms.AdminCreate.cno.Text = "" Or My.Forms.AdminCreate.sq1.SelectedItem = "" Or My.Forms.AdminCreate.sq2.SelectedItem = "" Or My.Forms.AdminCreate.ans1.Text = "" Or My.Forms.AdminCreate.ans2.Text = "" Or My.Forms.AdminCreate.en.Text = "" Or My.Forms.AdminCreate.pw.Text = "" Or My.Forms.AdminCreate.rtp.Text = "") Then
            MsgBox("Fill the empty box")
        Else
            'if no errors, save sa tables, which is sa accounts table(dito naka store lahat ng usernames ni admin, cashier, and registrar)'
            'and sa admin table (kasi gumagawa tayo ng admin account)
            If (My.Forms.AdminCreate.rtp.Text = My.Forms.AdminCreate.pw.Text) Then

                'bakit 2 yung connection string natin? yung isa, gagamitin for admin table, yung isa, para kay accounts table
                'remember, every time na magccreate tayo ng user account, automatic na nagse save siya kay accounts table.
                'why? to avoid repetitions. best practice na unique ang bawat username ni admin, cashier, and registrar.

                'eto yung ginamit na connection string for admin table
                Dim objConn As New MySqlConnection
                Dim ins As New MySqlCommand
                Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn.ConnectionString = cn
                objConn.Open()

                'eto yung ginamit na connection string for accounts table
                Dim objConn1 As New MySqlConnection
                Dim ins1 As New MySqlCommand
                Dim cn1 = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn1.ConnectionString = cn1
                objConn1.Open()


                Try
                    ins1.Connection = objConn1

                    'first Try, iiinsert kay accounts yung value nung employee id text box.
                    'pag hindi pa existing, mai insert siya, else, error. (check yung pinaka huling Catch)
                    ins1.CommandText = "INSERT INTO accounts VALUES(@EmployeeID)"
                    ins1.Parameters.AddWithValue("@EmployeeID", My.Forms.AdminCreate.en.Text) 'mispelled variable lol si tolits. haha
                    ins1.ExecuteNonQuery() 'need din nito dito para pumasok sa accounts table si admin
                    Try
                        'second try, iiinsert kay admin tables yung value nung employee id text box.
                        ins.Connection = objConn

                        'admin create (insert to database)
                        ins.CommandText = "INSERT INTO admin VALUES(@Photo, @Surname, @GivenName, @MiddleName, @Birthday, @Address, @Email_Account, @ContactNumber, @Security_Question1, @Answer1, @Security_Question2, @Answer2, @EmployeeID, @Password, @status, @LogIn_Attempts)"
                        ins.Parameters.AddWithValue("@Photo", My.Forms.AdminCreate.pl.Text)
                        ins.Parameters.AddWithValue("@Surname", My.Forms.AdminCreate.ln.Text)
                        ins.Parameters.AddWithValue("@GivenName", My.Forms.AdminCreate.fn.Text)
                        ins.Parameters.AddWithValue("@MiddleName", My.Forms.AdminCreate.mn.Text)
                        ins.Parameters.AddWithValue("@Birthday", My.Forms.AdminCreate.bd.Value.ToString)
                        ins.Parameters.AddWithValue("@Address", My.Forms.AdminCreate.add.Text)
                        ins.Parameters.AddWithValue("@Email_Account", My.Forms.AdminCreate.eadd.Text)
                        ins.Parameters.AddWithValue("@ContactNumber", My.Forms.AdminCreate.cno.Text)
                        ins.Parameters.AddWithValue("@Security_Question1", My.Forms.AdminCreate.sq1.Text)
                        ins.Parameters.AddWithValue("@Answer1", My.Forms.AdminCreate.ans1.Text)
                        ins.Parameters.AddWithValue("@Security_Question2", My.Forms.AdminCreate.sq2.Text)
                        ins.Parameters.AddWithValue("@Answer2", My.Forms.AdminCreate.ans2.Text)
                        ins.Parameters.AddWithValue("@EmployeeID", My.Forms.AdminCreate.en.Text)
                        ins.Parameters.AddWithValue("@Password", My.Forms.AdminCreate.pw.Text)
                        ins.Parameters.AddWithValue("@status", My.Forms.AdminCreate.statusTxtBoxAdmin.Text)
                        ins.Parameters.AddWithValue("@LogIn_Attempts", My.Forms.AdminCreate.loginAttempt.Text)
                        ins.ExecuteNonQuery()
                        MsgBox("Admin Account Successfully Created!")
                        My.Forms.AdminCreate.ln.Focus()
                        MainScreen.Show()
                        My.Forms.AdminCreate.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch
                    'eto yung catch pag existing na yung username sa accounts table.
                    MessageBox.Show("Account already exists in the database")
                End Try
            Else
                MsgBox("Passwords did'nt match!")
                My.Forms.AdminCreate.pw.Text = ""
                My.Forms.AdminCreate.rtp.Text = ""
                My.Forms.AdminCreate.pw.Focus()
            End If
        End If
    End Sub

    Public Sub createAdmin_1()
        Dim reSurname As New Regex("^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-]).*$")

        If Not reSurname.IsMatch(My.Forms.AdminCreate_1.pw.Text) Then
            MsgBox("AlphaNumericSymbol needed to Password!")
            My.Forms.AdminCreate_1.pw.Clear()

        ElseIf (My.Forms.AdminCreate_1.pl.Text = "" Or My.Forms.AdminCreate_1.ln.Text = "" Or My.Forms.AdminCreate_1.fn.Text = "" Or My.Forms.AdminCreate_1.mn.Text = "" Or My.Forms.AdminCreate_1.bd.Text = "" Or My.Forms.AdminCreate_1.add.Text = "" Or My.Forms.AdminCreate_1.eadd.Text = "" Or My.Forms.AdminCreate_1.cno.Text = "" Or My.Forms.AdminCreate_1.sq1.SelectedItem = "" Or My.Forms.AdminCreate_1.sq2.SelectedItem = "" Or My.Forms.AdminCreate_1.ans1.Text = "" Or My.Forms.AdminCreate_1.ans2.Text = "" Or My.Forms.AdminCreate_1.en.Text = "" Or My.Forms.AdminCreate_1.pw.Text = "" Or My.Forms.AdminCreate_1.rtp.Text = "") Then
            MsgBox("Fill the empty box")
        Else
            'if no errors, save sa tables, which is sa accounts table(dito naka store lahat ng usernames ni admin, cashier, and registrar)'
            'and sa admin table (kasi gumagawa tayo ng admin account)
            If (My.Forms.AdminCreate_1.rtp.Text = My.Forms.AdminCreate_1.pw.Text) Then

                'bakit 2 yung connection string natin? yung isa, gagamitin for admin table, yung isa, para kay accounts table
                'remember, every time na magccreate tayo ng user account, automatic na nagse save siya kay accounts table.
                'why? to avoid repetitions. best practice na unique ang bawat username ni admin, cashier, and registrar.

                'eto yung ginamit na connection string for admin table
                Dim objConn As New MySqlConnection
                Dim ins As New MySqlCommand
                Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn.ConnectionString = cn
                objConn.Open()

                'eto yung ginamit na connection string for accounts table
                Dim objConn1 As New MySqlConnection
                Dim ins1 As New MySqlCommand
                Dim cn1 = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn1.ConnectionString = cn1
                objConn1.Open()


                Try
                    ins1.Connection = objConn1

                    'first Try, iiinsert kay accounts yung value nung employee id text box.
                    'pag hindi pa existing, mai insert siya, else, error. (check yung pinaka huling Catch)
                    ins1.CommandText = "INSERT INTO accounts VALUES(@EmployeeID)"
                    ins1.Parameters.AddWithValue("@EmployeeID", My.Forms.AdminCreate_1.en.Text) 'mispelled variable lol si tolits. haha
                    ins1.ExecuteNonQuery() 'need din nito dito para pumasok sa accounts table si admin
                    Try
                        'second try, iiinsert kay admin tables yung value nung employee id text box.
                        ins.Connection = objConn

                        'admin create (insert to database)
                        ins.CommandText = "INSERT INTO admin VALUES(@Photo, @Surname, @GivenName, @MiddleName, @Birthday, @Address, @Email_Account, @ContactNumber, @Security_Question1, @Answer1, @Security_Question2, @Answer2, @EmployeeID, @Password, @status, @LogIn_Attempts)"
                        ins.Parameters.AddWithValue("@Photo", My.Forms.AdminCreate_1.pl.Text)
                        ins.Parameters.AddWithValue("@Surname", My.Forms.AdminCreate_1.ln.Text)
                        ins.Parameters.AddWithValue("@GivenName", My.Forms.AdminCreate_1.fn.Text)
                        ins.Parameters.AddWithValue("@MiddleName", My.Forms.AdminCreate_1.mn.Text)
                        ins.Parameters.AddWithValue("@Birthday", My.Forms.AdminCreate_1.bd.Value.ToString)
                        ins.Parameters.AddWithValue("@Address", My.Forms.AdminCreate_1.add.Text)
                        ins.Parameters.AddWithValue("@Email_Account", My.Forms.AdminCreate_1.eadd.Text)
                        ins.Parameters.AddWithValue("@ContactNumber", My.Forms.AdminCreate_1.cno.Text)
                        ins.Parameters.AddWithValue("@Security_Question1", My.Forms.AdminCreate_1.sq1.Text)
                        ins.Parameters.AddWithValue("@Answer1", My.Forms.AdminCreate_1.ans1.Text)
                        ins.Parameters.AddWithValue("@Security_Question2", My.Forms.AdminCreate_1.sq2.Text)
                        ins.Parameters.AddWithValue("@Answer2", My.Forms.AdminCreate_1.ans2.Text)
                        ins.Parameters.AddWithValue("@EmployeeID", My.Forms.AdminCreate_1.en.Text)
                        ins.Parameters.AddWithValue("@Password", My.Forms.AdminCreate_1.pw.Text)
                        ins.Parameters.AddWithValue("@status", My.Forms.AdminCreate_1.statusTxtBoxAdmin1.Text)
                        ins.Parameters.AddWithValue("@LogIn_Attempts", My.Forms.AdminCreate_1.loginAttempt.Text)
                        ins.ExecuteNonQuery()
                        MsgBox("Admin Account Successfully Created!")
                        My.Forms.AdminCreate_1.ln.Focus()
                        My.Forms.AdminPanel.Show()
                        My.Forms.AdminCreate_1.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch
                    'eto yung catch pag existing na yung username sa accounts table.
                    MessageBox.Show("Account already exists in the database!")
                End Try
            Else
                MsgBox("Passwords did'nt match!")
                My.Forms.AdminCreate_1.pw.Text = ""
                My.Forms.AdminCreate_1.rtp.Text = ""
                My.Forms.AdminCreate_1.pw.Focus()
            End If
        End If
    End Sub
    Public Sub registrarCreate1()
        'reSurname as Regex, same lang din sa explanation nung sa create ng admin,
        'ang use ni regex is para kaya kang ipaglaban ng password mo sa mga 'hackers'. haha 

        'actually, same lang din ito nung sa create admin account guys. same code lang,
        'ang nababago lang dito is yung sql queries
        'dun sa admin create, INSERT INTO admin, dito naman, since registrar ginagawa natin,
        'check niyo yung sql query, INSERT INTO registrar_account lang yung nagbago. yun lang naman yung nagbabago dito,
        'saka minsan yung feelings niya para sayo. hahaha!
        Dim reSurname As New Regex("^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-]).*$")
        If Not reSurname.IsMatch(My.Forms.RegistrarCreate.pw.Text) Then
            MsgBox("AlphaNumericSymbol needed to Password!")
            My.Forms.RegistrarCreate.pw.Clear()

        ElseIf (My.Forms.RegistrarCreate.pl.Text = "" Or My.Forms.RegistrarCreate.ln.Text = "" Or My.Forms.RegistrarCreate.fn.Text = "" Or My.Forms.RegistrarCreate.mn.Text = "" Or My.Forms.RegistrarCreate.bd.Text = "" Or My.Forms.RegistrarCreate.add.Text = "" Or My.Forms.RegistrarCreate.eadd.Text = "" Or My.Forms.RegistrarCreate.cno.Text = "" Or My.Forms.RegistrarCreate.sq1.SelectedItem = "" Or My.Forms.RegistrarCreate.sq2.SelectedItem = "" Or My.Forms.RegistrarCreate.ans1.Text = "" Or My.Forms.RegistrarCreate.ans2.Text = "" Or My.Forms.RegistrarCreate.en.Text = "" Or My.Forms.RegistrarCreate.pw.Text = "" Or My.Forms.RegistrarCreate.rtp.Text = "") Then
            MsgBox("Fill the empty box")
        Else
            If (My.Forms.RegistrarCreate.rtp.Text = My.Forms.RegistrarCreate.pw.Text) Then

                'alam na natin kung bakit dalawa yung connection string natin ha?
                'yung isang connection string, para sa accounts, yung isa para sa kung san natin ise save.
                'ang iccheck niyo lagi is yung ins or ins1 para malaman niyo kung para san yung object connection.

                Dim objConn As New MySqlConnection
                Dim ins As New MySqlCommand 'eto yung ins
                Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn.ConnectionString = cn
                objConn.Open()

                Dim objConn1 As New MySqlConnection
                Dim ins1 As New MySqlCommand 'eto yung ins1database
                Dim cn1 = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
                objConn1.ConnectionString = cn1
                objConn1.Open()
                Try
                    ins1.Connection = objConn1

                    'accounts table to avoid repeatition of EmployeeID
                    ins1.CommandText = "INSERT INTO accounts VALUES(@EmployeeID)" 'ins1 yung ginamit dito, so si ins1 ay para sa pag insert ng username sa accounts table
                    ins1.Parameters.AddWithValue("@EmployeeID", My.Forms.RegistrarCreate.en.Text)
                    ins1.ExecuteNonQuery()
                    Try
                        ins.Connection = objConn 'ins lang yung ginamit dito, so ginamit siya para sa pag save sa registrar. check niyo yung sa admin saka sa cashier.

                        'registrar create (insert to database)
                        ins.CommandText = "INSERT INTO registrar_account VALUES(@Photo, @Surname, @GivenName, @MiddleName, @Birthday, @Address, @Email_Account, @ContactNumber, @Security_Question1, @Answer1, @Security_Question2, @Answer2, @EmployeeID, @Password, @status)"
                        ins.Parameters.AddWithValue("@Photo", My.Forms.RegistrarCreate.pl.Text)
                        ins.Parameters.AddWithValue("@Surname", My.Forms.RegistrarCreate.ln.Text)
                        ins.Parameters.AddWithValue("@GivenName", My.Forms.RegistrarCreate.fn.Text)
                        ins.Parameters.AddWithValue("@MiddleName", My.Forms.RegistrarCreate.mn.Text)
                        ins.Parameters.AddWithValue("@Birthday", My.Forms.RegistrarCreate.bd.Value.ToString)
                        ins.Parameters.AddWithValue("@Address", My.Forms.RegistrarCreate.add.Text)
                        ins.Parameters.AddWithValue("@Email_Account", My.Forms.RegistrarCreate.eadd.Text)
                        ins.Parameters.AddWithValue("@ContactNumber", My.Forms.RegistrarCreate.cno.Text)
                        ins.Parameters.AddWithValue("@Security_Question1", My.Forms.RegistrarCreate.sq1.Text)
                        ins.Parameters.AddWithValue("@Answer1", My.Forms.RegistrarCreate.ans1.Text)
                        ins.Parameters.AddWithValue("@Security_Question2", My.Forms.RegistrarCreate.sq2.Text)
                        ins.Parameters.AddWithValue("@Answer2", My.Forms.RegistrarCreate.ans2.Text)
                        ins.Parameters.AddWithValue("@EmployeeID", My.Forms.RegistrarCreate.en.Text)
                        ins.Parameters.AddWithValue("@Password", My.Forms.RegistrarCreate.pw.Text)
                        ins.Parameters.AddWithValue("@status", My.Forms.RegistrarCreate.statusTextBoxRegistrar.Text)
                        ins.ExecuteNonQuery()
                        MsgBox("Registrar Account Successfully Created!")
                        My.Forms.RegistrarCreate.ln.Focus()
                        AdminPanel.Show()
                        My.Forms.RegistrarCreate.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch
                    'same lang din, eto yung catch para dun sa first try, which is error kung existing na yung username
                    'sa accounts table.
                    MessageBox.Show("Account already exists in the database!")
                End Try
            Else
                MsgBox("Passwords did'nt match!")
                My.Forms.RegistrarCreate.pw.Text = ""
                My.Forms.RegistrarCreate.rtp.Text = ""
                My.Forms.RegistrarCreate.pw.Focus()
            End If
        End If
    End Sub
    Public Sub createCashier()
        'create cashier. as usual, ganun pa din. same lang naman yung code.
        'ang pagkakaiba lang is, yung SQL Query.
        'INSERT INTO cashier_account naman dito. kasi cashier account yung ginagawa natin
        Dim reSurname As New Regex("^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-]).*$")
        If Not reSurname.IsMatch(My.Forms.CashierCreate.pw.Text) Then
            MsgBox("AlphaNumericSymbol needed to Password!")
            My.Forms.CashierCreate.pw.Clear()

        ElseIf (My.Forms.CashierCreate.pl.Text = "" Or My.Forms.CashierCreate.ln.Text = "" Or My.Forms.CashierCreate.fn.Text = "" Or My.Forms.CashierCreate.mn.Text = "" Or My.Forms.CashierCreate.bd.Text = "" Or My.Forms.CashierCreate.add.Text = "" Or My.Forms.CashierCreate.eadd.Text = "" Or My.Forms.CashierCreate.cno.Text = "" Or My.Forms.CashierCreate.sq1.SelectedItem = "" Or My.Forms.CashierCreate.sq2.SelectedItem = "" Or My.Forms.CashierCreate.ans1.Text = "" Or My.Forms.CashierCreate.ans2.Text = "" Or My.Forms.CashierCreate.en.Text = "" Or My.Forms.CashierCreate.pw.Text = "" Or My.Forms.CashierCreate.rtp.Text = "") Then
            MsgBox("Fill the empty box")
        Else
            If (My.Forms.CashierCreate.rtp.Text = My.Forms.CashierCreate.pw.Text) Then
                Dim objConn As New MySqlConnection
                Dim ins As New MySqlCommand
                Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"

                objConn.ConnectionString = cn
                objConn.Open()
                Dim objConn1 As New MySqlConnection
                Dim ins1 As New MySqlCommand
                Dim cn1 = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"

                objConn1.ConnectionString = cn1
                objConn1.Open()
                Try
                    ins1.Connection = objConn1

                    'accounts table to avoid repeatition of EmployeeID
                    ins1.CommandText = "INSERT INTO accounts VALUES(@EmployeeID)"
                    ins1.Parameters.AddWithValue("@EmployeeID", My.Forms.CashierCreate.en.Text)
                    ins1.ExecuteNonQuery()
                    Try
                        ins.Connection = objConn

                        'cashier_accounts create (insert to database)
                        ins.CommandText = "INSERT INTO cashier_account VALUES(@Photo, @Surname, @GivenName, @MiddleName, @Birthday, @Address, @Email_Account, @ContactNumber, @Security_Question1, @Answer1, @Security_Question2, @Answer2, @EmployeeID, @Password, @status)"
                        ins.Parameters.AddWithValue("@Photo", My.Forms.CashierCreate.pl.Text)
                        ins.Parameters.AddWithValue("@Surname", My.Forms.CashierCreate.ln.Text)
                        ins.Parameters.AddWithValue("@GivenName", My.Forms.CashierCreate.fn.Text)
                        ins.Parameters.AddWithValue("@MiddleName", My.Forms.CashierCreate.mn.Text)
                        ins.Parameters.AddWithValue("@Birthday", My.Forms.CashierCreate.bd.Value.ToString)
                        ins.Parameters.AddWithValue("@Address", My.Forms.CashierCreate.add.Text)
                        ins.Parameters.AddWithValue("@Email_Account", My.Forms.CashierCreate.eadd.Text)
                        ins.Parameters.AddWithValue("@ContactNumber", My.Forms.CashierCreate.cno.Text)
                        ins.Parameters.AddWithValue("@Security_Question1", My.Forms.CashierCreate.sq1.Text)
                        ins.Parameters.AddWithValue("@Answer1", My.Forms.CashierCreate.ans1.Text)
                        ins.Parameters.AddWithValue("@Security_Question2", My.Forms.CashierCreate.sq2.Text)
                        ins.Parameters.AddWithValue("@Answer2", My.Forms.CashierCreate.ans2.Text)
                        ins.Parameters.AddWithValue("@EmployeeID", My.Forms.CashierCreate.en.Text)
                        ins.Parameters.AddWithValue("@Password", My.Forms.CashierCreate.pw.Text)
                        ins.Parameters.AddWithValue("@status", My.Forms.CashierCreate.statusTextBoxCashier.Text)
                        ins.ExecuteNonQuery()
                        MsgBox("Cashier Account Successfuly Created!")
                        My.Forms.CashierCreate.ln.Focus()
                        AdminPanel.Show()
                        My.Forms.CashierCreate.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch
                    MessageBox.Show("Account already exists in the database!")
                End Try
            Else
                MsgBox("Passwords did'nt match!")
                My.Forms.CashierCreate.pw.Text = ""
                My.Forms.CashierCreate.rtp.Text = ""
                My.Forms.CashierCreate.pw.Focus()
            End If
        End If
    End Sub
    Public Sub qwe()
        'Adding Subjects (insert to database table "subject_tbl")
        Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
        objConn.ConnectionString = cn
        objConn.Open()
        Try
            If (My.Forms.AddSubject.gl.SelectedIndex = -1 Or My.Forms.AddSubject.sec.SelectedIndex = -1 Or My.Forms.AddSubject.sy.Text = "" Or My.Forms.AddSubject.tme.Text = "" Or My.Forms.AddSubject.nm.Text = "" Or My.Forms.AddSubject.subjname.SelectedIndex = -1 Or My.Forms.AddSubject.teacher.Text = "") Then
                MsgBox("Enter the empty fields!")
            Else
                'so dito, subjects yung sine save natin sa database, so yung SQL Query natin,
                'INSERT INTO subject_tbl, para lang din tayong gumagawa ng user account, pero nagbago yung variables natin.
                'pero same flow. gawa ng connection string, ioopen yung connection ni database,
                'then execute ng sql query para mag save sa database. easy lang diba? kayang kaya niyo to!
                ins.Connection = objConn
                ins.CommandText = "INSERT INTO subject_tbl VALUES( @GradeLevel, @Section, @SchoolYear, @Time, @No_Minutes, @Subject_Name, @Teacher)"
                ins.Parameters.AddWithValue("@GradeLevel", My.Forms.AddSubject.gl.SelectedItem.ToString)
                ins.Parameters.AddWithValue("@Section", My.Forms.AddSubject.sec.SelectedItem.ToString)
                ins.Parameters.AddWithValue("@SchoolYear", My.Forms.AddSubject.sy.Text)
                ins.Parameters.AddWithValue("@Time", My.Forms.AddSubject.tme.Text)
                ins.Parameters.AddWithValue("@No_Minutes", My.Forms.AddSubject.nm.Text)
                ins.Parameters.AddWithValue("@Subject_Name", My.Forms.AddSubject.subjname.SelectedItem)
                ins.Parameters.AddWithValue("@Teacher", My.Forms.AddSubject.teacher.Text)
                ins.ExecuteNonQuery()
                ins.Parameters.Clear()
                MsgBox("Subject saved successfully!")
                objConn.Close()
                Dim a As Integer
                a = MsgBox("Do you want to Add another subject?", MsgBoxStyle.YesNo)
                If (a = MsgBoxResult.Yes) Then
                    AddSubClear()
                ElseIf (a = MsgBoxResult.No) Then
                    StudentCreate.Show()
                    My.Forms.AddSubject.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        objConn.Close()
    End Sub
    Public Sub insert()
        'insert method to. tandaan lang natin na kapag may nakita tayong 'insert()' sa ibang method, eto yung tinatawag niya.
        'bakit kelangan nito? para hindi na natin paulit ulit na copy paste etong 2 lines of code sa lahat ng method.
        cn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
        cn1.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
    End Sub
    Public Sub AddSubClear()

        'so eto yung method para mag clear yung mga text boxes and stuff sa code natin.
        'para hindi mahirapan si user na mag clear pa isa isa, si system na natin yung nagcclear para kay user
        'every successful query. naka automate na kumbaga.

        'clearing fields per forms
        My.Forms.AddSubject.gl.SelectedIndex = -1
        My.Forms.AddSubject.sec.SelectedIndex = -1
        My.Forms.AddSubject.sy.Text = ""
        My.Forms.AddSubject.tme.Text = ""
        My.Forms.AddSubject.nm.Text = ""
        My.Forms.AddSubject.subjname.SelectedIndex = -1
        My.Forms.AddSubject.teacher.Text = ""

        My.Forms.AdminCreate.pl.Text = ""
        My.Forms.AdminCreate.ln.Text = ""
        My.Forms.AdminCreate.fn.Text = ""
        My.Forms.AdminCreate.mn.Text = ""
        My.Forms.AdminCreate.bd.Value = Date.Now
        My.Forms.AdminCreate.add.Text = ""
        My.Forms.AdminCreate.eadd.Text = ""
        My.Forms.AdminCreate.cno.Text = ""
        My.Forms.AdminCreate.sq1.SelectedItem = ""
        My.Forms.AdminCreate.ans1.Text = ""
        My.Forms.AdminCreate.sq2.SelectedItem = ""
        My.Forms.AdminCreate.ans2.Text = ""
        My.Forms.AdminCreate.en.Text = ""
        My.Forms.AdminCreate.pw.Text = ""
        My.Forms.AdminCreate.rtp.Text = ""


        My.Forms.StudentCreate.pl.Text = ""
        My.Forms.StudentCreate.sn.Text = ""
        My.Forms.StudentCreate.ln.Text = ""
        My.Forms.StudentCreate.fn.Text = ""
        My.Forms.StudentCreate.mn.Text = ""
        My.Forms.StudentCreate.bd.Text = ""
        My.Forms.StudentCreate.cont.Text = ""
        My.Forms.StudentCreate.bp.Text = ""
        My.Forms.StudentCreate.gen.SelectedItem = ""
        My.Forms.StudentCreate.add.Text = ""
        My.Forms.StudentCreate.citi.Text = ""
        My.Forms.StudentCreate.rel.Text = ""
        My.Forms.StudentCreate.sy.Text = ""
        My.Forms.StudentCreate.gl.SelectedItem = ""
        My.Forms.StudentCreate.mon.Text = ""
        My.Forms.StudentCreate.mono.Text = ""
        My.Forms.StudentCreate.fon.Text = ""
        My.Forms.StudentCreate.fono.Text = ""
        My.Forms.StudentCreate.gdn.Text = ""
        My.Forms.StudentCreate.rl.Text = ""
        My.Forms.StudentCreate.nso.Text = ""
        My.Forms.StudentCreate.bc.Text = ""
        My.Forms.StudentCreate.bap.Text = ""
        My.Forms.StudentCreate.pl.Text = ""
    End Sub
    Public Sub LoginReg()
        'method to para mag login si registrar, from here, magbabago yung SQL Query natin, instead na INSERT,
        'SELECT na. iccheck natin kung meron bang username sa database table.

        'Login registrar account for security(selecting from registrar_account table)
        Try
            If (My.Forms.RegistrarLogin.en.Text = "") Then
                MsgBox("Please enter EmployeeNo.")
                My.Forms.RegistrarLogin.en.Focus()
            ElseIf (My.Forms.RegistrarLogin.pw.Text = "") Then
                MsgBox("Please enter Password.")
                My.Forms.RegistrarLogin.pw.Focus()
            ElseIf (My.Forms.RegistrarLogin.en.Text = "" And My.Forms.RegistrarLogin.pw.Text = "") Then
                MsgBox("Please fill the empty fields.")
                My.Forms.RegistrarLogin.en.Focus()
            Else
                insert() 'eto yung insert method. instead na 2 lines of code, eto na lang ilalagay. dali diba? haha
                cn.Open() 'siyempre, para maka connect tayo sa database, need natin iopen yung connection.

                'see, yung SQL Query natin, select all from registrar_account where yung EmployeeID ay equals dun sa nakatype textbox and yung Password ay equals dun sa password na nakatype sa text box.
                Dim ad As String = "SELECT * FROM registrar_account WHERE (EmployeeID ='" & My.Forms.RegistrarLogin.en.Text & "' AND Password ='" & My.Forms.RegistrarLogin.pw.Text & "')"

                Dim cmd As MySqlCommand = New MySqlCommand(ad, cn)
                r = cmd.ExecuteReader() 'execute query

                'if r.Read, ibig sabihin nun, merong username and password dun sa databae na nag match dun sa username and password na
                'naka type sa login screen. 
                If r.Read Then

                    'add if else here to check if account status is active!
                    'if active, login, else, show error that error is blocked.

                    My.Forms.Screen_Registrar.Show()
                    RegistrarPanel.TopLevel = False
                    My.Forms.Screen_Registrar.RegistrarPanelPictureBox.Controls.Add(RegistrarPanel)
                    RegistrarPanel.Show()
                    My.Forms.MainScreen.Hide()
                    'show natin yung registrar panel kasi successful yung login.
                    My.Forms.MainScreen.Button5.Visible = False
                    cn.Close() 'need natin iclose lagi yung connection sa database. why? para ma prevent yung database leaks.

                Else
                    'else, magsshow tayo ng error. kasi hindi match yung nasa database, saka yung naka type sa login screen.
                    MsgBox("EmployeeID and Password did'nt Match!")
                    My.Forms.RegistrarLogin.en.Focus()
                    My.Forms.RegistrarLogin.pw.Text = ""
                    cn.Close()
                End If
            End If
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoginAdm()


        Dim statusAttempts As String
        Dim statusCount As Integer
        Dim statusValue As String


        Try
            If (My.Forms.LoginAdmin.en.Text = "") Then
                MsgBox("Please enter Employee Number.", vbInformation, "St. Martin De Porres")
                My.Forms.LoginAdmin.en.Focus()
            ElseIf (My.Forms.LoginAdmin.pw.Text = "") Then
                MsgBox("Please enter Password.", vbInformation, "St. Martin De Porres")
                My.Forms.LoginAdmin.pw.Focus()
            ElseIf (My.Forms.LoginAdmin.en.Text = "" And My.Forms.LoginAdmin.pw.Text = "") Then
                MsgBox("Please fill the empty fields.", vbInformation, "St. Martin De Porres")
                My.Forms.LoginAdmin.en.Focus()
            Else


                insert()
                cn.Open()
                Dim status As String = "SELECT * FROM admin WHERE (EmployeeID='" & My.Forms.LoginAdmin.en.Text & " ' )"
                Dim comd As MySqlCommand = New MySqlCommand(status, cn)
                r = comd.ExecuteReader()


                If r.Read = True Then

                    If r.GetString("status") = "Active" Then
                        If r.GetString("Password") = My.Forms.LoginAdmin.pw.Text Then

                            cn.Close()
                            My.Forms.LoginAdmin.Hide()
                            My.Forms.Screen_Admin.Show()
                            AdminPanel.TopLevel = False
                            My.Forms.Screen_Admin.AdminPanelPictureBox.Controls.Add(AdminPanel)
                            AdminPanel.Show()
                            My.Forms.MainScreen.Hide()

                            statusAttempts = "UPDATE admin SET LogIn_Attempts= 0 WHERE EmployeeID = '" & My.Forms.LoginAdmin.en.Text & "'"
                            My.Forms.LoginAdmin.lblcount.Text = 0

                            Using sqlCmdStatus = New MySqlCommand(statusAttempts, cn1)
                                cn1.Open()
                                sqlCmdStatus.ExecuteNonQuery()
                            End Using
                            cn1.Close()

                        Else
                            statusCount = Val(My.Forms.LoginAdmin.lblcount.Text)
                            statusValue = "Active"

                            If statusCount >= 2 Then
                                statusValue = "Blocked"
                            End If

                            statusAttempts = "UPDATE admin SET LogIn_Attempts= LogIn_Attempts + 1, Status = '" & statusValue & "' WHERE EmployeeID = '" & My.Forms.LoginAdmin.en.Text & "'"
                            Using sqlCmdStatus = New MySqlCommand(statusAttempts, cn1)
                                cn1.Open()
                                sqlCmdStatus.ExecuteNonQuery()
                            End Using

                            statusCount = Val(r.GetString("LogIn_Attempts") + 1)
                            My.Forms.LoginAdmin.lblcount.Text = statusCount


                            cn1.Close()
                            MsgBox("Employee number and Password did not match !", vbCritical, "St. Martin De Porres")

                        End If

                    Else
                        My.Forms.LoginAdmin.lblcount.Text = 0
                        MsgBox("Sorry! Your Account is blocked. Please contact your administrator.", vbCritical, "St. Martin De Porres")
                        My.Forms.LoginAdmin.en.Focus()
                        My.Forms.LoginAdmin.pw.Text = ""
                        My.Forms.LoginAdmin.en.Text = ""

                    End If

                Else
                    cn.Close()
                    My.Forms.LoginAdmin.lblcount.Text = 0
                    MsgBox("Employee number and Password did not match!", vbExclamation, "St. Martin De Porres")
                    My.Forms.LoginAdmin.en.Focus()
                    My.Forms.LoginAdmin.pw.Text = ""


                End If

                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try





    End Sub
    Public Sub LoginCash()
        'login cashier naman toooo. 
        'Login cashier account for security(selecting from cashier_account table)
        Dim loginCounter As Integer
        Dim employeeID As String
        Dim lastLoginEmpID As String
        Dim statusBlocked As String
        Dim loginStatus As String

        statusBlocked = "blocked"
        loginCounter = 0
        Try
            If (My.Forms.CashierLogin.en.Text = "") Then
                MsgBox("Please enter Employee Number.")
                My.Forms.CashierLogin.en.Focus()
            ElseIf (My.Forms.CashierLogin.pw.Text = "") Then
                MsgBox("Please enter Password.")
                My.Forms.CashierLogin.pw.Focus()
            ElseIf (My.Forms.CashierLogin.en.Text = "" And My.Forms.CashierLogin.pw.Text = "") Then
                MsgBox("Please fill the empty fields.")
                My.Forms.CashierLogin.en.Focus()
            Else
                employeeID = My.Forms.CashierLogin.en.Text
                insert()
                'SQL Query lang naman yung nagbabago, pero yung feelings ni princess poppy hindi magbabago yun. haha
                Dim ad As String = "SELECT * FROM cashier_account WHERE (EmployeeID ='" & My.Forms.CashierLogin.en.Text & "' AND Password ='" & My.Forms.CashierLogin.pw.Text & "')"
                cn.Open()
                Dim cmd As MySqlCommand = New MySqlCommand(ad, cn)
                r = cmd.ExecuteReader()
                If r.Read Then

                    loginStatus = r("status").ToString()
                    If loginStatus = "active" Then
                        My.Forms.MainScreen.Button5.Visible = False
                        My.Forms.CashierLogin.Hide()
                        CashierPanel.TopLevel = False
                        My.Forms.MainScreen.Pi.Controls.Add(CashierPanel)
                        CashierPanel.Show()
                        cn.Close()
                    Else
                        MsgBox("Your account is blocked! Please contact your System Administrator")
                    End If

                Else
                    lastLoginEmpID = My.Forms.CashierLogin.en.Text
                    If lastLoginEmpID = employeeID Then
                        loginCounter += 1
                    Else
                        loginCounter = 0
                    End If

                    MsgBox("Employee number and Password did not match!")
                    My.Forms.CashierLogin.en.Focus()
                    My.Forms.CashierLogin.pw.Text = ""
                    cn.Close()
                End If

                If loginCounter = 3 Then
                    Dim reg As String = "UPDATE cashier_account SET status = '" & statusBlocked & "'"
                    Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                        Using sqlCmd = New MySqlCommand(reg, cn1)
                            cn1.Open()
                            sqlCmd.ExecuteNonQuery()
                            cn1.Close()
                        End Using
                    End Using
                End If

                End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub adminPan()
        'Admin panel. To display Picture of Admin, Name, ContactNumber, etc.
        insert() 'okay andito nanaman tong insert() na to, para san nga ulit to guys? remember! hehe

        'meron tayong SQL Query, SELECT * FROM admin <-- eto kasi yung method pag successfully na nakapag login si admin
        'ididisplay niya yung information nung admin na nag login, so select all from admin(table) where is yung EmployeeID
        'is equals dun sa employee id na nasa text.
        Dim reg As String = "SELECT * FROM admin WHERE (EmployeeID ='" & My.Forms.AdminPanel.empl.Text & "')"
        cn1.Open() 'open database connection ulit para maka connect tayo sa databae.

        Dim cmd As MySqlCommand = New MySqlCommand(reg, cn1)
        r = cmd.ExecuteReader() 'execute sql query
        'alam na natin kung ano ibig sabihin ng r.Read diba guys? ibig sabihin, meron nun sa database. so,
        'ididisplay niya kung ano yung nakita niya sa database na under nung employee id
        Try
            If r.Read Then
                My.Forms.AdminPanel.n1.Text = r("Surname").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.AdminPanel.email.Text = r("Email_Account").ToString() & "."
                My.Forms.AdminPanel.cn.Text = r("ContactNumber").ToString() & "."
                My.Forms.AdminPanel.pl.Text = r("Photo").ToString()
                My.Forms.AdminPanel.PictureBox3.Image = Image.FromFile(My.Forms.AdminPanel.pl.Text)
                cn1.Close() 'remember na laging icclose yung database connection. parang sa pag ibig, dapat laging may closure kayo ng x mo. hahaha
            Else
                MsgBox("Employee number not Found!")
                cn1.Close()
            End If
        Catch ex As Exception
        End Try
        cn1.Close()
        
    End Sub
    Public Sub studentSearch()
        'View Student info. To display Picture of Student, Name, StudentNo, etc.

        'so eto yung method ng pag search ng student guys,
        'ang lagi lang natin iccheck is yung SQL Query. siyempre ang sine search natin is yung student information,
        'dun tayo titingin sa student_info na table. sql query is, SELECT * FROM student_info where is yung Student_ID_No is
        'equals dun sa nai type sa text box.
        Try
            'pag empty yung text box pero ni click yung search button,
            'display ng error. siyempre hindi naman tayo pwedeng maghanap ng wala. hehe
            ' If (My.Forms.AdminPanel.TextBox1.Text = "") Then
            'MsgBox("Enter Student Number.")
            'Else
            'insert() 'lagi na lang natin nakikita to. always remember na pag ko connect tayo sa database, lagi siyang nanjan. ayoko na humugot. haha
            'Dim r As MySqlDataReader

            'eto yung sql query naten.
            'Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.AdminPanel.TextBox1.Text & "')"
            ' cn1.Open() 'open ng database connection
            ' Dim cmd As MySqlCommand = New MySqlCommand(reg, cn1) 'etong line ng code na to, kung mapapansin naten,
            'cmd as MySqlCommand daw. tapos kinuha niya yung reg which is yung SQL query natin, at yung cn1 which is yung
            'nasa insert(), which is pag connect sa database. then check yung next line,
            'r = cmd.ExecuteReader() <--- so ibig sabihin nun, para magkaron tayo ng successful connection kay database,
            'need natin ng SQL Query string which is yung 'reg', need din natin ng connection kay db, which is yung 'cn1',
            'na makikita natin dun sa insert() method, and yung 'r' para mai execute yung connection kay database.

            'r = cmd.ExecuteReader() 'execute ng sql query. eto si r

            'so r.Read, alam na natin na nag success siya, display niya yung student information. else, display error tayo
            If r.Read Then
                My.Forms.AdminPanel.Hide()
                ViewStudentInfo.TopLevel = False
                My.Forms.MainScreen.Pi.Controls.Add(ViewStudentInfo)
                ViewStudentInfo.Show()
                cn1.Close()
            Else
                MsgBox("Studente number not found!")
                ' en.Focus()
                '   My.Forms.AdminPanel.TextBox1.Text = ""
                '   My.Forms.AdminPanel.TextBox1.Focus()
                cn1.Close()
            End If
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub close1()
        'eto yung pag close method ng mga forms.
        '    Try
        Application.Exit()
        'My.Forms.LoginAdmin.Close()
        'My.Forms.CashierLogin.Close()
        'My.Forms.RegistrarLogin.Close()
        'My.Forms.AdminPanel.Close()
        'My.Forms.ViewStudentInfo.Close()
        'My.Forms.RegistrarCreate.Close()
        'My.Forms.CashierCreate.Close()
        'My.Forms.AdminCreate.Close()
        'My.Forms.StudentCreate.Close()
        'My.Forms.Screen_Admin.Close()
        'My.Forms.Screen_Cashier.Close()
        'My.Forms.Screen_Registrar.Close()
        'My.Forms.MainScreen.Close()

        '   Catch
        '  End Try
    End Sub
    Public Sub chapass()

        'change password na tayo guys, ibang sql query na gamit natin dito. change password, need natin mag update sa database,
        'so UPDATE table SET fields = laman ng text box
        'Change password of Admin
        Try
            If (My.Forms.ChangePass.pw.Text = "") Then
                MsgBox("Please enter Password")
                My.Forms.ChangePass.pw.Focus()
            ElseIf (My.Forms.ChangePass.rtp.Text = "") Then
                MsgBox("Please enter re-type password!")
                My.Forms.ChangePass.rtp.Focus()
            ElseIf (My.Forms.ChangePass.rtp.Text = "" And My.Forms.ChangePass.pw.Text = "") Then
                MsgBox("Please enter the empty fields")
                My.Forms.ChangePass.pw.Focus()
            Else
                If (My.Forms.ChangePass.pw.Text = My.Forms.ChangePass.rtp.Text) Then
                    'eto yung sql query natin for changing password. medyo magbabago lang dito, kasi wala na yung insert().
                    'hindi naman na kasi tayo mag i insert or titingin sa db, mag a update na tayo.
                    Dim reg As String = "UPDATE admin SET Password = '" & My.Forms.ChangePass.rtp.Text & "'"
                    Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                        Using sqlCmd = New MySqlCommand(reg, cn1)
                            cn1.Open() 'pero siyempre andito pa din yung mag o open tayo ng connection,
                            sqlCmd.ExecuteNonQuery() 'mag e execute ng query,
                            MsgBox("Password changed successfully!")
                            cn1.Close() 'at close connection. para san ulit to guys? remember! para ma prevent yung db leaks.
                            'pag kasi may naka open lang na connection ng database, bukod sa prone sa database leaks,
                            'kumakain pa siya ng resources (memory) ng computer. which is cause ng pagbagal ng computer
                            'na gamit ni admin, or cashier, or registrar. kaya important na every open ng database connection,
                            'perform yung database transaction (SELECT or INSERT or UPDATE, etc.)
                            'then close connection.
                        End Using
                        cn1.Close()
                    End Using
                Else
                    MsgBox("Passwords are not mathced!")
                    My.Forms.ChangePass.pw.Text = ""
                    My.Forms.ChangePass.rtp.Text = ""
                    My.Forms.ChangePass.pw.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub forgot()

        'sa forgot password naman to. 
        'Forgot password (To verify secret question)
        Try
            insert() 'andito na ulit si insert() kasi SELECT lang naman tayo eh. nakuha na natin yung employeeid dun sa unang text box,
            'so kapag yung employee id sa unang textbox at si answer1 and answer2 sa text box ngayon ay matched dun sa database,
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM admin WHERE (EmployeeID ='" & My.Forms.Forgot1.ne1.Text & "' and Answer1 ='" & My.Forms.Forgot1.ans1.Text & "' and Answer2 ='" & My.Forms.Forgot1.ans2.Text & "')"
            cn1.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn1)
            r = cmd.ExecuteReader()
            'eto yun. open si change password form para mai type niya yung bago niyang password.
            If r.Read Then
                ChangePass.TopLevel = False
                My.Forms.MainScreen.Pi.Controls.Add(ChangePass)
                ChangePass.Show()
                My.Forms.Forgot1.Close()
                cn1.Close()
            Else
                MsgBox("Secret Question and Answer are not Matched!")
                My.Forms.Forgot1.ans1.Focus()
                cn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub forgor01()
        'etong method na to, nagveverify lang kung existing si employee number sa database.
        'same explanation lang din to guys tulad ng ibang methods natin.

        'Verification for EmployeeNumber of Admin to change password
        Try
            'eto yung connection string natin, same lang din ng nasa insert()
            cn1.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            'eto yung sql query naten. check natin kung yung ni type ni user sa text box ay existing sa databaes.
            Dim reg As String = "SELECT * FROM admin WHERE (EmployeeID ='" & My.Forms.ForgotV.ne1.Text & "')"
            cn1.Open() 'open database connection
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn1) 'lagay natin kay cmd yung reg saka cn1
            r = cmd.ExecuteReader() 'execute natin

            'kung meron ngang username na tinype ni user sa database, show yung next form. else, error
            If r.Read Then
                ChangePass.TopLevel = False
                My.Forms.MainScreen.Pi.Controls.Add(Forgot1)
                Forgot1.Show()
                My.Forms.ForgotV.Hide()
                cn1.Close()
            Else
                MsgBox("Employee number not Found!")
                cn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub veditR()
        'not implemented in system
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM registrar_account WHERE (EmployeeID ='" & My.Forms.RegistrarEdit.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.RegistrarEdit.ln.Text = r("Surname").ToString()
                My.Forms.RegistrarEdit.fn.Text = r("GivenName").ToString()
                My.Forms.RegistrarEdit.mn.Text = r("MiddleName").ToString()
                My.Forms.RegistrarEdit.bd.Text = r("Birthday").ToString()
                My.Forms.RegistrarEdit.add.Text = r("Address").ToString()
                My.Forms.RegistrarEdit.eadd.Text = r("Email_Account").ToString()
                My.Forms.RegistrarEdit.cno.Text = r("ContactNumber").ToString()
                My.Forms.RegistrarEdit.eadd.Text = r("Email_Account").ToString()
                My.Forms.RegistrarEdit.pl.Text = r("Photo").ToString()
                My.Forms.RegistrarEdit.PictureBox1.Image = Image.FromFile(My.Forms.RegistrarEdit.pl.Text)
                My.Forms.RegistrarEdit.GroupBox2.Enabled = True
                My.Forms.RegistrarEdit.Button1.Enabled = False
                My.Forms.RegistrarEdit.en.Enabled = False
                cn.Close()
            Else
                MsgBox("Employee number not Found!")
                My.Forms.RegistrarEdit.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub editr()
        'not implemented
        Dim reg As String = "UPDATE registrar_account SET Surname = '" & My.Forms.RegistrarEdit.ln.Text & "', GivenName = '" & My.Forms.RegistrarEdit.fn.Text & "', MiddleName = '" & My.Forms.RegistrarEdit.mn.Text & "', Birthday = '" & My.Forms.RegistrarEdit.bd.Text & "', Address = '" & My.Forms.RegistrarEdit.add.Text & "', Email_Account = '" & My.Forms.RegistrarEdit.eadd.Text & "', ContactNumber = '" & My.Forms.RegistrarEdit.cno.Text & "' WHERE EmployeeID = '" & My.Forms.RegistrarEdit.en.Text & "'"
        Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
            Using sqlCmd = New MySqlCommand(reg, cn)
                cn.Open()
                sqlCmd.ExecuteNonQuery()
                MsgBox("Edited Successfully!")
                My.Forms.RegistrarEdit.Button1.Enabled = True
                My.Forms.RegistrarEdit.GroupBox2.Enabled = False
                My.Forms.RegistrarEdit.en.Enabled = True
                My.Forms.RegistrarEdit.en.Text = ""
                My.Forms.RegistrarEdit.ln.Text = ""
                My.Forms.RegistrarEdit.fn.Text = ""
                My.Forms.RegistrarEdit.mn.Text = ""
                My.Forms.RegistrarEdit.bd.Text = ""
                My.Forms.RegistrarEdit.add.Text = ""
                My.Forms.RegistrarEdit.eadd.Text = ""
                My.Forms.RegistrarEdit.cno.Text = ""
                cn.Close()
            End Using
            cn.Close()
        End Using
    End Sub
    Public Sub vedit()
        'not implement
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM cashier_account WHERE (EmployeeID ='" & My.Forms.CashierEdit.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.CashierEdit.ln.Text = r("Surname").ToString()
                My.Forms.CashierEdit.fn.Text = r("GivenName").ToString()
                My.Forms.CashierEdit.mn.Text = r("MiddleName").ToString()
                My.Forms.CashierEdit.bd.Text = r("Birthday").ToString()
                My.Forms.CashierEdit.add.Text = r("Address").ToString()
                My.Forms.CashierEdit.eadd.Text = r("Email_Account").ToString()
                My.Forms.CashierEdit.cno.Text = r("ContactNumber").ToString()
                My.Forms.CashierEdit.eadd.Text = r("Email_Account").ToString()
                My.Forms.CashierEdit.pl.Text = r("Photo").ToString()
                My.Forms.CashierEdit.GroupBox2.Enabled = True
                My.Forms.CashierEdit.Button1.Enabled = False
                My.Forms.CashierEdit.en.Enabled = False
                My.Forms.CashierEdit.PictureBox1.Image = Image.FromFile(My.Forms.CashierEdit.pl.Text)
                cn.Close()
            Else
                MsgBox("Employee number not Found!")
                My.Forms.CashierEdit.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub editC()
        'not implemented
        Try
            Dim reg As String = "UPDATE cashier_account SET Surname = '" & My.Forms.CashierEdit.ln.Text & "', GivenName = '" & My.Forms.CashierEdit.fn.Text & "', MiddleName = '" & My.Forms.CashierEdit.mn.Text & "', Birthday = '" & My.Forms.CashierEdit.bd.Text & "', Address = '" & My.Forms.CashierEdit.add.Text & "', Email_Account = '" & My.Forms.CashierEdit.eadd.Text & "', ContactNumber = '" & My.Forms.CashierEdit.cno.Text & "' WHERE EmployeeID = '" & My.Forms.CashierEdit.en.Text & "'"
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Edited Successfully!")
                    My.Forms.CashierEdit.Button1.Enabled = True
                    My.Forms.CashierEdit.GroupBox2.Enabled = False
                    My.Forms.CashierEdit.en.Enabled = True
                    My.Forms.CashierEdit.en.Text = ""
                    My.Forms.CashierEdit.ln.Text = ""
                    My.Forms.CashierEdit.fn.Text = ""
                    My.Forms.CashierEdit.mn.Text = ""
                    My.Forms.CashierEdit.bd.Text = ""
                    My.Forms.CashierEdit.add.Text = ""
                    My.Forms.CashierEdit.eadd.Text = ""
                    My.Forms.CashierEdit.cno.Text = ""
                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub RegE()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM registrar_account WHERE (EmployeeID ='" & My.Forms.DeleteRegistrar.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.DeleteRegistrar.ln.Text = r("Surname").ToString()
                My.Forms.DeleteRegistrar.fn.Text = r("GivenName").ToString()
                My.Forms.DeleteRegistrar.mn.Text = r("MiddleName").ToString()
                My.Forms.DeleteRegistrar.bd.Text = r("Birthday").ToString()
                My.Forms.DeleteRegistrar.add.Text = r("Address").ToString()
                My.Forms.DeleteRegistrar.eadd.Text = r("Email_Account").ToString()
                My.Forms.DeleteRegistrar.cno.Text = r("ContactNumber").ToString()
                My.Forms.DeleteRegistrar.eadd.Text = r("Email_Account").ToString()
                My.Forms.DeleteRegistrar.pl.Text = r("Photo").ToString()
                My.Forms.DeleteRegistrar.PictureBox1.Image = Image.FromFile(My.Forms.DeleteRegistrar.pl.Text)
                My.Forms.DeleteRegistrar.GroupBox2.Enabled = True
                My.Forms.DeleteRegistrar.Button1.Enabled = False
                My.Forms.DeleteRegistrar.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.DeleteRegistrar.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub regdel()
        'not implemented
        Try
            Dim reg As String = "DELETE FROM registrar_account WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Deleted!")
                    My.Forms.DeleteRegistrar.Button1.Enabled = True
                    My.Forms.DeleteRegistrar.GroupBox2.Enabled = False
                    My.Forms.DeleteRegistrar.en.Enabled = True
                    My.Forms.DeleteRegistrar.en.Text = ""
                    My.Forms.DeleteRegistrar.ln.Text = ""
                    My.Forms.DeleteRegistrar.fn.Text = ""
                    My.Forms.DeleteRegistrar.mn.Text = ""
                    My.Forms.DeleteRegistrar.bd.Text = ""
                    My.Forms.DeleteRegistrar.add.Text = ""
                    My.Forms.DeleteRegistrar.eadd.Text = ""
                    My.Forms.DeleteRegistrar.cno.Text = ""
                    My.Forms.DeleteRegistrar.cno.Text = ""
                    My.Forms.DeleteRegistrar.PictureBox1.Image = Nothing
                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub delcas()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM cashier_account WHERE (EmployeeID ='" & My.Forms.DeleteCashier.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.DeleteCashier.ln.Text = r("Surname").ToString()
                My.Forms.DeleteCashier.fn.Text = r("GivenName").ToString()
                My.Forms.DeleteCashier.mn.Text = r("MiddleName").ToString()
                My.Forms.DeleteCashier.bd.Text = r("Birthday").ToString()
                My.Forms.DeleteCashier.add.Text = r("Address").ToString()
                My.Forms.DeleteCashier.eadd.Text = r("Email_Account").ToString()
                My.Forms.DeleteCashier.cno.Text = r("ContactNumber").ToString()
                My.Forms.DeleteCashier.eadd.Text = r("Email_Account").ToString()
                My.Forms.DeleteCashier.pl.Text = r("Photo").ToString()
                My.Forms.DeleteCashier.PictureBox1.Image = Image.FromFile(My.Forms.DeleteCashier.pl.Text)
                My.Forms.DeleteCashier.GroupBox2.Enabled = True
                My.Forms.DeleteCashier.Button1.Enabled = False
                My.Forms.DeleteCashier.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.DeleteCashier.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub delad()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM admin WHERE (EmployeeID ='" & My.Forms.deleteAdmin.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.deleteAdmin.ln.Text = r("Surname").ToString()
                My.Forms.deleteAdmin.fn.Text = r("GivenName").ToString()
                My.Forms.deleteAdmin.mn.Text = r("MiddleName").ToString()
                My.Forms.deleteAdmin.bd.Text = r("Birthday").ToString()
                My.Forms.deleteAdmin.add.Text = r("Address").ToString()
                My.Forms.deleteAdmin.eadd.Text = r("Email_Account").ToString()
                My.Forms.deleteAdmin.cno.Text = r("ContactNumber").ToString()
                My.Forms.deleteAdmin.eadd.Text = r("Email_Account").ToString()
                My.Forms.deleteAdmin.pl.Text = r("Photo").ToString()
                My.Forms.deleteAdmin.PictureBox1.Image = Image.FromFile(My.Forms.deleteAdmin.pl.Text)
                My.Forms.deleteAdmin.GroupBox2.Enabled = True
                My.Forms.deleteAdmin.Button1.Enabled = False
                My.Forms.deleteAdmin.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.deleteAdmin.en.Text = ""
                My.Forms.deleteAdmin.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub deleteCashierAccounts()
        '   For Each FRM As Form In Application.OpenForms
        Try
            '  Dim deleteAccountUser As String = "My.Forms." & FRM.Name.ToString & ".en.Text"
            '  Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteCashier.en.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd1 = New MySqlCommand(reg1, cn1)
                    cn1.Open()
                    sqlCmd1.ExecuteNonQuery()
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
    Public Sub deleteAdminAccounts()
        '   For Each FRM As Form In Application.OpenForms
        Try
            '  Dim deleteAccountUser As String = "My.Forms." & FRM.Name.ToString & ".en.Text"
            '  Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.deleteAdmin.en.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd1 = New MySqlCommand(reg1, cn1)
                    cn1.Open()
                    sqlCmd1.ExecuteNonQuery()
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
    Public Sub deleteRegistrarAccounts()
        '   For Each FRM As Form In Application.OpenForms
        Try
            '  Dim deleteAccountUser As String = "My.Forms." & FRM.Name.ToString & ".en.Text"
            '  Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Dim reg1 As String = "DELETE FROM accounts WHERE EmployeeID = '" & My.Forms.DeleteRegistrar.en.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd1 = New MySqlCommand(reg1, cn1)
                    cn1.Open()
                    sqlCmd1.ExecuteNonQuery()
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
    Public Sub delad1()
        'not implemented

        Dim reg As String = "DELETE FROM admin WHERE EmployeeID = '" & My.Forms.deleteAdmin.en.Text & "'"
        Try
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Deleted!")
                    My.Forms.deleteAdmin.Button1.Enabled = True
                    My.Forms.deleteAdmin.GroupBox2.Enabled = False
                    My.Forms.deleteAdmin.en.Enabled = True
                    My.Forms.deleteAdmin.en.Text = ""
                    My.Forms.deleteAdmin.ln.Text = ""
                    My.Forms.deleteAdmin.fn.Text = ""
                    My.Forms.deleteAdmin.mn.Text = ""
                    My.Forms.deleteAdmin.bd.Text = ""
                    My.Forms.deleteAdmin.add.Text = ""
                    My.Forms.deleteAdmin.eadd.Text = ""
                    My.Forms.deleteAdmin.cno.Text = ""
                    My.Forms.deleteAdmin.pl.Text = ""
                    My.Forms.deleteAdmin.PictureBox1.Image = Nothing
                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub delcas1()
        'not implemented
        Dim reg As String = "DELETE FROM admin WHERE EmployeeID = '" & My.Forms.DeleteCashier.en.Text & "'"
        Try
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()
                    MsgBox("Deleted!")
                    My.Forms.DeleteCashier.Button1.Enabled = True
                    My.Forms.DeleteCashier.GroupBox2.Enabled = False
                    My.Forms.DeleteCashier.en.Enabled = True
                    My.Forms.DeleteCashier.en.Text = ""
                    My.Forms.DeleteCashier.ln.Text = ""
                    My.Forms.DeleteCashier.fn.Text = ""
                    My.Forms.DeleteCashier.mn.Text = ""
                    My.Forms.DeleteCashier.bd.Text = ""
                    My.Forms.DeleteCashier.add.Text = ""
                    My.Forms.DeleteCashier.eadd.Text = ""
                    My.Forms.DeleteCashier.cno.Text = ""
                    My.Forms.DeleteCashier.pl.Text = ""
                    My.Forms.DeleteCashier.PictureBox1.Image = Nothing
                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub dropstud()

        'drop student method. eto yung parang iddrop na si student. pero ang ginawa natin dito,
        'si student na iddrop, idedelete siya dun sa student_info na table, at, iiinsert siya saa archive table.
        'bakit? siyempre para may record pa din tayo ng student na yun kahit na nag drop na siya.

        'check sql query lang, guys alam kong naiintindihan na natin yung sql query. yun lang ang important dun.
        'siyempre importante din na maintindihan mo yung feelings ng....asfgasldkfjalskdjf haha.
        'anyways, 

        'Drop student (delete from student_info table)
        Try
            'so eto yung una nating transaction kay database, insert.
            'usual routine natin kay database.
            'connection string (insert() noon) cn dito
            'open connection
            'sql query execute
            'close connection
            Dim objConn As New MySqlConnection
            Dim ins As New MySqlCommand
            Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            objConn.ConnectionString = cn
            objConn.Open()
            ins.Connection = objConn
            ins.CommandText = "INSERT INTO student_info_archive VALUES(@Photo ,@Name, @Student_ID_No)"
            ins.Parameters.AddWithValue("@Photo", My.Forms.DeleteStudent_A.pl.Text)
            ins.Parameters.AddWithValue("@Name", My.Forms.DeleteStudent_A.nam.Text)
            ins.Parameters.AddWithValue("@Student_ID_No", My.Forms.DeleteStudent_A.sn.Text)
            ins.ExecuteNonQuery()
            objConn.Close()

            'may bago tayong transaction kay database which is delete.
            'same routine tayo guys.
            'connection string (insert() noon) cn1 dito
            'open connection
            'sql query execute
            'close connection
            Dim reg As String = "DELETE FROM student_info WHERE Student_ID_No = '" & My.Forms.DeleteStudent_A.sn.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn1)
                    cn1.Open()
                    sqlCmd.ExecuteNonQuery()
                    My.Forms.DeleteStudent_A.DeleteButton_a_Student.Enabled = True
                    My.Forms.DeleteStudent_A.sn.Text = ""
                    My.Forms.DeleteStudent_A.nam.Text = ""
                    My.Forms.DeleteStudent_A.add.Text = ""
                    My.Forms.DeleteStudent_A.bd.Text = ""
                    My.Forms.DeleteStudent_A.gl.Text = ""
                    My.Forms.DeleteStudent_A.ag.Text = ""
                    My.Forms.DeleteStudent_A.sy.Text = ""
                    My.Forms.DeleteStudent_A.con.Text = ""
                    My.Forms.DeleteStudent_A.pl.Text = ""
                    cn1.Close()
                End Using
                cn1.Close()
            End Using
            MsgBox("Student Deleted!!")
            My.Forms.DeleteStudent_A.DeleteButton_a_Student.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub dropstudR()

        'drop student method. eto yung parang iddrop na si student. pero ang ginawa natin dito,
        'si student na iddrop, idedelete siya dun sa student_info na table, at, iiinsert siya saa archive table.
        'bakit? siyempre para may record pa din tayo ng student na yun kahit na nag drop na siya.

        'check sql query lang, guys alam kong naiintindihan na natin yung sql query. yun lang ang important dun.
        'siyempre importante din na maintindihan mo yung feelings ng....asfgasldkfjalskdjf haha.
        'anyways, 

        'Drop student (delete from student_info table)
        Try
            'so eto yung una nating transaction kay database, insert.
            'usual routine natin kay database.
            'connection string (insert() noon) cn dito
            'open connection
            'sql query execute
            'close connection
            Dim objConn As New MySqlConnection
            Dim ins As New MySqlCommand
            Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            objConn.ConnectionString = cn
            objConn.Open()
            ins.Connection = objConn
            ins.CommandText = "INSERT INTO student_info_archive VALUES(@Photo ,@Name, @Student_ID_No)"
            ins.Parameters.AddWithValue("@Photo", My.Forms.DeleteStudent_R.pl.Text)
            ins.Parameters.AddWithValue("@Name", My.Forms.DeleteStudent_R.nam.Text)
            ins.Parameters.AddWithValue("@Student_ID_No", My.Forms.DeleteStudent_R.sn.Text)
            ins.ExecuteNonQuery()
            objConn.Close()

            'may bago tayong transaction kay database which is delete.
            'same routine tayo guys.
            'connection string (insert() noon) cn1 dito
            'open connection
            'sql query execute
            'close connection
            Dim reg As String = "DELETE FROM student_info WHERE Student_ID_No = '" & My.Forms.DeleteStudent_R.sn.Text & "'"
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn1)
                    cn1.Open()
                    sqlCmd.ExecuteNonQuery()
                    My.Forms.DeleteStudent_R.DeleteButton_a_Student.Enabled = True
                    My.Forms.DeleteStudent_R.sn.Text = ""
                    My.Forms.DeleteStudent_R.nam.Text = ""
                    My.Forms.DeleteStudent_R.add.Text = ""
                    My.Forms.DeleteStudent_R.bd.Text = ""
                    My.Forms.DeleteStudent_R.gl.Text = ""
                    My.Forms.DeleteStudent_R.ag.Text = ""
                    My.Forms.DeleteStudent_R.sy.Text = ""
                    My.Forms.DeleteStudent_R.con.Text = ""
                    My.Forms.DeleteStudent_R.pl.Text = ""
                    cn1.Close()
                End Using
                cn1.Close()
            End Using
            MsgBox("Student Deleted!!")
            My.Forms.DeleteStudent_A.DeleteButton_a_Student.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub

    Public Sub editstud()
        'edit student info method guys, easy lang to maintindihan. alam naman na natin yung
        'routine natin kapag magttransact tayo kay database eh.

        'edit Student info
        Try
            My.Forms.UpdateStudent_A.SearchStudent_btn.Enabled = True
            'eto yung sql query natin, which is UPDATE.
            Dim reg1 As String = "UPDATE student_info SET Address = '" & My.Forms.UpdateStudent_A.add.Text & "', Birthday = '" & My.Forms.UpdateStudent_A.bd.Text & "', GradeLevel = '" & My.Forms.UpdateStudent_A.gl.Text & "', Birthday = '" & My.Forms.UpdateStudent_A.bd.Text & "', Contact = '" & My.Forms.UpdateStudent_A.con.Text & "', SchoolYear = '" & My.Forms.UpdateStudent_A.sy.Text & "', Age = '" & My.Forms.UpdateStudent_A.ag.Text & "' WHERE Student_ID_No = '" & My.Forms.UpdateStudent_A.sn.Text & "'"
            'eto yung connection string natin, (insert() noon), cn1 dito.
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg1, cn1)
                    cn1.Open() 'open connection
                    sqlCmd.ExecuteNonQuery() 'execute sql query
                    MsgBox("Student Info Edited")
                    My.Forms.UpdateStudent_A.SearchStudent_btn.Enabled = True
                    My.Forms.UpdateStudent_A.UpdateButton_a_Student.Enabled = False

                    My.Forms.UpdateStudent_A.sn.Text = ""
                    My.Forms.UpdateStudent_A.nam.Text = ""
                    My.Forms.UpdateStudent_A.add.Text = ""
                    My.Forms.UpdateStudent_A.bd.Text = ""
                    My.Forms.UpdateStudent_A.gl.Text = ""
                    My.Forms.UpdateStudent_A.con.Text = ""
                    My.Forms.UpdateStudent_A.sy.Text = ""
                    My.Forms.UpdateStudent_A.pl.Text = ""
                    My.Forms.UpdateStudent_A.ag.Text = ""
                    My.Forms.UpdateStudent_A.pl.Text = ""

                    cn1.Close() 'close connection
                End Using
                cn1.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub editstud_R()
        'edit student info method guys, easy lang to maintindihan. alam naman na natin yung
        'routine natin kapag magttransact tayo kay database eh.

        'edit Student info
        Try
            My.Forms.UpdateStudent_A.SearchStudent_btn.Enabled = True
            'eto yung sql query natin, which is UPDATE.
            Dim reg1 As String = "UPDATE student_info SET Address = '" & My.Forms.UpdateStudent_R.add.Text & "', Birthday = '" & My.Forms.UpdateStudent_R.bd.Text & "', GradeLevel = '" & My.Forms.UpdateStudent_R.gl.Text & "', Birthday = '" & My.Forms.UpdateStudent_R.bd.Text & "', Contact = '" & My.Forms.UpdateStudent_R.con.Text & "', SchoolYear = '" & My.Forms.UpdateStudent_R.sy.Text & "', Age = '" & My.Forms.UpdateStudent_R.ag.Text & "' WHERE Student_ID_No = '" & My.Forms.UpdateStudent_R.sn.Text & "'"
            'eto yung connection string natin, (insert() noon), cn1 dito.
            Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg1, cn1)
                    cn1.Open() 'open connection
                    sqlCmd.ExecuteNonQuery() 'execute sql query
                    MsgBox("Student Info Edited")
                    My.Forms.UpdateStudent_R.SearchStudent_btn.Enabled = True
                    My.Forms.UpdateStudent_R.UpdateButton_a_Student.Enabled = False

                    My.Forms.UpdateStudent_R.sn.Text = ""
                    My.Forms.UpdateStudent_R.nam.Text = ""
                    My.Forms.UpdateStudent_R.add.Text = ""
                    My.Forms.UpdateStudent_R.bd.Text = ""
                    My.Forms.UpdateStudent_R.gl.Text = ""
                    My.Forms.UpdateStudent_R.con.Text = ""
                    My.Forms.UpdateStudent_R.sy.Text = ""
                    My.Forms.UpdateStudent_R.pl.Text = ""
                    My.Forms.UpdateStudent_R.ag.Text = ""
                    My.Forms.UpdateStudent_R.pl.Text = ""

                    cn1.Close() 'close connection
                End Using
                cn1.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub vadmmin_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM admin WHERE (EmployeeID ='" & My.Forms.UpdateAdmin.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateAdmin.ln.Text = r("Surname").ToString()
                My.Forms.UpdateAdmin.fn.Text = r("GivenName").ToString()
                My.Forms.UpdateAdmin.mn.Text = r("MiddleName").ToString()
                My.Forms.UpdateAdmin.bd.Text = r("Birthday").ToString()
                My.Forms.UpdateAdmin.add.Text = r("Address").ToString()
                My.Forms.UpdateAdmin.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateAdmin.cno.Text = r("ContactNumber").ToString()
                My.Forms.UpdateAdmin.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateAdmin.pl.Text = r("Photo").ToString()
                My.Forms.UpdateAdmin.PictureBox1.Image = Image.FromFile(My.Forms.UpdateAdmin.pl.Text)
                My.Forms.UpdateAdmin.GroupBox2.Enabled = True
                My.Forms.UpdateAdmin.ValidateAccountUpdate_btn.Enabled = False
                My.Forms.UpdateAdmin.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.UpdateAdmin.en.Text = ""
                My.Forms.UpdateAdmin.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub updateAccntAdmin_btn()
        Try
            If (My.Forms.UpdateAdmin.ln.Text = "" And My.Forms.UpdateAdmin.fn.Text = "" _
              And My.Forms.UpdateAdmin.mn.Text = "" And My.Forms.UpdateAdmin.bd.Text = "" _
              And My.Forms.UpdateAdmin.add.Text = "" And My.Forms.UpdateAdmin.eadd.Text = "" _
              And My.Forms.UpdateAdmin.cno.Text = "") Then
                MsgBox("Please enter the empty fields")
            Else
                Dim reg As String = "UPDATE admin SET Surname = '" & My.Forms.UpdateAdmin.ln.Text & "', GivenName = '" & My.Forms.UpdateAdmin.fn.Text & "', MiddleName = '" & My.Forms.UpdateAdmin.mn.Text & "', Birthday = '" & My.Forms.UpdateAdmin.bd.Text & "', Address = '" & My.Forms.UpdateAdmin.add.Text & "', Email_Account = '" & My.Forms.UpdateAdmin.eadd.Text & "', ContactNumber = '" & My.Forms.UpdateAdmin.cno.Text & "'"
                Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                    Using sqlCmd = New MySqlCommand(reg, cn1)
                        cn1.Open()
                        sqlCmd.ExecuteNonQuery()
                        MsgBox("Admin Account Updated!")
                        My.Forms.UpdateAdmin.en.Text = ""
                        My.Forms.UpdateAdmin.ln.Text = ""
                        My.Forms.UpdateAdmin.fn.Text = ""
                        My.Forms.UpdateAdmin.mn.Text = ""
                        My.Forms.UpdateAdmin.bd.Text = ""
                        My.Forms.UpdateAdmin.add.Text = ""
                        My.Forms.UpdateAdmin.eadd.Text = ""
                        My.Forms.UpdateAdmin.cno.Text = ""
                        My.Forms.UpdateAdmin.GroupBox2.Enabled = False
                        My.Forms.UpdateAdmin.ValidateAccountUpdate_btn.Enabled = True
                        My.Forms.UpdateAdmin.en.Enabled = True
                        My.Forms.UpdateAdmin.en.Focus()
                        cn1.Close()
                    End Using
                    cn1.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub vRegistrar_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM registrar_account WHERE (EmployeeID ='" & My.Forms.UpdateRegistrar.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateRegistrar.ln.Text = r("Surname").ToString()
                My.Forms.UpdateRegistrar.fn.Text = r("GivenName").ToString()
                My.Forms.UpdateRegistrar.mn.Text = r("MiddleName").ToString()
                My.Forms.UpdateRegistrar.bd.Text = r("Birthday").ToString()
                My.Forms.UpdateRegistrar.add.Text = r("Address").ToString()
                My.Forms.UpdateRegistrar.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateRegistrar.cno.Text = r("ContactNumber").ToString()
                My.Forms.UpdateRegistrar.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateRegistrar.pl.Text = r("Photo").ToString()
                My.Forms.UpdateRegistrar.PictureBox1.Image = Image.FromFile(My.Forms.UpdateRegistrar.pl.Text)
                My.Forms.UpdateRegistrar.GroupBox2.Enabled = True
                My.Forms.UpdateRegistrar.ValidateAccountUpdate_btn.Enabled = False
                My.Forms.UpdateRegistrar.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.UpdateRegistrar.en.Text = ""
                My.Forms.UpdateRegistrar.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub updateAccntRegistrar_btn()
        Try
            If (My.Forms.UpdateRegistrar.ln.Text = "" And My.Forms.UpdateRegistrar.fn.Text = "" _
              And My.Forms.UpdateRegistrar.mn.Text = "" And My.Forms.UpdateRegistrar.bd.Text = "" _
              And My.Forms.UpdateRegistrar.add.Text = "" And My.Forms.UpdateRegistrar.eadd.Text = "" _
              And My.Forms.UpdateRegistrar.cno.Text = "") Then
                MsgBox("Please enter the empty fields")
            Else
                Dim reg As String = "UPDATE registrar_account SET Surname = '" & My.Forms.UpdateRegistrar.ln.Text & "', GivenName = '" & My.Forms.UpdateRegistrar.fn.Text & "', MiddleName = '" & My.Forms.UpdateRegistrar.mn.Text & "', Birthday = '" & My.Forms.UpdateRegistrar.bd.Text & "', Address = '" & My.Forms.UpdateRegistrar.add.Text & "', Email_Account = '" & My.Forms.UpdateRegistrar.eadd.Text & "', ContactNumber = '" & My.Forms.UpdateRegistrar.cno.Text & "'"
                Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                    Using sqlCmd = New MySqlCommand(reg, cn1)
                        cn1.Open()
                        sqlCmd.ExecuteNonQuery()
                        MsgBox("Registrar Account Updated!")
                        My.Forms.UpdateRegistrar.en.Text = ""
                        My.Forms.UpdateRegistrar.ln.Text = ""
                        My.Forms.UpdateRegistrar.fn.Text = ""
                        My.Forms.UpdateRegistrar.mn.Text = ""
                        My.Forms.UpdateRegistrar.bd.Text = ""
                        My.Forms.UpdateRegistrar.add.Text = ""
                        My.Forms.UpdateRegistrar.eadd.Text = ""
                        My.Forms.UpdateRegistrar.cno.Text = ""
                        My.Forms.UpdateRegistrar.GroupBox2.Enabled = False
                        My.Forms.UpdateRegistrar.ValidateAccountUpdate_btn.Enabled = True
                        My.Forms.UpdateRegistrar.en.Enabled = True
                        My.Forms.UpdateRegistrar.en.Focus()
                        cn1.Close()
                    End Using
                    cn1.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub vCashier_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM cashier_account WHERE (EmployeeID ='" & My.Forms.UpdateCashier.en.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateCashier.ln.Text = r("Surname").ToString()
                My.Forms.UpdateCashier.fn.Text = r("GivenName").ToString()
                My.Forms.UpdateCashier.mn.Text = r("MiddleName").ToString()
                My.Forms.UpdateCashier.bd.Text = r("Birthday").ToString()
                My.Forms.UpdateCashier.add.Text = r("Address").ToString()
                My.Forms.UpdateCashier.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateCashier.cno.Text = r("ContactNumber").ToString()
                My.Forms.UpdateCashier.eadd.Text = r("Email_Account").ToString()
                My.Forms.UpdateCashier.pl.Text = r("Photo").ToString()
                My.Forms.UpdateCashier.PictureBox1.Image = Image.FromFile(My.Forms.UpdateCashier.pl.Text)
                My.Forms.UpdateCashier.GroupBox2.Enabled = True
                My.Forms.UpdateCashier.ValidateAccountUpdate_btn.Enabled = False
                My.Forms.UpdateCashier.en.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.UpdateCashier.en.Text = ""
                My.Forms.UpdateCashier.en.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub updateAccntCashier_btn()
        Try
            If (My.Forms.UpdateCashier.ln.Text = "" And My.Forms.UpdateCashier.fn.Text = "" _
              And My.Forms.UpdateCashier.mn.Text = "" And My.Forms.UpdateCashier.bd.Text = "" _
              And My.Forms.UpdateCashier.add.Text = "" And My.Forms.UpdateCashier.eadd.Text = "" _
              And My.Forms.UpdateCashier.cno.Text = "") Then
                MsgBox("Please enter the empty fields")
            Else
                Dim reg As String = "UPDATE cashier_account SET Surname = '" & My.Forms.UpdateCashier.ln.Text & "', GivenName = '" & My.Forms.UpdateCashier.fn.Text & "', MiddleName = '" & My.Forms.UpdateCashier.mn.Text & "', Birthday = '" & My.Forms.UpdateCashier.bd.Text & "', Address = '" & My.Forms.UpdateCashier.add.Text & "', Email_Account = '" & My.Forms.UpdateCashier.eadd.Text & "', ContactNumber = '" & My.Forms.UpdateCashier.cno.Text & "'"
                Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                    Using sqlCmd = New MySqlCommand(reg, cn1)
                        cn1.Open()
                        sqlCmd.ExecuteNonQuery()
                        MsgBox("Cashier Account Updated!")
                        My.Forms.UpdateCashier.en.Text = ""
                        My.Forms.UpdateCashier.ln.Text = ""
                        My.Forms.UpdateCashier.fn.Text = ""
                        My.Forms.UpdateCashier.mn.Text = ""
                        My.Forms.UpdateCashier.bd.Text = ""
                        My.Forms.UpdateCashier.add.Text = ""
                        My.Forms.UpdateCashier.eadd.Text = ""
                        My.Forms.UpdateCashier.cno.Text = ""
                        My.Forms.UpdateCashier.GroupBox2.Enabled = False
                        My.Forms.UpdateCashier.ValidateAccountUpdate_btn.Enabled = True
                        My.Forms.UpdateCashier.en.Enabled = True
                        My.Forms.UpdateCashier.en.Focus()
                        cn1.Close()
                    End Using
                    cn1.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
  
    Public Sub updateSubjA_btn()
        Try
            If (My.Forms.UpdateSub_A.gl.Text = "" And My.Forms.UpdateSub_A.sec.Text = "" _
              And My.Forms.UpdateSub_A.nm.Text = "" And My.Forms.UpdateSub_A.teacher.Text = "" _
              And My.Forms.UpdateSub_A.sy.Text = "" And My.Forms.UpdateSub_A.nm.Text = "") Then
                MsgBox("Please enter the empty fields")
            Else
                Dim reg As String = "UPDATE subject_tbl SET Grade_Level = '" & My.Forms.UpdateSub_A.gl.Text & "', Section = '" & My.Forms.UpdateSub_A.sec.Text & "', School_Year = '" & My.Forms.UpdateSub_A.sy.Text & "', Time = '" & My.Forms.UpdateSub_A.tim.Text & "', No_Minutes = '" & My.Forms.UpdateSub_A.nm.Text = "" & "', Teacher = '" & My.Forms.UpdateSub_A.teacher.Text & "'"
                Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                    Using sqlCmd = New MySqlCommand(reg, cn1)
                        cn1.Open()
                        sqlCmd.ExecuteNonQuery()
                        MsgBox("Subject Updated!")
                        My.Forms.UpdateSub_A.gl.Text = ""
                        My.Forms.UpdateSub_A.sec.Text = ""
                        My.Forms.UpdateSub_A.nm.Text = ""
                        My.Forms.UpdateSub_A.teacher.Text = ""
                        My.Forms.UpdateSub_A.sy.Text = ""
                        My.Forms.UpdateSub_A.tim.Text = ""
                        My.Forms.UpdateSub_A.GroupBox2.Enabled = False
                        My.Forms.UpdateSub_A.SearchSubj_btn.Enabled = True
                        My.Forms.UpdateSub_A.subj.Enabled = True
                        My.Forms.UpdateSub_A.subj.Focus()
                        cn1.Close()
                    End Using
                    cn1.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubjR_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.UpdateSub_A.subj.Text & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateSub_A.gl.Text = r("Grade_Level").ToString()
                My.Forms.UpdateSub_A.sec.Text = r("Section").ToString()
                My.Forms.UpdateSub_A.sy.Text = r("School_Year").ToString()
                My.Forms.UpdateSub_A.tim.Text = r("Time").ToString()
                My.Forms.UpdateSub_A.nm.Text = r("No_Minutes").ToString()
                My.Forms.UpdateSub_A.teacher.Text = r("Teacher").ToString()
                My.Forms.UpdateSub_A.SearchSubj_btn.Enabled = False
                My.Forms.UpdateSub_A.subj.Enabled = False
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.UpdateSub_A.subj.Text = ""
                My.Forms.UpdateSub_A.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub updateSubjR_btn()
        Try
            If (My.Forms.UpdateSub_A.gl.Text = "" And My.Forms.UpdateSub_A.sec.Text = "" _
              And My.Forms.UpdateSub_A.nm.Text = "" And My.Forms.UpdateSub_A.teacher.Text = "" _
              And My.Forms.UpdateSub_A.sy.Text = "" And My.Forms.UpdateSub_A.nm.Text = "") Then
                MsgBox("Please enter the empty fields")
            Else
                Dim reg As String = "UPDATE subject_tbl SET Grade_Level = '" & My.Forms.UpdateSub_A.gl.Text & "', Section = '" & My.Forms.UpdateSub_A.sec.Text & "', School_Year = '" & My.Forms.UpdateSub_A.sy.Text & "', Time = '" & My.Forms.UpdateSub_A.tim.Text & "', No_Minutes = '" & My.Forms.UpdateSub_A.nm.Text = "" & "', Teacher = '" & My.Forms.UpdateSub_A.teacher.Text & "'"
                Using cn1 = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                    Using sqlCmd = New MySqlCommand(reg, cn1)
                        cn1.Open()
                        sqlCmd.ExecuteNonQuery()
                        MsgBox("Subject Updated!")
                        My.Forms.UpdateSub_A.gl.Text = ""
                        My.Forms.UpdateSub_A.sec.Text = ""
                        My.Forms.UpdateSub_A.nm.Text = ""
                        My.Forms.UpdateSub_A.teacher.Text = ""
                        My.Forms.UpdateSub_A.sy.Text = ""
                        My.Forms.UpdateSub_A.tim.Text = ""
                        My.Forms.UpdateSub_A.GroupBox2.Enabled = False
                        My.Forms.UpdateSub_A.SearchSubj_btn.Enabled = True
                        My.Forms.UpdateSub_A.subj.Enabled = True
                        My.Forms.UpdateSub_A.subj.Focus()
                        cn1.Close()
                    End Using
                    cn1.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_A_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader

            Dim ViewSubject_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.ViewSubject.subj.SelectedItem & "')"
           cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(ViewSubject_frm, cn)
            r = cmd.ExecuteReader()
            If r.Read Then
                'For form ViewSubject_frm search button
                My.Forms.ViewSubject.gl.Text = r("Grade_Level").ToString()
                My.Forms.ViewSubject.sec.Text = r("Section").ToString()
                My.Forms.ViewSubject.sy.Text = r("School_Year").ToString()
                My.Forms.ViewSubject.tim.Text = r("Time").ToString()
                My.Forms.ViewSubject.nm.Text = r("No_Minutes").ToString()
                My.Forms.ViewSubject.teacher.Text = r("Teacher").ToString()
                cn.Close()
            Else
                MsgBox("EmployeeID not Found!")
                My.Forms.ViewSubject.subj.Text = ""
                My.Forms.ViewSubject.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub deleteSubject_A()
        'not implemented

        Dim reg As String = "DELETE FROM subject_tbl WHERE Subject_Name = '" & My.Forms.DeleteSub_A.subj.Text & "' "
        Try
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()

                    'For form DeleteSub_A delete button
                    My.Forms.DeleteSub_A.gl.Text = ""
                    My.Forms.DeleteSub_A.sec.Text = ""
                    My.Forms.DeleteSub_A.sy.Text = ""
                    My.Forms.DeleteSub_A.tim.Text = ""
                    My.Forms.DeleteSub_A.nm.Text = ""
                    My.Forms.DeleteSub_A.teacher.Text = ""
                    My.Forms.DeleteSub_A.subj.Text = ""
                    My.Forms.DeleteSub_A.SearchSubj_btn.Enabled = True
                    My.Forms.DeleteSub_A.GroupBox2.Enabled = False
                    My.Forms.DeleteSub_A.subj.Enabled = True


                    MsgBox("Subject Deleted!")

                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub deleteSubject_R()
        'not implemented

        Dim reg As String = "DELETE FROM subject_tbl WHERE Subject_Name = '" & My.Forms.DeleteSubj_R.subj.Text & "' "
        Try
            Using cn = New MySqlConnection("server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'")
                Using sqlCmd = New MySqlCommand(reg, cn)
                    cn.Open()
                    sqlCmd.ExecuteNonQuery()


                    'For form DeleteSubj_R delete button
                    My.Forms.DeleteSubj_R.gl.Text = ""
                    My.Forms.DeleteSubj_R.sec.Text = ""
                    My.Forms.DeleteSubj_R.sy.Text = ""
                    My.Forms.DeleteSubj_R.tim.Text = ""
                    My.Forms.DeleteSubj_R.nm.Text = ""
                    My.Forms.DeleteSubj_R.teacher.Text = ""
                    My.Forms.DeleteSubj_R.subj.Text = ""
                    My.Forms.DeleteSubj_R.SearchSubj_btn.Enabled = True
                    My.Forms.DeleteSubj_R.GroupBox2.Enabled = False
                    My.Forms.DeleteSubj_R.subj.Enabled = True
                    MsgBox("Subject Deleted!")

                    cn.Close()
                End Using
                cn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_A_Update_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim UpdateSub_A_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.UpdateSub_A.subj.Text & "')"
            cn.Open()
            Dim cmd1 As MySqlCommand = New MySqlCommand(UpdateSub_A_frm, cn)
            r = cmd1.ExecuteReader()
            If r.Read Then

                'For form UpdateSub_A search button
                My.Forms.UpdateSub_A.gl.Text = r("Grade_Level").ToString()
                My.Forms.UpdateSub_A.sec.Text = r("Section").ToString()
                My.Forms.UpdateSub_A.sy.Text = r("School_Year").ToString()
                My.Forms.UpdateSub_A.tim.Text = r("Time").ToString()
                My.Forms.UpdateSub_A.nm.Text = r("No_Minutes").ToString()
                My.Forms.UpdateSub_A.teacher.Text = r("Teacher").ToString()
                My.Forms.UpdateSub_A.SearchSubj_btn.Enabled = False
                My.Forms.UpdateSub_A.subj.Enabled = False

                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.UpdateSub_A.subj.Text = ""
                My.Forms.UpdateSub_A.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_R_Update_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim UpdateSub_A_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.UpdateSub_R.subj.Text & "')"
            cn.Open()
            Dim cmd1 As MySqlCommand = New MySqlCommand(UpdateSub_A_frm, cn)
            r = cmd1.ExecuteReader()
            If r.Read Then

                'For form UpdateSub_A search button
                My.Forms.UpdateSub_R.gl.Text = r("Grade_Level").ToString()
                My.Forms.UpdateSub_R.sec.Text = r("Section").ToString()
                My.Forms.UpdateSub_R.sy.Text = r("School_Year").ToString()
                My.Forms.UpdateSub_R.tim.Text = r("Time").ToString()
                My.Forms.UpdateSub_R.nm.Text = r("No_Minutes").ToString()
                My.Forms.UpdateSub_R.teacher.Text = r("Teacher").ToString()
                My.Forms.UpdateSub_R.SearchSubj_btn.Enabled = False
                My.Forms.UpdateSub_R.subj.Enabled = False

                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.UpdateSub_R.subj.Text = ""
                My.Forms.UpdateSub_R.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_A_Delete_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim DeleteSubj_R_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.DeleteSubj_R.subj.Text & "')"
            cn.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(DeleteSubj_R_frm, cn)

            r = cmd3.ExecuteReader()
            If r.Read Then


                'For form DeleteSubj_R search button
                My.Forms.DeleteSubj_R.gl.Text = r("Grade_Level").ToString()
                My.Forms.DeleteSubj_R.sec.Text = r("Section").ToString()
                My.Forms.DeleteSubj_R.sy.Text = r("School_Year").ToString()
                My.Forms.DeleteSubj_R.tim.Text = r("Time").ToString()
                My.Forms.DeleteSubj_R.nm.Text = r("No_Minutes").ToString()
                My.Forms.DeleteSubj_R.teacher.Text = r("Teacher").ToString()
                My.Forms.DeleteSubj_R.SearchSubj_btn.Enabled = False
                My.Forms.DeleteSubj_R.subj.Enabled = False
                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.DeleteSubj_R.subj.Text = ""
                My.Forms.DeleteSubj_R.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_R_Delete_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim DeleteSubj_R_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.DeleteSubj_R.subj.Text & "')"
            cn.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(DeleteSubj_R_frm, cn)

            r = cmd3.ExecuteReader()
            If r.Read Then

                'For form DeleteSubj_R search button
                My.Forms.DeleteSubj_R.gl.Text = r("Grade_Level").ToString()
                My.Forms.DeleteSubj_R.sec.Text = r("Section").ToString()
                My.Forms.DeleteSubj_R.sy.Text = r("School_Year").ToString()
                My.Forms.DeleteSubj_R.tim.Text = r("Time").ToString()
                My.Forms.DeleteSubj_R.nm.Text = r("No_Minutes").ToString()
                My.Forms.DeleteSubj_R.teacher.Text = r("Teacher").ToString()
                My.Forms.DeleteSubj_R.SearchSubj_btn.Enabled = False
                My.Forms.DeleteSubj_R.subj.Enabled = False
                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.UpdateSub_A.subj.Text = ""
                My.Forms.UpdateSub_A.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub

    Public Sub SearchSubject_A_View_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim DeleteSubj_R_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.ViewSubject.subj.SelectedItem & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(DeleteSubj_R_frm, cn)

            r = cmd.ExecuteReader()
            If r.Read Then

                'For form DeleteSubj_R search button
                My.Forms.ViewSubject.gl.Text = r("Grade_Level").ToString()
                My.Forms.ViewSubject.sec.Text = r("Section").ToString()
                My.Forms.ViewSubject.sy.Text = r("School_Year").ToString()
                My.Forms.ViewSubject.tim.Text = r("Time").ToString()
                My.Forms.ViewSubject.nm.Text = r("No_Minutes").ToString()
                My.Forms.ViewSubject.teacher.Text = r("Teacher").ToString()
                My.Forms.ViewSubject.SearchSubj_btn.Enabled = False
                My.Forms.ViewSubject.subj.Enabled = False
                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.ViewSubject.subj.Text = ""
                My.Forms.ViewSubject.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchSubject_R_View_btn()
        'not implemented
        Try
            insert()
            Dim r As MySqlDataReader
            Dim DeleteSubj_R_frm As String = "SELECT * FROM subject_tbl WHERE (Subject_Name ='" & My.Forms.ViewSubjectR.subj.SelectedItem & "')"
            cn.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(DeleteSubj_R_frm, cn)

            r = cmd.ExecuteReader()
            If r.Read Then

                'For form DeleteSubj_R search button
                My.Forms.ViewSubjectR.gl.Text = r("Grade_Level").ToString()
                My.Forms.ViewSubjectR.sec.Text = r("Section").ToString()
                My.Forms.ViewSubjectR.sy.Text = r("School_Year").ToString()
                My.Forms.ViewSubjectR.tim.Text = r("Time").ToString()
                My.Forms.ViewSubjectR.nm.Text = r("No_Minutes").ToString()
                My.Forms.ViewSubjectR.teacher.Text = r("Teacher").ToString()
                My.Forms.ViewSubjectR.SearchSubj_btn.Enabled = False
                My.Forms.ViewSubjectR.subj.Enabled = False
                cn.Close()
            Else
                MsgBox("Subject not Found!")
                My.Forms.ViewSubjectR.subj.Text = ""
                My.Forms.ViewSubjectR.subj.Focus()
                cn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cn.Close()
        End Try
    End Sub
    Public Sub SearchStudent_A_Update_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.UpdateStudent_A.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateStudent_A.sn.Text = r("Student_ID_No").ToString()
                My.Forms.UpdateStudent_A.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.UpdateStudent_A.add.Text = r("Address").ToString()
                My.Forms.UpdateStudent_A.bd.Text = r("Birthday").ToString()
                My.Forms.UpdateStudent_A.gl.Text = r("GradeLevel").ToString()
                My.Forms.UpdateStudent_A.con.Text = r("Contact").ToString()
                My.Forms.UpdateStudent_A.sy.Text = r("SchoolYear").ToString()
                My.Forms.UpdateStudent_A.pl.Text = r("Photo").ToString()
                My.Forms.UpdateStudent_A.ag.Text = r("Age").ToString()
                My.Forms.UpdateStudent_A.pl.Text = r("Photo").ToString()

                My.Forms.UpdateStudent_A.add.Enabled = True
                My.Forms.UpdateStudent_A.bd.Enabled = True
                My.Forms.UpdateStudent_A.gl.Enabled = True
                My.Forms.UpdateStudent_A.con.Enabled = True
                My.Forms.UpdateStudent_A.sy.Enabled = True
                My.Forms.UpdateStudent_A.pl.Enabled = True
                My.Forms.UpdateStudent_A.ag.Enabled = True
                My.Forms.UpdateStudent_A.pl.Enabled = True
                My.Forms.UpdateStudent_A.sn.Enabled = False
                My.Forms.UpdateStudent_A.SearchStudent_btn.Enabled = False




                My.Forms.UpdateStudent_A.PictureBox2.Image = Image.FromFile(My.Forms.UpdateStudent_A.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.UpdateStudent_A.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    Public Sub SearchStudent_A_Delete_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.DeleteStudent_A.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.DeleteStudent_A.sn.Text = r("Student_ID_No").ToString()
                My.Forms.DeleteStudent_A.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.DeleteStudent_A.add.Text = r("Address").ToString()
                My.Forms.DeleteStudent_A.bd.Text = r("Birthday").ToString()
                My.Forms.DeleteStudent_A.gl.Text = r("GradeLevel").ToString()
                My.Forms.DeleteStudent_A.con.Text = r("Contact").ToString()
                My.Forms.DeleteStudent_A.sy.Text = r("SchoolYear").ToString()
                My.Forms.DeleteStudent_A.pl.Text = r("Photo").ToString()
                My.Forms.DeleteStudent_A.ag.Text = r("Age").ToString()
                My.Forms.DeleteStudent_A.pl.Text = r("Photo").ToString()

              

                My.Forms.DeleteStudent_A.DeleteButton_a_Student.Enabled = True


                My.Forms.DeleteStudent_A.PictureBox2.Image = Image.FromFile(My.Forms.DeleteStudent_A.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.DeleteStudent_A.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    Public Sub SearchStudent_R_Delete_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.DeleteStudent_R.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.DeleteStudent_R.sn.Text = r("Student_ID_No").ToString()
                My.Forms.DeleteStudent_R.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.DeleteStudent_R.add.Text = r("Address").ToString()
                My.Forms.DeleteStudent_R.bd.Text = r("Birthday").ToString()
                My.Forms.DeleteStudent_R.gl.Text = r("GradeLevel").ToString()
                My.Forms.DeleteStudent_R.con.Text = r("Contact").ToString()
                My.Forms.DeleteStudent_R.sy.Text = r("SchoolYear").ToString()
                My.Forms.DeleteStudent_R.pl.Text = r("Photo").ToString()
                My.Forms.DeleteStudent_R.ag.Text = r("Age").ToString()
                My.Forms.DeleteStudent_R.pl.Text = r("Photo").ToString()
              
                My.Forms.DeleteStudent_R.SearchStudent_btn.Enabled = False

                My.Forms.DeleteStudent_R.DeleteButton_a_Student.Enabled = True


                My.Forms.DeleteStudent_R.PictureBox2.Image = Image.FromFile(My.Forms.DeleteStudent_R.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.DeleteStudent_A.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    Public Sub SearchStudent_r_Update_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.UpdateStudent_R.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.UpdateStudent_R.sn.Text = r("Student_ID_No").ToString()
                My.Forms.UpdateStudent_R.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.UpdateStudent_R.add.Text = r("Address").ToString()
                My.Forms.UpdateStudent_R.bd.Text = r("Birthday").ToString()
                My.Forms.UpdateStudent_R.gl.Text = r("GradeLevel").ToString()
                My.Forms.UpdateStudent_R.con.Text = r("Contact").ToString()
                My.Forms.UpdateStudent_R.sy.Text = r("SchoolYear").ToString()
                My.Forms.UpdateStudent_R.pl.Text = r("Photo").ToString()
                My.Forms.UpdateStudent_R.ag.Text = r("Age").ToString()
                My.Forms.UpdateStudent_R.pl.Text = r("Photo").ToString()

                My.Forms.UpdateStudent_R.add.Enabled = True
                My.Forms.UpdateStudent_R.bd.Enabled = True
                My.Forms.UpdateStudent_R.gl.Enabled = True
                My.Forms.UpdateStudent_R.con.Enabled = True
                My.Forms.UpdateStudent_R.sy.Enabled = True
                My.Forms.UpdateStudent_R.pl.Enabled = True
                My.Forms.UpdateStudent_R.ag.Enabled = True
                My.Forms.UpdateStudent_R.pl.Enabled = True
                My.Forms.UpdateStudent_R.sn.Enabled = False
                My.Forms.UpdateStudent_R.SearchStudent_btn.Enabled = False
                My.Forms.UpdateStudent_R.PictureBox2.Image = Image.FromFile(My.Forms.UpdateStudent_R.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.UpdateStudent_R.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    Public Sub SearchStudent_A_ViewStudent_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.ViewStudent.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.ViewStudent.sn.Text = r("Student_ID_No").ToString()
                My.Forms.ViewStudent.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.ViewStudent.add.Text = r("Address").ToString()
                My.Forms.ViewStudent.bd.Text = r("Birthday").ToString()
                My.Forms.ViewStudent.gl.Text = r("GradeLevel").ToString()
                My.Forms.ViewStudent.con.Text = r("Contact").ToString()
                My.Forms.ViewStudent.sy.Text = r("SchoolYear").ToString()
                My.Forms.ViewStudent.pl.Text = r("Photo").ToString()
                My.Forms.ViewStudent.ag.Text = r("Age").ToString()
                My.Forms.ViewStudent.pl.Text = r("Photo").ToString()

             
                My.Forms.ViewStudent.PictureBox2.Image = Image.FromFile(My.Forms.ViewStudent.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.ViewStudent.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub

    Public Sub SearchStudent_R_ViewStudent_btn()
        'not implemented
        Dim conn As New MySqlConnection ' <---
        ' Me.sn.Text = My.Forms.AdminPanel.TextBox1.Text
        'Me.FormBorderStyle = 0
        Try
            'insert() 'tatanggalin natin to, ang error kasi is yung pag connect sa db. gawa tayo ng sarili.
            conn.ConnectionString = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            Dim r As MySqlDataReader
            Dim reg As String = "SELECT * FROM student_info WHERE (Student_ID_No ='" & My.Forms.ViewStudent_R.sn.Text & "')"
            conn.Open() 'instead na cn1.Open, babaguhin natin. ilalagay natin yung conn na ni declare natin sa taas.
            Dim cmd As MySqlCommand = New MySqlCommand(reg, conn) '<--- dapat gagana na to. haha.
            r = cmd.ExecuteReader()
            If r.Read Then
                My.Forms.ViewStudent_R.sn.Text = r("Student_ID_No").ToString()
                My.Forms.ViewStudent_R.nam.Text = r("LastName").ToString() & ", " & r("GivenName").ToString() & " " & r("MiddleName").ToString() & "."
                My.Forms.ViewStudent_R.add.Text = r("Address").ToString()
                My.Forms.ViewStudent_R.bd.Text = r("Birthday").ToString()
                My.Forms.ViewStudent_R.gl.Text = r("GradeLevel").ToString()
                My.Forms.ViewStudent_R.con.Text = r("Contact").ToString()
                My.Forms.ViewStudent_R.sy.Text = r("SchoolYear").ToString()
                My.Forms.ViewStudent_R.pl.Text = r("Photo").ToString()
                My.Forms.ViewStudent_R.ag.Text = r("Age").ToString()
                My.Forms.ViewStudent_R.pl.Text = r("Photo").ToString()


                My.Forms.ViewStudent_R.PictureBox2.Image = Image.FromFile(My.Forms.ViewStudent_R.pl.Text)
                conn.Close() 'papalitan natin lahat ng cn1 ng conn
            Else
                MsgBox("Student ID not Found!")
                My.Forms.ViewStudent.sn.Focus()
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace) '<-- tanggalin naten yung error.
        End Try
        conn.Close()
    End Sub
    
    'guys, kapag may question kayo, chat lang kayo dun sa chat box, pag hindi ako available, sasagot naman si tolits.
    'pag urgent, you can reach me at my mobile number. okay?
    'God bless us!
End Module