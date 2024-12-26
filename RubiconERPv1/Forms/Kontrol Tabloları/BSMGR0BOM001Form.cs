using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0BOM001Form : Form
    {
        private BSMGR0BOM001DAL _dataAccessLayer;
        private string _connectionString = "Data Source=localhost;Initial Catalog=RubiconDB;Integrated Security=True;";

        public BSMGR0BOM001Form()
        {
            InitializeComponent();

            // Bağlantı testi
            TestConnection();

            // Data Access Layer başlatma
            _dataAccessLayer = new BSMGR0BOM001DAL(_connectionString);

            // Verileri yükle ve DataGridView'i özelleştir
            LoadData();
            CustomizeDataGridView();

            // DataGridView'e satır seçme olayı ekle
            dgvBomTypes.CellClick += dgvBomTypes_CellClick;
        }

        private void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Bağlantı başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable dataTable = _dataAccessLayer.GetAllRecords();
                dgvBomTypes.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dgvBomTypes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvBomTypes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBomTypes.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            dgvBomTypes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBomTypes.MultiSelect = false;
            dgvBomTypes.AllowUserToAddRows = false;
            dgvBomTypes.AllowUserToDeleteRows = false;
            dgvBomTypes.ReadOnly = true;

            // Alternating Row Colors
            dgvBomTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvBomTypes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvBomTypes.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvBomTypes.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvBomTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvBomTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvBomTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBomTypes.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvBomTypes.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvBomTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBomTypes.GridColor = Color.DarkGray;

            // Column Auto Resize
            dgvBomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Row Height
            dgvBomTypes.RowTemplate.Height = 30;

            // Selection Mode
            dgvBomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBomTypes.MultiSelect = false;

            dgvBomTypes.BackgroundColor = Color.LightSteelBlue;

            dgvBomTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
             // DataGridView tüm formu kaplayacak şekilde genişler.
        }

        private void ClearFields()
        {
            txtComCode.Clear();
            txtDocType.Clear();
            txtDocTypeText.Clear();
            chkIsPassive.Checked = false;
        }

        private void dgvBomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvBomTypes.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvBomTypes.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtDocType.Text = dgvBomTypes.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
                txtDocTypeText.Text = dgvBomTypes.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
                chkIsPassive.Checked = dgvBomTypes.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text.Trim();
            string docType = txtDocType.Text.Trim();
            string docTypeText = txtDocTypeText.Text.Trim();
            bool isPassive = chkIsPassive.Checked;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve Ürün Ağacı Tipi alanları doldurulmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Kayıt eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBomTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek için bir satır seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvBomTypes.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldDocType = dgvBomTypes.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
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
                    MessageBox.Show("Güncelleme sırasında bir sorun oluştu. Kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBomTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvBomTypes.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string docType = dgvBomTypes.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

            try
            {
                _dataAccessLayer.DeleteRecord(comCode, docType);
                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
