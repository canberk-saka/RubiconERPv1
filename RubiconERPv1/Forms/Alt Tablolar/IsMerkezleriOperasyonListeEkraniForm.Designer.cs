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
            this.btnOperasyonListele = new System.Windows.Forms.Button();
            this.btnOperasyonIncele = new System.Windows.Forms.Button();
            this.btnOperasyonDuzenle = new System.Windows.Forms.Button();
            this.btnOperasyonEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtOperasyonListele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtOperasyonListele)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperasyonListele
            // 
            this.btnOperasyonListele.Location = new System.Drawing.Point(622, 113);
            this.btnOperasyonListele.Name = "btnOperasyonListele";
            this.btnOperasyonListele.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonListele.TabIndex = 13;
            this.btnOperasyonListele.Text = "Operasyon Listele";
            this.btnOperasyonListele.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonIncele
            // 
            this.btnOperasyonIncele.Location = new System.Drawing.Point(469, 113);
            this.btnOperasyonIncele.Name = "btnOperasyonIncele";
            this.btnOperasyonIncele.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonIncele.TabIndex = 12;
            this.btnOperasyonIncele.Text = "Operasyon İncele";
            this.btnOperasyonIncele.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonDuzenle
            // 
            this.btnOperasyonDuzenle.Location = new System.Drawing.Point(311, 113);
            this.btnOperasyonDuzenle.Name = "btnOperasyonDuzenle";
            this.btnOperasyonDuzenle.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonDuzenle.TabIndex = 11;
            this.btnOperasyonDuzenle.Text = "Operasyon Düzenle";
            this.btnOperasyonDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnOperasyonEkle
            // 
            this.btnOperasyonEkle.Location = new System.Drawing.Point(156, 113);
            this.btnOperasyonEkle.Name = "btnOperasyonEkle";
            this.btnOperasyonEkle.Size = new System.Drawing.Size(116, 50);
            this.btnOperasyonEkle.TabIndex = 10;
            this.btnOperasyonEkle.Text = "Operasyon Ekle";
            this.btnOperasyonEkle.UseVisualStyleBackColor = true;
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
            // dtOperasyonListele
            // 
            this.dtOperasyonListele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtOperasyonListele.Location = new System.Drawing.Point(156, 213);
            this.dtOperasyonListele.Name = "dtOperasyonListele";
            this.dtOperasyonListele.RowHeadersWidth = 51;
            this.dtOperasyonListele.RowTemplate.Height = 24;
            this.dtOperasyonListele.Size = new System.Drawing.Size(1286, 369);
            this.dtOperasyonListele.TabIndex = 7;
            // 
            // IsMerkezleriOperasyonListeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 697);
            this.Controls.Add(this.btnOperasyonListele);
            this.Controls.Add(this.btnOperasyonIncele);
            this.Controls.Add(this.btnOperasyonDuzenle);
            this.Controls.Add(this.btnOperasyonEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtOperasyonListele);
            this.Name = "IsMerkezleriOperasyonListeEkraniForm";
            this.Text = "IsMerkezleriOperasyonListeEkraniForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtOperasyonListele)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperasyonListele;
        private System.Windows.Forms.Button btnOperasyonIncele;
        private System.Windows.Forms.Button btnOperasyonDuzenle;
        private System.Windows.Forms.Button btnOperasyonEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtOperasyonListele;
    }
}