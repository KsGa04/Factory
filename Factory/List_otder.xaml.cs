using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class List_otder : Window
    {
        public Пользователь пользователь;
        public List_otder(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
            ListViewLoad();
        }
        /// <summary>
        /// Заполение ListView данными из таблицы Заказы
        /// </summary>
        public void ListViewLoad()
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var orders = db.Заказ.ToList();
                Fabric.ItemsSource = orders;
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CustomerMain storekeeperMain = new CustomerMain(пользователь);
            storekeeperMain.Show();
            this.Hide();
        }
    }
}
