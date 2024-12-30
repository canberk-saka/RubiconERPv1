using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0ROT002Form : Form
    {
        private BSMGR0ROT002DAL _dataAccessLayer;
        string connectionString = DbConnection.GetConnectionString();

        public BSMGR0ROT002Form()
        {
            InitializeComponent();

            // Bağlantı testi
            TestConnection();

            // Data Access Layer başlatma
            _dataAccessLayer = new BSMGR0ROT002DAL(connectionString);

            // ComboBox verilerini yükle
            LoadComboBox();

            // Verileri yükle
            LoadData();
            CustomizeDataGridView();

            // DataGridView'e satır seçme olayı ekle
            dgvCenters.CellClick += dgvCenters_CellClick;
        }

        private void LoadComboBox()
        {
            try
            {
                DataTable companyCodes = _dataAccessLayer.GetCompanyCodes();
                comboBox1.DataSource = companyCodes;
                comboBox1.DisplayMember = "COMCODE"; // Görüntülenecek sütun
                comboBox1.ValueMember = "COMCODE";   // Değer olarak kullanılacak sütun
                comboBox1.SelectedIndex = -1;        // Varsayılan seçim yok
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dgvCenters.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvCenters.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCenters.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            dgvCenters.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCenters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCenters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCenters.MultiSelect = false;
            dgvCenters.AllowUserToAddRows = false;
            dgvCenters.AllowUserToDeleteRows = false;
            dgvCenters.ReadOnly = true;

            // Alternating Row Colors
            dgvCenters.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCenters.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCenters.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCenters.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvCenters.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvCenters.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCenters.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCenters.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvCenters.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvCenters.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCenters.GridColor = Color.DarkGray;

            // Column Auto Resize
            dgvCenters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Row Height
            dgvCenters.RowTemplate.Height = 30;

            // Background Color
            dgvCenters.BackgroundColor = Color.LightSteelBlue;

            // Docking for full resize
            dgvCenters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
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
                dgvCenters.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            comboBox1.SelectedIndex = -1;
            txtDocType.Clear();
            txtDocTypeText.Clear();
            chkIsPassive.Checked = false;
        }

        private void dgvCenters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCenters.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                comboBox1.SelectedValue = dgvCenters.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString();
                txtDocType.Text = dgvCenters.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
                txtDocTypeText.Text = dgvCenters.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
                chkIsPassive.Checked = dgvCenters.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = comboBox1.SelectedValue?.ToString();
            string docType = txtDocType.Text.Trim();
            string docTypeText = txtDocTypeText.Text.Trim();
            bool isPassive = chkIsPassive.Checked;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve İş Merkezi Tipi alanları doldurulmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvCenters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek için bir satır seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvCenters.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldDocType = dgvCenters.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
            string comCode = comboBox1.SelectedValue?.ToString();
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
            if (dgvCenters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvCenters.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string docType = dgvCenters.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

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
