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
    public partial class RotaOperasyonBomListelemeEkraniForm : Form
    {
        private BSMGR0ROTDAL _dataAccessLayer;
        public RotaOperasyonBomListelemeEkraniForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0ROTDAL(connectionString);
        }


        public void SetRotalarBom(string rotaNumarasi)
        {
            try
            {
                // Veritabanından ilgili malzeme koduna göre BOM content verilerini al
                DataTable bomContentData = _dataAccessLayer.GetRotalarBom(rotaNumarasi);

                // Eğer veri varsa, DataGridView'e yükle
                if (bomContentData.Rows.Count > 0)
                {
                    dgvMalzemeListele.DataSource = bomContentData;
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

        private void dtMalzemeListele_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    // Eğer geçerli bir satır seçilmişse
            //    if (e.RowIndex >= 0)
            //    {
            //        // Seçilen satırdaki Malzeme Kodu'nu al
            //        string rotaNumarasi = dtMalzemeListele.Rows[e.RowIndex].Cells["Rota Numarası"].Value.ToString();

            //        // UrunAgaclariComponentEkraniForm formunu oluştur
            //        RotaOperasyonBomListelemeEkraniForm RotalarOperasyonListeEkraniForm = new RotaOperasyonBomListelemeEkraniForm();

            //        // Malzeme Kodu'nu formun SetData metoduyla gönder
            //        RotalarOperasyonListeEkraniForm.SetRotalarBom(rotaNumarasi);

            //        // Formu göster
            //        RotalarOperasyonListeEkraniForm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lütfen geçerli bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
                    dgvMalzemeListele.DataSource = bomContentData;
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

        private void dgvMalzemeListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
