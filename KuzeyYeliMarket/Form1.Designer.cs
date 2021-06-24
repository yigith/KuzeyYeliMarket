
namespace KuzeyYeliMarket
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                con.Close();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstKategoriler = new System.Windows.Forms.ListBox();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnKategoriDuzenle = new System.Windows.Forms.Button();
            this.btnKategoriSil = new System.Windows.Forms.Button();
            this.btnYeniKategori = new System.Windows.Forms.Button();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategoriler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ürünler";
            // 
            // lstKategoriler
            // 
            this.lstKategoriler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstKategoriler.DisplayMember = "KategoriAd";
            this.lstKategoriler.FormattingEnabled = true;
            this.lstKategoriler.ItemHeight = 20;
            this.lstKategoriler.Location = new System.Drawing.Point(12, 52);
            this.lstKategoriler.Name = "lstKategoriler";
            this.lstKategoriler.Size = new System.Drawing.Size(211, 364);
            this.lstKategoriler.TabIndex = 2;
            this.lstKategoriler.ValueMember = "Id";
            this.lstKategoriler.SelectedIndexChanged += new System.EventHandler(this.lstKategoriler_SelectedIndexChanged);
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUrunler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(229, 52);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.Size = new System.Drawing.Size(496, 363);
            this.dgvUrunler.TabIndex = 7;
            // 
            // btnKategoriDuzenle
            // 
            this.btnKategoriDuzenle.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.edit;
            this.btnKategoriDuzenle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKategoriDuzenle.Location = new System.Drawing.Point(169, 22);
            this.btnKategoriDuzenle.Name = "btnKategoriDuzenle";
            this.btnKategoriDuzenle.Size = new System.Drawing.Size(24, 24);
            this.btnKategoriDuzenle.TabIndex = 4;
            this.btnKategoriDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnKategoriSil
            // 
            this.btnKategoriSil.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.remove;
            this.btnKategoriSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKategoriSil.Location = new System.Drawing.Point(199, 22);
            this.btnKategoriSil.Name = "btnKategoriSil";
            this.btnKategoriSil.Size = new System.Drawing.Size(24, 24);
            this.btnKategoriSil.TabIndex = 3;
            this.btnKategoriSil.UseVisualStyleBackColor = true;
            // 
            // btnYeniKategori
            // 
            this.btnYeniKategori.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.plus;
            this.btnYeniKategori.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYeniKategori.Location = new System.Drawing.Point(139, 22);
            this.btnYeniKategori.Name = "btnYeniKategori";
            this.btnYeniKategori.Size = new System.Drawing.Size(24, 24);
            this.btnYeniKategori.TabIndex = 1;
            this.btnYeniKategori.UseVisualStyleBackColor = true;
            // 
            // btnUrunDuzenle
            // 
            this.btnUrunDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunDuzenle.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.edit;
            this.btnUrunDuzenle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUrunDuzenle.Location = new System.Drawing.Point(671, 22);
            this.btnUrunDuzenle.Name = "btnUrunDuzenle";
            this.btnUrunDuzenle.Size = new System.Drawing.Size(24, 24);
            this.btnUrunDuzenle.TabIndex = 10;
            this.btnUrunDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunSil.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.remove;
            this.btnUrunSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUrunSil.Location = new System.Drawing.Point(701, 22);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(24, 24);
            this.btnUrunSil.TabIndex = 9;
            this.btnUrunSil.UseVisualStyleBackColor = true;
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniUrun.BackgroundImage = global::KuzeyYeliMarket.Properties.Resources.plus;
            this.btnYeniUrun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYeniUrun.Location = new System.Drawing.Point(641, 22);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(24, 24);
            this.btnYeniUrun.TabIndex = 8;
            this.btnYeniUrun.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 427);
            this.Controls.Add(this.btnUrunDuzenle);
            this.Controls.Add(this.btnUrunSil);
            this.Controls.Add(this.btnYeniUrun);
            this.Controls.Add(this.btnKategoriDuzenle);
            this.Controls.Add(this.btnKategoriSil);
            this.Controls.Add(this.btnYeniKategori);
            this.Controls.Add(this.dgvUrunler);
            this.Controls.Add(this.lstKategoriler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Market Uygulaması";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstKategoriler;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Button btnYeniKategori;
        private System.Windows.Forms.Button btnKategoriSil;
        private System.Windows.Forms.Button btnKategoriDuzenle;
        private System.Windows.Forms.Button btnUrunDuzenle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnYeniUrun;
    }
}

