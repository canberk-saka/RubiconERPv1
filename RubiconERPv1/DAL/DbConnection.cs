
using System;
using System.Data.SqlClient;



namespace DataAccessLayer
{
    public class DbConnection
    {

        // Veritabanı bağlantı dizesi (App.config veya Web.config'den alınır)
        private static readonly string _connectionString = "Data Source=DESKTOP-BAP4RDU\\SQLEXPRESS02;Initial Catalog=RubiconDB;Integrated Security=True;Trust Server Certificate=True";

        // SqlConnection döndüren bir metot
        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open(); // Bağlantıyı aç
                return connection; // Açık bağlantıyı döndür
            }
            catch (SqlException ex)
            {
                // Loglama veya hata yönetimi yapabilirsiniz
                Console.WriteLine($"Veritabanına bağlanırken bir hata oluştu: {ex.Message}");
                return null; // Bağlantı hatalıysa null döndür
            }
        }

    }
}
