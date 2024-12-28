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
            LoadData();
            CustomizeDataGridView();
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
                txtComCode.Text = dgvLanguages.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
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
            txtComCode.Clear();
            txtLanCode.Clear();
            txtLanText.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
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
            if (string.IsNullOrEmpty(txtLanCode.Text) || string.IsNullOrEmpty(txtLanText.Text))
            {
                MessageBox.Show("Dil Kodu ve Dil Metni zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string oldLanCode = dgvLanguages.SelectedRows[0].Cells["LANCODE"].Value?.ToString();
                string oldComCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string newComCode = txtComCode.Text;
                string newLanCode = txtLanCode.Text;
                string lanText = txtLanText.Text;

                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldLanCode, newComCode, newLanCode, lanText);

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

            try
            {
                string comCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string lanCode = dgvLanguages.SelectedRows[0].Cells["LANCODE"].Value?.ToString();

                if (!string.IsNullOrEmpty(comCode) && !string.IsNullOrEmpty(lanCode))
                {
                    _dataAccessLayer.DeleteRecord(comCode, lanCode);
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

        private void lblLanCode_Click(object sender, EventArgs e)
        {
            // Bu alana etiket tıklandığında yapılacak işlemleri yazabilirsiniz.
            MessageBox.Show("Dil Kodu etiketi tıklandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
