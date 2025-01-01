using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class IsMerkezleriOperasyonEklemeEkraniForm : Form
    {
        private BSMGR0WORKCENTERDAL _dataAccessLayer;
        private string connectionString;

        public IsMerkezleriOperasyonEklemeEkraniForm()
        {
            InitializeComponent();
            connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0WORKCENTERDAL(connectionString);
        }

        // Form yüklendiğinde verileri çekmek için
        private void IsMerkezleriOperasyonEklemeEkraniForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Firma kodları, iş merkezi tipleri ve operasyon kodları gibi verileri doldur
                LoadFirmaKodu();
                LoadIsMerkeziTipi();
                LoadOperasyonKodu();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetData(string firmaKodu, string isMerkeziTipi, string isMerkeziKodu, DateTime gecerlilikBaslangic, DateTime gecerlilikBitis, string operasyonKodu)
        {
            // Formdaki alanlara veri aktarma
            cbFirmaKodu.SelectedItem = firmaKodu;
            cbIsMerkeziTipi.SelectedItem = isMerkeziTipi;
            txtIsMerkeziKodu.Text = isMerkeziKodu;
            cbOperasyonKodu.SelectedItem = operasyonKodu;
            dateTimePicker1.Value = gecerlilikBaslangic;
            dateTimePicker2.Value = gecerlilikBitis;
        }


        // Firma Kodlarını ComboBox'a yükle
        private void LoadFirmaKodu()
        {
            try
            {
                string query = "SELECT COMCODE FROM BSMGR0GEN001"; // Firma kodlarını çekecek sorgu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    adapter.Fill(dataTable);
                    cbFirmaKodu.DataSource = dataTable;
                    cbFirmaKodu.DisplayMember = "COMCODE";
                    cbFirmaKodu.ValueMember = "COMCODE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İş Merkezi Tiplerini ComboBox'a yükle
        private void LoadIsMerkeziTipi()
        {
            try
            {
                string query = "SELECT DOCTYPE FROM BSMGR0WCM001"; // İş merkezi tiplerini çekecek sorgu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    adapter.Fill(dataTable);
                    cbIsMerkeziTipi.DataSource = dataTable;
                    cbIsMerkeziTipi.DisplayMember = "DOCTYPE";
                    cbIsMerkeziTipi.ValueMember = "DOCTYPE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İş merkezi tipleri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Operasyon Kodlarını ComboBox'a yükle
        private void LoadOperasyonKodu()
        {
            try
            {
                string query = "SELECT DOCTYPE FROM BSMGR0ROT003"; // Operasyon kodlarını çekecek sorgu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    adapter.Fill(dataTable);
                    cbOperasyonKodu.DataSource = dataTable;
                    cbOperasyonKodu.DisplayMember = "DOCTYPE";
                    cbOperasyonKodu.ValueMember = "DOCTYPE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Operasyon kodları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcıdan alınan verileri topla
                string firmaKodu = cbFirmaKodu.SelectedValue.ToString();
                string isMerkeziTipi = cbIsMerkeziTipi.SelectedValue.ToString();
                string isMerkeziKodu = txtIsMerkeziKodu.Text; // İş Merkezi Kodu
                string operasyonKodu = cbOperasyonKodu.SelectedValue.ToString(); // Operasyon Kodu
                DateTime gecerlilikBaslangic = dateTimePicker1.Value; // Başlangıç Tarihi
                DateTime gecerlilikBitis = dateTimePicker2.Value; // Bitiş Tarihi

                // Verileri veritabanına ekle
                bool isSaved = _dataAccessLayer.InsertOperasyon(
                    firmaKodu,
                    isMerkeziTipi,
                    isMerkeziKodu,
                    gecerlilikBaslangic,
                    gecerlilikBitis,
                    operasyonKodu
                );

                if (isSaved)
                {
                    MessageBox.Show("Operasyon başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operasyon eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Operasyon ekleme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdan alınan verileri topla
                string firmaKodu = cbFirmaKodu.SelectedValue.ToString(); // Firma Kodu
                string isMerkeziTipi = cbIsMerkeziTipi.SelectedValue.ToString(); // İş Merkezi Tipi
                string isMerkeziKodu = txtIsMerkeziKodu.Text; // İş Merkezi Kodu
                string operasyonKodu = cbOperasyonKodu.SelectedValue.ToString(); // Operasyon Kodu
                DateTime gecerlilikBaslangic = dateTimePicker1.Value; // Başlangıç Tarihi
                DateTime gecerlilikBitis = dateTimePicker2.Value; // Bitiş Tarihi

                // Verileri güncelleme işlemi için veritabanına gönder
                bool isUpdated = _dataAccessLayer.UpdateOperasyon(
                    firmaKodu,
                    isMerkeziTipi,
                    isMerkeziKodu,
                    gecerlilikBaslangic,
                    gecerlilikBitis,
                    operasyonKodu
                );

                if (isUpdated)
                {
                    MessageBox.Show("Operasyon başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operasyon güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Operasyon güncelleme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
