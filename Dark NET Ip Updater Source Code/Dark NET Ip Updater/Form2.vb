Imports System.Net
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form2
    Public Tt As String
    Public lin As String
    Public ss As String
    Public Path As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "IP.txt"
    Public Path7 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "Link.txt"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If (Me.TextBox2.Text = Nothing) Then
            Me.Label3.Text = "State : Not Value in textbox to upload ."
        Else
            m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
            m.w.Document.All.Item("submit").InvokeMember("click")
            '        /edit.php?i=vNR9KwWb    Edit Paste
        End If
        Label8.Text = "Your IP Uploaded !"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If (Me.TextBox2.Text = Nothing) Then
                'Me.Label3.Text = "State : Not Value in textbox to upload ."
            Else
                m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
                m.w.Document.All.Item("submit").InvokeMember("click")
                '        /edit.php?i=vNR9KwWb    Edit Paste
            End If
            Label8.Text = "Your IP Updated !"
        Catch ex As Exception
            MsgBox("No Update Need !")
        End Try

        Try
            Threading.Thread.CurrentThread.Sleep(100)
            Me.TextBox3.Text = m.w.Url.ToString.Replace("http://pastebin.com/", "http://pastebin.com/raw.php?i=")
            Me.TextBox1u.Text = Me.TextBox3.Text.Replace("http://pastebin.com/raw.php?i=", "")
            Dim tttt As String = Me.TextBox1u.Text.Replace("edit.php?i=", "")
            ss = ("http://pastebin.com/edit.php?i=" & tttt)
            Me.ttt.Text = ss
            m.w.Navigate(ss) ' Edit Paste
            Threading.Thread.CurrentThread.Sleep(100)
            m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
            m.w.Document.All.Item("submit").InvokeMember("click")
        Catch ex As Exception
        End Try

        Me.TextBox3.Text = m.w.Url.ToString.Replace("http://pastebin.com/", "http://pastebin.com/raw.php?i=")
        Try
            File.WriteAllText(Path, ss)
            File.WriteAllText(Path7, TextBox3.Text)
            S()
        Catch ex As Exception
        End Try
    End Sub
    Sub S()
        File.SetAttributes(Path, FileAttributes.Hidden)
        File.SetAttributes(Path7, FileAttributes.Hidden)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
        m.w.Document.All.Item("submit").InvokeMember("click")
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Dark NET IP Updater v2.0"
        NotifyIcon1.BalloonTipText = "Your IP :" & TextBox2.Text
        NotifyIcon1.ShowBalloonTip(3000)
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Tt = File.ReadAllText(Path)
            Me.ttt.Text = Tt
            lin = File.ReadAllText(Path7)
            Me.TextBox3.Text = lin
        Catch ex As Exception
        End Try
        If TextBox3.Text = "" Then
        Else
            Me.Button1.Visible = False
            Me.Button2.Visible = False
            Me.Button8.Visible = True
            Me.Button7.Visible = True
  End If
        m.w.Navigate(ttt.Text)
        Label8.Text = "Loading Your IP ! "
    End Sub
    'Sub uup()
    '    Try
    '        Dim w As New WebClient
    '        Dim cpuids As String = (w.DownloadString(TextBox3.Text))
    '        Label7.Text = cpuids
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub texxt()

        Me.TextBox2.Text = GetExternalIp()
    End Sub
    'Sub op()
    '    Threading.Thread.CurrentThread.Sleep(100)
    '    Me.Label5.Text = Me.TextBox2.Text
    'End Sub
    Private Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                         .Matches(ExternalIP)(0).ToString()
            Return ExternalIP
        Catch
            Return Nothing
        End Try

    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim gg As New System.Threading.Thread(AddressOf GetExternalIp)
        gg.Start()
        Me.TextBox2.Text = GetExternalIp()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Timer1.Enabled = True
    End Sub
    Public Sub up()
        Dim ggg As New System.Threading.Thread(AddressOf GetExternalIp)
        ggg.Start()
        Me.TextBox2.Text = GetExternalIp()
        Me.TextBox3.Text = m.w.Url.ToString.Replace("http://pastebin.com/", "http://pastebin.com/raw.php?i=")
        Me.TextBox1u.Text = Me.TextBox3.Text.Replace("http://pastebin.com/raw.php?i=", "")
        Dim tttt As String = Me.TextBox1u.Text.Replace("edit.php?i=", "")
        Dim ss As String = ("http://pastebin.com/edit.php?i=" & tttt)
        Me.ttt.Text = ss
        m.w.Navigate(ss) ' Edit Paste
        Threading.Thread.Sleep(100)
        m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
        m.w.Document.All.Item("submit").InvokeMember("click")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Process.GetCurrentProcess.Kill()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim gg As New System.Threading.Thread(AddressOf GetExternalIp)
        gg.Start()
        Threading.Thread.CurrentThread.Sleep(1000)
        Timer1.Interval = TimeSpan.FromMinutes(NumericUpDown1.Value).TotalMilliseconds
        MsgBox("ok")
        Try
            If (Me.TextBox2.Text = Nothing) Then
                Me.Label3.Text = "State : Not Value in textbox to upload ."
            Else
                m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
                m.w.Document.All.Item("submit").InvokeMember("click")
                '        /edit.php?i=vNR9KwWb    Edit Paste
            End If
            Threading.Thread.CurrentThread.Sleep(100)
            Me.TextBox3.Text = m.w.Url.ToString.Replace("http://pastebin.com/", "http://pastebin.com/raw.php?i=")
            Me.TextBox1u.Text = Me.TextBox3.Text.Replace("http://pastebin.com/raw.php?i=", "")
            Dim tttt As String = Me.TextBox1u.Text.Replace("edit.php?i=", "")
            Dim ss As String = ("http://pastebin.com/edit.php?i=" & tttt)
            Me.ttt.Text = ss
            m.w.Navigate(ss) ' Edit Paste
            'Threading.Thread.CurrentThread.Sleep(100)
            m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
            m.w.Document.All.Item("submit").InvokeMember("click")
        Catch ex As Exception
            MsgBox("No Update Need !")
        End Try
        'uup()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        m.w.Navigate(ttt.Text)
        Label8.Text = "Set Your New IP !"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        If (Me.TextBox2.Text = Nothing) Then
            Me.Label3.Text = "State : Not Value in textbox to upload ."
        Else
            m.w.Document.All.Item("paste_code").InnerText = Me.TextBox2.Text
            m.w.Document.All.Item("submit").InvokeMember("click")
            '        /edit.php?i=vNR9KwWb    Edit Paste
        End If
        Label8.Text = "Your IP Updated !"
    End Sub
    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Process.GetCurrentProcess.Kill()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        File.Delete(Path)
        File.Delete(Path7)
        Label8.Text = "Your Setting Has Been Reset !"
    End Sub
End Class

