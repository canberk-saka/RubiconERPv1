using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class BSMGR0BOMDAL
    {
        private readonly string _connectionString;

        public BSMGR0BOMDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // BSMGR0BOMHEAD tablosuna veri ekleme
        public bool InsertBOMHead(
            string firmaKodu, string urunAgaciTipi, string urunAgaciKodu,
            DateTime gecerlilikBaslangic, DateTime gecerlilikBitis,
            string malzemeTipi, string malzemeKodu, decimal temelMiktar)
        {
            try
            {
                string query = @"
                    INSERT INTO BSMGR0BOMHEAD
                    (COMCODE, BOMDOCTYPE, BOMDOCNUM, BOMDOCFROM, BOMDOCUNTIL, MATDOCTYPE, MATDOCNUM, QUANTITY)
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
                MessageBox.Show($"BOM başlık verisi eklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        COMCODE AS 'Firma Kodu',
                        BOMDOCTYPE AS 'Ürün Ağacı Tipi',
                        BOMDOCNUM AS 'Ürün Ağacı Kodu',
                        BOMDOCFROM AS 'Geçerlilik Başlangıç',
                        BOMDOCUNTIL AS 'Geçerlilik Bitiş',
                        MATDOCTYPE AS 'Malzeme Tipi',
                        MATDOCNUM AS 'Malzeme Kodu',
                        QUANTITY AS 'Temel Miktar',
                        ISDELETED AS 'Silindi Mi?',
                        ISPASSIVE AS 'Pasif Mi?',
                        DRAWNUM AS 'Açıklama'
                        
                    FROM 
                        BSMGR0BOMHEAD;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable); // Fill the DataTable with query result
                }
                catch (Exception ex)
                {
                    throw new Exception($"Veri çekme sırasında hata oluştu: {ex.Message}");
                }

                return dataTable;
            }
        }

        public DataTable GetFilteredData(
     string firmaKodu,
     string urunAgaciTipi,
     string malzemeTipi,
     string malzemeKodu,
     string urunAgaciKodu,
     DateTime? baslangicTarihi,
     DateTime? bitisTarihi,
     string silindiMi,
     string pasifMi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Base SQL query
                string query = @"
        SELECT 
            h.COMCODE AS 'Firma Kodu',
            h.BOMDOCTYPE AS 'Ürün Ağacı Tipi',
            h.BOMDOCNUM AS 'Ürün Ağacı Kodu',
            h.BOMDOCFROM AS 'Geçerlilik Başlangıç',
            h.BOMDOCUNTIL AS 'Geçerlilik Bitiş',
            h.MATDOCTYPE AS 'Malzeme Tipi',
            h.MATDOCNUM AS 'Malzeme Kodu',
            h.QUANTITY AS 'Temel Miktar',
            h.ISDELETED AS 'Silindi Mi?',
            h.ISPASSIVE AS 'Pasif Mi?',
            h.DRAWNUM AS 'Açıklama'  -- Fixed the column alias for 'Çizim Numarası'
        FROM 
            BSMGR0BOMHEAD h
        WHERE 1 = 1"; // This is a basic WHERE condition that will always be true

                // Add filters based on the provided parameters
                if (!string.IsNullOrEmpty(firmaKodu)) query += " AND h.COMCODE = @firmaKodu";
                if (!string.IsNullOrEmpty(urunAgaciTipi)) query += " AND h.BOMDOCTYPE = @urunAgaciTipi";
                if (!string.IsNullOrEmpty(malzemeTipi)) query += " AND h.MATDOCTYPE = @malzemeTipi";
                if (!string.IsNullOrEmpty(malzemeKodu)) query += " AND h.MATDOCNUM = @malzemeKodu";
                if (!string.IsNullOrEmpty(urunAgaciKodu)) query += " AND h.BOMDOCNUM = @urunAgaciKodu";
                if (baslangicTarihi.HasValue) query += " AND h.BOMDOCFROM >= @baslangicTarihi";
                if (bitisTarihi.HasValue) query += " AND h.BOMDOCUNTIL <= @bitisTarihi";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND h.ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND h.ISPASSIVE = @pasifMi";

                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the command based on the filters
                if (!string.IsNullOrEmpty(firmaKodu)) command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                if (!string.IsNullOrEmpty(urunAgaciTipi)) command.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                if (!string.IsNullOrEmpty(malzemeTipi)) command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                if (!string.IsNullOrEmpty(malzemeKodu)) command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                if (!string.IsNullOrEmpty(urunAgaciKodu)) command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);
                if (baslangicTarihi.HasValue) command.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.Value.Date);
                if (bitisTarihi.HasValue) command.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.Value.Date);
                if (!string.IsNullOrEmpty(silindiMi)) command.Parameters.AddWithValue("@silindiMi", silindiMi);
                if (!string.IsNullOrEmpty(pasifMi)) command.Parameters.AddWithValue("@pasifMi", pasifMi);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable result = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return result;
            }
        }



        // Method to retrieve data from any control table
        public DataTable GetControlTableData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query dynamically selects all columns from the specified table
                string query = $"SELECT * FROM {tableName}";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable); // Fill the DataTable with data from the query
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during data retrieval
                    throw new Exception($"Veri çekme sırasında hata oluştu: {ex.Message}");
                }

                return dataTable; // Return the populated DataTable
            }
        }


        public bool UpdateBOM(
    string urunAgaciKodu,          // Ürün Ağacı Kodu
    string firmaKodu,              // Firma Kodu
    string urunAgaciTipi,          // Ürün Ağacı Tipi
    string malzemeTipi,            // Malzeme Tipi
    string malzemeKodu,            // Malzeme Kodu
    DateTime gecerlilikBaslangic,  // Geçerlilik Başlangıç
    DateTime gecerlilikBitis,      // Geçerlilik Bitiş
    string cizimNumarasi,          // Çizim Numarası
    string silindiMi,              // Silindi Mi? (0 veya 1)
    string pasifMi,                 // Pasif Mi? (0 veya 1)
    string temelMiktar
)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            UPDATE BSMGR0BOMHEAD
            SET 
                COMCODE = @firmaKodu,
                BOMDOCTYPE = @urunAgaciTipi,
                MATDOCTYPE = @malzemeTipi,
                MATDOCNUM = @malzemeKodu,
                BOMDOCFROM = @gecerlilikBaslangic,
                BOMDOCUNTIL = @gecerlilikBitis,
                DRAWNUM = @cizimNumarasi,
                ISDELETED = @silindiMi,
                ISPASSIVE = @pasifMi,
                QUANTITY = @temelMiktar
            WHERE BOMDOCNUM = @urunAgaciKodu";  // Ürün Ağacı Kodu'na göre güncelleme yapılır.

                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                command.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                command.Parameters.AddWithValue("@gecerlilikBaslangic", gecerlilikBaslangic);
                command.Parameters.AddWithValue("@gecerlilikBitis", gecerlilikBitis);
                command.Parameters.AddWithValue("@cizimNumarasi", cizimNumarasi);
                command.Parameters.AddWithValue("@silindiMi", silindiMi);
                command.Parameters.AddWithValue("@pasifMi", pasifMi);
                command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);
                command.Parameters.AddWithValue("@temelMiktar", temelMiktar);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();  // SQL komutunu çalıştır

                    // Eğer güncelleme işlemi başarılı olduysa, rowsAffected > 0 olacaktır.
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Hata durumunda exception fırlat
                    MessageBox.Show($"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool InsertBOM(
    string urunAgaciKodu,          // Ürün Ağacı Kodu
    string firmaKodu,              // Firma Kodu
    string urunAgaciTipi,          // Ürün Ağacı Tipi
    string malzemeTipi,            // Malzeme Tipi
    string malzemeKodu,            // Malzeme Kodu
    DateTime gecerlilikBaslangic,  // Geçerlilik Başlangıç
    DateTime gecerlilikBitis,      // Geçerlilik Bitiş
    string cizimNumarasi,          // Çizim Numarası
    string silindiMi,              // Silindi Mi? (0 veya 1)
    string pasifMi                 // Pasif Mi? (0 veya 1)
)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO BSMGR0BOMHEAD (
                COMCODE,
                BOMDOCTYPE,
                MATDOCTYPE,
                MATDOCNUM,
                BOMDOCFROM,
                BOMDOCUNTIL,
                DRAWNUM,
                ISDELETED,
                ISPASSIVE,
                BOMDOCNUM
            ) VALUES (
                @firmaKodu, 
                @urunAgaciTipi, 
                @malzemeTipi, 
                @malzemeKodu, 
                @gecerlilikBaslangic, 
                @gecerlilikBitis, 
                @cizimNumarasi, 
                @silindiMi, 
                @pasifMi, 
                @urunAgaciKodu
            )";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                command.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                command.Parameters.AddWithValue("@gecerlilikBaslangic", gecerlilikBaslangic);
                command.Parameters.AddWithValue("@gecerlilikBitis", gecerlilikBitis);
                command.Parameters.AddWithValue("@cizimNumarasi", cizimNumarasi);
                command.Parameters.AddWithValue("@silindiMi", silindiMi);
                command.Parameters.AddWithValue("@pasifMi", pasifMi);
                command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();  // SQL komutunu çalıştır

                    // Eğer ekleme işlemi başarılı olduysa, rowsAffected > 0 olacaktır.
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Hata durumunda exception fırlat
                    MessageBox.Show($"Ekleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public DataTable GetComponentData(string urunAgaciKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @" SELECT 
     MATDOCNUM AS 'Malzeme Kodu',              
     MATDOCTYPE AS 'Malzeme Tipi',              
     COMPBOMDOCNUM AS 'Ürün Ağacı Kodu', 
     COMPBOMDOCTYPE AS 'Ürün Ağacı Tipi'
 FROM 
     BSMGR0BOMCONTENT
 WHERE
     BOMDOCNUM = @urunAgaciKodu
";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable componentsTable = new DataTable();

                try
                {
                    // Veritabanı bağlantısını açıyoruz ve verileri çekiyoruz
                    connection.Open();
                    adapter.Fill(componentsTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Veritabanı bağlantısı otomatik olarak kapanacak
                return componentsTable;
            }
        }


        public DataTable GetBOMContentData(string urunAgaciKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                
                MATDOCNUM AS 'Malzeme Kodu',              
                MATDOCTYPE AS 'Malzeme Tipi',              
                COMPBOMDOCNUM AS 'Ürün Ağacı Kodu', 
                COMPBOMDOCTYPE AS 'Ürün Ağacı Tipi'
                
                
               FROM BSMGR0BOMCONTENT

WHERE 
                BOMDOCNUM = @urunAgaciKodu;";  

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
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

    


        public bool InsertBOMContent(
    string firmaKodu,          // Firma Kodu
    string maliyetMerkeziTipi, // Maliyet Merkezi Tipi
    string maliyetMerkeziKodu, // Maliyet Merkezi Kodu
    DateTime gecerlilikBaslangic,  // Geçerlilik Başlangıç
    DateTime gecerlilikBitis,      // Geçerlilik Bitiş
    string malzemeTipi,            // Malzeme Tipi
    string malzemeKodu,            // Malzeme Kodu
    int icerikNumarasi,            // İçerik Numarası
    string bilesenKodu,           // Bileşen Kodu
    string kalemUrunAgaciTipi,    // Kalem Ürün Ağacı Tipi
    string kalemUrunAgaciKodu,    // Kalem Ürün Ağacı Kodu
    decimal bilesenMiktari       // Bileşen Miktarı
)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO BSMGR0BOMCONTENT (
                COMCODE,
                BOMDOCTYPE,
                BOMDOCNUM,
                BOMDOCFROM,
                BOMDOCUNTIL,
                MATDOCTYPE,
                MATDOCNUM,
                CONTENTNUM,
                COMPONENT,
                COMPBOMDOCTYPE,
                COMPBOMDOCNUM,
                QUANTITY
            ) 
            VALUES (
                @firmaKodu, 
                @maliyetMerkeziTipi, 
                @maliyetMerkeziKodu, 
                @gecerlilikBaslangic, 
                @gecerlilikBitis, 
                @malzemeTipi, 
                @malzemeKodu, 
                @icerikNumarasi, 
                @bilesenKodu, 
                @kalemUrunAgaciTipi, 
                @kalemUrunAgaciKodu, 
                @bilesenMiktari
            )";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
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

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();  // SQL komutunu çalıştır

                    // Eğer kayıt başarıyla eklendiyse, rowsAffected > 0 olacaktır.
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Hata durumunda exception fırlat
                    MessageBox.Show($"Veri eklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public DataTable GetUrunAgaciDetails(string urunAgaciKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                h.COMCODE AS 'Firma Kodu',
                h.BOMDOCTYPE AS 'Ürün Ağacı Tipi',
                h.BOMDOCNUM AS 'Ürün Ağacı Kodu',
                h.BOMDOCFROM AS 'Geçerlilik Başlangıç',
                h.BOMDOCUNTIL AS 'Geçerlilik Bitiş',
                h.MATDOCTYPE AS 'Malzeme Tipi',
                h.MATDOCNUM AS 'Malzeme Kodu',
                h.QUANTITY AS 'Temel Miktar',
                h.ISDELETED AS 'Silindi Mi?',
                h.ISPASSIVE AS 'Pasif Mi?',
                h.DRAWNUM AS 'Açıklama'
            FROM 
                BSMGR0BOMHEAD h
            WHERE 
                h.BOMDOCNUM = @urunAgaciKodu";

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
                    MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dataTable;
            }
        }

      


        // Silme işlemi (BOMHEAD ve BOMCONTENT)
        public bool DeleteBOM(string urunAgaciKodu)
        {
            try
            {
                // SQL sorgusu ile BSMGR0BOMHEAD ve BSMGR0BOMCONTENT tablosundan belirtilen ürünü sil
                string deleteQuery = @"
                    DELETE FROM BSMGR0BOMHEAD WHERE BOMDOCNUM = @urunAgaciKodu;
                    DELETE FROM BSMGR0BOMCONTENT WHERE BOMDOCNUM = @urunAgaciKodu;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri silme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
