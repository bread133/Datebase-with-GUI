using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.Win32;
using NIR_7.MySQL;

namespace NIR_7
{
    /// <summary>
    /// Interaction logic for ConfigureDump.xaml
    /// </summary>
    public partial class ConfigureDump : UserControl
    {
        public ConfigureDump()
        {
            InitializeComponent();
        }

        private void FullDumpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySQLDump.CreateFullDump(User.Text, Password.Password.ToString(), Database.Text, Path.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void NoDataDumpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySQLDump.CreateNoDataDump(User.Text, Password.Password.ToString(), Database.Text, Path.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void SimpleBackupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySQLBackup.CreateBackup(User.Text, Password.Password.ToString(), Database.Text,
                $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Dumps\{Path.Text}.sql",
                $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Dumps\backup.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
