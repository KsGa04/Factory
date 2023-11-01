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
using System.Windows.Shapes;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для List_otder.xaml
    /// </summary>
    public partial class List_otder : Window
    {
        public Пользователь пользователь;
        public List_otder(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
            ListViewLoad();
        }
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
