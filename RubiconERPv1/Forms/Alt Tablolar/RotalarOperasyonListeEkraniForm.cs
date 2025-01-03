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
    public partial class RotalarOperasyonListeEkraniForm : Form
    {
        private BSMGR0ROTDAL _dataAccessLayer;
        public RotalarOperasyonListeEkraniForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0ROTDAL(connectionString);
        }

        public void SetRotalarOperasyon(string rotaNumarasi)
        {
            try
            {
                // Veritabanından ilgili malzeme koduna göre BOM content verilerini al
                DataTable bomContentData = _dataAccessLayer.GetRotalarOperasyon(rotaNumarasi);

                // Eğer veri varsa, DataGridView'e yükle
                if (bomContentData.Rows.Count > 0)
                {
                    dgvRotaOperasyonListe.DataSource = bomContentData;
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
       

        private void dgvRotaOperasyonListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Eğer geçerli bir satır seçilmişse
                if (e.RowIndex >= 0)
                {
                    // Seçilen satırdaki Malzeme Kodu'nu al
                    string rotaNumarasi = dgvRotaOperasyonListe.Rows[e.RowIndex].Cells["Rota Numarası"].Value.ToString();

                    // UrunAgaclariComponentEkraniForm formunu oluştur
                    RotaOperasyonBomListelemeEkraniForm RotaOperasyonBomListelemeEkraniForm = new RotaOperasyonBomListelemeEkraniForm();

                    // Malzeme Kodu'nu formun SetData metoduyla gönder
                    RotaOperasyonBomListelemeEkraniForm.SetRotalarBom(rotaNumarasi);

                    // Formu göster
                    RotaOperasyonBomListelemeEkraniForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
