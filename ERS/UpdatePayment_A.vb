Public Class UpdatePayment_A

    Private Sub SearchAddpayemt_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAddpayemt_btn.Click

        SearchUpdatePayment_A()
        If midterm.Text = "0" Then
            Payment_grp.Enabled = False
            MsgBox("Already paid!")
            pre_btn.Visible = False
            mid_btn.Visible = False
        End If
    End Sub

    Private Sub pre_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pre_btn.Click
        prelimPay_btn()
        SearchUpdatePayment_A()
        If prelim.Text = "0" Then
            pre_btn.Visible = False
            mid_btn.Visible = True
        End If
        'If fin_btn.Text = "Paid!" Then
        '    MsgBox("Already Paid!")
        'End If
    End Sub

    Private Sub mid_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mid_btn.Click
        midtermPay_btn()
        SearchUpdatePayment_A()
        If midterm.Text = "0" Then
            MsgBox("Already paid!")
            pre_btn.Visible = False
            mid_btn.Visible = False
        End If
    End Sub

    Private Sub UpdatePayment_A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As Integer = total.Text
        Dim a As Integer = rf.Text
        Dim b As Integer = lf.Text
        Dim c As Integer = ef.Text
        Dim d As Integer = gf.Text
        Dim f As Integer = mf.Text
        Dim g As Integer = tf.Text
        t = a + b + c + d + f + g
        total.Text = t
    End Sub
    Private Sub UpadatePayment_A_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub
End Class