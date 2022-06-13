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
    /// Логика взаимодействия для PodskazkaPage.xaml
    /// </summary>
    public partial class PodskazkaPage : Page
    {
        vitEntities1 vit;
        public PodskazkaPage()
        {
            InitializeComponent();
            vit = new vitEntities1();
        }

        private void Proverka(object sender, RoutedEventArgs e)
        {
            int login = Convert.ToInt32(inputLogin.Text);
            string fio = inputfio.Text;


            if (vit.Inspector.Any(x => x.tabNum == login))
            {
                Inspector insp = vit.Inspector.ToList().Find(x => x.tabNum == login);
                if (insp.name.Equals(fio))
                {
                    MessageBox.Show($"Ваш пароль {insp.password}");
                }
                else
                {
                    MessageBox.Show("Неправильные данные");
                }
            }

        }


    }
}
