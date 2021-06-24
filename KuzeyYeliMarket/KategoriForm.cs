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

            if (kategori == null)
            {
                var cmd = new SqlCommand(
                    "INSERT INTO Kategoriler(KategoriAd) VALUES(@p1); " +
                    "SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@p1", kategoriAd);
                SonEklenenId = (int)(decimal)cmd.ExecuteScalar();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
