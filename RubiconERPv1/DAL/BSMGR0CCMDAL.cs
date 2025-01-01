using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0CCMDAL
    {
        private readonly string _connectionString;

        public BSMGR0CCMDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Maliyet Merkezi Detaylarını Getir
        public DataTable GetMaterialDetails(string maliyetMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        h.COMCODE AS 'Firma Kodu',
                        h.CCMDOCTYPE AS 'Maliyet Merkezi Tipi',
                        h.CCMDOCNUM AS 'Maliyet Merkezi Kodu',
                        h.CCMDOCFROM AS 'Geçerlilik Başlangıç',
                        h.CCMDOCUNTIL AS 'Geçerlilik Bitiş',
                        t.CCMSTEXT AS 'Kısa Açıklama',
                        t.CCMLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINCCMDOCTYPE AS 'Ana Maliyet Merkezi Tipi',
                        h.MAINCCMDOCNUM AS 'Ana Maliyet Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0CCMHEAD h
                    INNER JOIN 
                        BSMGR0CCMTEXT t ON h.CCMDOCNUM = t.CCMDOCNUM
                    WHERE 
                        h.CCMDOCNUM = @maliyetMerkeziKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // Maliyet Merkezi Verilerini Getir (Filtreli)
        public DataTable GetFilteredData(string firma, string maliyetMerkeziTipi, string maliyetMerkeziKodu,
            string silindiMi, string pasifMi, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT 
                    h.COMCODE AS 'Firma Kodu',
                    h.CCMDOCTYPE AS 'Maliyet Merkezi Tipi',
                    h.CCMDOCNUM AS 'Maliyet Merkezi Kodu',
                    h.CCMDOCFROM AS 'Geçerlilik Başlangıç',
                    h.CCMDOCUNTIL AS 'Geçerlilik Bitiş',
                    t.CCMSTEXT AS 'Kısa Açıklama',
                    t.CCMLTEXT AS 'Uzun Açıklama',
                    t.LANCODE AS 'Dil Kodu',
                    h.MAINCCMDOCTYPE AS 'Ana Maliyet Merkezi Tipi',
                    h.MAINCCMDOCNUM AS 'Ana Maliyet Merkezi Kodu',
                    h.ISDELETED AS 'Silindi Mi?',
                    h.ISPASSIVE AS 'Pasif Mi?'
                FROM 
                    BSMGR0CCMHEAD h
                INNER JOIN 
                    BSMGR0CCMTEXT t ON h.CCMDOCNUM = t.CCMDOCNUM
                WHERE 
                    1 = 1";  // Başlangıçta her şey geçerli, filtreler eklenebilir

                // Filtrelere göre sorguya eklemeler
                if (!string.IsNullOrEmpty(firma)) query += " AND h.COMCODE = @firma";
                if (!string.IsNullOrEmpty(maliyetMerkeziTipi)) query += " AND h.CCMDOCTYPE = @maliyetMerkeziTipi";
                if (!string.IsNullOrEmpty(maliyetMerkeziKodu)) query += " AND h.CCMDOCNUM = @maliyetMerkeziKodu";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND h.ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND h.ISPASSIVE = @pasifMi";
                if (baslangicTarihi.HasValue) query += " AND h.CCMDOCFROM >= @baslangicTarihi";
                if (bitisTarihi.HasValue) query += " AND h.CCMDOCUNTIL <= @bitisTarihi";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametre ekle
                if (!string.IsNullOrEmpty(firma)) command.Parameters.AddWithValue("@firma", firma);
                if (!string.IsNullOrEmpty(maliyetMerkeziTipi)) command.Parameters.AddWithValue("@maliyetMerkeziTipi", maliyetMerkeziTipi);
                if (!string.IsNullOrEmpty(maliyetMerkeziKodu)) command.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);
                if (!string.IsNullOrEmpty(silindiMi)) command.Parameters.AddWithValue("@silindiMi", silindiMi);
                if (!string.IsNullOrEmpty(pasifMi)) command.Parameters.AddWithValue("@pasifMi", pasifMi);
                if (baslangicTarihi.HasValue) command.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.Value.Date); // Tarih formatı
                if (bitisTarihi.HasValue) command.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.Value.Date); // Tarih formatı

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // Bütün Maliyet Merkezi Verilerini Getir
        public DataTable GetAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT 
                    h.COMCODE AS 'Firma Kodu',
                    h.CCMDOCTYPE AS 'Maliyet Merkezi Tipi',
                    h.CCMDOCNUM AS 'Maliyet Merkezi Kodu',
                    h.CCMDOCFROM AS 'Geçerlilik Başlangıç',
                    h.CCMDOCUNTIL AS 'Geçerlilik Bitiş',
                    t.CCMSTEXT AS 'Kısa Açıklama',
                    t.CCMLTEXT AS 'Uzun Açıklama',
                    t.LANCODE AS 'Dil Kodu',
                    h.MAINCCMDOCTYPE AS 'Ana Maliyet Merkezi Tipi',
                    h.MAINCCMDOCNUM AS 'Ana Maliyet Merkezi Kodu',
                    h.ISDELETED AS 'Silindi Mi?',
                    h.ISPASSIVE AS 'Pasif Mi?'
                FROM 
                    BSMGR0CCMHEAD h
                INNER JOIN 
                    BSMGR0CCMTEXT t ON h.CCMDOCNUM = t.CCMDOCNUM";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public bool InsertCostCenter(string firmaKodu, string maliyetMerkeziTipi, string maliyetMerkeziKodu,
    DateTime? baslangicTarihi, DateTime? bitisTarihi, string anaMaliyetMerkeziTipi, string anaMaliyetMerkeziKodu,
    string silindiMi, string pasifMi, string kisaAciklama, string uzunAciklama, string dilKodu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
            INSERT INTO BSMGR0CCMHEAD
            (
                COMCODE, CCMDOCTYPE, CCMDOCNUM, CCMDOCFROM, CCMDOCUNTIL, MAINCCMDOCTYPE, MAINCCMDOCNUM, 
                ISDELETED, ISPASSIVE
            )
            VALUES
            (
                @firmaKodu, @maliyetMerkeziTipi, @maliyetMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
                @anaMaliyetMerkeziTipi, @anaMaliyetMerkeziKodu, @silindiMi, @pasifMi
            );

            INSERT INTO BSMGR0CCMTEXT
            (
                COMCODE, CCMDOCTYPE, CCMDOCNUM, CCMDOCFROM, CCMDOCUNTIL, LANCODE, CCMSTEXT, CCMLTEXT
            )
            VALUES
            (
                @firmaKodu, @maliyetMerkeziTipi, @maliyetMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
                @dilKodu, @kisaAciklama, @uzunAciklama
            )";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    command.Parameters.AddWithValue("@maliyetMerkeziTipi", maliyetMerkeziTipi);
                    command.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);
                    command.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@anaMaliyetMerkeziTipi", anaMaliyetMerkeziTipi);
                    command.Parameters.AddWithValue("@anaMaliyetMerkeziKodu", anaMaliyetMerkeziKodu);
                    command.Parameters.AddWithValue("@silindiMi", silindiMi);
                    command.Parameters.AddWithValue("@pasifMi", pasifMi);
                    command.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
                    command.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);
                    command.Parameters.AddWithValue("@dilKodu", dilKodu);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Eğer ekleme başarılıysa, true döner
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı döndür
                throw new Exception("Yeni maliyet merkezi eklenirken bir hata oluştu: " + ex.Message);
            }
        }


        // Maliyet Merkezi Güncelleme
        public bool UpdateCostCenter(string maliyetMerkeziKodu, string firmaKodu, string maliyetMerkeziTipi,
     string anaMaliyetMerkeziTipi, string anaMaliyetMerkeziKodu, string silindiMi, string pasifMi,
     DateTime? baslangicTarihi, DateTime? bitisTarihi, string kisaAciklama, string uzunAciklama, string dilKodu)
        {
            string updateCCMHeadQuery = @"
    UPDATE BSMGR0CCMHEAD
    SET
        COMCODE = @firmaKodu,
        CCMDOCTYPE = @maliyetMerkeziTipi,
        MAINCCMDOCTYPE = @anaMaliyetMerkeziTipi,
        MAINCCMDOCNUM = @anaMaliyetMerkeziKodu,
        ISDELETED = @silindiMi,
        ISPASSIVE = @pasifMi,
        CCMDOCFROM = @baslangicTarihi,
        CCMDOCUNTIL = @bitisTarihi
    WHERE
        CCMDOCNUM = @maliyetMerkeziKodu";

            string updateCCMTextQuery = @"
    UPDATE BSMGR0CCMTEXT
    SET
        CCMSTEXT = @kisaAciklama,
        CCMLTEXT = @uzunAciklama,
        LANCODE = @dilKodu
    WHERE
        CCMDOCNUM = @maliyetMerkeziKodu";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand commandCCMHead = new SqlCommand(updateCCMHeadQuery, connection))
                {
                    commandCCMHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    commandCCMHead.Parameters.AddWithValue("@maliyetMerkeziTipi", maliyetMerkeziTipi);
                    commandCCMHead.Parameters.AddWithValue("@anaMaliyetMerkeziTipi", anaMaliyetMerkeziTipi);
                    commandCCMHead.Parameters.AddWithValue("@anaMaliyetMerkeziKodu", anaMaliyetMerkeziKodu);
                    commandCCMHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                    commandCCMHead.Parameters.AddWithValue("@pasifMi", pasifMi);
                    commandCCMHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    commandCCMHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    commandCCMHead.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);

                    using (SqlCommand commandCCMText = new SqlCommand(updateCCMTextQuery, connection))
                    {
                        commandCCMText.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
                        commandCCMText.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);
                        commandCCMText.Parameters.AddWithValue("@dilKodu", dilKodu);
                        commandCCMText.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);

                        try
                        {
                            connection.Open();
                            // CCMHead güncellenmesi
                            int rowsAffectedCCMHead = commandCCMHead.ExecuteNonQuery();
                            // CCMText güncellenmesi
                            int rowsAffectedCCMText = commandCCMText.ExecuteNonQuery();

                            // Eğer her iki güncelleme başarılıysa, true döner
                            return rowsAffectedCCMHead > 0 && rowsAffectedCCMText > 0;
                        }
                        catch (Exception ex)
                        {
                            // Hata mesajı döndür
                            throw new Exception("Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
        }

        public bool DeleteCostCenter(string maliyetMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            DELETE FROM BSMGR0CCMHEAD WHERE CCMDOCNUM = @maliyetMerkeziKodu;
            DELETE FROM BSMGR0CCMTEXT WHERE CCMDOCNUM = @maliyetMerkeziKodu;
        ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@maliyetMerkeziKodu", maliyetMerkeziKodu);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Eğer silme işlemi başarılı olduysa true döner
                }
                catch (Exception ex)
                {
                    // Hata durumunda false döner
                    throw new Exception("Maliyet merkezi silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }



        // Kontrol Tablosu Verilerini Getir
        public DataTable GetControlTableData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }
    }
}
