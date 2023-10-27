using PractikaNIR.Generators;
using PractikaNIR.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Models
{
    public class Exhibit : Item
    {
        public int Year { get; set; }
        public int CollectionName { get; set; }
        public int ArtistName { get; set; }
        public Artist Artist { get; set; }

        private int numberCollection;

        public Exhibit(int _numberCollection, Artist artist)
        {
            numberCollection = new Random().Next(1, _numberCollection + 1);
            Artist = artist;
        }

        public Exhibit(int _numberCollection, Artist artist, int artistId) 
        {
            numberCollection = new Random().Next(1, _numberCollection + 1);
            Artist = artist;
            ArtistId = artistId;
        }

        public override void Generate()
        {
            Name = new GenerateWord(10, 45).ToString();
            CollectionId = numberCollection;
            Year = new Random().Next(Artist.Birth.Date.Year + 15, Artist.Death.Date.Year);
        }

        public override string ToString()
        {
            return $"Название: {Name}\nГод создания: {Year}\nНомер коллекции: {CollectionId}\nХудожник: {Artist.Name}";
        }
    }
}
