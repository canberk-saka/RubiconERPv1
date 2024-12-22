using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer; // DAL sınıfı buradan erişilecek

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class MalzemeBilgileriForm : Form
    {
        private readonly BSMGR0MATHEADDAL _dal;

        public MalzemeBilgileriForm()
        {
            InitializeComponent();

            // Bağlantı stringini veritabanınıza uygun olarak değiştirin
            string connectionString = "Data Source=EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";
            _dal = new BSMGR0MATHEADDAL(connectionString);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dataTable = _dal.GetAllRecords();
                dgvMalzeme.DataSource = dataTable; // DataGridView kontrolüne bağla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcıdan alınan veriler
                string comCode = txtComCode.Text;
                string matDocType = cbMatDocType.Text;
                string matDocNum = txtMatDocNum.Text;
                DateTime matDocFrom = dtpMatDocFrom.Value;
                DateTime matDocUntil = dtpMatDocUntil.Value;
                int supplyType = int.Parse(txtSupplyType.Text);
                string stUnit = txtStUnit.Text;
                decimal netWeight = decimal.Parse(txtNetWeight.Text);
                string nwUnit = txtNwUnit.Text;
                decimal brutWeight = decimal.Parse(txtBrutWeight.Text);
                string bwUnit = txtBwUnit.Text;
                int isBom = chkIsBom.Checked ? 1 : 0;
                string bomDocType = txtBomDocType.Text;
                string bomDocNum = txtBomDocNum.Text;
                int isRoute = chkIsRoute.Checked ? 1 : 0;
                string rotDocType = txtRotDocType.Text;
                string rotDocNum = txtRotDocNum.Text;
                int isDeleted = chkIsDeleted.Checked ? 1 : 0;
                int isPassive = chkIsPassive.Checked ? 1 : 0;

                // Yeni kayıt ekle
                _dal.AddRecord(comCode, matDocType, matDocNum, matDocFrom, matDocUntil, supplyType, stUnit, netWeight, nwUnit, brutWeight, bwUnit, isBom, bomDocType, bomDocNum, isRoute, rotDocType, rotDocNum, isDeleted, isPassive);

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string oldMatDocNum = txtOldMatDocNum.Text; // Güncellenecek eski MATDOCNUM
        //        string comCode = txtComCode.Text;
        //        string matDocType = cbMatDocType.Text;
        //        string matDocNum = txtMatDocNum.Text;
        //        DateTime matDocFrom = dtpMatDocFrom.Value;
        //        DateTime matDocUntil = dtpMatDocUntil.Value;
        //        int supplyType = int.Parse(txtSupplyType.Text);
        //        string stUnit = txtStUnit.Text;
        //        decimal netWeight = decimal.Parse(txtNetWeight.Text);
        //        string nwUnit = txtNwUnit.Text;
        //        decimal brutWeight = decimal.Parse(txtBrutWeight.Text);
        //        string bwUnit = txtBwUnit.Text;
        //        int isBom = chkIsBom.Checked ? 1 : 0;
        //        string bomDocType = txtBomDocType.Text;
        //        string bomDocNum = txtBomDocNum.Text;
        //        int isRoute = chkIsRoute.Checked ? 1 : 0;
        //        string rotDocType = txtRotDocType.Text;
        //        string rotDocNum = txtRotDocNum.Text;
        //        int isDeleted = chkIsDeleted.Checked ? 1 : 0;
        //        int isPassive = chkIsPassive.Checked ? 1 : 0;

        //        // Kayıt güncelle
        //        bool success = _dal.UpdateRecord(oldMatDocNum, comCode, matDocType, matDocNum, matDocFrom, matDocUntil, supplyType, stUnit, netWeight, nwUnit, brutWeight, bwUnit, isBom, bomDocType, bomDocNum, isRoute, rotDocType, rotDocNum, isDeleted, isPassive);

        //        if (success)
        //        {
        //            MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Kayıt bulunamadı veya güncellenemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Kayıt güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string matDocNum = txtMatDocNum.Text;

                // Kayıt sil
                _dal.DeleteRecord(matDocNum);

                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırdaki verileri doldur
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMalzeme.Rows[e.RowIndex];

                txtComCode.Text = row.Cells["COMCODE"].Value.ToString();
                cbMatDocType.Text = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMatDocNum.Text = row.Cells["MATDOCNUM"].Value.ToString();
                dtpMatDocFrom.Value = Convert.ToDateTime(row.Cells["MATDOCFROM"].Value);
                dtpMatDocUntil.Value = Convert.ToDateTime(row.Cells["MATDOCUNTIL"].Value);
                txtSupplyType.Text = row.Cells["SUPPLYTYPE"].Value.ToString();
                txtStUnit.Text = row.Cells["STUNIT"].Value.ToString();
                txtNetWeight.Text = row.Cells["NETWEIGHT"].Value.ToString();
                txtNwUnit.Text = row.Cells["NWUNIT"].Value.ToString();
                txtBrutWeight.Text = row.Cells["BRUTWEIGHT"].Value.ToString();
                txtBwUnit.Text = row.Cells["BWUNIT"].Value.ToString();
                chkIsBom.Checked = Convert.ToBoolean(row.Cells["ISBOM"].Value);
                txtBomDocType.Text = row.Cells["BOMDOCTYPE"].Value.ToString();
                txtBomDocNum.Text = row.Cells["BOMDOCNUM"].Value.ToString();
                chkIsRoute.Checked = Convert.ToBoolean(row.Cells["ISROUTE"].Value);
                txtRotDocType.Text = row.Cells["ROTDOCTYPE"].Value.ToString();
                txtRotDocNum.Text = row.Cells["ROTDOCNUM"].Value.ToString();
                chkIsDeleted.Checked = Convert.ToBoolean(row.Cells["ISDELETED"].Value);
                chkIsPassive.Checked = Convert.ToBoolean(row.Cells["ISPASSIVE"].Value);

                //txtOldMatDocNum.Text = txtMatDocNum.Text; // Güncelleme için eski numara saklanır
            }
        }
    }
}
