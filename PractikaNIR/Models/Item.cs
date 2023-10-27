using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract void Generate();
    }
}
