namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN002Form
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvLanguages = new System.Windows.Forms.DataGridView();
            this.txtLanCode = new System.Windows.Forms.TextBox();
            this.txtLanText = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblLanCode = new System.Windows.Forms.Label();
            this.lblLanText = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguages.Location = new System.Drawing.Point(12, 12);
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.RowHeadersWidth = 51;
            this.dgvLanguages.Size = new System.Drawing.Size(913, 223);
            this.dgvLanguages.TabIndex = 0;
            // 
            // txtLanCode
            // 
            this.txtLanCode.Location = new System.Drawing.Point(110, 301);
            this.txtLanCode.Name = "txtLanCode";
            this.txtLanCode.Size = new System.Drawing.Size(200, 22);
            this.txtLanCode.TabIndex = 2;
            // 
            // txtLanText
            // 
            this.txtLanText.Location = new System.Drawing.Point(110, 337);
            this.txtLanText.Name = "txtLanText";
            this.txtLanText.Size = new System.Drawing.Size(200, 22);
            this.txtLanText.TabIndex = 3;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(20, 271);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 4;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblLanCode
            // 
            this.lblLanCode.AutoSize = true;
            this.lblLanCode.Location = new System.Drawing.Point(20, 304);
            this.lblLanCode.Name = "lblLanCode";
            this.lblLanCode.Size = new System.Drawing.Size(60, 16);
            this.lblLanCode.TabIndex = 5;
            this.lblLanCode.Text = "Dil Kodu:";
            // 
            // lblLanText
            // 
            this.lblLanText.AutoSize = true;
            this.lblLanText.Location = new System.Drawing.Point(20, 343);
            this.lblLanText.Name = "lblLanText";
            this.lblLanText.Size = new System.Drawing.Size(61, 16);
            this.lblLanText.TabIndex = 6;
            this.lblLanText.Text = "Dil Metni:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(225, 406);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 45);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(335, 406);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 45);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(460, 406);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 45);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(133, 263);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 11;
            // 
            // BSMGR0GEN002Form
            // 
            this.ClientSize = new System.Drawing.Size(937, 566);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLanText);
            this.Controls.Add(this.lblLanCode);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtLanText);
            this.Controls.Add(this.txtLanCode);
            this.Controls.Add(this.dgvLanguages);
            this.Name = "BSMGR0GEN002Form";
            this.Text = "BSMGR0GEN002Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLanguages;
        private System.Windows.Forms.TextBox txtLanCode;
        private System.Windows.Forms.TextBox txtLanText;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblLanCode;
        private System.Windows.Forms.Label lblLanText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}
