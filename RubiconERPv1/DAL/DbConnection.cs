using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbConnection
    {

        // Veritabanı bağlantı dizesi
        //private static readonly string _connectionString = "Data Source=EMINPC;Initial Catalog=RubiconDB;Integrated Security=True;";
        private static readonly string _connectionString = "Data Source=DESKTOP-BAP4RDU\\SQLEXPRESS02;Initial Catalog=RubiconDB;Integrated Security=True;";
        //private static readonly string _connectionString = "EMRE;Initial Catalog=RubiconDB;Integrated Security=True;";


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

        // Bağlantı dizesini döndüren bir metot
        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
