namespace RubiconERPv1.Forms.Ana_Tablolar
{
    partial class UrunAgaciForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUrunAgaciKodu = new System.Windows.Forms.TextBox();
            this.txtMalzemeKodu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMalzemeTipi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPasifMi = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSilindiMi = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbUrunAgaciTipi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpGecerlilikBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpGecerlilikBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFirma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnTumunuGoster = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnIncele = new System.Windows.Forms.Button();
            this.btnBul = new System.Windows.Forms.Button();
            this.dgvUrunAgaci = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunAgaci)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUrunAgaciKodu);
            this.groupBox1.Controls.Add(this.txtMalzemeKodu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMalzemeTipi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbPasifMi);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbSilindiMi);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbUrunAgaciTipi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpGecerlilikBitisTarihi);
            this.groupBox1.Controls.Add(this.dtpGecerlilikBaslangicTarihi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFirma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(160, 87);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1699, 286);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Ağaçları Listesi";
            // 
            // txtUrunAgaciKodu
            // 
            this.txtUrunAgaciKodu.Location = new System.Drawing.Point(164, 161);
            this.txtUrunAgaciKodu.Name = "txtUrunAgaciKodu";
            this.txtUrunAgaciKodu.Size = new System.Drawing.Size(100, 22);
            this.txtUrunAgaciKodu.TabIndex = 35;
            // 
            // txtMalzemeKodu
            // 
            this.txtMalzemeKodu.Location = new System.Drawing.Point(526, 101);
            this.txtMalzemeKodu.Name = "txtMalzemeKodu";
            this.txtMalzemeKodu.Size = new System.Drawing.Size(167, 22);
            this.txtMalzemeKodu.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Malzeme Kodu";
            // 
            // cmbMalzemeTipi
            // 
            this.cmbMalzemeTipi.FormattingEnabled = true;
            this.cmbMalzemeTipi.Location = new System.Drawing.Point(526, 43);
            this.cmbMalzemeTipi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMalzemeTipi.Name = "cmbMalzemeTipi";
            this.cmbMalzemeTipi.Size = new System.Drawing.Size(95, 24);
            this.cmbMalzemeTipi.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Malzeme Tipi";
            // 
            // cmbPasifMi
            // 
            this.cmbPasifMi.FormattingEnabled = true;
            this.cmbPasifMi.Location = new System.Drawing.Point(1216, 176);
            this.cmbPasifMi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPasifMi.Name = "cmbPasifMi";
            this.cmbPasifMi.Size = new System.Drawing.Size(70, 24);
            this.cmbPasifMi.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1111, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Pasif Mi?:";
            // 
            // cmbSilindiMi
            // 
            this.cmbSilindiMi.FormattingEnabled = true;
            this.cmbSilindiMi.Location = new System.Drawing.Point(1216, 142);
            this.cmbSilindiMi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSilindiMi.Name = "cmbSilindiMi";
            this.cmbSilindiMi.Size = new System.Drawing.Size(70, 24);
            this.cmbSilindiMi.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1111, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Silindi Mi?:";
            // 
            // cmbUrunAgaciTipi
            // 
            this.cmbUrunAgaciTipi.FormattingEnabled = true;
            this.cmbUrunAgaciTipi.Location = new System.Drawing.Point(164, 107);
            this.cmbUrunAgaciTipi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUrunAgaciTipi.Name = "cmbUrunAgaciTipi";
            this.cmbUrunAgaciTipi.Size = new System.Drawing.Size(100, 24);
            this.cmbUrunAgaciTipi.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ürün Ağacı Tipi";
            // 
            // dtpGecerlilikBitisTarihi
            // 
            this.dtpGecerlilikBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBitisTarihi.Location = new System.Drawing.Point(1295, 78);
            this.dtpGecerlilikBitisTarihi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpGecerlilikBitisTarihi.Name = "dtpGecerlilikBitisTarihi";
            this.dtpGecerlilikBitisTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpGecerlilikBitisTarihi.TabIndex = 11;
            // 
            // dtpGecerlilikBaslangicTarihi
            // 
            this.dtpGecerlilikBaslangicTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGecerlilikBaslangicTarihi.Location = new System.Drawing.Point(1295, 41);
            this.dtpGecerlilikBaslangicTarihi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpGecerlilikBaslangicTarihi.Name = "dtpGecerlilikBaslangicTarihi";
            this.dtpGecerlilikBaslangicTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpGecerlilikBaslangicTarihi.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1111, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Geçerlilik Başlangıç Tarihi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1111, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Geçerlilik Başlangıç Tarihi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Ağacı Kodu";
            // 
            // cmbFirma
            // 
            this.cmbFirma.FormattingEnabled = true;
            this.cmbFirma.Location = new System.Drawing.Point(164, 37);
            this.cmbFirma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFirma.Name = "cmbFirma";
            this.cmbFirma.Size = new System.Drawing.Size(121, 24);
            this.cmbFirma.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firma Kodu:";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(993, 406);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(168, 42);
            this.btnSil.TabIndex = 43;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click_1);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(781, 406);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(168, 42);
            this.btnEkle.TabIndex = 42;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Location = new System.Drawing.Point(1691, 406);
            this.btnTumunuGoster.Margin = new System.Windows.Forms.Padding(4);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.Size = new System.Drawing.Size(168, 42);
            this.btnTumunuGoster.TabIndex = 41;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.UseVisualStyleBackColor = true;
            this.btnTumunuGoster.Click += new System.EventHandler(this.btnTumunuGoster_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(563, 406);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(168, 42);
            this.btnDuzenle.TabIndex = 40;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click_1);
            // 
            // btnIncele
            // 
            this.btnIncele.Location = new System.Drawing.Point(361, 406);
            this.btnIncele.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncele.Name = "btnIncele";
            this.btnIncele.Size = new System.Drawing.Size(168, 42);
            this.btnIncele.TabIndex = 39;
            this.btnIncele.Text = "İncele";
            this.btnIncele.UseVisualStyleBackColor = true;
            this.btnIncele.Click += new System.EventHandler(this.btnIncele_Click);
            // 
            // btnBul
            // 
            this.btnBul.Location = new System.Drawing.Point(160, 406);
            this.btnBul.Margin = new System.Windows.Forms.Padding(4);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(168, 42);
            this.btnBul.TabIndex = 38;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // dgvUrunAgaci
            // 
            this.dgvUrunAgaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunAgaci.Location = new System.Drawing.Point(160, 476);
            this.dgvUrunAgaci.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUrunAgaci.Name = "dgvUrunAgaci";
            this.dgvUrunAgaci.RowHeadersWidth = 51;
            this.dgvUrunAgaci.Size = new System.Drawing.Size(1699, 299);
            this.dgvUrunAgaci.TabIndex = 44;
            this.dgvUrunAgaci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunAgaci_CellClick_1);
            this.dgvUrunAgaci.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunAgaci_CellDoubleClick);
            // 
            // UrunAgaciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1040);
            this.Controls.Add(this.dgvUrunAgaci);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnTumunuGoster);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnIncele);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UrunAgaciForm";
            this.Text = "UrunAgaciForm";
            this.Load += new System.EventHandler(this.UrunAgaciForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunAgaci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPasifMi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSilindiMi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbUrunAgaciTipi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBitisTarihi;
        private System.Windows.Forms.DateTimePicker dtpGecerlilikBaslangicTarihi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFirma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnTumunuGoster;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnIncele;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.DataGridView dgvUrunAgaci;
        private System.Windows.Forms.ComboBox cmbMalzemeTipi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMalzemeKodu;
        private System.Windows.Forms.TextBox txtUrunAgaciKodu;
    }
}
