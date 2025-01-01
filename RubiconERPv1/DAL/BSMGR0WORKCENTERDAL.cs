using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0WORKCENTERDAL
    {
        private readonly string _connectionString;

        public BSMGR0WORKCENTERDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Kontrol Tablosu Verilerini Almak İçin Kullanılan Metod
        public DataTable GetControlTableData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM {tableName}"; // Dinamik tablo adı kullanılarak sorgu oluşturuluyor.

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable); // Veritabanından veri çekiliyor
                }
                catch (Exception ex)
                {
                    // Hata durumunda, hata mesajı döndürülür
                    throw new Exception($"Veri çekme işlemi sırasında bir hata oluştu: {ex.Message}");
                }

                return dataTable; // DataTable geri döndürülür
            }
        }


        // İş Merkezi Detaylarını Getir
        public DataTable GetWorkCenterDetails(string isMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        h.COMCODE AS 'Firma Kodu',
                        h.WORKCENTERDOCTYPE AS 'İş Merkezi Tipi',
                        h.WORKCENTERDOCNUM AS 'İş Merkezi Kodu',
                        h.WORKCENTERDOCFROM AS 'Geçerlilik Başlangıç',
                        h.WORKCENTERDOCUNTIL AS 'Geçerlilik Bitiş',
                        t.WORKCENTERSTEXT AS 'Kısa Açıklama',
                        t.WORKCENTERLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINWORKCENTERDOCTYPE AS 'Ana İş Merkezi Tipi',
                        h.MAINWORKCENTERDOCNUM AS 'Ana İş Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0WORKCENTERHEAD h
                    INNER JOIN 
                        BSMGR0WORKCENTERTEXT t ON h.WORKCENTERDOCNUM = t.WORKCENTERDOCNUM
                    WHERE 
                        h.WORKCENTERDOCNUM = @isMerkeziKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // İş Merkezi Verilerini Getir (Filtreli)
        public DataTable GetFilteredData(string firma, string isMerkeziTipi, string isMerkeziKodu,
            string silindiMi, string pasifMi, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        h.COMCODE AS 'Firma Kodu',
                        h.WORKCENTERDOCTYPE AS 'İş Merkezi Tipi',
                        h.WORKCENTERDOCNUM AS 'İş Merkezi Kodu',
                        h.WORKCENTERDOCFROM AS 'Geçerlilik Başlangıç',
                        h.WORKCENTERDOCUNTIL AS 'Geçerlilik Bitiş',
                        t.WORKCENTERSTEXT AS 'Kısa Açıklama',
                        t.WORKCENTERLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINWORKCENTERDOCTYPE AS 'Ana İş Merkezi Tipi',
                        h.MAINWORKCENTERDOCNUM AS 'Ana İş Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0WORKCENTERHEAD h
                    INNER JOIN 
                        BSMGR0WORKCENTERTEXT t ON h.WORKCENTERDOCNUM = t.WORKCENTERDOCNUM
                    WHERE 
                        1 = 1"; // Başlangıçta her şey geçerli, filtreler eklenebilir

                // Filtrelere göre sorguya eklemeler
                if (!string.IsNullOrEmpty(firma)) query += " AND h.COMCODE = @firma";
                if (!string.IsNullOrEmpty(isMerkeziTipi)) query += " AND h.WORKCENTERDOCTYPE = @isMerkeziTipi";
                if (!string.IsNullOrEmpty(isMerkeziKodu)) query += " AND h.WORKCENTERDOCNUM = @isMerkeziKodu";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND h.ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND h.ISPASSIVE = @pasifMi";
                if (baslangicTarihi.HasValue) query += " AND h.WORKCENTERDOCFROM >= @baslangicTarihi";
                if (bitisTarihi.HasValue) query += " AND h.WORKCENTERDOCUNTIL <= @bitisTarihi";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametre ekle
                if (!string.IsNullOrEmpty(firma)) command.Parameters.AddWithValue("@firma", firma);
                if (!string.IsNullOrEmpty(isMerkeziTipi)) command.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                if (!string.IsNullOrEmpty(isMerkeziKodu)) command.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);
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

        // Bütün İş Merkezi Verilerini Getir
        public DataTable GetAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        h.COMCODE AS 'Firma Kodu',
                        h.WORKCENTERDOCTYPE AS 'İş Merkezi Tipi',
                        h.WORKCENTERDOCNUM AS 'İş Merkezi Kodu',
                        h.WORKCENTERDOCFROM AS 'Geçerlilik Başlangıç',
                        h.WORKCENTERDOCUNTIL AS 'Geçerlilik Bitiş',
                        t.WORKCENTERSTEXT AS 'Kısa Açıklama',
                        t.WORKCENTERLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINWORKCENTERDOCTYPE AS 'Ana İş Merkezi Tipi',
                        h.MAINWORKCENTERDOCNUM AS 'Ana İş Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0WORKCENTERHEAD h
                    INNER JOIN 
                        BSMGR0WORKCENTERTEXT t ON h.WORKCENTERDOCNUM = t.WORKCENTERDOCNUM";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // İş Merkezi Ekleme
        public bool InsertWorkCenter(string firmaKodu, string isMerkeziTipi, string isMerkeziKodu,
            DateTime? baslangicTarihi, DateTime? bitisTarihi, string anaIsMerkeziTipi, string anaIsMerkeziKodu,
            string silindiMi, string pasifMi, string kisaAciklama, string uzunAciklama, string dilKodu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
            INSERT INTO BSMGR0WORKCENTERHEAD
            (
                COMCODE, WORKCENTERDOCTYPE, WORKCENTERDOCNUM, WORKCENTERDOCFROM, WORKCENTERDOCUNTIL, MAINWORKCENTERDOCTYPE, MAINWORKCENTERDOCNUM, 
                ISDELETED, ISPASSIVE
            )
            VALUES
            (
                @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
                @anaIsMerkeziTipi, @anaIsMerkeziKodu, @silindiMi, @pasifMi
            );

            INSERT INTO BSMGR0WORKCENTERTEXT
            (
                COMCODE, WORKCENTERDOCTYPE, WORKCENTERDOCNUM, WORKCENTERDOCFROM, WORKCENTERDOCUNTIL, LANCODE, WORKCENTERSTEXT, WORKCENTERLTEXT
            )
            VALUES
            (
                @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
                @dilKodu, @kisaAciklama, @uzunAciklama
            )";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    command.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                    command.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);
                    command.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@anaIsMerkeziTipi", anaIsMerkeziTipi);
                    command.Parameters.AddWithValue("@anaIsMerkeziKodu", anaIsMerkeziKodu);
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
                throw new Exception("Yeni iş merkezi eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // İş Merkezi Güncelleme
        public bool UpdateWorkCenter(string isMerkeziKodu, string firmaKodu, string isMerkeziTipi,
     string anaIsMerkeziTipi, string anaIsMerkeziKodu, string silindiMi, string pasifMi,
     DateTime? baslangicTarihi, DateTime? bitisTarihi, string kisaAciklama, string uzunAciklama, string dilKodu)
        {
            string updateWorkCenterHeadQuery = @"
    UPDATE BSMGR0WORKCENTERHEAD
    SET
        COMCODE = @firmaKodu,
        WORKCENTERDOCTYPE = @isMerkeziTipi,
        MAINWORKCENTERDOCTYPE = @anaIsMerkeziTipi,
        MAINWORKCENTERDOCNUM = @anaIsMerkeziKodu,
        ISDELETED = @silindiMi,
        ISPASSIVE = @pasifMi,
        WORKCENTERDOCFROM = @baslangicTarihi,
        WORKCENTERDOCUNTIL = @bitisTarihi
    WHERE
        WORKCENTERDOCNUM = @isMerkeziKodu";

            string updateWorkCenterTextQuery = @"
    UPDATE BSMGR0WORKCENTERTEXT
    SET
        WORKCENTERSTEXT = @kisaAciklama,
        WORKCENTERLTEXT = @uzunAciklama,
        LANCODE = @dilKodu
    WHERE
        WORKCENTERDOCNUM = @isMerkeziKodu";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand commandWorkCenterHead = new SqlCommand(updateWorkCenterHeadQuery, connection))
                {
                    commandWorkCenterHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    commandWorkCenterHead.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                    commandWorkCenterHead.Parameters.AddWithValue("@anaIsMerkeziTipi", anaIsMerkeziTipi);
                    commandWorkCenterHead.Parameters.AddWithValue("@anaIsMerkeziKodu", anaIsMerkeziKodu);
                    commandWorkCenterHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                    commandWorkCenterHead.Parameters.AddWithValue("@pasifMi", pasifMi);
                    commandWorkCenterHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    commandWorkCenterHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    commandWorkCenterHead.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                    using (SqlCommand commandWorkCenterText = new SqlCommand(updateWorkCenterTextQuery, connection))
                    {
                        commandWorkCenterText.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
                        commandWorkCenterText.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);
                        commandWorkCenterText.Parameters.AddWithValue("@dilKodu", dilKodu);
                        commandWorkCenterText.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                        try
                        {
                            connection.Open();
                            // WorkCenterHead güncellenmesi
                            int rowsAffectedWorkCenterHead = commandWorkCenterHead.ExecuteNonQuery();
                            // WorkCenterText güncellenmesi
                            int rowsAffectedWorkCenterText = commandWorkCenterText.ExecuteNonQuery();

                            // Eğer her iki güncelleme başarılıysa, true döner
                            return rowsAffectedWorkCenterHead > 0 && rowsAffectedWorkCenterText > 0;
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

        public bool DeleteWorkCenter(string isMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            DELETE FROM BSMGR0WORKCENTERHEAD WHERE WORKCENTERDOCNUM = @isMerkeziKodu;
            DELETE FROM BSMGR0WORKCENTERTEXT WHERE WORKCENTERDOCNUM = @isMerkeziKodu;
        ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Eğer silme işlemi başarılı olduysa true döner
                }
                catch (Exception ex)
                {
                    // Hata durumunda false döner
                    throw new Exception("İş merkezi silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
