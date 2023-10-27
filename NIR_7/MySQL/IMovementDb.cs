using MySqlX.XDevAPI.Relational;
using NIR_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.MySQL
{
    public interface IMovementDb<T> where T : Item
    {
        public static abstract int CreateTable(string fileSettings);
        public static abstract int DeleteItems(string fileSettings);
        public static abstract int InsertItem(string fileSettings, T item);
        public static abstract int InsertItems(string fileSettings, List<T> items);
    }
}
