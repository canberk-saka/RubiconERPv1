using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class BSMGR0MATHEADDAL
    {
        private readonly string _connectionString;

        public BSMGR0MATHEADDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // CREATE - Yeni Kayıt Ekleme
        public void AddRecord(
            string comCode, string matDocType, string matDocNum, DateTime matDocFrom,
            DateTime matDocUntil, int supplyType, string stUnit, decimal netWeight,
            string nwUnit, decimal brutWeight, string bwUnit, int isBom, string bomDocType,
            string bomDocNum, int isRoute, string rotDocType, string rotDocNum,
            int isDeleted, int isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO BSMGR0MATHEAD (
                                    COMCODE, MATDOCTYPE, MATDOCNUM, MATDOCFROM, MATDOCUNTIL, SUPPLYTYPE,
                                    STUNIT, NETWEIGHT, NWUNIT, BRUTWEIGHT, BWUNIT, ISBOM,
                                    BOMDOCTYPE, BOMDOCNUM, ISROUTE, ROTDOCTYPE, ROTDOCNUM, ISDELETED, ISPASSIVE
                                )
                                VALUES (
                                    @comCode, @matDocType, @matDocNum, @matDocFrom, @matDocUntil, @supplyType,
                                    @stUnit, @netWeight, @nwUnit, @brutWeight, @bwUnit, @isBom,
                                    @bomDocType, @bomDocNum, @isRoute, @rotDocType, @rotDocNum, @isDeleted, @isPassive
                                )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@matDocType", matDocType);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);
                command.Parameters.AddWithValue("@matDocFrom", matDocFrom);
                command.Parameters.AddWithValue("@matDocUntil", matDocUntil);
                command.Parameters.AddWithValue("@supplyType", supplyType);
                command.Parameters.AddWithValue("@stUnit", stUnit);
                command.Parameters.AddWithValue("@netWeight", netWeight);
                command.Parameters.AddWithValue("@nwUnit", nwUnit);
                command.Parameters.AddWithValue("@brutWeight", brutWeight);
                command.Parameters.AddWithValue("@bwUnit", bwUnit);
                command.Parameters.AddWithValue("@isBom", isBom);
                command.Parameters.AddWithValue("@bomDocType", bomDocType);
                command.Parameters.AddWithValue("@bomDocNum", bomDocNum);
                command.Parameters.AddWithValue("@isRoute", isRoute);
                command.Parameters.AddWithValue("@rotDocType", rotDocType);
                command.Parameters.AddWithValue("@rotDocNum", rotDocNum);
                command.Parameters.AddWithValue("@isDeleted", isDeleted);
                command.Parameters.AddWithValue("@isPassive", isPassive);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // READ - Belirli Bir Kayıt Getirme
        public DataTable GetRecord(string matDocNum)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BSMGR0MATHEAD WHERE MATDOCNUM = @matDocNum";
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
        public bool UpdateRecord(
            string oldMatDocNum, string comCode, string matDocType, string matDocNum, DateTime matDocFrom,
            DateTime matDocUntil, int supplyType, string stUnit, decimal netWeight,
            string nwUnit, decimal brutWeight, string bwUnit, int isBom, string bomDocType,
            string bomDocNum, int isRoute, string rotDocType, string rotDocNum,
            int isDeleted, int isPassive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE BSMGR0MATHEAD
                                SET COMCODE = @comCode, MATDOCTYPE = @matDocType, MATDOCNUM = @matDocNum,
                                    MATDOCFROM = @matDocFrom, MATDOCUNTIL = @matDocUntil, SUPPLYTYPE = @supplyType,
                                    STUNIT = @stUnit, NETWEIGHT = @netWeight, NWUNIT = @nwUnit,
                                    BRUTWEIGHT = @brutWeight, BWUNIT = @bwUnit, ISBOM = @isBom,
                                    BOMDOCTYPE = @bomDocType, BOMDOCNUM = @bomDocNum, ISROUTE = @isRoute,
                                    ROTDOCTYPE = @rotDocType, ROTDOCNUM = @rotDocNum, ISDELETED = @isDeleted,
                                    ISPASSIVE = @isPassive
                                WHERE MATDOCNUM = @oldMatDocNum";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comCode", comCode);
                command.Parameters.AddWithValue("@matDocType", matDocType);
                command.Parameters.AddWithValue("@matDocNum", matDocNum);
                command.Parameters.AddWithValue("@matDocFrom", matDocFrom);
                command.Parameters.AddWithValue("@matDocUntil", matDocUntil);
                command.Parameters.AddWithValue("@supplyType", supplyType);
                command.Parameters.AddWithValue("@stUnit", stUnit);
                command.Parameters.AddWithValue("@netWeight", netWeight);
                command.Parameters.AddWithValue("@nwUnit", nwUnit);
                command.Parameters.AddWithValue("@brutWeight", brutWeight);
                command.Parameters.AddWithValue("@bwUnit", bwUnit);
                command.Parameters.AddWithValue("@isBom", isBom);
                command.Parameters.AddWithValue("@bomDocType", bomDocType);
                command.Parameters.AddWithValue("@bomDocNum", bomDocNum);
                command.Parameters.AddWithValue("@isRoute", isRoute);
                command.Parameters.AddWithValue("@rotDocType", rotDocType);
                command.Parameters.AddWithValue("@rotDocNum", rotDocNum);
                command.Parameters.AddWithValue("@isDeleted", isDeleted);
                command.Parameters.AddWithValue("@isPassive", isPassive);
                command.Parameters.AddWithValue("@oldMatDocNum", oldMatDocNum);

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
                string query = "DELETE FROM BSMGR0MATHEAD WHERE MATDOCNUM = @matDocNum";
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
    }
}
