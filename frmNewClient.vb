Public Class frmNewClient


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dr As DataSet1.CLIENTRow
        Dim ds = frmMenu.ds

        dr = ds.CLIENT.NewCLIENTRow

        dr.Item("Name") = txtName.Text
        dr.Item("Date") = Date.Now
        dr.Item("Phone") = txtPhone.Text
        dr.Item("Email") = txtEmail.Text

        ds.CLIENT.Rows.Add(dr)

        Close()
    End Sub

    Private Sub frmNewClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class