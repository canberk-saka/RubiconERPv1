using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0GEN005DAL
    {
        private readonly string _connectionString;

        public BSMGR0GEN005DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE, UNITCODE, UNITTEXT, ISMAINUNIT, MAINUNITCODE FROM BSMGR0GEN005";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Firma kodlarını getir
        public DataTable GetCompanyCodes()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT DISTINCT COMCODE FROM BSMGR0GEN001"; // Firma kodlarını getir
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Yeni kayıt ekle
        public void AddRecord(string comCode, string unitCode, string unitText, int isMainUnit, string mainUnitCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN005 (COMCODE, UNITCODE, UNITTEXT, ISMAINUNIT, MAINUNITCODE) " +
                               "VALUES (@ComCode, @UnitCode, @UnitText, @IsMainUnit, @MainUnitCode)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@UnitCode", unitCode);
                cmd.Parameters.AddWithValue("@UnitText", unitText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsMainUnit", isMainUnit);
                cmd.Parameters.AddWithValue("@MainUnitCode", mainUnitCode ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Kayıt güncelle
        public bool UpdateRecord(string oldComCode, string oldUnitCode, string newComCode, string newUnitCode, string unitText, int isMainUnit, string mainUnitCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BSMGR0GEN005 SET COMCODE = @NewComCode, UNITCODE = @NewUnitCode, UNITTEXT = @UnitText, " +
                               "ISMAINUNIT = @IsMainUnit, MAINUNITCODE = @MainUnitCode " +
                               "WHERE COMCODE = @OldComCode AND UNITCODE = @OldUnitCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewComCode", newComCode);
                cmd.Parameters.AddWithValue("@NewUnitCode", newUnitCode);
                cmd.Parameters.AddWithValue("@UnitText", unitText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsMainUnit", isMainUnit);
                cmd.Parameters.AddWithValue("@MainUnitCode", mainUnitCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@OldComCode", oldComCode);
                cmd.Parameters.AddWithValue("@OldUnitCode", oldUnitCode);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Kayıt sil
        public void DeleteRecord(string comCode, string unitCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0GEN005 WHERE COMCODE = @ComCode AND UNITCODE = @UnitCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);
                cmd.Parameters.AddWithValue("@UnitCode", unitCode);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Firma kodunun varlığını kontrol et
        public bool CheckIfCompanyCodeExists(string comCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BSMGR0GEN005 WHERE COMCODE = @ComCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComCode", comCode);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Birim kodunun geçerliliğini kontrol et
        public bool IsUnitCodeValid(string unitCode)
        {
            string[] validCodes = { "KG", "LT", "AD", "GR" }; // Kilogram, Litre, Adet, Gram
            return Array.Exists(validCodes, code => code == unitCode);
        }
    }
}
