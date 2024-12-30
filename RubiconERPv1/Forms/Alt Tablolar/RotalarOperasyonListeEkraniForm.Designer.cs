namespace RubiconERPv1.Forms.Alt_Tablolar
{
    partial class RotalarOperasyonListeEkraniForm
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
            this.btnOperasyonIncele = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOperasyonDuzenle = new System.Windows.Forms.Button();
            this.btnOperasyonEkle = new System.Windows.Forms.Button();
            this.btnOperasyonListele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperasyonIncele
            // 
            this.btnOperasyonIncele.Location = new System.Drawing.Point(226, 94);
            this.btnOperasyonIncele.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperasyonIncele.Name = "btnOperasyonIncele";
            this.btnOperasyonIncele.Size = new System.Drawing.Size(110, 41);
            this.btnOperasyonIncele.TabIndex = 10;
            this.btnOperasyonIncele.Text = "Operasyon İncele";
            this.btnOperasyonIncele.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(96, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operasyon Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(100, 175);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(964, 300);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnOperasyonDuzenle
            // 
            this.btnOperasyonDuzenle.Location = new System.Drawing.Point(100, 94);
            this.btnOperasyonDuzenle.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperasyonDuzenle.Name = "btnOperasyonDuzenle";
            this.btnOperasyonDuzenle.Size = new System.Drawing.Size(110, 41);
            this.btnOperasyonDuzenle.TabIndex = 13;
            this.btnOperasyonDuzenle.Text = "Operasyon Düzenle";
            this.btnOperasyonDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonEkle
            // 
            this.btnOperasyonEkle.Location = new System.Drawing.Point(352, 94);
            this.btnOperasyonEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperasyonEkle.Name = "btnOperasyonEkle";
            this.btnOperasyonEkle.Size = new System.Drawing.Size(110, 41);
            this.btnOperasyonEkle.TabIndex = 14;
            this.btnOperasyonEkle.Text = "Operasyon Ekle";
            this.btnOperasyonEkle.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonListele
            // 
            this.btnOperasyonListele.Location = new System.Drawing.Point(485, 94);
            this.btnOperasyonListele.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperasyonListele.Name = "btnOperasyonListele";
            this.btnOperasyonListele.Size = new System.Drawing.Size(110, 41);
            this.btnOperasyonListele.TabIndex = 15;
            this.btnOperasyonListele.Text = "Operasyon Listele";
            this.btnOperasyonListele.UseVisualStyleBackColor = true;
            // 
            // RotalarOperasyonListeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 553);
            this.Controls.Add(this.btnOperasyonListele);
            this.Controls.Add(this.btnOperasyonEkle);
            this.Controls.Add(this.btnOperasyonDuzenle);
            this.Controls.Add(this.btnOperasyonIncele);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RotalarOperasyonListeEkraniForm";
            this.Text = "RotalarOperasyonListeEkraniForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperasyonIncele;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOperasyonDuzenle;
        private System.Windows.Forms.Button btnOperasyonEkle;
        private System.Windows.Forms.Button btnOperasyonListele;
    }
}