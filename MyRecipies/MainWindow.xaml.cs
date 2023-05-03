using MyRecipies.DBContext;
using MyRecipies.Pages;
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

namespace MyRecipies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MyRecipesEntities db = new MyRecipesEntities();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ComponentsPage();
        }

        private void FoodsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DishesPage();
        }

        private void ComponentsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ComponentsPage();
        }
    }
}
