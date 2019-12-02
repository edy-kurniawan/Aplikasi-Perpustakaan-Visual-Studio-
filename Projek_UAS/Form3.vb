Imports System.Data.Odbc
Public Class Form3
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
        da = New OdbcDataAdapter("select * from buku", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, 0)
        table = ds.Tables(0)
        DataGridView1.DataSource = table
        conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insertquery As String
        Dim hasil As Integer

        insertquery = "insert into buku" & "(Kode_Buku, Judul, Penulis , Penerbit , Tahun_Terbit)" & "values('" & TextBox1.Text & "', " & " ' " & TextBox2.Text & "' , " & " ' " & TextBox3.Text & "' , " & " ' " & TextBox4.Text & "' , " & " ' " & TextBox5.Text & "')"
        Try
            cmd = New OdbcCommand(insertquery, conn)
            cmd.Connection.Open()
            hasil = cmd.ExecuteNonQuery()
            If (hasil > 0) Then MessageBox.Show("Buku disimpan", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        Catch ex As Exception
            MessageBox.Show("failed :" & ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkan_data()
        DataGridView1.Refresh()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.RowCount > 0 Then
            Dim baris As Integer
            With DataGridView1
                baris = .CurrentRow.Index
                TextBox1.Text = .Item(0, baris).Value
                TextBox2.Text = .Item(1, baris).Value
                TextBox3.Text = .Item(2, baris).Value
                TextBox4.Text = .Item(3, baris).Value
                TextBox5.Text = .Item(4, baris).Value
            End With
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            koneksi()
            cmd = New OdbcCommand("update buku set Judul = ? , Penulis = ? , Penerbit = ?, Tahun_Terbit = ?  where Kode_Buku = ?", conn)
            With cmd
                .Parameters.AddWithValue("?", TextBox2.Text)
                .Parameters.AddWithValue("?", TextBox3.Text)
                .Parameters.AddWithValue("?", TextBox4.Text)
                .Parameters.AddWithValue("?", TextBox5.Text)
                .Parameters.AddWithValue("?", TextBox1.Text)
                .ExecuteNonQuery()
                DataGridView1.Refresh()

            End With
            conn.Close()
            tampilkan_data()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        koneksi()
        cmd = New OdbcCommand("DELETE FROM buku WHERE Kode_Buku = '" + TextBox1.Text + "'", conn)
        With cmd
            .ExecuteNonQuery()
            .Dispose()
            DataGridView1.Refresh()
        End With
        conn.Close()
        tampilkan_data()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        DataGridView1.Refresh()
    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnggotaToolStripMenuItem.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        
    End Sub

    Private Sub PeminjamanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PeminjamanToolStripMenuItem1.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengembalianToolStripMenuItem.Click
        Me.Hide()
        Form5.Show()
    End Sub
End Class