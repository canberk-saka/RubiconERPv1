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
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0GEN004DAL(connectionString);

            dgvCities.CellClick += dgvCities_CellClick;

            // ComboBox'ları yükle
            LoadComboBoxes();

            // Verileri yükle ve DataGridView'i özelleştir
            LoadData();
            CustomizeDataGridView();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Firma kodlarını yükle
                DataTable dtCompanies = _dataAccessLayer.GetCompanyCodes();
                comboBox1.DataSource = dtCompanies;
                comboBox1.DisplayMember = "COMCODE";
                comboBox1.ValueMember = "COMCODE";
                comboBox1.SelectedIndex = -1;

                // Ülke kodlarını yükle
                DataTable dtCountries = _dataAccessLayer.GetCountryCodes();
                comboBox2.DataSource = dtCountries;
                comboBox2.DisplayMember = "COUNTRYCODE";
                comboBox2.ValueMember = "COUNTRYCODE";
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ComboBox'lar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                comboBox1.SelectedValue = dgvCities.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                comboBox2.SelectedValue = dgvCities.Rows[e.RowIndex].Cells["COUNTRYCODE"].Value?.ToString() ?? string.Empty;
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            txtCityCode.Clear();
            txtCityText.Clear();
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
            dgvCities.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvCities.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCities.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvCities.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCities.MultiSelect = false;
            dgvCities.AllowUserToAddRows = false;
            dgvCities.AllowUserToDeleteRows = false;
            dgvCities.ReadOnly = true;

            dgvCities.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCities.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCities.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCities.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvCities.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvCities.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCities.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCities.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgvCities.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCities.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCities.GridColor = Color.DarkGray;
            dgvCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCities.RowTemplate.Height = 30;
            dgvCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCities.MultiSelect = false;
            dgvCities.BackgroundColor = Color.LightSteelBlue;
            dgvCities.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = comboBox1.SelectedValue?.ToString();
            string countryCode = comboBox2.SelectedValue?.ToString();
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
            string newComCode = comboBox1.SelectedValue?.ToString();
            string newCountryCode = comboBox2.SelectedValue?.ToString();
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
