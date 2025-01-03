using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using RubiconERPv1.Forms.Alt_Tablolar;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class RotalarEkraniForm : Form
    {
        private BSMGR0ROTDAL _dataAccessLayer;

        public RotalarEkraniForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0ROTDAL(connectionString);
        }

        private void RotalarEkraniForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;

            // DataGridView ayarları
            //dgvRotaBilgileri.Location = new Point((this.ClientSize.Width - dgvRotaBilgileri.Width) / 2, (this.ClientSize.Height - dgvRotaBilgileri.Height) / 2 + 100);

            // ComboBox'ları yükleme
            LoadComboBoxData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
            LoadComboBoxData(cbSilindiMi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");
            LoadComboBoxData(cbPasifMi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");

            // ComboBox başlatma
            InitializeComboBoxes();

            // DataGridView'i temizle
            dgvRotaBilgileri.DataSource = null;
        }

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

        private void InitializeComboBoxes()
        {
            // ComboBox'lar için evet/hayır seçimleri
            cbSilindiMi.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Hayır" },
                new { Value = "1", Text = "Evet" }
            };
            cbSilindiMi.DisplayMember = "Text";
            cbSilindiMi.ValueMember = "Value";

            cbPasifMi.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Hayır" },
                new { Value = "1", Text = "Evet" }
            };
            cbPasifMi.DisplayMember = "Text";
            cbPasifMi.ValueMember = "Value";
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                string firmaKodu = cbFirmaKodu.SelectedValue?.ToString() == "" ? null : cbFirmaKodu.SelectedValue.ToString();
                string silindiMi = cbSilindiMi.SelectedValue?.ToString() == "" ? null : cbSilindiMi.SelectedValue.ToString();
                string pasifMi = cbPasifMi.SelectedValue?.ToString() == "" ? null : cbPasifMi.SelectedValue.ToString();

                // Verileri çekiyoruz
                DataTable result = _dataAccessLayer.GetFilteredData(
                    firmaKodu,
                    silindiMi,
                    pasifMi
                );

                dgvRotaBilgileri.DataSource = result;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Seçtiğiniz filtrelere uygun rota bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnIncele_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırı alıyoruz
                if (dgvRotaBilgileri.SelectedRows.Count > 0)
                {
                    // Seçilen satırdaki Rota Numarası'nı alıyoruz
                    DataGridViewRow selectedRow = dgvRotaBilgileri.SelectedRows[0];
                    string rotaNumarasi = selectedRow.Cells["Rota Numarası"].Value.ToString();

                    // Rota Numarası'na ait detayları çekiyoruz
                    DataTable rotaDetails = _dataAccessLayer.GetRotaDetails(rotaNumarasi);

                    if (rotaDetails.Rows.Count > 0)
                    {
                        // Detayları gösterecek formu oluşturuyoruz
                        RotaTumBilgilerForm detailsForm = new RotaTumBilgilerForm();

                        // Detayları formda yüklüyoruz
                        detailsForm.LoadRotaDetails(rotaDetails);
                        detailsForm.SetFormMode(false);  // Sadece görüntüleme modu

                        // Formu gösteriyoruz
                        detailsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen rota ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir rota seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İnceleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Ekleme işlemleri
                UrunAgaclariComponentEkraniForm componentEkraniForm = new UrunAgaclariComponentEkraniForm();
                componentEkraniForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable allData = _dataAccessLayer.GetAllData();
                dgvRotaBilgileri.DataSource = allData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRotaBilgileri.SelectedRows.Count > 0)
                {
                    string urunAgaciKodu = dgvRotaBilgileri.SelectedRows[0].Cells["Ürün Ağacı Kodu"].Value.ToString();
                    var confirmResult = MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        bool isDeleted = _dataAccessLayer.DeleteRota(urunAgaciKodu);
                        if (isDeleted)
                        {
                            MessageBox.Show("Ürün ağacı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvRotaBilgileri.DataSource = _dataAccessLayer.GetAllData();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silinecek bir ürün ağacı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen rotayı alıyoruz
                if (dgvRotaBilgileri.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvRotaBilgileri.SelectedRows[0];
                    string rotaNumarasi = selectedRow.Cells["Rota Numarası"].Value.ToString();

                    // Seçilen rota numarasına ait detayları çekiyoruz
                    DataTable rotaDetails = _dataAccessLayer.GetRotaDetails(rotaNumarasi);

                    if (rotaDetails.Rows.Count > 0)
                    {
                        // Detayları gösterecek formu oluşturuyoruz
                        RotaTumBilgilerForm detailsForm = new RotaTumBilgilerForm();
                        detailsForm.LoadRotaDetails(rotaDetails);
                        detailsForm.SetFormMode(true);  // Düzenleme modu
                        detailsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen rota ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir rota seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Düzenleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRotaBilgileri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Eğer geçerli bir satır seçilmişse
                if (e.RowIndex >= 0)
                {
                    // Seçilen satırdaki Malzeme Kodu'nu al
                    string rotaNumarasi = dgvRotaBilgileri.Rows[e.RowIndex].Cells["Rota Numarası"].Value.ToString();

                    // UrunAgaclariComponentEkraniForm formunu oluştur
                    RotalarOperasyonListeEkraniForm RotalarOperasyonListeEkraniForm = new RotalarOperasyonListeEkraniForm();

                    // Malzeme Kodu'nu formun SetData metoduyla gönder
                    RotalarOperasyonListeEkraniForm.SetRotalarOperasyon(rotaNumarasi);

                    // Formu göster
                    RotalarOperasyonListeEkraniForm.Show();
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

        private void dgvRotaBilgileri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
