Imports MySql.Data.MySqlClient
Public Class LOGIN
    Sub Terbuka()
        DASHBOARD.LOGINToolStripMenuItem.Enabled = False
        DASHBOARD.LOGOUTToolStripMenuItem.Enabled = True
        DASHBOARD.GANTIPASSWORDToolStripMenuItem.Enabled = True
        DASHBOARD.EXITToolStripMenuItem.Enabled = True
        DASHBOARD.MASTERDATAToolStripMenuItem.Enabled = True
        DASHBOARD.ABSENSIToolStripMenuItem.Enabled = True
        DASHBOARD.LAPORANToolStripMenuItem.Enabled = True
        DASHBOARD.INPUTDATAKERYAWANToolStripMenuItem.Enabled = True
        DASHBOARD.PictureBox3.Hide()
        DASHBOARD.PictureBox4.Hide()
        DASHBOARD.PictureBox5.Hide()
        DASHBOARD.PictureBox6.Hide()
        DASHBOARD.PictureBox7.Hide()
        DASHBOARD.PictureBox9.Hide()
        DASHBOARD.PictureBox10.Hide()
        DASHBOARD.PictureBox11.Hide()
        DASHBOARD.Label3.Show()
        DASHBOARD.Label4.Show()
        DASHBOARD.Label6.Show()
        DASHBOARD.Label7.Show()
        DASHBOARD.Label11.Show()
        DASHBOARD.Label12.Show()
        DASHBOARD.Label9.Show()
        DASHBOARD.Label10.Show()
        DASHBOARD.Label15.Show()
        DASHBOARD.Label14.Show()
        DASHBOARD.PictureBox2.Show()
    End Sub

    Sub Kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        CheckBox1.Checked = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim tglmysql As String
        'tglmysql = Format(Today, "dd/MM/yyyy")

        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MessageBox.Show("Username atau Password Tidak Boleh Kosong", "")
            TextBox1.Focus()
        Else
            Call Koneksi()
            cmd = New MySqlCommand("Select * from tb_admin where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Me.Close()
                Call Terbuka()
                MessageBox.Show("Selamat Datang!", "")
                If DASHBOARD.SS4.Text > "09.01.00" Then
                    DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
                End If

                If DASHBOARD.SS4.Text < "06.30.00" Then
                    DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
                    DASHBOARD.KEHADIRANKARYAWANToolStripMenuItem.Enabled = False
                Else
                    DASHBOARD.KEHADIRANKARYAWANToolStripMenuItem.Enabled = True
                End If

                If DASHBOARD.SS4.Text < "15.00.00" Then
                    DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
                Else
                    DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = True
                End If

                DASHBOARD.Label4.Text = rd!namakar
                DASHBOARD.Label6.Text = rd!nip
                DASHBOARD.SS6.Text = rd!username
                DASHBOARD.SS8.Text = rd!level
                DASHBOARD.Label11.Text = rd!keterangan
                ABSENSI.TextBox5.Text = rd!namakar
                ABSENSI.TextBox6.Text = rd!nip
                ABSENSI.TextBox2.Text = rd!statkar
                ABSENSI.TextBox1.Text = rd!jabatan
                PULANG.TextBox5.Text = rd!namakar
                PULANG.TextBox6.Text = rd!nip
                PULANG.TextBox2.Text = rd!statkar
                PULANG.TextBox1.Text = rd!jabatan
                DATA_KARYAWAN.TextBox7.Text = rd!namakar
                DATA_KARYAWAN.TextBox2.Text = rd!nip
                DATA_KARYAWAN.TextBox9.Text = rd!statkar
                DATA_KARYAWAN.TextBox1.Text = rd!jabatan
                DATA_KARYAWAN.TextBox10.Text = rd!golongan

                'Call Koneksi()
                'cmd = New MySqlCommand("Select * from tb_absensi where username = '" & DASHBOARD.SS6.Text & "', tanggal = '" & tglmysql & "'", con)
                'rd = cmd.ExecuteReader
                'rd.Read()
                'If rd.HasRows Then
                'DASHBOARD.Label14.Text = rd!stathadir
                'End If

                'If DASHBOARD.Label14.Text = "ALPA" Then
                'DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
                'Else
                'DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = True
                'End If

                'If DASHBOARD.Label14.Text = "" Then
                'DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = False
                'Else
                'DASHBOARD.ABSENSIPULANGToolStripMenuItem.Enabled = True
                'End If

                'Call Koneksi()
                'cmd = New MySqlCommand("Select * from tb_pulang where username = '" & DASHBOARD.SS6.Text & "'", con)
                'rd = cmd.ExecuteReader
                'rd.Read()
                'If rd.HasRows Then
                'DASHBOARD.Label15.Text = rd!statpulang
                'End If

                Call Koneksi()
                cmd = New MySqlCommand("Select * from tb_karyawan where username = '" & DASHBOARD.SS6.Text & "' or namakar = '" & DASHBOARD.Label4.Text & "' or nip = '" & DASHBOARD.Label6.Text & "'", con)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    DASHBOARD.PictureBox2.Show()
                    DASHBOARD.PictureBox2.ImageLocation = rd!profil
                    DASHBOARD.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                    DATA_KARYAWAN.TextBox8.Text = rd!namaibu
                    DATA_KARYAWAN.TextBox4.Text = rd!nik
                    DATA_KARYAWAN.TextBox3.Text = rd!alamat
                    DATA_KARYAWAN.TextBox5.Text = rd!nohp
                    DATA_KARYAWAN.TextBox6.Text = rd!email
                    DATA_KARYAWAN.ComboBox1.Text = rd!agama
                    DATA_KARYAWAN.ComboBox2.Text = rd!jkelamin
                    DATA_KARYAWAN.ComboBox3.Text = rd!warga
                    DATA_KARYAWAN.ComboBox4.Text = rd!statnikah

                    DATA_KARYAWAN.PictureBox2.ImageLocation = rd!profil
                    DATA_KARYAWAN.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                End If

                If DASHBOARD.SS8.Text = "KARYAWAN" Then
                    DASHBOARD.MasterDataLoginToolStripMenuItem.Enabled = False
                    DASHBOARD.LAPORANToolStripMenuItem.Enabled = False
                    DASHBOARD.INPUTDATAKERYAWANToolStripMenuItem.Enabled = False
                End If

                If DASHBOARD.SS8.Text = "OWNER" Then
                    DASHBOARD.MASTERDATAToolStripMenuItem.Enabled = False
                    DASHBOARD.ABSENSIToolStripMenuItem.Enabled = False
                    DASHBOARD.INPUTDATAKERYAWANToolStripMenuItem.Enabled = False

                    DASHBOARD.Label12.Hide()
                    DASHBOARD.Label11.Hide()
                    DASHBOARD.Label9.Hide()
                    DASHBOARD.Label10.Hide()
                    DASHBOARD.Label15.Hide()
                    DASHBOARD.Label14.Hide()
                    DASHBOARD.PictureBox8.Show()
                End If

            Else
                    MessageBox.Show("Username atau Password Salah!", "")
                Call Kondisiawal()
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Call Kondisiawal()
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LUPAPASSWORD.ShowDialog()
    End Sub
End Class
