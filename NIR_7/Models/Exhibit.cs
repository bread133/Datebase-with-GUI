using MySql.Data.MySqlClient;
using NIR_7.Generators;
using NIR_7.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.Models
{
    public class Exhibit : Item
    {
        public int Year { get; set; }
        public int CollectionId { get; set; }
        public int ArtistId { get; set; }

        private int numberCollection;
        private int numberArtist;

        public Exhibit(int _numberCollection, int _numberArtist)
        {
            numberCollection = _numberCollection;
            numberArtist = _numberArtist;
        }

        public override void Generate()
        {
            Random random = new();

            Name = new GenerateWord(10, 45).ToString();

            CollectionId = numberCollection;
            ArtistId = numberArtist;

            Year = new Random().Next(1200, 2000);
        }

        public static List<Exhibit> GenerateItems(int n)
        {
            List<Exhibit> list = new();
            for (int i = 0; i < n; i++)
            {
                int numberArtist = Connector.SelectRandomForeighnKey(Connector.sandboxFileSetting, "artist");
                int numberCollection = Connector.SelectRandomForeighnKey(Connector.sandboxFileSetting, "collection");

                Exhibit item = new(numberCollection, numberArtist);
                item.Generate();
                list.Add(item);
            }
            return list;
        }

        public override string ToString()
        {
            return $"Название: {Name}\nГод создания: {Year}\nНомер коллекции: {CollectionId}";
        }
    }
}
