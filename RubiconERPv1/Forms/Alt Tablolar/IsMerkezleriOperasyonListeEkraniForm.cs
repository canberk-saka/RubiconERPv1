using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class IsMerkezleriOperasyonListeEkraniForm : Form
    {
        private BSMGR0WORKCENTERDAL _dataAccessLayer;
        public IsMerkezleriOperasyonListeEkraniForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0WORKCENTERDAL(connectionString);


        }

        public void SetData(string isMerkeziKodu)
        {
            try
            {
               
                // İş Merkezi Kodu'na göre veriyi çek
                DataTable wcmDetails = _dataAccessLayer.GetWCMDetailsByCode(isMerkeziKodu);

                // Veri bulunduysa, DataGridView'e yükle
                if (wcmDetails.Rows.Count > 0)
                {
                    dgvOperasyonListele.DataSource = wcmDetails;
                }
                else
                {
                    MessageBox.Show("Veri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOperasyonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırın indeksini al
                int selectedRowIndex = dgvOperasyonListele.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvOperasyonListele.Rows[selectedRowIndex];

                // Seçilen satırdaki verileri al
                string firmaKodu = selectedRow.Cells["Firma Kodu"].Value.ToString();     // Firma Kodu
                string isMerkeziTipi = selectedRow.Cells["İş Merkezi Tipi"].Value.ToString(); // İş Merkezi Tipi
                string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString(); // İş Merkezi Kodu
                DateTime gecerlilikBaslangic = Convert.ToDateTime(selectedRow.Cells["Geçerlilik Başlangıç"].Value); // Geçerlilik Başlangıç
                DateTime gecerlilikBitis = Convert.ToDateTime(selectedRow.Cells["Geçerlilik Bitiş"].Value); // Geçerlilik Bitiş
                string operasyonKodu = selectedRow.Cells["Operasyon Kodu"].Value.ToString(); // Operasyon Kodu

                // Yeni formu oluştur
                IsMerkezleriOperasyonEklemeEkraniForm form = new IsMerkezleriOperasyonEklemeEkraniForm();

                // Form verilerini aktar
                form.SetData(firmaKodu, isMerkeziTipi, isMerkeziKodu, gecerlilikBaslangic, gecerlilikBitis, operasyonKodu);

                // Formu göster
                form.Show();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj ver
                MessageBox.Show($"Operasyon ekleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOperasyonDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırın indeksini al
                int selectedRowIndex = dgvOperasyonListele.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvOperasyonListele.Rows[selectedRowIndex];

                // Seçilen satırdaki verileri al
                string firmaKodu = selectedRow.Cells["Firma Kodu"].Value.ToString();     // Firma Kodu
                string isMerkeziTipi = selectedRow.Cells["İş Merkezi Tipi"].Value.ToString(); // İş Merkezi Tipi
                string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString(); // İş Merkezi Kodu
                DateTime gecerlilikBaslangic = Convert.ToDateTime(selectedRow.Cells["Geçerlilik Başlangıç"].Value); // Geçerlilik Başlangıç
                DateTime gecerlilikBitis = Convert.ToDateTime(selectedRow.Cells["Geçerlilik Bitiş"].Value); // Geçerlilik Bitiş
                string operasyonKodu = selectedRow.Cells["Operasyon Kodu"].Value.ToString(); // Operasyon Kodu

                // Yeni formu oluştur
                IsMerkezleriOperasyonEklemeEkraniForm form = new IsMerkezleriOperasyonEklemeEkraniForm();

                // Form verilerini aktar
                form.SetData(firmaKodu, isMerkeziTipi, isMerkeziKodu, gecerlilikBaslangic, gecerlilikBitis, operasyonKodu);

                // Formu göster
                form.Show();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj ver
                MessageBox.Show($"Operasyon ekleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOperasyonSil_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırın indeksini al
                int selectedRowIndex = dgvOperasyonListele.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvOperasyonListele.Rows[selectedRowIndex];

                // Seçilen satırdaki verileri al
                string firmaKodu = selectedRow.Cells["Firma Kodu"].Value.ToString();      // Firma Kodu
                string operasyonKodu = selectedRow.Cells["Operasyon Kodu"].Value.ToString();  // Operasyon Kodu
                string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString(); // İş Merkezi Kodu

                // Kullanıcıya silme işlemi hakkında onay iste
                DialogResult result = MessageBox.Show("Seçilen operasyonu silmek istediğinizden emin misiniz?",
                                                      "Silme Onayı",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Silme işlemi yapılacaksa, DAL sınıfındaki DeleteOperasyon fonksiyonunu çağır
                    bool isDeleted = _dataAccessLayer.DeleteOperasyon(isMerkeziKodu, firmaKodu, operasyonKodu);

                    if (isDeleted)
                    {
                        MessageBox.Show("Operasyon başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Silinen operasyonu DataGridView'den kaldır
                        dgvOperasyonListele.Rows.RemoveAt(selectedRowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Operasyon silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IsMerkezleriOperasyonListeEkraniForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }
    }
}
