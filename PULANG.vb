Imports MySql.Data.MySqlClient
Public Class PULANG
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
        TextBox2.Enabled = False
        TextBox1.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Sub isi()
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox2.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Absen" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button4.Text = "Batal"
            Call Isi()
        Else
            tglmysql = Format(Today, "yy-MM-dd")
            Call Koneksi()
            Dim inputdata As String = "insert into tb_pulang values ('" & TextBox6.Text & "', '" & TextBox5.Text & "', '" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & tglmysql & "', '" & DASHBOARD.SS4.Text & "', '" & DASHBOARD.SS6.Text & "')"
            cmd = New MySqlCommand(inputdata, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Absensi Berhasil Ditambahkan")
            MsgBox("Tanggal : " & DASHBOARD.SS2.Text & vbCrLf &
                    "Jam: " & DASHBOARD.SS4.Text & vbCrLf &
                    "Status: " & TextBox3.Text, , "Keterangan Pulang")
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
            Dim updatedata As String = "Update tb_pulang set nip = '" & TextBox6.Text & "', namakar = '" & TextBox5.Text & "', statkar = '" & TextBox2.Text & "', jabatan = '" & TextBox1.Text & "', statpulang = '" & TextBox3.Text & "', tanggal = '" & tglmysql & "', waktu = '" & DASHBOARD.SS4.Text & "' where username = '" & DASHBOARD.SS6.Text & "'"
            cmd = New MySqlCommand(updatedata, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Absensi Berhasil Diubah")
            MsgBox("Tanggal : " & DASHBOARD.SS2.Text & vbCrLf &
                    "Jam: " & DASHBOARD.SS4.Text & vbCrLf &
                    "Status: " & TextBox3.Text, , "Keterangan Pulang")
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

    Private Sub PULANG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()

        If DASHBOARD.SS4.Text < "17.00.00" Then
            TextBox3.Text = "PULANG LEBIH AWAL"

        ElseIf "17.15.00" < DASHBOARD.SS4.Text > "17.01.00" Then
            TextBox3.Text = "TEPAT WAKTU"

        ElseIf "18.15.00" < DASHBOARD.SS4.Text > "17.16.00" Then
            TextBox3.Text = "OVERTIME 1 JAM"

        ElseIf "19.15.00" < DASHBOARD.SS4.Text > "18.16.00" Then
            TextBox3.Text = "OVERTIME 2 JAM"

        ElseIf "20.15.00" < DASHBOARD.SS4.Text > "19.16.00" Then
            TextBox3.Text = "OVERTIME 3 JAM"

        ElseIf DASHBOARD.SS4.Text > "20.16.00" Then
            TextBox3.Text = "OVERTIME 4 JAM"
        End If
    End Sub
End Class