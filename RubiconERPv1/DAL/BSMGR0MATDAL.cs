using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0MATDAL
    {
        private readonly string _connectionString;

        public BSMGR0MATDAL(string connectionString)
        {
            _connectionString = connectionString;
        }



        public DataTable GetFilteredData(string firma, string malzemeTipi, string malzemeNo, string tedarikTipi,
             string malzemeKisaAciklama, string malzemeUzunAciklama,
             string urunAgaciVarMi, string dilKodu, string silindiMi, string pasifMi,
             DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Dinamik sorgu
                string query = @"
SELECT 
    h.MATDOCNUM AS 'Malzeme Kodu',
    h.COMCODE AS 'Firma Kodu',
    h.MATDOCTYPE AS 'Malzeme Tipi',
    h.MATDOCFROM AS 'Başlangıç Tarihi',
    h.MATDOCUNTIL AS 'Bitiş Tarihi',
    t.MATSTEXT AS 'Kısa Açıklama',
    t.MATLTEXT AS 'Uzun Açıklama',
    t.LANCODE AS 'Dil Kodu',
    h.ISBOM AS 'Ürün Ağacı Var Mı?',
    h.ISDELETED AS 'Silindi Mi?',
    h.ISPASSIVE AS 'Pasif Mi?'
FROM 
    BSMGR0MATHEAD h
INNER JOIN 
    BSMGR0MATTEXT t ON h.MATDOCNUM = t.MATDOCNUM
WHERE 
    1 = 1";  // Başlangıçta her şey geçerli, filtreler eklenebilir

                // Filtrelere göre sorguya eklemeler
                if (!string.IsNullOrEmpty(firma)) query += " AND h.COMCODE = @firma";
                if (!string.IsNullOrEmpty(malzemeTipi)) query += " AND h.MATDOCTYPE = @malzemeTipi";
                if (!string.IsNullOrEmpty(malzemeNo)) query += " AND h.MATDOCNUM = @malzemeNo";
                if (!string.IsNullOrEmpty(tedarikTipi)) query += " AND h.SUPPLYTYPE = @tedarikTipi";
                if (!string.IsNullOrEmpty(malzemeKisaAciklama)) query += " AND t.MATSTEXT LIKE @malzemeKisaAciklama";
                if (!string.IsNullOrEmpty(malzemeUzunAciklama)) query += " AND t.MATLTEXT LIKE @malzemeUzunAciklama";
                if (!string.IsNullOrEmpty(urunAgaciVarMi)) query += " AND h.ISBOM = @urunAgaciVarMi";
                if (!string.IsNullOrEmpty(dilKodu)) query += " AND t.LANCODE = @dilKodu";
                if (!string.IsNullOrEmpty(silindiMi)) query += " AND h.ISDELETED = @silindiMi";
                if (!string.IsNullOrEmpty(pasifMi)) query += " AND h.ISPASSIVE = @pasifMi";
                if (baslangicTarihi.HasValue) query += " AND h.MATDOCFROM >= @baslangicTarihi";
                if (bitisTarihi.HasValue) query += " AND h.MATDOCUNTIL <= @bitisTarihi";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametre ekle
                if (!string.IsNullOrEmpty(firma)) command.Parameters.AddWithValue("@firma", firma);
                if (!string.IsNullOrEmpty(malzemeTipi)) command.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                if (!string.IsNullOrEmpty(malzemeNo)) command.Parameters.AddWithValue("@malzemeNo", malzemeNo);
                if (!string.IsNullOrEmpty(tedarikTipi)) command.Parameters.AddWithValue("@tedarikTipi", tedarikTipi);
                if (!string.IsNullOrEmpty(malzemeKisaAciklama)) command.Parameters.AddWithValue("@malzemeKisaAciklama", "%" + malzemeKisaAciklama + "%");
                if (!string.IsNullOrEmpty(malzemeUzunAciklama)) command.Parameters.AddWithValue("@malzemeUzunAciklama", "%" + malzemeUzunAciklama + "%");
                if (!string.IsNullOrEmpty(urunAgaciVarMi)) command.Parameters.AddWithValue("@urunAgaciVarMi", urunAgaciVarMi);
                if (!string.IsNullOrEmpty(dilKodu)) command.Parameters.AddWithValue("@dilKodu", dilKodu);
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


        public bool UpdateMaterial(string malzemeKodu, string firmaKodu, string malzemeTipi, string malzemeKisaAciklama,
    string malzemeUzunAciklama, string dilKodu, string tedarikTipi, string malzemeStokBirimi,
    string netAgirlik, string netAgirlikBirimi, string brutAgirlik, string brutAgirlikBirimi,
    string urunAgaciVarMi, string urunAgaciTipi, string urunAgaciKodu, string rotaVarMi,
    string rotaTipi, string rotaNumarasi, string silindiMi, string pasifMi,
    DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            string updateMatHeadQuery = @"
        UPDATE BSMGR0MATHEAD
        SET
            COMCODE = @firmaKodu,
            MATDOCTYPE = @malzemeTipi,
            SUPPLYTYPE = @tedarikTipi,
            STUNIT = @malzemeStokBirimi,
            NETWEIGHT = @netAgirlik,
            NWUNIT = @netAgirlikBirimi,
            BRUTWEIGHT = @brutAgirlik,
            BWUNIT = @brutAgirlikBirimi,
            ISBOM = @urunAgaciVarMi,
            BOMDOCTYPE = @urunAgaciTipi,
            BOMDOCNUM = @urunAgaciKodu,
            ISROUTE = @rotaVarMi,
            ROTDOCTYPE = @rotaTipi,
            ROTDOCNUM = @rotaNumarasi,
            ISDELETED = @silindiMi,
            ISPASSIVE = @pasifMi,
            MATDOCFROM = @baslangicTarihi,
            MATDOCUNTIL = @bitisTarihi
        WHERE
            MATDOCNUM = @malzemeKodu";

            string updateMatTextQuery = @"
        UPDATE BSMGR0MATTEXT
        SET
            MATSTEXT = @malzemeKisaAciklama,
            MATLTEXT = @malzemeUzunAciklama,
            LANCODE = @dilKodu
        WHERE
            MATDOCNUM = @malzemeKodu";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand commandMatHead = new SqlCommand(updateMatHeadQuery, connection))
                {
                    commandMatHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    commandMatHead.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                    commandMatHead.Parameters.AddWithValue("@tedarikTipi", tedarikTipi);
                    commandMatHead.Parameters.AddWithValue("@malzemeStokBirimi", malzemeStokBirimi);
                    commandMatHead.Parameters.AddWithValue("@netAgirlik", netAgirlik);
                    commandMatHead.Parameters.AddWithValue("@netAgirlikBirimi", netAgirlikBirimi);
                    commandMatHead.Parameters.AddWithValue("@brutAgirlik", brutAgirlik);
                    commandMatHead.Parameters.AddWithValue("@brutAgirlikBirimi", brutAgirlikBirimi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciVarMi", urunAgaciVarMi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);
                    commandMatHead.Parameters.AddWithValue("@rotaVarMi", rotaVarMi);
                    commandMatHead.Parameters.AddWithValue("@rotaTipi", rotaTipi);
                    commandMatHead.Parameters.AddWithValue("@rotaNumarasi", rotaNumarasi);
                    commandMatHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                    commandMatHead.Parameters.AddWithValue("@pasifMi", pasifMi);
                    commandMatHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    commandMatHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);
                    commandMatHead.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);

                    using (SqlCommand commandMatText = new SqlCommand(updateMatTextQuery, connection))
                    {
                        commandMatText.Parameters.AddWithValue("@malzemeKisaAciklama", malzemeKisaAciklama);
                        commandMatText.Parameters.AddWithValue("@malzemeUzunAciklama", malzemeUzunAciklama);
                        commandMatText.Parameters.AddWithValue("@dilKodu", dilKodu);
                        commandMatText.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);

                        try
                        {
                            connection.Open();
                            // MatHead güncellenmesi
                            int rowsAffectedMatHead = commandMatHead.ExecuteNonQuery();
                            // MatText güncellenmesi
                            int rowsAffectedMatText = commandMatText.ExecuteNonQuery();

                            // Eğer her iki güncelleme başarılıysa, true döner
                            return rowsAffectedMatHead > 0 && rowsAffectedMatText > 0;
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



        public DataTable GetControlTableData(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM {tableName}"; // Kontrol tablosundaki tüm verileri çek
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public DataTable GetAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
        SELECT 
            h.MATDOCNUM AS 'Malzeme Kodu',
            h.COMCODE AS 'Firma Kodu',
            h.MATDOCTYPE AS 'Malzeme Tipi',
            h.MATDOCFROM AS 'Başlangıç Tarihi',
            h.MATDOCUNTIL AS 'Bitiş Tarihi',
            t.MATSTEXT AS 'Kısa Açıklama',
            t.MATLTEXT AS 'Uzun Açıklama',
            t.LANCODE AS 'Dil Kodu',
            h.ISBOM AS 'Ürün Ağacı Var Mı?',
            h.ISDELETED AS 'Silindi Mi?',
            h.ISPASSIVE AS 'Pasif Mi?'
        FROM 
            BSMGR0MATHEAD h
        INNER JOIN 
            BSMGR0MATTEXT t ON h.MATDOCNUM = t.MATDOCNUM";  // Tüm verileri çekeriz

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public DataTable GetMaterialDetails(string malzemeKodu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                h.MATDOCNUM AS 'Malzeme Kodu',
                h.COMCODE AS 'Firma Kodu',
                h.MATDOCTYPE AS 'Malzeme Tipi',
                h.MATDOCFROM AS 'Geçerlilik Başlangıç',
                h.MATDOCUNTIL AS 'Geçerlilik Bitiş',
                t.MATSTEXT AS 'Malzeme Kısa Açıklama',
                t.MATLTEXT AS 'Malzeme Uzun Açıklama',
                t.LANCODE AS 'Dil Kodu',
                h.SUPPLYTYPE AS 'Tedarik Tipi',
                h.STUNIT AS 'Malzeme Stok Birimi',
                h.NETWEIGHT AS 'Net Ağırlık',
                h.NWUNIT AS 'Net Ağırlık Birimi',
                h.BRUTWEIGHT AS 'Brüt Ağırlık',
                h.BWUNIT AS 'Brüt Ağırlık Birimi',
                h.ISBOM AS 'Ürün Ağacı Var Mı?',
                h.BOMDOCTYPE AS 'Ürün Ağacı Tipi',
                h.BOMDOCNUM AS 'Ürün Ağacı Kodu',
                h.ISROUTE AS 'Rota Var Mı?',
                h.ROTDOCNUM AS 'Rota Numarası',
                h.ROTDOCTYPE AS 'Rota Tipi',
                h.ISDELETED AS 'Silindi Mi?',
                h.ISPASSIVE AS 'Pasif Mi?'
            FROM 
                BSMGR0MATHEAD h
            INNER JOIN 
                BSMGR0MATTEXT t ON h.MATDOCNUM = t.MATDOCNUM
            WHERE 
                h.MATDOCNUM = @malzemeKodu";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public bool InsertMaterial(string malzemeKodu, string firmaKodu, string malzemeTipi, string malzemeKisaAciklama,
     string malzemeUzunAciklama, string dilKodu, string tedarikTipi, string malzemeStokBirimi,
     string netAgirlik, string netAgirlikBirimi, string brutAgirlik, string brutAgirlikBirimi,
     string urunAgaciVarMi, string urunAgaciTipi, string urunAgaciKodu, string rotaVarMi,
     string rotaTipi, string rotaNumarasi, string silindiMi, string pasifMi,
     DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            string insertMatHeadQuery = @"
    INSERT INTO BSMGR0MATHEAD
    (
        MATDOCNUM, COMCODE, MATDOCTYPE, SUPPLYTYPE, STUNIT, NETWEIGHT, NWUNIT, BRUTWEIGHT, 
        BWUNIT, ISBOM, BOMDOCTYPE, BOMDOCNUM, ISROUTE, ROTDOCTYPE, ROTDOCNUM, ISDELETED, 
        ISPASSIVE, MATDOCFROM, MATDOCUNTIL
    )
    VALUES
    (
        @malzemeKodu, @firmaKodu, @malzemeTipi, @tedarikTipi, @malzemeStokBirimi, @netAgirlik, 
        @netAgirlikBirimi, @brutAgirlik, @brutAgirlikBirimi, @urunAgaciVarMi, @urunAgaciTipi, 
        @urunAgaciKodu, @rotaVarMi, @rotaTipi, @rotaNumarasi, @silindiMi, @pasifMi, 
        @baslangicTarihi, @bitisTarihi
    )";

            string insertMatTextQuery = @"
    INSERT INTO BSMGR0MATTEXT
    (
        COMCODE, MATDOCTYPE, MATDOCNUM, MATDOCFROM, MATDOCUNTIL, LANCODE, MATSTEXT, MATLTEXT
    )
    VALUES
    (
        @firmaKodu, @malzemeTipi, @malzemeKodu, @baslangicTarihi, @bitisTarihi, @dilKodu, 
        @malzemeKisaAciklama, @malzemeUzunAciklama
    )";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand commandMatHead = new SqlCommand(insertMatHeadQuery, connection))
                {
                    // Parametreleri ekle
                    commandMatHead.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                    commandMatHead.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                    commandMatHead.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);
                    commandMatHead.Parameters.AddWithValue("@tedarikTipi", tedarikTipi);
                    commandMatHead.Parameters.AddWithValue("@malzemeStokBirimi", malzemeStokBirimi);
                    commandMatHead.Parameters.AddWithValue("@netAgirlik", netAgirlik);
                    commandMatHead.Parameters.AddWithValue("@netAgirlikBirimi", netAgirlikBirimi);
                    commandMatHead.Parameters.AddWithValue("@brutAgirlik", brutAgirlik);
                    commandMatHead.Parameters.AddWithValue("@brutAgirlikBirimi", brutAgirlikBirimi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciVarMi", urunAgaciVarMi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciTipi", urunAgaciTipi);
                    commandMatHead.Parameters.AddWithValue("@urunAgaciKodu", urunAgaciKodu);
                    commandMatHead.Parameters.AddWithValue("@rotaVarMi", rotaVarMi);
                    commandMatHead.Parameters.AddWithValue("@rotaTipi", rotaTipi);
                    commandMatHead.Parameters.AddWithValue("@rotaNumarasi", rotaNumarasi);
                    commandMatHead.Parameters.AddWithValue("@silindiMi", silindiMi);
                    commandMatHead.Parameters.AddWithValue("@pasifMi", pasifMi);
                    commandMatHead.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                    commandMatHead.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);

                    using (SqlCommand commandMatText = new SqlCommand(insertMatTextQuery, connection))
                    {
                        // Parametreleri ekle
                        commandMatText.Parameters.AddWithValue("@firmaKodu", firmaKodu);
                        commandMatText.Parameters.AddWithValue("@malzemeKodu", malzemeKodu);
                        commandMatText.Parameters.AddWithValue("@malzemeTipi", malzemeTipi);  // Burada malzemeTipi parametresi kullanılıyor
                        commandMatText.Parameters.AddWithValue("@malzemeKisaAciklama", malzemeKisaAciklama);
                        commandMatText.Parameters.AddWithValue("@malzemeUzunAciklama", malzemeUzunAciklama);
                        commandMatText.Parameters.AddWithValue("@dilKodu", dilKodu);
                        commandMatText.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi.HasValue ? (object)baslangicTarihi.Value : DBNull.Value);
                        commandMatText.Parameters.AddWithValue("@bitisTarihi", bitisTarihi.HasValue ? (object)bitisTarihi.Value : DBNull.Value);

                        try
                        {
                            connection.Open();
                            // MatHead ve MatText yeni kayıtları ekle
                            int rowsAffectedMatHead = commandMatHead.ExecuteNonQuery();
                            int rowsAffectedMatText = commandMatText.ExecuteNonQuery();

                            // Eğer her iki ekleme başarılıysa, true döner
                            return rowsAffectedMatHead > 0 && rowsAffectedMatText > 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Yeni kayıt eklenirken bir hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
        }







    }
}
