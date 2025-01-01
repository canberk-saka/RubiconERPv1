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
                    LoadComboBoxWithControlData(cmbMaliyetMerkeziTipi, "BSMGR0WORKCENTER001", "DOCTYPE", "DOCTYPE");
                    cmbMaliyetMerkeziTipi.SelectedItem = row["İş Merkezi Tipi"].ToString();

                    // İş Merkezi Kodu
                    txtAnaIsMerkeziKodu.Text = row["İş Merkezi Kodu"].ToString();

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

                    // Silindi Mi?
                    cmbSilindiMi.SelectedItem = row["Silindi Mi?"].ToString() == "1" ? "Evet" : "Hayır";

                    // Pasif Mi?
                    cmbPasifMi.SelectedItem = row["Pasif Mi?"].ToString() == "1" ? "Evet" : "Hayır";
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
            txtAnaIsMerkeziKodu.ReadOnly = !isEditMode;
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

            btnKaydet.Visible = isEditMode;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString();
                string isMerkeziTipi = cmbMaliyetMerkeziTipi.SelectedItem.ToString();
                string isMerkeziKodu = txtAnaIsMerkeziKodu.Text;
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;
                string gunlukCalismaSuresi = txtCalismaSuresi.Text;
                string kisaAciklama = txtIsMerkeziKisaAciklama.Text;
                string uzunAciklama = txtIsMerkeziUzunAciklama.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Veritabanı güncelleme işlemi
                //bool isUpdated = _dataAccessLayer.UpdateWorkCenter(
                //    isMerkeziKodu,
                //    firmaKodu,
                //    isMerkeziTipi,
                //    baslangicTarihi,
                //    bitisTarihi,
                //    gunlukCalismaSuresi,
                //    kisaAciklama,
                //    uzunAciklama,
                //    silindiMi,
                //    pasifMi,
                //    dilKodu
                //);

                //if (isUpdated)
                //{
                //    MessageBox.Show("İş merkezi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cmbFirma.SelectedItem.ToString();
                string isMerkeziTipi = cmbMaliyetMerkeziTipi.SelectedItem.ToString();
                string isMerkeziKodu = txtAnaIsMerkeziKodu.Text;
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;
                string gunlukCalismaSuresi = txtCalismaSuresi.Text;
                string kisaAciklama = txtIsMerkeziKisaAciklama.Text;
                string uzunAciklama = txtIsMerkeziUzunAciklama.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Yeni iş merkezi ekleme işlemi
                //bool isSaved = _dataAccessLayer.InsertWorkCenter(
                //    firmaKodu,
                //    isMerkeziTipi,
                //    isMerkeziKodu,
                //    baslangicTarihi,
                //    bitisTarihi,
                //    gunlukCalismaSuresi,
                //    kisaAciklama,
                //    uzunAciklama,
                //    silindiMi,
                //    pasifMi,
                //    dilKodu
                //);

                //if (isSaved)
                //{
                //    MessageBox.Show("İş merkezi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Ekleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
