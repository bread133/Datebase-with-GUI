using NIR_7.General;
using NIR_7.Models;
using NIR_7.MySQL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectPlotView.xaml
    /// </summary>
    public partial class SelectPlotView : UserControl
    {
        int n;
        public SelectPlotView()
        {
            try
            {
                InitializeComponent();
                Plot.ClearValue(NameProperty);
                Plot.Plot.Clear();
                n = Convert.ToInt32(N.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ArtistPlotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = Convert.ToInt32(N.Text);
                Plot.ClearValue(NameProperty);
                Plot.Plot.Clear();
                double[] dataX = new double[n];
                double[] dataY = new double[n];
                dataX[0] = 0;
                dataY[0] = 0;
                List<Artist> list = Artist.GenerateItems(n);
                ArtistDb.InsertItems(Connector.sandboxFileSetting, list);
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Artist>.SelectData(Connector.sandboxFileSetting, "artist", i);
                }
                Plot.Plot.AddScatter(dataX, dataY);
                Plot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ExhibitionPlotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = Convert.ToInt32(N.Text);
                Plot.ClearValue(NameProperty);
                Plot.Plot.Clear();
                double[] dataX = new double[n];
                double[] dataY = new double[n];
                dataX[0] = 0;
                dataY[0] = 0;
                List<Exhibit> list = Exhibit.GenerateItems(n);
                ExhibitDb.InsertItems(Connector.sandboxFileSetting, list);
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Exhibition>.SelectData(Connector.sandboxFileSetting, "exhibition", i);
                }
                Plot.Plot.AddScatter(dataX, dataY);
                Plot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void CollectionPlotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = Convert.ToInt32(N.Text);
                Plot.ClearValue(NameProperty);
                Plot.Plot.Clear();
                double[] dataX = new double[n];
                double[] dataY = new double[n];
                dataX[0] = 0;
                dataY[0] = 0;
                List<Collection> list = Collection.GenerateItems(n);
                CollectionDb.InsertItems(Connector.sandboxFileSetting, list);
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Collection>.SelectData(Connector.sandboxFileSetting, "collection", i);
                }
                Plot.Plot.AddScatter(dataX, dataY);
                Plot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ExhibitPlotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = Convert.ToInt32(N.Text);
                Plot.ClearValue(NameProperty);
                Plot.Plot.Clear();
                double[] dataX = new double[n];
                double[] dataY = new double[n];
                dataX[0] = 0;
                dataY[0] = 0;
                List<Exhibit> list = Exhibit.GenerateItems(n);
                ExhibitDb.InsertItems(Connector.sandboxFileSetting, list);
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Exhibit>.SelectData(Connector.sandboxFileSetting, "exhibit", i);
                }
                Plot.Plot.AddScatter(dataX, dataY);
                Plot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
