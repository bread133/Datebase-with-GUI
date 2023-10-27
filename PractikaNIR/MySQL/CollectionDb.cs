using MySql.Data.MySqlClient;
using PractikaNIR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.MySQL
{
    public class CollectionDb : IMovementDb<Collection>
    {
        public static void CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS collection (" +
                "Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
                "Names VARCHAR(45) NOT NULL UNIQUE, " +
                "ExhibitionId INT, " +
                "FOREIGN KEY (ExhibitionId) " +
                "REFERENCES exhibition(Id) " +
                "ON DELETE CASCADE ON UPDATE CASCADE)");

        public static void DropTable(string fileSettings) =>
            Connector.DropTable(fileSettings, Tables.Collection, "CASCADE");

        public static void DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Collection);

        public static void InsertItem(string fileSettings, Collection item)
        {
            var connection = Connector.ConnectionToDb(fileSettings);
            MySqlCommand command = new(
                "INSERT INTO collection (Names, ExhibitionId) " +
                "VALUES(@Names, @ExhibitionId)",
                connection);
            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("ExhibitionId", item.ExhibitionId);

            command.ExecuteNonQuery();
        }

        public static void InsertItems(string fileSettings, List<Collection> items)
        {
            foreach (Collection item in items)
                InsertItem(fileSettings, item);
        }

        public static void UpdateItem(string fileSettings, string name)
        {
            throw new NotImplementedException();
        }
    }
}
