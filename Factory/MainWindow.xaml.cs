using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class MainWindow : Window
    {
        public Пользователь user;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Авторизация пользователя по ролям
        /// </summary>
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                if (db.Пользователь.Where(x => x.login == login.Text && x.password == password.Password).Any())
                {
                    user = db.Пользователь.Where(x => x.login == login.Text && x.password == password.Password).First();
                    if (user.id_role == 1) { CustomerMain customer = new CustomerMain(user); customer.Show(); this.Hide(); }
                    else if (user.id_role == 2) { ManagerMain manager = new ManagerMain(user); manager.Show(); this.Hide(); }
                    else if (user.id_role == 3) { StorekeeperMain storekeeper = new StorekeeperMain(user); storekeeper.Show(); this.Hide(); }
                    else if (user.id_role == 4) { DirectorateMain directorate = new DirectorateMain(user); directorate.Show(); this.Hide(); }
                    
                }
                else
                {
                    MessageBox.Show("Данный аккаунт отсутствует либо допущены ошибки в логине и пароле");
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
