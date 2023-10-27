using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Generators
{
    public class GenerateDate
    {
        private Random random = new();

        public DateTime Date;

        private int GenerateYear(int beginYear, int endYear)
        {
            if (beginYear < 1000)
            {
                throw new ArgumentOutOfRangeException("Начальный год должен быть не меньше 1000 года.");
            }
            if (endYear > DateTime.Now.Year + 2)
            {
                throw new ArgumentOutOfRangeException("Конечный год должен быть не больше текущего.");
            }
            return random.Next(beginYear, endYear);
        }

        private int GenerateMonth() => random.Next(1, 12);

        private int GenerateDay(int year, int month)
        {
            return month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => random.Next(1, 32),
                2 when year % 4 == 0 && year % 100 != 0 || year % 400 == 0 => random.Next(1, 30),
                2 => random.Next(1, 29),
                _ => random.Next(1, 31),
            };
        }

        public GenerateDate(int year) // год задается, все остальное генерируется
        {
            int month = GenerateMonth();
            Date = new DateTime(year, month, GenerateDay(year, month));
        }
        public GenerateDate(int beginYear, int endYear) // все числа генерируется, год задается в диапазоне
        {
            int year = GenerateYear(beginYear, endYear);
            int month = GenerateMonth();
            int day = GenerateDay(year, month);

            Date = new DateTime(year, month, day);
        }

        public GenerateDate(int year, int month, int day) // все задается вручную, это для тестов
        {
            Date = new DateTime(year, month, day);
        }

        public static GenerateDate operator +(GenerateDate f1, int year)
        {
            return new GenerateDate(f1.Date.Year + year, f1.Date.Month, f1.Date.Day);
        }

        public static bool operator<(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date < f2.Date;
        }

        public static bool operator >(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date > f2.Date;
        }

        public static bool operator <=(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date <= f2.Date;
        }

        public static bool operator >=(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date >= f2.Date;
        }

        public static bool operator ==(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date == f2.Date;
        }

        public static bool operator !=(GenerateDate f1, GenerateDate f2)
        {
            return f1.Date != f2.Date;
        }

        public override string ToString()
        {
            return Date.Year.ToString() + "-" + Date.Month.ToString() + "-" + Date.Day.ToString();
        }
    }
}
