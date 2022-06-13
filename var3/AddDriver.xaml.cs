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
    /// Логика взаимодействия для AddDriver.xaml
    /// </summary>
    public partial class AddDriver : Page
    {
        vitEntities1 context;
        public AddDriver(vitEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;

        private void AddNewDrivers(object sender, RoutedEventArgs e)
        {
            Driver driver = new Driver()
            {
                numDriverDocument = numBox.Text,
                name = fioBox.Text,
                adres = adresBox.Text,
                phone = phoneBox.Text
            };
            context.Driver.Add(driver);
            context.SaveChanges();

            NavigationService.Navigate(new DriversPage());
        }
        Driver dr;
        public AddDriver(vitEntities1 cont,Driver driver)
        {
            InitializeComponent();
            context = cont;
            dr = driver;

            numBox.Text = dr.numDriverDocument;
            fioBox.Text = dr.name;
            adresBox.Text = dr.adres;
            phoneBox.Text = dr.phone;

            flag = false;
        }
    }
}
