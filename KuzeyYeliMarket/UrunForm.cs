﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyYeliMarket
{
    public partial class UrunForm : Form
    {

        private readonly SqlConnection con;

        public Urun Urun { get; private set; }

        public UrunForm(SqlConnection connection)
        {
            con = connection;
            InitializeComponent();
            KategorileriYukle();
            txtUrunAd.Focus();
        }

        public UrunForm(SqlConnection connection, Urun urun) : this(connection)
        {
            Urun = urun;
            txtId.Text = urun.Id.ToString();
            txtUrunAd.Text = urun.UrunAd;
            nudBirimFiyat.Value = urun.BirimFiyat;
            nudStokAdet.Value = urun.StokAdet;
            cboKategori.SelectedValue = urun.KategoriId;
        }

        private void KategorileriYukle()
        {
            var kategoriler = new List<Kategori>();
            var cmd = new SqlCommand("SELECT Id, KategoriAd FROM Kategoriler ORDER BY KategoriAd", con);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                kategoriler.Add(new Kategori()
                {
                    Id = (int)dr[0],
                    KategoriAd = (string)dr[1]
                });
            }
            dr.Close();
            cboKategori.DataSource = kategoriler;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            #region Veri Geçerliliğini Kontrol Etme
            string urunAd = txtUrunAd.Text.Trim();
            if (urunAd == string.Empty)
            {
                MessageBox.Show("Ürün adı belirtmediniz.");
                return;
            }
            #endregion

            #region Ürün Özelliklerinin Atanması
            if (Urun == null)
                Urun = new Urun();

            Urun.UrunAd = urunAd;
            Urun.KategoriId = (int)cboKategori.SelectedValue;
            Urun.BirimFiyat = nudBirimFiyat.Value;
            Urun.StokAdet = (int)nudStokAdet.Value;
            #endregion

            #region Veritabanı Ekleme/Güncelleme
            if (Urun.Id == 0)
                UrunEkle(Urun);
            else
                UrunGuncelle(Urun);
            #endregion

            #region Formun Uygun Sonuçla Sonlandırılması
            DialogResult = DialogResult.OK; 
            #endregion
        }

        private void UrunGuncelle(Urun urun)
        {
            var cmd = new SqlCommand(
                "UPDATE Urunler " +
                "SET KategoriId = @p1, UrunAd = @p2, BirimFiyat = @p3, StokAdet = @p4 " +
                "WHERE Id = @p5", con);
            cmd.Parameters.AddWithValue("@p1", urun.KategoriId);
            cmd.Parameters.AddWithValue("@p2", urun.UrunAd);
            cmd.Parameters.AddWithValue("@p3", urun.BirimFiyat);
            cmd.Parameters.AddWithValue("@p4", urun.StokAdet);
            cmd.Parameters.AddWithValue("@p5", urun.Id);
            cmd.ExecuteNonQuery();
        }

        private void UrunEkle(Urun urun)
        {
            var cmd = new SqlCommand(
                "INSERT INTO Urunler(KategoriId, UrunAd, BirimFiyat, StokAdet) " +
                "VALUES(@p1, @p2, @p3, @p4);" +
                "SELECT SCOPE_IDENTITY();", con);
            cmd.Parameters.AddWithValue("@p1", urun.KategoriId);
            cmd.Parameters.AddWithValue("@p2", urun.UrunAd);
            cmd.Parameters.AddWithValue("@p3", urun.BirimFiyat);
            cmd.Parameters.AddWithValue("@p4", urun.StokAdet);
            urun.Id = (int)(decimal)cmd.ExecuteScalar();
            Urun = urun;
        }
    }
}