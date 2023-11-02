using System.Windows;

namespace Factory
{
    public partial class CustomerMain : Window
    {
        public Пользователь Пользователь;
        public CustomerMain(Пользователь user)
        {
            InitializeComponent();
            Пользователь = user;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void create_order_Click(object sender, RoutedEventArgs e)
        {
            Create_order create_Order = new Create_order(Пользователь);
            create_Order.Show();
            this.Hide();
        }

        private void order_list_Click(object sender, RoutedEventArgs e)
        {
            List_otder list_Otder = new List_otder(Пользователь);
            list_Otder.Show();
            this.Hide();
        }
    }
}
