Imports AForge
Imports AForge.Video.DirectShow
Imports AForge.Video
Imports System.IO
Public Class Webcam
    Public CAMERA As VideoCaptureDevice
    Public bmp As Bitmap
    Private Sub Webcam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CAMERA = cameras.VideoDevice
            AddHandler CAMERA.NewFrame, New NewFrameEventHandler(AddressOf Captured)
            CAMERA.Start()
        ElseIf cameras.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            AdminCreate.Enabled = True
        End If
    End Sub
    Private Sub Captured(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        bmp = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub

    Private Sub capture_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles capture_btn.Click

        PictureBox1.Image = PictureBox1.Image
        CAMERA.Stop()
        'Dim Path As String
        'Path = SaveFileDialog1.FileName
        Dim a As Integer = MsgBox("Do you want to take again?", MsgBoxStyle.YesNo)
        If (a = MsgBoxResult.Yes) Then
            Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
            If cameras.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CAMERA = cameras.VideoDevice
                AddHandler CAMERA.NewFrame, New NewFrameEventHandler(AddressOf Captured)
                CAMERA.Start()
            ElseIf cameras.ShowDialog() = Windows.Forms.DialogResult.Cancel Then

            End If
        ElseIf (a = MsgBoxResult.No) Then
            Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm

            SaveFileDialog1.DefaultExt = ".jpg"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                SaveFileDialog1.Title = "Save an Image File"
                PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                My.Forms.AdminCreate.pl.Text = SaveFileDialog1.FileName
                My.Forms.AdminCreate.PictureBox1.Image = Image.FromFile(My.Forms.AdminCreate.pl.Text)
                My.Forms.AdminCreate.pl.Text = ""

                My.Forms.AdminCreate_1.pl.Text = SaveFileDialog1.FileName
                My.Forms.AdminCreate_1.PictureBox1.Image = Image.FromFile(My.Forms.AdminCreate_1.pl.Text)
                My.Forms.AdminCreate_1.pl.Text = ""

                My.Forms.CashierCreate.pl.Text = SaveFileDialog1.FileName
                My.Forms.CashierCreate.PictureBox1.Image = Image.FromFile(My.Forms.CashierCreate.pl.Text)
                My.Forms.CashierCreate.pl.Text = ""

                My.Forms.RegistrarCreate.pl.Text = SaveFileDialog1.FileName
                My.Forms.RegistrarCreate.PictureBox1.Image = Image.FromFile(My.Forms.RegistrarCreate.pl.Text)
                My.Forms.RegistrarCreate.pl.Text = ""

                My.Forms.StudentCreate.pl.Text = SaveFileDialog1.FileName
                My.Forms.StudentCreate.PictureBox1.Image = Image.FromFile(My.Forms.StudentCreate.pl.Text)
                My.Forms.StudentCreate.pl.Text = ""


                AdminCreate.Enabled = True
                AdminCreate_1.Enabled = True
                CashierCreate.Enabled = True
                RegistrarCreate.Enabled = True
                StudentCreate.Enabled = True
                Me.Close()
            End If
            End If
    End Sub
    Private Sub Webcam_Closing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            CAMERA.Stop()
        Catch



        End Try

        AdminCreate.Enabled = True
        AdminCreate_1.Enabled = True
        CashierCreate.Enabled = True
        RegistrarCreate.Enabled = True
        StudentCreate.Enabled = True
    End Sub
End Class