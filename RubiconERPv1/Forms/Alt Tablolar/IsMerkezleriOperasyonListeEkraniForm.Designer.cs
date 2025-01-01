namespace RubiconERPv1.Forms.Alt_Tablolar
{
    partial class IsMerkezleriOperasyonListeEkraniForm
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
            this.btnOperasyonSil = new System.Windows.Forms.Button();
            this.btnOperasyonDuzenle = new System.Windows.Forms.Button();
            this.btnOperasyonEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOperasyonListele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperasyonListele)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperasyonSil
            // 
            this.btnOperasyonSil.Location = new System.Drawing.Point(469, 113);
            this.btnOperasyonSil.Name = "btnOperasyonSil";
            this.btnOperasyonSil.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonSil.TabIndex = 12;
            this.btnOperasyonSil.Text = "Operasyonu Sil";
            this.btnOperasyonSil.UseVisualStyleBackColor = true;
            this.btnOperasyonSil.Click += new System.EventHandler(this.btnOperasyonSil_Click);
            // 
            // btnOperasyonDuzenle
            // 
            this.btnOperasyonDuzenle.Location = new System.Drawing.Point(311, 113);
            this.btnOperasyonDuzenle.Name = "btnOperasyonDuzenle";
            this.btnOperasyonDuzenle.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonDuzenle.TabIndex = 11;
            this.btnOperasyonDuzenle.Text = "Operasyon Düzenle";
            this.btnOperasyonDuzenle.UseVisualStyleBackColor = true;
            this.btnOperasyonDuzenle.Click += new System.EventHandler(this.btnOperasyonDuzenle_Click);
            // 
            // btnOperasyonEkle
            // 
            this.btnOperasyonEkle.Location = new System.Drawing.Point(156, 113);
            this.btnOperasyonEkle.Name = "btnOperasyonEkle";
            this.btnOperasyonEkle.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonEkle.TabIndex = 10;
            this.btnOperasyonEkle.Text = "Operasyon Ekle";
            this.btnOperasyonEkle.UseVisualStyleBackColor = true;
            this.btnOperasyonEkle.Click += new System.EventHandler(this.btnOperasyonEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(151, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operasyon Liste Ekranı";
            // 
            // dgvOperasyonListele
            // 
            this.dgvOperasyonListele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperasyonListele.Location = new System.Drawing.Point(156, 213);
            this.dgvOperasyonListele.Name = "dgvOperasyonListele";
            this.dgvOperasyonListele.RowHeadersWidth = 51;
            this.dgvOperasyonListele.RowTemplate.Height = 24;
            this.dgvOperasyonListele.Size = new System.Drawing.Size(1286, 369);
            this.dgvOperasyonListele.TabIndex = 7;
            // 
            // IsMerkezleriOperasyonListeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 697);
            this.Controls.Add(this.btnOperasyonSil);
            this.Controls.Add(this.btnOperasyonDuzenle);
            this.Controls.Add(this.btnOperasyonEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOperasyonListele);
            this.Name = "IsMerkezleriOperasyonListeEkraniForm";
            this.Text = "IsMerkezleriOperasyonListeEkraniForm";
            this.Load += new System.EventHandler(this.IsMerkezleriOperasyonListeEkraniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperasyonListele)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOperasyonSil;
        private System.Windows.Forms.Button btnOperasyonDuzenle;
        private System.Windows.Forms.Button btnOperasyonEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOperasyonListele;
    }
}