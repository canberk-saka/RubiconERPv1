using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using RubiconERPv1.Forms.Alt_Tablolar;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class UrunAgaciForm : Form
    {
        private BSMGR0BOMDAL _dataAccessLayer;

        public UrunAgaciForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0BOMDAL(connectionString);
        }

        private void UrunAgaciForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            int x = (this.ClientSize.Width - dgvUrunAgaci.Width) / 2;
            int y = ((this.ClientSize.Height - dgvUrunAgaci.Height) / 2) + 100;
            dgvUrunAgaci.Location = new Point(x, y);

            // Load ComboBoxes data
            LoadComboBoxData(cmbFirma, "BSMGR0GEN001", "COMCODE", "COMCODE");
            LoadComboBoxData(cmbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE");
            LoadComboBoxData(cmbUrunAgaciTipi, "BSMGR0BOM001", "DOCTYPE", "DOCTYPE");

            // Initialize ComboBoxes for Yes/No selections
            InitializeComboBoxes();

            // Clear DataGridView
            dgvUrunAgaci.DataSource = null;
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
            cmbSilindiMi.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Hayır" },
                new { Value = "1", Text = "Evet" }
            };
            cmbSilindiMi.DisplayMember = "Text";
            cmbSilindiMi.ValueMember = "Value";

            cmbPasifMi.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Hayır" },
                new { Value = "1", Text = "Evet" }
            };
            cmbPasifMi.DisplayMember = "Text";
            cmbPasifMi.ValueMember = "Value";
        }

        private void dgvUrunAgaci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle DataGridView cell click here
        }







        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                // Get filter criteria from UI
                string firmaKodu = cmbFirma.SelectedValue?.ToString() == "" ? null : cmbFirma.SelectedValue.ToString();
                string urunAgaciTipi = cmbUrunAgaciTipi.SelectedValue?.ToString() == "" ? null : cmbUrunAgaciTipi.SelectedValue.ToString();
                string malzemeTipi = cmbMalzemeTipi.SelectedValue?.ToString() == "" ? null : cmbMalzemeTipi.SelectedValue.ToString();
                string malzemeKodu = txtMalzemeKodu.Text;
                string urunAgaciKodu = txtUrunAgaciKodu.Text.Trim();
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;
                string silindiMi = cmbSilindiMi.SelectedValue?.ToString() == "" ? null : cmbSilindiMi.SelectedValue.ToString();
                string pasifMi = cmbPasifMi.SelectedValue?.ToString() == "" ? null : cmbPasifMi.SelectedValue.ToString();

                // Call the DAL method to get filtered data
                DataTable result = _dataAccessLayer.GetFilteredData(
                    firmaKodu,
                    urunAgaciTipi,
                    malzemeTipi,
                    malzemeKodu,
                    urunAgaciKodu,
                    baslangicTarihi,
                    bitisTarihi,
                    silindiMi,
                    pasifMi
                );

                // Bind the result to DataGridView
                dgvUrunAgaci.DataSource = result;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Seçtiğiniz filtrelere uygun ürün ağacı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Check if a row is selected in the DataGridView
                if (dgvUrunAgaci.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvUrunAgaci.SelectedRows[0];
                    string urunAgaciKodu = selectedRow.Cells["Ürün Ağacı Kodu"].Value.ToString();

                    // Fetch details of the selected product tree (Urun Agaci)
                    DataTable urunAgaciDetails = _dataAccessLayer.GetUrunAgaciDetails(urunAgaciKodu);

                    if (urunAgaciDetails.Rows.Count > 0)
                    {
                        // Create and show the new form to display the details
                        UrunAgaclariTumBilgilerForm detailsForm = new UrunAgaclariTumBilgilerForm();
                        detailsForm.LoadUrunAgaciDetails(urunAgaciDetails);
                        detailsForm.SetFormMode(false);  // Set the form in "view-only" mode
                        detailsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen ürün ağacı ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir ürün ağacı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İnceleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable allData = _dataAccessLayer.GetAllData();
                dgvUrunAgaci.DataSource = allData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuzenle_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView
                if (dgvUrunAgaci.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvUrunAgaci.SelectedRows[0];
                    string urunAgaciKodu = selectedRow.Cells["Ürün Ağacı Kodu"].Value.ToString();

                    // Fetch details of the selected product tree (Urun Agaci)
                    DataTable urunAgaciDetails = _dataAccessLayer.GetUrunAgaciDetails(urunAgaciKodu);

                    if (urunAgaciDetails.Rows.Count > 0)
                    {
                        // Create and show the new form to display the details
                        UrunAgaclariTumBilgilerForm detailsForm = new UrunAgaclariTumBilgilerForm();
                        detailsForm.LoadUrunAgaciDetails(urunAgaciDetails);
                        detailsForm.SetFormMode(true);  // Set the form in "view-only" mode
                        detailsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen ürün ağacı ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir ürün ağacı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İnceleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvUrunAgaci.SelectedRows.Count > 0)
                {
                    string urunAgaciKodu = dgvUrunAgaci.SelectedRows[0].Cells["Ürün Ağacı Kodu"].Value.ToString();

                    var confirmResult = MessageBox.Show("Bu ürün ağacını silmek istediğinizden emin misiniz?",
                                                         "Silme Onayı",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        bool isDeleted = _dataAccessLayer.DeleteBOM(urunAgaciKodu);

                        if (isDeleted)
                        {
                            MessageBox.Show("Ürün ağacı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvUrunAgaci.DataSource = _dataAccessLayer.GetAllData();
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView
                if (dgvUrunAgaci.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvUrunAgaci.SelectedRows[0];
                    string urunAgaciKodu = selectedRow.Cells["Ürün Ağacı Kodu"].Value.ToString();

                    // Fetch details of the selected product tree (Urun Agaci)
                    DataTable urunAgaciDetails = _dataAccessLayer.GetUrunAgaciDetails(urunAgaciKodu);

                    if (urunAgaciDetails.Rows.Count > 0)
                    {
                        // Create and show the new form to display the details
                        UrunAgaclariTumBilgilerForm detailsForm = new UrunAgaclariTumBilgilerForm();
                        detailsForm.LoadUrunAgaciDetails(urunAgaciDetails);
                        detailsForm.SetFormMode(true);  // Set the form in "view-only" mode
                        detailsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen ürün ağacı ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir ürün ağacı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İnceleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUrunAgaci_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUrunAgaci_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Eğer geçerli bir satır seçilmişse
                if (e.RowIndex >= 0)
                {
                    // Seçilen satırdaki Malzeme Kodu'nu al
                    string urunAgaciKodu = dgvUrunAgaci.Rows[e.RowIndex].Cells["Ürün Ağacı Kodu"].Value.ToString();

                    // UrunAgaclariComponentEkraniForm formunu oluştur
                    UrunAgaclariComponentEkraniForm componentEkraniForm = new UrunAgaclariComponentEkraniForm();

                    // Malzeme Kodu'nu formun SetData metoduyla gönder
                    componentEkraniForm.SetUrunAgaciKodu(urunAgaciKodu);

                    // Formu göster
                    componentEkraniForm.Show();
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
