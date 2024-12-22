
using RubiconERPv1.Forms;
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
            this.btnAnaTablo1 = new System.Windows.Forms.Button();
            this.btnAnaTablo2 = new System.Windows.Forms.Button();
            this.pnlAnaTablolar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstKontrolTablolari
            // 
            this.lstKontrolTablolari.ItemHeight = 16;
            this.lstKontrolTablolari.Items.AddRange(new object[] {
            "Kontrol Tablo 1",
            "Kontrol Tablo 2",
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
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo1);
            this.pnlAnaTablolar.Controls.Add(this.btnAnaTablo2);
            this.pnlAnaTablolar.Location = new System.Drawing.Point(280, 10);
            this.pnlAnaTablolar.Name = "pnlAnaTablolar";
            this.pnlAnaTablolar.Size = new System.Drawing.Size(500, 450);
            this.pnlAnaTablolar.TabIndex = 1;
            // 
            // btnAnaTablo1
            // 
            this.btnAnaTablo1.Location = new System.Drawing.Point(20, 20);
            this.btnAnaTablo1.Name = "btnAnaTablo1";
            this.btnAnaTablo1.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo1.TabIndex = 0;
            this.btnAnaTablo1.Text = "Ana Tablo 1";
            this.btnAnaTablo1.Click += new System.EventHandler(this.btnAnaTablo1_Click_1);
            // 
            // btnAnaTablo2
            // 
            this.btnAnaTablo2.Location = new System.Drawing.Point(20, 80);
            this.btnAnaTablo2.Name = "btnAnaTablo2";
            this.btnAnaTablo2.Size = new System.Drawing.Size(150, 40);
            this.btnAnaTablo2.TabIndex = 1;
            this.btnAnaTablo2.Text = "Ana Tablo 2";
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
            MessageBox.Show("Ana Tablo 2 sayfasına yönlendiriliyorsunuz.");
            // Burada AnaTablo2Form açılır.
            // var anaTablo2Form = new AnaTablo2Form();
            // anaTablo2Form.Show();
        }

        private void lstKontrolTablolari_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedItem = lstKontrolTablolari.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Kontrol Tablo 1":
                    var deneme = new deneme(); // MAT0001 formu açılıyor
                    deneme.Show();
                    break;

                case "Kontrol Tablo 2":
                    MessageBox.Show("Kontrol Tablo 2 seçildi.");
                    break;

                case "Materyal Tablosu":
                    MessageBox.Show("Materyal Tablosu sayfasına yönlendiriliyorsunuz.");
                    var materialForm = new BSMGR0MAT001Form(); // MAT0001 formu açılıyor
                    materialForm.Show();
                    break;

                default:
                    MessageBox.Show("Bilinmeyen seçim.");
                    break;
            }
        }

        private void btnAnaTablo1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ana Tablo 1 sayfasına yönlendiriliyorsunuz.");
            // Burada AnaTablo1Form açılır.
            var MalzemeBilgileriForm = new MalzemeBilgileriForm();
            MalzemeBilgileriForm.Show();
        }
    }
}
