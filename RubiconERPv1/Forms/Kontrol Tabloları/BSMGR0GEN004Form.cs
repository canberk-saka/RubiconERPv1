using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0GEN004Form : Form
    {
        private BSMGR0GEN004DAL _dataAccessLayer;

        public BSMGR0GEN004Form()
        {
            InitializeComponent();
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0GEN004DAL(connectionString);

            dgvCities.CellClick += dgvCities_CellClick;

            // Verileri yükle ve DataGridView'i özelleştir
            LoadData();
            CustomizeDataGridView();
        }

        private void LoadData()
        {
            try
            {
                DataTable dtCities = _dataAccessLayer.GetAllRecords();
                dgvCities.DataSource = dtCities;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dgvCities.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvCities.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCities.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            dgvCities.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCities.MultiSelect = false;
            dgvCities.AllowUserToAddRows = false;
            dgvCities.AllowUserToDeleteRows = false;
            dgvCities.ReadOnly = true;

            // Alternating Row Colors
            dgvCities.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCities.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCities.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCities.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvCities.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvCities.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCities.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCities.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvCities.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvCities.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCities.GridColor = Color.DarkGray;

            // Column Auto Resize
            dgvCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Row Height
            dgvCities.RowTemplate.Height = 30;

            // Selection Mode
            dgvCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCities.MultiSelect = false;

            dgvCities.BackgroundColor = Color.LightSteelBlue;

            dgvCities.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
             // DataGridView tüm formu kaplayacak şekilde genişler.
                                             // Diğer kontroller ekranın alt kısmına sabitlenecek
            



        }

        private void dgvCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCities.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvCities.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtCountryCode.Text = dgvCities.Rows[e.RowIndex].Cells["COUNTRYCODE"].Value?.ToString() ?? string.Empty;
                txtCityCode.Text = dgvCities.Rows[e.RowIndex].Cells["CITYCODE"].Value?.ToString() ?? string.Empty;
                txtCityText.Text = dgvCities.Rows[e.RowIndex].Cells["CITYTEXT"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtComCode.Clear();
            txtCountryCode.Clear();
            txtCityCode.Clear();
            txtCityText.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text.Trim();
            string countryCode = txtCountryCode.Text.Trim();
            string cityCode = txtCityCode.Text.Trim();
            string cityText = txtCityText.Text.Trim();

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(countryCode) || string.IsNullOrEmpty(cityCode))
            {
                MessageBox.Show("Firma Kodu, Ülke Kodu ve Şehir Kodu doldurulmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _dataAccessLayer.AddRecord(comCode, countryCode, cityCode, cityText);
                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt ekleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvCities.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldCityCode = dgvCities.SelectedRows[0].Cells["CITYCODE"].Value?.ToString();
            string newComCode = txtComCode.Text.Trim();
            string newCountryCode = txtCountryCode.Text.Trim();
            string newCityCode = txtCityCode.Text.Trim();
            string cityText = txtCityText.Text.Trim();

            try
            {
                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldCityCode, newComCode, newCountryCode, newCityCode, cityText);

                if (result)
                {
                    MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvCities.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string cityCode = dgvCities.SelectedRows[0].Cells["CITYCODE"].Value?.ToString();

            try
            {
                _dataAccessLayer.DeleteRecord(comCode, cityCode);
                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
