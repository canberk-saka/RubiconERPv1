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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperasyonIncele
            // 
            this.btnOperasyonIncele.Location = new System.Drawing.Point(301, 116);
            this.btnOperasyonIncele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperasyonIncele.Name = "btnOperasyonIncele";
            this.btnOperasyonIncele.Size = new System.Drawing.Size(147, 50);
            this.btnOperasyonIncele.TabIndex = 10;
            this.btnOperasyonIncele.Text = "Operasyon İncele";
            this.btnOperasyonIncele.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(128, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operasyon Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(133, 215);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1285, 369);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnOperasyonDuzenle
            // 
            this.btnOperasyonDuzenle.Location = new System.Drawing.Point(133, 116);
            this.btnOperasyonDuzenle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperasyonDuzenle.Name = "btnOperasyonDuzenle";
            this.btnOperasyonDuzenle.Size = new System.Drawing.Size(147, 50);
            this.btnOperasyonDuzenle.TabIndex = 13;
            this.btnOperasyonDuzenle.Text = "Operasyon Düzenle";
            this.btnOperasyonDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonEkle
            // 
            this.btnOperasyonEkle.Location = new System.Drawing.Point(469, 116);
            this.btnOperasyonEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperasyonEkle.Name = "btnOperasyonEkle";
            this.btnOperasyonEkle.Size = new System.Drawing.Size(147, 50);
            this.btnOperasyonEkle.TabIndex = 14;
            this.btnOperasyonEkle.Text = "Operasyon Ekle";
            this.btnOperasyonEkle.UseVisualStyleBackColor = true;
            // 
            // RotalarOperasyonListeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 681);
            this.Controls.Add(this.btnOperasyonEkle);
            this.Controls.Add(this.btnOperasyonDuzenle);
            this.Controls.Add(this.btnOperasyonIncele);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}