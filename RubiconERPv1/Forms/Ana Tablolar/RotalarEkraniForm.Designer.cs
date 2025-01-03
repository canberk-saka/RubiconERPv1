namespace RubiconERPv1.Forms.Ana_Tablolar
{
    partial class RotalarEkraniForm
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
            this.dgvRotaBilgileri = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnTumunuGoster = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnIncele = new System.Windows.Forms.Button();
            this.btnBul = new System.Windows.Forms.Button();
            this.grpRotaListeleme = new System.Windows.Forms.GroupBox();
            this.lblFirmaKodu = new System.Windows.Forms.Label();
            this.cbFirmaKodu = new System.Windows.Forms.ComboBox();
            this.lblMaliyetMerkeziKodu = new System.Windows.Forms.Label();
            this.txtmalzemekodu = new System.Windows.Forms.TextBox();
            this.lblGecerlilikBaslangicTarihi = new System.Windows.Forms.Label();
            this.dtpGecerlilikBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblGecerlilikBitisTarihi = new System.Windows.Forms.Label();
            this.dtpGecerlilikBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblAnaMaliyetMerkeziTipi = new System.Windows.Forms.Label();
            this.txtRotaCizimNumarasi = new System.Windows.Forms.TextBox();
            this.lblSilindiMi = new System.Windows.Forms.Label();
            this.cbSilindiMi = new System.Windows.Forms.ComboBox();
            this.lblPasifMi = new System.Windows.Forms.Label();
            this.cbPasifMi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotaBilgileri)).BeginInit();
            this.grpRotaListeleme.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRotaBilgileri
            // 
            this.dgvRotaBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotaBilgileri.Location = new System.Drawing.Point(172, 553);
            this.dgvRotaBilgileri.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRotaBilgileri.Name = "dgvRotaBilgileri";
            this.dgvRotaBilgileri.RowHeadersWidth = 51;
            this.dgvRotaBilgileri.Size = new System.Drawing.Size(1709, 352);
            this.dgvRotaBilgileri.TabIndex = 40;
            this.dgvRotaBilgileri.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRotaBilgileri_CellDoubleClick);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(1005, 481);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(168, 42);
            this.btnSil.TabIndex = 39;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(793, 481);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(168, 42);
            this.btnEkle.TabIndex = 38;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Location = new System.Drawing.Point(1713, 481);
            this.btnTumunuGoster.Margin = new System.Windows.Forms.Padding(4);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.Size = new System.Drawing.Size(168, 42);
            this.btnTumunuGoster.TabIndex = 37;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.UseVisualStyleBackColor = true;
            this.btnTumunuGoster.Click += new System.EventHandler(this.btnTumunuGoster_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(575, 481);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(168, 42);
            this.btnDuzenle.TabIndex = 36;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnIncele
            // 
            this.btnIncele.Location = new System.Drawing.Point(373, 481);
            this.btnIncele.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncele.Name = "btnIncele";
            this.btnIncele.Size = new System.Drawing.Size(168, 42);
            this.btnIncele.TabIndex = 35;
            this.btnIncele.Text = "İncele";
            this.btnIncele.UseVisualStyleBackColor = true;
            this.btnIncele.Click += new System.EventHandler(this.btnIncele_Click);
            // 
            // btnBul
            // 
            this.btnBul.Location = new System.Drawing.Point(172, 481);
            this.btnBul.Margin = new System.Windows.Forms.Padding(4);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(168, 42);
            this.btnBul.TabIndex = 34;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // grpRotaListeleme
            // 
            this.grpRotaListeleme.Controls.Add(this.lblFirmaKodu);
            this.grpRotaListeleme.Controls.Add(this.cbFirmaKodu);
            this.grpRotaListeleme.Controls.Add(this.lblMaliyetMerkeziKodu);
            this.grpRotaListeleme.Controls.Add(this.txtmalzemekodu);
            this.grpRotaListeleme.Controls.Add(this.lblGecerlilikBaslangicTarihi);
            this.grpRotaListeleme.Controls.Add(this.dtpGecerlilikBaslangicTarihi);
            this.grpRotaListeleme.Controls.Add(this.lblGecerlilikBitisTarihi);
            this.grpRotaListeleme.Controls.Add(this.dtpGecerlilikBitisTarihi);
            this.grpRotaListeleme.Controls.Add(this.lblAnaMaliyetMerkeziTipi);
            this.grpRotaListeleme.Controls.Add(this.txtRotaCizimNumarasi);
            this.grpRotaListeleme.Controls.Add(this.lblSilindiMi);
            this.grpRotaListeleme.Controls.Add(this.cbSilindiMi);
            this.grpRotaListeleme.Controls.Add(this.lblPasifMi);
            this.grpRotaListeleme.Controls.Add(this.cbPasifMi);
            this.grpRotaListeleme.Location = new System.Drawing.Point(172, 134);
            this.grpRotaListeleme.Margin = new System.Windows.Forms.Padding(4);
            this.grpRotaListeleme.Name = "grpRotaListeleme";
            this.grpRotaListeleme.Padding = new System.Windows.Forms.Padding(4);
            this.grpRotaListeleme.Size = new System.Drawing.Size(1709, 326);
            this.grpRotaListeleme.TabIndex = 33;
            this.grpRotaListeleme.TabStop = false;
            this.grpRotaListeleme.Text = "Rota Bilgileri Listeleme Ekranı";
            // 
            // lblFirmaKodu
            // 
            this.lblFirmaKodu.AutoSize = true;
            this.lblFirmaKodu.Location = new System.Drawing.Point(27, 65);
            this.lblFirmaKodu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirmaKodu.Name = "lblFirmaKodu";
            this.lblFirmaKodu.Size = new System.Drawing.Size(78, 16);
            this.lblFirmaKodu.TabIndex = 0;
            this.lblFirmaKodu.Text = "Firma Kodu:";
            // 
            // cbFirmaKodu
            // 
            this.cbFirmaKodu.Location = new System.Drawing.Point(171, 62);
            this.cbFirmaKodu.Margin = new System.Windows.Forms.Padding(4);
            this.cbFirmaKodu.Name = "cbFirmaKodu";
            this.cbFirmaKodu.Size = new System.Drawing.Size(111, 24);
            this.cbFirmaKodu.TabIndex = 1;
            // 
            // lblMaliyetMerkeziKodu
            // 
            this.lblMaliyetMerkeziKodu.AutoSize = true;
            this.lblMaliyetMerkeziKodu.Location = new System.Drawing.Point(377, 65);
            this.lblMaliyetMerkeziKodu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaliyetMerkeziKodu.Name = "lblMaliyetMerkeziKodu";
            this.lblMaliyetMerkeziKodu.Size = new System.Drawing.Size(96, 16);
            this.lblMaliyetMerkeziKodu.TabIndex = 4;
            this.lblMaliyetMerkeziKodu.Text = "Malzeme Kodu";
            // 
            // txtmalzemekodu
            // 
            this.txtmalzemekodu.Location = new System.Drawing.Point(504, 62);
            this.txtmalzemekodu.Margin = new System.Windows.Forms.Padding(4);
            this.txtmalzemekodu.Name = "txtmalzemekodu";
            this.txtmalzemekodu.Size = new System.Drawing.Size(148, 22);
            this.txtmalzemekodu.TabIndex = 5;
            // 
            // lblGecerlilikBaslangicTarihi
            // 
            this.lblGecerlilikBaslangicTarihi.AutoSize = true;
            this.lblGecerlilikBaslangicTarihi.Location = new System.Drawing.Point(1172, 65);
            this.lblGecerlilikBaslangicTarihi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGecerlilikBaslangicTarihi.Name = "lblGecerlilikBaslangicTarihi";
            this.lblGecerlilikBaslangicTarihi.Size = new System.Drawing.Size(166, 16);
            this.lblGecerlilikBaslangicTarihi.TabIndex = 6;
            this.lblGecerlilikBaslangicTarihi.Text = "Geçerlilik Başlangıç Tarihi:";
            // 
            // dtpGecerlilikBaslangicTarihi
            // 
            this.dtpGecerlilikBaslangicTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBaslangicTarihi.Location = new System.Drawing.Point(1412, 62);
            this.dtpGecerlilikBaslangicTarihi.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGecerlilikBaslangicTarihi.Name = "dtpGecerlilikBaslangicTarihi";
            this.dtpGecerlilikBaslangicTarihi.Size = new System.Drawing.Size(265, 22);
            this.dtpGecerlilikBaslangicTarihi.TabIndex = 7;
            // 
            // lblGecerlilikBitisTarihi
            // 
            this.lblGecerlilikBitisTarihi.AutoSize = true;
            this.lblGecerlilikBitisTarihi.Location = new System.Drawing.Point(1172, 114);
            this.lblGecerlilikBitisTarihi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGecerlilikBitisTarihi.Name = "lblGecerlilikBitisTarihi";
            this.lblGecerlilikBitisTarihi.Size = new System.Drawing.Size(131, 16);
            this.lblGecerlilikBitisTarihi.TabIndex = 8;
            this.lblGecerlilikBitisTarihi.Text = "Geçerlilik Bitiş Tarihi:";
            // 
            // dtpGecerlilikBitisTarihi
            // 
            this.dtpGecerlilikBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBitisTarihi.Location = new System.Drawing.Point(1412, 111);
            this.dtpGecerlilikBitisTarihi.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGecerlilikBitisTarihi.Name = "dtpGecerlilikBitisTarihi";
            this.dtpGecerlilikBitisTarihi.Size = new System.Drawing.Size(265, 22);
            this.dtpGecerlilikBitisTarihi.TabIndex = 9;
            // 
            // lblAnaMaliyetMerkeziTipi
            // 
            this.lblAnaMaliyetMerkeziTipi.AutoSize = true;
            this.lblAnaMaliyetMerkeziTipi.Location = new System.Drawing.Point(27, 167);
            this.lblAnaMaliyetMerkeziTipi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnaMaliyetMerkeziTipi.Name = "lblAnaMaliyetMerkeziTipi";
            this.lblAnaMaliyetMerkeziTipi.Size = new System.Drawing.Size(105, 16);
            this.lblAnaMaliyetMerkeziTipi.TabIndex = 10;
            this.lblAnaMaliyetMerkeziTipi.Text = "Rota Açıklaması";
            // 
            // txtRotaCizimNumarasi
            // 
            this.txtRotaCizimNumarasi.Location = new System.Drawing.Point(171, 164);
            this.txtRotaCizimNumarasi.Margin = new System.Windows.Forms.Padding(4);
            this.txtRotaCizimNumarasi.Name = "txtRotaCizimNumarasi";
            this.txtRotaCizimNumarasi.Size = new System.Drawing.Size(265, 22);
            this.txtRotaCizimNumarasi.TabIndex = 11;
            // 
            // lblSilindiMi
            // 
            this.lblSilindiMi.AutoSize = true;
            this.lblSilindiMi.Location = new System.Drawing.Point(797, 129);
            this.lblSilindiMi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSilindiMi.Name = "lblSilindiMi";
            this.lblSilindiMi.Size = new System.Drawing.Size(70, 16);
            this.lblSilindiMi.TabIndex = 14;
            this.lblSilindiMi.Text = "Silindi Mi?:";
            // 
            // cbSilindiMi
            // 
            this.cbSilindiMi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSilindiMi.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbSilindiMi.Location = new System.Drawing.Point(900, 122);
            this.cbSilindiMi.Margin = new System.Windows.Forms.Padding(4);
            this.cbSilindiMi.Name = "cbSilindiMi";
            this.cbSilindiMi.Size = new System.Drawing.Size(103, 24);
            this.cbSilindiMi.TabIndex = 15;
            // 
            // lblPasifMi
            // 
            this.lblPasifMi.AutoSize = true;
            this.lblPasifMi.Location = new System.Drawing.Point(797, 65);
            this.lblPasifMi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasifMi.Name = "lblPasifMi";
            this.lblPasifMi.Size = new System.Drawing.Size(64, 16);
            this.lblPasifMi.TabIndex = 16;
            this.lblPasifMi.Text = "Pasif Mi?:";
            // 
            // cbPasifMi
            // 
            this.cbPasifMi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPasifMi.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbPasifMi.Location = new System.Drawing.Point(895, 62);
            this.cbPasifMi.Margin = new System.Windows.Forms.Padding(4);
            this.cbPasifMi.Name = "cbPasifMi";
            this.cbPasifMi.Size = new System.Drawing.Size(103, 24);
            this.cbPasifMi.TabIndex = 17;
            // 
            // RotalarEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1040);
            this.Controls.Add(this.dgvRotaBilgileri);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnTumunuGoster);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnIncele);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.grpRotaListeleme);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RotalarEkraniForm";
            this.Text = "RotalarEkraniForm";
            this.Load += new System.EventHandler(this.RotalarEkraniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotaBilgileri)).EndInit();
            this.grpRotaListeleme.ResumeLayout(false);
            this.grpRotaListeleme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRotaBilgileri;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnTumunuGoster;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnIncele;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.GroupBox grpRotaListeleme;
        private System.Windows.Forms.Label lblFirmaKodu;
        private System.Windows.Forms.ComboBox cbFirmaKodu;
        private System.Windows.Forms.Label lblMaliyetMerkeziKodu;
        private System.Windows.Forms.TextBox txtmalzemekodu;
        private System.Windows.Forms.Label lblGecerlilikBaslangicTarihi;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBaslangicTarihi;
        private System.Windows.Forms.Label lblGecerlilikBitisTarihi;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBitisTarihi;
        private System.Windows.Forms.Label lblAnaMaliyetMerkeziTipi;
        private System.Windows.Forms.TextBox txtRotaCizimNumarasi;
        private System.Windows.Forms.Label lblSilindiMi;
        private System.Windows.Forms.ComboBox cbSilindiMi;
        private System.Windows.Forms.Label lblPasifMi;
        private System.Windows.Forms.ComboBox cbPasifMi;
    }
}