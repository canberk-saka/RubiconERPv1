using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0ROT003Form : Form
    {
        private BSMGR0ROT003DAL _dataAccessLayer;
        string connectionString = DbConnection.GetConnectionString();

        public BSMGR0ROT003Form()
        {
            InitializeComponent();

            // Bağlantı testi
            TestConnection();

            // Data Access Layer başlatma
            _dataAccessLayer = new BSMGR0ROT003DAL(connectionString);

            // Firma kodlarını ComboBox'a yükle
            LoadCompanyCodes();

            // Verileri yükle
            LoadData();
            CustomizeDataGridView();

            // DataGridView'e satır seçme olayı ekle
            dgvOperations.CellClick += dgvOperations_CellClick;
        }

        private void CustomizeDataGridView()
        {
            dgvOperations.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvOperations.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOperations.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvOperations.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.MultiSelect = false;
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.AllowUserToDeleteRows = false;
            dgvOperations.ReadOnly = true;

            dgvOperations.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvOperations.RowsDefaultCellStyle.BackColor = Color.White;
            dgvOperations.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvOperations.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvOperations.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvOperations.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvOperations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOperations.EnableHeadersVisualStyles = false;

            dgvOperations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOperations.GridColor = Color.DarkGray;

            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperations.RowTemplate.Height = 30;
            dgvOperations.BackgroundColor = Color.LightSteelBlue;

            dgvOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
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
                dgvOperations.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompanyCodes()
        {
            try
            {
                DataTable companyCodes = _dataAccessLayer.GetCompanyCodes();
                comboBox1.DataSource = companyCodes;
                comboBox1.DisplayMember = "COMCODE";
                comboBox1.ValueMember = "COMCODE";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            comboBox1.SelectedIndex = -1;
            txtDocType.Clear();
            txtDocTypeText.Clear();
            chkIsPassive.Checked = false;
        }

        private void dgvOperations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOperations.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                comboBox1.SelectedValue = dgvOperations.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString();
                txtDocType.Text = dgvOperations.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString();
                txtDocTypeText.Text = dgvOperations.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString();
                chkIsPassive.Checked = dgvOperations.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "1";
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
                MessageBox.Show("Firma Kodu ve Operasyon Tipi alanları doldurulmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvOperations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek için bir satır seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvOperations.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldDocType = dgvOperations.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
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
            if (dgvOperations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvOperations.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string docType = dgvOperations.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

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
