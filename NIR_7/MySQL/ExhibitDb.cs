using MySql.Data.MySqlClient;
using NIR_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.MySQL
{
    public class ExhibitDb : IMovementDb<Exhibit>
    {
        public static int CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS exhibit (" +
                "Ids INT NOT NULL UNIQUE PRIMARY KEY AUTO_INCREMENT, " +
                "Names VARCHAR(45) NOT NULL, " +
                "Year INT NOT NULL, " +
                "CollectionId INT NOT NULL, " +
                "ArtistId INT NOT NULL, " +
                "FOREIGN KEY (CollectionId) " +
                "REFERENCES collection(Ids) " +
                "ON DELETE CASCADE, " +
                "FOREIGN KEY (ArtistId) " +
                "REFERENCES artist(Ids) " +
                "ON DELETE CASCADE)");
        public static int DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Exhibit);

        public static int InsertItem(string fileSettings, Exhibit item)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand command = new(
                Connector.StartTransactionAndCommit(
                "INSERT INTO exhibit (Names, Year, CollectionId, ArtistId) " +
                "VALUES(@Names, @Year, @CollectionId, @ArtistId)"),
                connection);

            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("Year", item.Year);
            command.Parameters.AddWithValue("CollectionId", item.CollectionId);
            command.Parameters.AddWithValue("ArtistId", item.ArtistId);
            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public static int InsertItems(string fileSettings, List<Exhibit> items)
        {
            int result = 0;
            foreach (Exhibit item in items)
                result += InsertItem(fileSettings, item);
            return result;
        }
    }
}
