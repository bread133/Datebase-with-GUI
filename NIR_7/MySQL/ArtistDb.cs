using MySql.Data.MySqlClient;
using NIR_7.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.MySQL
{
    public class ArtistDb : IMovementDb<Artist>
    {
        public static int CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS artist (" +
                "Ids INT NOT NULL UNIQUE PRIMARY KEY AUTO_INCREMENT, " +
                "Names VARCHAR(45) NOT NULL UNIQUE, " +
                "Birth DATE NOT NULL, " +
                "Death DATE)");

        public static int DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Artist);

        //Connector.MovementToDb(fileSettings,
        //        $"INSERT INTO artist (Names, Birth, Death) VALUES('{item.Name}', '{item.Birth}', '{item.Death}')"); - колхоз
        public static int InsertItem(string fileSettings, Artist item) 
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand command = new(
                Connector.StartTransactionAndCommit(
                "INSERT INTO artist (Names, Birth, Death) " +
                "VALUES(@Name, @Birth, @Death)"), 
                connection);
            command.Parameters.AddWithValue("Name", item.Name);
            command.Parameters.AddWithValue("Birth", item.Birth.Date);
            command.Parameters.AddWithValue("Death", item.Death.Date);
            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public static int InsertItems(string fileSettings, List<Artist> items)
        {
            int result = 0;

            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            foreach (Artist item in items)
            {
                result += InsertItem(fileSettings, item);
            }

            connection.Close();
            return result;
        }
    }
}
