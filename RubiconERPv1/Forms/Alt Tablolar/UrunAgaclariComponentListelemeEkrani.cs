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
    public partial class UrunAgaclariComponentListelemeEkrani : Form
    {
        private BSMGR0BOMDAL _dataAccessLayer;
        public UrunAgaclariComponentListelemeEkrani()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0BOMDAL(connectionString);
        }

        public void SetComponentData(DataTable componentsTable)
        {
            dgvComponentListele.DataSource = componentsTable;


            dgvComponentListele.Refresh();


        }

        private void UrunAgaclariComponentListelemeEkrani_Load(object sender, EventArgs e)
        {

        }

        private void dgvComponentListele_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Seçilen satırdaki Ürün Ağacı Kodunu alıyoruz
                string urunAgaciKodu = dgvComponentListele.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Veritabanından bileşenleri çekiyoruz
                DataTable componentsTable = _dataAccessLayer.GetComponentData(urunAgaciKodu);

                // DataGridView'in DataSource'ını yeni DataTable ile güncelliyoruz
                dgvComponentListele.DataSource = componentsTable;

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
