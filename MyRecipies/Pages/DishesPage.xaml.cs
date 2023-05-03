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
    /// Interaction logic for DishesPage.xaml
    /// </summary>
    public partial class DishesPage : Page
    {
        private List<Dish> _dishes = new List<Dish>();
        public DishesPage()
        {
            InitializeComponent();
            var list = MainWindow.db.Category.ToList();
            list.Insert(0, new Category { Id = 0, Name = "Все" });
            CategoryCb.ItemsSource = list;
            CategoryCb.DisplayMemberPath = "Name";
            CategoryCb.SelectedIndex = 0;

            NotAvailableOnlyCheck.IsChecked = false;

            UpdateList();
        }

        private void UpdateList()
        {
            _dishes = MainWindow.db.Dish.ToList();

            var selectedCategory = CategoryCb.SelectedItem as Category;
            if(selectedCategory.Id != 0)
                _dishes = _dishes.Where(d => d.CategoryId == selectedCategory.Id).ToList();

            if(SearchTb.Text != string.Empty)
                _dishes = _dishes.Where(d => d.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            //if(NotAvailableOnlyCheck.IsChecked == true)

            DishesLv.ItemsSource = _dishes;
            DishesLv.Items.Refresh();
        }

        private void CategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
