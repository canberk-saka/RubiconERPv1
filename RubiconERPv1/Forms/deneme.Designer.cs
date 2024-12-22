using System;
using System.Windows.Forms;

namespace RubiconERPv1.Forms
{
    public partial class deneme : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabPageFirma, tabPageMalzeme, tabPageAgirlik, tabPageUrunAgaci;
        private GroupBox groupBoxFirma, groupBoxMalzeme, groupBoxAğırlık, groupBoxUrunAgaci;
        private Label lblCOMCODE, lblMATDOCTYPE, lblMATDOCNUM, lblMATDOCFROM, lblMATDOCUNTIL;
        private TextBox txtCOMCODE, txtMATDOCNUM;
        private ComboBox cbMATDOCTYPE, cbSUPPLYTYPE;
        private DateTimePicker dtpMATDOCFROM, dtpMATDOCUNTIL;
        private Button btnAdd, btnUpdate, btnDelete, btnGet, btnListAll;
        private DataGridView dgvMalzeme; // DataGridView for displaying Malzeme information

        // Dispose methodu
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFirma = new System.Windows.Forms.TabPage();
            this.groupBoxFirma = new System.Windows.Forms.GroupBox();
            this.lblCOMCODE = new System.Windows.Forms.Label();
            this.txtCOMCODE = new System.Windows.Forms.TextBox();
            this.lblMATDOCTYPE = new System.Windows.Forms.Label();
            this.cbMATDOCTYPE = new System.Windows.Forms.ComboBox();
            this.tabPageMalzeme = new System.Windows.Forms.TabPage();
            this.groupBoxMalzeme = new System.Windows.Forms.GroupBox();
            this.lblMATDOCNUM = new System.Windows.Forms.Label();
            this.txtMATDOCNUM = new System.Windows.Forms.TextBox();
            this.lblMATDOCFROM = new System.Windows.Forms.Label();
            this.dtpMATDOCFROM = new System.Windows.Forms.DateTimePicker();
            this.lblMATDOCUNTIL = new System.Windows.Forms.Label();
            this.dtpMATDOCUNTIL = new System.Windows.Forms.DateTimePicker();
            this.dgvMalzeme = new System.Windows.Forms.DataGridView();
            this.tabPageAgirlik = new System.Windows.Forms.TabPage();
            this.groupBoxAğırlık = new System.Windows.Forms.GroupBox();
            this.tabPageUrunAgaci = new System.Windows.Forms.TabPage();
            this.groupBoxUrunAgaci = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageFirma.SuspendLayout();
            this.groupBoxFirma.SuspendLayout();
            this.tabPageMalzeme.SuspendLayout();
            this.groupBoxMalzeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).BeginInit();
            this.tabPageAgirlik.SuspendLayout();
            this.tabPageUrunAgaci.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFirma);
            this.tabControl.Controls.Add(this.tabPageMalzeme);
            this.tabControl.Controls.Add(this.tabPageAgirlik);
            this.tabControl.Controls.Add(this.tabPageUrunAgaci);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(570, 178);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFirma
            // 
            this.tabPageFirma.Controls.Add(this.groupBoxFirma);
            this.tabPageFirma.Location = new System.Drawing.Point(4, 25);
            this.tabPageFirma.Name = "tabPageFirma";
            this.tabPageFirma.Size = new System.Drawing.Size(562, 149);
            this.tabPageFirma.TabIndex = 0;
            this.tabPageFirma.Text = "Firma Bilgileri";
            // 
            // groupBoxFirma
            // 
            this.groupBoxFirma.Controls.Add(this.lblCOMCODE);
            this.groupBoxFirma.Controls.Add(this.txtCOMCODE);
            this.groupBoxFirma.Controls.Add(this.lblMATDOCTYPE);
            this.groupBoxFirma.Controls.Add(this.cbMATDOCTYPE);
            this.groupBoxFirma.Location = new System.Drawing.Point(10, 10);
            this.groupBoxFirma.Name = "groupBoxFirma";
            this.groupBoxFirma.Size = new System.Drawing.Size(350, 120);
            this.groupBoxFirma.TabIndex = 0;
            this.groupBoxFirma.TabStop = false;
            // 
            // lblCOMCODE
            // 
            this.lblCOMCODE.Location = new System.Drawing.Point(10, 20);
            this.lblCOMCODE.Name = "lblCOMCODE";
            this.lblCOMCODE.Size = new System.Drawing.Size(100, 20);
            this.lblCOMCODE.TabIndex = 0;
            this.lblCOMCODE.Text = "Firma Kodu";
            // 
            // txtCOMCODE
            // 
            this.txtCOMCODE.Location = new System.Drawing.Point(120, 20);
            this.txtCOMCODE.Name = "txtCOMCODE";
            this.txtCOMCODE.Size = new System.Drawing.Size(200, 22);
            this.txtCOMCODE.TabIndex = 1;
            // 
            // lblMATDOCTYPE
            // 
            this.lblMATDOCTYPE.Location = new System.Drawing.Point(10, 50);
            this.lblMATDOCTYPE.Name = "lblMATDOCTYPE";
            this.lblMATDOCTYPE.Size = new System.Drawing.Size(100, 20);
            this.lblMATDOCTYPE.TabIndex = 2;
            this.lblMATDOCTYPE.Text = "Malzeme Tipi";
            // 
            // cbMATDOCTYPE
            // 
            this.cbMATDOCTYPE.Location = new System.Drawing.Point(120, 50);
            this.cbMATDOCTYPE.Name = "cbMATDOCTYPE";
            this.cbMATDOCTYPE.Size = new System.Drawing.Size(200, 24);
            this.cbMATDOCTYPE.TabIndex = 3;
            // 
            // tabPageMalzeme
            // 
            this.tabPageMalzeme.Controls.Add(this.groupBoxMalzeme);
            this.tabPageMalzeme.Location = new System.Drawing.Point(4, 25);
            this.tabPageMalzeme.Name = "tabPageMalzeme";
            this.tabPageMalzeme.Size = new System.Drawing.Size(562, 149);
            this.tabPageMalzeme.TabIndex = 1;
            this.tabPageMalzeme.Text = "Malzeme Bilgileri";
            // 
            // groupBoxMalzeme
            // 
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCNUM);
            this.groupBoxMalzeme.Controls.Add(this.txtMATDOCNUM);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCFROM);
            this.groupBoxMalzeme.Controls.Add(this.dtpMATDOCFROM);
            this.groupBoxMalzeme.Controls.Add(this.lblMATDOCUNTIL);
            this.groupBoxMalzeme.Controls.Add(this.dtpMATDOCUNTIL);
            this.groupBoxMalzeme.Location = new System.Drawing.Point(10, 10);
            this.groupBoxMalzeme.Name = "groupBoxMalzeme";
            this.groupBoxMalzeme.Size = new System.Drawing.Size(415, 133);
            this.groupBoxMalzeme.TabIndex = 0;
            this.groupBoxMalzeme.TabStop = false;
            // 
            // lblMATDOCNUM
            // 
            this.lblMATDOCNUM.Location = new System.Drawing.Point(10, 20);
            this.lblMATDOCNUM.Name = "lblMATDOCNUM";
            this.lblMATDOCNUM.Size = new System.Drawing.Size(100, 20);
            this.lblMATDOCNUM.TabIndex = 4;
            this.lblMATDOCNUM.Text = "Malzeme Kodu";
            // 
            // txtMATDOCNUM
            // 
            this.txtMATDOCNUM.Location = new System.Drawing.Point(120, 20);
            this.txtMATDOCNUM.Name = "txtMATDOCNUM";
            this.txtMATDOCNUM.Size = new System.Drawing.Size(200, 22);
            this.txtMATDOCNUM.TabIndex = 5;
            // 
            // lblMATDOCFROM
            // 
            this.lblMATDOCFROM.Location = new System.Drawing.Point(10, 50);
            this.lblMATDOCFROM.Name = "lblMATDOCFROM";
            this.lblMATDOCFROM.Size = new System.Drawing.Size(100, 20);
            this.lblMATDOCFROM.TabIndex = 6;
            this.lblMATDOCFROM.Text = "Geçerlilik Başlangıç";
            // 
            // dtpMATDOCFROM
            // 
            this.dtpMATDOCFROM.Location = new System.Drawing.Point(120, 50);
            this.dtpMATDOCFROM.Name = "dtpMATDOCFROM";
            this.dtpMATDOCFROM.Size = new System.Drawing.Size(200, 22);
            this.dtpMATDOCFROM.TabIndex = 7;
            // 
            // lblMATDOCUNTIL
            // 
            this.lblMATDOCUNTIL.Location = new System.Drawing.Point(10, 80);
            this.lblMATDOCUNTIL.Name = "lblMATDOCUNTIL";
            this.lblMATDOCUNTIL.Size = new System.Drawing.Size(100, 20);
            this.lblMATDOCUNTIL.TabIndex = 8;
            this.lblMATDOCUNTIL.Text = "Geçerlilik Bitiş";
            // 
            // dtpMATDOCUNTIL
            // 
            this.dtpMATDOCUNTIL.Location = new System.Drawing.Point(120, 80);
            this.dtpMATDOCUNTIL.Name = "dtpMATDOCUNTIL";
            this.dtpMATDOCUNTIL.Size = new System.Drawing.Size(200, 22);
            this.dtpMATDOCUNTIL.TabIndex = 9;
            // 
            // dgvMalzeme
            // 
            this.dgvMalzeme.ColumnHeadersHeight = 29;
            this.dgvMalzeme.Location = new System.Drawing.Point(24, 204);
            this.dgvMalzeme.Name = "dgvMalzeme";
            this.dgvMalzeme.RowHeadersWidth = 51;
            this.dgvMalzeme.Size = new System.Drawing.Size(668, 208);
            this.dgvMalzeme.TabIndex = 10;
            // 
            // tabPageAgirlik
            // 
            this.tabPageAgirlik.Controls.Add(this.groupBoxAğırlık);
            this.tabPageAgirlik.Location = new System.Drawing.Point(4, 25);
            this.tabPageAgirlik.Name = "tabPageAgirlik";
            this.tabPageAgirlik.Size = new System.Drawing.Size(562, 149);
            this.tabPageAgirlik.TabIndex = 2;
            this.tabPageAgirlik.Text = "Ağırlık Bilgileri";
            // 
            // groupBoxAğırlık
            // 
            this.groupBoxAğırlık.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAğırlık.Name = "groupBoxAğırlık";
            this.groupBoxAğırlık.Size = new System.Drawing.Size(200, 100);
            this.groupBoxAğırlık.TabIndex = 0;
            this.groupBoxAğırlık.TabStop = false;
            // 
            // tabPageUrunAgaci
            // 
            this.tabPageUrunAgaci.Controls.Add(this.groupBoxUrunAgaci);
            this.tabPageUrunAgaci.Location = new System.Drawing.Point(4, 25);
            this.tabPageUrunAgaci.Name = "tabPageUrunAgaci";
            this.tabPageUrunAgaci.Size = new System.Drawing.Size(562, 149);
            this.tabPageUrunAgaci.TabIndex = 3;
            this.tabPageUrunAgaci.Text = "Ürün Ağacı Bilgileri";
            // 
            // groupBoxUrunAgaci
            // 
            this.groupBoxUrunAgaci.Location = new System.Drawing.Point(0, 0);
            this.groupBoxUrunAgaci.Name = "groupBoxUrunAgaci";
            this.groupBoxUrunAgaci.Size = new System.Drawing.Size(200, 100);
            this.groupBoxUrunAgaci.TabIndex = 0;
            this.groupBoxUrunAgaci.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            // 
            // deneme
            // 
            this.ClientSize = new System.Drawing.Size(727, 424);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dgvMalzeme);
            this.Name = "deneme";
            this.Text = "Malzeme İşlemleri";
            this.tabControl.ResumeLayout(false);
            this.tabPageFirma.ResumeLayout(false);
            this.groupBoxFirma.ResumeLayout(false);
            this.groupBoxFirma.PerformLayout();
            this.tabPageMalzeme.ResumeLayout(false);
            this.groupBoxMalzeme.ResumeLayout(false);
            this.groupBoxMalzeme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).EndInit();
            this.tabPageAgirlik.ResumeLayout(false);
            this.tabPageUrunAgaci.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    }
}
