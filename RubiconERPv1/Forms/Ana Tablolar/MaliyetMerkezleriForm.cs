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
    public partial class MaliyetMerkezleriForm : Form
    {
        public MaliyetMerkezleriForm()
        {
            InitializeComponent();
        }

        private void MaliyetMerkezleriForm_Load(object sender, EventArgs e)
        {
            // Ekran boyutlarını al
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Formun konumunu ekranın köşesine ayarla
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }

        private void groupBoxMaliyetMerkezi_Enter(object sender, EventArgs e)
        {

        }

        private void MaliyetMerkezleriForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}