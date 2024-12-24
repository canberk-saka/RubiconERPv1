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
            this.txtComCode = new System.Windows.Forms.TextBox();
            this.txtCityCode = new System.Windows.Forms.TextBox();
            this.txtCityText = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblCityCode = new System.Windows.Forms.Label();
            this.lblCityText = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.SuspendLayout();

            // dgvCities
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.Location = new System.Drawing.Point(12, 12);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.Size = new System.Drawing.Size(600, 200);
            this.dgvCities.TabIndex = 0;

            // txtComCode
            this.txtComCode.Location = new System.Drawing.Point(120, 230);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(150, 22);
            this.txtComCode.TabIndex = 1;

            // txtCityCode
            this.txtCityCode.Location = new System.Drawing.Point(120, 270);
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(150, 22);
            this.txtCityCode.TabIndex = 2;

            // txtCityText
            this.txtCityText.Location = new System.Drawing.Point(120, 310);
            this.txtCityText.Name = "txtCityText";
            this.txtCityText.Size = new System.Drawing.Size(150, 22);
            this.txtCityText.TabIndex = 3;

            // lblComCode
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(12, 233);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(83, 16);
            this.lblComCode.TabIndex = 4;
            this.lblComCode.Text = "Firma Kodu:";

            // lblCityCode
            this.lblCityCode.AutoSize = true;
            this.lblCityCode.Location = new System.Drawing.Point(12, 273);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(74, 16);
            this.lblCityCode.TabIndex = 5;
            this.lblCityCode.Text = "Şehir Kodu:";

            // lblCityText
            this.lblCityText.AutoSize = true;
            this.lblCityText.Location = new System.Drawing.Point(12, 313);
            this.lblCityText.Name = "lblCityText";
            this.lblCityText.Size = new System.Drawing.Size(64, 16);
            this.lblCityText.TabIndex = 6;
            this.lblCityText.Text = "Şehir Adı:";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(300, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(300, 270);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(300, 310);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(420, 230);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // BSMGR0GEN004Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCityText);
            this.Controls.Add(this.lblCityCode);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtCityText);
            this.Controls.Add(this.txtCityCode);
            this.Controls.Add(this.txtComCode);
            this.Controls.Add(this.dgvCities);
            this.Name = "BSMGR0GEN004Form";
            this.Text = "BSMGR0GEN004 - Şehir Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.TextBox txtCityCode;
        private System.Windows.Forms.TextBox txtCityText;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblCityCode;
        private System.Windows.Forms.Label lblCityText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}
