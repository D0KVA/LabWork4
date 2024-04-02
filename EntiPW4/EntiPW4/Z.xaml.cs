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

namespace EntiPW4
{
    /// <summary>
    /// Логика взаимодействия для Z.xaml
    /// </summary>
    public partial class Z : Page
    {
        private PractikaPW1Entities z = new PractikaPW1Entities();
        public Z()
        {
            InitializeComponent();

            dg.ItemsSource = z.Zhanres.ToList();
            cbx.ItemsSource = z.Zhanres.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = z.Zhanres.ToList().Where(item => item.NameZhanre.Contains(SearchTxt.Text));
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = z.Zhanres.ToList();
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cbx.SelectedItem as Zhanres;
            if (selected != null)
            {
                dg.ItemsSource = z.Zhanres.ToList().Where(item => item.NameZhanre == selected.NameZhanre);
            }
        }
    }
}
