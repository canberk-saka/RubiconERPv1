namespace RubiconERPv1.Forms.Alt_Tablolar
{
    partial class UrunAgaclariComponentEkraniForm
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
            this.dgvUrunAgaciBilesenListesi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnIncele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunAgaciBilesenListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUrunAgaciBilesenListesi
            // 
            this.dgvUrunAgaciBilesenListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunAgaciBilesenListesi.Location = new System.Drawing.Point(43, 229);
            this.dgvUrunAgaciBilesenListesi.Name = "dgvUrunAgaciBilesenListesi";
            this.dgvUrunAgaciBilesenListesi.RowHeadersWidth = 51;
            this.dgvUrunAgaciBilesenListesi.RowTemplate.Height = 24;
            this.dgvUrunAgaciBilesenListesi.Size = new System.Drawing.Size(1286, 369);
            this.dgvUrunAgaciBilesenListesi.TabIndex = 0;
            this.dgvUrunAgaciBilesenListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunAgaciBilesenListesi_CellClick);
            this.dgvUrunAgaciBilesenListesi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunAgaciBilesenListesi_CellContentClick);
            this.dgvUrunAgaciBilesenListesi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunAgaciBilesenListesi_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(38, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Ağacı Bileşen Listesi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1213, 627);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Patlat";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(43, 129);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(116, 50);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Bileşen Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(201, 129);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(116, 50);
            this.btnDuzenle.TabIndex = 4;
            this.btnDuzenle.Text = "Bileşen Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnIncele
            // 
            this.btnIncele.Location = new System.Drawing.Point(377, 129);
            this.btnIncele.Name = "btnIncele";
            this.btnIncele.Size = new System.Drawing.Size(116, 50);
            this.btnIncele.TabIndex = 5;
            this.btnIncele.Text = "Bileşen İncele";
            this.btnIncele.UseVisualStyleBackColor = true;
            // 
            // UrunAgaclariComponentEkraniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 727);
            this.Controls.Add(this.btnIncele);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUrunAgaciBilesenListesi);
            this.Name = "UrunAgaclariComponentEkraniForm";
            this.Text = "UrunAgaclariComponentEkraniForm";
            this.Load += new System.EventHandler(this.UrunAgaclariComponentEkraniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunAgaciBilesenListesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunAgaciBilesenListesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnIncele;
    }
}