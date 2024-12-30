namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0GEN005Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUnits;
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUnits
            // 
            this.dgvUnits.ColumnHeadersHeight = 29;
            this.dgvUnits.Location = new System.Drawing.Point(12, 12);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.RowHeadersWidth = 51;
            this.dgvUnits.Size = new System.Drawing.Size(1043, 244);
            this.dgvUnits.TabIndex = 0;
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.Location = new System.Drawing.Point(576, 477);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(200, 22);
            this.txtUnitCode.TabIndex = 2;
            // 
            // txtUnitText
            // 
            this.txtUnitText.Location = new System.Drawing.Point(222, 480);
            this.txtUnitText.Name = "txtUnitText";
            this.txtUnitText.Size = new System.Drawing.Size(200, 22);
            this.txtUnitText.TabIndex = 3;
            // 
            // chkIsMainUnit
            // 
            this.chkIsMainUnit.Location = new System.Drawing.Point(598, 560);
            this.chkIsMainUnit.Name = "chkIsMainUnit";
            this.chkIsMainUnit.Size = new System.Drawing.Size(200, 22);
            this.chkIsMainUnit.TabIndex = 4;
            // 
            // txtMainUnitCode
            // 
            this.txtMainUnitCode.Location = new System.Drawing.Point(598, 520);
            this.txtMainUnitCode.Name = "txtMainUnitCode";
            this.txtMainUnitCode.Size = new System.Drawing.Size(200, 22);
            this.txtMainUnitCode.TabIndex = 5;
            // 
            // lblComCode
            // 
            this.lblComCode.AutoSize = true;
            this.lblComCode.Location = new System.Drawing.Point(138, 526);
            this.lblComCode.Name = "lblComCode";
            this.lblComCode.Size = new System.Drawing.Size(78, 16);
            this.lblComCode.TabIndex = 1;
            this.lblComCode.Text = "Firma Kodu:";
            // 
            // lblUnitCode
            // 
            this.lblUnitCode.AutoSize = true;
            this.lblUnitCode.Location = new System.Drawing.Point(479, 483);
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.Size = new System.Drawing.Size(74, 16);
            this.lblUnitCode.TabIndex = 2;
            this.lblUnitCode.Text = "Birim Kodu:";
            // 
            // lblUnitText
            // 
            this.lblUnitText.AutoSize = true;
            this.lblUnitText.Location = new System.Drawing.Point(138, 483);
            this.lblUnitText.Name = "lblUnitText";
            this.lblUnitText.Size = new System.Drawing.Size(63, 16);
            this.lblUnitText.TabIndex = 3;
            this.lblUnitText.Text = "Birim Adı:";
            // 
            // lblIsMainUnit
            // 
            this.lblIsMainUnit.AutoSize = true;
            this.lblIsMainUnit.Location = new System.Drawing.Point(479, 562);
            this.lblIsMainUnit.Name = "lblIsMainUnit";
            this.lblIsMainUnit.Size = new System.Drawing.Size(110, 16);
            this.lblIsMainUnit.TabIndex = 4;
            this.lblIsMainUnit.Text = "Ana Ağırlık Birimi:";
            // 
            // lblMainUnitCode
            // 
            this.lblMainUnitCode.AutoSize = true;
            this.lblMainUnitCode.Location = new System.Drawing.Point(479, 526);
            this.lblMainUnitCode.Name = "lblMainUnitCode";
            this.lblMainUnitCode.Size = new System.Drawing.Size(101, 16);
            this.lblMainUnitCode.TabIndex = 5;
            this.lblMainUnitCode.Text = "Ana Birim Kodu:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(372, 603);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(513, 603);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(659, 603);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(222, 523);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // BSMGR0GEN005Form
            // 
            this.ClientSize = new System.Drawing.Size(1067, 645);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.lblComCode);
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
            this.Load += new System.EventHandler(this.BSMGR0GEN005Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
    }
}
