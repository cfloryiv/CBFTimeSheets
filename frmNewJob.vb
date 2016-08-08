Public Class frmNewJob
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtHourlyRate.TextChanged

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dr As DataSet1.JOBRow
        Dim ds = frmMenu.ds
        Dim clientID As Integer = frmMenu.clientID
        dr = ds.JOB.NewJOBRow

        dr.Item("Desc") = txtDesc.Text
        dr.Item("Date") = Date.Now
        dr.Item("Phone") = txtPhone.Text
        dr.Item("Email") = txtEmail.Text
        Try
            dr.Item("EstHours") = CType(txtEstHours.Text, Decimal)
        Catch ex As Exception
            dr.Item("EstHours") = 0
        End Try
        Try
            dr.Item("Budget") = CType(txtBudget.Text, Decimal)
        Catch ex As Exception
            dr.Item("Budget") = 0
        End Try
        Try
            dr.Item("HourlyRate") = CType(txtHourlyRate.Text, Decimal)
        Catch ex As Exception
            dr.Item("HourlyRate") = 0
        End Try

        dr.Item("ClientID") = clientID
        dr.Item("Complete") = "N"

        ds.JOB.Rows.Add(dr)

        Close()
    End Sub
End Class