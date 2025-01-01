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
            this.btnMalzemeListele = new System.Windows.Forms.Button();
            this.btnMalzemeIncele = new System.Windows.Forms.Button();
            this.btnMalzemeDuzenle = new System.Windows.Forms.Button();
            this.btnMalzemeEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtMalzemeListele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtMalzemeListele)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMalzemeListele
            // 
            this.btnMalzemeListele.Location = new System.Drawing.Point(483, 100);
            this.btnMalzemeListele.Margin = new System.Windows.Forms.Padding(2);
            this.btnMalzemeListele.Name = "btnMalzemeListele";
            this.btnMalzemeListele.Size = new System.Drawing.Size(87, 41);
            this.btnMalzemeListele.TabIndex = 19;
            this.btnMalzemeListele.Text = "Malzeme Listele";
            this.btnMalzemeListele.UseVisualStyleBackColor = true;
            // 
            // btnMalzemeIncele
            // 
            this.btnMalzemeIncele.Location = new System.Drawing.Point(369, 100);
            this.btnMalzemeIncele.Margin = new System.Windows.Forms.Padding(2);
            this.btnMalzemeIncele.Name = "btnMalzemeIncele";
            this.btnMalzemeIncele.Size = new System.Drawing.Size(87, 41);
            this.btnMalzemeIncele.TabIndex = 18;
            this.btnMalzemeIncele.Text = "Malzeme İncele";
            this.btnMalzemeIncele.UseVisualStyleBackColor = true;
            // 
            // btnMalzemeDuzenle
            // 
            this.btnMalzemeDuzenle.Location = new System.Drawing.Point(250, 100);
            this.btnMalzemeDuzenle.Margin = new System.Windows.Forms.Padding(2);
            this.btnMalzemeDuzenle.Name = "btnMalzemeDuzenle";
            this.btnMalzemeDuzenle.Size = new System.Drawing.Size(87, 41);
            this.btnMalzemeDuzenle.TabIndex = 17;
            this.btnMalzemeDuzenle.Text = "Malzeme Düzenle";
            this.btnMalzemeDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnMalzemeEkle
            // 
            this.btnMalzemeEkle.Location = new System.Drawing.Point(134, 100);
            this.btnMalzemeEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnMalzemeEkle.Name = "btnMalzemeEkle";
            this.btnMalzemeEkle.Size = new System.Drawing.Size(87, 41);
            this.btnMalzemeEkle.TabIndex = 16;
            this.btnMalzemeEkle.Text = "Malzeme Ekle";
            this.btnMalzemeEkle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(130, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tüketilen Malzeme Listeleme Ekranı";
            // 
            // dtMalzemeListele
            // 
            this.dtMalzemeListele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMalzemeListele.Location = new System.Drawing.Point(134, 181);
            this.dtMalzemeListele.Margin = new System.Windows.Forms.Padding(2);
            this.dtMalzemeListele.Name = "dtMalzemeListele";
            this.dtMalzemeListele.RowHeadersWidth = 51;
            this.dtMalzemeListele.RowTemplate.Height = 24;
            this.dtMalzemeListele.Size = new System.Drawing.Size(964, 300);
            this.dtMalzemeListele.TabIndex = 14;
            // 
            // RotaOperasyonBomListelemeEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 529);
            this.Controls.Add(this.btnMalzemeListele);
            this.Controls.Add(this.btnMalzemeIncele);
            this.Controls.Add(this.btnMalzemeDuzenle);
            this.Controls.Add(this.btnMalzemeEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtMalzemeListele);
            this.Name = "RotaOperasyonBomListelemeEkraniForm";
            this.Text = "RotaOperasyonBomListelemeEkraniForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtMalzemeListele)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMalzemeListele;
        private System.Windows.Forms.Button btnMalzemeIncele;
        private System.Windows.Forms.Button btnMalzemeDuzenle;
        private System.Windows.Forms.Button btnMalzemeEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtMalzemeListele;
    }
}