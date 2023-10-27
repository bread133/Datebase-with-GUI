using MySqlX.XDevAPI.Common;
using NIR_7.General;
using NIR_7.MySQL;
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

namespace NIR_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //PasswordBoxView passwordBox = new PasswordBoxView();
            //passwordBox.ShowDialog();

            //if(Connector.FileSetting == null) 
            //    Environment.Exit(0);
            Connector.CreateTables(Connector.sandboxFileSetting);
            Connector.CreateTables(Connector.galleryFileSetting);

            InitializeComponent();
            MessageBox.Show("Таблицы базы данных успешно сгенерировались", "Создание таблиц", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void CreateDataForTables_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                insertPlot.Visibility = Visibility.Hidden;
                timeGeneration.Visibility = Visibility.Hidden;
                selectControl.Visibility = Visibility.Hidden;
                createData.Visibility = Visibility.Visible;
                deleteControl.Visibility = Visibility.Hidden;
                configureDump.Visibility = Visibility.Hidden;
                deletePlot.Visibility = Visibility.Hidden;
                selectPlot.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public void DeleteDataForTables_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Visible;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        public void CreateGallery_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            selectControl.Visibility= Visibility.Visible;
            createData.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void DumpButton_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Visible;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void GeneratePlotButton_Click(object sender, EventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Visible;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void InsertPlotButton_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Visible;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void DeletePlotButton_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Visible;
            selectPlot.Visibility = Visibility.Hidden;
        }

        private void SelectPlotButton_Click(object sender, RoutedEventArgs e)
        {
            insertPlot.Visibility = Visibility.Hidden;
            timeGeneration.Visibility = Visibility.Hidden;
            createData.Visibility = Visibility.Hidden;
            selectControl.Visibility = Visibility.Hidden;
            deleteControl.Visibility = Visibility.Hidden;
            configureDump.Visibility = Visibility.Hidden;
            deletePlot.Visibility = Visibility.Hidden;
            selectPlot.Visibility = Visibility.Visible;
        }
    }
}
