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
            lstKategoriler.DataSource = kategoriler;
        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriListele();
            btnYeniKategori.Enabled = btnKategoriDuzenle.Enabled = btnKategoriSil.Enabled = lstKategoriler.SelectedIndex != -1;

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

        private void dgvUrunler_SelectionChanged(object sender, EventArgs e)
        {
            btnYeniUrun.Enabled = btnUrunDuzenle.Enabled = btnUrunSil.Enabled = dgvUrunler.SelectedRows.Count != 0;
        }

        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedIndex == -1) return;

            DialogResult dr = MessageBox.Show("Seçili kategori ve altındaki tüm ürünler silinecektir. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                KategoriSil((int)lstKategoriler.SelectedValue);
                KategorileriListele();
            }
        }

        private void KategoriSil(int id)
        {
            var cmd = new SqlCommand("DELETE FROM Kategoriler WHERE Id = @p1", con);
            cmd.Parameters.AddWithValue("@p1", id);
            cmd.ExecuteNonQuery();
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("Seçili ürün silinecektir. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                Urun urun = (Urun)dgvUrunler.SelectedRows[0].DataBoundItem;
                UrunSil(urun.Id);
                KategorileriListele();
                KategoriyiSec(urun.KategoriId);
            }
        }

        private void UrunSil(int id)
        {
            var cmd = new SqlCommand("DELETE FROM Urunler WHERE Id = @p1", con);
            cmd.Parameters.AddWithValue("@p1", id);
            cmd.ExecuteNonQuery();
        }

        private void btnYeniKategori_Click(object sender, EventArgs e)
        {
            KategoriForm frm = new KategoriForm(con);
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                KategorileriListele();
                KategoriyiSec(frm.SonEklenenId);
            }
        }

        private void KategoriyiSec(int kategoriId)
        {
            lstKategoriler.SelectedValue = kategoriId;
        }

        private void btnKategoriDuzenle_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedIndex == -1) return;
            Kategori kategori = (Kategori)lstKategoriler.SelectedItem;
            KategoriForm frm = new KategoriForm(con, kategori);
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                KategorileriListele();
                KategoriyiSec(kategori.Id);
            }

        }

        private void lstKategoriler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnKategoriSil.PerformClick();
            }
        }

        private void dgvUrunler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvUrunler.SelectedRows.Count > 0)
            {
                btnUrunSil.PerformClick();
            }
        }

        private void btnYeniUrun_Click(object sender, EventArgs e)
        {
            // aradan sonra burada yeni bir ürün form açacağız
        }
    }
}
