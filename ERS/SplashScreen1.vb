Imports MySql.Data.MySqlClient
Public NotInheritable Class SplashScreen1
    Dim cn As New MySqlConnection
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True
        Try
            prg1.Increment(5)
            If prg1.Value = 100 Then
                splash()
                Me.Close()
            End If
        Catch
            Timer1.Enabled = False
            Dim a As Integer = MsgBox("Database not found! Do you want to retry??", MsgBoxStyle.RetryCancel)
            If (a = MsgBoxResult.Retry) Then
                Dim b As New SplashScreen1
                b.Show()
            ElseIf (a = MsgBoxResult.Cancel) Then
                Me.Close()
            End If
        End Try
    End Sub
End Class
