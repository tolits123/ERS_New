Imports System.IO
Imports System.Drawing.Imaging
Public Class DeleteStudent_R
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Screen_Registrar.Show()
        RegistrarPanel.Show()
        Me.Close()
    End Sub
    Private Sub DeleteStudent_R_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Registrar.Show()
        RegistrarPanel.Show()
    End Sub

    Private Sub SearchStudent_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStudent_btn.Click
        SearchStudent_R_Delete_btn()
        PictureBox2.Image = base64toimage(pl.Text)
    End Sub

    Public Function base64toimage(ByVal base64code As String) As Image
        Dim imagebyte As Byte() = Convert.FromBase64String(base64code)
        Dim ms As New MemoryStream(imagebyte, 0, imagebyte.Length)
        Dim tmpImage As Image = Image.FromStream(ms, True)
        Return tmpImage
    End Function

    Private Sub DeleteButton_a_Student_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton_a_Student.Click
        dropstudR()
    End Sub
End Class