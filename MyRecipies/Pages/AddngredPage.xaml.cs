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
    /// Interaction logic for AddngredPage.xaml
    /// </summary>
    public partial class AddngredPage : Page
    {
        public AddngredPage()
        {
            InitializeComponent();

            UnitCb.ItemsSource = MainWindow.db.Unit.ToList();
            UnitCb.DisplayMemberPath = "Name";
            UnitCb.SelectedItem = MainWindow.db.Unit.FirstOrDefault();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ComponentsPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UnitCb.SelectedItem == null || NameTb.Text == string.Empty 
                || PriceTb.Text == string.Empty || CountTb.Text == string.Empty
                || InFridgeTb.Text == string.Empty) 
            {
                MessageBox.Show("Введите данные");
                return;
            }

            double price = 0;
            try
            {
                price = Convert.ToDouble(PriceTb.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода цены");
                return;
            }

            double count = 0;
            try
            {
                count = Convert.ToInt32(CountTb.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода количества");
                return;
            }

            int inFridge = 0;
            try
            {
                inFridge = Convert.ToInt32(InFridgeTb.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода количества в холодильнике");
                return;
            }

            var selectedUnit = UnitCb.SelectedItem as Unit;
            if(selectedUnit == null) 
            {
                MessageBox.Show("Выберите единицу измерения");
                return;
            }

            var ingred = new Ingredient();
            ingred.Name = NameTb.Text;
            ingred.Cost = Convert.ToDecimal(price);
            ingred.CostForCount = count;
            ingred.AvailableCount = inFridge;
            ingred.UnitId = selectedUnit.Id;
            
            try
            {
                MainWindow.db.Ingredient.Add(ingred);
                MainWindow.db.SaveChanges();

                NavigationService.Navigate(new ComponentsPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось сохранить данные");
            }
        }
    }
}
