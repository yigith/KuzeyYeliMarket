using System;
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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("server=.; database=KuzeyYeli; uid=sa; pwd=123");
        List<Kategori> kategoriler;
        List<Urun> urunler;

        public Form1()
        {
            con.Open();
            InitializeComponent();
            KategorileriListele();
        }

        private void KategorileriListele()
        {
            kategoriler = new List<Kategori>();
            var cmd = new SqlCommand("SELECT Id, KategoriAd FROM Kategoriler", con);
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
            lstKategoriler.DataSource = kategoriler;
        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            if (lstKategoriler.SelectedIndex == -1)
            {
                dgvUrunler.DataSource = null;
                return;
            }

            int kategoriId = (int)lstKategoriler.SelectedValue;

            urunler = new List<Urun>();
            var cmd = new SqlCommand("SELECT Id, KategoriId, UrunAd, BirimFiyat, StokAdet, Resim FROM Urunler WHERE KategoriId = @p1", con);
            cmd.Parameters.AddWithValue("@p1", kategoriId);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                urunler.Add(new Urun()
                {
                    Id = (int)dr[0],
                    KategoriId = (int)dr[1],
                    UrunAd = (string)dr[2],
                    BirimFiyat = (decimal)dr[3],
                    StokAdet = (int)dr[4]
                });
            }
            dr.Close();
            dgvUrunler.DataSource = urunler;
        }
    }
}
