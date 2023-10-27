using NIR_7.MySQL;
using System.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ScottPlot.SnapLogic;
using NIR_7.General;

namespace NIR_7
{
    /// <summary>
    /// Interaction logic for SelectControl.xaml
    /// </summary>
    public partial class SelectControl : UserControl
    {
        public SelectControl()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = Csv.Text.Trim();
                Stopwatch stopWatch = new();
                stopWatch.Start();
                DataTable data = Connector.SelectItems(Connector.sandboxFileSetting, textSelect.Text).Tables[0];
                stopWatch.Stop();

                Csv.Text = ConvertDataTable.ToCSV(data);

                TimeSpan ts = stopWatch.Elapsed;
                String elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                TimeBox.Text = elapsedTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void SelectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
