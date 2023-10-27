using MySql.Data.MySqlClient;
using NIR_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.MySQL
{
    public class CollectionDb : IMovementDb<Collection>
    {
        public static int CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS collection (" +
                "Ids INT NOT NULL UNIQUE PRIMARY KEY AUTO_INCREMENT, " +
                "Names VARCHAR(45) NOT NULL UNIQUE, " +
                "ExhibitionId INT NOT NULL, " +
                "FOREIGN KEY (ExhibitionId) " +
                "REFERENCES exhibition(Ids) " +
                "ON DELETE CASCADE)");

        public static int DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Collection);

        public static int InsertItem(string fileSettings, Collection item)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand command = new(
                Connector.StartTransactionAndCommit(
                "INSERT INTO collection (Names, ExhibitionId) " +
                "VALUES(@Names, @ExhibitionId)"),
                connection);
            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("ExhibitionId", item.ExhibitionId);
            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public static int InsertItems(string fileSettings, List<Collection> items)
        {
            int result = 0;
            foreach (Collection item in items)
                result += InsertItem(fileSettings, item);
            return result;
        }
    }
}
