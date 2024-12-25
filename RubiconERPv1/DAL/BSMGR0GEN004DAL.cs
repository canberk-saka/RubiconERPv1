using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0GEN004DAL
    {
        private readonly string _connectionString;

        public BSMGR0GEN004DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE, CITYCODE, CITYTEXT FROM BSMGR0GEN004";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Yeni kayıt ekle
        public void AddRecord(string comCode, string countryCode, string cityCode, string cityText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN004 (COMCODE, COUNTRYCODE, CITYCODE, CITYTEXT) VALUES (@ComCode, @CountryCode, @CityCode, @CityText)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Parametrelerin doğru şekilde eklendiğinden emin olun
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@CountryCode", countryCode ?? throw new ArgumentNullException(nameof(countryCode), "Ülke Kodu boş olamaz."));
                cmd.Parameters.AddWithValue("@CityCode", cityCode ?? throw new ArgumentNullException(nameof(cityCode), "Şehir Kodu boş olamaz."));
                cmd.Parameters.AddWithValue("@CityText", cityText ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        // Kayıt güncelle
        public bool UpdateRecord(string oldComCode, string oldCityCode, string newComCode, string newCityCode, string cityText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BSMGR0GEN004 SET COMCODE = @NewComCode, CITYCODE = @NewCityCode, CITYTEXT = @CityText WHERE COMCODE = @OldComCode AND CITYCODE = @OldCityCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewComCode", newComCode);
                cmd.Parameters.AddWithValue("@NewCityCode", newCityCode);
                cmd.Parameters.AddWithValue("@CityText", cityText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@OldComCode", oldComCode);
                cmd.Parameters.AddWithValue("@OldCityCode", oldCityCode);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Kayıt sil
        public void DeleteRecord(string comCode, string cityCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0GEN004 WHERE COMCODE = @ComCode AND CITYCODE = @CityCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@CityCode", cityCode);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Firma kodunun varlığını kontrol et
        public bool CheckIfCompanyCodeExists(string comCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BSMGR0GEN001 WHERE COMCODE = @ComCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Şehir kodunun geçerliliğini kontrol et
        public bool IsCityCodeValid(string cityCode)
        {
            string[] validCodes = { "34", "54" }; // İstanbul, Sakarya
            return Array.Exists(validCodes, code => code == cityCode);
        }
    }
}
