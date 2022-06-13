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
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        vitEntities1 context;
        public CarsPage()
        {
            InitializeComponent();
            context = new vitEntities1();

            var list = context.DriversCars.Where(x => x.dateEndhaving == null).ToList();
            CarsTable.ItemsSource = list;

            markCombo.ItemsSource = context.Car.ToList();
        }


        public void RefreshData()
        {
            var list = context.Car.ToList();
            if (markCombo.SelectedIndex > 0)
            {
                //
                Car c = markCombo.SelectedItem as Car;
                list = list.Where(x => x == c).ToList();
            }

            if (!string.IsNullOrWhiteSpace(inputNomer.Text))
            {
                list = list.Where(x => x.StateNumber.ToLower().Contains(inputNomer.Text.ToLower())).ToList();
            }

            CarsTable.ItemsSource = list;

        }



        private void SearchNum(object sender, TextChangedEventArgs e)
        {
            RefreshData();
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

        private void EditCars(object sender, RoutedEventArgs e)
        {
            
            Car car = CarsTable.SelectedItem as Car;
            NavigationService.Navigate(new AddCars(context, car));
        }

        private void DeleteCars(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes)
            {
                try
                {
                    Car car = CarsTable.SelectedItem as Car;
                    context.Car.Remove(car);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка при удалении");
                }
            }
        }

        private void GoAddCars(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCars(context));
        }

        private void ChangedMark(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
