namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0ROT001Form
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
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutes.Location = new System.Drawing.Point(12, 12);
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.RowHeadersWidth = 51;
            this.dgvRoutes.Size = new System.Drawing.Size(980, 233);
            this.dgvRoutes.TabIndex = 0;
            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(299, 429);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(150, 22);
            this.txtComCode.TabIndex = 1;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(580, 429);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(150, 22);
            this.txtDocType.TabIndex = 2;
            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(367, 472);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(150, 22);
            this.txtDocTypeText.TabIndex = 3;
            // 
            // chkIsPassive
            // 
            this.chkIsPassive.AutoSize = true;
            this.chkIsPassive.Location = new System.Drawing.Point(652, 479);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(18, 17);
            this.chkIsPassive.TabIndex = 4;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(215, 432);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 5;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(483, 432);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(65, 16);
            this.lblDocType.TabIndex = 6;
            this.lblDocType.Text = "Rota Tipi:";
            // 
            // lblDocTypeText
            // 
            this.lblDocTypeText.AutoSize = true;
            this.lblDocTypeText.Location = new System.Drawing.Point(215, 478);
            this.lblDocTypeText.Name = "lblDocTypeText";
            this.lblDocTypeText.Size = new System.Drawing.Size(134, 16);
            this.lblDocTypeText.TabIndex = 7;
            this.lblDocTypeText.Text = "Rota Tipi Açıklaması:";
            // 
            // lblIsPassive
            // 
            this.lblIsPassive.AutoSize = true;
            this.lblIsPassive.Location = new System.Drawing.Point(543, 478);
            this.lblIsPassive.Name = "lblIsPassive";
            this.lblIsPassive.Size = new System.Drawing.Size(61, 16);
            this.lblIsPassive.TabIndex = 8;
            this.lblIsPassive.Text = "Pasif mi?";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(341, 585);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(486, 585);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(630, 585);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BSMGR0ROT001Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 627);
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
            this.Controls.Add(this.dgvRoutes);
            this.Name = "BSMGR0ROT001Form";
            this.Text = "BSMGR0ROT001 - Rota Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvRoutes;
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
