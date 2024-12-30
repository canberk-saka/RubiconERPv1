using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BSMGR0GEN001DAL
    {
        private readonly string _connectionString;

        public BSMGR0GEN001DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string comCode, string comText, string address1, string address2, string cityCode, string countryCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN001 (COMCODE, COMTEXT, ADDRESS1, ADDRESS2, CITYCODE, COUNTRYCODE) VALUES (@comCode, @comText, @address1, @address2, @cityCode, @countryCode)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@comText", comText);
                command.Parameters.AddWithValue("@address1", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityCode", cityCode ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@countryCode", countryCode ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Şehir Kodlarını Getir
        public DataTable GetCityCodes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT CITYCODE FROM BSMGR0GEN004";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // Ülke Kodlarını Getir
        public DataTable GetCountryCodes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNTRYCODE FROM BSMGR0GEN003";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // READ - Belirli bir kayıt getirme
        public DataTable GetRecord(string comCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0GEN001 WHERE COMCODE = @comCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // UPDATE - Kayıt Güncelleme
        public bool UpdateRecord(string oldComCode, string comCode, string comText, string address1, string address2, string cityCode, string countryCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE BSMGR0GEN001
                                 SET COMCODE = @comCode,
                                     COMTEXT = @comText,
                                     ADDRESS1 = @address1,
                                     ADDRESS2 = @address2,
                                     CITYCODE = @cityCode,
                                     COUNTRYCODE = @countryCode
                                 WHERE COMCODE = @oldComCode";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@comText", comText);
                command.Parameters.AddWithValue("@address1", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityCode", cityCode ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@countryCode", countryCode ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@oldComCode", oldComCode);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0; // Güncelleme başarılıysa true döner
            }
        }

        // DELETE - Kayıt Silme
        public void DeleteRecord(string comCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0GEN001 WHERE COMCODE = @comCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);

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
                string query = "SELECT * FROM BSMGR0GEN001";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // COMCODE'un var olup olmadığını kontrol etme
        public bool CheckIfCompanyCodeExists(string comCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM BSMGR0GEN001 WHERE COMCODE = @comCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }
    }
}
