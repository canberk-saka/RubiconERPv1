using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using RubiconERPv1.Forms.Alt_Tablolar;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class IsMerkezleriForm : Form
    {
        private BSMGR0WORKCENTERDAL _dataAccessLayer;

        public IsMerkezleriForm()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0WORKCENTERDAL(connectionString);
            dgvIsMerkezi.CellClick += dgvIsMerkezi_CellClick;
        }

        private void IsMerkezleriForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            int x = (this.ClientSize.Width - dgvIsMerkezi.Width) / 2;
            int y = ((this.ClientSize.Height - dgvIsMerkezi.Height) / 2) + 100;
            dgvIsMerkezi.Location = new Point(x, y);

            // ComboBox verilerini yükle
            LoadComboBoxData(cmbFirma, "BSMGR0GEN001", "COMCODE", "COMCODE");
            LoadComboBoxData(cmbDilKodu, "BSMGR0GEN002", "LANCODE", "LANCODE");
            LoadComboBoxData(cmbIsMerkeziTipi, "BSMGR0WCM001", "DOCTYPE", "DOCTYPE");

            // ComboBoxları başlat
            InitializeComboBoxes();
            dgvIsMerkezi.DataSource = null;
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

        private void dgvIsMerkezi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CellClick olayını burada kullanabilirsiniz
        }

        






        private void btnBul_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Filtreler için değerleri almak
                string firma = cmbFirma.SelectedValue?.ToString() == "" ? null : cmbFirma.SelectedValue.ToString();
                string isMerkeziTipi = cmbIsMerkeziTipi.SelectedValue?.ToString() == "" ? null : cmbIsMerkeziTipi.SelectedValue.ToString();
                string isMerkeziKodu = txtIsMerkeziKodu.Text.Trim();  // Kodu al
                string silindiMi = cmbSilindiMi.SelectedValue?.ToString() == "" ? null : cmbSilindiMi.SelectedValue.ToString();
                string pasifMi = cmbPasifMi.SelectedValue?.ToString() == "" ? null : cmbPasifMi.SelectedValue.ToString();
                DateTime? baslangicTarihi = dtpGecerlilikBaslangicTarihi.Checked ? (DateTime?)dtpGecerlilikBaslangicTarihi.Value : null;
                DateTime? bitisTarihi = dtpGecerlilikBitisTarihi.Checked ? (DateTime?)dtpGecerlilikBitisTarihi.Value : null;

                // DAL sınıfındaki GetFilteredData metoduna parametreleri geçirme
                DataTable result = _dataAccessLayer.GetFilteredData(
                    firma,
                    isMerkeziTipi,
                    isMerkeziKodu,
                    silindiMi,
                    pasifMi,
                    baslangicTarihi,
                    bitisTarihi
                );

                // Sonuçları DataGridView'da gösterme
                dgvIsMerkezi.DataSource = result;

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

        private void btnIncele_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvIsMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvIsMerkezi.SelectedRows[0];
                    string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString();

                    DataTable workCenterDetails = _dataAccessLayer.GetWCMDetails(isMerkeziKodu);
                    IsMerkezleriTumBilgilerForm tumBilgilerForm = new IsMerkezleriTumBilgilerForm();
                    tumBilgilerForm.LoadWorkCenterDetails(workCenterDetails);
                    tumBilgilerForm.SetFormMode(false);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir iş merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                if (dgvIsMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvIsMerkezi.SelectedRows[0];
                    string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString();

                    DataTable workCenterDetails = _dataAccessLayer.GetWCMDetails(isMerkeziKodu);
                    IsMerkezleriTumBilgilerForm tumBilgilerForm = new IsMerkezleriTumBilgilerForm();
                    tumBilgilerForm.LoadWorkCenterDetails(workCenterDetails);
                    tumBilgilerForm.SetFormMode(true);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir iş merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvIsMerkezi.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvIsMerkezi.SelectedRows[0];
                    string isMerkeziKodu = selectedRow.Cells["İş Merkezi Kodu"].Value.ToString();

                    DataTable workCenterDetails = _dataAccessLayer.GetWCMDetails(isMerkeziKodu);
                    IsMerkezleriTumBilgilerForm tumBilgilerForm = new IsMerkezleriTumBilgilerForm();

                    tumBilgilerForm.LoadWorkCenterDetails(workCenterDetails);
                    tumBilgilerForm.SetFormMode(true);
                    //tumBilgilerForm.SetFormModeInsert(true);
                    tumBilgilerForm.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen bir iş merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'den seçilen satırdaki İş Merkezi Kodu
                if (dgvIsMerkezi.SelectedRows.Count > 0)
                {
                    // Seçilen satırdaki İş Merkezi Kodu
                    string isMerkeziKodu = dgvIsMerkezi.SelectedRows[0].Cells["İş Merkezi Kodu"].Value.ToString();

                    if (string.IsNullOrWhiteSpace(isMerkeziKodu))
                    {
                        MessageBox.Show("Lütfen silinecek iş merkezi kodunu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Silme işlemi için onay isteği
                    var confirmResult = MessageBox.Show("Bu iş merkezi kaydını silmek istediğinizden emin misiniz?",
                                                         "Silme Onayı",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Veritabanı üzerinden silme işlemi
                        bool isDeleted = _dataAccessLayer.DeleteWCM(isMerkeziKodu);

                        if (isDeleted)
                        {
                            MessageBox.Show("İş merkezi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Lütfen silinecek bir iş merkezi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable allData = _dataAccessLayer.GetAllData();
                dgvIsMerkezi.DataSource = allData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        

       

        private void dgvIsMerkezi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırdaki verileri almak
            if (e.RowIndex >= 0) // Satır seçildi mi kontrolü
            {
                // Satırdaki hücrelerden değerler alınıyor


                string isMerkeziKodu = dgvIsMerkezi.Rows[e.RowIndex].Cells["İş Merkezi Kodu"].Value.ToString();


                // Verileri bir sonraki forma gönderme
                IsMerkezleriOperasyonListeEkraniForm form = new IsMerkezleriOperasyonListeEkraniForm();

                form.SetData(isMerkeziKodu);

                // Formu göster
                form.Show();
            }
        }
    }
}
