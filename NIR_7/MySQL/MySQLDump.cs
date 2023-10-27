using NIR_7.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NIR_7.MySQL
{
    public static class MySQLDump
    {
        public static void CreateDump(string username, string password, string databases, string request, string systemPath)
        {
            string result = Cmd.ExecuteDump(request, systemPath);
            if (result != null) // костыль
            {
                StreamWriter sw = new StreamWriter(systemPath);
                sw.WriteLine(result);
                sw.Close();
            }
            MessageBox.Show($"Создан бекап по пути {systemPath}.", "Инфо", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        public static void CreateFullDump(string username, string password, string databases, string name) => 
            CreateDump(username, password, databases, 
                $"--single-transaction --triggers --user={username} --password={password} --databases {databases}",
                $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Dumps\{name}.sql");

        public static void CreateNoDataDump(string username, string password, string databases, string name) =>
            CreateDump(username, password, databases, 
                $"--single-transaction --no-data --no-create-db --user={username} --password={password} --databases {databases}",
                $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Dumps\{name}.sql");
    }
}
