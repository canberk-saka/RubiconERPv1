namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN001Form
    {
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.TextBox txtComText;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCityCode;
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
            this.txtCityCode = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblComText = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCityCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvCompanies
            // 
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Location = new System.Drawing.Point(12, 200);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.Size = new System.Drawing.Size(760, 200);
            this.dgvCompanies.TabIndex = 0;

            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(100, 20);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(200, 20);
            this.txtComCode.TabIndex = 1;

            // 
            // txtComText
            // 
            this.txtComText.Location = new System.Drawing.Point(100, 50);
            this.txtComText.Name = "txtComText";
            this.txtComText.Size = new System.Drawing.Size(200, 20);
            this.txtComText.TabIndex = 2;

            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(100, 80);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(200, 20);
            this.txtAddress1.TabIndex = 3;

            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(100, 110);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(200, 20);
            this.txtAddress2.TabIndex = 4;

            // 
            // txtCityCode
            // 
            this.txtCityCode.Location = new System.Drawing.Point(100, 140);
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(200, 20);
            this.txtCityCode.TabIndex = 5;

            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(20, 23);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(74, 13);
            this.lblComCode.TabIndex = 6;
            this.lblComCode.Text = "Firma Kodu:";

            // 
            // lblComText
            // 
            this.lblComText.AutoSize = true;
            this.lblComText.Location = new System.Drawing.Point(20, 53);
            this.lblComText.Name = "lblComText";
            this.lblComText.Size = new System.Drawing.Size(65, 13);
            this.lblComText.TabIndex = 7;
            this.lblComText.Text = "Firma Adı:";

            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(20, 83);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(74, 13);
            this.lblAddress1.TabIndex = 8;
            this.lblAddress1.Text = "Firma Adresi:";

            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(20, 113);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(81, 13);
            this.lblAddress2.TabIndex = 9;
            this.lblAddress2.Text = "Firma Adresi-2:";

            // 
            // lblCityCode
            // 
            this.lblCityCode.AutoSize = true;
            this.lblCityCode.Location = new System.Drawing.Point(20, 143);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(62, 13);
            this.lblCityCode.TabIndex = 10;
            this.lblCityCode.Text = "Şehir Kodu:";

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(350, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(350, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(350, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // BSMGR0GEN001Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCityCode);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lblComText);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtCityCode);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtComText);
            this.Controls.Add(this.txtComCode);
            this.Controls.Add(this.dgvCompanies);
            this.Name = "BSMGR0GEN001Form";
            this.Text = "BSMGR0GEN001Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
