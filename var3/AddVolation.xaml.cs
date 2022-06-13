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
    /// Логика взаимодействия для AddVolation.xaml
    /// </summary>
    public partial class AddVolation : Page
    {
        vitEntities1 context;
        public AddVolation(vitEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;
        


        private void AddNewVolation(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Violation violation = new Violation()
                {
                    id = Convert.ToInt32(TabBox.Text),
                    title = nameBox.Text,
                    penaltyRange = penaltyBox.Text,
                    deprivationLicense = deprivationBox.Text
                };
                context.Violation.Add(violation);
                context.SaveChanges();

                NavigationService.Navigate(new MainPAg());
            }
            else
            {
                context.Violation.Find(viol.id).title = nameBox.Text;
                context.Violation.Find(viol.id).penaltyRange = penaltyBox.Text;
                context.Violation.Find(viol.id).deprivationLicense = deprivationBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new MainPAg());
            }
        }
        Violation viol;
        // перегрузка конструктора для редактирования
        public AddVolation(vitEntities1 cont, Violation violation)
        {
            InitializeComponent();
            context = cont;
            viol = violation;
            TabBox.Text = violation.id.ToString();
            nameBox.Text = violation.title;
            penaltyBox.Text = violation.penaltyRange;
            deprivationBox.Text = violation.deprivationLicense;
            flag = false;
        }
    }
}
