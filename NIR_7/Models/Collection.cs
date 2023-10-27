using NIR_7.Generators;
using NIR_7.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.Models
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
            ExhibitionId = numberExhibition;
        }

        public static List<Collection> GenerateItems(int n)
        {
            List<Collection> list = new();
            for (int i = 0; i < n; i++)
            {
                int numberExhibition = Connector.SelectRandomForeighnKey(Connector.sandboxFileSetting, "exhibition");
                Collection item = new(numberExhibition);
                item.Generate();
                list.Add(item);
            }
            return list;
        }

        public override string ToString()
        {
            return $"{Name}\nНомер коллекции: {ExhibitionId}";
        }
    }
}
