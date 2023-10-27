using MySql.Data.MySqlClient;
using PractikaNIR.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.MySQL
{
    public class ArtistDb : IMovementDb<Artist>
    {
        public static void CreateTable(string fileSettings) =>
            Connector.MovementToDb(fileSettings,
                "CREATE TABLE IF NOT EXISTS artist (" +
                "Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
                "Names VARCHAR(45) NOT NULL UNIQUE, " +
                "Birth DATE NOT NULL, " +
                "Death DATE NOT NULL)");

        public static void DropTable(string fileSettings) =>
            Connector.DropTable(fileSettings, Tables.Artist, "CASCADE");

        public static void DeleteItems(string fileSettings) =>
            Connector.DeleteItems(fileSettings, Tables.Artist);

        //Connector.MovementToDb(fileSettings,
        //        $"INSERT INTO artist (Names, Birth, Death) VALUES('{item.Name}', '{item.Birth}', '{item.Death}')"); - колхоз
        public static void InsertItem(string fileSettings, Artist item) 
        {
            var connection = Connector.ConnectionToDb(fileSettings);
            MySqlCommand command = new(
                "INSERT INTO artist (Names, Birth, Death) " +
                "VALUES(@Name, @Birth, @Death)", 
                connection);
            command.Parameters.AddWithValue("Name", item.Name);
            command.Parameters.AddWithValue("Birth", item.Birth.Date);
            command.Parameters.AddWithValue("Death", item.Death.Date);

            command.ExecuteNonQuery();
        }

        public static void InsertItems(string fileSettings, List<Artist> items)
        {
            foreach (Artist item in items)
                InsertItem(fileSettings, item);
        }

        public static void UpdateItem(string fileSettings, string name)
        {
            
        }
    }
}
