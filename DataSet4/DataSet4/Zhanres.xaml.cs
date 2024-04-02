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
using DataSet4.DataSet1TableAdapters;

namespace DataSet4
{
    /// <summary>
    /// Логика взаимодействия для Zhanres.xaml
    /// </summary>
    public partial class Zhanres : Page
    {
        ZhanresTableAdapter zhanres = new ZhanresTableAdapter();
        public Zhanres()
        {
            InitializeComponent();

            dg.ItemsSource = zhanres.GetData();
            cbx.ItemsSource = zhanres.GetData();
            cbx.DisplayMemberPath = "NameZhanre";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = zhanres.SearchByName(SearchTxt.Text);
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var id = (int)(cbx.SelectedItem as DataRowView).Row[0];
                dg.ItemsSource = zhanres.FilterByZhanre(id);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = zhanres.GetData();
        }
    }
}
