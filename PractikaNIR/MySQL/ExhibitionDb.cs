using MySql.Data.MySqlClient;
using PractikaNIR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.MySQL
{
    public class ExhibitionDb : IMovementDb<Exhibition>
    {
        public static void CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS exhibition (" +
                "Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
                "Names VARCHAR(45) NOT NULL UNIQUE, " +
                "DateBegin DATE NOT NULL, " +
                "DateFinish DATE NOT NULL)");

        public static void DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Exhibition);

        public static void DropTable(string fileSettings) =>
             Connector.DropTable(fileSettings, Tables.Exhibition, "CASCADE");

        public static void InsertItem(string fileSettings, Exhibition item)
        {
            var connection = Connector.ConnectionToDb(fileSettings);
            MySqlCommand command = new(
                "INSERT INTO exhibition (Names, DateBegin, DateFinish) " +
                "VALUES(@Names, @DateBegin, @DateFinish)",
                connection);
            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("DateBegin", item.DateBegin.Date);
            command.Parameters.AddWithValue("DateFinish", item.DateEnd.Date);

            command.ExecuteNonQuery();
        }

        public static void InsertItems(string fileSettings, List<Exhibition> items)
        {
            foreach (Exhibition item in items)
                InsertItem(fileSettings, item);
        }

        public static void UpdateItem(string fileSettings, string name)
        {
            throw new NotImplementedException();
        }
    }
}
