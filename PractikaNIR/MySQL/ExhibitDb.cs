using MySql.Data.MySqlClient;
using PractikaNIR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.MySQL
{
    public class ExhibitDb : IMovementDb<Exhibit>
    {
        public static void CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS exhibit (" +
                "Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
                "Names VARCHAR(85) NOT NULL UNIQUE, " +
                "Year INT NOT NULL, " +
                "CollectionId INT NOT NULL, " +
                "ArtistId INT," +
                "FOREIGN KEY (CollectionId) " +
                "REFERENCES collection(Id) " +
                "ON DELETE CASCADE ON UPDATE CASCADE, " +
                "FOREIGN KEY (ArtistId) " +
                "REFERENCES artist(Id) " +
                "ON DELETE CASCADE ON UPDATE CASCADE)");

        public static void DropTable(string fileSettings) =>
            Connector.DropTable(fileSettings, Tables.Exhibit, "CASCADE");
        public static void DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Exhibit);

        public static void InsertItem(string fileSettings, Exhibit item)
        {
            var connection = Connector.ConnectionToDb(fileSettings);
            MySqlCommand command = new(
                "INSERT INTO exhibit (Names, Year, CollectionId, ArtistId) " +
                "VALUES(@Names, @Year, @CollectionId, @ArtistId)",
                connection);
            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("Year", item.Year);
            command.Parameters.AddWithValue("CollectionId", item.CollectionId);
            command.Parameters.AddWithValue("ArtistId", item.ArtistId);

            command.ExecuteNonQuery();
        }

        public static void InsertItems(string fileSettings, List<Exhibit> items)
        {
            foreach (Exhibit item in items)
                InsertItem(fileSettings, item);
        }

        public static void UpdateItem(string fileSettings, string name)
        {
            throw new NotImplementedException();
        }
    }
}
