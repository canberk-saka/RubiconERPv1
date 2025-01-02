namespace RubiconERPv1.Forms.Alt_Tablolar
{
    partial class UrunAgaclariComponentListelemeEkrani
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
            this.dgvComponentListele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentListele)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComponentListele
            // 
            this.dgvComponentListele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentListele.Location = new System.Drawing.Point(12, 29);
            this.dgvComponentListele.Name = "dgvComponentListele";
            this.dgvComponentListele.RowHeadersWidth = 51;
            this.dgvComponentListele.RowTemplate.Height = 24;
            this.dgvComponentListele.Size = new System.Drawing.Size(933, 406);
            this.dgvComponentListele.TabIndex = 0;
            this.dgvComponentListele.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponentListele_CellDoubleClick);
            // 
            // UrunAgaclariComponentListelemeEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 500);
            this.Controls.Add(this.dgvComponentListele);
            this.Name = "UrunAgaclariComponentListelemeEkrani";
            this.Text = "UrunAgaclariComponentListelemeEkrani";
            this.Load += new System.EventHandler(this.UrunAgaclariComponentListelemeEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentListele)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComponentListele;
    }
}