Public Class frmMain

    Dim jobID As Integer
    Dim ID As Integer
    Dim ds = frmMenu.ds



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        clearScreen()

    End Sub

    Sub clearScreen()

        txtNotes.Text = ""
        txtDate.Text = Date.Now.ToShortDateString()
        txtHours.Text = 0.00
        txtComplete.Text = "N"
        rebuildClientList()

    End Sub
    Sub rebuildClientList()
        ' rebuild list of clients in listbox
        Dim dr() As DataRow = ds.CLIENT.Select(True)
        lbClient.Items.Clear()
        For ii As Integer = 0 To dr.GetUpperBound(0)
            Dim name As String = dr(ii).Item("Name")
            lbClient.Items.Add(name)
        Next
    End Sub
    Sub rebuildJobList()
        ' rebuild list of jobs for the current client
        Dim clientName As String
        clientName = lbClient.SelectedItem.ToString()
        Dim dr() As DataRow = ds.JOB.Select($" clientID = '{frmMenu.clientID}'")
        lbJob.Items.Clear()
        For ii As Integer = 0 To dr.GetUpperBound(0)
            Dim desc As String = dr(ii).Item("Desc")
            lbJob.Items.Add(desc)
        Next

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        clearScreen()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' save all changes to database
        frmMenu.TSAdapter.Update(ds.TSENTRY)
        frmMenu.ClientAdapter.Update(ds.CLIENT)
        frmMenu.JobAdapter.Update(ds.JOB)

        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' save this timesheet entry
        Dim dr As DataSet1.TSENTRYRow

        dr = ds.TSENTRY.NewTSENTRYRow

        dr("ClientID") = frmMenu.clientID
        dr("JobID") = jobID
        dr("Date") = txtDate.Text
        dr("Hours") = CType(txtHours.Text, Decimal)
        dr("Notes") = txtNotes.Text

        ds.TSENTRY.Rows.Add(dr)

        clearScreen()
    End Sub

    Private Sub txtClient_TextChanged(sender As Object, e As EventArgs)
        ' get the client id
        Dim clientName As String
        clientName = lbClient.SelectedItem.ToString()
        Dim dr() As DataRow = ds.CLIENT.Select($" Name = '{clientName}'")
        frmMenu.clientID = 0
        For ii As Integer = 0 To dr.GetUpperBound(0)
            frmMenu.clientID = dr(ii).Item("ClientID")
        Next
        rebuildJobList()
    End Sub

    Private Sub txtJob_TextChanged(sender As Object, e As EventArgs)
        ' get the job id
    End Sub

    Private Sub btnNewClient_Click(sender As Object, e As EventArgs) Handles btnNewClient.Click
        ' setup a new client form
        Dim frm As Form = New frmNewClient()
        frm.ShowDialog()

        rebuildClientList()
    End Sub

    Private Sub btnNewJob_Click(sender As Object, e As EventArgs) Handles btnNewJob.Click
        ' setup a new job for this client
        Dim frm As Form = New frmNewJob()
        frm.ShowDialog()

        rebuildJobList()
    End Sub

    Private Sub lbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbClient.SelectedIndexChanged
        ' get the client id
        Dim clientName As String
        clientName = lbClient.SelectedItem.ToString()
        Dim dr() As DataRow = ds.CLIENT.Select($" Name = '{clientName}'")
        frmMenu.clientID = 0
        For ii As Integer = 0 To dr.GetUpperBound(0)
            frmMenu.clientID = dr(ii).Item("ClientID")
        Next
        rebuildJobList()
    End Sub

    Private Sub lbJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbJob.SelectedIndexChanged
        Dim jobDesc As String
        jobDesc = lbJob.SelectedItem.ToString()
        Dim dr() As DataRow = ds.JOB.select($"Desc = '{jobDesc}'")
        jobID = 0
        For ii As Integer = 0 To dr.GetUpperBound(0)
            jobID = dr(ii).Item("JobID")
        Next
    End Sub
End Class
