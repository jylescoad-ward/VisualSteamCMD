Public Class main
    Public gameid As String = "nul"
    Public installfolder As String = "nul"
    Public steamcmd As String = "C:\steamcmd\steamcmd.exe"
    Private Sub DownloadSteamCMD_Click(sender As Object, e As EventArgs) Handles DownloadSteamCMD.Click
        If (Not System.IO.Directory.Exists("C:\steamcmd")) Then
            System.IO.Directory.CreateDirectory("C:\steamcmd")
        End If
        MessageBox.Show("Created SteamCMD Folder at Location: C:\SteamCMD\")
        My.Computer.Network.DownloadFile(
    "http://jyles.pw/steamcmd.exe",
    "C:\steamcmd\steamcmd.exe")
        MessageBox.Show("Downloaded SteamCMD EXE to: C:\SteamCMD\SteamCME.exe")
    End Sub

    Private Sub FirstRun_Click(sender As Object, e As EventArgs) Handles FirstRun.Click
        Dim proc As New System.Diagnostics.Process()
        MessageBox.Show("A Window will open up, Dont worry! This will install SteamCMD, Do NOT close the window. It will Close itself.")

        'First Start of SteamCMD to Update'
        Dim firstStart As New ProcessStartInfo
        firstStart.FileName = steamcmd
        firstStart.Arguments = "+quit"
        Process.Start(firstStart)

        MessageBox.Show("SteamCMD has finished installing, it should of installed by now and closed itself. You can now continue to Step 2.")
    End Sub

    Private Sub InstallLocation_Click(sender As Object, e As EventArgs) Handles InstallLocation.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then

            installfolder = folderDlg.SelectedPath

            Dim root As Environment.SpecialFolder = folderDlg.RootFolder

        End If
        MessageBox.Show(installfolder)
    End Sub

    Private Sub SetGameID_Click(sender As Object, e As EventArgs) Handles SetGameID.Click
        gameid = InputBox("Enter SteamCMD GameID from the Link", "SteamCMD GameID Input", "Enter GameID From List")

        MessageBox.Show("gameid set to: " & gameid)

    End Sub

    Private Sub Install_Click(sender As Object, e As EventArgs) Handles Install.Click
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = "C:\steamcmd\steamcmd.exe"
        startInfo.Arguments = "+login anonymous +force_install_dir " & installfolder & " +app_update " & gameid & " validate +quit"
        Process.Start(startInfo)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim showWeb As New ProcessStartInfo
        showWeb.FileName = "iexplore.exe"
        showWeb.Arguments = "https://developer.valvesoftware.com/wiki/Dedicated_Servers_List"
        Process.Start(showWeb)
    End Sub
End Class
