Imports System.ComponentModel
Imports System.IO

Public Class m
    Public Tt As String
    Public a As String
    Public Path As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "User.txt"
    Public Path3 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "Password.txt"
    Public w As WebBrowser
    Private Sub _Lambda__1(ByVal a0 As Object, ByVal a1 As WebBrowserDocumentCompletedEventArgs)
        Me.com()
    End Sub
    Private Sub m_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.w = New WebBrowser
        AddHandler Me.w.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf Me._Lambda__1)
        Me.w.ScriptErrorsSuppressed = True
        Me.w.Navigate("http://pastebin.com/login")
        Try
            Tt = File.ReadAllText(Path)
            Me.TextBox1.Text = Tt
            Tt = File.ReadAllText(Path3)
            Me.TextBox2.Text = Tt
            Catch ex As Exception
        End Try
        Me.Label3.Text = "Connected ..."
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.w.Document.All.Item("user_name").InnerText = Me.TextBox1.Text
            Me.w.Document.All.Item("user_password").InnerText = Me.TextBox2.Text
            Me.w.Document.All.Item("submit").InvokeMember("click")
        Catch ex As Exception
        End Try
        If CheckBox1.Checked Then
            Try
                File.WriteAllText(Path, TextBox1.Text)
                File.WriteAllText(Path3, TextBox2.Text)
                S()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub com()
        If (Me.w.Url.ToString = "http://pastebin.com/login") Then
            Me.Button1.Enabled = True
        ElseIf (Me.w.Url.ToString = "http://pastebin.com/login.php?e=1") Then
            Me.Label6.Text = "State : There was an error with your login details."
        ElseIf Me.w.Url.ToString.Contains("/u/") Then
            Me.a = Me.w.Url.ToString.Replace("http://pastebin.com/u/", "")
            'Form2.Text = ("welcome : " & Me.a & " - Pastebin Uploader V.2 - Ahmad Albalawi")
            Me.Hide()
            Form2.Show()
            Me.w.Navigate("http://pastebin.com/index")
        ElseIf (Me.w.Url.ToString = "http://pastebin.com/login.php?e=4") Then
            Me.Label6.Text = "State : Please try again in about 5 minutes."
        ElseIf (Me.w.Url.ToString = "http://pastebin.com/index") Then
            Form2.Label3.Text = "State : Ready ."
        Else


        End If
    End Sub
    Sub S()
        File.SetAttributes(Path, FileAttributes.Hidden)
        File.SetAttributes(Path3, FileAttributes.Hidden)
    End Sub
End Class
''