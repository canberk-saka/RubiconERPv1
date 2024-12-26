using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class MalzemeBilgileriForm : Form
    {
        private BSMGR0MATDAL _dataAccessLayer; 

        public MalzemeBilgileriForm()
        {
            InitializeComponent();

            // ConnectionString'i al ve DAL'ı başlat
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0MATDAL(connectionString);

            // DataGridView'in CellClick olayını bağla (gerekirse)
            dgvMalzemeBilgileri.CellClick += dgvMalzemeBilgileri_CellClick;

            
        }

        private void MalzemeBilgileriForm2_Load(object sender, EventArgs e)
        {
            // Form boyut ve konum ayarları
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            int x = (this.ClientSize.Width - dgvMalzemeBilgileri.Width) / 2;
            int y = ((this.ClientSize.Height - dgvMalzemeBilgileri.Height) / 2) + 100;
            dgvMalzemeBilgileri.Location = new Point(x, y);

            // ComboBox verilerini yükle
            LoadComboBoxData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE"); // Firma
            LoadComboBoxData(cmbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE"); // Malzeme Tipi
            LoadComboBoxData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE"); // Dil Kodu

            // Tedarik Tipi, Ürün Ağacı Var Mı, Silindi Mi, Pasif Mi alanlarını doldur
            InitializeComboBoxes();

            // DataGridView'i başlangıçta boş bırak
            dgvMalzemeBilgileri.DataSource = null;

            // Tarih kontrollerini null yapmak için:
            dtpGecerlilikBaslangicTarihi.Checked = false;
            dtpGecerlilikBitisTarihi.Checked = false;
        }





        private void LoadComboBoxData(ComboBox comboBox, string tableName, string displayMember, string valueMember)
        {
            try
            {
                // Kontrol tablosundan verileri al
                DataTable data = _dataAccessLayer.GetControlTableData(tableName);

                // Sütunların varlığını kontrol et
                if (!data.Columns.Contains(displayMember) || !data.Columns.Contains(valueMember))
                {
                    MessageBox.Show($"Tabloda '{displayMember}' veya '{valueMember}' sütunu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // "Seçiniz" seçeneğini eklemek için yeni bir DataTable oluştur
                DataTable newData = data.Copy();
                DataRow newRow = newData.NewRow();
                newRow[displayMember] = "Seçiniz"; // Görüntülenecek metin
                newRow[valueMember] = ""; // Değer boş
                newData.Rows.InsertAt(newRow, 0); // İlk sıraya ekle

                // ComboBox'a veri bağla
                comboBox.DataSource = newData;
                comboBox.DisplayMember = displayMember; // Görüntülenecek sütun
                comboBox.ValueMember = valueMember; // Değer sütunu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // DataGridView CellClick olayı (isteğe bağlı)
        private void dgvMalzemeBilgileri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Burada bir hücre tıklandığında yapılacak işlemler yazılabilir
        }

        private void btnBul_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Filtrelerden verileri al
                string firma = cbFirmaKodu.SelectedValue?.ToString() == "" ? null : cbFirmaKodu.SelectedValue.ToString();
                string malzemeTipi = cmbMalzemeTipi.SelectedValue?.ToString() == "" ? null : cmbMalzemeTipi.SelectedValue.ToString();
                string malzemeNo = string.IsNullOrWhiteSpace(cmbMalzemeNo.Text) ? null : cmbMalzemeNo.Text;
                string tedarikTipi = cmbTedarikTipi.SelectedValue?.ToString(); // 0 veya 1 olabilir, boş olabilir
                string malzemeKisaAciklama = string.IsNullOrWhiteSpace(txtMalzemeKisaAciklama.Text) ? null : txtMalzemeKisaAciklama.Text;
                string malzemeUzunAciklama = string.IsNullOrWhiteSpace(txtMalzemeUzunAciklama.Text) ? null : txtMalzemeUzunAciklama.Text;
                string urunAgaciVarMi = cmbUrunAgaci.SelectedValue?.ToString(); // 0, 1, 2 olabilir, boş olabilir
                string dilKodu = cmbDilKodu.SelectedValue?.ToString() == "" ? null : cmbDilKodu.SelectedValue.ToString();
                string silindiMi = cmbSilindiMi.SelectedValue?.ToString(); // 0 veya 1 olabilir, boş olabilir
                string pasifMi = cmbPasifMi.SelectedValue?.ToString(); // 0 veya 1 olabilir, boş olabilir
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                // Filtrelenmiş verileri al
                DataTable result = _dataAccessLayer.GetFilteredData(
                    firma, malzemeTipi, malzemeNo, tedarikTipi,
                    malzemeKisaAciklama, malzemeUzunAciklama,
                    urunAgaciVarMi, dilKodu, silindiMi, pasifMi,
                    baslangicTarihi, bitisTarihi
                );

                // DataGridView'i güncelle
                dgvMalzemeBilgileri.DataSource = result;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Seçtiğiniz filtrelere uygun kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeComboBoxes()
        {
            // Tedarik Tipi
            cmbTedarikTipi.DataSource = new[]
            {
        new { Value = "", Text = "Seçiniz" }, // Varsayılan boş seçenek
        new { Value = "0", Text = "Satın Alınan" },
        new { Value = "1", Text = "Üretilen" }
    };
            cmbTedarikTipi.DisplayMember = "Text";
            cmbTedarikTipi.ValueMember = "Value";

            // Ürün Ağacı Var Mı
            cmbUrunAgaci.DataSource = new[]
            {
        new { Value = "", Text = "Seçiniz" }, // Varsayılan boş seçenek
        new { Value = "0", Text = "Hayır" },
        new { Value = "1", Text = "Evet" },
        new { Value = "2", Text = "Olmayacak" }
    };
            cmbUrunAgaci.DisplayMember = "Text";
            cmbUrunAgaci.ValueMember = "Value";

            // Silindi Mi
            cmbSilindiMi.DataSource = new[]
            {
        new { Value = "", Text = "Seçiniz" }, // Varsayılan boş seçenek
        new { Value = "0", Text = "Hayır" },
        new { Value = "1", Text = "Evet" }
    };
            cmbSilindiMi.DisplayMember = "Text";
            cmbSilindiMi.ValueMember = "Value";

            // Pasif Mi
            cmbPasifMi.DataSource = new[]
            {
        new { Value = "", Text = "Seçiniz" }, // Varsayılan boş seçenek
        new { Value = "0", Text = "Hayır" },
        new { Value = "1", Text = "Evet" }
    };
            cmbPasifMi.DisplayMember = "Text";
            cmbPasifMi.ValueMember = "Value";
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            try
            {
                // Tüm verileri al
                DataTable allData = _dataAccessLayer.GetAllData();

                // Veriyi DataGridView'e yükle
                dgvMalzemeBilgileri.DataSource = allData;
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncele_Click(object sender, EventArgs e)
        {
            
        }
    }
}
