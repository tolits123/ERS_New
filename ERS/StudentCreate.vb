Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class StudentCreate



    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pl.Text = ""
        Try
            If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
                pl.Text = OpenFileDialog1.FileName
            End If
            PictureBox1.Image = Image.FromFile(pl.Text)
        Catch
            MsgBox("Please select picture.")
            pl.Text = ""
            PictureBox1.Image = PictureBox1.ErrorImage
        End Try
    End Sub
    Public Function imagetobase64(ByVal image As Image, ByVal format As ImageFormat) As String
        Using ms As New MemoryStream()
            image.Save(ms, format)
            Dim imageByte As Byte() = ms.ToArray()
            Dim base64String As String = Convert.ToBase64String(imageByte)
            Return base64String
        End Using
    End Function
    Public Shared Function ag(ByVal DOfB As Object) As String
        If (Month(Date.Today) * 100) + Date.Today.Day >= (Month(DOfB) * 100) + DOfB.Day Then
            Return DateDiff(DateInterval.Year, DOfB, Date.Today)
        Else
            Return DateDiff(DateInterval.Year, DOfB, Date.Today) - 1
        End If
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudentCreateEnrollBtn.Click
        If (cont.Text = "" Or pl.Text = "" Or age.Text = "" Or sn.Text = "" Or gen.SelectedItem = "" Or ln.Text = "" Or fn.Text = "" Or mn.Text = "" Or add.Text = "" Or pi.Text = "" Or rel.Text = "" Or citi.Text = "" Or sy.Text = "" Or gl.Text = "" Or mon.Text = "" Or mono.Text = "" Or fon.Text = "" Or fono.Text = "" Or gdn.Text = "" Or rl.Text = "") Then
            MsgBox("Please fill the empty fields!")
        Else
            Dim encodingtypestring As String = String.Empty
            Try
                If PictureBox1.ImageLocation.ToLower.EndsWith(".jpg") Then
                    encodeType = ImageFormat.Jpeg
                    encodingtypestring = "data:image/jpeg:base64,"
                ElseIf PictureBox1.ImageLocation.ToLower.EndsWith(".png") Then
                    encodeType = ImageFormat.Png
                    encodingtypestring = "data:image/png:base64,"
                End If
            Catch
            End Try
            decoding = encodingtypestring
            pl.Text = encodingtypestring & imagetobase64(PictureBox1.Image, encodeType)



            Dim objConn As New MySqlConnection
            Dim ins As New MySqlCommand
            Dim cn = "server= '" & server & "'; userid= '" & user & "'; port= '" & port & "';password= '" & password & "';database='" & database & "'"
            objConn.ConnectionString = cn
            objConn.Open()
            Try
                ins.Connection = objConn
                ins.CommandText = "INSERT INTO student_info VALUES(@Photo, @Student_ID_No, @LastName, @GivenName, @MiddleName, @Birthday, @Birth_Place, @Gender, @Address, @Age, @Citizenship, @Religion, @SchoolYear, @GradeLevel, @Scholar, @MotherName, @OccupationM, @FatherName, @OccupationF, @Guardian, @Relation, @Contact, @NSO, @Baptismal, @Name_Of_LastSchool, Address_of_LastSchool, @UploadCard, @UploadForm137, @UploadGoodMoral)"
                ins.Parameters.AddWithValue("@Photo", pl.Text)
                ins.Parameters.AddWithValue("@Student_ID_No", sn.Text)
                ins.Parameters.AddWithValue("@LastName", ln.Text)
                ins.Parameters.AddWithValue("@GivenName", fn.Text)
                ins.Parameters.AddWithValue("@MiddleName", mn.Text)
                ins.Parameters.AddWithValue("@Birthday", bd.Text)
                ins.Parameters.AddWithValue("@Birth_Place", bp.Text)
                ins.Parameters.AddWithValue("@Gender", gen.SelectedItem.ToString)
                ins.Parameters.AddWithValue("@Address", add.Text)
                ins.Parameters.AddWithValue("@Age", age.Text)
                ins.Parameters.AddWithValue("@Citizenship", citi.Text)
                ins.Parameters.AddWithValue("@Religion", rel.Text)
                ins.Parameters.AddWithValue("@SchoolYear", sy.Text)
                ins.Parameters.AddWithValue("@GradeLevel", gl.SelectedItem.ToString)
                ins.Parameters.AddWithValue("@Scholar", scho.Text)
                ins.Parameters.AddWithValue("@MotherName", mon.Text)
                ins.Parameters.AddWithValue("@OccupationM", mono.Text)
                ins.Parameters.AddWithValue("@FatherName", fon.Text)
                ins.Parameters.AddWithValue("@OccupationF", fono.Text)
                ins.Parameters.AddWithValue("@Guardian", gdn.Text)
                ins.Parameters.AddWithValue("@Relation", rl.Text)
                ins.Parameters.AddWithValue("@Contact", cont.Text)
                ins.Parameters.AddWithValue("@NSO", nso.Text)
                ins.Parameters.AddWithValue("@Baptismal", bap.Text)
                ins.Parameters.AddWithValue("@Name_Of_LastSchool", nols.Text)
                ins.Parameters.AddWithValue("@Address_of_LastSchool", bap.Text)
                ins.Parameters.AddWithValue("@UploadCard", bc.Text)
                ins.Parameters.AddWithValue("@UploadForm137", frm137.Text)
                ins.Parameters.AddWithValue("@UploadGoodMoral", gmr.Text)
                ins.ExecuteNonQuery()
                MsgBox("Student Added!!")
                AddSubClear()
                objConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub bd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bd.ValueChanged
        age.Text = ag(bd.Value)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudentCreateBackBtn.Click
        AdminPanel.Show()
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            scho.Text = "Yes"
        ElseIf (CheckBox1.Checked = False) Then
            scho.Text = "No"
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddSubject.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If (CheckBox2.Checked = True) Then
            Try
                If (OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    nso.Text = OpenFileDialog2.FileName
                    OpenFileDialog2.FileName = nso.Text
                End If
            Catch
                MsgBox("Please select picture.")
                nso.Text = ""
            End Try
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If (CheckBox3.Checked = True) Then
            Try
                If (OpenFileDialog3.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    bc.Text = OpenFileDialog3.FileName
                    OpenFileDialog2.FileName = bc.Text
                End If
            Catch
                MsgBox("Please select picture.")
                bap.Text = ""
            End Try
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If (CheckBox4.Checked = True) Then
            Try
                If (OpenFileDialog4.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    bap.Text = OpenFileDialog4.FileName
                    OpenFileDialog2.FileName = bap.Text
                End If
            Catch
                MsgBox("Please select picture.")
                bc.Text = ""
            End Try
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If (CheckBox2.Checked = True) Then
            Try
                If (OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    nso.Text = OpenFileDialog2.FileName
                    OpenFileDialog2.FileName = gmr.Text
                End If
            Catch
                MsgBox("Please select picture.")
                nso.Text = ""
            End Try
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If (CheckBox2.Checked = True) Then
            Try
                If (OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    nso.Text = OpenFileDialog2.FileName
                    OpenFileDialog2.FileName = frm137.Text
                End If
            Catch
                MsgBox("Please select picture.")
                nso.Text = ""
            End Try
        End If
    End Sub

    Private Sub Transferee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Transferee.CheckedChanged
        If (Transferee.Checked = True) Then
            nols.Enabled = True
            CheckBox3.Enabled = True
            CheckBox5.Enabled = True
            CheckBox6.Enabled = True
        ElseIf (Transferee.Checked = False) Then
            nols.Enabled = False
            CheckBox3.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Webcam.Show()
        Me.Enabled = False
    End Sub
End Class