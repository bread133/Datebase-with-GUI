using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Generators
{
    public class GenerateWord
    {
        private Random random = new Random();
        private int n;
        private StringBuilder result = new StringBuilder();
        public GenerateWord(int begin, int end)
        {
            n = random.Next(begin, end);
            char c = (char)random.Next(65, 91);
            result.Append(c); // большая буква
            for (int i = 1; i < n; i++)
                result.Append((char)random.Next(97, 123)); // маленькие буквы
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }
}
