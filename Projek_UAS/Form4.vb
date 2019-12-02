Imports System.Data.Odbc
Public Class Form4
    Const DSN = "DSN=projek"
    Dim conn As OdbcConnection
    Dim cmd As OdbcCommand
    Dim RD As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim dr As OdbcDataReader
    Dim ds As DataSet
    Dim table As DataTable

    Sub koneksi()
        conn = New OdbcConnection(DSN)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Sub tampilkan_data()
        koneksi()
        da = New OdbcDataAdapter("select * from peminjaman", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, 0)
        table = ds.Tables(0)
        DataGridView1.DataSource = table
        conn.Close()
    End Sub

    Sub tampilDataComboBox1()
        Call koneksi()
        Dim str As String
        str = "select Nim from anggota"
        cmd = New OdbcCommand(str, conn)
        RD = cmd.ExecuteReader
        If RD.HasRows Then
            Do While RD.Read
                ComboBox2.Items.Add(RD("Nim"))
            Loop
        Else

        End If
        conn.Close()
    End Sub

    Sub tampilDataComboBox2()
        Call koneksi()
        Dim str As String
        str = "select Kode_Buku from buku"
        cmd = New OdbcCommand(str, conn)
        RD = cmd.ExecuteReader
        If RD.HasRows Then
            Do While RD.Read
                ComboBox1.Items.Add(RD("Kode_Buku"))
            Loop
        Else

        End If
        conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insertquery As String
        Dim hasil As Integer

        insertquery = "insert into peminjaman" & "(Kode_Pinjam, Kode_Buku, Nim, Tanggal_Pinjam , Tanggal_Kembali)" & "values('" & TextBox1.Text & "', " & " ' " & ComboBox1.Text & "' , " & " ' " & ComboBox2.Text & "' , " & " ' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' , " & " ' " & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')"
        Try
            cmd = New OdbcCommand(insertquery, conn)
            cmd.Connection.Open()
            hasil = cmd.ExecuteNonQuery()
            If (hasil > 0) Then MessageBox.Show("Buku dipinjam", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            TextBox1.Focus()
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("failed :" & ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkan_data()
        tampilDataComboBox1()
        tampilDataComboBox2()
    End Sub


   
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengembalianToolStripMenuItem.Click
        Me.Hide()
        Form5.Show()

    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnggotaToolStripMenuItem.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class