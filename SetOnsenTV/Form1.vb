Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Environment.GetCommandLineArgs.Length = 2 Then
            Me.PictureBox1.Controls.Add(Me.Label1)
            Me.Label1.Text = "écÇË" & Environment.GetCommandLineArgs(1) & "ï™!"
            Me.PictureBox1.Show()
            Return
        End If

        Me.Visible = False
        Process.Start("â∑êÚó∑äŸTV.exe", "settings")
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
