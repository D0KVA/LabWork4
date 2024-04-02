using DataSet4.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DataSet4
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        GamesTableAdapter games = new GamesTableAdapter();
        public Games()
        {
            InitializeComponent();

            dg.ItemsSource = games.GetData();
            cbx.ItemsSource = games.GetData();
            cbx.DisplayMemberPath = "NameGame";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = games.SearchGame(SearchTxt.Text);
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (int)(cbx.SelectedItem as DataRowView).Row[0];
            dg.ItemsSource = games.FilterByGame(id);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = games.GetData();
        }
    }
}
