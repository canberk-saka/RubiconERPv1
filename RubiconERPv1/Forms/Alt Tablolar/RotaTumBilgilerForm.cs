using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class RotaTumBilgilerForm : Form
    {
        private BSMGR0ROTDAL _dataAccessLayer;

        // Form yüklenirken, detayları yükleyeceğiz
        public RotaTumBilgilerForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0ROTDAL(connectionString);
        }

        // Rota detaylarını form alanlarına yükleme
        public void LoadRotaDetails(DataTable rotaDetails)
        {
            try
            {
                if (rotaDetails.Rows.Count > 0)
                {
                    DataRow row = rotaDetails.Rows[0];

                    // Firma Kodu
                    cbFirmaKodu.SelectedItem = row["Firma Kodu"].ToString();

                    // Ürün Ağacı Tipi
                    cbUrunAgaciTipi.SelectedItem = row["Ürün Ağacı Tipi"].ToString();

                    // Ürün Ağacı Kodu
                    txtUrunAgaciKodu.Text = row["Ürün Ağacı Kodu"].ToString();

                    // Rota Açıklaması
                    txtRotaAciklamasi.Text = row["Rota Açıklaması"].ToString();

                    // Geçerlilik Başlangıç Tarihi
                    dtpGecerlilikBaslangicTarihi.Value = Convert.ToDateTime(row["Geçerlilik Başlangıç"]);

                    // Geçerlilik Bitiş Tarihi
                    dtpGecerlilikBitisTarihi.Value = Convert.ToDateTime(row["Geçerlilik Bitiş"]);

                    // Malzeme Tipi
                    cbMalzemeTipi.SelectedItem = row["Malzeme Tipi"].ToString();

                    // Malzeme Kodu
                    txtMalzemeKodu.Text = row["Malzeme Kodu"].ToString();

                    // Temel Miktar
                    txtTemelMiktar.Text = row["Temel Miktar"].ToString();

                    // Silindi Mi?
                    cbSilindiMi.SelectedItem = row["Silindi Mi?"].ToString() == "0" ? "Hayır" : "Evet";

                    // Pasif Mi?
                    cbPasifMi.SelectedItem = row["Pasif Mi?"].ToString() == "0" ? "Hayır" : "Evet";
                }
                else
                {
                    MessageBox.Show("Rota detayları yüklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Detayları yüklerken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Düzenleme veya ekleme işlemi için form modunu belirleme
        public void SetFormMode(bool isEditMode)
        {
            if (isEditMode)
            {
                // Düzenleme modunda formu etkinleştir
                txtUrunAgaciKodu.ReadOnly = false;
                txtRotaAciklamasi.ReadOnly = false;
                cbFirmaKodu.Enabled = true;
                cbUrunAgaciTipi.Enabled = true;
                cbMalzemeTipi.Enabled = true;
                txtMalzemeKodu.ReadOnly = false;
                txtTemelMiktar.ReadOnly = false;
                cbSilindiMi.Enabled = true;
                cbPasifMi.Enabled = true;
                dtpGecerlilikBaslangicTarihi.Enabled = true;
                dtpGecerlilikBitisTarihi.Enabled = true;
            }
            else
            {
                // Görüntüleme modunda formu salt okunur hale getir
                txtUrunAgaciKodu.ReadOnly = true;
                txtRotaAciklamasi.ReadOnly = true;
                cbFirmaKodu.Enabled = false;
                cbUrunAgaciTipi.Enabled = false;
                cbMalzemeTipi.Enabled = false;
                txtMalzemeKodu.ReadOnly = true;
                txtTemelMiktar.ReadOnly = true;
                cbSilindiMi.Enabled = false;
                cbPasifMi.Enabled = false;
                dtpGecerlilikBaslangicTarihi.Enabled = false;
                dtpGecerlilikBitisTarihi.Enabled = false;
            }
        }

        // Kaydet butonuna tıklanınca, düzenlenen bilgileri kaydetme
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string firmaKodu = cbFirmaKodu.SelectedValue.ToString();
                string urunAgaciTipi = cbUrunAgaciTipi.SelectedValue.ToString();
                string urunAgaciKodu = txtUrunAgaciKodu.Text;
                string rotaAciklamasi = txtRotaAciklamasi.Text;
                DateTime gecerlilikBaslangic = dtpGecerlilikBaslangicTarihi.Value;
                DateTime gecerlilikBitis = dtpGecerlilikBitisTarihi.Value;
                string malzemeTipi = cbMalzemeTipi.SelectedValue.ToString();
                string malzemeKodu = txtMalzemeKodu.Text;
                decimal temelMiktar = Convert.ToDecimal(txtTemelMiktar.Text);
                string silindiMi = cbSilindiMi.SelectedValue.ToString();
                string pasifMi = cbPasifMi.SelectedValue.ToString();

                // Güncellenen bilgileri DB'ye kaydet
                bool isUpdated = _dataAccessLayer.UpdateRota(urunAgaciKodu, firmaKodu, urunAgaciTipi, malzemeTipi, malzemeKodu, gecerlilikBaslangic, gecerlilikBitis, silindiMi, pasifMi, temelMiktar);

                if (isUpdated)
                {
                    MessageBox.Show("Rota başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Formu kapatıyoruz
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Formu kapatma işlemi
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form açıldığında ComboBox'lara veri yükleme işlemi
        private void RotaEklemeEkraniForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ComboBox'ları yükle
                LoadComboBoxData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
                LoadComboBoxData(cbUrunAgaciTipi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
                LoadComboBoxData(cbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE");
                LoadComboBoxData(cbSilindiMi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
                LoadComboBoxData(cbPasifMi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yükleme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox'lara veri yüklemek için metod
        private void LoadComboBoxData(ComboBox comboBox, string tableName, string displayMember, string valueMember)
        {
            try
            {
                DataTable data = _dataAccessLayer.GetControlTableData(tableName);
                if (!data.Columns.Contains(displayMember) || !data.Columns.Contains(valueMember))
                {
                    MessageBox.Show($"Tabloda '{displayMember}' veya '{valueMember}' sütunu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable newData = data.Copy();
                DataRow newRow = newData.NewRow();
                newRow[displayMember] = "Seçiniz";
                newRow[valueMember] = "";
                newData.Rows.InsertAt(newRow, 0);

                comboBox.DataSource = newData;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
