Imports MySql.Data.MySqlClient
Public Class ABSENSI
    Dim tglmysql As String

    Sub kondisiawal()
        Button4.Text = "Tutup"
        Button1.Text = "Edit Absen"
        Button2.Text = "Absen"

        Button4.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = True

        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox2.Enabled = False
    End Sub

    Sub isi()
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Absen" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button4.Text = "Batal"
            Call isi()
        Else
            tglmysql = Format(Today, "yy-MM-dd")
            Call Koneksi()
            Dim inputdata As String = "insert into tb_absensi values ('" & TextBox6.Text & "', '" & TextBox5.Text & "', '" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & tglmysql & "', '" & DASHBOARD.SS4.Text & "', '" & DASHBOARD.SS6.Text & "')"
            cmd = New MySqlCommand(inputdata, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Absensi Berhasil Ditambahkan")
            MsgBox("Tanggal : " & DASHBOARD.SS2.Text & vbCrLf &
                    "Jam: " & DASHBOARD.SS4.Text & vbCrLf &
                    "Status: " & TextBox3.Text, , "Keterangan Kehadiran")
            Call kondisiawal()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Edit Absen" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button4.Text = "Batal"
            Call isi()
        Else
            tglmysql = Format(Today, "yy-MM-dd")
            Call Koneksi()
            Dim updatedata As String = "Update tb_absensi set nip = '" & TextBox6.Text & "', namakar = '" & TextBox5.Text & "', statkar = '" & TextBox2.Text & "', jabatan = '" & TextBox1.Text & "', stathadir = '" & TextBox3.Text & "', tanggal = '" & tglmysql & "', waktu = '" & DASHBOARD.SS4.Text & "' where username = '" & DASHBOARD.SS6.Text & "'"
            cmd = New MySqlCommand(updatedata, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Absensi Berhasil Diubah")
            MsgBox("Tanggal : " & DASHBOARD.SS2.Text & vbCrLf &
                    "Jam: " & DASHBOARD.SS4.Text & vbCrLf &
                    "Status: " & TextBox3.Text, , "Keterangan Kehadiran")
            Call kondisiawal()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Batal" Then
            Call kondisiawal()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ABSENSI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()

        If DASHBOARD.SS4.Text < "08.00.00" Then
            TextBox3.Text = "HADIR"

        ElseIf DASHBOARD.SS4.Text = "08.00.00" Then
            TextBox3.Text = "HADIR"

        ElseIf "08.15.00" < DASHBOARD.SS4.Text > "08.01.00" Then
            TextBox3.Text = "TERLAMBAT 15 MENIT"

        ElseIf "08.30.00" < DASHBOARD.SS4.Text > "08.16.00" Then
            TextBox3.Text = "TERLAMBAT 30 MENIT"

        ElseIf "08.45.00" < DASHBOARD.SS4.Text > "08.31.00" Then
            TextBox3.Text = "TERLAMBAT 45 MENIT"

        ElseIf "09.00.00" < DASHBOARD.SS4.Text > "08.46.00" Then
            TextBox3.Text = "TERLAMBAT 1 JAM"

        ElseIf DASHBOARD.SS4.Text > "09.01.00" Then
            TextBox3.Text = "ALPA"
            DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
        End If
    End Sub
End Class