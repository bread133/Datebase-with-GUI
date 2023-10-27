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
    /// Interaction logic for DeleteControl.xaml
    /// </summary>
    public partial class DeleteControl : UserControl
    {
        int valuesExhibit;
        int valuesCollection;

        void SelectSome()
        {
            // сделать селекты количества строк, запретить/разрешить доступ к кнопкам
            valuesExhibit = Connector.SelectInt(Connector.sandboxFileSetting, "exhibit");
            valuesCollection = Connector.SelectInt(Connector.sandboxFileSetting, "collection");
        }

        public DeleteControl()
        {
            SelectSome();
            InitializeComponent();
        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectSome();
                int result = ArtistDb.DeleteItems(Connector.sandboxFileSetting);

                MessageBox.Show($"Удаление {result} строк завершено", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ExhibitionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectSome();
                int result = ExhibitionDb.DeleteItems(Connector.sandboxFileSetting);

                MessageBox.Show($"Удаление {result} строк завершено", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void CollectionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectSome();
                int result = CollectionDb.DeleteItems(Connector.sandboxFileSetting);

                MessageBox.Show($"Удаление {result} строк завершено", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ExhibitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectSome();
                int result = ExhibitDb.DeleteItems(Connector.sandboxFileSetting);

                MessageBox.Show($"Удаление {result} строк завершено", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
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
