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


    }
}
