using System;
using System.Data;
using System.Drawing;
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

            // Verileri yükle ve DataGridView'i özelleştir
            LoadData();
            CustomizeDataGridView();

            // DataGridView'e olay ekle
            dgvCostCenters.CellClick += dgvCostCenters_CellClick;
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

        private void CustomizeDataGridView()
        {
            dgvCostCenters.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvCostCenters.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCostCenters.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvCostCenters.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCostCenters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCostCenters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCostCenters.MultiSelect = false;
            dgvCostCenters.AllowUserToAddRows = false;
            dgvCostCenters.AllowUserToDeleteRows = false;
            dgvCostCenters.ReadOnly = true;

            // Alternating Row Colors
            dgvCostCenters.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCostCenters.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCostCenters.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCostCenters.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvCostCenters.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvCostCenters.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCostCenters.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCostCenters.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvCostCenters.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvCostCenters.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCostCenters.GridColor = Color.DarkGray;

            // Row Height
            dgvCostCenters.RowTemplate.Height = 30;

            // Background Color
            dgvCostCenters.BackgroundColor = Color.LightSteelBlue;

            
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
            string comCode = txtComCode.Text.Trim();
            string docType = txtDocType.Text.Trim();
            string docTypeText = txtDocTypeText.Text.Trim();
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
            string comCode = txtComCode.Text.Trim();
            string docType = txtDocType.Text.Trim();
            string docTypeText = txtDocTypeText.Text.Trim();
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
