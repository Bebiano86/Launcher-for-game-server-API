Imports System.Net
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.IO.StreamReader
Imports System.Security
Public Class Form1
    Dim Watermark As String = "yes"
    Private x, y As Integer
    Private newpoint As Point
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
            Application.DoEvents()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
            Application.DoEvents()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.CreateDirectory("C:\\Launcher")
        Dim web As New WebClient 'Para habilitar o download da ultima versão do arquivo.
        Dim UltimaVersao As String = web.DownloadString("http://hlc.ovh/update.txt") 'Para verificar a versão atual e decidir se há ou não updates.
        Dim VersaoDessePrograma As String = My.Application.Info.Version.ToString 'Encontra a versão deste programa.


        If VersaoDessePrograma < UltimaVersao Then 'Se a versão deste programa for mais antiga que a nova versão, ele irá atualizar, caso contrario nada será feito.

            If MessageBox.Show("Um novo update está disponivel!" & vbNewLine & "Você quer atualizar?", "Atualizador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then 'Messagebox perguntando se a atualização deve ou não ser feita.
                My.Computer.Network.DownloadFile("http://hlc.ovh/Launcher/LauncherServer.exe", Application.StartupPath & "\Launcher.V1.0.0.3.exe") 'Se for escolhido Yes, será baixada a nova versão do programa e criada uma nova pasta para colocar o arquivo baixado.
                MsgBox("Update feito com sucesso!" & vbNewLine & "O aplicativo será fechado.") 'Dizendo que o aplicativo vai fechar
                End 'Sai do aplicativo
            Else
                'Se escolherem não
            End If
        End If
        With My.Application.Info.Version
            Label5.Text = "Versão Beta -" & My.Application.Info.Version.ToString()
        End With
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("http://hlc.ovh")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Diagnostics.Process.Start("https://discord.me/sfservidores")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Instruções :" & vbNewLine & vbNewLine & "Introduzir link do api!" & vbNewLine & "Guardar link!" & vbNewLine & "Executar a função!" & vbNewLine & vbNewLine & "Compilado por: Bebiano", MsgBoxStyle.Information, "Instruções")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Label4.Text = "Digitando..."
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim objwriter As New System.IO.StreamWriter("C:\\Launcher\start.txt")
        objwriter.Write(TextBox1.Text)
        objwriter.Close()
        Label4.Text = "Salvo com Sucesso!"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = My.Computer.FileSystem.ReadAllText("C:\\Launcher\start.txt")
        System.Diagnostics.Process.Start(TextBox1.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.facebook.com/claudio.bebiano")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Label2.Text = "Digitando..."
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim objwriter As New System.IO.StreamWriter("C:\\Launcher\stop.txt")
        objwriter.Write(TextBox2.Text)
        objwriter.Close()
        Label2.Text = "Salvo com Sucesso!"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox2.Text = My.Computer.FileSystem.ReadAllText("C:\\Launcher\stop.txt")
        System.Diagnostics.Process.Start(TextBox2.Text)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Label3.Text = "Digitando..."
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim objwriter As New System.IO.StreamWriter("C:\\Launcher\restart.txt")
        objwriter.Write(TextBox3.Text)
        objwriter.Close()
        Label3.Text = "Salvo com Sucesso!"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox3.Text = My.Computer.FileSystem.ReadAllText("C:\\Launcher\restart.txt")
        System.Diagnostics.Process.Start(TextBox3.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        System.Diagnostics.Process.Start("http://hlc.ovh/painel/?m=news&p=news")
    End Sub

End Class
