using NIR_7.Models;
using NIR_7.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NIR_7.General
{
    public static class MyTimer<T> where T : Item
    {
        public delegate List<T> GenerationItems(int n);
        public delegate int InsertItems(string fileSettings, List<T> items);
        public delegate int DeleteItems(string fileSettings);
        public delegate int DeleteItemsForPlot(string fileSettings, string table, int n);
        public delegate DataSet SelectItems(string fileSettings, string request);

        public static double GenerationData(GenerationItems generationItems, int n)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();
            generationItems(n);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts.TotalMilliseconds;
        }

        public static double InsertData(InsertItems insertItems, GenerationItems generationItems, int n, string fileSettings)
        {
            List<T> list = generationItems(n);
            Stopwatch stopWatch = new();
            stopWatch.Start();
            insertItems(fileSettings, list);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts.TotalMilliseconds;
        }

        public static double DeleteData(GenerationItems generationItems, InsertItems insertItems, DeleteItems deleteItems, 
            string table, string fileSettings, int i, DeleteItemsForPlot deleteItemsForPlot)
        {
            deleteItems(fileSettings);
            List<T> list = generationItems(i);
            Stopwatch stopWatch = new();
            stopWatch.Start();
            deleteItemsForPlot(fileSettings, table, i);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts.TotalMilliseconds;
        }

        public static double SelectData(string fileSettings, string tableName, int i)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();
            Connector.SelectItems(fileSettings, 
                $"SELECT * FROM `{tableName}` LIMIT {i}");
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts.TotalMilliseconds;
        }
    }
}
