using MySqlX.XDevAPI.Relational;
using PractikaNIR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaNIR.MySQL
{
    public interface IMovementDb<T> where T : Item
    {
        public static abstract void CreateTable(string fileSettings);
        public static abstract void DropTable(string fileSettings);
        public static abstract void DeleteItems(string fileSettings);
        public static abstract void InsertItem(string fileSettings, T item);
        public static abstract void InsertItems(string fileSettings, List<T> items);
        public static abstract void UpdateItem(string fileSettings, string name);
    }
}
