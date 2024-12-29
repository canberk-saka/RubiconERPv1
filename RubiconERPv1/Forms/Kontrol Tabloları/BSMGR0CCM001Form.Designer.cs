namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0CCM001Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCostCenters;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.TextBox txtDocTypeText;
        private System.Windows.Forms.CheckBox chkIsPassive;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDocTypeText;
        private System.Windows.Forms.Label lblIsPassive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCostCenters = new System.Windows.Forms.DataGridView();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.txtDocTypeText = new System.Windows.Forms.TextBox();
            this.chkIsPassive = new System.Windows.Forms.CheckBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDocTypeText = new System.Windows.Forms.Label();
            this.lblIsPassive = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostCenters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCostCenters
            // 
            this.dgvCostCenters.ColumnHeadersHeight = 29;
            this.dgvCostCenters.Location = new System.Drawing.Point(12, 12);
            this.dgvCostCenters.Name = "dgvCostCenters";
            this.dgvCostCenters.RowHeadersWidth = 51;
            this.dgvCostCenters.Size = new System.Drawing.Size(1056, 255);
            this.dgvCostCenters.TabIndex = 0;
            this.dgvCostCenters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostCenters_CellClick);
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(352, 341);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(200, 22);
            this.txtDocType.TabIndex = 2;
            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(352, 383);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(200, 22);
            this.txtDocTypeText.TabIndex = 3;
            // 
            // chkIsPassive
            // 
            this.chkIsPassive.Location = new System.Drawing.Point(750, 304);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(200, 22);
            this.chkIsPassive.TabIndex = 4;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(217, 306);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 1;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(217, 347);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(129, 16);
            this.lblDocType.TabIndex = 2;
            this.lblDocType.Text = "Maliyet Merkezi Tipi:";
            // 
            // lblDocTypeText
            // 
            this.lblDocTypeText.AutoSize = true;
            this.lblDocTypeText.Location = new System.Drawing.Point(217, 391);
            this.lblDocTypeText.Name = "lblDocTypeText";
            this.lblDocTypeText.Size = new System.Drawing.Size(99, 16);
            this.lblDocTypeText.TabIndex = 3;
            this.lblDocTypeText.Text = "Tip Açıklaması:";
            // 
            // lblIsPassive
            // 
            this.lblIsPassive.AutoSize = true;
            this.lblIsPassive.Location = new System.Drawing.Point(624, 306);
            this.lblIsPassive.Name = "lblIsPassive";
            this.lblIsPassive.Size = new System.Drawing.Size(61, 16);
            this.lblIsPassive.TabIndex = 4;
            this.lblIsPassive.Text = "Pasif mi?";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(347, 445);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(493, 445);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(661, 445);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(302, 306);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 9;
            // 
            // BSMGR0CCM001Form
            // 
            this.ClientSize = new System.Drawing.Size(1080, 577);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvCostCenters);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.txtDocType);
            this.Controls.Add(this.lblDocTypeText);
            this.Controls.Add(this.txtDocTypeText);
            this.Controls.Add(this.lblIsPassive);
            this.Controls.Add(this.chkIsPassive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Name = "BSMGR0CCM001Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maliyet Merkezi Tipi Formu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostCenters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
    }
}
