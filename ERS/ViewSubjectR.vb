Imports MySql.Data.MySqlClient

Public Class ViewSubjectR

    Private Sub ViewSubjectR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        insert()
        Dim r As MySqlDataReader
        Dim reg As String = "SELECT Subject_Name FROM subject_tbl"
        cn.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(reg, cn)
        r = cmd.ExecuteReader()
        If r.Read Then

            subj.Items.Clear()
            subj.Items.Add(r("Subject_Name").ToString())
            While (r.Read())
                subj.Items.Add(r("Subject_Name").ToString())
            End While
        Else
            MessageBox.Show("No subject Found")
        End If
    End Sub

    Private Sub SearchSubj_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchSubj_btn.Click
        cn.Close()
        SearchSubject_R_View_btn()
    End Sub
End Class