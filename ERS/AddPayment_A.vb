Public Class AddPayment_A

    Private Sub AddPayment_A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        'Dim tuition As Integer
        'tuition = t / 3

        'prelim.Text = tuition
        'midterm.Text = tuition
        'finals.Text = tuition



    End Sub

    Private Sub fp_rdobnt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fp_rdobnt.CheckedChanged
        Payment_grp.Text = "Full payment"
        partialp.Text = ""
        Dim t As Integer = total.Text
        total.Text = t

        EnterPartial_grp.Enabled = False
        Dim tuition As Integer
        tuition = t / 2
            Proceed_btn.Enabled = True
        prelim.Text = tuition
        midterm.Text = tuition
        total1.Text = "-"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If fp_rdobnt.Checked = True Then
            pp_rdbnt.Checked = False
            Proceed_btn.Enabled = True

        ElseIf pp_rdbnt.Checked = True Then
            fp_rdobnt.Checked = False
            Proceed_btn.Enabled = False

            Dim tuition As Integer
            Dim partialpayment As Integer
            Dim total1 As Integer
            Dim tuition1 As Integer
            tuition = total.Text
            partialpayment = partialp.Text

            total1 = tuition - partialpayment

            tuition1 = total1 / 2

            prelim.Text = tuition1
            midterm.Text = tuition1
        End If

        EnterPartial_grp.Enabled = False
        Proceed_btn.Enabled = True
       
    End Sub
    Private Sub AddPayment_A_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Screen_Admin.Show()
        AdminPanel.Show()
    End Sub

    Private Sub pp_rdbnt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pp_rdbnt.CheckedChanged
        EnterPartial_grp.Enabled = True
        Payment_grp.Text = "Partial payment"
        Proceed_btn.Enabled = False
        prelim.Text = "-"
        midterm.Text = "-"
        Dim t As Integer = total.Text
        total.Text = t
        total1.Text = total.Text
    End Sub

    Private Sub SearchAddpayemt_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAddpayemt_btn.Click
        Try
            SearchAddPayment_A()
            If grade.Text = "Grade 1" Then

            ElseIf grade.Text = "Grade 2" Then




            End If







        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


    Private Sub Proceed_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Proceed_btn.Click
        If fp_rdobnt.Checked = True Then
            FullPayment_A()
            Proceed_btn.Enabled = True
            EnterPartial_grp.Enabled = False
            Payment_grp.Enabled = False
            fp_rdobnt.Enabled = False
            pp_rdbnt.Enabled = False
            miscellaneous_fee_grp.Enabled = False
            total1.Text = ""
            total.Text = ""
            sn.Enabled = True
            SearchAddpayemt_btn.Enabled = True
            sn.Text = ""
            prelim.Text = "-"
            midterm.Text = "-"
        ElseIf pp_rdbnt.Checked = True Then
            Proceed_btn.Enabled = False
            PartialPayment_A()
            partialp.Text = ""
            EnterPartial_grp.Enabled = False
            Payment_grp.Enabled = False
            fp_rdobnt.Enabled = False
            pp_rdbnt.Enabled = False
            miscellaneous_fee_grp.Enabled = False
            sn.Enabled = True
            SearchAddpayemt_btn.Enabled = True
            total1.Text = ""
            total.Text = ""
            sn.Text = ""
            prelim.Text = "-"
            midterm.Text = "-"
        End If
        nameOS.Text = "---"
        grade.Text = "---"
        Proceed_btn.Enabled = False
  
  End Sub

    Private Sub enterTuition_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enterTuition_btn.Click
        partialp.Text = ""
        Dim t As Integer = total.Text
        total.Text = t
        total1.Text = total.Text
        fp_rdobnt.Enabled = True
        pp_rdbnt.Enabled = True


    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

<<<<<<< HEAD
        End If
    End Sub
    Private Sub subjandbooksComputation()
        Dim total As Integer
        Dim il As Integer = IdLace.Text
        Dim pat As Integer = Patch.Text
        Dim s1 As Integer = p1.Text
        Dim s2 As Integer = p2.Text
        Dim s3 As Integer = p3.Text
        Dim s4 As Integer = p4.Text
        Dim s5 As Integer = p5.Text
        Dim s6 As Integer = p6.Text
        Dim s7 As Integer = p7.Text
        Dim s8 As Integer = p8.Text
        Dim s9 As Integer = p9.Text
        total = il + pat + s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9

        'comment
        totalBooks.Text = total
=======
>>>>>>> parent of fbcd98c... [04032017] Updated Payment_frm, AdminUpdate_frm, CashierUpdate_frm, RegistrarUpdate_frm
    End Sub
End Class