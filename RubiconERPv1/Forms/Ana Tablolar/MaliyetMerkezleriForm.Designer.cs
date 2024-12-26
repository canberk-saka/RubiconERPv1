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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxMaliyetMerkezi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMaliyetMerkezi
            // 
            this.groupBoxMaliyetMerkezi.Controls.Add(this.label1);
            this.groupBoxMaliyetMerkezi.Controls.Add(this.comboBox1);
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
            this.groupBoxMaliyetMerkezi.Enter += new System.EventHandler(this.groupBoxMaliyetMerkezi_Enter);
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1.Location = new System.Drawing.Point(685, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 24);
            this.comboBox1.TabIndex = 24;
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(750, 330);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 34);
            this.button6.TabIndex = 31;
            this.button6.Text = "Sil";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(591, 330);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 34);
            this.button5.TabIndex = 30;
            this.button5.Text = "Ekle";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1281, 330);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 34);
            this.button4.TabIndex = 29;
            this.button4.Text = "Tümünü Göster";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(427, 330);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 34);
            this.button3.TabIndex = 28;
            this.button3.Text = "Düzenle";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 34);
            this.button2.TabIndex = 27;
            this.button2.Text = "İncele";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 34);
            this.button1.TabIndex = 26;
            this.button1.Text = "Bul";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(125, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1282, 286);
            this.dataGridView1.TabIndex = 32;
            // 
            // MaliyetMerkezleriForm
            // 
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxMaliyetMerkezi);
            this.Name = "MaliyetMerkezleriForm";
            this.Text = "Maliyet Merkezi Bilgileri";
            this.Load += new System.EventHandler(this.MaliyetMerkezleriForm_Load_1);
            this.groupBoxMaliyetMerkezi.ResumeLayout(false);
            this.groupBoxMaliyetMerkezi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
