Imports System.Data.Odbc
Public Class Form1
    Const DSN = "DSN=projek"
    Dim conn As OdbcConnection
    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn = New OdbcConnection(DSN)
            conn.Open()
        Catch ex As Exception
            MsgBox("Koneksi Database Gagal")
        End Try
        Dim myadapter As New OdbcDataAdapter
        Dim sqlQuery = "SELECT * FROM user WHERE username='" + TextBox1.Text + "' AND password='" + TextBox2.Text + "'"
        Dim myCommand As New OdbcCommand
        myCommand.Connection = conn
        myCommand.CommandText = sqlQuery

        myadapter.SelectCommand = myCommand
        Dim myData As OdbcDataReader
        myData = myCommand.ExecuteReader()
        If myData.HasRows = 0 Then
            MsgBox("Username / Password salah", MsgBoxStyle.Exclamation, "Error Login")
        Else
            MsgBox("Login Berhasil, Selamat Datang " & TextBox1.Text & "!", MsgBoxStyle.Information, "Sukses Login")
            PictureBox1.Enabled = True
            PictureBox2.Enabled = True
            PictureBox3.Enabled = True
            PictureBox5.Enabled = True
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
