using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0MAT001Form : Form
    {
        private BSMGR0MAT001DAL _dataAccessLayer;

        public BSMGR0MAT001Form()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0MAT001DAL(connectionString);

            dgvMaterials.CellClick += dgvMaterials_CellClick;
            cbIsPassive.Items.AddRange(new string[] { "0 - Hayır", "1 - Evet" });

            LoadComboBox();
            LoadData();
            CustomizeDataGridView();
        }

        private void LoadComboBox()
        {
            try
            {
                DataTable dtCompanies = _dataAccessLayer.GetCompanyCodes();
                comboBox1.DataSource = dtCompanies;
                comboBox1.DisplayMember = "COMCODE"; // Görüntülenecek sütun
                comboBox1.ValueMember = "COMCODE";   // Değer olarak kullanılacak sütun
                comboBox1.SelectedIndex = -1;        // Varsayılan seçili değeri temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dgvMaterials.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvMaterials.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMaterials.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvMaterials.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterials.MultiSelect = false;
            dgvMaterials.AllowUserToAddRows = false;
            dgvMaterials.AllowUserToDeleteRows = false;
            dgvMaterials.ReadOnly = true;

            dgvMaterials.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvMaterials.RowsDefaultCellStyle.BackColor = Color.White;
            dgvMaterials.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvMaterials.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvMaterials.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvMaterials.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvMaterials.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterials.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgvMaterials.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvMaterials.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMaterials.GridColor = Color.DarkGray;
            dgvMaterials.RowTemplate.Height = 30;
            dgvMaterials.BackgroundColor = Color.LightSteelBlue;
            dgvMaterials.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMaterials.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                comboBox1.SelectedValue = dgvMaterials.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtDocType.Text = dgvMaterials.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
                txtDocTypeText.Text = dgvMaterials.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
                cbIsPassive.Text = (dgvMaterials.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "True") ? "1 - Evet" : "0 - Hayır";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            comboBox1.SelectedIndex = -1;
            txtDocType.Clear();
            txtDocTypeText.Clear();
            cbIsPassive.SelectedIndex = -1;
        }

        private void LoadData()
        {
            try
            {
                DataTable dtMaterials = _dataAccessLayer.GetAllRecords();
                dgvMaterials.DataSource = dtMaterials;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = comboBox1.SelectedValue?.ToString();
            string docType = txtDocType.Text;
            string docTypeText = txtDocTypeText.Text;
            bool isPassive = cbIsPassive.Text == "1 - Evet";

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve Malzeme Tipi zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dataAccessLayer.AddRecord(comCode, docType, docTypeText, isPassive);
            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvMaterials.SelectedRows[0].Cells["COMCODE"].Value.ToString();
            string oldDocType = dgvMaterials.SelectedRows[0].Cells["DOCTYPE"].Value.ToString();

            string comCode = comboBox1.SelectedValue?.ToString();
            string docType = txtDocType.Text;
            string docTypeText = txtDocTypeText.Text;
            bool isPassive = cbIsPassive.Text == "1 - Evet";

            bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldDocType, comCode, docType, docTypeText, isPassive);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string docType = dgvMaterials.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

            _dataAccessLayer.DeleteRecord(docType);
            MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
