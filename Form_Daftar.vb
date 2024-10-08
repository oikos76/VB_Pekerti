﻿Public Class Form_Daftar
    Dim SQL As String, LAdd As Boolean, LEdit As Boolean, tKode As String, tIndex As Integer
    Dim Proses As New ClsKoneksi
    Dim tblData As New DataTable

    Sub Data_Refresh()
        DGView.ColumnCount = 20
        DGView.Columns(0).Visible = True
        ResetTitle()
        Me.Cursor = Cursors.WaitCursor
        SQL = txtQuery.Text
        tblData = Proses.ExecuteQuery(SQL)
        DGView.Rows.Clear()
        If Me.Text = "Daftar Customer" Then
            DGView.Columns(0).HeaderText = "ID Rec"
            DGView.Columns(0).Width = 90
            DGView.Columns(1).HeaderText = "Nama"
            DGView.Columns(1).Width = 250
            DGView.Columns(2).HeaderText = "Alamat"
            DGView.Columns(2).Width = 250
            DGView.Columns(3).HeaderText = "Kota"
            DGView.Columns(3).Width = 200
            DGView.Columns(4).HeaderText = "Tlp"
            DGView.Columns(4).Width = 200
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !IDRec,
                    .Table.Rows(a) !Nama,
                    .Table.Rows(a) !alamat1,
                    .Table.Rows(a) !Kota,
                    .Table.Rows(a) !phone)
                Next (a)
            End With
        ElseIf Me.Text = "History DPL" Then
            DGView.Columns(0).HeaderText = "No PO"
            DGView.Columns(0).Width = 100
            DGView.Columns(1).HeaderText = "No DPL"
            DGView.Columns(1).Width = 100
            DGView.Columns(2).HeaderText = "No Boks"
            DGView.Columns(2).Width = 100
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGView.Columns(3).HeaderText = "Jumlah Boks"
            DGView.Columns(3).Width = 100
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGView.Columns(4).HeaderText = "Isi Tiap Boks"
            DGView.Columns(4).Width = 100
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGView.Columns(5).HeaderText = "Total"
            DGView.Columns(5).Width = 100
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim Total As Double = 0
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !NoPO,
                        .Table.Rows(a) !NoDPL,
                        .Table.Rows(a) !NoBoksAwal & " ~ " & .Table.Rows(a) !NoBoksAkhir,
                        Format(.Table.Rows(a) !JumlahBoks, "###,##0"),
                        Format(.Table.Rows(a) !TotalTiapBoks, "###,##0"),
                        Format(.Table.Rows(a) !QTYDPL, "###,##0"))
                    Total += .Table.Rows(a) !QTYDPL
                Next (a)
            End With
            DGView.Rows.Add("", "", "", "", "T O T A L  :", Format(Total, "###,##0"))
        ElseIf Me.Text = "Daftar Jurnal" Then
            DGView.Columns(0).HeaderText = "Id JurnalL"
            DGView.Columns(0).Width = 100
            DGView.Columns(1).HeaderText = "Tgl Jurnal"
            DGView.Columns(1).Width = 120
            DGView.Columns(2).HeaderText = "Uraian"
            DGView.Columns(2).Width = 200
            DGView.Columns(3).HeaderText = "Kode GL"
            DGView.Columns(3).Width = 200
            DGView.Columns(4).HeaderText = "Debet"
            DGView.Columns(4).Width = 100
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(5).HeaderText = "Kredit"
            DGView.Columns(5).Width = 100
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !IDRec,
                                    Format(.Table.Rows(a) !tanggal, "dd-MM-yyyy"),
                                    .Table.Rows(a) !uraian,
                                    .Table.Rows(a) !accountcode + "  " + .Table.Rows(a) !ketacccode,
                                    Format(.Table.Rows(a) !Debet, "###,##0"),
                                    Format(.Table.Rows(a) !Kredit, "###,##0"))
                Next (a)
            End With
        ElseIf Me.Text = "Daftar DPL" Then
            DGView.Columns(0).HeaderText = "No DPL"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Tgl DPL"
            DGView.Columns(1).Width = 140
            DGView.Columns(2).HeaderText = "No PO "
            DGView.Columns(2).Width = 150
            DGView.Columns(3).HeaderText = "Importir"
            DGView.Columns(3).Width = 200
            DGView.Columns(4).HeaderText = " "
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !NoDPL,
                                    Format(.Table.Rows(a) !TglDPL, "dd-MM-yyyy"),
                                    .Table.Rows(a) !NoPO,
                                    .Table.Rows(a) !Importir)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar LHP" Then
            DGView.Columns(0).HeaderText = "No LHP"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Perajin"
            DGView.Columns(1).Width = 250
            DGView.Columns(2).HeaderText = "Tgl.LHP "
            DGView.Columns(2).Width = 120
            DGView.Columns(3).HeaderText = " "
            DGView.Columns(4).HeaderText = " "
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !NoLHP,
                                    .Table.Rows(a) !NamaPerajin,
                                    Format(.Table.Rows(a) !TglLHP, "dd-MM-yyyy"))
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Pra LHP" Then
            DGView.Columns(0).HeaderText = "No Pra LHP"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Perajin"
            DGView.Columns(1).Width = 300
            DGView.Columns(2).HeaderText = " "
            DGView.Columns(3).HeaderText = " "
            DGView.Columns(4).HeaderText = " "
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !NoPraLHP,
                                    .Table.Rows(a) !NamaPerajin)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Produk DPL" Then
            DGView.Columns(0).HeaderText = "KodeProduk"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Kode Buyer"
            DGView.Columns(1).Width = 150
            DGView.Columns(2).HeaderText = "Produk"
            DGView.Columns(2).Width = 250
            DGView.Columns(3).HeaderText = "Importir"
            DGView.Columns(3).Width = 150
            DGView.Columns(4).HeaderText = "No.PO"
            DGView.Columns(4).Width = 150
            DGView.Columns(5).HeaderText = "Jumlah PO"
            DGView.Columns(5).Width = 150
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.Cursor = Cursors.WaitCursor
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !Kode_Produk,
                                    .Table.Rows(a) !Kode_Buyer,
                                    .Table.Rows(a) !Deskripsi,
                                    .Table.Rows(a) !Nama,
                                    .Table.Rows(a) !NoPO,
                                    Format(.Table.Rows(a) !Jumlah, "###,##0"))
                Next (a)
            End With
            Me.Cursor = Cursors.Default
        ElseIf Me.Text = "Daftar Produk Pra LHP" Then
            DGView.Columns(0).HeaderText = "KodeProduk + SP"
            DGView.Columns(0).Width = 1
            DGView.Columns(1).HeaderText = "Kode Produk"
            DGView.Columns(1).Width = 150
            DGView.Columns(2).HeaderText = "Produk"
            DGView.Columns(2).Width = 250
            DGView.Columns(3).HeaderText = "Tgl Terima"
            DGView.Columns(3).Width = 150
            DGView.Columns(4).HeaderText = "No.SP"
            DGView.Columns(4).Width = 150
            DGView.Columns(5).HeaderText = "No.PraLHP"
            DGView.Columns(5).Width = 150
            Me.Cursor = Cursors.WaitCursor
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(Microsoft.VisualBasic.Left(.Table.Rows(a) !Kode_Produk & Space(25), 25) & Microsoft.VisualBasic.Right(Space(25) & .Table.Rows(a) !NoSP, 25),
                                    .Table.Rows(a) !Kode_Produk,
                                    .Table.Rows(a) !Produk,
                                    Format(.Table.Rows(a) !tglTerima, "dd-MM-yyyy"),
                                    .Table.Rows(a) !NoSP,
                                    .Table.Rows(a) !NoPraLHP)
                Next (a)
            End With
            Me.Cursor = Cursors.Default
        ElseIf Me.Text = "Riwayat Harga SP" Then
            DGView.Columns(0).HeaderText = "IDREC"
            DGView.Columns(0).Width = 1
            DGView.Columns(1).HeaderText = "Harga Beli"
            DGView.Columns(1).Width = 100
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(2).HeaderText = "No DPB"
            DGView.Columns(2).Width = 100
            DGView.Columns(3).HeaderText = "Tgl DPB"
            DGView.Columns(3).Width = 100
            DGView.Columns(4).HeaderText = "Perajin"
            DGView.Columns(4).Width = 200
            DGView.Columns(5).HeaderText = ""
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !IDREC,
                    Format(.Table.Rows(a) !HargaBeli, "###,##0.00"),
                    .Table.Rows(a) !nodpb, Format(.Table.Rows(a) !TglDPB, "dd-MM-yyyy"),
                    .Table.Rows(a) !Perajin)

                Next (a)
            End With
        ElseIf Me.Text = "Riwayat Harga" Then
            DGView.Columns(0).HeaderText = "IDREC"
            DGView.Columns(0).Width = 1
            DGView.Columns(1).HeaderText = "Harga FOB (PI)"
            DGView.Columns(1).Width = 100
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(2).HeaderText = "No PI"
            DGView.Columns(2).Width = 100
            DGView.Columns(3).HeaderText = "Tgl PI"
            DGView.Columns(4).HeaderText = "No PO"
            DGView.Columns(5).HeaderText = "tGL PO"
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !IDREC,
                    Format(.Table.Rows(a) !HargaFOB, "###,##0.00") +
                                    Microsoft.VisualBasic.Right(Space(5) + .Table.Rows(a) !MataUang, 5),
                    .Table.Rows(a) !NoPI, Format(.Table.Rows(a) !TGLPI, "dd-MM-yyyy"),
                    .Table.Rows(a) !NoPO, Format(.Table.Rows(a) !TGLPo, "dd-MM-yyyy"))

                Next (a)
            End With
        ElseIf Me.Text = "Daftar DPB" Then
            DGView.Columns(0).HeaderText = "No DPB"
            DGView.Columns(0).Width = 130
            DGView.Columns(1).HeaderText = "Tgl DPB"
            DGView.Columns(1).Width = 125
            DGView.Columns(2).HeaderText = "No. SP"
            DGView.Columns(2).Width = 130
            DGView.Columns(3).HeaderText = "No.LHP "
            DGView.Columns(3).Width = 130
            DGView.Columns(4).HeaderText = "Perajin "
            DGView.Columns(4).Width = 150
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !nodpb,
                                    Format(.Table.Rows(a) !TglDPB, "dd-MM-yyyy"),
                                    .Table.Rows(a) !NoSP, .Table.Rows(a) !NoLHP,
                                    .Table.Rows(a) !Perajin)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Kode GL" Then
            DGView.Columns(0).HeaderText = "COA"
            DGView.Columns(0).Width = 2
            DGView.Columns(1).HeaderText = "Kode GL"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 150
            DGView.Columns(2).HeaderText = "Nama Account"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).Width = 390
            DGView.Columns(3).HeaderText = ""
            DGView.Columns(3).Width = 100
            DGView.Columns(4).HeaderText = ""
            DGView.Columns(4).Width = 100
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !no_PERKIRAAN,
                    .Table.Rows(a) !no_PERKIRAAN,
                    .Table.Rows(a) !NM_PERKIRAAN)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Supplier" Then
            DGView.Columns(0).HeaderText = "ID Supplier"
            DGView.Columns(0).Width = 90
            DGView.Columns(1).HeaderText = "Supplier"
            DGView.Columns(1).Width = 250
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).HeaderText = "Alamat"
            DGView.Columns(2).Width = 300
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "Tlp"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).HeaderText = "Kota"
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !IdRec, .Table.Rows(a) !Nama,
                    .Table.Rows(a) !alamat1, .Table.Rows(a) !phone, .Table.Rows(a) !kota)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Main Menu Program" Then
            DGView.Columns(0).HeaderText = "Menu"
            DGView.Columns(0).Width = 1
            DGView.Columns(1).HeaderText = "Menu"
            DGView.Columns(1).Width = 200
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !menu, .Table.Rows(a) !menu)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Company" Then
            Dim tLevel As Integer = 0
            DGView.Columns(0).HeaderText = "CompCode"
            DGView.Columns(0).Width = 1
            DGView.Columns(1).HeaderText = "Company"
            DGView.Columns(1).Width = 200
            DGView.Columns(2).HeaderText = "Alamat"
            DGView.Columns(2).Width = 200
            DGView.Columns(3).HeaderText = "Tlp"
            DGView.Columns(3).Width = 80
            DGView.Columns(4).HeaderText = "WP"
            DGView.Columns(4).Width = 80
            DGView.Columns(5).HeaderText = "NPWP"
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !compcode, .Table.Rows(a) !company, .Table.Rows(a) !alamat,
                    .Table.Rows(a) !tlp, .Table.Rows(a) !wp, .Table.Rows(a) !npwp)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar User" Then
            Dim tLevel As Integer = 0
            DGView.Columns(0).HeaderText = "User ID"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Nama User"
            DGView.Columns(1).Width = 150
            DGView.Columns(2).HeaderText = "Last Login"
            DGView.Columns(2).Width = 250
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !userid, .Table.Rows(a) !username,
                                    Format(.Table.Rows(a) !lastlogin, "dd-MM-yyyy  hh:mm:ss"))
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Bahan" Then
            DGView.Columns(0).HeaderText = "Kode Bahan"
            DGView.Columns(0).Width = 5
            DGView.Columns(1).HeaderText = "Nama Bahan"
            DGView.Columns(2).HeaderText = "Kode"
            DGView.Columns(3).HeaderText = "English Name"
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !KodeBahan,
                                    .Table.Rows(a) !NamaIndonesia,
                                    .Table.Rows(a) !KodeBahan,
                                    .Table.Rows(a) !NamaInggris)
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Kelompok (Fungsi)" Then
            DGView.Columns(0).HeaderText = "Kode Fungsi"
            DGView.Columns(0).Width = 5
            DGView.Columns(1).HeaderText = "Nama Fungsi"
            DGView.Columns(1).Width = 300
            DGView.Columns(2).HeaderText = "Kode"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(3).HeaderText = "English Name"
            DGView.Columns(3).Width = 300
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !KodeFungsi,
                                    .Table.Rows(a) !NamaIndonesia,
                                    .Table.Rows(a) !KodeFungsi,
                                    .Table.Rows(a) !NamaInggris)
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Produk" Then
            DGView.Columns(0).HeaderText = "IDRec"
            DGView.Columns(0).Width = 5
            DGView.Columns(1).HeaderText = "Deskripsi"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 500
            DGView.Columns(2).HeaderText = "Kode Produk"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).Width = 100
            DGView.Columns(3).HeaderText = "Satuan"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(3).Width = 90
            DGView.Columns(4).HeaderText = "Panjang"
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(4).Width = 90
            DGView.Columns(5).HeaderText = "Lebar"
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(5).Width = 90
            DGView.Columns(6).HeaderText = "Tinggi"
            DGView.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(6).Width = 90
            DGView.Columns(7).HeaderText = "Diameter"
            DGView.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(7).Width = 90
            DGView.Columns(8).HeaderText = "Berat"
            DGView.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(8).Width = 90
            DGView.Columns(9).HeaderText = "Tebal"
            DGView.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(9).Width = 90
            DGView.Columns(10).HeaderText = "Contoh"
            DGView.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(10).Width = 90
            DGView.Columns(11).HeaderText = "Fungsi_IND"
            DGView.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(11).Width = 150
            DGView.Columns(12).HeaderText = "Perajin"
            DGView.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(12).Width = 250
            DGView.Columns(13).HeaderText = "Kapasitas"
            DGView.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(13).Width = 100
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !KodeProduk,
                                    IIf(IsDBNull(.Table.Rows(a) !Deskripsi), "", .Table.Rows(a) !Deskripsi),
                                    .Table.Rows(a) !KodeProduk,
                                    IIf(IsDBNull(.Table.Rows(a) !Satuan), "", .Table.Rows(a) !Satuan),
                                    Format(.Table.Rows(a) !Panjang, "###,##0.00"),
                                    Format(.Table.Rows(a) !Lebar, "###,##0.00"),
                                    Format(.Table.Rows(a) !Tinggi, "###,##0.00"),
                                    Format(.Table.Rows(a) !Diameter, "###,##0.00"),
                                    Format(.Table.Rows(a) !Berat, "###,##0.00"),
                                    Format(.Table.Rows(a) !Tebal, "###,##0.00"),
                                    IIf(.Table.Rows(a) !contoh = 1, "Ada Contoh", "Tidak Ada Contoh"),
                                    .Table.Rows(a) !fungsi_ind,
                                    .Table.Rows(a) !Kode_Perajin + " - " + IIf(IsDBNull(.Table.Rows(a) !Perajin), "", .Table.Rows(a) !Perajin),
                                    Format(.Table.Rows(a) !Kapasitas, "###,##0"))
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Inventaris" Then
            DGView.Columns(0).HeaderText = "IdRec"
            DGView.Columns(0).Width = 5
            DGView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).HeaderText = "Kode GL"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 150
            DGView.Columns(2).HeaderText = "Account"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).Width = 200
            DGView.Columns(3).HeaderText = "Tgl.Beli"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).Width = 100
            DGView.Columns(4).HeaderText = "Nilai Perolehan"
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(4).Width = 150
            DGView.Columns(5).HeaderText = "% Penyusutan"
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(5).Width = 100
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !idrec, .Table.Rows(a) !kodegl,
                                    .Table.Rows(a) !namaAccount,
                                    Format(.Table.Rows(a) !tglBeli, "dd-MM-yyyy"),
                                    Format(.Table.Rows(a) !hargabeli, "###,##0"),
                                    Replace(Format(.Table.Rows(a) !penyusutan, "###,##0.00"), ".00", "") & " %")
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar SP" Then
            DGView.Columns(0).HeaderText = "No. SP"
            DGView.Columns(0).Width = 150
            DGView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(1).HeaderText = "Perajin"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 350
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !NoSP,
                                    .Table.Rows(a) !Perajin)
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar SP Contoh" Then
            DGView.Columns(0).HeaderText = "No. SP"
            DGView.Columns(0).Width = 150
            DGView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(1).HeaderText = "Perajin"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 350
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !NoSP,
                                    .Table.Rows(a) !Perajin)
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar PO" Or Trim(Me.Text) = "Daftar PO-DPL" Then
            DGView.Columns(0).HeaderText = "No. PO"
            DGView.Columns(0).Width = 100
            DGView.Columns(1).HeaderText = "Importir"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 250
            DGView.Columns(2).HeaderText = "Kode Importir"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "Tgl PO"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).HeaderText = "Tgl Kirim"
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !nopo,
                                    IIf(IsDBNull(.Table.Rows(a) !importir), "", .Table.Rows(a) !importir),
                                    .Table.Rows(a) !KodeImportir,
                                    Format(.Table.Rows(a) !tglpo, "dd-MM-yyyy"),
                                    Format(.Table.Rows(a) !tglKirim, "dd-MM-yyyy"))
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Produk SP" Then

            DGView.Columns(0).HeaderText = "Kode Produk"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Deskripsi Produk"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 250
            DGView.Columns(2).HeaderText = "Importir"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "No PO"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).Width = 120
            DGView.Columns(4).HeaderText = "Harga Beli RP"
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(4).Width = 100
            DGView.Columns(5).HeaderText = ""
            DGView.Columns(6).HeaderText = ""
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !KodeProduk,
                                    IIf(IsDBNull(.Table.Rows(a) !Produk), "", .Table.Rows(a) !Produk),
                                    .Table.Rows(a) !KodeImportir,
                                    .Table.Rows(a) !Importir,
                                    .Table.Rows(a) !NoPO,
                                    Format(.Table.Rows(a) !HargaBeliRp, "###,##0.00"))
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Produk PO" Then
            DGView.Columns(0).HeaderText = "Kode Produk"
            DGView.Columns(0).Width = 100
            DGView.Columns(1).HeaderText = "Deskripsi Produk"
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(1).Width = 300
            DGView.Columns(2).HeaderText = "Kode Buyer"
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "Importir"
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).Width = 150
            DGView.Columns(4).HeaderText = "No PO"
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).Width = 100
            DGView.Columns(5).HeaderText = "Jumlah PO"
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !Kode_Produk,
                                    IIf(IsDBNull(.Table.Rows(a) !Deskripsi), "", .Table.Rows(a) !Deskripsi),
                                    .Table.Rows(a) !Kode_Importir,
                                    .Table.Rows(a) !Nama,
                                    .Table.Rows(a) !NoPO,
                                    Replace(Format(.Table.Rows(a) !Jumlah, "###,##0.00"), ".00", ""))
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Importir" Then
            DGView.Columns(0).HeaderText = "Kode Importir"
            DGView.Columns(0).Width = 100
            DGView.Columns(1).HeaderText = "Nama"
            DGView.Columns(1).Width = 200
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).HeaderText = "Negara Asal"
            DGView.Columns(2).Width = 100
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(3).HeaderText = "Jenis"
            DGView.Columns(3).Width = 120
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).HeaderText = "Alamat"
            DGView.Columns(4).Width = 500
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(5).HeaderText = "Alamat Kirim"
            DGView.Columns(6).HeaderText = "Notify"
            DGView.Columns(7).HeaderText = "Port"
            DGView.Columns(8).HeaderText = "Catatan"
            DGView.Columns(9).HeaderText = "Telepon"
            DGView.Columns(10).HeaderText = "Fax"
            DGView.Columns(11).HeaderText = "Email"
            DGView.Columns(12).HeaderText = "Contact Person"
            DGView.Columns(13).HeaderText = "Masih Beli (Y/N)"
            DGView.Columns(14).HeaderText = "Tgl.Masuk"
            DGView.Columns(15).HeaderText = "Last Update"

            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !KodeImportir,
                                    .Table.Rows(a) !nama,
                                    .Table.Rows(a) !NegaraAsal,
                                    .Table.Rows(a) !Jenis,
                                    .Table.Rows(a) !Alamat, .Table.Rows(a) !AlamatKirim,
                                    .Table.Rows(a) !Notify,
                                    .Table.Rows(a) !Port,
                                    .Table.Rows(a) !Catatan,
                                    .Table.Rows(a) !Telepon, .Table.Rows(a) !Fax, .Table.Rows(a) !Email,
                                    .Table.Rows(a) !ContactPerson,
                                    .Table.Rows(a) !BeliYN,
                                    Format(.Table.Rows(a) !tglMasuk, "dd-MM-yyyy"),
                                    Format(.Table.Rows(a) !LastUPD, "dd-MM-yyyy"))
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Perajin" Then
            DGView.Columns(0).HeaderText = "Kode Perajin"
            DGView.Columns(0).Width = 5
            DGView.Columns(1).HeaderText = "Nama"
            DGView.Columns(1).Width = 200
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).HeaderText = "Kode"
            DGView.Columns(2).Width = 60
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGView.Columns(3).HeaderText = "Wilayah Produksi"
            DGView.Columns(3).Width = 120
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).HeaderText = "Alamat"
            DGView.Columns(4).Width = 500
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !KodePerajin,
                                    .Table.Rows(a) !nama, .Table.Rows(a) !KodePerajin,
                                    .Table.Rows(a) !WilayahProduksi,
                                    .Table.Rows(a) !Alamat)
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar Produk PO (SP)" Then
            DGView.Columns(0).HeaderText = "Kode Produk"
            DGView.Columns(0).Width = 150
            DGView.Columns(1).HeaderText = "Produk"
            DGView.Columns(1).Width = 200
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).HeaderText = "Importir"
            DGView.Columns(2).Width = 150
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "NoPO"
            DGView.Columns(3).Width = 120
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(4).HeaderText = "Jumlah PO"
            DGView.Columns(4).Width = 100
            DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGView.Columns(5).HeaderText = "Jumlah SP"
            DGView.Columns(5).Width = 100
            DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim QtySP As Double = 0, QtyDiSP As Double = 0
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    QtyDiSP = Proses.QTYProdukSP(.Table.Rows(a) !Kode_Produk, .Table.Rows(a) !NoPO)
                    QtySP = .Table.Rows(a) !Jumlah - QtyDiSP
                    If QtySP <> 0 Then
                        DGView.Rows.Add(.Table.Rows(a) !Kode_Produk,
                                    .Table.Rows(a) !Deskripsi,
                                    .Table.Rows(a) !Nama,
                                    .Table.Rows(a) !NoPO,
                                    Format(.Table.Rows(a) !Jumlah, "###,##0"),
                                    Format(QtySP, "###,##0"))
                    End If
                Next (a)
            End With
        ElseIf Trim(Me.Text) = "Daftar PI" Then
            DGView.Columns(0).HeaderText = "No. PI"
            DGView.Columns(0).Width = 140
            DGView.Columns(1).HeaderText = "Tgl.PI"
            DGView.Columns(1).Width = 140
            DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(2).HeaderText = "Kode Importir"
            DGView.Columns(2).Width = 100
            DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGView.Columns(3).HeaderText = "Importir"
            DGView.Columns(3).Width = 190
            DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '  select nopi, nopo, tglpi, statuspi, Kode_Importir, importir
            '          From t_pi
            'Where aktifyn = 'Y'
            'And Kode_Importir = 'E0701'
            'group by nopi, nopo, tglpi, statuspi, Kode_Importir, importir

            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    Application.DoEvents()
                    DGView.Rows.Add(.Table.Rows(a) !nopi,
                                    .Table.Rows(a) !tglPI,
                                    .Table.Rows(a) !Kode_Importir,
                                    .Table.Rows(a) !importir)
                Next (a)
            End With
        ElseIf Me.Text = "Daftar Toko" Then
            DGView.Columns(0).HeaderText = "Id Toko"
            DGView.Columns(0).Width = 80
            DGView.Columns(1).HeaderText = "Nama Toko"
            DGView.Columns(1).Width = 250
            DGView.Columns(2).HeaderText = "Alamat"
            DGView.Columns(2).Width = 280
            DGView.Columns(3).HeaderText = "Contact Person"
            DGView.Columns(3).Width = 120
            DGView.Columns(4).HeaderText = "Tlp"
            DGView.Columns(4).Width = 100
            DGView.Columns(5).HeaderText = ""
            DGView.Columns(6).HeaderText = ""
            DGView.Columns(7).HeaderText = ""
            DGView.Columns(8).HeaderText = ""
            DGView.Columns(9).HeaderText = ""
            DGView.Columns(10).HeaderText = ""
            DGView.Rows.Clear()
            With tblData.Columns(0)
                For a = 0 To tblData.Rows.Count - 1
                    DGView.Rows.Add(.Table.Rows(a) !idrec,
                    .Table.Rows(a) !nama,
                    .Table.Rows(a) !alamat1 + " " + .Table.Rows(a) !alamat2,
                    .Table.Rows(a) !contactperson,
                    .Table.Rows(a) !tlpcp)
                Next (a)
            End With
        Else
            MsgBox("Please cek this condition code! :" & Me.Text)
            DGView.DataSource = tblData
        End If
        DGView.Columns(0).ReadOnly = True
        Me.Cursor = Cursors.Default
        If DGView.RowCount <> 0 Then
            FrmMenuUtama.TSKeterangan.Text = DGView.Rows(0).Cells(0).Value
        End If
    End Sub

    Private Sub Form_Daftar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FrmMenuUtama.TSKeterangan.Visible = True
        DGView.GridColor = Color.Red
        DGView.CellBorderStyle = DataGridViewCellBorderStyle.None
        DGView.BackgroundColor = Color.LightGray

        DGView.DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen     'LightSkyBlue
        DGView.DefaultCellStyle.SelectionForeColor = Color.White

        DGView.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DGView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGView.AllowUserToResizeColumns = True

        DGView.RowsDefaultCellStyle.BackColor = Color.LightCyan
        DGView.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        DGView.ColumnHeadersDefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter

        With Me.DGView.RowTemplate
            .Height = 32
            .MinimumHeight = 32
        End With
        tCari.Text = ""
        Data_Refresh()
        txtQuery.Visible = False
    End Sub

    Private Sub DGView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGView.CellClick
        FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
    End Sub


    Private Sub DGView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGView.KeyPress
        If e.KeyChar = Chr(13) Then
            If DGView.RowCount = 1 Then
                'DGView.Rows(DGView.CurrentCell.RowIndex).Selected = True
                FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
                'Else
                '    FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
            End If
            Me.Close()
        End If
    End Sub


    Private Sub DGView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGView.CellDoubleClick
        FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
        Me.Close()
    End Sub

    Private Sub tCari_TextChanged(sender As Object, e As EventArgs) Handles tCari.TextChanged

    End Sub

    Private Sub DGView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGView.CellContentClick

    End Sub

    Private Sub tCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCari.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim mKondisi As String = ""
            If Trim(Me.Text) = "Daftar Barang" Then
                Dim kodetoko As String = Mid(FrmMenuUtama.Kode_Toko.Text, 4, 2)
                txtQuery.Text = "Select * t " &
                " From M_Barang " &
                "Where Nama like '" & tCari.Text & "%' " &
                "  and AktifYN = 'Y' " &
                "Order By IDRec, Nama "
            ElseIf Trim(Me.Text) = "Daftar Jurnal" Then
                If Trim(param1.Text) = "" Then
                    MsgBox("Jenis Jurnal Belum di pilih !", vbCritical + vbOKOnly, ".:Warning !")
                    Exit Sub
                End If
                Dim tPeriode As String = Format(Now, "yyMM")
                txtQuery.Text = "Select * From T_Jurnal " &
                    "Where AktifYN = 'Y' " &
                    " And convert(char(4), tanggal, 12) = '" & tPeriode & "' " &
                    " And JenisJurnal = '" & param1.Text & "' " &
                    " And uraian like '%" & tCari.Text & "%' " &
                    "Order By IdRec, NoUrut "
            ElseIf Trim(Me.Text) = "Daftar PO" Or Trim(Me.Text) = "Daftar PO-DPL" Then
                txtQuery.Text = "Select NoPO, m_KodeImportir.Nama Importir, TglPO, KodeImportir, max(t_PO.tglKirim) tglKirim  " &
                " From T_PO Inner Join m_KodeImportir on Kode_Importir = KodeImportir " &
                "Where T_PO.AktifYN = 'Y' " &
                "  and nopo like '%" & tCari.Text & "%' " &
                "Group By NoPO, m_KodeImportir.Nama, TglPO, KodeImportir " &
                "Order By TglPO Desc, NoPO Desc "
            ElseIf Trim(Me.Text) = "Daftar Barang PO" Then
                txtQuery.Text = "SELECT Deskripsi, Kode_Buyer, Kode_Produk, Kode_Importir, " &
                "      m_KodeImportir.Nama, T_PO.NoPO, t_PO.Jumlah " &
                " FROM t_PO inner join m_KodeProduk ON " &
                "      m_KodeProduk.KodeProduk = t_PO.Kode_produk " &
                "      INNER JOIN m_KodeImportir on Kode_Importir = KodeImportir " &
                "WHERE t_PO.AktifYN = 'Y' " &
                "  And T_PO.NOPO = '" & param1.Text & "' " &
                "  And Deskripsi like '%" & tCari.Text & "%' " &
                "ORDER BY kode_buyer"
            ElseIf Trim(Me.Text) = "Daftar Produk PO (SP)" Then
                txtQuery.Text = "Select Deskripsi, Kode_Buyer, Kode_Produk, Kode_Importir, " &
                   " m_KodeImportir.Nama, T_PO.NoPO, t_PO.Jumlah " &
                   " From t_PO inner join m_KodeProduk ON " &
                   " m_KodeProduk.KodeProduk = t_PO.Kode_produk " &
                   " inner join m_KodeImportir on Kode_Importir = KodeImportir " &
                   "Where t_PO.AktifYN = 'Y' " &
                   "  And T_PO.NOPO = '" & param1.Text & "' " &
                   "  And Deskripsi like '%" & tCari.Text & "%' "
            ElseIf Trim(Me.Text) = "Daftar Produk PO" Then
                txtQuery.Text = "SELECT Deskripsi, Kode_Buyer, Kode_Produk, Kode_Importir, " &
                    "      m_KodeImportir.Nama, T_PO.NoPO, t_PO.Jumlah, file_foto " &
                    " FROM t_PO inner join m_KodeProduk ON " &
                    "      m_KodeProduk.KodeProduk = t_PO.Kode_produk " &
                    "      INNER JOIN m_KodeImportir on Kode_Importir = KodeImportir " &
                    "WHERE t_PO.AktifYN = 'Y' " &
                    "  And T_PO.NOPO = '" & param1.Text & "' " &
                    "  And Deskripsi like '%" & tCari.Text & "%'  " &
                    "ORDER BY kode_buyer"
            ElseIf Me.Text = "Daftar Toko" Then
                txtQuery.Text = "Select * " &
                " From M_Toko " &
                "Where AktifYN = 'Y' " &
                "  And (nama like '%" & tCari.Text & "%' or idrec like '%" & tCari.Text & "%') " &
                "Order By idrec"
            ElseIf Me.Text = "Daftar Supplier" Then
                txtQuery.Text = "Select IdRec, Nama, Alamat1, Phone, Kota " &
                " From M_Supplier " &
                "Where AktifYN = 'Y' " &
                "  And Nama Like '" & tCari.Text & "%' " &
                "Order By Nama "
            ElseIf Trim(Me.Text) = "Daftar Produk SP" Then
                txtQuery.Text = "Select NoPO, Importir, KodeImportir, HargaBeliRP, Produk, KodeProduk " &
                    " From T_SP " &
                    "Where AktifYN = 'Y' " &
                    " And Produk like '%" & Trim(tCari.Text) & "%' " &
                    " And NoSP = '" & param1.Text & "' "
            ElseIf Trim(Me.Text) = "Daftar DPB" Then
                txtQuery.Text = "Select distinct NoDPB, TglDPB, t_DPB.NoSP, NoLHP, Perajin, right(NoDPB,2) + left(NoDPB,3)  " &
                    " From t_DPB Inner Join T_SP on T_DPB.NoSP = T_SP.NoSP " &
                    "Where t_DPB.AktifYN = 'Y' " &
                    " AND  NoDPB like '%" & Trim(tCari.Text) & "%' " &
                    " AND year(TglDPB) > 2000 " &
                    "Order By right(NoDPB,2) + left(NoDPB,3) Desc"
            ElseIf Trim(Me.Text) = "Daftar PI" Then
                txtQuery.Text = "Select  nopi, nopo, tglpi, statuspi, Kode_Importir, importir " &
                    " From t_PI " &
                    "Where AktifYN = 'Y' " &
                    "  and NoPI like '%" & tCari.Text & "%' " &
                    "Group By nopi, nopo, tglpi, statuspi, Kode_Importir, importir " &
                    "ORDER BY TglPI Desc, NoPI "
            ElseIf Me.Text = "Daftar SP" Then
                txtQuery.Text = "Select NoSP, Kode_Perajin, Perajin  " &
                    " From T_SP " &
                    "Where T_SP.AktifYN = 'Y' " &
                    " and NoSP like '%" & tCari.Text & "%' " &
                    "Group By NoSP, Kode_Perajin, Perajin " &
                    "Order By right(NoSP,2) Desc, nosp desc "
            ElseIf Me.Text = "Daftar SP Contoh" Then
                txtQuery.Text = "Select NoSP, T_SPContoh.Kode_Perajin, m_KodePerajin.Nama Perajin  " &
                    " From T_SPContoh inner join m_KodePerajin on T_SPContoh.Kode_Perajin = m_KodePerajin.KodePerajin " &
                    "Where T_SPContoh.AktifYN = 'Y' " &
                    " And nosp like '" & tCari.Text & "%' " &
                    "Group By NoSP, Kode_Perajin, m_KodePerajin.Nama, TglSP, right(nosp,3)+left(nosp,3)  " &
                    "Order By TglSP desc, right(nosp,3)+left(nosp,3) desc "
            ElseIf Me.Text = "Daftar User" Then
                txtQuery.Text = "Select * " &
                    " From m_User " &
                    "Where AktifYN = 'Y' and userid <> 'EKO_K' " &
                    "  And userid like '%" & tCari.Text & "%' " &
                    "Order By userid "
            ElseIf Me.Text = "Daftar Perajin" Then
                txtQuery.Text = " Select A.* " &
                " From m_KodePerajin A " &
                " Where A.AktifYN = 'Y' " &
                "   AND Nama LIKE '%" & tCari.Text & "%' " &
                " Order By Nama "
            ElseIf Me.Text = "Daftar Importir"
                txtQuery.Text = "Select * " &
                " From m_KodeImportir " &
                "Where AktifYN = 'Y' " &
                "  And (nama Like '%" & tCari.Text & "%') " &
                "Order By nama "
            ElseIf Me.Text = "Daftar Inventaris"
                txtQuery.Text = "Select * " &
                " From m_Penyusutan " &
                "Where AktifYN = 'Y' " &
                "  And (namaAccount Like '%" & tCari.Text & "%') " &
                "Order By namaAccount "
            ElseIf Me.Text = "Daftar Produk"
                txtQuery.Text = "Select * " &
                " From m_KodeProduk " &
                "Where AktifYN = 'Y' " &
                "  And ( KodeProduk Like '%" & tCari.Text & "%' or Deskripsi Like '%" & tCari.Text & "%') " &
                "Order By Deskripsi "
            ElseIf Me.Text = "Daftar DPL" Then
                If Trim(tCari.Text) <> "" Then
                    mKondisi = "  And T_DPL.NoDPL like '%" & Trim(tCari.Text) & "%' "
                Else
                    mKondisi = ""
                End If
                txtQuery.Text = "Select Distinct NoDPL, tglDPL, max(T_DPL.NoPO) NOPO, T_DPL.Importir, RIGHT(T_DPL.NoDPL,2) + LEFT(T_DPL.NoDPL,3)  " &
                    " From t_DPL INNER JOIN t_PO ON t_DPL.NoPO = t_PO.NoPO AND t_DPL.KodeProduk = t_PO.Kode_Produk INNER JOIN " &
                    "      t_PI ON t_PO.NoPO = t_PI.NoPO AND t_PO.Kode_Produk = t_PI.Kode_Produk " &
                    "Where T_DPL.AktifYN = 'Y' " & mKondisi & " " &
                    "Group By NoDPL, TglDPL, T_DPL.Importir, RIGHT(T_DPL.NoDPL,2) + LEFT(T_DPL.NoDPL,3)   " &
                    "Order By TGLDPL DESC "
            ElseIf Me.Text = "Daftar Kode GL"
                txtQuery.Text = "Select * From M_PERKIRAAN " &
                        "Where AktifYN = 'Y' " &
                        "  And (NM_PERKIRAAN like '%" & tCari.Text & "%' or " &
                        "      NO_PERKIRAAN like '%" & tCari.Text & "%') " &
                        " Order By NO_PERKIRAAN, NM_PERKIRAAN "
            ElseIf Me.Text = "Daftar LHP" Then
                txtQuery.Text = "Select NoLHP, a.NamaPerajin, a.TglLHP " &
                    " From T_LHP a  " &
                    "Where a.AktifYN = 'Y' " &
                    "And NoLHP Like '%" & Trim(tCari.Text) & "%' " &
                    "Group By NoLHP, a.NamaPerajin, a.TglLHP " &
                    "Order By a.tglLHP desc, NoLHP Desc "
            ElseIf Me.Text = "Daftar Toko" Then
                txtQuery.Text = "Select * " &
                        " From M_Toko " &
                        "Where AktifYN = 'Y' " &
                        "  And (nama like '%" & tCari.Text & "%' or idrec like '%" & tCari.Text & "%') " &
                        "Order By idrec"
            Else
                MsgBox("Code Program untuk pencarian " & Me.Text & " Belum ada ! :" & Me.Text)
                DGView.DataSource = tblData
            End If
            Data_Refresh()
            DGView.Focus()
        End If
    End Sub

    Private Sub DGView_KeyUp(sender As Object, e As KeyEventArgs) Handles DGView.KeyUp
        If e.KeyCode = Keys.PageDown Then
            FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
        ElseIf e.KeyCode = Keys.PageUp Then
            FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DGView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGView.KeyDown
        If e.KeyCode = Keys.Down Then
            If DGView.CurrentCell.RowIndex + 1 = DGView.RowCount Then
                FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
            Else
                FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex + 1).Cells(0).Value
            End If
        ElseIf e.KeyCode = Keys.Up Then
            If DGView.CurrentCell.RowIndex = 0 Then
                FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex).Cells(0).Value
            Else
                FrmMenuUtama.TSKeterangan.Text = DGView.Rows(DGView.CurrentCell.RowIndex - 1).Cells(0).Value
            End If
        End If
    End Sub

    Private Sub ResetTitle()
        DGView.Columns(0).HeaderText = ""
        DGView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(1).HeaderText = ""
        DGView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(2).HeaderText = ""
        DGView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(3).HeaderText = ""
        DGView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(4).HeaderText = ""
        DGView.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(5).HeaderText = ""
        DGView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(6).HeaderText = ""
        DGView.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(7).HeaderText = ""
        DGView.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(8).HeaderText = ""
        DGView.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(9).HeaderText = ""
        DGView.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(10).HeaderText = ""
        DGView.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(11).HeaderText = ""
        DGView.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(12).HeaderText = ""
        DGView.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(13).HeaderText = ""
        DGView.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(14).HeaderText = ""
        DGView.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(15).HeaderText = ""
        DGView.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(16).HeaderText = ""
        DGView.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(17).HeaderText = ""
        DGView.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(18).HeaderText = ""
        DGView.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(18).HeaderText = ""
        DGView.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGView.Columns(19).HeaderText = ""
        DGView.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Sub
    'DGView.Rows(e.Handled).Selected = True 
    'Dim y As Integer = DGView.CurrentCellAddress.Y
    'If DGView.CurrentCell.RowIndex + 1 = DGView.RowCount Then
    '            FrmMenuUtama.TSKeterangan.Text = Me.DGView.Rows(y).Cells(0).Value
    '        Else
    '            FrmMenuUtama.TSKeterangan.Text = Me.DGView.Rows(y).Cells(0).Value
    '        End If
End Class