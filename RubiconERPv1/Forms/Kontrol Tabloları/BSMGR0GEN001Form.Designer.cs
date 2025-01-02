namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN001Form
    {
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.TextBox txtComText;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblComText;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblCityCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private void InitializeComponent()
        {
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.txtComCode = new System.Windows.Forms.TextBox();
            this.txtComText = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblComText = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCityCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Location = new System.Drawing.Point(1, 0);
            this.dgvCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.RowHeadersWidth = 51;
            this.dgvCompanies.Size = new System.Drawing.Size(1013, 246);
            this.dgvCompanies.TabIndex = 0;
            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(609, 295);
            this.txtComCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(265, 22);
            this.txtComCode.TabIndex = 1;
            // 
            // txtComText
            // 
            this.txtComText.Location = new System.Drawing.Point(144, 295);
            this.txtComText.Margin = new System.Windows.Forms.Padding(4);
            this.txtComText.Name = "txtComText";
            this.txtComText.Size = new System.Drawing.Size(265, 22);
            this.txtComText.TabIndex = 2;
            this.txtComText.TextChanged += new System.EventHandler(this.txtComText_TextChanged);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(144, 399);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(265, 22);
            this.txtAddress1.TabIndex = 3;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(144, 349);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(265, 22);
            this.txtAddress2.TabIndex = 4;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(499, 301);
            this.lblComCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 6;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblComText
            // 
            this.lblComText.AutoSize = true;
            this.lblComText.Location = new System.Drawing.Point(38, 301);
            this.lblComText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComText.Name = "lblComText";
            this.lblComText.Size = new System.Drawing.Size(67, 16);
            this.lblComText.TabIndex = 7;
            this.lblComText.Text = "Firma Adı:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(38, 402);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(86, 16);
            this.lblAddress1.TabIndex = 8;
            this.lblAddress1.Text = "Firma Adresi:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(38, 352);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(97, 16);
            this.lblAddress2.TabIndex = 9;
            this.lblAddress2.Text = "Firma Adresi-2:";
            // 
            // lblCityCode
            // 
            this.lblCityCode.AutoSize = true;
            this.lblCityCode.Location = new System.Drawing.Point(499, 349);
            this.lblCityCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(75, 16);
            this.lblCityCode.TabIndex = 10;
            this.lblCityCode.Text = "Şehir Kodu:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(42, 473);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 37);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(218, 473);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 37);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(409, 473);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 37);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(609, 473);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 37);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(609, 343);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(609, 399);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ülke kodu:";
            // 
            // BSMGR0GEN001Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCityCode);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lblComText);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtComText);
            this.Controls.Add(this.txtComCode);
            this.Controls.Add(this.dgvCompanies);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BSMGR0GEN001Form";
            this.Text = "BSMGR0GEN001Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
    }
}
