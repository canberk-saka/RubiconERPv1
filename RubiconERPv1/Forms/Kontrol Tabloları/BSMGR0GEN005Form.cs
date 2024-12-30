using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0GEN005Form : Form
    {
        private BSMGR0GEN005DAL _dataAccessLayer;

        public BSMGR0GEN005Form()
        {
            InitializeComponent();
            string connectionString = DbConnection.GetConnectionString();
            _dataAccessLayer = new BSMGR0GEN005DAL(connectionString);

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            LoadComboBox();
            LoadData();
            CustomizeDataGridView();
        }
        


        private void CustomizeDataGridView()
        {
            dgvUnits.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvUnits.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUnits.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            dgvUnits.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnits.MultiSelect = false;
            dgvUnits.AllowUserToAddRows = false;
            dgvUnits.AllowUserToDeleteRows = false;
            dgvUnits.ReadOnly = true;

            dgvUnits.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvUnits.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUnits.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvUnits.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvUnits.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvUnits.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvUnits.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUnits.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgvUnits.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUnits.GridColor = Color.DarkGray;
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnits.RowTemplate.Height = 30;
            dgvUnits.BackgroundColor = Color.LightSteelBlue;
            dgvUnits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void LoadData()
        {
            try
            {
                DataTable dtUnits = _dataAccessLayer.GetAllRecords();
                dgvUnits.DataSource = dtUnits;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBox()
        {
            try
            {
                DataTable dtCompanies = _dataAccessLayer.GetCompanyCodes();
                comboBox1.DataSource = dtCompanies;
                comboBox1.DisplayMember = "COMCODE"; // Görüntülenecek sütun
                comboBox1.ValueMember = "COMCODE";   // Değer olarak kullanılacak sütun
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma kodları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnitCode.Clear();
            txtUnitText.Clear();
            txtMainUnitCode.Clear();
            chkIsMainUnit.Checked = false;
        }

        private void ClearFields()
        {
            comboBox1.SelectedIndex = -1;
            txtUnitCode.Clear();
            txtUnitText.Clear();
            chkIsMainUnit.Checked = false;
            txtMainUnitCode.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = comboBox1.SelectedValue?.ToString();
            string unitCode = txtUnitCode.Text;
            string unitText = txtUnitText.Text;
            int isMainUnit = chkIsMainUnit.Checked ? 1 : 0;
            string mainUnitCode = txtMainUnitCode.Text;

            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(unitCode))
            {
                MessageBox.Show("Firma Kodu ve Birim Kodu zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _dataAccessLayer.AddRecord(comCode, unitCode, unitText, isMainUnit, mainUnitCode);
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
            if (dgvUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldComCode = dgvUnits.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
            string oldUnitCode = dgvUnits.SelectedRows[0].Cells["UNITCODE"].Value?.ToString();
            string newComCode = comboBox1.SelectedValue?.ToString();
            string newUnitCode = txtUnitCode.Text;
            string unitText = txtUnitText.Text;
            int isMainUnit = chkIsMainUnit.Checked ? 1 : 0;
            string mainUnitCode = txtMainUnitCode.Text;

            try
            {
                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldUnitCode, newComCode, newUnitCode, unitText, isMainUnit, mainUnitCode);

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
        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvUnits.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                comboBox1.SelectedValue = dgvUnits.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString();
                txtUnitCode.Text = dgvUnits.Rows[e.RowIndex].Cells["UNITCODE"].Value?.ToString() ?? string.Empty;
                txtUnitText.Text = dgvUnits.Rows[e.RowIndex].Cells["UNITTEXT"].Value?.ToString() ?? string.Empty;
                txtMainUnitCode.Text = dgvUnits.Rows[e.RowIndex].Cells["MAINUNITCODE"].Value?.ToString() ?? string.Empty;
                chkIsMainUnit.Checked = dgvUnits.Rows[e.RowIndex].Cells["ISMAINUNIT"].Value?.ToString() == "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string comCode = dgvUnits.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string unitCode = dgvUnits.SelectedRows[0].Cells["UNITCODE"].Value?.ToString();

                _dataAccessLayer.DeleteRecord(comCode, unitCode);
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

        private void BSMGR0GEN005Form_Load(object sender, EventArgs e)
        {
            dgvUnits.CellClick += dgvUnits_CellClick; // DataGridView'e tıklama olayı ekle
        }
    }
}
