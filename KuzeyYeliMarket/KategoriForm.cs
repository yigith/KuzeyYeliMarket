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
    public partial class KategoriForm : Form
    {
        public int SonEklenenId { get; private set; }

        private readonly SqlConnection con;
        Kategori kategori;

        public KategoriForm(SqlConnection connection)
        {
            con = connection;
            InitializeComponent();
        }

        public KategoriForm(SqlConnection connection, Kategori kategori) : this(connection)
        {
            this.kategori = kategori;
            txtId.Text = kategori.Id.ToString();
            txtKategoriAd.Text = kategori.KategoriAd;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string kategoriAd = txtKategoriAd.Text.Trim();
            if (kategoriAd == "")
            {
                MessageBox.Show("Önce bir kategori adı belirtmelisiniz.");
                return;
            }

            // düzenlenen bir kategori yoksa yeni kategori ekle
            if (kategori == null)
            {
                var cmd = new SqlCommand(
                    "INSERT INTO Kategoriler(KategoriAd) VALUES(@p1); " +
                    "SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@p1", kategoriAd);
                SonEklenenId = (int)(decimal)cmd.ExecuteScalar();
            }
            else
            {
                var cmd = new SqlCommand(
                    "UPDATE Kategoriler SET KategoriAd = @p1 WHERE Id = @p2", con);
                cmd.Parameters.AddWithValue("@p1", kategoriAd);
                cmd.Parameters.AddWithValue("@p2", kategori.Id);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
