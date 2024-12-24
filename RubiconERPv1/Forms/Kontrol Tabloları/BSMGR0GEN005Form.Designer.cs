namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN005Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.TextBox txtUnitCode;
        private System.Windows.Forms.TextBox txtUnitText;
        private System.Windows.Forms.CheckBox chkIsMainUnit;
        private System.Windows.Forms.TextBox txtMainUnitCode;
        private System.Windows.Forms.Label lblComCode;
        private System.Windows.Forms.Label lblUnitCode;
        private System.Windows.Forms.Label lblUnitText;
        private System.Windows.Forms.Label lblIsMainUnit;
        private System.Windows.Forms.Label lblMainUnitCode;
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
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.txtComCode = new System.Windows.Forms.TextBox();
            this.txtUnitCode = new System.Windows.Forms.TextBox();
            this.txtUnitText = new System.Windows.Forms.TextBox();
            this.chkIsMainUnit = new System.Windows.Forms.CheckBox();
            this.txtMainUnitCode = new System.Windows.Forms.TextBox();
            this.lblComCode = new System.Windows.Forms.Label();
            this.lblUnitCode = new System.Windows.Forms.Label();
            this.lblUnitText = new System.Windows.Forms.Label();
            this.lblIsMainUnit = new System.Windows.Forms.Label();
            this.lblMainUnitCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvUnits
            // 
            this.dgvUnits.Location = new System.Drawing.Point(12, 12);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.Size = new System.Drawing.Size(760, 200);
            this.dgvUnits.TabIndex = 0;

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
            // lblUnitCode
            // 
            this.lblUnitCode.AutoSize = true;
            this.lblUnitCode.Location = new System.Drawing.Point(12, 265);
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.Size = new System.Drawing.Size(69, 16);
            this.lblUnitCode.Text = "Birim Kodu:";

            // 
            // txtUnitCode
            // 
            this.txtUnitCode.Location = new System.Drawing.Point(120, 262);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(200, 22);
            this.txtUnitCode.TabIndex = 2;

            // 
            // lblUnitText
            // 
            this.lblUnitText.AutoSize = true;
            this.lblUnitText.Location = new System.Drawing.Point(12, 300);
            this.lblUnitText.Name = "lblUnitText";
            this.lblUnitText.Size = new System.Drawing.Size(58, 16);
            this.lblUnitText.Text = "Birim Adı:";

            // 
            // txtUnitText
            // 
            this.txtUnitText.Location = new System.Drawing.Point(120, 297);
            this.txtUnitText.Name = "txtUnitText";
            this.txtUnitText.Size = new System.Drawing.Size(200, 22);
            this.txtUnitText.TabIndex = 3;

            // 
            // lblIsMainUnit
            // 
            this.lblIsMainUnit.AutoSize = true;
            this.lblIsMainUnit.Location = new System.Drawing.Point(12, 335);
            this.lblIsMainUnit.Name = "lblIsMainUnit";
            this.lblIsMainUnit.Size = new System.Drawing.Size(105, 16);
            this.lblIsMainUnit.Text = "Ana Ağırlık Birimi:";

            // 
            // chkIsMainUnit
            // 
            this.chkIsMainUnit.Location = new System.Drawing.Point(120, 332);
            this.chkIsMainUnit.Name = "chkIsMainUnit";
            this.chkIsMainUnit.Size = new System.Drawing.Size(200, 22);
            this.chkIsMainUnit.TabIndex = 4;

            // 
            // lblMainUnitCode
            // 
            this.lblMainUnitCode.AutoSize = true;
            this.lblMainUnitCode.Location = new System.Drawing.Point(12, 370);
            this.lblMainUnitCode.Name = "lblMainUnitCode";
            this.lblMainUnitCode.Size = new System.Drawing.Size(95, 16);
            this.lblMainUnitCode.Text = "Ana Birim Kodu:";

            // 
            // txtMainUnitCode
            // 
            this.txtMainUnitCode.Location = new System.Drawing.Point(120, 367);
            this.txtMainUnitCode.Name = "txtMainUnitCode";
            this.txtMainUnitCode.Size = new System.Drawing.Size(200, 22);
            this.txtMainUnitCode.TabIndex = 5;

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
            // BSMGR0GEN005Form
            // 
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.lblComCode);
            this.Controls.Add(this.txtComCode);
            this.Controls.Add(this.lblUnitCode);
            this.Controls.Add(this.txtUnitCode);
            this.Controls.Add(this.lblUnitText);
            this.Controls.Add(this.txtUnitText);
            this.Controls.Add(this.lblIsMainUnit);
            this.Controls.Add(this.chkIsMainUnit);
            this.Controls.Add(this.lblMainUnitCode);
            this.Controls.Add(this.txtMainUnitCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Name = "BSMGR0GEN005Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birim Kontrol Formu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
