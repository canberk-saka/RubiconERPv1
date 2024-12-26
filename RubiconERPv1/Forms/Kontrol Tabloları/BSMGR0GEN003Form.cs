using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0GEN003Form : Form
    {
        private BSMGR0GEN003DAL _dataAccessLayer;

        public BSMGR0GEN003Form()
        {
            InitializeComponent();
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0GEN003DAL(connectionString);
            dgvCountries.CellClick += dgvCountries_CellClick;
            CustomizeDataGridView();
            LoadData();
        }

        private void CustomizeDataGridView()
        {
            // Genel tasarım
            dgvCountries.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvCountries.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCountries.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvCountries.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCountries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCountries.MultiSelect = false;
            dgvCountries.AllowUserToAddRows = false;
            dgvCountries.AllowUserToDeleteRows = false;
            dgvCountries.ReadOnly = true;

            // Arka plan rengi ve grid stili
            dgvCountries.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCountries.BackgroundColor = Color.LightSteelBlue; // Açık mavi arka plan
            dgvCountries.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCountries.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCountries.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Başlık stili
            dgvCountries.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCountries.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCountries.EnableHeadersVisualStyles = false;

            // Grid ayarları
            dgvCountries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCountries.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCountries.GridColor = Color.DarkGray;
            dgvCountries.RowTemplate.Height = 30;

            // DataGridView'in ekranı kaplamamasını sağlar
            dgvCountries.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCountries.Size = new Size(750, 250); // Boyutu ayarla
            dgvCountries.Location = new Point(20, 20); // Formdaki konumu ayarla
        }

        private void dgvCountries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCountries.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvCountries.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtCountryCode.Text = dgvCountries.Rows[e.RowIndex].Cells["COUNTRYCODE"].Value?.ToString() ?? string.Empty;
                txtCountryText.Text = dgvCountries.Rows[e.RowIndex].Cells["COUNTRYTEXT"].Value?.ToString() ?? string.Empty;
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
            txtCountryText.Clear();
        }

        private void LoadData()
        {
            try
            {
                DataTable dtCountries = _dataAccessLayer.GetAllRecords();
                dgvCountries.DataSource = dtCountries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
            string countryCode = txtCountryCode.Text;
            string countryText = txtCountryText.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(countryCode))
            {
                MessageBox.Show("Firma Kodu ve Ülke Kodu zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dataAccessLayer.AddRecord(comCode, countryCode, countryText);
            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountryCode.Text) || string.IsNullOrEmpty(txtCountryText.Text))
            {
                MessageBox.Show("Ülke Kodu ve Ülke Adı zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCountries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string oldCountryCode = dgvCountries.SelectedRows[0].Cells["COUNTRYCODE"].Value?.ToString();
                string oldComCode = dgvCountries.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string newComCode = txtComCode.Text;
                string newCountryCode = txtCountryCode.Text;
                string countryText = txtCountryText.Text;

                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldCountryCode, newComCode, newCountryCode, countryText);

                if (result)
                {
                    MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu. Kayıt bulunamamış olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCountries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string comCode = dgvCountries.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string countryCode = dgvCountries.SelectedRows[0].Cells["COUNTRYCODE"].Value?.ToString();

                if (!string.IsNullOrEmpty(comCode) && !string.IsNullOrEmpty(countryCode))
                {
                    _dataAccessLayer.DeleteRecord(comCode, countryCode);
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Geçersiz kayıt seçildi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
