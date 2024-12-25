using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0CCM001Form : Form
    {
        private BSMGR0CCM001DAL _dataAccessLayer;

        public BSMGR0CCM001Form()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0CCM001DAL(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = _dataAccessLayer.GetAllRecords();
                dgvCostCenters.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtComCode.Clear();
            txtDocType.Clear();
            txtDocTypeText.Clear();
            chkIsPassive.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
            string docType = txtDocType.Text;
            string docTypeText = txtDocTypeText.Text;
            bool isPassive = chkIsPassive.Checked;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve Maliyet Merkezi Tipi zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_dataAccessLayer.IsDocTypeValid(docType))
            {
                MessageBox.Show("Geçersiz Maliyet Merkezi Tipi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _dataAccessLayer.AddRecord(comCode, docType, docTypeText, isPassive);
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
            if (dgvCostCenters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvCostCenters.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldDocType = dgvCostCenters.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
            string comCode = txtComCode.Text;
            string docType = txtDocType.Text;
            string docTypeText = txtDocTypeText.Text;
            bool isPassive = chkIsPassive.Checked;

            try
            {
                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldDocType, comCode, docType, docTypeText, isPassive);

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
            if (dgvCostCenters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string docType = dgvCostCenters.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

            try
            {
                _dataAccessLayer.DeleteRecord(docType);
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

        private void dgvCostCenters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCostCenters.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtComCode.Text = dgvCostCenters.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
            txtDocType.Text = dgvCostCenters.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
            txtDocTypeText.Text = dgvCostCenters.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
            chkIsPassive.Checked = dgvCostCenters.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "1";
        }
    }
}
