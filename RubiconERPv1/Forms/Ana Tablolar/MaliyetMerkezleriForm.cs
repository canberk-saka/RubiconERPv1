using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using RubiconERPv1.Forms.Alt_Tablolar;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class MaliyetMerkezleriForm : Form
    {
        private BSMGR0CCMDAL _dataAccessLayer;

        public MaliyetMerkezleriForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0CCMDAL(connectionString);
            dgvMaliyetMerkezi.CellClick += dgvMaliyetMerkezi_CellClick;
        }

        private void MaliyetMerkezleriForm_Load_1(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            int x = (this.ClientSize.Width - dgvMaliyetMerkezi.Width) / 2;
            int y = ((this.ClientSize.Height - dgvMaliyetMerkezi.Height) / 2) + 100;
            dgvMaliyetMerkezi.Location = new Point(x, y);

            // ComboBox verilerini yükle
            LoadComboBoxData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
            LoadComboBoxData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");
            LoadComboBoxData(cbMaliyetMerkeziTipi, "BSMGR0CCM001", "DOCTYPE", "DOCTYPE");

            // ComboBoxları başlat
            InitializeComboBoxes();
            dgvMaliyetMerkezi.DataSource = null;
            dtpGecerlilikBaslangicTarihi.Checked = false;
            dtpGecerlilikBitisTarihi.Checked = false;
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

       
       
      

        

        private void dgvMaliyetMerkezi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CellClick olayını burada kullanabilirsiniz
        }


        private void btnIncele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaliyetMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMaliyetMerkezi.SelectedRows[0];
                    string maliyetMerkeziKodu = selectedRow.Cells["Maliyet Merkezi Kodu"].Value.ToString();

                    DataTable costCenterDetails = _dataAccessLayer.GetMaterialDetails(maliyetMerkeziKodu);
                    MaliyetMerkezleriTumBilgilerForm tumBilgilerForm = new MaliyetMerkezleriTumBilgilerForm();
                    tumBilgilerForm.LoadCostCenterDetails(costCenterDetails);
                    tumBilgilerForm.SetFormModeIncele(false);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir maliyet merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaliyetMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMaliyetMerkezi.SelectedRows[0];
                    string maliyetMerkeziKodu = selectedRow.Cells["Maliyet Merkezi Kodu"].Value.ToString();

                    DataTable costCenterDetails = _dataAccessLayer.GetMaterialDetails(maliyetMerkeziKodu);
                    MaliyetMerkezleriTumBilgilerForm tumBilgilerForm = new MaliyetMerkezleriTumBilgilerForm();
                    
                    tumBilgilerForm.LoadCostCenterDetails(costCenterDetails);
                    tumBilgilerForm.SetFormMode(true);
                    tumBilgilerForm.SetFormModeInsert(true);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir maliyet merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable allData = _dataAccessLayer.GetAllData();
                dgvMaliyetMerkezi.DataSource = allData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                // Filtreler için değerleri almak
                string firma = cbFirmaKodu.SelectedValue?.ToString() == "" ? null : cbFirmaKodu.SelectedValue.ToString();
                string maliyetMerkeziTipi = cbMaliyetMerkeziTipi.SelectedValue?.ToString() == "" ? null : cbMaliyetMerkeziTipi.SelectedValue.ToString();
                string maliyetMerkeziKodu = txtMaliyetMerkeziKodu.Text.Trim();  // Kodu al
                string silindiMi = cbSilindiMi.SelectedValue?.ToString() == "" ? null : cbSilindiMi.SelectedValue.ToString();
                string pasifMi = cbPasifMi.SelectedValue?.ToString() == "" ? null : cbPasifMi.SelectedValue.ToString();
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;


                // DAL sınıfındaki GetFilteredData metoduna parametreleri geçirme
                DataTable result = _dataAccessLayer.GetFilteredData(
                    firma,
                    maliyetMerkeziTipi,
                    maliyetMerkeziKodu,
                    silindiMi,
                    pasifMi,
                    baslangicTarihi,
                    bitisTarihi
                );

                // Sonuçları DataGridView'da gösterme
                dgvMaliyetMerkezi.DataSource = result;

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

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaliyetMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMaliyetMerkezi.SelectedRows[0];
                    string maliyetMerkeziKodu = selectedRow.Cells["Maliyet Merkezi Kodu"].Value.ToString();

                    DataTable costCenterDetails = _dataAccessLayer.GetMaterialDetails(maliyetMerkeziKodu);
                    MaliyetMerkezleriTumBilgilerForm tumBilgilerForm = new MaliyetMerkezleriTumBilgilerForm();
                    tumBilgilerForm.LoadCostCenterDetails(costCenterDetails);
                    tumBilgilerForm.SetFormMode(true);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir maliyet merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                // DataGridView'den seçilen satırdaki Maliyet Merkezi Kodu
                if (dgvMaliyetMerkezi.SelectedRows.Count > 0)
                {
                    // Seçilen satırdaki Maliyet Merkezi Kodu
                    string maliyetMerkeziKodu = dgvMaliyetMerkezi.SelectedRows[0].Cells["Maliyet Merkezi Kodu"].Value.ToString();

                    if (string.IsNullOrWhiteSpace(maliyetMerkeziKodu))
                    {
                        MessageBox.Show("Lütfen silinecek maliyet merkezi kodunu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Silme işlemi için onay isteği
                    var confirmResult = MessageBox.Show("Bu maliyet merkezi kaydını silmek istediğinizden emin misiniz?",
                                                         "Silme Onayı",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Veritabanı üzerinden silme işlemi
                        bool isDeleted = _dataAccessLayer.DeleteCostCenter(maliyetMerkeziKodu);

                        if (isDeleted)
                        {
                            MessageBox.Show("Maliyet merkezi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Silme işleminden sonra listeyi güncelleyebilirsiniz
                           
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silinecek bir maliyet merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       

    }
}
