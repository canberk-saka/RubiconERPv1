using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using RubiconERPv1.Forms.Alt_Tablolar;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class MalzemeBilgileriForm : Form
    {
        private BSMGR0MATDAL _dataAccessLayer;

        public MalzemeBilgileriForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0MATDAL(connectionString);
            dgvMalzemeBilgileri.CellClick += dgvMalzemeBilgileri_CellClick;
        }

        private void MalzemeBilgileriForm2_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            int x = (this.ClientSize.Width - dgvMalzemeBilgileri.Width) / 2;
            int y = ((this.ClientSize.Height - dgvMalzemeBilgileri.Height) / 2) + 100;
            dgvMalzemeBilgileri.Location = new Point(x, y);
            

            // ComboBox verilerini yükle
            LoadComboBoxData(cbFirmaKodu, "BSMGR0GEN001", "COMCODE", "COMCODE");
            LoadComboBoxData(cmbMalzemeTipi, "BSMGR0MAT001", "DOCTYPE", "DOCTYPE");
            LoadComboBoxData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");

            InitializeComboBoxes();
            dgvMalzemeBilgileri.DataSource = null;
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
                newRow[valueMember] = "Seçiniz";
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
            cmbTedarikTipi.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Satın Alınan" },
                new { Value = "1", Text = "Üretilen" }
            };
            cmbTedarikTipi.DisplayMember = "Text";
            cmbTedarikTipi.ValueMember = "Value";

            cmbUrunAgaci.DataSource = new[] {
                new { Value = "", Text = "Seçiniz" },
                new { Value = "0", Text = "Hayır" },
                new { Value = "1", Text = "Evet" },
                new { Value = "2", Text = "Olmayacak" }
            };
            cmbUrunAgaci.DisplayMember = "Text";
            cmbUrunAgaci.ValueMember = "Value";

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

        private void btnIncele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMalzemeBilgileri.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMalzemeBilgileri.SelectedRows[0];
                    string malzemeKodu = selectedRow.Cells["Malzeme Kodu"].Value.ToString();

                    DataTable materialDetails = _dataAccessLayer.GetMaterialDetails(malzemeKodu);
                    MalzemeTumBilgilerForm tumBilgilerForm = new MalzemeTumBilgilerForm();
                    tumBilgilerForm.LoadMaterialDetails(materialDetails);
                    tumBilgilerForm.SetFormMode(false);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir malzeme seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgvMalzemeBilgileri.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMalzemeBilgileri.SelectedRows[0];
                    string malzemeKodu = selectedRow.Cells["Malzeme Kodu"].Value.ToString();

                    DataTable materialDetails = _dataAccessLayer.GetMaterialDetails(malzemeKodu);
                    MalzemeTumBilgilerForm tumBilgilerForm = new MalzemeTumBilgilerForm();
                    tumBilgilerForm.LoadMaterialDetails(materialDetails);
                    tumBilgilerForm.SetFormMode(true);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir malzeme seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                string firma = cbFirmaKodu.SelectedValue?.ToString() == "" ? null : cbFirmaKodu.SelectedValue.ToString();
                string malzemeTipi = cmbMalzemeTipi.SelectedValue?.ToString() == "" ? null : cmbMalzemeTipi.SelectedValue.ToString();
                string malzemeNo = string.IsNullOrWhiteSpace(cmbMalzemeNo.Text) ? null : cmbMalzemeNo.Text;
                string tedarikTipi = cmbTedarikTipi.SelectedValue?.ToString();
                string malzemeKisaAciklama = string.IsNullOrWhiteSpace(txtMalzemeKisaAciklama.Text) ? null : txtMalzemeKisaAciklama.Text;
                string malzemeUzunAciklama = string.IsNullOrWhiteSpace(txtMalzemeUzunAciklama.Text) ? null : txtMalzemeUzunAciklama.Text;
                string urunAgaciVarMi = cmbUrunAgaci.SelectedValue?.ToString();
                string dilKodu = cmbDilKodu.SelectedValue?.ToString() == "" ? null : cmbDilKodu.SelectedValue.ToString();
                string silindiMi = cmbSilindiMi.SelectedValue?.ToString();
                string pasifMi = cmbPasifMi.SelectedValue?.ToString();
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                DataTable result = _dataAccessLayer.GetFilteredData(
                    firma, malzemeTipi, malzemeNo, tedarikTipi,
                    malzemeKisaAciklama, malzemeUzunAciklama,
                    urunAgaciVarMi, dilKodu, silindiMi, pasifMi,
                    baslangicTarihi, bitisTarihi
                );

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

        private void btnTumunuGoster_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                DataTable allData = _dataAccessLayer.GetAllData();
                dgvMalzemeBilgileri.DataSource = allData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMalzemeBilgileri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }
       




        private void btnEkle_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvMalzemeBilgileri.SelectedRows[0];
            string malzemeKodu = selectedRow.Cells["Malzeme Kodu"].Value.ToString();

            DataTable materialDetails = _dataAccessLayer.GetMaterialDetails(malzemeKodu);
            MalzemeTumBilgilerForm tumBilgilerForm = new MalzemeTumBilgilerForm();
            tumBilgilerForm.LoadMaterialDetails(materialDetails);
            tumBilgilerForm.SetFormMode(true);
            tumBilgilerForm.SetFormModeInsert(true);
            tumBilgilerForm.Show();
        }

        private void button_sil_Click_1(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırdaki Maliyet Merkezi Kodu
                if (dgvMalzemeBilgileri.SelectedRows.Count > 0)
                {
                    // Seçilen satırdaki Maliyet Merkezi Kodu
                    string malzemeKodu = dgvMalzemeBilgileri.SelectedRows[0].Cells["Malzeme Kodu"].Value.ToString();

                    if (string.IsNullOrWhiteSpace(malzemeKodu))
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
                        bool isDeleted = _dataAccessLayer.DeleteMaterial(malzemeKodu);

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
