using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Ana_Tablolar
{
    public partial class MalzemeBilgileriForm : Form
    {
        public MalzemeBilgileriForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //khbhk
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MalzemeBilgileriForm2_Load(object sender, EventArgs e)
        {
            // Ekran boyutlarını al
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Formun konumunu ekranın köşesine ayarla
            this.Location = Screen.PrimaryScreen.Bounds.Location;

            // Formun ortasına yerleştirmek için hesaplama yap
            int x = (this.ClientSize.Width - dataGridView1.Width) / 2;
            int y = ((this.ClientSize.Height - dataGridView1.Height) / 2) + 100;

            // Konumu ayarla
            dataGridView1.Location = new Point(x, y);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}