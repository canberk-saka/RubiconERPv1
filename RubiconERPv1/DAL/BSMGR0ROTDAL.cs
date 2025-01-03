using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class BSMGR0ROTDAL
    {
        private readonly string _connectionString;

        public BSMGR0ROTDAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DataTable GetRotalarOperasyon(string rotaNumarasi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
    r.COMCODE AS 'Firma Kodu',
    r.ROTDOCTYPE AS 'Rota Tipi',
    r.ROTDOCNUM AS 'Rota Numarası',
    r.ROTDOCFROM AS 'Geçerlilik Başlangıç',
    r.ROTDOCUNTIL AS 'Geçerlilik Bitiş',
    r.MATDOCTYPE AS 'Malzeme Tipi',
    r.MATDOCNUM AS 'Malzeme Kodu',
    r.OPRNUM AS 'Operasyon Numarası',
    r.WCMDOCTYPE AS 'İş Merkezi Tipi',
    r.WCMDOCNUM AS 'İş Merkezi Kodu',
    r.OPRDOCTYPE AS 'Operasyon Kodu',
rt.DOCTYPETEXT AS 'Operasyon Tipi Açıklaması',  
    r.SETUPTIME AS 'Operasyon Hazırlık Süresi(Saat)',
    r.MACHINETIME AS 'Operasyon Makine Süresi(Saat)',
    r.LABOURTIME AS 'Operasyon İşçilik Süresi(Saat)'
    
FROM 
    BSMGR0ROTOPRCONTENT r
LEFT JOIN 
    BSMGR0ROT003 rt ON r.OPRDOCTYPE = rt.DOCTYPE  -- Operasyon Kodu ile Operasyon Tipi eşleşiyor
WHERE 
    r.ROTDOCNUM = @rotaNumarasi;"
;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rotaNumarasi", rotaNumarasi);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

        public DataTable GetRotalarBom(string rotaNumarasi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                r.COMCODE AS 'Firma Kodu',
                r.ROTDOCTYPE AS 'Rota Tipi',
                r.ROTDOCNUM AS 'Rota Numarası',
                r.ROTDOCFROM AS 'Geçerlilik Başlangıç',
                r.ROTDOCUNTIL AS 'Geçerlilik Bitiş',
                r.MATDOCTYPE AS 'Malzeme Tipi',
                r.MATDOCNUM AS 'Malzeme Kodu',
                r.QUANTITY AS 'Bileşen Miktarı',
                r.OPRNUM AS 'Operasyon Numarası'
                
            FROM 
                BSMGR0ROTBOMCONTENT r
            WHERE 
                r.ROTDOCNUM = @rotaNumarasi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rotaNumarasi", rotaNumarasi);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }





        // Rotaların tüm verilerini çeker
        public DataTable GetAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        COMCODE AS 'Firma Kodu',
                        ROTDOCTYPE AS 'Ürün Ağacı Tipi',
                        ROTDOCNUM AS 'Ürün Ağacı Kodu',
                        ROTDOCFROM AS 'Geçerlilik Başlangıç',
                        ROTDOCUNTIL AS 'Geçerlilik Bitiş',
                        MATDOCTYPE AS 'Malzeme Tipi',
                        MATDOCNUM AS 'Malzeme Kodu',
                        QUANTITY AS 'Temel Miktar',
                        ISDELETED AS 'Silindi Mi?',
                        ISPASSIVE AS 'Pasif Mi?',
                        DRAWNUM AS 'Rota Numarası'
                    FROM 
                        BSMGR0ROTHEAD;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable); // Veriyi DataTable'a al
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

        // Rota güncelleme metodu
        public bool UpdateRota(string urunAgaciKodu, string firmaKodu, string urunAgaciTipi, string malzemeTipi, string malzemeKodu,
                               DateTime gecerlilikBaslangic, DateTime gecerlilikBitis, string silindiMi, string pasifMi, decimal temelMiktar)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE BSMGR0BOMHEAD
                    SET 
                        COMCODE = @FirmaKodu,
                        BOMDOCTYPE = @UrunAgaciTipi,
                        MATDOCTYPE = @MalzemeTipi,
                        MATDOCNUM = @MalzemeKodu,
                        BOMDOCFROM = @GecerlilikBaslangic,
                        BOMDOCUNTIL = @GecerlilikBitis,
                        ISDELETED = @SilindiMi,
                        ISPASSIVE = @PasifMi,
                        QUANTITY = @TemelMiktar
                    WHERE BOMDOCNUM = @UrunAgaciKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UrunAgaciKodu", urunAgaciKodu);
                command.Parameters.AddWithValue("@FirmaKodu", firmaKodu);
                command.Parameters.AddWithValue("@UrunAgaciTipi", urunAgaciTipi);
                command.Parameters.AddWithValue("@MalzemeTipi", malzemeTipi);
                command.Parameters.AddWithValue("@MalzemeKodu", malzemeKodu);
                command.Parameters.AddWithValue("@GecerlilikBaslangic", gecerlilikBaslangic);
                command.Parameters.AddWithValue("@GecerlilikBitis", gecerlilikBitis);
                command.Parameters.AddWithValue("@SilindiMi", silindiMi);
                command.Parameters.AddWithValue("@PasifMi", pasifMi);
                command.Parameters.AddWithValue("@TemelMiktar", temelMiktar);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Eğer 0'dan fazla satır güncellenirse başarılı demektir
                }
                catch (Exception ex)
                {
                    // Hata durumunda loglama veya hata mesajı dönebilirsiniz
                    Console.WriteLine($"Hata: {ex.Message}");
                    return false;
                }
            }
        }

        public DataTable GetRotaDetails(string rotaNumarasi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                r.COMCODE AS 'Firma Kodu',
                r.ROTDOCNUM AS 'Ürün Ağacı Kodu',
                r.ROTDOCFROM AS 'Geçerlilik Başlangıç',
                r.ROTDOCUNTIL AS 'Geçerlilik Bitiş',
                r.MATDOCTYPE AS 'Malzeme Tipi',
                r.MATDOCNUM AS 'Malzeme Kodu',
                r.QUANTITY AS 'Temel Miktar',
                r.ISDELETED AS 'Silindi Mi?',
                r.ISPASSIVE AS 'Pasif Mi?',
                r.DRAWNUM AS 'Çizim Numarası'
            FROM 
                BSMGR0ROTHEAD r
            WHERE 
                r.ROTDOCNUM = @rotaNumarasi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rotaNumarasi", rotaNumarasi);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }



        // Ürün ağacı koduna göre rota kaydını siler
        public bool DeleteRota(string urunAgaciKodu)
        {
            try
            {
                string query = @"
                    DELETE FROM BSMGR0ROTHEAD WHERE ROTDOCNUM = @urunAgaciKodu;
                    DELETE FROM BSMGR0ROTOPRCONTENT WHERE ROTDOCNUM = @urunAgaciKodu;
                    DELETE FROM BSMGR0ROTBOMCONTENT WHERE ROTDOCNUM = @urunAgaciKodu;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();  // SQL komutunu çalıştır

                    return rowsAffected > 0;  // Satır silinmişse başarılı
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Eğer hata olursa, işlem başarısız olur
            }
        }

        public DataTable GetControlTableData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Dinamik bir SQL sorgusu oluşturuyoruz
                string query = $"SELECT * FROM {tableName};";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);  // Veriyi DataTable'a al
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

        // Filtreli verileri çeker
        public DataTable GetFilteredData(string firmaKodu, string silindiMi, string pasifMi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Filtreleme için SQL sorgusunu oluşturuyoruz
                string query = @"
                    SELECT 
                        COMCODE AS 'Firma Kodu',
                        ROTDOCTYPE AS 'Ürün Ağacı Tipi',
                        ROTDOCNUM AS 'Ürün Ağacı Kodu',
                        ROTDOCFROM AS 'Geçerlilik Başlangıç',
                        ROTDOCUNTIL AS 'Geçerlilik Bitiş',
                        MATDOCTYPE AS 'Malzeme Tipi',
                        MATDOCNUM AS 'Malzeme Kodu',
                        QUANTITY AS 'Temel Miktar',
                        ISDELETED AS 'Silindi Mi?',
                        ISPASSIVE AS 'Pasif Mi?',
                        DRAWNUM AS 'Rota Numarası'
                    FROM 
                        BSMGR0ROTHEAD
                    WHERE 1=1";  // Bu, tüm satırları almak için bir temel sorgudur.

                // Parametreleri ekliyoruz
                if (!string.IsNullOrEmpty(firmaKodu)) query += " AND COMCODE = @firmaKodu";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND ISPASSIVE = @pasifMi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firmaKodu", firmaKodu ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@silindiMi", silindiMi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@pasifMi", pasifMi ?? (object)DBNull.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable resultTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(resultTable);  // Sonuçları al
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return resultTable;
            }
        }

        // Rota Başlık Verisini Ekler (BSMGR0ROTHEAD)
        public bool InsertRotaHead(
            string firmaKodu, string urunAgaciTipi, string urunAgaciKodu,
            DateTime gecerlilikBaslangic, DateTime gecerlilikBitis,
            string malzemeTipi, string malzemeKodu, decimal temelMiktar)
        {
            try
            {
                string query = @"
                    INSERT INTO BSMGR0ROTHEAD
                    (COMCODE, ROTDOCTYPE, ROTDOCNUM, ROTDOCFROM, ROTDOCUNTIL, MATDOCTYPE, MATDOCNUM, QUANTITY)
                    VALUES
                    (@firmaKodu, @urunAgaciTipi, @urunAgaciKodu, @gecerlilikBaslangic, @gecerlilikBitis, @malzemeTipi, @malzemeKodu, @temelMiktar)";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    command.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                    command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);
                    command.Parameters.AddWithValue("@gecerlilikBaslangic", gecerlilikBaslangic);
                    command.Parameters.AddWithValue("@gecerlilikBitis", gecerlilikBitis);
                    command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                    command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                    command.Parameters.AddWithValue("@temelMiktar", temelMiktar);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rota başlık verisi eklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Rota Başlık Verilerini Getir (BSMGR0ROTHEAD)
        public DataTable GetRotaHeadData(string urunAgaciKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        COMCODE AS 'Firma Kodu',
                        ROTDOCTYPE AS 'Ürün Ağacı Tipi',
                        ROTDOCNUM AS 'Ürün Ağacı Kodu',
                        ROTDOCFROM AS 'Geçerlilik Başlangıç',
                        ROTDOCUNTIL AS 'Geçerlilik Bitiş',
                        MATDOCTYPE AS 'Malzeme Tipi',
                        MATDOCNUM AS 'Malzeme Kodu',
                        QUANTITY AS 'Temel Miktar'
                    FROM 
                        BSMGR0ROTHEAD
                    WHERE
                        ROTDOCNUM = @urunAgaciKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

        // Rota İçeriği Verisini Ekler (BSMGR0ROTOPRCONTENT)
        public bool InsertRotaContent(
            string firmaKodu, string maliyetMerkeziTipi, string maliyetMerkeziKodu,
            DateTime gecerlilikBaslangic, DateTime gecerlilikBitis,
            string malzemeTipi, string malzemeKodu, int icerikNumarasi,
            string bilesenKodu, string kalemUrunAgaciTipi, string kalemUrunAgaciKodu, decimal bilesenMiktari)
        {
            try
            {
                string query = @"
                    INSERT INTO BSMGR0ROTOPRCONTENT
                    (COMCODE, ROTDOCTYPE, ROTDOCNUM, ROTDOCFROM, ROTDOCUNTIL, MATDOCTYPE, MATDOCNUM, CONTENTNUM, COMPONENT, COMPBOMDOCTYPE, COMPBOMDOCNUM, QUANTITY)
                    VALUES
                    (@firmaKodu, @maliyetMerkeziTipi, @maliyetMerkeziKodu, @gecerlilikBaslangic, @gecerlilikBitis, @malzemeTipi, @malzemeKodu, @icerikNumarasi, @bilesenKodu, @kalemUrunAgaciTipi, @kalemUrunAgaciKodu, @bilesenMiktari)";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    command.Parameters.AddWithValue("@maliyetMerkeziTipi", maliyetMerkeziTipi);
                    command.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);
                    command.Parameters.AddWithValue("@gecerlilikBaslangic", gecerlilikBaslangic);
                    command.Parameters.AddWithValue("@gecerlilikBitis", gecerlilikBitis);
                    command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                    command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                    command.Parameters.AddWithValue("@icerikNumarasi", icerikNumarasi);
                    command.Parameters.AddWithValue("@bilesenKodu", bilesenKodu);
                    command.Parameters.AddWithValue("@kalemUrunAgaciTipi", kalemUrunAgaciTipi);
                    command.Parameters.AddWithValue("@kalemUrunAgaciKodu", kalemUrunAgaciKodu);
                    command.Parameters.AddWithValue("@bilesenMiktari", bilesenMiktari);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rota içerik verisi eklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Rota İçeriği Verilerini Getir (BSMGR0ROTOPRCONTENT)
        public DataTable GetRotaContentData(string urunAgaciKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        COMCODE AS 'Firma Kodu',
                        ROTDOCTYPE AS 'Ürün Ağacı Tipi',
                        ROTDOCNUM AS 'Ürün Ağacı Kodu',
                        MATDOCTYPE AS 'Malzeme Tipi',
                        MATDOCNUM AS 'Malzeme Kodu',
                        QUANTITY AS 'Bileşen Miktarı'
                    FROM 
                        BSMGR0ROTOPRCONTENT
                    WHERE
                        ROTDOCNUM = @urunAgaciKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }
    }
}
