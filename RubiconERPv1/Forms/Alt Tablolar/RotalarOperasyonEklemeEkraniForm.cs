﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class RotalarOperasyonEklemeEkraniForm : Form
    {
        public RotalarOperasyonEklemeEkraniForm()
        {
            InitializeComponent();
        }

        private void RotalarOperasyonEklemeEkraniForm_Load(object sender, EventArgs e)
        {
            // Ekran boyutlarını al
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Formun konumunu ekranın köşesine ayarla
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}