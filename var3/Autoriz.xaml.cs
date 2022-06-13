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
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        vitEntities1 vit;
        public Autoriz()
        {
            InitializeComponent();

            vit = new vitEntities1();
             
        }
        int count = 0;
        private void GoMain(object sender, RoutedEventArgs e)
        {
            int login = Convert.ToInt32(inputLogin.Text);
            string password = inputPassword.Text;
            if (vit.Inspector.Any(x => x.tabNum == login))
            {
                Inspector inspector = vit.Inspector.ToList().Find(x => x.tabNum == login);
                if (inspector.password.Equals(inputPassword.Text))
                {
                    MessageBox.Show("Добро пожаловать");
                    NavigationService.Navigate(new MainPAg());
                }
                else
                {
                    MessageBox.Show("Неверные входные данные");
                    count++;
                }
            }
            else
            {
                MessageBox.Show("Неверные входные данные");
                count++;
            }
            if (count >= 3)
            {
                check.Visibility = Visibility.Visible;
            }
        }

        private void GoPodskazka(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PodskazkaPage());
        }
    }
}
