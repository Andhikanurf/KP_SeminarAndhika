Public Class DASHBOARD
    Sub Terkunci()
        LOGINToolStripMenuItem.Enabled = True
        GANTIPASSWORDToolStripMenuItem.Enabled = False
        LOGOUTToolStripMenuItem.Enabled = False
        MASTERDATAToolStripMenuItem.Enabled = False
        LAPORANToolStripMenuItem.Enabled = False
        ABSENSIToolStripMenuItem.Enabled = False
        INPUTDATAKERYAWANToolStripMenuItem.Enabled = False
        SS6.Text = ""
        SS8.Text = ""
        Label3.Hide()
        Label4.Hide()
        Label6.Hide()
        Label7.Hide()
        Label9.Hide()
        Label10.Hide()
        Label11.Hide()
        Label12.Hide()
        Label15.Hide()
        Label14.Hide()
        PictureBox2.Hide()
        PictureBox3.Show()
        PictureBox4.Show()
        PictureBox5.Show()
        PictureBox6.Show()
        PictureBox7.Show()
        PictureBox8.Hide()
        PictureBox9.Show()
        PictureBox10.Show()
        PictureBox11.Show()
    End Sub

    Private Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Terkunci()

        SS2.Text = Today
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SS4.Text = TimeOfDay
    End Sub

    Private Sub GANTIPASSWORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GANTIPASSWORDToolStripMenuItem.Click
        GANTI_PASSWORD.ShowDialog()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Call Terkunci()

        DATA_KARYAWAN.TextBox8.Text = ""
        DATA_KARYAWAN.TextBox4.Text = ""
        DATA_KARYAWAN.TextBox3.Text = ""
        DATA_KARYAWAN.TextBox5.Text = ""
        DATA_KARYAWAN.TextBox6.Text = ""
    End Sub

    Private Sub DATAKARYAWANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAKARYAWANToolStripMenuItem.Click
        DATA_KARYAWAN.ShowDialog()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        LOGIN.ShowDialog()
    End Sub

    'Private Sub GRAFIKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRAFIKToolStripMenuItem.Click
    '   GRAFIK.ShowDialog()
    'End Sub

    Private Sub KEHADIRANKARYAWANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KEHADIRANKARYAWANToolStripMenuItem.Click
        ABSENSI.ShowDialog()
    End Sub

    Private Sub ABSENSIPULANGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABSENSIPULANGToolStripMenuItem.Click
        PULANG.ShowDialog()
    End Sub

    Private Sub MasterDataLoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterDataLoginToolStripMenuItem.Click
        DATA_ADMIN.ShowDialog()
    End Sub

    Private Sub LAPORANABSENSIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANABSENSIToolStripMenuItem.Click
        LAPORAN1.ShowDialog()
    End Sub

    Private Sub LAPORANOVERTIMEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANOVERTIMEToolStripMenuItem.Click
        LAPORAN2.ShowDialog()
    End Sub

    Private Sub INPUTDATAKERYAWANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INPUTDATAKERYAWANToolStripMenuItem.Click
        INPUT.ShowDialog()

    End Sub
End Class
