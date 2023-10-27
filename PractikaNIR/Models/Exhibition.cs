using PractikaNIR.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Models
{
    public class Exhibition : Item
    {
        public GenerateDate DateBegin { get; set; }
        public GenerateDate DateEnd { get; set; }

        private int yearBeginGen { get; set; }
        private int yearEndGen { get; set; }

        public Exhibition(int yearBeginGen, int yearEndGen) 
        {
            this.yearBeginGen = yearBeginGen;
            this.yearEndGen = yearEndGen;
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

        public override string ToString()
        {
            return $"{Name} \nДата начала: {DateBegin}\nДата окончания: {DateEnd}";
        }
    }
}
