using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PractikaNIR.Models;

namespace PractikaNIR.MySQL
{
    public class Connector
    {
        public const string FileSettingsSandox =
            "server=127.0.0.1;" +
            "uid=root;" +
            "pwd=root;" +
            "database=sandbox";

        public const string FileSettingsGallery =
           "server=127.0.0.1;" +
           "uid=root;" +
           "pwd=root;" +
           "database=artist_gallery";

        protected MySqlConnection Connection { get; private set; }

        public Connector() { }

        public void ConnectionToDatabase(string fileSettings)
        {
            try
            {
                Connection = new()
                {
                    ConnectionString = fileSettings
                };
                Connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again.");
                        break;
                }
            }
        }

        public static MySqlConnection ConnectionToDb(string fileSettings)
        {
            try
            {
                MySqlConnection connection = new()
                {
                    ConnectionString = fileSettings
                };
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again.");
                        break;
                }
                throw new Exception(ex.Message);
            }
        }

        public void ConnectionToGallery() =>
            ConnectionToDatabase(FileSettingsGallery);

        public void ConnectionToSandBox() =>
            ConnectionToDatabase(FileSettingsSandox);

        public static void MovementToDb(string fileSettings, string request)
        {
            try
            {
                Connector connector = new();
                connector.ConnectionToDatabase(fileSettings);
                MySqlCommand cmd = new(request, connector.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DropTable(string fileSettings, Tables table, string modifier) =>
            MovementToDb(fileSettings,
                $"DROP TABLE `{table}` " + modifier);

        public static void DeleteItems(string fileSettings, Tables table) =>
            MovementToDb(fileSettings,
                $"DELETE FROM `{table}`");
    }
}
