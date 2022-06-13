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
    /// Логика взаимодействия для MainPAg.xaml
    /// </summary>
    public partial class MainPAg : Page
    {
        vitEntities1 context;
        public MainPAg()
        {
            InitializeComponent();
            context = new vitEntities1();
            ViolationTable.ItemsSource = context.Violation.ToList();
        }

        ///private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //
       // }

        public void RefreshData()
        {
            var list = context.Violation.ToList();
            if (!string.IsNullOrWhiteSpace(inputNameSearch.Text))
            {
                list = list.Where(x => x.title.ToLower().Contains(inputNameSearch.Text.ToLower())).ToList();
            }
            ViolationTable.ItemsSource = list;
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

        private void SearchFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void GoAddViolation(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVolation(context));
        }

        private void EditViol(object sender, RoutedEventArgs e)
        {
            Violation violation = ViolationTable.SelectedItem as Violation;
            NavigationService.Navigate(new AddVolation(context, violation));
        }

        private void DeleteViol(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes)
            {
                try
                {
                    Violation violation = ViolationTable.SelectedItem as Violation;
                    context.Violation.Remove(violation);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка при удалении");
                }
            }

        }
    }
}
