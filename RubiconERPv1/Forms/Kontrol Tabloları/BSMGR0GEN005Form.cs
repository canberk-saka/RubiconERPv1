using System;
using System.Data;
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
            LoadData();
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
