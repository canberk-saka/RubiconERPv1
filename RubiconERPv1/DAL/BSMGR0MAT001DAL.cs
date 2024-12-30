using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class BSMGR0MAT001DAL
    {
        private readonly string _connectionString;

        public BSMGR0MAT001DAL(string connectionString)
        {
            _connectionString = connectionString; // Bağlantı dizesini ayarla
        }

        // Firma kodlarını listeleme (ComboBox için)
        public DataTable GetCompanyCodes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COMCODE FROM BSMGR0GEN001"; // Firma kodlarını getiren sorgu
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable; // Firma kodlarını içeren DataTable döndürülür
            }
        }

        // Yeni kayıt ekle
        public void AddRecord(string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0MAT001 (COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE) VALUES (@comCode, @docType, @docTypeText, @isPassive)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText ?? (object)DBNull.Value); // Null kontrolü
                command.Parameters.AddWithValue("@isPassive", isPassive);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Kayıt güncelle
        public bool UpdateRecord(string oldComCode, string oldDocType, string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                UPDATE BSMGR0MAT001
                SET 
                    COMCODE = @comCode, 
                    DOCTYPE = @docType, 
                    DOCTYPETEXT = @docTypeText, 
                    ISPASSIVE = @isPassive
                WHERE 
                    COMCODE = @oldComCode 
                    AND DOCTYPE = @oldDocType";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText ?? (object)DBNull.Value); // Null kontrolü
                command.Parameters.AddWithValue("@isPassive", isPassive);

                command.Parameters.AddWithValue("@oldComCode", oldComCode);
                command.Parameters.AddWithValue("@oldDocType", oldDocType);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0; // Güncelleme başarılıysa true döndür
            }
        }

        // Kayıt sil
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

        // Tüm kayıtları listeleme
        public DataTable GetAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MAT001";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        // Firma kodunun varlığını kontrol et
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

                return count > 0; // Firma kodu varsa true döndür
            }
        }
    }
}
