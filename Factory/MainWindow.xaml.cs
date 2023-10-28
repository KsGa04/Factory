using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Пользователь user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                user = db.Пользователь.Where(x => x.login == login.Text && x.password == password.Password).First();
                if (user == null)
                {
                    MessageBox.Show("Данных аккаунт отсутствует либо допущены ошибки в логине и пароле");
                }
                else
                {
                    if (user.id_role == 1) { CustomerMain customer = new CustomerMain(user); customer.Show(); this.Hide(); }
                    else if (user.id_role == 2) { ManagerMain manager = new ManagerMain(user); manager.Show(); this.Hide(); }
                    else if (user.id_role == 3) { StorekeeperMain storekeeper = new StorekeeperMain(user); storekeeper.Show(); this.Hide(); }
                    else if (user.id_role == 4) { DirectorateMain directorate = new DirectorateMain(user); directorate.Show(); this.Hide(); }
                }
            }
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
