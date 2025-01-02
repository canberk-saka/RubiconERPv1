using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
   
    public partial class UrunAgaclariComponentEkraniForm : Form
    {
        private BSMGR0BOMDAL _dataAccessLayer;
        public UrunAgaclariComponentEkraniForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0BOMDAL(connectionString);
        }

        private void UrunAgaclariComponentEkraniForm_Load(object sender, EventArgs e)
        {
          
        }

        public void SetUrunAgaciKodu(string urunAgaciKodu)
        {
            try
            {
                // Veritabanından ilgili malzeme koduna göre BOM content verilerini al
                DataTable bomContentData = _dataAccessLayer.GetBOMContentData(urunAgaciKodu);

                // Eğer veri varsa, DataGridView'e yükle
                if (bomContentData.Rows.Count > 0)
                {
                    dgvUrunAgaciBilesenListesi.DataSource = bomContentData;
                }
                else
                {
                    MessageBox.Show("Seçilen malzeme koduna ait veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvUrunAgaciBilesenListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

       

        private void dgvUrunAgaciBilesenListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUrunAgaciBilesenListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Seçilen satırdaki Ürün Ağacı Kodunu alıyoruz
                string urunAgaciKodu = dgvUrunAgaciBilesenListesi.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Veritabanından bileşenleri çekiyoruz
                DataTable componentsTable = _dataAccessLayer.GetComponentData(urunAgaciKodu);

                // DataGridView'in DataSource'ını yeni DataTable ile güncelliyoruz
                dgvUrunAgaciBilesenListesi.DataSource = componentsTable;

                //Eğer başka bir forma veri aktarmak isterseniz, aşağıdaki satırları kullanabilirsiniz:
                UrunAgaclariComponentListelemeEkrani componentForm = new UrunAgaclariComponentListelemeEkrani();
                componentForm.SetComponentData(componentsTable);  // Verileri gönderiyoruz
                componentForm.Show();  // Formu gösteriyoruz
            }
            catch (Exception ex)
            {
                // Hata mesajını gösteriyoruz
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







    }
}
