using DataAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class MaliyetMerkezleriTumBilgilerForm : Form
    {
        private BSMGR0CCMDAL _dataAccessLayer;
        private bool _isEditMode;

        public MaliyetMerkezleriTumBilgilerForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0CCMDAL(connectionString);
        }

        // Maliyet Merkezi Detaylarını Yükle
        public void LoadCostCenterDetails(DataTable costCenterDetails)
        {

            try
            {
                if (costCenterDetails.Rows.Count > 0)
                {
                    DataRow row = costCenterDetails.Rows[0];

                    // Firma Kodu
                    LoadComboBoxWithControlData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
                    cbFirmaKodu.SelectedItem = row["Firma Kodu"].ToString();

                    // Dil Kodu
                    LoadComboBoxWithControlData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");
                    cmbDilKodu.SelectedItem = row["Dil Kodu"].ToString();

                    // Maliyet Merkezi Tipi
                    LoadComboBoxWithControlData(cbMaliyetMerkeziTipi, "BSMGR0CCM001", "DOCTYPE", "DOCTYPE");
                    cbMaliyetMerkeziTipi.SelectedItem = row["Maliyet Merkezi Tipi"].ToString();

                    // Maliyet Merkezi Kodu
                    txtMaliyetMerkeziKodu.Text = row["Maliyet Merkezi Kodu"].ToString();

                    // Geçerlilik Başlangıç
                    if (DateTime.TryParse(row["Geçerlilik Başlangıç"].ToString(), out DateTime startDate))
                        dtpGecerlilikBaslangicTarihi.Value = startDate;

                    // Geçerlilik Bitiş
                    if (DateTime.TryParse(row["Geçerlilik Bitiş"].ToString(), out DateTime endDate))
                        dtpGecerlilikBitisTarihi.Value = endDate;

                    // Ana Maliyet Merkezi Tipi
                    txtAnaMaliyetMerkeziTipi.Text = row["Ana Maliyet Merkezi Tipi"].ToString();

                    // Ana Maliyet Merkezi Kodu
                    txtAnaMaliyetMerkeziKodu.Text = row["Ana Maliyet Merkezi Kodu"].ToString();


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

                    // Kısa Açıklama (MATSTEXT)
                    txtMaliyetMerkeziKisaAciklama.Text = row["Kısa Açıklama"] != DBNull.Value ? row["Kısa Açıklama"].ToString() : string.Empty;

                    // Uzun Açıklama (MATLTEXT)
                    txtMaliyetMerkeziUzunAciklama.Text = row["Uzun Açıklama"] != DBNull.Value ? row["Uzun Açıklama"].ToString() : string.Empty;

                }
                else
                {
                    MessageBox.Show("Seçilen maliyet merkezi ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtMaliyetMerkeziKodu.ReadOnly = !isEditMode;
            txtAnaMaliyetMerkeziTipi.ReadOnly = !isEditMode;
            txtAnaMaliyetMerkeziKodu.ReadOnly = !isEditMode;
            cbFirmaKodu.Enabled = isEditMode;
            cbMaliyetMerkeziTipi.Enabled = isEditMode;
            dtpGecerlilikBaslangicTarihi.Enabled = isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = isEditMode;
            cmbDilKodu.Enabled = isEditMode;
            cmbSilindiMi.Enabled = isEditMode;
            cmbPasifMi.Enabled = isEditMode;
            txtMaliyetMerkeziKisaAciklama.ReadOnly = !isEditMode;
            txtMaliyetMerkeziUzunAciklama.ReadOnly = !isEditMode;


            btnSave.Visible = !isEditMode;
        }

        public void SetFormModeIncele(bool isEditMode)
        {
            _isEditMode = isEditMode;

            // Düzenleme modunda iken kullanıcı girişine izin ver, inceleme modunda okuma modunda olacak
            txtMaliyetMerkeziKodu.ReadOnly = !isEditMode;
            txtAnaMaliyetMerkeziTipi.ReadOnly = !isEditMode;
            txtAnaMaliyetMerkeziKodu.ReadOnly = !isEditMode;
            cbFirmaKodu.Enabled = isEditMode;
            cbMaliyetMerkeziTipi.Enabled = isEditMode;
            dtpGecerlilikBaslangicTarihi.Enabled = isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = isEditMode;
            cmbDilKodu.Enabled = isEditMode;
            cmbSilindiMi.Enabled = isEditMode;
            cmbPasifMi.Enabled = isEditMode;
            txtMaliyetMerkeziKisaAciklama.ReadOnly = !isEditMode;
            txtMaliyetMerkeziUzunAciklama.ReadOnly = !isEditMode;


            btnSave.Visible = isEditMode;
            btnKaydet.Visible = isEditMode;
        }

        // Form modunu ekleme için ayarla
        public void SetFormModeInsert(bool isInsertMode)
        {
            btnKaydet.Visible = !isInsertMode;
            btnSave.Visible = isInsertMode;
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
                string maliyetMerkeziKodu = txtMaliyetMerkeziKodu.Text;
                string firmaKodu = cbFirmaKodu.SelectedItem.ToString();
                string maliyetMerkeziTipi = cbMaliyetMerkeziTipi.SelectedItem.ToString();
                string anaMaliyetMerkeziTipi = txtAnaMaliyetMerkeziTipi.Text;
                string anaMaliyetMerkeziKodu = txtAnaMaliyetMerkeziKodu.Text;
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0";
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0";
                string kisaAciklama = txtMaliyetMerkeziKisaAciklama.Text;
                string uzunAciklama = txtMaliyetMerkeziUzunAciklama.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();

                // Geçerlilik başlangıç ve bitiş tarihlerini kontrol et
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                // Veritabanı güncelleme işlemi
                bool isUpdated = _dataAccessLayer.UpdateCostCenter(
     maliyetMerkeziKodu,
     firmaKodu,
     maliyetMerkeziTipi,
     anaMaliyetMerkeziTipi,
     anaMaliyetMerkeziKodu,
     silindiMi,
     pasifMi,
     baslangicTarihi,
     bitisTarihi,
     kisaAciklama,  // Kısa açıklama parametresi
     uzunAciklama,  // Uzun açıklama parametresi
     dilKodu        // Dil Kodu parametresi
 );


                if (isUpdated)
                {
                    MessageBox.Show("Maliyet merkezi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MaliyetMerkezleriTumBilgilerForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string firmaKodu = cbFirmaKodu.SelectedItem.ToString();
                string maliyetMerkeziTipi = cbMaliyetMerkeziTipi.SelectedItem.ToString();
                string maliyetMerkeziKodu = txtMaliyetMerkeziKodu.Text;
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;
                string anaMaliyetMerkeziTipi = txtAnaMaliyetMerkeziTipi.Text;
                string anaMaliyetMerkeziKodu = txtAnaMaliyetMerkeziKodu.Text;
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Kısa Açıklama
                string kisaAciklama = txtMaliyetMerkeziKisaAciklama.Text;

                // Uzun Açıklama
                string uzunAciklama = txtMaliyetMerkeziUzunAciklama.Text;

                // Dil Kodu
                string dilKodu = cmbDilKodu.SelectedItem.ToString();

                // Veritabanı kaydı ekleme işlemi
                bool isSaved = _dataAccessLayer.InsertCostCenter(
                    firmaKodu, maliyetMerkeziTipi, maliyetMerkeziKodu, baslangicTarihi, bitisTarihi,
                    anaMaliyetMerkeziTipi, anaMaliyetMerkeziKodu, silindiMi, pasifMi,
                    kisaAciklama, uzunAciklama, dilKodu
                );

                if (isSaved)
                {
                    MessageBox.Show("Maliyet merkezi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
