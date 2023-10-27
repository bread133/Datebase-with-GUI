using MySql.Data.MySqlClient;
using NIR_7.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NIR_7
{
    /// <summary>
    /// Interaction logic for PasswordBoxView.xaml
    /// </summary>
    public partial class PasswordBoxView : Window
    {
        public PasswordBoxView()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ps = Password.Password.ToString();
                Connector.FileSetting = 
                    "server=localhost;" +
                    "uid=root;" +
                    $"pwd={ps};" +
                    "database=sandbox";

                MySqlConnection connection = new()
                {
                    ConnectionString = Connector.FileSetting
                };
                connection.Open();
                connection.Close();

                Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
