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
        // Kontrolleri tanımla
        private ListBox lstKontrolTablolari;
        private Panel pnlAnaTablolar;
        private Button btnAnaTablo1;
        private Button btnAnaTablo2;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lstKontrolTablolari = new System.Windows.Forms.ListBox();
            this.pnlAnaTablolar = new System.Windows.Forms.Panel();
            this.btnAnaTablo3 = new System.Windows.Forms.Button();
            this.btnAnaTablo1 = new System.Windows.Forms.Button();
            this.btnAnaTablo2 = new System.Windows.Forms.Button();
            this.btnAnaTablo4 = new System.Windows.Forms.Button();
            this.pnlAnaTablolar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstKontrolTablolari
            // 
            this.lstKontrolTablolari.ItemHeight = 16;
            this.lstKontrolTablolari.Items.AddRange(new object[] {
            "Firma Kontrol",
            "Dil Kontrol",
            "Ülke Kontrol",
            "Şehir Kontrol",
            "Birim Kontrol",
            "Maliyet Merkezi Kontrol",
            "Rota Kontrol",
            "İş Merkezi Kontrol",
            "Operasyon Kontrol",
            "Ürün Ağacı Kontrol",
            "Materyal Tablosu"});
            this.lstKontrolTablolari.Location = new System.Drawing.Point(10, 10);
            this.lstKontrolTablolari.Name = "lstKontrolTablolari";
            this.lstKontrolTablolari.Size = new System.Drawing.Size(250, 436);
            this.lstKontrolTablolari.TabIndex = 0;
            this.lstKontrolTablolari.SelectedIndexChanged += new System.EventHandler(this.lstKontrolTablolari_SelectedIndexChanged_1);
            // 
            // pnlAnaTablolar
            // 
            this.pnlAnaTablolar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo4);
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo3);
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo1);
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo2);
            this.pnlAnaTablolar.Location = new System.Drawing.Point(280, 10);
            this.pnlAnaTablolar.Name = "pnlAnaTablolar";
            this.pnlAnaTablolar.Size = new System.Drawing.Size(500, 450);
            this.pnlAnaTablolar.TabIndex = 1;
            // 
            // btnAnaTablo3
            // 
            this.btnAnaTablo3.Location = new System.Drawing.Point(20, 142);
            this.btnAnaTablo3.Name = "btnAnaTablo3";
            this.btnAnaTablo3.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo3.TabIndex = 2;
            this.btnAnaTablo3.Text = "Maliyet Merkezleri Ana Tablosu";
            this.btnAnaTablo3.UseVisualStyleBackColor = true;
            this.btnAnaTablo3.Click += new System.EventHandler(this.btnAnaTablo3_Click);
            // 
            // btnAnaTablo1
            // 
            this.btnAnaTablo1.Location = new System.Drawing.Point(20, 20);
            this.btnAnaTablo1.Name = "btnAnaTablo1";
            this.btnAnaTablo1.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo1.TabIndex = 0;
            this.btnAnaTablo1.Text = "Malzeme Ana tablosu";
            this.btnAnaTablo1.UseVisualStyleBackColor = true;
            this.btnAnaTablo1.Click += new System.EventHandler(this.btnAnaTablo1_Click_1);
            // 
            // btnAnaTablo2
            // 
            this.btnAnaTablo2.Location = new System.Drawing.Point(20, 80);
            this.btnAnaTablo2.Name = "btnAnaTablo2";
            this.btnAnaTablo2.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo2.TabIndex = 1;
            this.btnAnaTablo2.Text = "İş Merkezleri Ana Tablosu";
            this.btnAnaTablo2.UseVisualStyleBackColor = true;
            this.btnAnaTablo2.Click += new System.EventHandler(this.btnAnaTablo2_Click_1);
            // 
            // btnAnaTablo4
            // 
            this.btnAnaTablo4.Location = new System.Drawing.Point(20, 205);
            this.btnAnaTablo4.Name = "btnAnaTablo4";
            this.btnAnaTablo4.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo4.TabIndex = 3;
            this.btnAnaTablo4.Text = "Ürün Ağaçları Ana Tablosu";
            this.btnAnaTablo4.UseVisualStyleBackColor = true;
            this.btnAnaTablo4.Click += new System.EventHandler(this.btnAnaTablo4_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.lstKontrolTablolari);
            this.Controls.Add(this.pnlAnaTablolar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.pnlAnaTablolar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // Ana Tablo 2 Butonu Tıklama Olayı
        private void BtnAnaTablo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ana Tablo 2 butonuna tıklandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lstKontrolTablolari_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedItem = lstKontrolTablolari.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Firma Kontrol":
                    var form001 = new BSMGR0GEN001Form();
                    form001.Show();
                    break;

                case "Dil Kontrol":
                    var form002 = new BSMGR0GEN002Form();
                    form002.Show();
                    break;

                case "Ülke Kontrol":
                    var form003 = new BSMGR0GEN003Form();
                    form003.Show();
                    break;

                case "Şehir Kontrol":
                    var form004 = new BSMGR0GEN004Form();
                    form004.Show();
                    break;

                case "Birim Kontrol":
                    var form005 = new BSMGR0GEN005Form();
                    form005.Show();
                    break;

                case "Maliyet Merkezi Kontrol":
                    var form006 = new BSMGR0CCM001Form();
                    form006.Show();
                    break;

                case "Rota Kontrol":
                    var form007 = new BSMGR0ROT001Form();
                    form007.Show();
                    break;

                case "İş Merkezi Kontrol":
                    var form008 = new BSMGR0ROT002Form();
                    form008.Show();
                    break;

                case "Operasyon Kontrol":
                    var form009 = new BSMGR0ROT003Form();
                    form009.Show();
                    break;

                case "Ürün Ağacı Kontrol":
                    var form010 = new BSMGR0BOM001Form();
                    form010.Show();
                    break;

                case "Materyal Tablosu":
                    var materialForm = new BSMGR0MAT001Form();
                    materialForm.Show();
                    break;

                default:
                    MessageBox.Show("Bilinmeyen seçim yapıldı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnAnaTablo1_Click_1(object sender, EventArgs e)
        {
            // Ana Tablo 1'e tıklandığında MalzemeBilgileriForm'u aç
            var malzemeBilgileriForm = new MalzemeBilgileriForm();
            malzemeBilgileriForm.Show();
        }

        private void btnAnaTablo2_Click_1(object sender, EventArgs e)
        {
            var IsMerkezleriForm = new IsMerkezleriForm();
            IsMerkezleriForm.Show();
        }

        private void btnAnaTablo3_Click(object sender, EventArgs e)
        {
            var MaliyetMerkezleriForm=new MaliyetMerkezleriForm();
            MaliyetMerkezleriForm.Show();
        }

        private void btnAnaTablo4_Click(object sender, EventArgs e)
        {
            var UrunAgaclariForm = new UrunAgaciForm();
            UrunAgaclariForm.Show();
        }
    }
}
