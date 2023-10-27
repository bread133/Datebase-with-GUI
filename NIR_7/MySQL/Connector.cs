using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using NIR_7.Models;
using System.Windows.Navigation;
using System.Data.Common;
using System.Data.Odbc;
using NIR_7.General;

namespace NIR_7.MySQL
{
    public class Connector
    {
        public static string FileSetting { get; set; }

        public const string sandboxFileSetting =
            "server=127.0.0.1;" +
                    "uid=root;" +
                    "pwd=root;" +
                    "database=sandbox";

        public const string galleryFileSetting =
            "server=127.0.0.1;" +
                    "uid=root;" +
                    "pwd=root;" +
                    "database=artist_gallery";
        protected MySqlConnection Connection { get; private set; }
        public Connector() { }
        public Connector(string fileSetting)
        {
            FileSetting = fileSetting;
        }

        public static void CreateTables(string fileSettings)
        {
            ArtistDb.CreateTable(fileSettings);
            ExhibitionDb.CreateTable(fileSettings);
            CollectionDb.CreateTable(fileSettings);
            ExhibitDb.CreateTable(fileSettings);
        }

        public static int MovementToDb(string fileSettings, string request)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand cmd = new(request, connection);
            var result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public static string StartTransactionAndCommit(string request) =>
            $"START TRANSACTION; {request}; COMMIT; SET autocommit = 0;";

        // для добавления данных для измерения времени
        public static string StartTransactionAndRollback(string request) =>
            $"START TRANSACTION; {request}; ROLLBACK; SET autocommit = 0;";

        public static int SelectRandomForeighnKey(string fileSettings, string dataTable)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = StartTransactionAndCommit($"SELECT Ids FROM `{dataTable}` ORDER BY RAND() LIMIT 1");
            int result = int.Parse(cmd.ExecuteScalar().ToString());

            connection.Close();
            return result;
        }

        public static int SelectInt(string fileSettings, string dataTable)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = StartTransactionAndCommit($"SELECT COUNT(*) FROM `{dataTable}`");
            int result = int.Parse(cmd.ExecuteScalar().ToString());

            connection.Close();
            return result;
        }

        public static DataSet SelectItems(string fileSettings, string request)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlDataAdapter dataAdapter = new(StartTransactionAndCommit(request), connection);
            DataSet result = new();
            dataAdapter.Fill(result);

            connection.Close();
            return result;
        }

        public static int DeleteItems(string fileSettings, Tables table) =>
            MovementToDb(fileSettings,
                StartTransactionAndCommit(DeleteItemString(table)));

        public static int DeleteItemsForPlot(string fileSettings, string table, int n)
        {
            return MovementToDb(fileSettings,
                StartTransactionAndRollback($"DELETE FROM `{table}` LIMIT {n}"));
        }

        public static string DeleteItemString(Tables table) =>
            $"DELETE FROM `{table}`";
    }
}
