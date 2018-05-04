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

namespace ExchangeRates
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void navButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name)
            {
                case "navButton_main":
                    Main_Grid.Visibility = Visibility.Visible;
                    Currency_Grid.Visibility = Visibility.Hidden;
                    Converter_Grid.Visibility = Visibility.Hidden;
                    Author_Grid.Visibility = Visibility.Hidden;
                    titleLabel.Content = "Główne kursy walut";
                    break;

                case "navButton_currency":
                    Main_Grid.Visibility = Visibility.Hidden;
                    Currency_Grid.Visibility = Visibility.Visible;
                    Converter_Grid.Visibility = Visibility.Hidden;
                    Author_Grid.Visibility = Visibility.Hidden;
                    titleLabel.Content = "Waluta";
                    break;

                case "navButton_converter":
                    Main_Grid.Visibility = Visibility.Hidden;
                    Currency_Grid.Visibility = Visibility.Hidden;
                    Converter_Grid.Visibility = Visibility.Visible;
                    Author_Grid.Visibility = Visibility.Hidden;
                    titleLabel.Content = "Przelicznik";
                    break;

                case "navButton_author":
                    Main_Grid.Visibility = Visibility.Hidden;
                    Currency_Grid.Visibility = Visibility.Hidden;
                    Converter_Grid.Visibility = Visibility.Hidden;
                    Author_Grid.Visibility = Visibility.Visible;
                    titleLabel.Content = "Autor";
                    break;


                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
