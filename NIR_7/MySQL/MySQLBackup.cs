using MySqlX.XDevAPI.Common;
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
    public static class MySQLBackup
    {
        public static void CreateBackup(string username, string password, string database, string fileNameDump, string systemPathBatch) 
        {
            //Б - безопасность
            StreamWriter sw = new StreamWriter(systemPathBatch);
            sw.WriteLine(
                "cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\n"
                + $"mysql --user={username} --password={password} {database} < {fileNameDump}");
            sw.Close();

            Cmd.ExecuteBackup(systemPathBatch);

            MessageBox.Show($"Бекап создан в базе данных {database}", "Инфо",
                MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

            sw = new StreamWriter(systemPathBatch);
            sw.Close();
        }
    }
}
