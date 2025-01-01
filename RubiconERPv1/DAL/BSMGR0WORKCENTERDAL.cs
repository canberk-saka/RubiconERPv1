using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public DataTable GetWCMDetails(string isMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        h.COMCODE AS 'Firma Kodu',
                        h.WCMDOCTYPE AS 'İş Merkezi Tipi',
                        h.WCMDOCNUM AS 'İş Merkezi Kodu',
                        h.WCMDOCFROM AS 'Geçerlilik Başlangıç',
                        h.WCMDOCUNTIL AS 'Geçerlilik Bitiş',
                        h.CCMDOCNUM AS 'Maliyet Merkezi Kodu',
                        h.WORKTIME AS 'Günlük Çalışma Süresi',
                        t.WCMSTEXT AS 'Kısa Açıklama',
                        t.WCMLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINWCMDOCTYPE AS 'Ana İş Merkezi Tipi',
                        h.MAINWCMDOCNUM AS 'Ana İş Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0WCMHEAD h
                    INNER JOIN 
                        BSMGR0WCMTEXT t ON h.WCMDOCNUM = t.WCMDOCNUM
                    WHERE 
                        h.WCMDOCNUM = @isMerkeziKodu";

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
                h.WCMDOCTYPE AS 'İş Merkezi Tipi',
                h.WCMDOCNUM AS 'İş Merkezi Kodu',
                h.WCMDOCFROM AS 'Geçerlilik Başlangıç',
                h.WCMDOCUNTIL AS 'Geçerlilik Bitiş',
                h.CCMDOCTYPE AS 'Maliyet Merkezi Tipi', -- Maliyet Merkezi Tipi eklendi
                h.CCMDOCNUM AS 'Maliyet Merkezi Kodu', -- Maliyet Merkezi Kodu eklendi
                t.WCMSTEXT AS 'Kısa Açıklama',
                t.WCMLTEXT AS 'Uzun Açıklama',
                t.LANCODE AS 'Dil Kodu',
                
                h.ISDELETED AS 'Silindi Mi?',
                h.ISPASSIVE AS 'Pasif Mi?'
            FROM 
                BSMGR0WCMHEAD h
            INNER JOIN 
                BSMGR0WCMTEXT t ON h.WCMDOCNUM = t.WCMDOCNUM
            WHERE 
                1 = 1"; // Başlangıçta her şey geçerli, filtreler eklenebilir

                // Filtrelere göre sorguya eklemeler
                if (!string.IsNullOrEmpty(firma)) query += " AND h.COMCODE = @firma";
                if (!string.IsNullOrEmpty(isMerkeziTipi)) query += " AND h.WCMDOCTYPE = @isMerkeziTipi";
                if (!string.IsNullOrEmpty(isMerkeziKodu)) query += " AND h.WCMDOCNUM = @isMerkeziKodu";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND h.ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND h.ISPASSIVE = @pasifMi";
                if (baslangicTarihi.HasValue) query += " AND h.WCMDOCFROM >= @baslangicTarihi";
                if (bitisTarihi.HasValue) query += " AND h.WCMDOCUNTIL <= @bitisTarihi";

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
                        h.WCMDOCTYPE AS 'İş Merkezi Tipi',
                        h.WCMDOCNUM AS 'İş Merkezi Kodu',
                        h.WCMDOCFROM AS 'Geçerlilik Başlangıç',
                        h.WCMDOCUNTIL AS 'Geçerlilik Bitiş',
                        t.WCMSTEXT AS 'Kısa Açıklama',
                        t.WCMLTEXT AS 'Uzun Açıklama',
                        t.LANCODE AS 'Dil Kodu',
                        h.MAINWCMDOCTYPE AS 'Ana İş Merkezi Tipi',
                        h.MAINWCMDOCNUM AS 'Ana İş Merkezi Kodu',
                        h.ISDELETED AS 'Silindi Mi?',
                        h.ISPASSIVE AS 'Pasif Mi?'
                    FROM 
                        BSMGR0WCMHEAD h
                    INNER JOIN 
                        BSMGR0WCMTEXT t ON h.WCMDOCNUM = t.WCMDOCNUM";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public bool InsertWorkCenter(
      string firmaKodu, string isMerkeziTipi, string isMerkeziKodu, DateTime? baslangicTarihi,
      DateTime? bitisTarihi, string gunlukCalismaSuresi, string kisaAciklama, string uzunAciklama,
      string silindiMi, string pasifMi, string dilKodu, string anaIsMerkeziTipi, string anaIsMerkeziKodu,
      string maliyetMerkeziKodu, string maliyetMerkeziTipi)
        {
            try
            {
                // WCMHEAD tablosuna veri ekleme
                string insertWCMHeadQuery = @"
        INSERT INTO BSMGR0WCMHEAD
        (
            COMCODE, WCMDOCTYPE, WCMDOCNUM, WCMDOCFROM, WCMDOCUNTIL, MAINWCMDOCTYPE, MAINWCMDOCNUM,
            ISDELETED, ISPASSIVE
        )
        VALUES
        (
            @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi,
            @anaIsMerkeziTipi, @anaIsMerkeziKodu, @silindiMi, @pasifMi
        )";

                // WCMTEXT tablosuna veri ekleme
                string insertWCMTextQuery = @"
        INSERT INTO BSMGR0WCMTEXT
        (
            COMCODE, WCMDOCTYPE, WCMDOCNUM, WCMDOCFROM, WCMDOCUNTIL, LANCODE, WCMSTEXT, WCMLTEXT
        )
        VALUES
        (
            @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
            @dilKodu, @kisaAciklama, @uzunAciklama
        )";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand commandWCMHead = new SqlCommand(insertWCMHeadQuery, connection))
                    {
                        commandWCMHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                        commandWCMHead.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                        commandWCMHead.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);
                        commandWCMHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                        commandWCMHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                        commandWCMHead.Parameters.AddWithValue("@anaIsMerkeziTipi", anaIsMerkeziTipi);
                        commandWCMHead.Parameters.AddWithValue("@anaIsMerkeziKodu", anaIsMerkeziKodu);
                        commandWCMHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                        commandWCMHead.Parameters.AddWithValue("@pasifMi", pasifMi);

                        using (SqlCommand commandWCMText = new SqlCommand(insertWCMTextQuery, connection))
                        {
                            commandWCMText.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                            commandWCMText.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                            commandWCMText.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);
                            commandWCMText.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                            commandWCMText.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                            commandWCMText.Parameters.AddWithValue("@dilKodu", dilKodu);
                            commandWCMText.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
                            commandWCMText.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);

                            try
                            {
                                connection.Open();
                                // WCMHead verisini ekle
                                int rowsAffectedWCMHead = commandWCMHead.ExecuteNonQuery();
                                // WCMText verisini ekle
                                int rowsAffectedWCMText = commandWCMText.ExecuteNonQuery();

                                // Eğer her iki tablonun eklenmesi başarılıysa, true döner
                                return rowsAffectedWCMHead > 0 && rowsAffectedWCMText > 0;
                            }
                            catch (Exception ex)
                            {
                                // Hata durumunda exception fırlat
                                throw new Exception("Ekleme işlemi sırasında bir hata oluştu: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda false döner
                MessageBox.Show($"Ekleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // İş Merkezi Güncelleme
        public bool UpdateWCM(string isMerkeziKodu, string firmaKodu, string isMerkeziTipi,
                       string anaIsMerkeziTipi, string anaIsMerkeziKodu, string silindiMi, string pasifMi,
                       DateTime? baslangicTarihi, DateTime? bitisTarihi, string kisaAciklama, string uzunAciklama, string dilKodu)
        {
            string updateWCMHeadQuery = @"
    UPDATE BSMGR0WCMHEAD
    SET
        COMCODE = @firmaKodu,
        WCMDOCTYPE = @isMerkeziTipi,
        MAINWCMDOCTYPE = @anaIsMerkeziTipi,
        MAINWCMDOCNUM = @anaIsMerkeziKodu,
        ISDELETED = @silindiMi,
        ISPASSIVE = @pasifMi,
        WCMDOCFROM = @baslangicTarihi,
        WCMDOCUNTIL = @bitisTarihi
    WHERE
        WCMDOCNUM = @isMerkeziKodu";

            string updateWCMTextQuery = @"
    UPDATE BSMGR0WCMTEXT
    SET
        WCMSTEXT = @kisaAciklama,
        WCMLTEXT = @uzunAciklama,
        LANCODE = @dilKodu
    WHERE
        WCMDOCNUM = @isMerkeziKodu";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand commandWCMHead = new SqlCommand(updateWCMHeadQuery, connection))
                {
                    commandWCMHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    commandWCMHead.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
                    commandWCMHead.Parameters.AddWithValue("@anaIsMerkeziTipi", anaIsMerkeziTipi);
                    commandWCMHead.Parameters.AddWithValue("@anaIsMerkeziKodu", anaIsMerkeziKodu);
                    commandWCMHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                    commandWCMHead.Parameters.AddWithValue("@pasifMi", pasifMi);
                    commandWCMHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    commandWCMHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    commandWCMHead.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                    using (SqlCommand commandWCMText = new SqlCommand(updateWCMTextQuery, connection))
                    {
                        commandWCMText.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
                        commandWCMText.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);
                        commandWCMText.Parameters.AddWithValue("@dilKodu", dilKodu);
                        commandWCMText.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);

                        try
                        {
                            connection.Open();

                            // WCMHead güncellenmesi
                            int rowsAffectedWCMHead = commandWCMHead.ExecuteNonQuery();
                            // WCMText güncellenmesi
                            int rowsAffectedWCMText = commandWCMText.ExecuteNonQuery();

                            // Hata ayıklama için satır sayısını kontrol et
                            if (rowsAffectedWCMHead == 0)
                            {
                                MessageBox.Show("İş merkezi kodu ile eşleşen bir kayıt bulunamadı (WCMHead).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            if (rowsAffectedWCMText == 0)
                            {
                                MessageBox.Show("İş merkezi kodu ile eşleşen bir kayıt bulunamadı (WCMText).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            if (rowsAffectedWCMHead > 0 && rowsAffectedWCMText > 0)
                            {
                                return true; // Başarıyla güncellendi
                            }
                            else
                            {
                                throw new Exception("Güncelleme işlemi başarısız. Hiçbir satır etkilenmedi.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Hata mesajını döndür
                            throw new Exception("Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
        }




        //        public bool InsertWorkCenter(string firmaKodu, string isMerkeziTipi, string isMerkeziKodu,
        //    DateTime? baslangicTarihi, DateTime? bitisTarihi, string gunlukCalismaSuresi, string kisaAciklama,
        //    string uzunAciklama, string silindiMi, string pasifMi, string dilKodu)
        //        {
        //            try
        //            {
        //                using (SqlConnection connection = new SqlConnection(_connectionString))
        //                {
        //                    string query = @"
        //INSERT INTO BSMGR0WCMHEAD
        //(
        //    COMCODE, WCMDOCTYPE, WCMDOCNUM, WCMDOCFROM, WCMDOCUNTIL, MAINWCMDOCTYPE, MAINWCMDOCNUM, 
        //    ISDELETED, ISPASSIVE, WCMDOCFROM
        //)
        //VALUES
        //(
        //    @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
        //    @anaIsMerkeziTipi, @anaIsMerkeziKodu, @silindiMi, @pasifMi, @gunlukCalismaSuresi
        //);

        //INSERT INTO BSMGR0WCMTEXT
        //(
        //    COMCODE, WCMDOCTYPE, WCMDOCNUM, WCMDOCFROM, WCMDOCUNTIL, LANCODE, WCMSTEXT, WCMLTEXT
        //)
        //VALUES
        //(
        //    @firmaKodu, @isMerkeziTipi, @isMerkeziKodu, @baslangicTarihi, @bitisTarihi, 
        //    @dilKodu, @kisaAciklama, @uzunAciklama
        //)";

        //                    SqlCommand command = new SqlCommand(query, connection);

        //                    // Parametreleri ekle
        //                    command.Parameters.AddWithValue("@firmaKodu", firmaKodu);
        //                    command.Parameters.AddWithValue("@isMerkeziTipi", isMerkeziTipi);
        //                    command.Parameters.AddWithValue("@isMerkeziKodu", isMerkeziKodu);
        //                    command.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
        //                    command.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
        //                    command.Parameters.AddWithValue("@gunlukCalismaSuresi", gunlukCalismaSuresi);
        //                    command.Parameters.AddWithValue("@kisaAciklama", kisaAciklama);
        //                    command.Parameters.AddWithValue("@uzunAciklama", uzunAciklama);
        //                    command.Parameters.AddWithValue("@dilKodu", dilKodu);
        //                    command.Parameters.AddWithValue("@silindiMi", silindiMi);
        //                    command.Parameters.AddWithValue("@pasifMi", pasifMi);
        //                    command.Parameters.AddWithValue("@anaIsMerkeziTipi", IsMerkeziTipi);
        //                    command.Parameters.AddWithValue("@anaIsMerkeziKodu", IsMerkeziKodu);

        //                    connection.Open();
        //                    int rowsAffected = command.ExecuteNonQuery();
        //                    return rowsAffected > 0; // Eğer ekleme başarılıysa true döner


        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                // Hata mesajı döndür
        //                throw new Exception("Yeni iş merkezi eklenirken bir hata oluştu: " + ex.Message);
        //            }
        //        }


        public bool DeleteWCM(string isMerkeziKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            DELETE FROM BSMGR0WCMHEAD WHERE WCMDOCNUM = @isMerkeziKodu;
            DELETE FROM BSMGR0WCMTEXT WHERE WCMDOCNUM = @isMerkeziKodu;
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
