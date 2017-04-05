Imports System.IO
Imports System.Drawing.Imaging
Public Class UpdateStudent_A
    Dim encodeType As ImageFormat = ImageFormat.Jpeg
    Dim decoding As String = String.Empty

    Private Sub SearchStudent_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStudent_btn.Click
        SearchStudent_A_Update_btn()
        PictureBox2.Image = base64toimage(pl.Text)
    End Sub

    Public Function base64toimage(ByVal base64code As String) As Image
        Dim imagebyte As Byte() = Convert.FromBase64String(base64code)
        Dim ms As New MemoryStream(imagebyte, 0, imagebyte.Length)
        Dim tmpImage As Image = Image.FromStream(ms, True)
        Return tmpImage
    End Function

    Private Sub UpdateButton_a_Student_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton_a_Student.Click
        editstud()
    End Sub
    Private Sub UpdateStudent_A_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Screen_Admin.Show()
        AdminPanel.Show()
        Me.Close()
    End Sub
End Class