﻿using System.Drawing;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Kontrol_Tabloları
{
    partial class BSMGR0MAT001Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.grpMaterialDetails = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsPassive = new System.Windows.Forms.ComboBox();
            this.txtDocTypeText = new System.Windows.Forms.TextBox();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.grpMaterialDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(12, 31);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersWidth = 51;
            this.dgvMaterials.RowTemplate.Height = 24;
            this.dgvMaterials.Size = new System.Drawing.Size(1148, 298);
            this.dgvMaterials.TabIndex = 0;
            // 
            // grpMaterialDetails
            // 
            this.grpMaterialDetails.Controls.Add(this.comboBox1);
            this.grpMaterialDetails.Controls.Add(this.label4);
            this.grpMaterialDetails.Controls.Add(this.label3);
            this.grpMaterialDetails.Controls.Add(this.label2);
            this.grpMaterialDetails.Controls.Add(this.label1);
            this.grpMaterialDetails.Controls.Add(this.cbIsPassive);
            this.grpMaterialDetails.Controls.Add(this.txtDocTypeText);
            this.grpMaterialDetails.Controls.Add(this.txtDocType);
            this.grpMaterialDetails.Location = new System.Drawing.Point(226, 476);
            this.grpMaterialDetails.Name = "grpMaterialDetails";
            this.grpMaterialDetails.Size = new System.Drawing.Size(650, 145);
            this.grpMaterialDetails.TabIndex = 1;
            this.grpMaterialDetails.TabStop = false;
            this.grpMaterialDetails.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pasif mi?:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tip Açıklaması:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Malzeme Tipi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firma Kodu:";
            // 
            // cbIsPassive
            // 
            this.cbIsPassive.FormattingEnabled = true;
            this.cbIsPassive.Location = new System.Drawing.Point(425, 85);
            this.cbIsPassive.Name = "cbIsPassive";
            this.cbIsPassive.Size = new System.Drawing.Size(121, 24);
            this.cbIsPassive.TabIndex = 3;
            // 
            // txtDocTypeText
            // 
            this.txtDocTypeText.Location = new System.Drawing.Point(425, 34);
            this.txtDocTypeText.Name = "txtDocTypeText";
            this.txtDocTypeText.Size = new System.Drawing.Size(100, 22);
            this.txtDocTypeText.TabIndex = 2;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(109, 87);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(100, 22);
            this.txtDocType.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(309, 647);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(423, 647);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 34);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(559, 647);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(674, 650);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 29);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleName = "comboBox1";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // BSMGR0MAT001Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 742);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpMaterialDetails);
            this.Controls.Add(this.dgvMaterials);
            this.Name = "BSMGR0MAT001Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BSMGR0MAT001 - Materyal Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.grpMaterialDetails.ResumeLayout(false);
            this.grpMaterialDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvMaterials;
        private GroupBox grpMaterialDetails;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbIsPassive;
        private TextBox txtDocTypeText;
        private TextBox txtDocType;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private ComboBox comboBox1;
    }
}