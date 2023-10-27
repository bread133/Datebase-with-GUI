using PractikaNIR.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Models
{
    public class Collection : Item
    {
        public int ExhibitionId { get; set; }
        private int numberExhibition;

        public Collection(int _numberExhibition) 
        {
            numberExhibition = _numberExhibition;
        }

        public override void Generate()
        {
            Name = new GenerateWord(10, 45).ToString();
            ExhibitionId = new Random().Next(1, numberExhibition + 1);
        }

        public override string ToString()
        {
            return $"{Name}\nНомер коллекции: {ExhibitionId}";
        }
    }
}
