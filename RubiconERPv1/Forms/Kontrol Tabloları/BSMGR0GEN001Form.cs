using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0GEN001Form : Form
    {
        private BSMGR0GEN001DAL _dataAccessLayer;

        public BSMGR0GEN001Form()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0GEN001DAL(connectionString);
            dgvCompanies.CellClick += dgvCompanies_CellClick;
            LoadData();
        }

        private void dgvCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCompanies.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvCompanies.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtComText.Text = dgvCompanies.Rows[e.RowIndex].Cells["COMTEXT"].Value?.ToString() ?? string.Empty;
                txtAddress1.Text = dgvCompanies.Rows[e.RowIndex].Cells["ADDRESS1"].Value?.ToString() ?? string.Empty;
                txtAddress2.Text = dgvCompanies.Rows[e.RowIndex].Cells["ADDRESS2"].Value?.ToString() ?? string.Empty;
                txtCityCode.Text = dgvCompanies.Rows[e.RowIndex].Cells["CITYCODE"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtComCode.Clear();
            txtComText.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtCityCode.Clear();
        }

        private void LoadData()
        {
            try
            {
                DataTable dtCompanies = _dataAccessLayer.GetAllRecords();
                dgvCompanies.DataSource = dtCompanies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
            string comText = txtComText.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string cityCode = txtCityCode.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(comText))
            {
                MessageBox.Show("Firma Kodu ve Firma Adı zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dataAccessLayer.AddRecord(comCode, comText, address1, address2, cityCode);
            MessageBox.Show("Kıyayt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComCode.Text) || string.IsNullOrEmpty(txtComText.Text))
            {
                MessageBox.Show("Firma Kodu ve Firma Adı zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string oldComCode = dgvCompanies.SelectedRows[0].Cells["COMCODE"].Value.ToString();
                string comCode = txtComCode.Text;
                string comText = txtComText.Text;
                string address1 = txtAddress1.Text;
                string address2 = txtAddress2.Text;
                string cityCode = txtCityCode.Text;

                _dataAccessLayer.UpdateRecord(oldComCode, comCode, comText, address1, address2, cityCode);
                MessageBox.Show("Kıyayt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string comCode = dgvCompanies.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                if (!string.IsNullOrEmpty(comCode))
                {
                    _dataAccessLayer.DeleteRecord(comCode);
                    MessageBox.Show("Kıyayt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
