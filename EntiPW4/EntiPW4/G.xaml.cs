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
    /// Логика взаимодействия для G.xaml
    /// </summary>
    public partial class G : Page
    {
        private PractikaPW1Entities g = new PractikaPW1Entities();
        public G()
        {
            InitializeComponent();

            dg.ItemsSource = g.Games.ToList();
            cbx.ItemsSource = g.Games.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = g.Games.ToList().Where(item => item.NameGame.Contains(SearchTxt.Text));
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = g.Games.ToList();
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cbx.SelectedItem as Games;
            if (selected != null)
            {
                dg.ItemsSource = g.Games.ToList().Where(item => item.NameGame == selected.NameGame);
            }
        }
    }
}
