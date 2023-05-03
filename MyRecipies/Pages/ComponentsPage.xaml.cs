using MyRecipies.DBContext;
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

namespace MyRecipies.Pages
{
    /// <summary>
    /// Interaction logic for ComponentsPage.xaml
    /// </summary>
    public partial class ComponentsPage : Page
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private int _pageNumber = 1;
        private int _elemntOnPage = 5;
        public ComponentsPage()
        {
            InitializeComponent();
            _ingredients = MainWindow.db.Ingredient.ToList();
            GoPagination();
        }

        private void GoPagination()
        {
            IngredsLv.ItemsSource = _ingredients.Skip((_pageNumber - 1) * _elemntOnPage).Take(_elemntOnPage);
            CountOfPageTb.Text = _pageNumber.ToString();
            IngredsLv.Items.Refresh();
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            var pagesCount = _ingredients.Count() / _elemntOnPage + (_ingredients.Count() % _elemntOnPage != 0 ? 1 : 0);
            if (_pageNumber == pagesCount)
                return;
            _pageNumber++;
            GoPagination();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber == 1)
                return;
            _pageNumber--;
            GoPagination();
        }

        private void AddIngredBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddngredPage());
        }
    }
}
