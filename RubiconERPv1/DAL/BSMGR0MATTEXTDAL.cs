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

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string comCode, string matDocType, string matDocNum, DateTime matDocFrom, DateTime matDocUntil, string lanCode, string matSText, string matLText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0MATTEXT (COMCODE, MATDOCTYPE, MATDOCNUM, MATDOCFROM, MATDOCUNTIL, LANCODE, MATSTEXT, MATLTEXT) VALUES (@comCode, @matDocType, @matDocNum, @matDocFrom, @matDocUntil, @lanCode, @matSText, @matLText)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@matDocType", matDocType);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);
                command.Parameters.AddWithValue("@matDocFrom", matDocFrom);
                command.Parameters.AddWithValue("@matDocUntil", matDocUntil);
                command.Parameters.AddWithValue("@lanCode", lanCode);
                command.Parameters.AddWithValue("@matSText", matSText);
                command.Parameters.AddWithValue("@matLText", matLText);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // READ - Belirli Kayıt Getirme
        public DataTable GetRecord(string matDocNum)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MATTEXT WHERE MATDOCNUM = @matDocNum";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // UPDATE - Kayıt Güncelleme
        public bool UpdateRecord(string comCode, string matDocType, string matDocNum, string lanCode, string matSText, string matLText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE BSMGR0MATTEXT
                                 SET MATDOCTYPE = @matDocType,
                                     MATSTEXT = @matSText,
                                     MATLTEXT = @matLText,
                                     LANCODE = @lanCode
                                 WHERE COMCODE = @comCode AND MATDOCNUM = @matDocNum";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@matDocType", matDocType);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);
                command.Parameters.AddWithValue("@lanCode", lanCode);
                command.Parameters.AddWithValue("@matSText", matSText);
                command.Parameters.AddWithValue("@matLText", matLText);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
        }

        // DELETE - Kayıt Silme
        public void DeleteRecord(string matDocNum)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0MATTEXT WHERE MATDOCNUM = @matDocNum";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);

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
    }
}
