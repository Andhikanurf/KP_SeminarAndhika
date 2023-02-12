Imports MySql.Data.MySqlClient
Public Class LAPORAN2
    Sub Kondisiawal()
        Call Koneksi()
        da = New MySqlDataAdapter("Select * from tb_pulang", con)
        ds = New DataSet
        da.Fill(ds, "tb_pulang")
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        ComboBox3.Text = ""
    End Sub

    Sub nip()
        Call Koneksi()
        ComboBox4.Items.Clear()
        cmd = New MySqlCommand("select * from tb_pulang", con)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox4.Items.Add(rd.Item(0))
        Loop
    End Sub

    Private Sub LAPORAN2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("01 - Januari")
        ComboBox1.Items.Add("02 - Februari")
        ComboBox1.Items.Add("03 - Maret")
        ComboBox1.Items.Add("04 - April")
        ComboBox1.Items.Add("05 - Mei")
        ComboBox1.Items.Add("06 - Juni")
        ComboBox1.Items.Add("07 - Juli")
        ComboBox1.Items.Add("08 - Agustus")
        ComboBox1.Items.Add("09 - September")
        ComboBox1.Items.Add("10 - Oktober")
        ComboBox1.Items.Add("11 - November")
        ComboBox1.Items.Add("12 - Desember")

        ComboBox2.Items.Clear()
        ComboBox2.Text = Date.Now.Year
        For i As Integer = 0 To 5
            ComboBox2.Items.Add(Date.Now.Year - i)
        Next

        ComboBox3.Items.Clear()
        ComboBox3.Text = Date.Now.Year
        For i As Integer = 0 To 5
            ComboBox3.Items.Add(Date.Now.Year - i)
        Next

        Label7.Text = "2023, 01, 01"
        Label10.Text = "2023, 01, 31"

        Label7.Text = Format(DateTimePicker2.Value, "yyyy, MM, dd")
        Label10.Text = Format(DateTimePicker3.Value, "yyyy, MM, dd")

        Call nip()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Call Koneksi()
        'cmd = New MySqlCommand("select * from tb_pulang where Tanggal = '" & DateTimePicker1.Value & "'", con)
        'rd = cmd.ExecuteReader
        'rd.Read()
        'If Not rd.HasRows Then
        'MessageBox.Show("Data Pada Tanggal Tersebut Tidak Ditemukan! ", "")
        'Else
        AxCrystalReport1.SelectionFormula = "totext({tb_pulang.tanggal})='" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "'"
        AxCrystalReport1.ReportFileName = "harian2.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
        Call Kondisiawal()
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Silahkan Isi Bulan dan Tahun Terlebih Dahulu", "", MessageBoxButtons.OK)
        Else
            AxCrystalReport1.SelectionFormula = "Month({tb_pulang.Tanggal})=" & Val(ComboBox1.Text) & " and year({tb_pulang.Tanggal})=" & Val(ComboBox2.Text) & ""
            AxCrystalReport1.ReportFileName = "bulanan2.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call Kondisiawal()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox4.Text = "" Then
            MessageBox.Show("Silahkan Isi NIP Terlebih Dahulu", "", MessageBoxButtons.OK)
        Else
            AxCrystalReport1.SelectionFormula = "totext({tb_pulang.NIP})='" & ComboBox4.Text & "'"
            AxCrystalReport1.ReportFileName = "pulangnip.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call Kondisiawal()
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Label7.Text = Format(DateTimePicker2.Value, "yyyy, MM, dd")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AxCrystalReport1.SelectionFormula = "({tb_pulang.tanggal}) in date ('" & Label7.Text & "') to date ('" & Label10.Text & "')"
        AxCrystalReport1.ReportFileName = "mingguan2.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
        Call Kondisiawal()
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        Label10.Text = Format(DateTimePicker3.Value, "yyyy, MM, dd")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ComboBox3.Text = "" Then
            MessageBox.Show("Silahkan Isi Bulan dan Tahun Terlebih Dahulu", "", MessageBoxButtons.OK)
        Else
            AxCrystalReport1.SelectionFormula = "Year({tb_pulang.tanggal})=" & Val(ComboBox3.Text) & ""
            AxCrystalReport1.ReportFileName = "tahunan2.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call Kondisiawal()
        End If
    End Sub
End Class