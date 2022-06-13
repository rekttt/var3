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
    /// Логика взаимодействия для AddCars.xaml
    /// </summary>
    public partial class AddCars : Page
    {
        vitEntities1 context;
        public AddCars(vitEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;

        private void AddNewCar(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                Car car = new Car()
                {
                    StateNumber = numBox.Text,
                    mark = Convert.ToInt32(markBoxq.Text),
                    model = modelBox.Text,
                    color = colorBox.Text,
                    madeYear = Convert.ToInt32(yearBox.Text),
                    dateOfRegistration = Convert.ToDateTime(dateBox.Text)


                };
                context.Car.Add(car);
                context.SaveChanges();

                NavigationService.Navigate(new CarsPage());
            }
            else
            {
                context.Car.Find(c.StateNumber).mark = Convert.ToInt32(markBoxq.Text);
                context.Car.Find(c.StateNumber).model = modelBox.Text;
                context.Car.Find(c.StateNumber).color = colorBox.Text;
                context.Car.Find(c.StateNumber).madeYear = Convert.ToInt32(yearBox.Text);
                context.Car.Find(c.StateNumber).dateOfRegistration = Convert.ToDateTime(dateBox.Text);

                context.SaveChanges();
                NavigationService.Navigate(new CarsPage());
            }
        }
        Car c;
        public AddCars(vitEntities1 cont, Car car)
        {
            InitializeComponent();
            context = cont;
            c = car;

            numBox.Text = car.StateNumber;
            markBoxq.Text = car.mark.ToString();
            modelBox.Text = car.model;
            colorBox.Text = car.color;
            yearBox.Text = car.madeYear.ToString();
            dateBox.Text = car.dateOfRegistration.ToString();
            flag = false;

        }
    }
}
