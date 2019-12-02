Imports System.Data.Odbc
Public Class Form5
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
        da = New OdbcDataAdapter("select * from pengembalian", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "peminjaman")
        DataGridView1.DataSource = (ds.Tables("peminjaman"))
        cmd = New OdbcCommand("select * FROM peminjaman", conn)
        RD = cmd.ExecuteReader
            Do While RD.Read
                ComboBox1.Items.Add(RD.Item(0))
            Loop
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Close()
        Dim insertquery As String
        Dim hasil As Integer


            insertquery = "insert into pengembalian" & "(Kode_Pinjam, Kode_Buku, Nim, Tanggal_Pinjam , Tanggal_Kembali, Jatuh_Tempo, Denda_Perhari, Total_Denda)" & "values('" & ComboBox1.Text & "', " & " ' " & TextBox1.Text & "' , " & " ' " & TextBox2.Text & "' , " & " ' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' , " & " ' " & Format(DateTimePicker3.Value, "yyyy-MM-dd") & "', " & " ' " & TextBox4.Text & "', " & " ' " & TextBox5.Text & "', " & " ' " & TextBox6.Text & "'   )"
            Try
                cmd = New OdbcCommand(insertquery, conn)
                cmd.Connection.Open()
                hasil = cmd.ExecuteNonQuery()
                If (hasil > 0) Then MessageBox.Show("Buku dikembalikan", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd = New OdbcCommand("DELETE FROM peminjaman WHERE Kode_Pinjam = '" + ComboBox1.Text + "'", conn)
            With cmd
                .ExecuteNonQuery()
                .Dispose()
                DataGridView1.Refresh()
            End With
            conn.Close()
            tampilkan_data()
            ComboBox1.Text = ""
            ComboBox1.Focus()
        Catch ex As Exception
            MessageBox.Show("failed :" & ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkan_data()
        
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New OdbcCommand("Select * from peminjaman where Kode_Pinjam='" & ComboBox1.Text & "'", conn)
        RD = cmd.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            TextBox1.Text = RD.Item("Kode_Buku")
            TextBox2.Text = RD.Item("Nim")
            DateTimePicker1.Value = RD.Item("Tanggal_Pinjam")
            DateTimePicker2.Value = RD.Item("Tanggal_Kembali")
            DateTimePicker1.Enabled = False
            TextBox3.Text = DateDiff(DateInterval.Day, DateTimePicker1.Value, DateTimePicker2.Value) & " Hari"
            
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        TextBox4.Text = DateDiff(DateInterval.Day, DateTimePicker2.Value, DateTimePicker3.Value)


    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox6.Text = TextBox4.Text * TextBox5.Text
    End Sub

    Private Sub PeminjamanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PeminjamanToolStripMenuItem1.Click
        Me.Hide()
        Form4.Show()

    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnggotaToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class