Imports MySql.Data.MySqlClient
Imports System.IO

Public Class DATA_KARYAWAN
    Sub kondisiawal()
        Button8.Text = "Edit"
        Button1.Text = "Tutup"
        Button2.Text = "Input"
        Button1.Enabled = True
        Button2.Enabled = True
        Button8.Enabled = True
        Button10.Enabled = False

        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False

        TextBox10.Enabled = False
        TextBox9.Enabled = False
        TextBox1.Enabled = False

    End Sub

    Sub isi()
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox2.Enabled = True
        TextBox4.Enabled = True
        TextBox3.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True

        TextBox10.Enabled = True
        TextBox9.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub DATA_KARYAWAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Button8.Text = "Edit" Then
            Button8.Text = "Simpan"
            Button2.Enabled = False
            Button1.Text = "Batal"
            Button10.Enabled = True
            Call isi()
        Else
            If TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox3.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox1.Text = "" Or TextBox9.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or Label13.Text = "" Then
                MessageBox.Show("Silahkan Isi Semua Field", "")
            Else
                Call Koneksi()
                Label3.Text = Label3.Text.Replace("\", "\\")
                Dim updatedata As String = "update tb_karyawan set namakar = '" & TextBox7.Text & "', namaibu = '" & TextBox8.Text & "', nip = '" & TextBox2.Text & "', nik = '" & TextBox4.Text & "', alamat = '" & TextBox3.Text & "', nohp = '" & TextBox5.Text & "', email = '" & TextBox6.Text & "', agama = '" & ComboBox1.Text & "', jkelamin = '" & ComboBox2.Text & "', warga = '" & ComboBox3.Text & "', statnikah = '" & ComboBox4.Text & "', golongan = '" & TextBox10.Text & "', statkar = '" & TextBox9.Text & "', jabatan = '" & TextBox1.Text & "', profil = '" & Label3.Text & "' where username = '" & DASHBOARD.SS6.Text & "'"
                cmd = New MySqlCommand(updatedata, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Update Data Berhasil", "")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Input" Then
            Button2.Text = "Simpan"
            Button8.Enabled = False
            Button10.Enabled = True
            Button1.Text = "Batal"
            Call isi()
        Else
            If TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox3.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox1.Text = "" Or TextBox9.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or Label13.Text = "" Then
                MessageBox.Show("Silahkan Isi Semua Field", "")
            Else
                Call Koneksi()
                Label3.Text = Label3.Text.Replace("\", "\\")
                Dim inputdata As String = "Insert into tb_karyawan values ('" & TextBox7.Text & "','" & TextBox8.Text & "', '" & TextBox2.Text & "', '" & TextBox4.Text & "','" & TextBox3.Text & "', '" & TextBox5.Text & "','" & TextBox6.Text & "', '" & ComboBox1.Text & "', '" & ComboBox2.Text & "', '" & ComboBox3.Text & "', '" & ComboBox4.Text & "', '" & TextBox10.Text & "', '" & TextBox9.Text & "', '" & TextBox1.Text & "', '" & Label3.Text & "', '" & DASHBOARD.SS6.Text & "')"
                cmd = New MySqlCommand(inputdata, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Input Data Berhasil", "")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Batal" Then
            Call kondisiawal()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "Choose Image (*.JPG;*.PNG)|*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        Label3.Text = OpenFileDialog1.FileName
        PictureBox2.Load(Label3.Text)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "Choose Image (*.JPG;*.PNG)|*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        Label3.Text = OpenFileDialog1.FileName
        PictureBox2.Load(Label3.Text)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
End Class