Imports System.ComponentModel

Public Class Form1

    Dim WithEvents _worker As New BackgroundWorker

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.Text = "WeatherMan"
        lblStatus.Text = ""
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MsgBox("Enter your location please ...", vbExclamation)
            Return
        End If
        TextBox1.Enabled = False
        Button1.Enabled = False
        Me.UseWaitCursor = True

        _worker.RunWorkerAsync()
    End Sub

    Sub updatePrg(text, value, delay)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() updatePrg(text, value, delay))
        Else
            ProgressBar1.Visible = True
            ProgressBar1.Value = value
            lblStatus.Text = text
            Task.Delay(delay).Wait()
        End If
    End Sub

    Private Sub _worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _worker.DoWork
        Dim t1 As New List(Of Task)

        updatePrg("loading", 3, 500)
        updatePrg("checking location...", 10, 800)
        updatePrg("looking on clouds ..", 30, 1000)
        updatePrg("wait lang ... ", 60, 1000)
        updatePrg("asking kuya kim's opinion ...", 90, 1500)
        updatePrg("done", 100, 500)

    End Sub

    Private Sub _worker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _worker.ProgressChanged

    End Sub

    Private Sub _worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _worker.RunWorkerCompleted
        TextBox1.Enabled = True
        Button1.Enabled = True
        Me.UseWaitCursor = False

        frmDialog.ShowDialog(Me)

        lblStatus.Text = ""
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub
End Class
