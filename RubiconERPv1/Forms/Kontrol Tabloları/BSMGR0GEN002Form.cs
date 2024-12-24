using System;
using System.Data;
using System.Data.SqlClient;
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
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0GEN002DAL(connectionString);
            dgvLanguages.CellClick += dgvLanguages_CellClick;
            LoadData();
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

            _dataAccessLayer.AddRecord(comCode, lanCode, lanText);
            MessageBox.Show("Kıyayt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearFields();
        }

        // btnUpdate_Click metodu düzenlendi
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLanCode.Text) || string.IsNullOrEmpty(txtLanText.Text))
            {
                MessageBox.Show("Dil Kodu ve Dil Metni zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string oldLanCode = dgvLanguages.SelectedRows[0].Cells["LANCODE"].Value?.ToString(); // Eski dil kodu
                string oldComCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString(); // Eski firma kodu
                string newComCode = txtComCode.Text;  // Yeni firma kodu
                string newLanCode = txtLanCode.Text;  // Yeni dil kodu
                string lanText = txtLanText.Text;     // Dil metni

                // UpdateRecord metodu eksiksiz parametrelerle çağrılıyor
                bool result = _dataAccessLayer.UpdateRecord(oldComCode, oldLanCode, newComCode, newLanCode, lanText);

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
            if (dgvLanguages.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string comCode = dgvLanguages.SelectedRows[0].Cells["COMCODE"].Value?.ToString();
                string lanCode = dgvLanguages.SelectedRows[0].Cells["LANGCODE"].Value?.ToString();

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
    }
}
