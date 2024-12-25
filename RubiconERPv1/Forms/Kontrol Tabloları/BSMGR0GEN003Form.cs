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
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0GEN003DAL(connectionString);
            dgvCountries.CellClick += dgvCountries_CellClick;
            LoadData();
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
