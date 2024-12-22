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

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO BSMGR0MAT001 (COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE) VALUES (@comCode, @docType, @docTypeText, @isPassive)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText); // TextBox'tan alınan değer
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

        public bool UpdateRecord(string oldComCode, string oldDocType, string comCode, string docType, string docTypeText, bool isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // COMCODE'nun var olup olmadığını kontrol ediyoruz
                string checkComCodeQuery = "SELECT COUNT(*) FROM BSMGR0MAT001 WHERE COMCODE = @comCode";
                SqlCommand checkComCodeCommand = new SqlCommand(checkComCodeQuery, connection);
                checkComCodeCommand.Parameters.AddWithValue("@comCode", comCode);

                connection.Open();
                int count = (int)checkComCodeCommand.ExecuteScalar();

                if (count == 0)  // COMCODE veri tabanında yoksa
                {
                    MessageBox.Show("Firma Kodu veri tabanında mevcut değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Hem COMCODE hem de DOCTYPE güncelleniyor
                string query = @"
        UPDATE BSMGR0MAT001
        SET
            COMCODE = @comCode,          -- COMCODE güncelleniyor
            DOCTYPE = @docType,          -- DOCTYPE güncelleniyor
            DOCTYPETEXT = @docTypeText,  -- DOCTYPETEXT güncelleniyor
            ISPASSIVE = @isPassive       -- ISPASSIVE güncelleniyor
        WHERE
            DOCTYPE = @oldDocType        -- Filtreleme için eski DOCTYPE
            AND COMCODE = @oldComCode";  // Filtreleme için eski COMCODE

                SqlCommand command = new SqlCommand(query, connection);

                // Güncellenecek yeni değerler
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@docType", docType);
                command.Parameters.AddWithValue("@docTypeText", docTypeText);
                command.Parameters.AddWithValue("@isPassive", isPassive);

                // Eski değerler (WHERE filtresi için)
                command.Parameters.AddWithValue("@oldDocType", oldDocType);
                command.Parameters.AddWithValue("@oldComCode", oldComCode);

                command.ExecuteNonQuery();
                connection.Close();

                return true; // Güncelleme başarılı
            }
        }


        // DELETE - Kayıt Silme
        public void DeleteRecord(string docType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM BSMGR0MAT001 WHERE DOCTYPE = @docType"; // DOCKTYPE ile silme işlemi
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@docType", docType); // DOCKTYPE parametresini ekle

                connection.Open();
                command.ExecuteNonQuery(); // SQL komutunu çalıştır
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

        public bool CheckIfCompanyCodeExists(string comCode)
        {
            // SQL sorgusu ve bağlantı işlemleri
            string query = "SELECT COUNT(*) FROM BSMGR0GEN001 WHERE COMCODE = @comCode";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0; // Firma kodu varsa true döner
            }
        }


    }
}
