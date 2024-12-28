using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0MATHEADDAL
    {
        private readonly string _connectionString;

        public BSMGR0MATHEADDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm kayıtları getir
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MATHEAD";
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
        public void AddRecord(string comCode, string matType, string matNumber, DateTime startDate, DateTime endDate, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO BSMGR0MATHEAD (COMCODE, MATDOCTYPE, MATDOCNUM, MATDOCFROM, MATDOCUNTIL, ISPASSIVE)
                    VALUES (@comCode, @matType, @matNumber, @startDate, @endDate, @isPassive)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@matType", matType);
                command.Parameters.AddWithValue("@matNumber", matNumber);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);
                command.Parameters.AddWithValue("@isPassive", isPassive);

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
                string query = "DELETE FROM BSMGR0MATHEAD WHERE MATDOCNUM = @matNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matNumber", matNumber);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
