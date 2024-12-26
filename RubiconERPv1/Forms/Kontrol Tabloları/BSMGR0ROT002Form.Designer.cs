namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0ROT002Form
    {
        private System.ComponentModel.IContainer components = null;

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
            this.dgvCenters = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCenters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCenters
            // 
            this.dgvCenters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCenters.Location = new System.Drawing.Point(12, 1);
            this.dgvCenters.Name = "dgvCenters";
            this.dgvCenters.RowHeadersWidth = 51;
            this.dgvCenters.Size = new System.Drawing.Size(1068, 242);
            this.dgvCenters.TabIndex = 0;
            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(337, 397);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(150, 22);
            this.txtComCode.TabIndex = 1;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(683, 397);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(150, 22);
            this.txtDocType.TabIndex = 2;
            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(405, 468);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(150, 22);
            this.txtDocTypeText.TabIndex = 3;
            // 
            // chkIsPassive
            // 
            this.chkIsPassive.AutoSize = true;
            this.chkIsPassive.Location = new System.Drawing.Point(683, 470);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(83, 20);
            this.chkIsPassive.TabIndex = 4;
            this.chkIsPassive.Text = "Pasif mi?";
            this.chkIsPassive.UseVisualStyleBackColor = true;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(234, 400);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 5;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(545, 403);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(96, 16);
            this.lblDocType.TabIndex = 6;
            this.lblDocType.Text = "İş Merkezi Tipi:";
            // 
            // lblDocTypeText
            // 
            this.lblDocTypeText.AutoSize = true;
            this.lblDocTypeText.Location = new System.Drawing.Point(234, 474);
            this.lblDocTypeText.Name = "lblDocTypeText";
            this.lblDocTypeText.Size = new System.Drawing.Size(165, 16);
            this.lblDocTypeText.TabIndex = 7;
            this.lblDocTypeText.Text = "İş Merkezi Tipi Açıklaması:";
            // 
            // lblIsPassive
            // 
            this.lblIsPassive.AutoSize = true;
            this.lblIsPassive.Location = new System.Drawing.Point(596, 474);
            this.lblIsPassive.Name = "lblIsPassive";
            this.lblIsPassive.Size = new System.Drawing.Size(61, 16);
            this.lblIsPassive.TabIndex = 8;
            this.lblIsPassive.Text = "Pasif mi?";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(271, 583);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(405, 583);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(528, 583);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(683, 583);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BSMGR0ROT002Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 642);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblIsPassive);
            this.Controls.Add(this.lblDocTypeText);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.chkIsPassive);
            this.Controls.Add(this.txtDocTypeText);
            this.Controls.Add(this.txtDocType);
            this.Controls.Add(this.txtComCode);
            this.Controls.Add(this.dgvCenters);
            this.Name = "BSMGR0ROT002Form";
            this.Text = "BSMGR0ROT002 - İş Merkezi Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCenters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvCenters;
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
    }
}
