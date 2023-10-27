using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace NIR_7
{
    /// <summary>
    /// Interaction logic for CreateDataForTables.xaml
    /// </summary>
    public partial class CreateDataForTables : UserControl
    {
        // сделать селекты количества строк, запретить/разрешить доступ к кнопкам
        int valuesArtist;
        int valuesExhibition;
        int valuesCollection;

        void SelectSome()
        {
            // сделать селекты количества строк, запретить/разрешить доступ к кнопкам
            valuesArtist = Connector.SelectInt(Connector.sandboxFileSetting, "artist");
            valuesExhibition = Connector.SelectInt(Connector.sandboxFileSetting, "exhibition");
            valuesCollection = Connector.SelectInt(Connector.sandboxFileSetting, "collection");
        }

        public CreateDataForTables()
        {
            try
            {
                SelectSome();
                InitializeComponent();

                if (valuesArtist == 0 || valuesCollection == 0)
                    ExhibitButton.IsEnabled = false;
                if (valuesExhibition == 0)
                {
                    CollectionButton.IsEnabled = false;
                    ExhibitButton.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
             
        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectSome();

                if (!(textNumber.Text.All(Char.IsDigit)))
                    throw new Exception("Формат ввода количества строк неверный.");

                int n = Convert.ToInt32(textNumber.Text);
                List<Artist> list = Artist.GenerateItems(n);

                int result = ArtistDb.InsertItems(Connector.sandboxFileSetting, list);

                MessageBox.Show($"Добавлено {result} строк в таблицу artist", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

                if (valuesCollection != 0)
                    ExhibitButton.IsEnabled = true;

                if (valuesArtist == 0 || valuesCollection == 0)
                    ExhibitButton.IsEnabled = false;
                if (valuesExhibition == 0)
                {
                    CollectionButton.IsEnabled = false;
                    ExhibitButton.IsEnabled = false;
                }

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

                if (!(textNumber.Text.All(Char.IsDigit)))
                    throw new Exception("Формат ввода количества строк неверный.");

                int n = Convert.ToInt32(textNumber.Text);
                List<Exhibition> list = Exhibition.GenerateItems(n, 2023, 2025);

                int result = ExhibitionDb.InsertItems(Connector.sandboxFileSetting, list);

                MessageBox.Show($"Добавлено {result} строк в таблицу exhibition", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

                CollectionButton.IsEnabled = true;

                if (valuesArtist == 0 || valuesCollection == 0)
                    ExhibitButton.IsEnabled = false;
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

                if (!(textNumber.Text.All(Char.IsDigit)))
                    throw new Exception("Формат ввода количества строк неверный.");

                int n = Convert.ToInt32(textNumber.Text);
                List<Collection> list = Collection.GenerateItems(n);

                int result = CollectionDb.InsertItems(Connector.sandboxFileSetting, list);

                MessageBox.Show($"Добавлено {result} строк в таблицу collection", "Инфо",
                    MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

                if (valuesArtist != 0)
                    ExhibitButton.IsEnabled = true;
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

                if (!(textNumber.Text.All(Char.IsDigit)))
                    throw new Exception("Формат ввода количества строк неверный.");

                int n = Convert.ToInt32(textNumber.Text);
                // генереация форен ключа на основе случайного селекта id из таблиц художника и коллекций

                List<Exhibit> list = Exhibit.GenerateItems(n);

                int result = ExhibitDb.InsertItems(Connector.sandboxFileSetting, list);

                MessageBox.Show($"Добавлено {result} строк в таблицу exhibit", "Инфо",
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
