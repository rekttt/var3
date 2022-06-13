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

namespace var3
{
    /// <summary>
    /// Логика взаимодействия для DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        vitEntities1 context;
        public DriversPage()
        {
            InitializeComponent();
            context = new vitEntities1();
            DriversTable.ItemsSource = context.Driver.ToList();
        }

        public void RefreshData()
        {
            var list = context.Driver.ToList();
            if (!string.IsNullOrWhiteSpace(inputNameSearch.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(inputNameSearch.Text.ToLower())).ToList();

            }
            DriversTable.ItemsSource = list;
           
        }

        private void GoViolation(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPAg());
        }

        private void GoDrivers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DriversPage());

        }

        private void GoCars(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarsPage());

        }

        private void EditDriver(object sender, RoutedEventArgs e)
        {
            Driver driver = DriversTable.SelectedItem as Driver;
            NavigationService.Navigate(new AddDriver(context, driver));
        }

        private void DeleteDriver(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить", "Подтверждение", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes)
            {
                try
                {
                    Driver driver = DriversTable.SelectedItem as Driver;
                    context.Driver.Remove(driver);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка при удалении");
                }
            }
        }

        private void GoAddDriver(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDriver(context));
        }

        private void SearchFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
