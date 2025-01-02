using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class IsMerkezleriTumBilgilerForm : Form
    {
        private BSMGR0WORKCENTERDAL _dataAccessLayer;
        private bool _isEditMode;

        public IsMerkezleriTumBilgilerForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0WORKCENTERDAL(connectionString);
        }

        // İş Merkezi Detaylarını Yükle
        public void LoadWorkCenterDetails(DataTable workCenterDetails)
        {
            try
            {
                if (workCenterDetails.Rows.Count > 0)
                {
                    DataRow row = workCenterDetails.Rows[0];

                    // Firma Kodu
                    LoadComboBoxWithControlData(cmbFirma, "BSMGR0GEN001", "COMCODE", "COMCODE");
                    cmbFirma.SelectedItem = row["Firma Kodu"].ToString();

                    // Dil Kodu
                    LoadComboBoxWithControlData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");
                    cmbDilKodu.SelectedItem = row["Dil Kodu"].ToString();

                    // İş Merkezi Tipi
                    LoadComboBoxWithControlData(cmbMaliyetMerkeziTipi, "BSMGR0CCM001", "DOCTYPE", "DOCTYPE");
                    //cmbMaliyetMerkeziTipi.SelectedItem = row["Maliyet Merkezi Tipi"].ToString();

                    // İş Merkezi Kodu
                    txtIsMerkeziKodu.Text = row["İş Merkezi Kodu"].ToString();

                    // MAINWCMDOCTYPE ve CCMDOCNUM Değerleri
                    txtIsMerkeziTipi.Text = row["İş Merkezi Tipi"] != DBNull.Value ? row["İş Merkezi Tipi"].ToString() : string.Empty;

                    txtIsMerkeziKodu.Text = row["İş Merkezi Kodu"] != DBNull.Value ? row["İş Merkezi Kodu"].ToString() : string.Empty;

                    txtMaliyetMerkeziKodu.Text = row["Maliyet Merkezi Kodu"] != DBNull.Value ? row["Maliyet Merkezi Kodu"].ToString() : string.Empty;

                    // Geçerlilik Başlangıç
                    if (DateTime.TryParse(row["Geçerlilik Başlangıç"].ToString(), out DateTime startDate))
                        dtpGecerlilikBaslangicTarihi.Value = startDate;

                    // Geçerlilik Bitiş
                    if (DateTime.TryParse(row["Geçerlilik Bitiş"].ToString(), out DateTime endDate))
                        dtpGecerlilikBitisTarihi.Value = endDate;

                    // Günlük Çalışma Süresi
                    txtCalismaSuresi.Text = row["Günlük Çalışma Süresi"].ToString();

                    // Kısa Açıklama (STEXT)
                    txtIsMerkeziKisaAciklama.Text = row["Kısa Açıklama"] != DBNull.Value ? row["Kısa Açıklama"].ToString() : string.Empty;

                    // Uzun Açıklama (LTEXT)
                    txtIsMerkeziUzunAciklama.Text = row["Uzun Açıklama"] != DBNull.Value ? row["Uzun Açıklama"].ToString() : string.Empty;

                    // Silindi Mi? ComboBox'ını sabit değerlerle doldur
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
                    MessageBox.Show("Seçilen iş merkezi ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form modunu ayarla
        public void SetFormMode(bool isEditMode)
        {
            _isEditMode = isEditMode;

            // Düzenleme modunda iken kullanıcı girişine izin ver, inceleme modunda okuma modunda olacak
            txtIsMerkeziKodu.ReadOnly = !isEditMode;
            txtCalismaSuresi.ReadOnly = !isEditMode;
            txtIsMerkeziKisaAciklama.ReadOnly = !isEditMode;
            txtIsMerkeziUzunAciklama.ReadOnly = !isEditMode;
            cmbFirma.Enabled = isEditMode;
            cmbMaliyetMerkeziTipi.Enabled = isEditMode;
            dtpGecerlilikBaslangicTarihi.Enabled = isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = isEditMode;
            cmbDilKodu.Enabled = isEditMode;
            cmbSilindiMi.Enabled = isEditMode;
            cmbPasifMi.Enabled = isEditMode;
            txtMaliyetMerkeziKodu.Enabled = isEditMode;
            txtIsMerkeziTipi.Enabled = isEditMode;

            btnKaydet.Visible = isEditMode;
            btnSave.Visible = isEditMode;
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

       

      

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString();
                string isMerkeziTipi = txtIsMerkeziTipi.Text;
                string isMerkeziKodu = txtIsMerkeziKodu.Text;
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;
                string gunlukCalismaSuresi = txtCalismaSuresi.Text;
                string maliyetMerkeziKodu = txtMaliyetMerkeziKodu.Text;
                string maliyetMerkeziTipi = cmbMaliyetMerkeziTipi.SelectedItem.ToString();
                string kisaAciklama = txtIsMerkeziKisaAciklama.Text;
                string uzunAciklama = txtIsMerkeziUzunAciklama.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Ana İş Merkezi Tipi ve Kodu değerlerini al
                string anaIsMerkeziTipi = txtIsMerkeziTipi.Text;
                string anaIsMerkeziKodu = txtIsMerkeziKodu.Text;

                // Veritabanı güncelleme işlemi
                bool isUpdated = _dataAccessLayer.UpdateWCM(
                    isMerkeziKodu, firmaKodu, isMerkeziTipi,
                    anaIsMerkeziTipi, anaIsMerkeziKodu, silindiMi, pasifMi,
                    baslangicTarihi, bitisTarihi, kisaAciklama, uzunAciklama, dilKodu
                );

                MessageBox.Show(isUpdated.ToString());

                if (isUpdated)
                {
                    MessageBox.Show("İş merkezi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString(); // Firma Kodu
                string isMerkeziTipi = txtIsMerkeziTipi.Text; // İş Merkezi Tipi
                string isMerkeziKodu = txtIsMerkeziKodu.Text; // İş Merkezi Kodu
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null; // Başlangıç Tarihi
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null; // Bitiş Tarihi
                string gunlukCalismaSuresi = txtCalismaSuresi.Text; // Günlük Çalışma Süresi
                string maliyetMerkeziKodu = txtMaliyetMerkeziKodu.Text;
                string maliyetMerkeziTipi = cmbMaliyetMerkeziTipi.SelectedItem.ToString();
                string kisaAciklama = txtIsMerkeziKisaAciklama.Text; // Kısa Açıklama
                string uzunAciklama = txtIsMerkeziUzunAciklama.Text; // Uzun Açıklama
                string dilKodu = cmbDilKodu.SelectedItem.ToString(); // Dil Kodu
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Ana İş Merkezi Tipi ve Kodu
                string anaIsMerkeziTipi = txtIsMerkeziTipi.Text; // Ana İş Merkezi Tipi
                string anaIsMerkeziKodu = txtIsMerkeziKodu.Text; // Ana İş Merkezi Kodu

                // Yeni iş merkezi ekleme işlemi
                bool isInserted = _dataAccessLayer.InsertWorkCenter(
        firmaKodu,               // Firma Kodu
        isMerkeziTipi,           // İş Merkezi Tipi
        isMerkeziKodu,           // İş Merkezi Kodu
        baslangicTarihi,         // Başlangıç Tarihi
        bitisTarihi,             // Bitiş Tarihi
        gunlukCalismaSuresi,     // Günlük Çalışma Süresi
        kisaAciklama,            // Kısa Açıklama
        uzunAciklama,            // Uzun Açıklama
        silindiMi,               // Silindi Mi? ("1" veya "0")
        pasifMi,                 // Pasif Mi? ("1" veya "0")
        dilKodu,                 // Dil Kodu
        anaIsMerkeziTipi,        // Ana İş Merkezi Tipi
        anaIsMerkeziKodu,        // Ana İş Merkezi Kodu
        maliyetMerkeziKodu,     // Maliyet Merkezi Kodu
        maliyetMerkeziTipi      // Maliyet Merkezi Tipi
    );


                if (isInserted)
                {
                    MessageBox.Show("İş merkezi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void IsMerkezleriTumBilgilerForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }
    }
}
