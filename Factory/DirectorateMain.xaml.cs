using System.Windows;

namespace Factory
{
    public partial class DirectorateMain : Window
    {
        public Пользователь пользователь;
        public DirectorateMain(Пользователь user)
        {
            InitializeComponent();
            пользователь = user;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void report_fabric_Click(object sender, RoutedEventArgs e)
        {
            Report_fabric report_Fabric = new Report_fabric(пользователь);
            report_Fabric.Show();
            this.Hide();
        }

        private void report_furniture_Click(object sender, RoutedEventArgs e)
        {
            Report_furniture report_Furniture = new Report_furniture(пользователь);
            report_Furniture.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List_goods list_Goods = new List_goods(пользователь);
            list_Goods.Show();
            this.Hide();
        }
    }
}
