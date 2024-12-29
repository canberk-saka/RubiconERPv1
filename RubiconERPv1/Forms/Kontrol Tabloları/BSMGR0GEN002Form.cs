using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0GEN002Form : Form
    {
        private BSMGR0GEN002DAL _dataAccessLayer;

        public BSMGR0GEN002Form()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0GEN002DAL(connectionString);

            dgvLanguages.CellClick += dgvLanguages_CellClick;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

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
                comboBox1.SelectedIndex = -1; // Başlangıçta seçili bir değer olmasın
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Firma kodu combobox'tan seçildiğinde işlem yapabilirsiniz
        }

        private void LoadData()
        {
            try
            {
                DataTable dtLanguages = _dataAccessLayer.GetAllRecords();
                dgvLanguages.DataSource = dtLanguages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dgvLanguages.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvLanguages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLanguages.DefaultCellStyle.Font = new Font("Arial", 10F);
            dgvLanguages.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLanguages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLanguages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLanguages.MultiSelect = false;
            dgvLanguages.AllowUserToAddRows = false;
            dgvLanguages.AllowUserToDeleteRows = false;
            dgvLanguages.ReadOnly = true;

            dgvLanguages.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvLanguages.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLanguages.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvLanguages.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvLanguages.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvLanguages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLanguages.EnableHeadersVisualStyles = false;

            dgvLanguages.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLanguages.GridColor = Color.DarkGray;
            dgvLanguages.BackgroundColor = Color.LightSteelBlue;

            dgvLanguages.RowTemplate.Height = 30;
            dgvLanguages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void dgvLanguages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvLanguages.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                comboBox1.Text = dgvLanguages.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtLanCode.Text = dgvLanguages.Rows[e.RowIndex].Cells["LANCODE"].Value?.ToString() ?? string.Empty;
                txtLanText.Text = dgvLanguages.Rows[e.RowIndex].Cells["LANTEXT"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            comboBox1.SelectedIndex = -1; // Combobox'u temizle
            txtLanCode.Clear();
            txtLanText.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = comboBox1.SelectedValue?.ToString(); // Combobox'tan firma kodu alınıyor
            string lanCode = txtLanCode.Text;
            string lanText = txtLanText.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(lanCode))
            {
                MessageBox.Show("Firma Kodu ve Dil Kodu zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _dataAccessLayer.AddRecord(comCode, lanCode, lanText);
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
            if (dgvLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldLanCode = dgvLanguages.SelectedRows[0].Cells["LANCODE"].Value?.ToString();
            string comCode = comboBox1.SelectedValue?.ToString();
            string lanCode = txtLanCode.Text;
            string lanText = txtLanText.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(lanCode))
            {
                MessageBox.Show("Firma Kodu ve Dil Kodu zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldLanCode, comCode, lanCode, lanText);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string lanCode = dgvLanguages.SelectedRows[0].Cells["LANCODE"].Value?.ToString();

            try
            {
                _dataAccessLayer.DeleteRecord(comCode, lanCode);
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
    }
}
