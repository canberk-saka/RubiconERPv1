using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public void AddRecord(string comCode, string comText, string address1, string address2, string cityCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0GEN001 (COMCODE, COMTEXT, ADDRESS1, ADDRESS2, CITYCODE) VALUES (@comCode, @comText, @address1, @address2, @cityCode)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@comText", comText);
                command.Parameters.AddWithValue("@address1", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityCode", cityCode);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
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
        public bool UpdateRecord(string oldComCode, string comCode, string comText, string address1, string address2, string cityCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE BSMGR0GEN001
                                 SET COMCODE = @comCode,
                                     COMTEXT = @comText,
                                     ADDRESS1 = @address1,
                                     ADDRESS2 = @address2,
                                     CITYCODE = @cityCode
                                 WHERE COMCODE = @oldComCode";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@comText", comText);
                command.Parameters.AddWithValue("@address1", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityCode", cityCode);
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
