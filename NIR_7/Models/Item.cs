using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public abstract void Generate();
    }
}
