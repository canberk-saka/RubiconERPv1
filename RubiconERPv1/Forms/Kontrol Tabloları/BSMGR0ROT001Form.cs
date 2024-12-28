using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0ROT001Form : Form
    {
        private BSMGR0ROT001DAL _dataAccessLayer;
        string connectionString = DbConnection.GetConnectionString();

        public BSMGR0ROT001Form()
        {
            InitializeComponent();

            // Bağlantı testi
            TestConnection();

            // Data Access Layer başlatma
            _dataAccessLayer = new BSMGR0ROT001DAL(connectionString);
                
            // DataGridView'e veri yükleme
            LoadData();
            CustomizeDataGridView();

            dgvRoutes.CellClick += dgvRoutes_CellClick;
        }

        private void CustomizeDataGridView()
        {
            dgvRoutes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvRoutes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoutes.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            dgvRoutes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoutes.MultiSelect = false;
            dgvRoutes.AllowUserToAddRows = false;
            dgvRoutes.AllowUserToDeleteRows = false;
            dgvRoutes.ReadOnly = true;

            // Alternating Row Colors
            dgvRoutes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvRoutes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRoutes.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvRoutes.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvRoutes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvRoutes.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvRoutes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRoutes.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvRoutes.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvRoutes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRoutes.GridColor = Color.DarkGray;

            // Column Auto Resize
            dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Row Height
            dgvRoutes.RowTemplate.Height = 30;

            // Background Color
            dgvRoutes.BackgroundColor = Color.LightSteelBlue;

            // Docking for full resize
            dgvRoutes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }


        // Bağlantıyı test et
        private void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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



        // Verileri yükle
        private void LoadData()
        {
            try
            {
                DataTable dataTable = _dataAccessLayer.GetAllRecords();
                dgvRoutes.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Alanları temizle
        private void ClearFields()
        {
            txtComCode.Clear();
            txtDocType.Clear();
            txtDocTypeText.Clear();
            chkIsPassive.Checked = false;
        }

        // DataGridView satır seçimi
        private void dgvRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRoutes.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvRoutes.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtDocType.Text = dgvRoutes.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
                txtDocTypeText.Text = dgvRoutes.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
                chkIsPassive.Checked = dgvRoutes.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kaydet butonu
        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text.Trim();
            string docType = txtDocType.Text.Trim();
            string docTypeText = txtDocTypeText.Text.Trim();
            bool isPassive = chkIsPassive.Checked;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve Rota Tipi alanları doldurulmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Güncelle butonu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek için bir satır seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvRoutes.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldDocType = dgvRoutes.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
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

        // Sil butonu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvRoutes.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string docType = dgvRoutes.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();

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

        // Temizle butonu
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
