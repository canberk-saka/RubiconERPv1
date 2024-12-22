using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0MAT001DAL
    {
        private readonly string _connectionString;

        public BSMGR0MAT001DAL(string connectionString)
        {
            _connectionString = connectionString; // Bağlantı dizesini ayarla
        }

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0MAT001 (DOCTYPE, DOCTYPETEXT, ISPASSIVE) VALUES (@docType, @docTypeText, @isPassive)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText);
                command.Parameters.AddWithValue("@isPassive", isPassive);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // READ - Kayıt Getirme
        public DataTable GetRecord(string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MAT001 WHERE DOCTYPE = @docType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@docType", docType);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // UPDATE - Kayıt Güncelleme
        public void UpdateRecord(string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BSMGR0MAT001 SET DOCTYPETEXT = @docTypeText, ISPASSIVE = @isPassive WHERE DOCTYPE = @docType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText);
                command.Parameters.AddWithValue("@isPassive", isPassive);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // DELETE - Kayıt Silme
        public void DeleteRecord(string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0MAT001 WHERE DOCTYPE = @docType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@docType", docType);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // LIST - Tüm Kayıtları Listeleme
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MAT001";
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
