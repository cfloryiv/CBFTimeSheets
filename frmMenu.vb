Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Public Class frmMenu
    Public ds As New DataSet1
    Public clientID As Integer
    Public TSAdapter As New DataSet1TableAdapters.TSENTRYTableAdapter()
    Public ClientAdapter As New DataSet1TableAdapters.CLIENTTableAdapter()
    Public JobAdapter As New DataSet1TableAdapters.JOBTableAdapter()
    Private Sub EnterTimesheetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnterTimesheetsToolStripMenuItem.Click
        Dim frm As Form = New frmMain
        frm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenJobsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenJobsToolStripMenuItem.Click
        Dim crOpenJobs As New OpenJobs2
        crOpenJobs.SetDataSource(ds)
        crOpenJobs.Refresh()
        CrystalReportViewer1.ReportSource = crOpenJobs
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' get all entries loaded

        TSAdapter.Fill(ds.TSENTRY)
        ClientAdapter.Fill(ds.CLIENT)
        JobAdapter.Fill(ds.JOB)

    End Sub
End Class