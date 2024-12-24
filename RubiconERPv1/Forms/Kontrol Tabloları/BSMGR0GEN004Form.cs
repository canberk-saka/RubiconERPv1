using System;
using System.Data;
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
            LoadData();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
            string cityCode = txtCityCode.Text;
            string cityText = txtCityText.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(cityCode))
            {
                MessageBox.Show("Firma Kodu ve Şehir Kodu zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dataAccessLayer.AddRecord(comCode, cityCode, cityText);
            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCityCode.Text) || string.IsNullOrEmpty(txtCityText.Text))
            {
                MessageBox.Show("Şehir Kodu ve Şehir Adı zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string oldCityCode = dgvCities.SelectedRows[0].Cells["CITYCODE"].Value?.ToString();
                string oldComCode = dgvCities.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string newComCode = txtComCode.Text;
                string newCityCode = txtCityCode.Text;
                string cityText = txtCityText.Text;

                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldCityCode, newComCode, newCityCode, cityText);

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
            if (dgvCities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string comCode = dgvCities.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string cityCode = dgvCities.SelectedRows[0].Cells["CITYCODE"].Value?.ToString();

                if (!string.IsNullOrEmpty(comCode) && !string.IsNullOrEmpty(cityCode))
                {
                    _dataAccessLayer.DeleteRecord(comCode, cityCode);
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
