using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0MATTEXTDAL
    {
        private readonly string _connectionString;

        public BSMGR0MATTEXTDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MATTEXT";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // Kayıt ekle
        public void AddRecord(string matNumber, string shortDescription, string longDescription, string languageCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO BSMGR0MATTEXT (MATDOCNUM, MATSTEXT, MATLTEXT, LANCODE)
                    VALUES (@matNumber, @shortDescription, @longDescription, @languageCode)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matNumber", matNumber);
                command.Parameters.AddWithValue("@shortDescription", shortDescription);
                command.Parameters.AddWithValue("@longDescription", longDescription);
                command.Parameters.AddWithValue("@languageCode", languageCode);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Kayıt sil
        public void DeleteRecord(string matNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0MATTEXT WHERE MATDOCNUM = @matNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matNumber", matNumber);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
