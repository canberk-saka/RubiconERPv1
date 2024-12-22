namespace RubiconERPv1.Forms.Ana_Tablolar
{
    partial class MalzemeBilgileriForm
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
            this.dgvMalzeme = new System.Windows.Forms.DataGridView();
            this.tabPageUrunAgaci = new System.Windows.Forms.TabPage();
            this.groupBoxUrunAgaci = new System.Windows.Forms.GroupBox();
            this.txtBomDocType = new System.Windows.Forms.TextBox();
            this.lblBomDocType = new System.Windows.Forms.Label();
            this.chkIsBom = new System.Windows.Forms.CheckBox();
            this.tabPageAgirlik = new System.Windows.Forms.TabPage();
            this.groupBoxAğırlık = new System.Windows.Forms.GroupBox();
            this.txtBwUnit = new System.Windows.Forms.TextBox();
            this.lblBwUnit = new System.Windows.Forms.Label();
            this.txtBrutWeight = new System.Windows.Forms.TextBox();
            this.lblBrutWeight = new System.Windows.Forms.Label();
            this.txtNwUnit = new System.Windows.Forms.TextBox();
            this.lblNwUnit = new System.Windows.Forms.Label();
            this.txtNetWeight = new System.Windows.Forms.TextBox();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.txtStUnit = new System.Windows.Forms.TextBox();
            this.lblStUnit = new System.Windows.Forms.Label();
            this.txtSupplyType = new System.Windows.Forms.TextBox();
            this.lblSupplyType = new System.Windows.Forms.Label();
            this.tabPageMalzeme = new System.Windows.Forms.TabPage();
            this.groupBoxMalzeme = new System.Windows.Forms.GroupBox();
            this.chkIsPassive = new System.Windows.Forms.CheckBox();
            this.chkIsDeleted = new System.Windows.Forms.CheckBox();
            this.txtRotDocNum = new System.Windows.Forms.TextBox();
            this.lblRotDocNum = new System.Windows.Forms.Label();
            this.txtRotDocType = new System.Windows.Forms.TextBox();
            this.lblRotDocType = new System.Windows.Forms.Label();
            this.chkIsRoute = new System.Windows.Forms.CheckBox();
            this.txtBomDocNum = new System.Windows.Forms.TextBox();
            this.lblBomDocNum = new System.Windows.Forms.Label();
            this.dtpMatDocUntil = new System.Windows.Forms.DateTimePicker();
            this.lblMATDOCUNTIL = new System.Windows.Forms.Label();
            this.dtpMatDocFrom = new System.Windows.Forms.DateTimePicker();
            this.lblMATDOCFROM = new System.Windows.Forms.Label();
            this.txtMatDocNum = new System.Windows.Forms.TextBox();
            this.lblMATDOCNUM = new System.Windows.Forms.Label();
            this.cbMatDocType = new System.Windows.Forms.ComboBox();
            this.lblMATDOCTYPE = new System.Windows.Forms.Label();
            this.txtComCode = new System.Windows.Forms.TextBox();
            this.lblCOMCODE = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).BeginInit();
            this.tabPageUrunAgaci.SuspendLayout();
            this.groupBoxUrunAgaci.SuspendLayout();
            this.tabPageAgirlik.SuspendLayout();
            this.groupBoxAğırlık.SuspendLayout();
            this.tabPageMalzeme.SuspendLayout();
            this.groupBoxMalzeme.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMalzeme
            // 
            this.dgvMalzeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalzeme.Location = new System.Drawing.Point(16, 213);
            this.dgvMalzeme.Name = "dgvMalzeme";
            this.dgvMalzeme.RowHeadersWidth = 51;
            this.dgvMalzeme.RowTemplate.Height = 24;
            this.dgvMalzeme.Size = new System.Drawing.Size(991, 244);
            this.dgvMalzeme.TabIndex = 1;
            // 
            // tabPageUrunAgaci
            // 
            this.tabPageUrunAgaci.Controls.Add(this.groupBoxUrunAgaci);
            this.tabPageUrunAgaci.Location = new System.Drawing.Point(4, 25);
            this.tabPageUrunAgaci.Name = "tabPageUrunAgaci";
            this.tabPageUrunAgaci.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUrunAgaci.Size = new System.Drawing.Size(991, 166);
            this.tabPageUrunAgaci.TabIndex = 3;
            this.tabPageUrunAgaci.Text = "Ürün Ağacı";
            this.tabPageUrunAgaci.UseVisualStyleBackColor = true;
            // 
            // groupBoxUrunAgaci
            // 
            this.groupBoxUrunAgaci.Controls.Add(this.chkIsBom);
            this.groupBoxUrunAgaci.Controls.Add(this.lblBomDocType);
            this.groupBoxUrunAgaci.Controls.Add(this.txtBomDocType);
            this.groupBoxUrunAgaci.Location = new System.Drawing.Point(6, 6);
            this.groupBoxUrunAgaci.Name = "groupBoxUrunAgaci";
            this.groupBoxUrunAgaci.Size = new System.Drawing.Size(642, 154);
            this.groupBoxUrunAgaci.TabIndex = 0;
            this.groupBoxUrunAgaci.TabStop = false;
            this.groupBoxUrunAgaci.Text = "Ürün Ağacı";
            // 
            // txtBomDocType
            // 
            this.txtBomDocType.Location = new System.Drawing.Point(160, 35);
            this.txtBomDocType.Name = "txtBomDocType";
            this.txtBomDocType.Size = new System.Drawing.Size(100, 22);
            this.txtBomDocType.TabIndex = 21;
            // 
            // lblBomDocType
            // 
            this.lblBomDocType.AutoSize = true;
            this.lblBomDocType.Location = new System.Drawing.Point(21, 35);
            this.lblBomDocType.Name = "lblBomDocType";
            this.lblBomDocType.Size = new System.Drawing.Size(102, 16);
            this.lblBomDocType.TabIndex = 23;
            this.lblBomDocType.Text = "Ürün Ağacı Tipi:";
            // 
            // chkIsBom
            // 
            this.chkIsBom.AutoSize = true;
            this.chkIsBom.Location = new System.Drawing.Point(160, 84);
            this.chkIsBom.Name = "chkIsBom";
            this.chkIsBom.Size = new System.Drawing.Size(143, 20);
            this.chkIsBom.TabIndex = 22;
            this.chkIsBom.Text = "Ürün Ağacı Var mı?";
            this.chkIsBom.UseVisualStyleBackColor = true;
            // 
            // tabPageAgirlik
            // 
            this.tabPageAgirlik.Controls.Add(this.groupBoxAğırlık);
            this.tabPageAgirlik.Location = new System.Drawing.Point(4, 25);
            this.tabPageAgirlik.Name = "tabPageAgirlik";
            this.tabPageAgirlik.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAgirlik.Size = new System.Drawing.Size(991, 166);
            this.tabPageAgirlik.TabIndex = 2;
            this.tabPageAgirlik.Text = "Ağırlık Bilgileri";
            this.tabPageAgirlik.UseVisualStyleBackColor = true;
            // 
            // groupBoxAğırlık
            // 
            this.groupBoxAğırlık.Controls.Add(this.lblSupplyType);
            this.groupBoxAğırlık.Controls.Add(this.txtSupplyType);
            this.groupBoxAğırlık.Controls.Add(this.lblStUnit);
            this.groupBoxAğırlık.Controls.Add(this.txtStUnit);
            this.groupBoxAğırlık.Controls.Add(this.lblNetWeight);
            this.groupBoxAğırlık.Controls.Add(this.txtNetWeight);
            this.groupBoxAğırlık.Controls.Add(this.lblNwUnit);
            this.groupBoxAğırlık.Controls.Add(this.txtNwUnit);
            this.groupBoxAğırlık.Controls.Add(this.lblBrutWeight);
            this.groupBoxAğırlık.Controls.Add(this.txtBrutWeight);
            this.groupBoxAğırlık.Controls.Add(this.lblBwUnit);
            this.groupBoxAğırlık.Controls.Add(this.txtBwUnit);
            this.groupBoxAğırlık.Location = new System.Drawing.Point(6, 6);
            this.groupBoxAğırlık.Name = "groupBoxAğırlık";
            this.groupBoxAğırlık.Size = new System.Drawing.Size(642, 154);
            this.groupBoxAğırlık.TabIndex = 0;
            this.groupBoxAğırlık.TabStop = false;
            this.groupBoxAğırlık.Text = "Ağırlık Bilgileri";
            // 
            // txtBwUnit
            // 
            this.txtBwUnit.Location = new System.Drawing.Point(121, 32);
            this.txtBwUnit.Name = "txtBwUnit";
            this.txtBwUnit.Size = new System.Drawing.Size(100, 22);
            this.txtBwUnit.TabIndex = 29;
            // 
            // lblBwUnit
            // 
            this.lblBwUnit.AutoSize = true;
            this.lblBwUnit.Location = new System.Drawing.Point(6, 32);
            this.lblBwUnit.Name = "lblBwUnit";
            this.lblBwUnit.Size = new System.Drawing.Size(109, 16);
            this.lblBwUnit.TabIndex = 28;
            this.lblBwUnit.Text = "Brüt Ağırlık Birimi:";
            // 
            // txtBrutWeight
            // 
            this.txtBrutWeight.Location = new System.Drawing.Point(121, 67);
            this.txtBrutWeight.Name = "txtBrutWeight";
            this.txtBrutWeight.Size = new System.Drawing.Size(100, 22);
            this.txtBrutWeight.TabIndex = 27;
            // 
            // lblBrutWeight
            // 
            this.lblBrutWeight.AutoSize = true;
            this.lblBrutWeight.Location = new System.Drawing.Point(6, 67);
            this.lblBrutWeight.Name = "lblBrutWeight";
            this.lblBrutWeight.Size = new System.Drawing.Size(73, 16);
            this.lblBrutWeight.TabIndex = 26;
            this.lblBrutWeight.Text = "Brüt Ağırlık:";
            // 
            // txtNwUnit
            // 
            this.txtNwUnit.Location = new System.Drawing.Point(395, 61);
            this.txtNwUnit.Name = "txtNwUnit";
            this.txtNwUnit.Size = new System.Drawing.Size(100, 22);
            this.txtNwUnit.TabIndex = 25;
            // 
            // lblNwUnit
            // 
            this.lblNwUnit.AutoSize = true;
            this.lblNwUnit.Location = new System.Drawing.Point(270, 64);
            this.lblNwUnit.Name = "lblNwUnit";
            this.lblNwUnit.Size = new System.Drawing.Size(107, 16);
            this.lblNwUnit.TabIndex = 24;
            this.lblNwUnit.Text = "Net Ağırlık Birimi:";
            // 
            // txtNetWeight
            // 
            this.txtNetWeight.Location = new System.Drawing.Point(395, 26);
            this.txtNetWeight.Name = "txtNetWeight";
            this.txtNetWeight.Size = new System.Drawing.Size(100, 22);
            this.txtNetWeight.TabIndex = 23;
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Location = new System.Drawing.Point(270, 32);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(71, 16);
            this.lblNetWeight.TabIndex = 22;
            this.lblNetWeight.Text = "Net Ağırlık:";
            // 
            // txtStUnit
            // 
            this.txtStUnit.Location = new System.Drawing.Point(395, 103);
            this.txtStUnit.Name = "txtStUnit";
            this.txtStUnit.Size = new System.Drawing.Size(100, 22);
            this.txtStUnit.TabIndex = 21;
            // 
            // lblStUnit
            // 
            this.lblStUnit.AutoSize = true;
            this.lblStUnit.Location = new System.Drawing.Point(270, 100);
            this.lblStUnit.Name = "lblStUnit";
            this.lblStUnit.Size = new System.Drawing.Size(73, 16);
            this.lblStUnit.TabIndex = 20;
            this.lblStUnit.Text = "Stok Birimi:";
            // 
            // txtSupplyType
            // 
            this.txtSupplyType.Location = new System.Drawing.Point(121, 103);
            this.txtSupplyType.Name = "txtSupplyType";
            this.txtSupplyType.Size = new System.Drawing.Size(100, 22);
            this.txtSupplyType.TabIndex = 19;
            // 
            // lblSupplyType
            // 
            this.lblSupplyType.AutoSize = true;
            this.lblSupplyType.Location = new System.Drawing.Point(6, 103);
            this.lblSupplyType.Name = "lblSupplyType";
            this.lblSupplyType.Size = new System.Drawing.Size(83, 16);
            this.lblSupplyType.TabIndex = 18;
            this.lblSupplyType.Text = "Tedarik Tipi:";
            // 
            // tabPageMalzeme
            // 
            this.tabPageMalzeme.Controls.Add(this.groupBoxMalzeme);
            this.tabPageMalzeme.Location = new System.Drawing.Point(4, 25);
            this.tabPageMalzeme.Name = "tabPageMalzeme";
            this.tabPageMalzeme.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMalzeme.Size = new System.Drawing.Size(991, 166);
            this.tabPageMalzeme.TabIndex = 1;
            this.tabPageMalzeme.Text = "Malzeme Bilgileri";
            this.tabPageMalzeme.UseVisualStyleBackColor = true;
            // 
            // groupBoxMalzeme
            // 
            this.groupBoxMalzeme.Controls.Add(this.lblCOMCODE);
            this.groupBoxMalzeme.Controls.Add(this.txtComCode);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCTYPE);
            this.groupBoxMalzeme.Controls.Add(this.cbMatDocType);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCNUM);
            this.groupBoxMalzeme.Controls.Add(this.txtMatDocNum);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCFROM);
            this.groupBoxMalzeme.Controls.Add(this.dtpMatDocFrom);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCUNTIL);
            this.groupBoxMalzeme.Controls.Add(this.dtpMatDocUntil);
            this.groupBoxMalzeme.Controls.Add(this.lblBomDocNum);
            this.groupBoxMalzeme.Controls.Add(this.txtBomDocNum);
            this.groupBoxMalzeme.Controls.Add(this.chkIsRoute);
            this.groupBoxMalzeme.Controls.Add(this.lblRotDocType);
            this.groupBoxMalzeme.Controls.Add(this.txtRotDocType);
            this.groupBoxMalzeme.Controls.Add(this.lblRotDocNum);
            this.groupBoxMalzeme.Controls.Add(this.txtRotDocNum);
            this.groupBoxMalzeme.Controls.Add(this.chkIsDeleted);
            this.groupBoxMalzeme.Controls.Add(this.chkIsPassive);
            this.groupBoxMalzeme.Location = new System.Drawing.Point(6, 6);
            this.groupBoxMalzeme.Name = "groupBoxMalzeme";
            this.groupBoxMalzeme.Size = new System.Drawing.Size(989, 400);
            this.groupBoxMalzeme.TabIndex = 1;
            this.groupBoxMalzeme.TabStop = false;
            this.groupBoxMalzeme.Text = "Malzeme Bilgileri";
            // 
            // chkIsPassive
            // 
            this.chkIsPassive.Location = new System.Drawing.Point(0, 0);
            this.chkIsPassive.Name = "chkIsPassive";
            this.chkIsPassive.Size = new System.Drawing.Size(104, 24);
            this.chkIsPassive.TabIndex = 29;
            // 
            // chkIsDeleted
            // 
            this.chkIsDeleted.Location = new System.Drawing.Point(0, 0);
            this.chkIsDeleted.Name = "chkIsDeleted";
            this.chkIsDeleted.Size = new System.Drawing.Size(104, 24);
            this.chkIsDeleted.TabIndex = 28;
            // 
            // txtRotDocNum
            // 
            this.txtRotDocNum.Location = new System.Drawing.Point(0, 0);
            this.txtRotDocNum.Name = "txtRotDocNum";
            this.txtRotDocNum.Size = new System.Drawing.Size(100, 22);
            this.txtRotDocNum.TabIndex = 27;
            // 
            // lblRotDocNum
            // 
            this.lblRotDocNum.Location = new System.Drawing.Point(0, 0);
            this.lblRotDocNum.Name = "lblRotDocNum";
            this.lblRotDocNum.Size = new System.Drawing.Size(100, 23);
            this.lblRotDocNum.TabIndex = 26;
            // 
            // txtRotDocType
            // 
            this.txtRotDocType.Location = new System.Drawing.Point(0, 0);
            this.txtRotDocType.Name = "txtRotDocType";
            this.txtRotDocType.Size = new System.Drawing.Size(100, 22);
            this.txtRotDocType.TabIndex = 25;
            // 
            // lblRotDocType
            // 
            this.lblRotDocType.Location = new System.Drawing.Point(0, 0);
            this.lblRotDocType.Name = "lblRotDocType";
            this.lblRotDocType.Size = new System.Drawing.Size(100, 23);
            this.lblRotDocType.TabIndex = 24;
            // 
            // chkIsRoute
            // 
            this.chkIsRoute.Location = new System.Drawing.Point(0, 0);
            this.chkIsRoute.Name = "chkIsRoute";
            this.chkIsRoute.Size = new System.Drawing.Size(104, 24);
            this.chkIsRoute.TabIndex = 23;
            // 
            // txtBomDocNum
            // 
            this.txtBomDocNum.Location = new System.Drawing.Point(0, 0);
            this.txtBomDocNum.Name = "txtBomDocNum";
            this.txtBomDocNum.Size = new System.Drawing.Size(100, 22);
            this.txtBomDocNum.TabIndex = 22;
            // 
            // lblBomDocNum
            // 
            this.lblBomDocNum.Location = new System.Drawing.Point(0, 0);
            this.lblBomDocNum.Name = "lblBomDocNum";
            this.lblBomDocNum.Size = new System.Drawing.Size(100, 23);
            this.lblBomDocNum.TabIndex = 21;
            // 
            // dtpMatDocUntil
            // 
            this.dtpMatDocUntil.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMatDocUntil.Location = new System.Drawing.Point(481, 99);
            this.dtpMatDocUntil.Name = "dtpMatDocUntil";
            this.dtpMatDocUntil.Size = new System.Drawing.Size(200, 22);
            this.dtpMatDocUntil.TabIndex = 5;
            // 
            // lblMATDOCUNTIL
            // 
            this.lblMATDOCUNTIL.AutoSize = true;
            this.lblMATDOCUNTIL.Location = new System.Drawing.Point(361, 104);
            this.lblMATDOCUNTIL.Name = "lblMATDOCUNTIL";
            this.lblMATDOCUNTIL.Size = new System.Drawing.Size(69, 16);
            this.lblMATDOCUNTIL.TabIndex = 4;
            this.lblMATDOCUNTIL.Text = "Bitiş Tarihi";
            // 
            // dtpMatDocFrom
            // 
            this.dtpMatDocFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMatDocFrom.Location = new System.Drawing.Point(481, 63);
            this.dtpMatDocFrom.Name = "dtpMatDocFrom";
            this.dtpMatDocFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpMatDocFrom.TabIndex = 3;
            // 
            // lblMATDOCFROM
            // 
            this.lblMATDOCFROM.AutoSize = true;
            this.lblMATDOCFROM.Location = new System.Drawing.Point(361, 69);
            this.lblMATDOCFROM.Name = "lblMATDOCFROM";
            this.lblMATDOCFROM.Size = new System.Drawing.Size(104, 16);
            this.lblMATDOCFROM.TabIndex = 2;
            this.lblMATDOCFROM.Text = "Başlangıç Tarihi";
            // 
            // txtMatDocNum
            // 
            this.txtMatDocNum.Location = new System.Drawing.Point(481, 31);
            this.txtMatDocNum.Name = "txtMatDocNum";
            this.txtMatDocNum.Size = new System.Drawing.Size(200, 22);
            this.txtMatDocNum.TabIndex = 1;
            // 
            // lblMATDOCNUM
            // 
            this.lblMATDOCNUM.AutoSize = true;
            this.lblMATDOCNUM.Location = new System.Drawing.Point(361, 34);
            this.lblMATDOCNUM.Name = "lblMATDOCNUM";
            this.lblMATDOCNUM.Size = new System.Drawing.Size(114, 16);
            this.lblMATDOCNUM.TabIndex = 0;
            this.lblMATDOCNUM.Text = "Malzeme Dok. No";
            // 
            // cbMatDocType
            // 
            this.cbMatDocType.FormattingEnabled = true;
            this.cbMatDocType.Location = new System.Drawing.Point(115, 66);
            this.cbMatDocType.Name = "cbMatDocType";
            this.cbMatDocType.Size = new System.Drawing.Size(200, 24);
            this.cbMatDocType.TabIndex = 33;
            // 
            // lblMATDOCTYPE
            // 
            this.lblMATDOCTYPE.AutoSize = true;
            this.lblMATDOCTYPE.Location = new System.Drawing.Point(6, 69);
            this.lblMATDOCTYPE.Name = "lblMATDOCTYPE";
            this.lblMATDOCTYPE.Size = new System.Drawing.Size(88, 16);
            this.lblMATDOCTYPE.TabIndex = 32;
            this.lblMATDOCTYPE.Text = "Malzeme Tipi";
            // 
            // txtComCode
            // 
            this.txtComCode.Location = new System.Drawing.Point(115, 31);
            this.txtComCode.Name = "txtComCode";
            this.txtComCode.Size = new System.Drawing.Size(200, 22);
            this.txtComCode.TabIndex = 31;
            // 
            // lblCOMCODE
            // 
            this.lblCOMCODE.AutoSize = true;
            this.lblCOMCODE.Location = new System.Drawing.Point(6, 34);
            this.lblCOMCODE.Name = "lblCOMCODE";
            this.lblCOMCODE.Size = new System.Drawing.Size(75, 16);
            this.lblCOMCODE.TabIndex = 30;
            this.lblCOMCODE.Text = "Firma Kodu";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMalzeme);
            this.tabControl.Controls.Add(this.tabPageAgirlik);
            this.tabControl.Controls.Add(this.tabPageUrunAgaci);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(999, 195);
            this.tabControl.TabIndex = 0;
            // 
            // MalzemeBilgileriForm
            // 
            this.ClientSize = new System.Drawing.Size(1023, 508);
            this.Controls.Add(this.dgvMalzeme);
            this.Controls.Add(this.tabControl);
            this.Name = "MalzemeBilgileriForm";
            this.Text = "Malzeme Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).EndInit();
            this.tabPageUrunAgaci.ResumeLayout(false);
            this.groupBoxUrunAgaci.ResumeLayout(false);
            this.groupBoxUrunAgaci.PerformLayout();
            this.tabPageAgirlik.ResumeLayout(false);
            this.groupBoxAğırlık.ResumeLayout(false);
            this.groupBoxAğırlık.PerformLayout();
            this.tabPageMalzeme.ResumeLayout(false);
            this.groupBoxMalzeme.ResumeLayout(false);
            this.groupBoxMalzeme.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.DataGridView dgvMalzeme;
        private System.Windows.Forms.TabPage tabPageUrunAgaci;
        private System.Windows.Forms.GroupBox groupBoxUrunAgaci;
        private System.Windows.Forms.CheckBox chkIsBom;
        private System.Windows.Forms.Label lblBomDocType;
        private System.Windows.Forms.TextBox txtBomDocType;
        private System.Windows.Forms.TabPage tabPageAgirlik;
        private System.Windows.Forms.GroupBox groupBoxAğırlık;
        private System.Windows.Forms.Label lblSupplyType;
        private System.Windows.Forms.TextBox txtSupplyType;
        private System.Windows.Forms.Label lblStUnit;
        private System.Windows.Forms.TextBox txtStUnit;
        private System.Windows.Forms.Label lblNetWeight;
        private System.Windows.Forms.TextBox txtNetWeight;
        private System.Windows.Forms.Label lblNwUnit;
        private System.Windows.Forms.TextBox txtNwUnit;
        private System.Windows.Forms.Label lblBrutWeight;
        private System.Windows.Forms.TextBox txtBrutWeight;
        private System.Windows.Forms.Label lblBwUnit;
        private System.Windows.Forms.TextBox txtBwUnit;
        private System.Windows.Forms.TabPage tabPageMalzeme;
        private System.Windows.Forms.GroupBox groupBoxMalzeme;
        private System.Windows.Forms.Label lblCOMCODE;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.Label lblMATDOCTYPE;
        private System.Windows.Forms.ComboBox cbMatDocType;
        private System.Windows.Forms.Label lblMATDOCNUM;
        private System.Windows.Forms.TextBox txtMatDocNum;
        private System.Windows.Forms.Label lblMATDOCFROM;
        private System.Windows.Forms.DateTimePicker dtpMatDocFrom;
        private System.Windows.Forms.Label lblMATDOCUNTIL;
        private System.Windows.Forms.DateTimePicker dtpMatDocUntil;
        private System.Windows.Forms.Label lblBomDocNum;
        private System.Windows.Forms.TextBox txtBomDocNum;
        private System.Windows.Forms.CheckBox chkIsRoute;
        private System.Windows.Forms.Label lblRotDocType;
        private System.Windows.Forms.TextBox txtRotDocType;
        private System.Windows.Forms.Label lblRotDocNum;
        private System.Windows.Forms.TextBox txtRotDocNum;
        private System.Windows.Forms.CheckBox chkIsDeleted;
        private System.Windows.Forms.CheckBox chkIsPassive;
        private System.Windows.Forms.TabControl tabControl;
    }
}
