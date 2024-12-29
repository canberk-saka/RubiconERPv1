namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0ROT003Form
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
            this.dgvOperations = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOperations
            // 
            this.dgvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperations.Location = new System.Drawing.Point(12, 12);
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.RowHeadersWidth = 51;
            this.dgvOperations.Size = new System.Drawing.Size(1255, 244);
            this.dgvOperations.TabIndex = 0;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(765, 424);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(150, 22);
            this.txtDocType.TabIndex = 2;
            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(495, 483);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(150, 22);
            this.txtDocTypeText.TabIndex = 3;
            // 
            // chkIsPassive
            // 
            this.chkIsPassive.AutoSize = true;
            this.chkIsPassive.Location = new System.Drawing.Point(821, 489);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(18, 17);
            this.chkIsPassive.TabIndex = 4;
            this.chkIsPassive.UseVisualStyleBackColor = true;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(308, 430);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 5;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(645, 430);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(103, 16);
            this.lblDocType.TabIndex = 6;
            this.lblDocType.Text = "Operasyon Tipi:";
            // 
            // lblDocTypeText
            // 
            this.lblDocTypeText.AutoSize = true;
            this.lblDocTypeText.Location = new System.Drawing.Point(308, 486);
            this.lblDocTypeText.Name = "lblDocTypeText";
            this.lblDocTypeText.Size = new System.Drawing.Size(172, 16);
            this.lblDocTypeText.TabIndex = 7;
            this.lblDocTypeText.Text = "Operasyon Tipi Açıklaması:";
            // 
            // lblIsPassive
            // 
            this.lblIsPassive.AutoSize = true;
            this.lblIsPassive.Location = new System.Drawing.Point(747, 486);
            this.lblIsPassive.Name = "lblIsPassive";
            this.lblIsPassive.Size = new System.Drawing.Size(61, 16);
            this.lblIsPassive.TabIndex = 8;
            this.lblIsPassive.Text = "Pasif mi?";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 597);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(429, 597);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(583, 597);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(750, 597);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(392, 427);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // BSMGR0ROT003Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 697);
            this.Controls.Add(this.comboBox1);
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
            this.Controls.Add(this.dgvOperations);
            this.Name = "BSMGR0ROT003Form";
            this.Text = "BSMGR0ROT003 - Operasyon Tipi Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvOperations;
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
