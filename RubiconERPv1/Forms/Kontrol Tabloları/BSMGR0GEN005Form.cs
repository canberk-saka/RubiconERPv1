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
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0GEN005DAL(connectionString);
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

            // Alternating Row Colors
            dgvUnits.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvUnits.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUnits.RowsDefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dgvUnits.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Header Style
            dgvUnits.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dgvUnits.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvUnits.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUnits.EnableHeadersVisualStyles = false;

            // Cell Alignment
            foreach (DataGridViewColumn column in dgvUnits.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Grid Lines
            dgvUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUnits.GridColor = Color.DarkGray;

            // Column Auto Resize
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Row Height
            dgvUnits.RowTemplate.Height = 30;

            // Background Color
            dgvUnits.BackgroundColor = Color.LightSteelBlue;

            // Docking for full resize
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

        private void ClearFields()
        {
            txtComCode.Clear();
            txtUnitCode.Clear();
            txtUnitText.Clear();
            chkIsMainUnit.Checked = false;
            txtMainUnitCode.Clear();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
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
            string newComCode = txtComCode.Text;
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
    }
}
