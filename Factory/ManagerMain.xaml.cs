using System.Windows;

namespace Factory
{
    public partial class ManagerMain : Window
    {
        public Пользователь user;
        public ManagerMain(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void order_list_Click(object sender, RoutedEventArgs e)
        {
            List_orders_manager list_Orders_Manager = new List_orders_manager(user);
            list_Orders_Manager.Show();
            this.Hide();
        }
    }
}
