﻿'Imports AForge
'Imports AForge.Video
'Imports AForge.Video.DirectShow
Imports System.IO
Public Class AdminCreate
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AdminPanel.Show()
        Me.Close()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AdminPanel.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        createAdmin()
    End Sub

    Private Sub AdminCreate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.FormBorderStyle = 0
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Webcam.Show()

        Me.Enabled = False
    End Sub
End Class