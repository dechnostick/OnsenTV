Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Environment.GetCommandLineArgs.Length = 2 Then
            PictureBox1.Controls.Add(Label1)
            Label1.Text = "Žc‚è" & Environment.GetCommandLineArgs(1) & "•ª!"
            PictureBox1.Show()
            Return
        End If

        Visible = False
        Process.Start("OnsenTV.exe", "settings")
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
