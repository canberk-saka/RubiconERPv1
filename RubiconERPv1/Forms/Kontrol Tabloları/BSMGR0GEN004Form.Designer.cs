namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN004Form
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
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.txtCityCode = new System.Windows.Forms.TextBox();
            this.txtCityText = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblCityCode = new System.Windows.Forms.Label();
            this.lblCityText = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCountryCode = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCities
            // 
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.Location = new System.Drawing.Point(12, 12);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.RowHeadersWidth = 51;
            this.dgvCities.Size = new System.Drawing.Size(1055, 364);
            this.dgvCities.TabIndex = 0;
            // 
            // txtCityCode
            // 
            this.txtCityCode.Location = new System.Drawing.Point(406, 446);
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(150, 22);
            this.txtCityCode.TabIndex = 3;
            // 
            // txtCityText
            // 
            this.txtCityText.Location = new System.Drawing.Point(406, 486);
            this.txtCityText.Name = "txtCityText";
            this.txtCityText.Size = new System.Drawing.Size(150, 22);
            this.txtCityText.TabIndex = 4;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(71, 449);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 5;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblCityCode
            // 
            this.lblCityCode.AutoSize = true;
            this.lblCityCode.Location = new System.Drawing.Point(325, 452);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(75, 16);
            this.lblCityCode.TabIndex = 7;
            this.lblCityCode.Text = "Şehir Kodu:";
            // 
            // lblCityText
            // 
            this.lblCityText.AutoSize = true;
            this.lblCityText.Location = new System.Drawing.Point(325, 489);
            this.lblCityText.Name = "lblCityText";
            this.lblCityText.Size = new System.Drawing.Size(64, 16);
            this.lblCityText.TabIndex = 8;
            this.lblCityText.Text = "Şehir Adı:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(74, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(205, 524);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(328, 524);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(456, 524);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.Location = new System.Drawing.Point(71, 489);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(72, 16);
            this.lblCountryCode.TabIndex = 6;
            this.lblCountryCode.Text = "Ülke Kodu:";
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(165, 441);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.AccessibleName = "comboBox2";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(165, 486);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 14;
            // 
            // BSMGR0GEN004Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 598);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCityText);
            this.Controls.Add(this.lblCityCode);
            this.Controls.Add(this.lblCountryCode);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtCityText);
            this.Controls.Add(this.txtCityCode);
            this.Controls.Add(this.dgvCities);
            this.Name = "BSMGR0GEN004Form";
            this.Text = "BSMGR0GEN004 - Şehir Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.TextBox txtCityCode;
        private System.Windows.Forms.TextBox txtCityText;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblCityCode;
        private System.Windows.Forms.Label lblCityText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCountryCode;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
