using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class UrunAgaclariTumBilgilerForm : Form
    {
        private BSMGR0BOMDAL _dataAccessLayer;
        private bool _isEditMode;

        public UrunAgaclariTumBilgilerForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0BOMDAL(connectionString);
        }

        // Form modunu ayarla
        public void SetFormMode(bool isEditMode)
        {
            _isEditMode = isEditMode;

            // Düzenleme modunda iken kullanıcı girişine izin ver, inceleme modunda okuma modunda olacak
            txtUrunAgaciKodu.ReadOnly = !isEditMode;
            txtMalzemeKodu.ReadOnly = !isEditMode;
            txtTemelMiktar.ReadOnly = !isEditMode;
            txtCizimNumarasi.ReadOnly = !isEditMode;
            cmbFirma.Enabled = isEditMode;
            cmbUrunAgaciTipi.Enabled = isEditMode;
            cmbMalzemeTipi.Enabled = isEditMode;
            cmbSilindiMi.Enabled = isEditMode;
            cmbPasifMi.Enabled = isEditMode;
            dtpGecerlilikBaslangicTarihi.Enabled = isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = isEditMode;
            //btnKaydet.Visible = isEditMode;
        }



        // Urun Agaci Detaylarını Yükle
        public void LoadUrunAgaciDetails(DataTable urunAgaciDetails)
        {
            try
            {
                if (urunAgaciDetails.Rows.Count > 0)
                {
                    DataRow row = urunAgaciDetails.Rows[0];

                    // Firma Kodu
                    LoadComboBoxWithControlData(cmbFirma, "BSMGR0GEN001", "COMCODE", "COMCODE");
                    cmbFirma.SelectedItem = row["Firma Kodu"].ToString();

                    // Ürün Ağacı Tipi
                    LoadComboBoxWithControlData(cmbUrunAgaciTipi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
                    cmbUrunAgaciTipi.SelectedItem = row["Ürün Ağacı Tipi"].ToString();

                    // Malzeme Tipi
                    LoadComboBoxWithControlData(cmbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE");
                    cmbMalzemeTipi.SelectedItem = row["Malzeme Tipi"].ToString();

                    // Malzeme Kodu
                    txtMalzemeKodu.Text = row["Malzeme Kodu"].ToString();

                    txtUrunAgaciKodu.Text = row["Ürün Ağacı Kodu"].ToString();

                    // Geçerlilik Başlangıç
                    if (DateTime.TryParse(row["Geçerlilik Başlangıç"].ToString(), out DateTime startDate))
                        dtpGecerlilikBaslangicTarihi.Value = startDate;

                    // Geçerlilik Bitiş
                    if (DateTime.TryParse(row["Geçerlilik Bitiş"].ToString(), out DateTime endDate))
                        dtpGecerlilikBitisTarihi.Value = endDate;

                    // Temel Miktar
                    txtTemelMiktar.Text = row["Temel Miktar"].ToString();

                    

                    // Kısa Açıklama
                    txtCizimNumarasi.Text = row["Açıklama"].ToString();

                    // Silindi Mi? ComboBox'ı sabit değerlerle doldur
                    cmbSilindiMi.Items.Clear();
                    cmbSilindiMi.Items.Add("Hayır");
                    cmbSilindiMi.Items.Add("Evet");

                    // Silindi Mi? '0' ise "Hayır", '1' ise "Evet"
                    if (row["Silindi Mi?"].ToString() == "0")
                        cmbSilindiMi.SelectedItem = "Hayır";
                    else if (row["Silindi Mi?"].ToString() == "1")
                        cmbSilindiMi.SelectedItem = "Evet";

                    // Pasif Mi? ComboBox'ını sabit değerlerle doldur
                    cmbPasifMi.Items.Clear();
                    cmbPasifMi.Items.Add("Hayır");
                    cmbPasifMi.Items.Add("Evet");

                    // Pasif Mi? '0' ise "Hayır", '1' ise "Evet"
                    if (row["Pasif Mi?"].ToString() == "0")
                        cmbPasifMi.SelectedItem = "Hayır";
                    else if (row["Pasif Mi?"].ToString() == "1")
                        cmbPasifMi.SelectedItem = "Evet";
                }
                else
                {
                    MessageBox.Show("Seçilen ürün ağacı ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox'ı kontrol tablosuyla doldur
        private void LoadComboBoxWithControlData(ComboBox comboBox, string tableName, string displayMember, string valueMember)
        {
            try
            {
                DataTable data = _dataAccessLayer.GetControlTableData(tableName);
                comboBox.Items.Clear();

                foreach (DataRow row in data.Rows)
                {
                    comboBox.Items.Add(row[displayMember].ToString());
                }

                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnKaydet_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Formdaki verileri al
        //        string firmaKodu = comboBox1.SelectedItem.ToString();
        //        string urunAgaciTipi = comboBox2.SelectedItem.ToString();
        //        string malzemeKodu = textBox1.Text;
        //        DateTime? baslangicTarihi = dateTimePicker1.Checked ? (DateTime?)dateTimePicker1.Value : null;
        //        DateTime? bitisTarihi = dateTimePicker2.Checked ? (DateTime?)dateTimePicker2.Value : null;
        //        string temelMiktar = textBox2.Text;
        //        string cizimNumarasi = textBox3.Text;
        //        string kisaAciklama = textBox4.Text;
        //        string silindiMi = comboBox4.SelectedItem.ToString() == "Evet" ? "1" : "0";
        //        string pasifMi = comboBox5.SelectedItem.ToString() == "Evet" ? "1" : "0";

        //        // Veritabanı güncelleme işlemi
        //        bool isUpdated = _dataAccessLayer.UpdateUrunAgaci(
        //            firmaKodu, urunAgaciTipi, malzemeKodu, baslangicTarihi, bitisTarihi,
        //            temelMiktar, cizimNumarasi, kisaAciklama, silindiMi, pasifMi
        //        );

        //        if (isUpdated)
        //        {
        //            MessageBox.Show("Ürün ağacı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString(); // Firma Kodu
                string urunAgaciKodu = txtUrunAgaciKodu.Text; // Ürün Ağacı Kodu
                string urunAgaciTipi = cmbUrunAgaciTipi.SelectedItem.ToString(); // Ürün Ağacı Tipi
                string malzemeTipi = cmbMalzemeTipi.SelectedItem.ToString(); // Malzeme Tipi
                string malzemeKodu = txtMalzemeKodu.Text; // Malzeme Kodu
                DateTime gecerlilikBaslangic = dtpGecerlilikBaslangicTarihi.Value; // Geçerlilik Başlangıç
                DateTime gecerlilikBitis = dtpGecerlilikBitisTarihi.Value; // Geçerlilik Bitiş
       
                string silindiMi = cmbSilindiMi.SelectedValue?.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedValue?.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string cizimNumarasi = txtCizimNumarasi.Text; // Çizim Numarası
                string temelMiktar = txtTemelMiktar.Text; // Çizim Numarası

                // Veritabanı güncelleme işlemi
                bool isUpdated = _dataAccessLayer.UpdateBOM(
                    urunAgaciKodu,          // Ürün Ağacı Kodu
                    firmaKodu,              // Firma Kodu
                    urunAgaciTipi,          // Ürün Ağacı Tipi
                    malzemeTipi,            // Malzeme Tipi
                    malzemeKodu,            // Malzeme Kodu
                    gecerlilikBaslangic,    // Geçerlilik Başlangıç
                    gecerlilikBitis,        // Geçerlilik Bitiş
                    cizimNumarasi,           
                    silindiMi,              // Silindi Mi?
                    pasifMi,               // Pasif Mi?
                    temelMiktar
                );

                if (isUpdated)
                {
                    MessageBox.Show("Ürün ağacı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Güncelleme işlemi başarılı ise, listeyi yeniden yükleyebilirsiniz
                    //dgvUrunAgaclari.DataSource = _dataAccessLayer.GetAllData();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UrunAgaclariTumBilgilerForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString(); // Firma Kodu
                string urunAgaciKodu = txtUrunAgaciKodu.Text; // Ürün Ağacı Kodu
                string urunAgaciTipi = cmbUrunAgaciTipi.SelectedItem.ToString(); // Ürün Ağacı Tipi
                string malzemeTipi = cmbMalzemeTipi.SelectedItem.ToString(); // Malzeme Tipi
                string malzemeKodu = txtMalzemeKodu.Text; // Malzeme Kodu
                DateTime gecerlilikBaslangic = dtpGecerlilikBaslangicTarihi.Value; // Geçerlilik Başlangıç
                DateTime gecerlilikBitis = dtpGecerlilikBitisTarihi.Value; // Geçerlilik Bitiş

                string silindiMi = cmbSilindiMi.SelectedValue?.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedValue?.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string cizimNumarasi = txtCizimNumarasi.Text; // Çizim Numarası

                // Veritabanı ekleme işlemi
                bool isInserted = _dataAccessLayer.InsertBOM(
                    urunAgaciKodu,          // Ürün Ağacı Kodu
                    firmaKodu,              // Firma Kodu
                    urunAgaciTipi,          // Ürün Ağacı Tipi
                    malzemeTipi,            // Malzeme Tipi
                    malzemeKodu,            // Malzeme Kodu
                    gecerlilikBaslangic,    // Geçerlilik Başlangıç
                    gecerlilikBitis,        // Geçerlilik Bitiş
                    cizimNumarasi,          // Çizim Numarası
                    silindiMi,              // Silindi Mi? ("1" veya "0")
                    pasifMi                 // Pasif Mi? ("1" veya "0")
                );

                if (isInserted)
                {
                    MessageBox.Show("Ürün ağacı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ekleme işlemi başarılı ise, listeyi yeniden yükleyebilirsiniz
                    // dgvUrunAgaclari.DataSource = _dataAccessLayer.GetAllData();
                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
