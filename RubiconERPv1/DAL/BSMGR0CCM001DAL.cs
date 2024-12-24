using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0CCM001DAL
    {
        private readonly string _connectionString;

        public BSMGR0CCM001DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0CCM001 (COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE) VALUES (@ComCode, @DocType, @DocTypeText, @IsPassive)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComCode", comCode);
                command.Parameters.AddWithValue("@DocType", docType);
                command.Parameters.AddWithValue("@DocTypeText", docTypeText ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IsPassive", isPassive);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // READ - Tüm Kayıtları Getirme
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0CCM001";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // READ - Belirli Bir Kayıt Getirme
        public DataTable GetRecord(string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0CCM001 WHERE DOCTYPE = @DocType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DocType", docType);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // UPDATE - Kayıt Güncelleme
        public bool UpdateRecord(string oldComCode, string oldDocType, string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE BSMGR0CCM001
                    SET COMCODE = @ComCode, DOCTYPE = @DocType, DOCTYPETEXT = @DocTypeText, ISPASSIVE = @IsPassive
                    WHERE COMCODE = @OldComCode AND DOCTYPE = @OldDocType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComCode", comCode);
                command.Parameters.AddWithValue("@DocType", docType);
                command.Parameters.AddWithValue("@DocTypeText", docTypeText ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IsPassive", isPassive);
                command.Parameters.AddWithValue("@OldComCode", oldComCode);
                command.Parameters.AddWithValue("@OldDocType", oldDocType);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // DELETE - Kayıt Silme
        public void DeleteRecord(string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0CCM001 WHERE DOCTYPE = @DocType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DocType", docType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Firma Kodunun Varlığını Kontrol Etme
        public bool CheckIfCompanyCodeExists(string comCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BSMGR0GEN001 WHERE COMCODE = @ComCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComCode", comCode);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Maliyet Merkezi Tipinin Geçerliliğini Kontrol Et
        public bool IsDocTypeValid(string docType)
        {
            string[] validDocTypes = { "CC0", "CC1", "CC2" }; // Geçerli tipler: Ana, Yardımcı, Hayalî
            return Array.Exists(validDocTypes, type => type == docType);
        }
    }
}
