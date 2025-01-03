using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class MalzemeTumBilgilerForm : Form
    {
        private BSMGR0MATDAL _dataAccessLayer;

        public MalzemeTumBilgilerForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0MATDAL(connectionString);
        }

        public void LoadMaterialDetails(DataTable materialDetails)
        {
            try
            {
                if (materialDetails.Rows.Count > 0)
                {
                    DataRow row = materialDetails.Rows[0];

                    // Firma Kodu ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
                    cbFirmaKodu.SelectedItem = row["Firma Kodu"].ToString();

                    // Malzeme Tipi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE");
                    cmbMalzemeTipi.SelectedItem = row["Malzeme Tipi"].ToString();

                    // Malzeme Kodu
                    txtMalzemeKodu.Text = row["Malzeme Kodu"].ToString();

                    // Geçerlilik Başlangıç
                    if (DateTime.TryParse(row["Geçerlilik Başlangıç"].ToString(), out DateTime startDate))
                        dtpGecerlilikBaslangicTarihi.Value = startDate;

                    // Geçerlilik Bitiş
                    if (DateTime.TryParse(row["Geçerlilik Bitiş"].ToString(), out DateTime endDate))
                        dtpGecerlilikBitisTarihi.Value = endDate;

                    // Malzeme Kısa Açıklama
                    txtMalzemeKisaAciklamasi.Text = row["Malzeme Kısa Açıklama"].ToString();

                    // Malzeme Uzun Açıklama
                    txtMalzemeUzunAciklamasi.Text = row["Malzeme Uzun Açıklama"].ToString();

                    // Dil Kodu ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");
                    cmbDilKodu.SelectedItem = row["Dil Kodu"].ToString();

                    // Tedarik Tipi ComboBox'ını sabit değerlerle doldur
                    cmbTedarikTipi.Items.Clear();
                    cmbTedarikTipi.Items.Add("Satın Alınan");
                    cmbTedarikTipi.Items.Add("Üretilen");

                    // Tedarik Tipi'ni 0 veya 1'e göre "Satın Alınan" veya "Üretilen" olarak seç
                    if (row["Tedarik Tipi"].ToString() == "0")
                        cmbTedarikTipi.SelectedItem = "Satın Alınan";
                    else if (row["Tedarik Tipi"].ToString() == "1")
                        cmbTedarikTipi.SelectedItem = "Üretilen";

                    // Malzeme Stok Birimi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbMalzemeStokBirimi, "BSMGR0GEN005", "UNITCODE", "UNITCODE");
                    cmbMalzemeStokBirimi.SelectedItem = row["Malzeme Stok Birimi"].ToString();

                    // Net Ağırlık
                    decimal? netAgirlik = null;
                    if (row["Net Ağırlık"] != DBNull.Value)
                    {
                        netAgirlik = Convert.ToDecimal(row["Net Ağırlık"]);
                    }
                    txtNetAgirlik.Text = netAgirlik?.ToString("0.###") ?? "";

                    // Net Ağırlık Birimi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbNetAgirlikBirimi, "BSMGR0GEN005", "UNITCODE", "UNITCODE");
                    cmbNetAgirlikBirimi.SelectedItem = row["Net Ağırlık Birimi"].ToString();

                    // Brüt Ağırlık
                    decimal? brutAgirlik = null;
                    if (row["Brüt Ağırlık"] != DBNull.Value)
                    {
                        brutAgirlik = Convert.ToDecimal(row["Brüt Ağırlık"]);

                    }
                    txtBrutAgirlik.Text = brutAgirlik?.ToString("0.###") ?? "";

                    // Brüt Ağırlık Birimi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbBrutAgirlikBirimi, "BSMGR0GEN005", "UNITCODE", "UNITCODE");
                    cmbBrutAgirlikBirimi.SelectedItem = row["Brüt Ağırlık Birimi"].ToString();

                    // Ürün Ağacı Var Mı? ComboBox'ını sabit değerlerle doldur
                    cmbUrunAgaciVarMi.Items.Clear();
                    cmbUrunAgaciVarMi.Items.Add("Hayır");
                    cmbUrunAgaciVarMi.Items.Add("Evet");

                    // Ürün Ağacı Var Mı? '0' ise "Hayır", '1' ise "Evet"
                    if (row["Ürün Ağacı Var Mı?"].ToString() == "0")
                        cmbUrunAgaciVarMi.SelectedItem = "Hayır";
                    else if (row["Ürün Ağacı Var Mı?"].ToString() == "1")
                        cmbUrunAgaciVarMi.SelectedItem = "Evet";

                    // Ürün Ağacı Tipi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbUrunAgaciTipi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
                    cmbUrunAgaciTipi.SelectedItem = row["Ürün Ağacı Tipi"].ToString();

                    // Ürün Ağacı Kodu
                    txtUrunAgaciKodu.Text = row["Ürün Ağacı Kodu"].ToString();

                    // Rota Var Mı? ComboBox'ını sabit değerlerle doldur
                    cmbRotaVarMi.Items.Clear();
                    cmbRotaVarMi.Items.Add("Hayır");
                    cmbRotaVarMi.Items.Add("Evet");

                    // Rota Var Mı? '0' ise "Hayır", '1' ise "Evet"
                    if (row["Rota Var Mı?"].ToString() == "0")
                        cmbRotaVarMi.SelectedItem = "Hayır";
                    else if (row["Rota Var Mı?"].ToString() == "1")
                        cmbRotaVarMi.SelectedItem = "Evet";

                    // Rota Tipi ComboBox'ını kontrol tablosuyla doldur
                    LoadComboBoxWithControlData(cmbRotaTipi, "BSMGR0ROT001", "DOCTYPE", "DOCTYPE");
                    cmbRotaTipi.SelectedItem = row["Rota Tipi"].ToString();

                    // Rota Numarası
                    txtRotaNumarasi.Text = row["Rota Numarası"].ToString();

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
                    MessageBox.Show("Seçilen malzeme ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SetFormModeGuncelle(bool isEditMode)
        {
            // Düzenleme modunda iken kullanıcı girişine izin ver, inceleme modunda okuma modunda olacak
            txtMalzemeKodu.ReadOnly = !isEditMode;
            txtMalzemeKisaAciklamasi.ReadOnly = !isEditMode;
            txtMalzemeUzunAciklamasi.ReadOnly = !isEditMode;
            cbFirmaKodu.Enabled = isEditMode;
            cmbMalzemeTipi.Enabled = isEditMode;
            cmbDilKodu.Enabled = isEditMode;
            cmbTedarikTipi.Enabled = isEditMode;
            cmbMalzemeStokBirimi.Enabled = isEditMode;
            txtNetAgirlik.ReadOnly = !isEditMode;
            cmbNetAgirlikBirimi.Enabled = isEditMode;
            txtBrutAgirlik.ReadOnly = !isEditMode;
            cmbBrutAgirlikBirimi.Enabled = isEditMode;
            cmbUrunAgaciVarMi.Enabled = isEditMode;
            cmbUrunAgaciTipi.Enabled = isEditMode;
            txtUrunAgaciKodu.ReadOnly = !isEditMode;
            cmbRotaVarMi.Enabled = isEditMode;
            cmbRotaTipi.Enabled = isEditMode;
            txtRotaNumarasi.ReadOnly = !isEditMode;
            cmbSilindiMi.Enabled = isEditMode;
            cmbPasifMi.Enabled = isEditMode;

            // Tarih seçimlerini düzenleme modunda değiştirebilmek için enabled durumunu ayarla
            dtpGecerlilikBaslangicTarihi.Enabled = isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = isEditMode;

            // Kaydet butonunun görünürlüğünü düzenle
            btnKaydet.Visible = isEditMode;
            btnSave.Visible = !isEditMode;
        }

        public void SetFormModeIncele(bool isEditMode)
        {
            // Düzenleme modunda iken kullanıcı girişine izin ver, inceleme modunda okuma modunda olacak
            txtMalzemeKodu.ReadOnly = isEditMode;
            txtMalzemeKisaAciklamasi.ReadOnly = isEditMode;
            txtMalzemeUzunAciklamasi.ReadOnly = isEditMode;
            cbFirmaKodu.Enabled = !isEditMode;
            cmbMalzemeTipi.Enabled = !isEditMode;
            cmbDilKodu.Enabled = !isEditMode;
            cmbTedarikTipi.Enabled = !isEditMode;
            cmbMalzemeStokBirimi.Enabled = !isEditMode;
            txtNetAgirlik.ReadOnly = isEditMode;
            cmbNetAgirlikBirimi.Enabled = !isEditMode;
            txtBrutAgirlik.ReadOnly = isEditMode;
            cmbBrutAgirlikBirimi.Enabled = !isEditMode;
            cmbUrunAgaciVarMi.Enabled = !isEditMode;
            cmbUrunAgaciTipi.Enabled = !isEditMode;
            txtUrunAgaciKodu.ReadOnly =isEditMode;
            cmbRotaVarMi.Enabled = !isEditMode;
            cmbRotaTipi.Enabled = !isEditMode;
            txtRotaNumarasi.ReadOnly =isEditMode;
            cmbSilindiMi.Enabled = !isEditMode;
            cmbPasifMi.Enabled = !isEditMode;

            // Tarih seçimlerini düzenleme modunda değiştirebilmek için enabled durumunu ayarla
            dtpGecerlilikBaslangicTarihi.Enabled = !isEditMode;
            dtpGecerlilikBitisTarihi.Enabled = !isEditMode;

            // Kaydet butonunun görünürlüğünü düzenle
            btnKaydet.Visible = !isEditMode;
            btnSave.Visible = !isEditMode;
        }

        public void SetFormModeInsert(bool isInsertMode)
        {
            btnKaydet.Visible = !isInsertMode;
            btnSave.Visible = isInsertMode;
        }

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

      

        private void MalzemeTumBilgilerForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Formdaki verileri al
                string malzemeKodu = txtMalzemeKodu.Text;
                string firmaKodu = cbFirmaKodu.SelectedItem.ToString();
                string malzemeTipi = cmbMalzemeTipi.SelectedItem.ToString();
                string malzemeKisaAciklama = txtMalzemeKisaAciklamasi.Text;
                string malzemeUzunAciklama = txtMalzemeUzunAciklamasi.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();
                string tedarikTipi = cmbTedarikTipi.SelectedItem.ToString() == "Satın Alınan" ? "0" : "1"; // "Satın Alınan" = 0, "Üretilen" = 1
                string malzemeStokBirimi = cmbMalzemeStokBirimi.SelectedItem.ToString();
                string netAgirlik = txtNetAgirlik.Text;
                string netAgirlikBirimi = cmbNetAgirlikBirimi.SelectedItem.ToString();
                string brutAgirlik = txtBrutAgirlik.Text;
                string brutAgirlikBirimi = cmbBrutAgirlikBirimi.SelectedItem.ToString();
                string urunAgaciVarMi = cmbUrunAgaciVarMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string urunAgaciTipi = cmbUrunAgaciTipi.SelectedItem.ToString();
                string urunAgaciKodu = txtUrunAgaciKodu.Text;
                string rotaVarMi = cmbRotaVarMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string rotaTipi = cmbRotaTipi.SelectedItem.ToString();
                string rotaNumarasi = txtRotaNumarasi.Text;
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Geçerlilik başlangıç ve bitiş tarihlerini kontrol et
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                // Veritabanı güncelleme işlemi
                bool isUpdated = _dataAccessLayer.UpdateMaterial(malzemeKodu, firmaKodu, malzemeTipi, malzemeKisaAciklama,
                    malzemeUzunAciklama, dilKodu, tedarikTipi, malzemeStokBirimi, netAgirlik, netAgirlikBirimi, brutAgirlik,
                    brutAgirlikBirimi, urunAgaciVarMi, urunAgaciTipi, urunAgaciKodu, rotaVarMi, rotaTipi, rotaNumarasi,
                    silindiMi, pasifMi, baslangicTarihi, bitisTarihi);

                if (isUpdated)
                {
                    MessageBox.Show("Malzeme başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string malzemeKodu = txtMalzemeKodu.Text;
                string firmaKodu = cbFirmaKodu.SelectedItem.ToString();
                string malzemeTipi = cmbMalzemeTipi.SelectedItem.ToString();
                string malzemeKisaAciklama = txtMalzemeKisaAciklamasi.Text;
                string malzemeUzunAciklama = txtMalzemeUzunAciklamasi.Text;
                string dilKodu = cmbDilKodu.SelectedItem.ToString();
                string tedarikTipi = cmbTedarikTipi.SelectedItem.ToString() == "Satın Alınan" ? "0" : "1"; // "Satın Alınan" = 0, "Üretilen" = 1
                string malzemeStokBirimi = cmbMalzemeStokBirimi.SelectedItem.ToString();
                string netAgirlik = txtNetAgirlik.Text;
                string netAgirlikBirimi = cmbNetAgirlikBirimi.SelectedItem.ToString();
                string brutAgirlik = txtBrutAgirlik.Text;
                string brutAgirlikBirimi = cmbBrutAgirlikBirimi.SelectedItem.ToString();
                string urunAgaciVarMi = cmbUrunAgaciVarMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string urunAgaciTipi = cmbUrunAgaciTipi.SelectedItem.ToString();
                string urunAgaciKodu = txtUrunAgaciKodu.Text;
                string rotaVarMi = cmbRotaVarMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string rotaTipi = cmbRotaTipi.SelectedItem.ToString();
                string rotaNumarasi = txtRotaNumarasi.Text;
                string silindiMi = cmbSilindiMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0
                string pasifMi = cmbPasifMi.SelectedItem.ToString() == "Evet" ? "1" : "0"; // "Evet" = 1, "Hayır" = 0

                // Geçerlilik başlangıç ve bitiş tarihlerini kontrol et
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                // Yeni kayıt ekleme işlemi
                bool isSaved = _dataAccessLayer.InsertMaterial(malzemeKodu, firmaKodu, malzemeTipi, malzemeKisaAciklama,
                    malzemeUzunAciklama, dilKodu, tedarikTipi, malzemeStokBirimi, netAgirlik, netAgirlikBirimi, brutAgirlik,
                    brutAgirlikBirimi, urunAgaciVarMi, urunAgaciTipi, urunAgaciKodu, rotaVarMi, rotaTipi, rotaNumarasi,
                    silindiMi, pasifMi, baslangicTarihi, bitisTarihi);

                if (isSaved)
                {
                    MessageBox.Show("Malzeme başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
