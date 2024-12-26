using System;
using System.Data;
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
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0GEN001DAL(connectionString);

            dgvCompanies.CellClick += dgvCompanies_CellClick;

            LoadData();
            CustomizeDataGridView();
            
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

        private void CustomizeDataGridView()
        {
            dgvCompanies.Dock = DockStyle.Top;
            dgvCompanies.Height = this.ClientSize.Height / 2;

            dgvCompanies.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvCompanies.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompanies.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvCompanies.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompanies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompanies.MultiSelect = false;
            dgvCompanies.AllowUserToAddRows = false;
            dgvCompanies.AllowUserToDeleteRows = false;
            dgvCompanies.ReadOnly = true;

            dgvCompanies.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCompanies.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCompanies.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvCompanies.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvCompanies.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvCompanies.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompanies.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgvCompanies.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCompanies.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCompanies.GridColor = Color.DarkGray;
            dgvCompanies.RowTemplate.Height = 30;
            dgvCompanies.BackgroundColor = Color.LightSteelBlue;
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
            // Güncelleme işlemleri
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silme işlemleri
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtComText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
