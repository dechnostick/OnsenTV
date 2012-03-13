Imports Microsoft.Win32.Registry
Imports Microsoft.Win32

Public Class Form1

    Private Const TITLE As String = "温泉旅館TV"

    Private Const FIREFOX As String = "Firefox"
    Private Const CHROME As String = "Chrome"
    Private Const SAFARI As String = "Safari"
    Private Const OPERA As String = "Opera"
    Private Const IE As String = "IE"

    Private FIREFOX_PATH As String
    Private CHROME_PATH As String
    Private SAFARI_PATH As String
    Private OPERA_PATH As String

    Private Const UNINST_PATH As String = "Software\Microsoft\Windows\CurrentVersion\Uninstall"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ShowSettings()

        If My.Settings.Browser.Equals(String.Empty) Then
            Return
        End If

        If Environment.GetCommandLineArgs.Length = 2 Then

            Return
        End If

        ShowBrowser()
    End Sub

    Private Sub ShowSettings()

        Dim browser As String = My.Settings.Browser
        RadioButtonFF.Checked = browser.Equals(FIREFOX)
        RadioButtonSF.Checked = browser.Equals(SAFARI)
        RadioButtonGC.Checked = browser.Equals(CHROME)
        RadioButtonOP.Checked = browser.Equals(OPERA)
        RadioButtonIE.Checked = browser.Equals(IE)

        NumericUpDown制限時間.Value = My.Settings.Limit
        NumericUpDown待ち時間.Value = My.Settings.Wait
        CheckBoxSound.Checked = My.Settings.Sound

        If browser.Equals(String.Empty) Then
            NumericUpDown制限時間.Value = 10
            NumericUpDown待ち時間.Value = 5
        End If

        Dim regkey As RegistryKey = CurrentUser.OpenSubKey(UNINST_PATH, False)
        Dim sk As String = "InstallLocation"

        For Each s As String In regkey.GetSubKeyNames

            Dim subkey As RegistryKey = CurrentUser.OpenSubKey(UNINST_PATH & "\" & s, False)

            If Not subkey Is Nothing Then

                Dim displayName As String = subkey.GetValue("DisplayName").ToString

                If Not displayName Is Nothing Then

                    If displayName.ToString().Contains(CHROME) Then
                        CHROME_PATH = subkey.GetValue(sk).ToString & "\" & CHROME & ".exe"
                        RadioButtonGC.Enabled = True
                    End If
                End If
            End If
        Next

        regkey = LocalMachine.OpenSubKey(UNINST_PATH, False)
        For Each s As String In regkey.GetSubKeyNames

            Dim subkey As RegistryKey = LocalMachine.OpenSubKey(UNINST_PATH & "\" & s, False)

            Dim displayName As Object = subkey.GetValue("DisplayName")

            If Not displayName Is Nothing Then

                If displayName.ToString().Contains(FIREFOX) Then
                    FIREFOX_PATH = subkey.GetValue(sk).ToString & "\" & FIREFOX & ".exe"
                    RadioButtonFF.Enabled = True
                End If

                If displayName.ToString().Contains(SAFARI) Then
                    SAFARI_PATH = subkey.GetValue(sk).ToString & "\" & SAFARI & ".exe"
                    RadioButtonSF.Enabled = True
                End If

                If displayName.ToString().Contains(OPERA) Then
                    OPERA_PATH = subkey.GetValue(sk).ToString & "\" & OPERA & ".exe"
                    RadioButtonOP.Enabled = True
                End If
            End If
        Next
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        My.Settings.Limit = Decimal.ToInt32(NumericUpDown制限時間.Value)
        My.Settings.Wait = Decimal.ToInt32(NumericUpDown待ち時間.Value)
        My.Settings.Sound = CheckBoxSound.Checked

        Dim browser As String = String.Empty
        If RadioButtonFF.Checked Then browser = FIREFOX
        If RadioButtonSF.Checked Then browser = SAFARI
        If RadioButtonGC.Checked Then browser = CHROME
        If RadioButtonOP.Checked Then browser = OPERA
        If RadioButtonIE.Checked Then browser = IE

        My.Settings.Browser = browser
        My.Settings.Save()

        ShowBrowser()
    End Sub

    Private Sub ShowBrowser()

        If Not CanProcessStart() Then
            Return
        End If

        Visible = False

        Dim minutes As Integer = GetLastExecutedTime()
        Dim wait As Integer = My.Settings.Wait

        If 0 = minutes Then
            MessageBox.Show("さっき起動したばっかりだよ！！", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Dispose()
            Return
        ElseIf 0 < minutes And minutes < wait Then
            MessageBox.Show(minutes & " 分前に起動したばっかりだよ！！", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Dispose()
            Return
        End If

        Dim stream As IO.Stream = Nothing
        Dim player As Media.SoundPlayer = Nothing
        Dim p As Process = Nothing
        Dim iexplore As SHDocVw.InternetExplorer = Nothing

        Try
            Dim browser As String = My.Settings.Browser
            Dim path As String = String.Empty
            If browser.Equals(FIREFOX) Then path = FIREFOX_PATH
            If browser.Equals(SAFARI) Then path = SAFARI_PATH
            If browser.Equals(CHROME) Then path = CHROME_PATH
            If browser.Equals(OPERA) Then path = OPERA_PATH
            If browser.Equals(IE) Then path _
                = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) _
                & "\Internet Explorer\iexplore.exe"

            If browser.Equals(IE) Then
                iexplore = New SHDocVw.InternetExplorer()
                iexplore.Visible = True
                For Each pp As Process In Process.GetProcesses()
                    If pp.ProcessName.Equals("iexplore") Then
                        p = pp
                        Exit For
                    End If
                Next
            Else
                p = Process.Start(path)
            End If

            If My.Settings.Sound Then
                stream = My.Resources.bgm_coinin_1
                player = New Media.SoundPlayer(stream)
                player.PlaySync()
            End If

            Dim limit As Integer = My.Settings.Limit
            For i As Integer = 0 To 60 * limit
                Threading.Thread.Sleep(1000)

                If p.HasExited Then
                    Exit For
                End If

                If ((limit * 60) - i = 600) Then
                    Process.Start("SetOnsenTV.exe", "10")
                ElseIf ((limit * 60) - i = 300) Then
                    Process.Start("SetOnsenTV.exe", "5")
                End If
            Next

            While Not p.HasExited
                If Not iexplore Is Nothing Then
                    iexplore.Quit()
                End If
                p.CloseMainWindow()
                p.WaitForExit(1000 * 5)
            End While

            If My.Settings.Sound Then
                stream = My.Resources.bgm_gameover_1
                player.Stream = stream
                player.PlaySync()
            End If

            My.Settings.LastExecutedTime = DateTime.Now
        Finally

            If Not p Is Nothing Then
                p.Close()
                p.Dispose()
            End If

            If Not player Is Nothing Then
                player.Dispose()
            End If

            If Not stream Is Nothing Then
                stream.Close()
                stream.Dispose()
            End If

            Close()
            Dispose()
        End Try
    End Sub

    Private Function CanProcessStart() As Boolean

        Dim browser As String = My.Settings.Browser
        Dim processName As String = String.Empty
        Dim errorMessage As String = String.Empty

        Select Case browser

            Case FIREFOX
                processName = "firefox"
                errorMessage = "Mozilla Firefox は既に起動済みです。"

            Case SAFARI
                processName = "safari"
                errorMessage = "Safari は既に起動済みです。"

            Case CHROME
                processName = "chrome"
                errorMessage = "Google Chrome は既に起動済みです。"

            Case OPERA
                processName = "opera"
                errorMessage = "Opera は既に起動済みです。"

            Case Else
                processName = "iexplore"
                errorMessage = "Internet Explorer は既に起動済みです。"
        End Select

        For Each p As Process In Process.GetProcesses()
            If p.ProcessName.Equals(processName) Then
                MessageBox.Show(errorMessage, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

    Private Function GetLastExecutedTime() As Integer

        My.Settings.Upgrade()

        Dim lastExecutedTime As Date = My.Settings.LastExecutedTime

        If Not lastExecutedTime = Date.MinValue Then

            Return CType(DateTime.Now.Subtract(lastExecutedTime).TotalMinutes, Integer)
        Else
            Return -1
        End If
    End Function

    Private Sub Buttonキャンセル_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonキャンセル.Click
        Close()
    End Sub
End Class
