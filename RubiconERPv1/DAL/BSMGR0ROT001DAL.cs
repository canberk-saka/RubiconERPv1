using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0ROT001DAL
    {
        private readonly string _connectionString;

        public BSMGR0ROT001DAL(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString), "Bağlantı dizesi boş olamaz.");
        }

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0ROT001 (COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE) VALUES (@comCode, @docType, @docTypeText, @isPassive)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@isPassive", isPassive ? 1 : 0);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // READ - Tüm Kayıtları Getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE FROM BSMGR0ROT001";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                connection.Open();
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
                    UPDATE BSMGR0ROT001
                    SET 
                        COMCODE = @comCode,
                        DOCTYPE = @docType,
                        DOCTYPETEXT = @docTypeText,
                        ISPASSIVE = @isPassive
                    WHERE 
                        COMCODE = @oldComCode AND DOCTYPE = @oldDocType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@isPassive", isPassive ? 1 : 0);
                command.Parameters.AddWithValue("@oldComCode", oldComCode);
                command.Parameters.AddWithValue("@oldDocType", oldDocType);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // DELETE - Kayıt Silme
        public void DeleteRecord(string comCode, string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0ROT001 WHERE COMCODE = @comCode AND DOCTYPE = @docType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Firma Kodlarını Getir - ComboBox için
        public DataTable GetCompanyCodes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT DISTINCT COMCODE FROM BSMGR0GEN001"; // Firma kodlarının olduğu tablo
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}
