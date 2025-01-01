namespace RubiconERPv1.Forms.Ana_Tablolar
{
    partial class MaliyetMerkezleriForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxMaliyetMerkezi = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDilKodu = new System.Windows.Forms.ComboBox();
            this.lblFirmaKodu = new System.Windows.Forms.Label();
            this.cbFirmaKodu = new System.Windows.Forms.ComboBox();
            this.lblMaliyetMerkeziTipi = new System.Windows.Forms.Label();
            this.cbMaliyetMerkeziTipi = new System.Windows.Forms.ComboBox();
            this.lblMaliyetMerkeziKodu = new System.Windows.Forms.Label();
            this.txtMaliyetMerkeziKodu = new System.Windows.Forms.TextBox();
            this.lblGecerlilikBaslangicTarihi = new System.Windows.Forms.Label();
            this.dtpGecerlilikBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblGecerlilikBitisTarihi = new System.Windows.Forms.Label();
            this.dtpGecerlilikBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblAnaMaliyetMerkeziTipi = new System.Windows.Forms.Label();
            this.txtAnaMaliyetMerkeziTipi = new System.Windows.Forms.TextBox();
            this.lblAnaMaliyetMerkeziKodu = new System.Windows.Forms.Label();
            this.txtAnaMaliyetMerkeziKodu = new System.Windows.Forms.TextBox();
            this.lblSilindiMi = new System.Windows.Forms.Label();
            this.cbSilindiMi = new System.Windows.Forms.ComboBox();
            this.lblPasifMi = new System.Windows.Forms.Label();
            this.cbPasifMi = new System.Windows.Forms.ComboBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnTumunuGoster = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnIncele = new System.Windows.Forms.Button();
            this.btnBul = new System.Windows.Forms.Button();
            this.dgvMaliyetMerkezi = new System.Windows.Forms.DataGridView();
            this.groupBoxMaliyetMerkezi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyetMerkezi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMaliyetMerkezi
            // 
            this.groupBoxMaliyetMerkezi.Controls.Add(this.label1);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.cmbDilKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblFirmaKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.cbFirmaKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblMaliyetMerkeziTipi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.cbMaliyetMerkeziTipi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblMaliyetMerkeziKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.txtMaliyetMerkeziKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblGecerlilikBaslangicTarihi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.dtpGecerlilikBaslangicTarihi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblGecerlilikBitisTarihi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.dtpGecerlilikBitisTarihi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblAnaMaliyetMerkeziTipi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.txtAnaMaliyetMerkeziTipi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblAnaMaliyetMerkeziKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.txtAnaMaliyetMerkeziKodu);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblSilindiMi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.cbSilindiMi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.lblPasifMi);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.cbPasifMi);
            this.groupBoxMaliyetMerkezi.Location = new System.Drawing.Point(125, 48);
            this.groupBoxMaliyetMerkezi.Name = "groupBoxMaliyetMerkezi";
            this.groupBoxMaliyetMerkezi.Size = new System.Drawing.Size(1282, 265);
            this.groupBoxMaliyetMerkezi.TabIndex = 0;
            this.groupBoxMaliyetMerkezi.TabStop = false;
            this.groupBoxMaliyetMerkezi.Text = "Maliyet Merkezi Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Dil Kodu";
            // 
            // cmbDilKodu
            // 
            this.cmbDilKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDilKodu.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbDilKodu.Location = new System.Drawing.Point(685, 48);
            this.cmbDilKodu.Name = "cmbDilKodu";
            this.cmbDilKodu.Size = new System.Drawing.Size(77, 24);
            this.cmbDilKodu.TabIndex = 24;
            // 
            // lblFirmaKodu
            // 
            this.lblFirmaKodu.AutoSize = true;
            this.lblFirmaKodu.Location = new System.Drawing.Point(20, 53);
            this.lblFirmaKodu.Name = "lblFirmaKodu";
            this.lblFirmaKodu.Size = new System.Drawing.Size(78, 16);
            this.lblFirmaKodu.TabIndex = 0;
            this.lblFirmaKodu.Text = "Firma Kodu:";
            // 
            // cbFirmaKodu
            // 
            this.cbFirmaKodu.Location = new System.Drawing.Point(138, 50);
            this.cbFirmaKodu.Name = "cbFirmaKodu";
            this.cbFirmaKodu.Size = new System.Drawing.Size(84, 24);
            this.cbFirmaKodu.TabIndex = 1;
            // 
            // lblMaliyetMerkeziTipi
            // 
            this.lblMaliyetMerkeziTipi.AutoSize = true;
            this.lblMaliyetMerkeziTipi.Location = new System.Drawing.Point(267, 40);
            this.lblMaliyetMerkeziTipi.Name = "lblMaliyetMerkeziTipi";
            this.lblMaliyetMerkeziTipi.Size = new System.Drawing.Size(129, 16);
            this.lblMaliyetMerkeziTipi.TabIndex = 2;
            this.lblMaliyetMerkeziTipi.Text = "Maliyet Merkezi Tipi:";
            // 
            // cbMaliyetMerkeziTipi
            // 
            this.cbMaliyetMerkeziTipi.Location = new System.Drawing.Point(447, 34);
            this.cbMaliyetMerkeziTipi.Name = "cbMaliyetMerkeziTipi";
            this.cbMaliyetMerkeziTipi.Size = new System.Drawing.Size(112, 24);
            this.cbMaliyetMerkeziTipi.TabIndex = 3;
            // 
            // lblMaliyetMerkeziKodu
            // 
            this.lblMaliyetMerkeziKodu.AutoSize = true;
            this.lblMaliyetMerkeziKodu.Location = new System.Drawing.Point(267, 77);
            this.lblMaliyetMerkeziKodu.Name = "lblMaliyetMerkeziKodu";
            this.lblMaliyetMerkeziKodu.Size = new System.Drawing.Size(137, 16);
            this.lblMaliyetMerkeziKodu.TabIndex = 4;
            this.lblMaliyetMerkeziKodu.Text = "Maliyet Merkezi Kodu:";
            // 
            // txtMaliyetMerkeziKodu
            // 
            this.txtMaliyetMerkeziKodu.Location = new System.Drawing.Point(447, 74);
            this.txtMaliyetMerkeziKodu.Name = "txtMaliyetMerkeziKodu";
            this.txtMaliyetMerkeziKodu.Size = new System.Drawing.Size(112, 22);
            this.txtMaliyetMerkeziKodu.TabIndex = 5;
            // 
            // lblGecerlilikBaslangicTarihi
            // 
            this.lblGecerlilikBaslangicTarihi.AutoSize = true;
            this.lblGecerlilikBaslangicTarihi.Location = new System.Drawing.Point(879, 40);
            this.lblGecerlilikBaslangicTarihi.Name = "lblGecerlilikBaslangicTarihi";
            this.lblGecerlilikBaslangicTarihi.Size = new System.Drawing.Size(166, 16);
            this.lblGecerlilikBaslangicTarihi.TabIndex = 6;
            this.lblGecerlilikBaslangicTarihi.Text = "Geçerlilik Başlangıç Tarihi:";
            // 
            // dtpGecerlilikBaslangicTarihi
            // 
            this.dtpGecerlilikBaslangicTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBaslangicTarihi.Location = new System.Drawing.Point(1059, 37);
            this.dtpGecerlilikBaslangicTarihi.Name = "dtpGecerlilikBaslangicTarihi";
            this.dtpGecerlilikBaslangicTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpGecerlilikBaslangicTarihi.TabIndex = 7;
            // 
            // lblGecerlilikBitisTarihi
            // 
            this.lblGecerlilikBitisTarihi.AutoSize = true;
            this.lblGecerlilikBitisTarihi.Location = new System.Drawing.Point(879, 80);
            this.lblGecerlilikBitisTarihi.Name = "lblGecerlilikBitisTarihi";
            this.lblGecerlilikBitisTarihi.Size = new System.Drawing.Size(131, 16);
            this.lblGecerlilikBitisTarihi.TabIndex = 8;
            this.lblGecerlilikBitisTarihi.Text = "Geçerlilik Bitiş Tarihi:";
            // 
            // dtpGecerlilikBitisTarihi
            // 
            this.dtpGecerlilikBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBitisTarihi.Location = new System.Drawing.Point(1059, 77);
            this.dtpGecerlilikBitisTarihi.Name = "dtpGecerlilikBitisTarihi";
            this.dtpGecerlilikBitisTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpGecerlilikBitisTarihi.TabIndex = 9;
            // 
            // lblAnaMaliyetMerkeziTipi
            // 
            this.lblAnaMaliyetMerkeziTipi.AutoSize = true;
            this.lblAnaMaliyetMerkeziTipi.Location = new System.Drawing.Point(20, 136);
            this.lblAnaMaliyetMerkeziTipi.Name = "lblAnaMaliyetMerkeziTipi";
            this.lblAnaMaliyetMerkeziTipi.Size = new System.Drawing.Size(198, 16);
            this.lblAnaMaliyetMerkeziTipi.TabIndex = 10;
            this.lblAnaMaliyetMerkeziTipi.Text = "Maliyet Merkezi Kısa Açıklaması";
            // 
            // txtAnaMaliyetMerkeziTipi
            // 
            this.txtAnaMaliyetMerkeziTipi.Location = new System.Drawing.Point(228, 133);
            this.txtAnaMaliyetMerkeziTipi.Name = "txtAnaMaliyetMerkeziTipi";
            this.txtAnaMaliyetMerkeziTipi.Size = new System.Drawing.Size(200, 22);
            this.txtAnaMaliyetMerkeziTipi.TabIndex = 11;
            // 
            // lblAnaMaliyetMerkeziKodu
            // 
            this.lblAnaMaliyetMerkeziKodu.AutoSize = true;
            this.lblAnaMaliyetMerkeziKodu.Location = new System.Drawing.Point(20, 176);
            this.lblAnaMaliyetMerkeziKodu.Name = "lblAnaMaliyetMerkeziKodu";
            this.lblAnaMaliyetMerkeziKodu.Size = new System.Drawing.Size(202, 16);
            this.lblAnaMaliyetMerkeziKodu.TabIndex = 12;
            this.lblAnaMaliyetMerkeziKodu.Text = "Maliyet Merkezi Uzun Açıklaması";
            // 
            // txtAnaMaliyetMerkeziKodu
            // 
            this.txtAnaMaliyetMerkeziKodu.Location = new System.Drawing.Point(228, 173);
            this.txtAnaMaliyetMerkeziKodu.Name = "txtAnaMaliyetMerkeziKodu";
            this.txtAnaMaliyetMerkeziKodu.Size = new System.Drawing.Size(331, 22);
            this.txtAnaMaliyetMerkeziKodu.TabIndex = 13;
            // 
            // lblSilindiMi
            // 
            this.lblSilindiMi.AutoSize = true;
            this.lblSilindiMi.Location = new System.Drawing.Point(815, 139);
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
            this.cbSilindiMi.Location = new System.Drawing.Point(921, 136);
            this.cbSilindiMi.Name = "cbSilindiMi";
            this.cbSilindiMi.Size = new System.Drawing.Size(78, 24);
            this.cbSilindiMi.TabIndex = 15;
            // 
            // lblPasifMi
            // 
            this.lblPasifMi.AutoSize = true;
            this.lblPasifMi.Location = new System.Drawing.Point(1046, 139);
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
            this.cbPasifMi.Location = new System.Drawing.Point(1146, 136);
            this.cbPasifMi.Name = "cbPasifMi";
            this.cbPasifMi.Size = new System.Drawing.Size(78, 24);
            this.cbPasifMi.TabIndex = 17;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(750, 330);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(126, 34);
            this.btnSil.TabIndex = 31;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(591, 330);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(126, 34);
            this.btnEkle.TabIndex = 30;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Location = new System.Drawing.Point(1281, 330);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.Size = new System.Drawing.Size(126, 34);
            this.btnTumunuGoster.TabIndex = 29;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.UseVisualStyleBackColor = true;
            this.btnTumunuGoster.Click += new System.EventHandler(this.btnTumunuGoster_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(427, 330);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(126, 34);
            this.btnDuzenle.TabIndex = 28;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnIncele
            // 
            this.btnIncele.Location = new System.Drawing.Point(276, 330);
            this.btnIncele.Name = "btnIncele";
            this.btnIncele.Size = new System.Drawing.Size(126, 34);
            this.btnIncele.TabIndex = 27;
            this.btnIncele.Text = "İncele";
            this.btnIncele.UseVisualStyleBackColor = true;
            this.btnIncele.Click += new System.EventHandler(this.btnIncele_Click);
            // 
            // btnBul
            // 
            this.btnBul.Location = new System.Drawing.Point(125, 330);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(126, 34);
            this.btnBul.TabIndex = 26;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // dgvMaliyetMerkezi
            // 
            this.dgvMaliyetMerkezi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaliyetMerkezi.Location = new System.Drawing.Point(125, 388);
            this.dgvMaliyetMerkezi.Name = "dgvMaliyetMerkezi";
            this.dgvMaliyetMerkezi.RowHeadersWidth = 51;
            this.dgvMaliyetMerkezi.Size = new System.Drawing.Size(1282, 286);
            this.dgvMaliyetMerkezi.TabIndex = 32;
            // 
            // MaliyetMerkezleriForm
            // 
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.dgvMaliyetMerkezi);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnTumunuGoster);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnIncele);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.groupBoxMaliyetMerkezi);
            this.Name = "MaliyetMerkezleriForm";
            this.Text = "Maliyet Merkezi Bilgileri";
            this.Load += new System.EventHandler(this.MaliyetMerkezleriForm_Load_1);
            this.groupBoxMaliyetMerkezi.ResumeLayout(false);
            this.groupBoxMaliyetMerkezi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyetMerkezi)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxMaliyetMerkezi;
        private System.Windows.Forms.Label lblFirmaKodu;
        private System.Windows.Forms.ComboBox cbFirmaKodu;
        private System.Windows.Forms.Label lblMaliyetMerkeziTipi;
        private System.Windows.Forms.ComboBox cbMaliyetMerkeziTipi;
        private System.Windows.Forms.Label lblMaliyetMerkeziKodu;
        private System.Windows.Forms.TextBox txtMaliyetMerkeziKodu;
        private System.Windows.Forms.Label lblGecerlilikBaslangicTarihi;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBaslangicTarihi;
        private System.Windows.Forms.Label lblGecerlilikBitisTarihi;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBitisTarihi;
        private System.Windows.Forms.Label lblAnaMaliyetMerkeziTipi;
        private System.Windows.Forms.TextBox txtAnaMaliyetMerkeziTipi;
        private System.Windows.Forms.Label lblAnaMaliyetMerkeziKodu;
        private System.Windows.Forms.TextBox txtAnaMaliyetMerkeziKodu;
        private System.Windows.Forms.Label lblSilindiMi;
        private System.Windows.Forms.ComboBox cbSilindiMi;
        private System.Windows.Forms.Label lblPasifMi;
        private System.Windows.Forms.ComboBox cbPasifMi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDilKodu;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnTumunuGoster;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnIncele;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.DataGridView dgvMaliyetMerkezi;
    }
}
