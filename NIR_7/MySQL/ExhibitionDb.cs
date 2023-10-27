using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using NIR_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.MySQL
{
    public class ExhibitionDb : IMovementDb<Exhibition>
    {
        public static int CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS exhibition (" +
                "Ids INT NOT NULL UNIQUE PRIMARY KEY AUTO_INCREMENT, " +
                "Names VARCHAR(45) NOT NULL, " +
                "DateBegin DATE NOT NULL, " +
                "DateFinish DATE NOT NULL)");

        public static int DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Exhibition);

        public static int InsertItem(string fileSettings, Exhibition item)
        {
            MySqlConnection connection = new()
            {
                ConnectionString = fileSettings
            };
            connection.Open();

            MySqlCommand command = new(
                Connector.StartTransactionAndCommit(
                "INSERT INTO exhibition (Names, DateBegin, DateFinish) " +
                "VALUES(@Names, @DateBegin, @DateFinish)"),
                connection);
            command.Parameters.AddWithValue("Names", item.Name);
            command.Parameters.AddWithValue("DateBegin", item.DateBegin.Date);
            command.Parameters.AddWithValue("DateFinish", item.DateEnd.Date);
            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public static int InsertItems(string fileSettings, List<Exhibition> items)
        {
            int result = 0;
            foreach (Exhibition item in items)
                result += InsertItem(fileSettings, item);
            return result;
        }
    }
}
