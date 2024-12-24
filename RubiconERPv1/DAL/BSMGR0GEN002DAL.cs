using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0GEN002DAL
    {
        private readonly string _connectionString;

        public BSMGR0GEN002DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE, LANCODE, LANTEXT FROM BSMGR0GEN002";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Yeni kayıt ekle
        public void AddRecord(string comCode, string lanCode, string lanText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN002 (COMCODE, LANCODE, LANTEXT) VALUES (@ComCode, @LanCode, @LanText)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@LanCode", lanCode);
                cmd.Parameters.AddWithValue("@LanText", lanText ?? (object)DBNull.Value); 

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // Kayıt güncelle
        // UpdateRecord metodunu düzenledik
        public bool UpdateRecord(string oldComCode, string oldLanCode, string newComCode, string newLanCode, string lanText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BSMGR0GEN002 SET COMCODE = @NewComCode, LANCODE = @NewLanCode, LANTEXT = @LanText WHERE COMCODE = @OldComCode AND LANCODE = @OldLanCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewComCode", newComCode);
                cmd.Parameters.AddWithValue("@NewLanCode", newLanCode);
                cmd.Parameters.AddWithValue("@LanText", lanText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@OldComCode", oldComCode);
                cmd.Parameters.AddWithValue("@OldLanCode", oldLanCode);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Kayıt sil
        public void DeleteRecord(string comCode, string lanCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0GEN002 WHERE COMCODE = @ComCode AND LANCODE = @LanCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@LanCode", lanCode);

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

        // Dil kodunun geçerliliğini kontrol et
        public bool IsLanguageCodeValid(string lanCode)
        {
            string[] validCodes = { "T", "E", "D" }; // Türkçe, İngilizce, Almanca
            return Array.Exists(validCodes, code => code == lanCode);
        }
    }
}
