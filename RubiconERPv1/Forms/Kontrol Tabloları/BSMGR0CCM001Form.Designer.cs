namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0CCM001Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCostCenters;
        private System.Windows.Forms.TextBox txtComCode;
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
            this.txtComCode = new System.Windows.Forms.TextBox();
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

            ((System.ComponentModel.ISupportInitialize)(this.dgvCostCenters)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvCostCenters
            // 
            this.dgvCostCenters.Location = new System.Drawing.Point(12, 12);
            this.dgvCostCenters.Name = "dgvCostCenters";
            this.dgvCostCenters.Size = new System.Drawing.Size(760, 200);
            this.dgvCostCenters.TabIndex = 0;
            this.dgvCostCenters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostCenters_CellClick);

            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(12, 230);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(74, 16);
            this.lblComCode.Text = "Firma Kodu:";

            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(120, 227);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(200, 22);
            this.txtComCode.TabIndex = 1;

            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 265);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(106, 16);
            this.lblDocType.Text = "Maliyet Merkezi Tipi:";

            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(120, 262);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(200, 22);
            this.txtDocType.TabIndex = 2;

            // 
            // lblDocTypeText
            // 
            this.lblDocTypeText.AutoSize = true;
            this.lblDocTypeText.Location = new System.Drawing.Point(12, 300);
            this.lblDocTypeText.Name = "lblDocTypeText";
            this.lblDocTypeText.Size = new System.Drawing.Size(106, 16);
            this.lblDocTypeText.Text = "Tip Açıklaması:";

            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(120, 297);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(200, 22);
            this.txtDocTypeText.TabIndex = 3;

            // 
            // lblIsPassive
            // 
            this.lblIsPassive.AutoSize = true;
            this.lblIsPassive.Location = new System.Drawing.Point(12, 335);
            this.lblIsPassive.Name = "lblIsPassive";
            this.lblIsPassive.Size = new System.Drawing.Size(50, 16);
            this.lblIsPassive.Text = "Pasif mi?";

            // 
            // chkIsPassive
            // 
            this.chkIsPassive.Location = new System.Drawing.Point(120, 332);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(200, 22);
            this.chkIsPassive.TabIndex = 4;

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(400, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(400, 265);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(400, 300);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(400, 335);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // BSMGR0CCM001Form
            // 
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.dgvCostCenters);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtComCode);
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
    }
}
