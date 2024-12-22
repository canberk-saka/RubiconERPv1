using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    public partial class BSMGR0MAT001Form : Form
    {
        private BSMGR0MAT001DAL _dataAccessLayer;

        public BSMGR0MAT001Form()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-BAP4RDU\\SQLEXPRESS02;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dataAccessLayer = new BSMGR0MAT001DAL(connectionString);
            dgvMaterials.CellClick += dgvMaterials_CellClick;
            cbIsPassive.Items.AddRange(new string[] { "0 - Hayır", "1 - Evet" });
            LoadData();
        }
        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMaterials.Rows.Count <= e.RowIndex)
            {
                MessageBox.Show("Geçersiz satır seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtComCode.Text = dgvMaterials.Rows[e.RowIndex].Cells["COMCODE"].Value?.ToString() ?? string.Empty;
                txtDocType.Text = dgvMaterials.Rows[e.RowIndex].Cells["DOCTYPE"].Value?.ToString() ?? string.Empty;
                txtDocTypeText.Text = dgvMaterials.Rows[e.RowIndex].Cells["DOCTYPETEXT"].Value?.ToString() ?? string.Empty;
                cbIsPassive.Text = (dgvMaterials.Rows[e.RowIndex].Cells["ISPASSIVE"].Value?.ToString() == "True") ? "1 - Evet" : "0 - Hayır";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satır verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtComCode.Clear();
            txtDocType.Clear(); 
            txtDocTypeText.Clear();
            cbIsPassive.SelectedIndex = -1;
        }

        private void LoadData()
        {
            try
            {
                DataTable dtMaterials = _dataAccessLayer.GetAllRecords();
                dgvMaterials.DataSource = dtMaterials;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string comCode = txtComCode.Text;
            string docType = txtDocType.Text; // Changed to TextBox value
            string docTypeText = txtDocTypeText.Text;
            bool isPassive = cbIsPassive.Text == "1 - Evet";

            // Firma kodu ve malzeme tipi zorunlu alan kontrolü
            if (string.IsNullOrEmpty(comCode) || string.IsNullOrEmpty(docType))
            {
                MessageBox.Show("Firma Kodu ve Malzeme Tipi zorunludur!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Firma kodu kontrolü
            if (!_dataAccessLayer.CheckIfCompanyCodeExists(comCode))
            {
                MessageBox.Show("Girilen Firma Kodu veri tabanında bulunamadı! Lütfen geçerli bir Firma Kodu girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kayıt ekleme işlemi
            _dataAccessLayer.AddRecord(comCode, docType, docTypeText, isPassive);
            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Verileri yeniden yükle ve alanları temizle
            LoadData();
            ClearFields();
        }


        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocTypeText.Text))
            {
                MessageBox.Show("Malzeme Açıklaması zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvMaterials.SelectedRows.Count == 0)  // Seçili satır yoksa uyarı ver
            {
                MessageBox.Show("Lütfen güncellemek için bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // DataGridView'deki seçili satırdan eski COMCODE ve DOCTYPE değerlerini alıyoruz
                string oldComCode = dgvMaterials.SelectedRows[0].Cells["COMCODE"].Value.ToString(); // COMCODE hücresindeki değeri al
                string oldDocType = dgvMaterials.SelectedRows[0].Cells["DOCTYPE"].Value.ToString(); // DOCTYPE hücresindeki değeri al

                // Yeni değerleri TextBox ve ComboBox'lardan alıyoruz
                string comCode = txtComCode.Text;
                string docType = txtDocType.Text;
                string docTypeText = txtDocTypeText.Text;
                bool isPassive = cbIsPassive.Text == "1 - Evet";

                bool updateSuccess = _dataAccessLayer.UpdateRecord(oldComCode, oldDocType, comCode, docType, docTypeText, isPassive);

                if (updateSuccess)
                {
                    MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();  // Verileri tekrar yükle
                    ClearFields();  // Alanları temizle
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu. Girilen bilgileri kontrol edin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Veritabanı hatası oluştu: {sqlEx.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string docType = dgvMaterials.SelectedRows[0].Cells["DOCTYPE"].Value?.ToString();
                if (!string.IsNullOrEmpty(docType))
                {
                    _dataAccessLayer.DeleteRecord(docType);
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
