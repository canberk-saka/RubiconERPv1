using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0GEN003DAL
    {
        private readonly string _connectionString;

        public BSMGR0GEN003DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm firma kodlarını getir (ComboBox için)
        public DataTable GetCompanyCodes()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE FROM BSMGR0GEN001"; // Firma kodlarını getirir
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE, COUNTRYCODE, COUNTRYTEXT FROM BSMGR0GEN003";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Yeni kayıt ekle
        public void AddRecord(string comCode, string countryCode, string countryText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN003 (COMCODE, COUNTRYCODE, COUNTRYTEXT) VALUES (@ComCode, @CountryCode, @CountryText)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@CountryCode", countryCode);
                cmd.Parameters.AddWithValue("@CountryText", countryText ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Kayıt güncelle
        public bool UpdateRecord(string oldComCode, string oldCountryCode, string newComCode, string newCountryCode, string countryText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE BSMGR0GEN003
                    SET COMCODE = @NewComCode, COUNTRYCODE = @NewCountryCode, COUNTRYTEXT = @CountryText
                    WHERE COMCODE = @OldComCode AND COUNTRYCODE = @OldCountryCode";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewComCode", newComCode);
                cmd.Parameters.AddWithValue("@NewCountryCode", newCountryCode);
                cmd.Parameters.AddWithValue("@CountryText", countryText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@OldComCode", oldComCode);
                cmd.Parameters.AddWithValue("@OldCountryCode", oldCountryCode);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Kayıt sil
        public void DeleteRecord(string comCode, string countryCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0GEN003 WHERE COMCODE = @ComCode AND COUNTRYCODE = @CountryCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@CountryCode", countryCode);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Firma kodunun varlığını kontrol et
        public bool CheckIfCompanyCodeExists(string comCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BSMGR0GEN003 WHERE COMCODE = @ComCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Ülke kodunun geçerliliğini kontrol et
        public bool IsCountryCodeValid(string countryCode)
        {
            string[] validCodes = { "TR", "EN", "DE", "FR", "IT" }; // Geçerli ülke kodları
            return Array.Exists(validCodes, code => code == countryCode);
        }
    }
}
