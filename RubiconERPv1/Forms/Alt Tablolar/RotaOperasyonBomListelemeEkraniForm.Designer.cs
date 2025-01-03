namespace RubiconERPv1.Forms.Alt_Tablolar
{
    partial class RotaOperasyonBomListelemeEkraniForm
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
            this.btnMalzemeIncele = new System.Windows.Forms.Button();
            this.btnMalzemeDuzenle = new System.Windows.Forms.Button();
            this.btnMalzemeEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMalzemeListele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzemeListele)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMalzemeIncele
            // 
            this.btnMalzemeIncele.Location = new System.Drawing.Point(492, 123);
            this.btnMalzemeIncele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMalzemeIncele.Name = "btnMalzemeIncele";
            this.btnMalzemeIncele.Size = new System.Drawing.Size(116, 50);
            this.btnMalzemeIncele.TabIndex = 18;
            this.btnMalzemeIncele.Text = "Malzeme İncele";
            this.btnMalzemeIncele.UseVisualStyleBackColor = true;
            // 
            // btnMalzemeDuzenle
            // 
            this.btnMalzemeDuzenle.Location = new System.Drawing.Point(333, 123);
            this.btnMalzemeDuzenle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMalzemeDuzenle.Name = "btnMalzemeDuzenle";
            this.btnMalzemeDuzenle.Size = new System.Drawing.Size(116, 50);
            this.btnMalzemeDuzenle.TabIndex = 17;
            this.btnMalzemeDuzenle.Text = "Malzeme Düzenle";
            this.btnMalzemeDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnMalzemeEkle
            // 
            this.btnMalzemeEkle.Location = new System.Drawing.Point(179, 123);
            this.btnMalzemeEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMalzemeEkle.Name = "btnMalzemeEkle";
            this.btnMalzemeEkle.Size = new System.Drawing.Size(116, 50);
            this.btnMalzemeEkle.TabIndex = 16;
            this.btnMalzemeEkle.Text = "Malzeme Ekle";
            this.btnMalzemeEkle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(173, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tüketilen Malzeme Listeleme Ekranı";
            // 
            // dgvMalzemeListele
            // 
            this.dgvMalzemeListele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalzemeListele.Location = new System.Drawing.Point(179, 223);
            this.dgvMalzemeListele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMalzemeListele.Name = "dgvMalzemeListele";
            this.dgvMalzemeListele.RowHeadersWidth = 51;
            this.dgvMalzemeListele.RowTemplate.Height = 24;
            this.dgvMalzemeListele.Size = new System.Drawing.Size(1285, 369);
            this.dgvMalzemeListele.TabIndex = 14;
            this.dgvMalzemeListele.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMalzemeListele_CellContentClick);
            this.dgvMalzemeListele.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtMalzemeListele_CellDoubleClick);
            // 
            // RotaOperasyonBomListelemeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 651);
            this.Controls.Add(this.btnMalzemeIncele);
            this.Controls.Add(this.btnMalzemeDuzenle);
            this.Controls.Add(this.btnMalzemeEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMalzemeListele);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RotaOperasyonBomListelemeEkraniForm";
            this.Text = "RotaOperasyonBomListelemeEkraniForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzemeListele)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMalzemeIncele;
        private System.Windows.Forms.Button btnMalzemeDuzenle;
        private System.Windows.Forms.Button btnMalzemeEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMalzemeListele;
    }
}