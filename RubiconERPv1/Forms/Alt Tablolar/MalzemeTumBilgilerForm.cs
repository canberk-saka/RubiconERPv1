using System;
using System.Data;
using System.Windows.Forms;

namespace RubiconERPv1.Forms.Alt_Tablolar
{
    public partial class MalzemeTumBilgilerForm : Form
    {
        public MalzemeTumBilgilerForm()
        {
            InitializeComponent();
        }

        private void MalzemeTumBilgilerForm_Load(object sender, EventArgs e)
        {
            // Ekran boyutlarını al
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Formun konumunu ekranın köşesine ayarla
            this.Location = Screen.PrimaryScreen.Bounds.Location;
        }

        public void LoadMaterialDetails(DataTable materialDetails)
        {
            try
            {
                if (materialDetails.Rows.Count > 0)
                {
                    DataRow row = materialDetails.Rows[0];

                    // Firma Kodu
                    if (cbFirmaKodu.DataSource != null)
                    {
                        cbFirmaKodu.SelectedValue = row["Firma Kodu"].ToString();
                    }
                    else
                    {
                        cbFirmaKodu.SelectedIndex = -1;
                    }

                    // Malzeme Tipi
                    if (cmbMalzemeTipi.DataSource != null)
                    {
                        cmbMalzemeTipi.SelectedValue = row["Malzeme Tipi"].ToString();
                    }
                    else
                    {
                        cmbMalzemeTipi.SelectedIndex = -1;
                    }

                    // Malzeme Kodu
                    txtMalzemeKodu.Text = row["Malzeme Kodu"].ToString();

                    // Geçerlilik Başlangıç
                    if (DateTime.TryParse(row["Geçerlilik Başlangıç"].ToString(), out DateTime startDate))
                        dtpGecerlilikBaslangicTarihi.Value = startDate;

                    // Geçerlilik Bitiş
                    if (DateTime.TryParse(row["Geçerlilik Bitiş"].ToString(), out DateTime endDate))
                        dtpGecerlilikBitisTarihi.Value = endDate;

                    // Malzeme Kısa Açıklama
                    txtMalzemeKisaAciklamasi.Text = row["Malzeme Kısa Açıklama"].ToString();

                    // Malzeme Uzun Açıklama
                    txtMalzemeUzunAciklamasi.Text = row["Malzeme Uzun Açıklama"].ToString();

                    // Dil Kodu
                    if (cmbDilKodu.DataSource != null)
                    {
                        cmbDilKodu.SelectedValue = row["Dil Kodu"].ToString();
                    }
                    else
                    {
                        cmbDilKodu.SelectedIndex = -1;
                    }

                    // Tedarik Tipi
                    if (cmbTedarikTipi.DataSource != null)
                    {
                        cmbTedarikTipi.SelectedValue = row["Tedarik Tipi"].ToString();
                    }
                    else
                    {
                        cmbTedarikTipi.SelectedIndex = -1;
                    }

                    // Malzeme Stok Birimi
                    if (cmbMalzemeStokBirimi.DataSource != null)
                    {
                        cmbMalzemeStokBirimi.SelectedValue = row["Malzeme Stok Birimi"].ToString();
                    }
                    else
                    {
                        cmbMalzemeStokBirimi.SelectedIndex = -1;
                    }

                    // Net Ağırlık
                    txtNetAgirlik.Text = row["Net Ağırlık"].ToString();

                    // Net Ağırlık Birimi
                    if (cmbNetAgirlikBirimi.DataSource != null)
                    {
                        cmbNetAgirlikBirimi.SelectedValue = row["Net Ağırlık Birimi"].ToString();
                    }
                    else
                    {
                        cmbNetAgirlikBirimi.SelectedIndex = -1;
                    }

                    // Brüt Ağırlık
                    txtBrutAgirlik.Text = row["Brüt Ağırlık"].ToString();

                    // Brüt Ağırlık Birimi
                    if (cmbBrutAgirlikBirimi.DataSource != null)
                    {
                        cmbBrutAgirlikBirimi.SelectedValue = row["Brüt Ağırlık Birimi"].ToString();
                    }
                    else
                    {
                        cmbBrutAgirlikBirimi.SelectedIndex = -1;
                    }

                    // Ürün Ağacı Var Mı?
                    if (cmbUrunAgaciVarMi.DataSource != null)
                    {
                        cmbUrunAgaciVarMi.SelectedValue = row["Ürün Ağacı Var Mı?"].ToString();
                    }
                    else
                    {
                        cmbUrunAgaciVarMi.SelectedIndex = -1;
                    }

                    // Ürün Ağacı Tipi
                    if (cmbUrunAgaciTipi.DataSource != null)
                    {
                        cmbUrunAgaciTipi.SelectedValue = row["Ürün Ağacı Tipi"].ToString();
                    }
                    else
                    {
                        cmbUrunAgaciTipi.SelectedIndex = -1;
                    }

                    // Ürün Ağacı Kodu
                    txtUrunAgaciKodu.Text = row["Ürün Ağacı Kodu"].ToString();

                    // Rota Var Mı?
                    if (cmbRotaVarMi.DataSource != null)
                    {
                        cmbRotaVarMi.SelectedValue = row["Rota Var Mı?"].ToString();
                    }
                    else
                    {
                        cmbRotaVarMi.SelectedIndex = -1;
                    }

                    // Rota Tipi
                    if (cmbRotaTipi.DataSource != null)
                    {
                        cmbRotaTipi.SelectedValue = row["Rota Tipi"].ToString();
                    }
                    else
                    {
                        cmbRotaTipi.SelectedIndex = -1;
                    }

                    // Rota Numarası
                    txtRotaNumarasi.Text = row["Rota Numarası"].ToString();

                    // Silindi Mi?
                    if (cmbSilindiMi.DataSource != null)
                    {
                        cmbSilindiMi.SelectedValue = row["Silindi Mi?"].ToString();
                    }
                    else
                    {
                        cmbSilindiMi.SelectedIndex = -1;
                    }

                    // Pasif Mi?
                    if (cmbPasifMi.DataSource != null)
                    {
                        cmbPasifMi.SelectedValue = row["Pasif Mi?"].ToString();
                    }
                    else
                    {
                        cmbPasifMi.SelectedIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen malzeme ile ilgili bilgi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
