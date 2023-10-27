using NIR_7.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.Models
{
    public class Exhibition : Item
    {
        public GenerateDate DateBegin { get; set; }
        public GenerateDate DateEnd { get; set; }

        private int yearBeginGen { get; set; }
        private int yearEndGen { get; set; }

        public Exhibition(int _yearBeginGen, int _yearEndGen) 
        {
            yearBeginGen = _yearBeginGen;
            yearEndGen = _yearEndGen;
        }

        public override void Generate()
        {
            Random random = new Random();
            Name = new GenerateWord(15, 45).ToString();
            DateBegin = new GenerateDate(yearBeginGen, yearEndGen);

            DateEnd = new GenerateDate(DateBegin.Date.Year);
            if (DateBegin > DateEnd)
            {
                GenerateDate temp = DateBegin;
                DateBegin = DateEnd;
                DateEnd = temp;
            }
        }

        public static List<Exhibition> GenerateItems(int n)
        {
            List<Exhibition> list = new();
            for (int i = 0; i < n; i++)
            {
                Exhibition item = new(2023, 2025);
                item.Generate();
                list.Add(item);
            }
            return list;
        }

        public static List<Exhibition> GenerateItems(int n, int _yearBeginGen, int _yearEndGen)
        {
            List<Exhibition> list = new();
            for (int i = 0; i < n; i++)
            {
                Exhibition item = new(_yearBeginGen, _yearEndGen);
                item.Generate();
                list.Add(item);
            }
            return list;
        }

        public override string ToString()
        {
            return $"{Name} \nДата начала: {DateBegin}\nДата окончания: {DateEnd}";
        }
    }
}
