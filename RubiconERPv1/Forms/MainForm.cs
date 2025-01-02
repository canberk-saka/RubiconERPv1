using RubiconERPv1.Forms;
using RubiconERPv1.Forms.Alt_Tablolar;
using RubiconERPv1.Forms.Ana_Tablolar;
using RubiconERPv1.Forms.Kontrol_Tabloları;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RubiconERPv1
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonFirmaDeneme = new System.Windows.Forms.Button();
            this.buttonDilKontrol = new System.Windows.Forms.Button();
            this.buttonUlkeKontrol = new System.Windows.Forms.Button();
            this.buttonSehirKontrol = new System.Windows.Forms.Button();
            this.buttonBirimKontrol = new System.Windows.Forms.Button();
            this.buttonMaliyetMerkeziKontrol = new System.Windows.Forms.Button();
            this.buttonRotaKontrol = new System.Windows.Forms.Button();
            this.buttonIsMerkeziKontrol = new System.Windows.Forms.Button();
            this.buttonOperasyonKontrol = new System.Windows.Forms.Button();
            this.buttonUrunAgaciKontrol = new System.Windows.Forms.Button();
            this.buttonMateryalKontrol = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFirmaDeneme
            // 
            this.buttonFirmaDeneme.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFirmaDeneme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFirmaDeneme.Location = new System.Drawing.Point(12, 24);
            this.buttonFirmaDeneme.Name = "buttonFirmaDeneme";
            this.buttonFirmaDeneme.Size = new System.Drawing.Size(130, 40);
            this.buttonFirmaDeneme.TabIndex = 2;
            this.buttonFirmaDeneme.Text = "Firma Kontrol";
            this.buttonFirmaDeneme.UseVisualStyleBackColor = false;
            this.buttonFirmaDeneme.Click += new System.EventHandler(this.buttonFirmaDeneme_Click);
            // 
            // buttonDilKontrol
            // 
            this.buttonDilKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonDilKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDilKontrol.Location = new System.Drawing.Point(154, 24);
            this.buttonDilKontrol.Name = "buttonDilKontrol";
            this.buttonDilKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonDilKontrol.TabIndex = 3;
            this.buttonDilKontrol.Text = "Dil Kontrol";
            this.buttonDilKontrol.UseVisualStyleBackColor = false;
            this.buttonDilKontrol.Click += new System.EventHandler(this.buttonDilKontrol_Click);
            // 
            // buttonUlkeKontrol
            // 
            this.buttonUlkeKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonUlkeKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUlkeKontrol.Location = new System.Drawing.Point(12, 80);
            this.buttonUlkeKontrol.Name = "buttonUlkeKontrol";
            this.buttonUlkeKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonUlkeKontrol.TabIndex = 4;
            this.buttonUlkeKontrol.Text = "Ülke Kontrol";
            this.buttonUlkeKontrol.UseVisualStyleBackColor = false;
            this.buttonUlkeKontrol.Click += new System.EventHandler(this.buttonUlkeKontrol_Click);
            // 
            // buttonSehirKontrol
            // 
            this.buttonSehirKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonSehirKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSehirKontrol.Location = new System.Drawing.Point(154, 80);
            this.buttonSehirKontrol.Name = "buttonSehirKontrol";
            this.buttonSehirKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonSehirKontrol.TabIndex = 5;
            this.buttonSehirKontrol.Text = "Şehir Kontrol";
            this.buttonSehirKontrol.UseVisualStyleBackColor = false;
            this.buttonSehirKontrol.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonBirimKontrol
            // 
            this.buttonBirimKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonBirimKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBirimKontrol.Location = new System.Drawing.Point(12, 140);
            this.buttonBirimKontrol.Name = "buttonBirimKontrol";
            this.buttonBirimKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonBirimKontrol.TabIndex = 6;
            this.buttonBirimKontrol.Text = "Birim Kontrol";
            this.buttonBirimKontrol.UseVisualStyleBackColor = false;
            this.buttonBirimKontrol.Click += new System.EventHandler(this.buttonBirimKontrol_Click);
            // 
            // buttonMaliyetMerkeziKontrol
            // 
            this.buttonMaliyetMerkeziKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonMaliyetMerkeziKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMaliyetMerkeziKontrol.Location = new System.Drawing.Point(154, 140);
            this.buttonMaliyetMerkeziKontrol.Name = "buttonMaliyetMerkeziKontrol";
            this.buttonMaliyetMerkeziKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonMaliyetMerkeziKontrol.TabIndex = 7;
            this.buttonMaliyetMerkeziKontrol.Text = "Maliyet Merkezi Kontrol";
            this.buttonMaliyetMerkeziKontrol.UseVisualStyleBackColor = false;
            this.buttonMaliyetMerkeziKontrol.Click += new System.EventHandler(this.buttonMaliyetMerkeziKontrol_Click);
            // 
            // buttonRotaKontrol
            // 
            this.buttonRotaKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonRotaKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRotaKontrol.Location = new System.Drawing.Point(12, 202);
            this.buttonRotaKontrol.Name = "buttonRotaKontrol";
            this.buttonRotaKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonRotaKontrol.TabIndex = 8;
            this.buttonRotaKontrol.Text = "Rota Kontrol";
            this.buttonRotaKontrol.UseVisualStyleBackColor = false;
            this.buttonRotaKontrol.Click += new System.EventHandler(this.buttonRotaKontrol_Click);
            // 
            // buttonIsMerkeziKontrol
            // 
            this.buttonIsMerkeziKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonIsMerkeziKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonIsMerkeziKontrol.Location = new System.Drawing.Point(154, 202);
            this.buttonIsMerkeziKontrol.Name = "buttonIsMerkeziKontrol";
            this.buttonIsMerkeziKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonIsMerkeziKontrol.TabIndex = 9;
            this.buttonIsMerkeziKontrol.Text = "İş Merkezi Kontrol";
            this.buttonIsMerkeziKontrol.UseVisualStyleBackColor = false;
            this.buttonIsMerkeziKontrol.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonOperasyonKontrol
            // 
            this.buttonOperasyonKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonOperasyonKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOperasyonKontrol.Location = new System.Drawing.Point(12, 265);
            this.buttonOperasyonKontrol.Name = "buttonOperasyonKontrol";
            this.buttonOperasyonKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonOperasyonKontrol.TabIndex = 10;
            this.buttonOperasyonKontrol.Text = "Operasyon Kontrol";
            this.buttonOperasyonKontrol.UseVisualStyleBackColor = false;
            this.buttonOperasyonKontrol.Click += new System.EventHandler(this.buttonOperasyonKontrol_Click);
            // 
            // buttonUrunAgaciKontrol
            // 
            this.buttonUrunAgaciKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonUrunAgaciKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUrunAgaciKontrol.Location = new System.Drawing.Point(154, 265);
            this.buttonUrunAgaciKontrol.Name = "buttonUrunAgaciKontrol";
            this.buttonUrunAgaciKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonUrunAgaciKontrol.TabIndex = 11;
            this.buttonUrunAgaciKontrol.Text = "Ürün Ağacı Kontrol";
            this.buttonUrunAgaciKontrol.UseVisualStyleBackColor = false;
            this.buttonUrunAgaciKontrol.Click += new System.EventHandler(this.buttonUrunAgaciKontrol_Click);
            // 
            // buttonMateryalKontrol
            // 
            this.buttonMateryalKontrol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonMateryalKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMateryalKontrol.Location = new System.Drawing.Point(12, 330);
            this.buttonMateryalKontrol.Name = "buttonMateryalKontrol";
            this.buttonMateryalKontrol.Size = new System.Drawing.Size(130, 40);
            this.buttonMateryalKontrol.TabIndex = 12;
            this.buttonMateryalKontrol.Text = "Materyal Kontrol";
            this.buttonMateryalKontrol.UseVisualStyleBackColor = false;
            this.buttonMateryalKontrol.Click += new System.EventHandler(this.buttonMateryalKontrol_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(588, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "Malzeme Ana tablosu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(588, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 14;
            this.button2.Text = "İş Merkezleri Ana Tablosu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(588, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 15;
            this.button3.Text = "Maliyet Merkezleri Ana Tablosu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(588, 255);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 40);
            this.button4.TabIndex = 16;
            this.button4.Text = "Ürün Ağaçları Ana Tablosu";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(588, 319);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 40);
            this.button5.TabIndex = 17;
            this.button5.Text = "Rota Ana Tablosu";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(238, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "© 2025 CASA RUBICON A.Ş. Tüm Hakları Saklıdır.";
            // 
            // MainForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMateryalKontrol);
            this.Controls.Add(this.buttonUrunAgaciKontrol);
            this.Controls.Add(this.buttonOperasyonKontrol);
            this.Controls.Add(this.buttonIsMerkeziKontrol);
            this.Controls.Add(this.buttonRotaKontrol);
            this.Controls.Add(this.buttonMaliyetMerkeziKontrol);
            this.Controls.Add(this.buttonBirimKontrol);
            this.Controls.Add(this.buttonSehirKontrol);
            this.Controls.Add(this.buttonUlkeKontrol);
            this.Controls.Add(this.buttonDilKontrol);
            this.Controls.Add(this.buttonFirmaDeneme);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Ana Tablo 2 Butonu Tıklama Olayı
        private void BtnAnaTablo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ana Tablo 2 butonuna tıklandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

       

        private void buttonFirmaDeneme_Click(object sender, EventArgs e)
        {
            var firmaKontrolEkrani= new BSMGR0GEN001Form();
            firmaKontrolEkrani.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sehirKontrolEkrani= new BSMGR0GEN004Form();
            sehirKontrolEkrani.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var isMerkeziKontrolEkrani = new BSMGR0ROT002Form();
            isMerkeziKontrolEkrani.Show();
        }

        private void buttonDilKontrol_Click(object sender, EventArgs e)
        {
            var dilKontrolEkrani=new BSMGR0GEN002Form();
            dilKontrolEkrani.Show();

        }

        private void buttonUlkeKontrol_Click(object sender, EventArgs e)
        {
            var ulkeKontrolEkrani=new BSMGR0GEN003Form();
            ulkeKontrolEkrani.Show();
        }

        private void buttonBirimKontrol_Click(object sender, EventArgs e)
        {
            var birimKontrolEkrani=new BSMGR0GEN005Form();
            birimKontrolEkrani.Show();
        }

        private void buttonMaliyetMerkeziKontrol_Click(object sender, EventArgs e)
        {
            var maliyetMerkeziKontrolEkrani= new BSMGR0CCM001Form();
            maliyetMerkeziKontrolEkrani.Show();
        }

        private void buttonRotaKontrol_Click(object sender, EventArgs e)
        {
            var rotaKontrolEkrani=new BSMGR0ROT001Form();
            rotaKontrolEkrani.Show();
        }

        private void buttonOperasyonKontrol_Click(object sender, EventArgs e)
        {
            var operasyonKontrolEkrani=new BSMGR0ROT003Form();
            operasyonKontrolEkrani.Show();
        }

        private void buttonUrunAgaciKontrol_Click(object sender, EventArgs e)
        {
            var urunAgaciKontrolEkrani=new BSMGR0BOM001Form();
            urunAgaciKontrolEkrani.Show();
        }

        private void buttonMateryalKontrol_Click(object sender, EventArgs e)
        {
            var materyalKontrolEkrani = new BSMGR0MAT001Form(); 
            materyalKontrolEkrani.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ana Tablo 1'e tıklandığında MalzemeBilgileriForm'u aç
            var malzemeBilgileriForm = new MalzemeBilgileriForm();
            malzemeBilgileriForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var IsMerkezleriForm = new IsMerkezleriForm();
            IsMerkezleriForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var MaliyetMerkezleriForm = new MaliyetMerkezleriForm();
            MaliyetMerkezleriForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var UrunAgaclariForm = new UrunAgaciForm();
            UrunAgaclariForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var RotalarEkraniForm = new RotalarEkraniForm();
            RotalarEkraniForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
