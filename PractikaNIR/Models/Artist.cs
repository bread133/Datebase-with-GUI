using PractikaNIR.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Models
{
    public class Artist : Item
    {
        public GenerateDate Birth { get; set; }
        public GenerateDate Death { get; set; }

        public Artist()
        {

        }

        public override void Generate()
        {
            Random random = new();
            Name = new GenerateWord(3, 10).ToString() + ' '
                + new GenerateWord(3, 10).ToString();
            int _birth = random.Next(1200, 2000);
            Birth = new GenerateDate(_birth);
            int timeOfLife = random.Next(17, 100);
            Death = new GenerateDate(_birth + timeOfLife);
        }

        public override string ToString()
        {
            return $"{Name}\nYearOfBirth: {Birth} + \nYearOfDeath: {Death}";
        }
    }
}
