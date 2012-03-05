Imports System.Runtime.InteropServices

Public Class Form1

    Private Const TITLE As String = "温泉旅館TV"

    Private Const OPERA As String = "OP"
    Private Const CHROME As String = "GC"
    Private Const FIREFOX As String = "FF"
    Private Const IE As String = "IE"

    Private Const UNINST_PATH As String = "Software\Microsoft\Windows\CurrentVersion\Uninstall"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.Browser.Equals(String.Empty) Then
            Me.ShowSettings()
            Return
        End If

        If Environment.GetCommandLineArgs.Length = 2 Then
            Me.ShowSettings()
            Return
        End If

        Me.ShowBrowser()
    End Sub

    Private Sub ShowSettings()

        Me.RadioButtonGC.Enabled = Not Me.GetChromePath().Equals(String.Empty)
        Me.RadioButtonFF.Enabled = Not Me.GetFirefoxPath().Equals(String.Empty)
        Me.RadioButtonOP.Enabled = Not Me.GetOperaPath().Equals(String.Empty)

        Dim isDefault As Boolean = False

        Dim browser As String = My.Settings.Browser

        Select Case browser

            Case OPERA
                Me.RadioButtonOP.Checked = True

            Case CHROME
                Me.RadioButtonGC.Checked = True

            Case FIREFOX
                Me.RadioButtonFF.Checked = True

            Case IE
                Me.RadioButtonIE.Checked = True

            Case Else
                Me.RadioButtonIE.Checked = True
                isDefault = True
        End Select

        Dim limit As Integer = My.Settings.Limit
        Me.NumericUpDown制限時間.Value = limit

        Dim wait As Integer = My.Settings.Wait
        Me.NumericUpDown待ち時間.Value = wait

        Me.CheckBoxSound.Checked = My.Settings.Sound

        If isDefault Then
            Me.NumericUpDown制限時間.Value = 10
            Me.NumericUpDown待ち時間.Value = 5
        End If
    End Sub

    Private Function GetChromePath() As String

        Dim regkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey(UNINST_PATH, False)

        If regkey Is Nothing Then
            Return String.Empty
        End If

        For Each s As String In regkey.GetSubKeyNames
            Dim subkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(UNINST_PATH & "\" & s, False)

            Dim displayName As String = subkey.GetValue("DisplayName").ToString
            If Not displayName Is Nothing Then

                If displayName.Contains("Chrome") Then
                    Return subkey.GetValue("InstallLocation").ToString
                End If
            End If
        Next
        Return String.Empty
    End Function

    Private Function GetFirefoxPath() As String

        Dim regkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.LocalMachine.OpenSubKey(UNINST_PATH, False)

        If regkey Is Nothing Then
            Return String.Empty
        End If

        For Each s As String In regkey.GetSubKeyNames
            Dim subkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(UNINST_PATH & "\" & s, False)

            Dim displayName As String = subkey.GetValue("DisplayName").ToString
            If Not displayName Is Nothing Then

                If displayName.Contains("Firefox") Then
                    Return subkey.GetValue("InstallLocation").ToString
                End If
            End If
        Next
        Return String.Empty
    End Function

    Private Function GetOperaPath() As String

        Dim regkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.LocalMachine.OpenSubKey(UNINST_PATH, False)

        If regkey Is Nothing Then
            Return String.Empty
        End If

        For Each s As String In regkey.GetSubKeyNames
            Dim subkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(UNINST_PATH & "\" & s, False)

            Dim displayName As String = subkey.GetValue("DisplayName").ToString
            If Not displayName Is Nothing Then

                If displayName.Contains("Opera") Then
                    Return subkey.GetValue("InstallLocation").ToString
                End If
            End If
        Next
        Return String.Empty
    End Function

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        My.Settings.Limit = Decimal.ToInt32(Me.NumericUpDown制限時間.Value)
        My.Settings.Wait = Decimal.ToInt32(Me.NumericUpDown待ち時間.Value)
        My.Settings.Sound = Me.CheckBoxSound.Checked

        Dim browser As String = String.Empty

        If Me.RadioButtonOP.Checked Then
            browser = OPERA

        ElseIf Me.RadioButtonGC.Checked Then
            browser = CHROME

        ElseIf Me.RadioButtonFF.Checked Then
            browser = FIREFOX

        Else
            browser = IE
        End If
        My.Settings.Browser = browser
        My.Settings.Save()

        Me.ShowBrowser()
    End Sub

    Private Sub Buttonキャンセル_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonキャンセル.Click
        Me.Close()
    End Sub

    Private Sub ShowBrowser()

        If Not Me.CanProcessStart() Then
            Return
        End If

        Me.Visible = False

        Dim minutes As Integer = Me.GetLastExecutedTime()
        Dim wait As Integer = My.Settings.Wait
        If 0 = minutes Then
            MessageBox.Show("さっき起動したばっかりだよ！！", _
                TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Me.Dispose()
            Return
        ElseIf 0 < minutes And minutes < wait Then
            MessageBox.Show(minutes & " 分前に起動したばっかりだよ！！", _
                TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Me.Dispose()
            Return
        End If

        Dim stream As IO.Stream = Nothing
        Dim player As Media.SoundPlayer = Nothing
        Dim p As Process = Nothing
        Dim iexplore As SHDocVw.InternetExplorer = Nothing
        Try
            Dim browser As String = My.Settings.Browser
            Dim path As String = String.Empty

            Select Case browser

                Case OPERA
                    path = Me.GetOperaPath() & "\opera.exe"

                Case CHROME
                    path = Me.GetChromePath() & "\chrome.exe"

                Case FIREFOX
                    path = Me.GetFirefoxPath() & "\firefox.exe"

                Case Else
                    path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) _
                        & "\Internet Explorer\iexplore.exe"
            End Select

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

            Me.Close()
            Me.Dispose()
        End Try
    End Sub

    Private Function CanProcessStart() As Boolean

        Dim browser As String = My.Settings.Browser
        Dim processName As String = String.Empty
        Dim errorMessage As String = String.Empty

        Select Case browser

            Case OPERA
                processName = "opera"
                errorMessage = "Opera は既に起動済みです。"

            Case CHROME
                processName = "chrome"
                errorMessage = "Google Chrome は既に起動済みです。"

            Case FIREFOX
                processName = "firefox"
                errorMessage = "Mozilla Firefox は既に起動済みです。"

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
End Class
