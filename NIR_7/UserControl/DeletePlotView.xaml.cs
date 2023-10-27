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
    /// Interaction logic for DeletePlotView.xaml
    /// </summary>
    public partial class DeletePlotView : UserControl
    {
        int n;
        public DeletePlotView()
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
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Artist>.DeleteData(Artist.GenerateItems, ArtistDb.InsertItems, ArtistDb.DeleteItems, 
                        "artist", Connector.sandboxFileSetting, i, Connector.DeleteItemsForPlot);
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
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Exhibition>.DeleteData(Exhibition.GenerateItems, ExhibitionDb.InsertItems, ExhibitionDb.DeleteItems,
                        "exhibition", Connector.sandboxFileSetting, i, Connector.DeleteItemsForPlot);
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
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Collection>.DeleteData(Collection.GenerateItems, CollectionDb.InsertItems, CollectionDb.DeleteItems, 
                        "collection", Connector.sandboxFileSetting, i, Connector.DeleteItemsForPlot);
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
                for (int i = 1; i < n; i++)
                {
                    dataX[i] = i;
                    dataY[i] = MyTimer<Exhibit>.DeleteData(Exhibit.GenerateItems, ExhibitDb.InsertItems, ExhibitDb.DeleteItems,
                        "exhibit", Connector.sandboxFileSetting, i, Connector.DeleteItemsForPlot);
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
