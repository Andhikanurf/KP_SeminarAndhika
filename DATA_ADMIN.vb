Imports MySql.Data.MySqlClient
Public Class DATA_ADMIN

    Sub Kondisiawal()
        TextBox1.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox5.Text = ""
        ComboBox2.Text = ""

        TextBox4.Enabled = False
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        TextBox5.Enabled = False
        ComboBox6.Enabled = False
        ComboBox7.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        ComboBox5.Enabled = False
        ComboBox2.Enabled = False

        Button1.Text = "Input"
        Button2.Text = "Edit"
        Button3.Text = "Hapus"
        Button4.Text = "Tutup"
        Call Koneksi()
        da = New MySqlDataAdapter("Select nip, namakar, username, jabatan, golongan from tb_admin", con)
        ds = New DataSet
        da.Fill(ds, "tb_admin")
        DataGridView2.DataSource = ds.Tables("tb_admin")
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.ReadOnly = True
    End Sub

    Sub Isi()
        TextBox4.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        TextBox5.Enabled = True
        ComboBox6.Enabled = True
        ComboBox7.Enabled = True
        ComboBox5.Enabled = True
        ComboBox2.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub DATA_ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Kondisiawal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call Isi()
            'Call Otomatis()
            TextBox1.Focus()
        Else
            If TextBox1.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox5.Text = "" Or ComboBox2.Text = "" Then
                MessageBox.Show("Silahkan Isi Semua Field", "")
            Else
                Call Koneksi()
                Dim inputdata As String = "insert into tb_admin values ('" & TextBox1.Text & "','" & TextBox5.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "', '" & ComboBox1.Text & "', '" & ComboBox6.Text & "', '" & ComboBox7.Text & "', '" & ComboBox5.Text & "', '" & ComboBox2.Text & " ')"
                cmd = New MySqlCommand(inputdata, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Input Data Berhasil", "")
                Call Kondisiawal()
            End If
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        da = New MySqlDataAdapter("select * from tb_admin where namakar like '%" & Me.TextBox2.Text & "%' Or username Like '%" & Me.TextBox2.Text & "%'", con)
        ds = New DataSet
        da.Fill(ds, "tb_admin")
        DataGridView2.DataSource = (ds.Tables("tb_admin"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"

            Call Isi()
            TextBox4.Focus()
        Else
            If TextBox5.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox5.Text = "" Or ComboBox2.Text = "" Then
                MessageBox.Show("Silahkan Isi Semua Field", "")
            Else
                Call Koneksi()
                Dim updatedata As String = "Update tb_admin set nip = '" & TextBox1.Text & "', namakar = '" & TextBox5.Text & "', password = '" & TextBox3.Text & "', level = '" & ComboBox1.Text & "', statkar = '" & ComboBox6.Text & "', jabatan = '" & ComboBox7.Text & "', golongan= '" & ComboBox5.Text & "', keterangan = '" & ComboBox2.Text & "' where username = '" & TextBox4.Text & "'"
                cmd = New MySqlCommand(updatedata, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Update Data Berhasil", "")
                Call Kondisiawal()
            End If
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()

            cmd = New MySqlCommand("Select * from tb_admin where username like '%" & TextBox4.Text & "%'", con)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MessageBox.Show("Username Tidak Ditemukan", "")
            Else
                TextBox5.Text = rd.Item("namakar")
                TextBox3.Text = rd.Item("password")
                ComboBox1.Text = rd.Item("level")
                ComboBox6.Text = rd.Item("statkar")
                ComboBox7.Text = rd.Item("jabatan")
                TextBox1.Text = rd.Item("nip")
                ComboBox5.Text = rd.Item("golongan")
                ComboBox2.Text = rd.Item("keterangan")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Close()
        Else
            Call Kondisiawal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Hapus" Then
            Button3.Text = "Delete"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"

            Call Isi()
            TextBox4.Focus()
        Else
            If TextBox1.Text Or TextBox5.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox5.Text = "" Or ComboBox2.Text = "" Then
                MessageBox.Show("Silahkan Isi Semua Field", "")
            Else
                Call Koneksi()
                Dim hapusdata As String = "Delete from tb_admin where namakar = '" & TextBox5.Text & "'"
                cmd = New MySqlCommand(hapusdata, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Hapus Data Berhasil", "")
                Call Kondisiawal()
            End If
        End If
    End Sub

    'Sub Otomatis()
    'Call Koneksi()
    '   cmd = New MySqlCommand("select * from tb_admin where nip in (select max(nip) from tb_admin)", con)
    'Dim kodeurut As String
    'Dim hitung As Long
    '   rd = cmd.ExecuteReader
    '  rd.Read()
    'If Not rd.HasRows Then
    '       kodeurut = "3" + Format(Now, "yyMMdd") + "0001"
    'Else
    '       hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 9) + 1
    '      kodeurut = "3" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("0000" & hitung, 4)
    'End If
    '   TextBox1.Text = kodeurut
    'End Sub
End Class