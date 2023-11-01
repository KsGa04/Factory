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
    /// Логика взаимодействия для StorekeeperMain.xaml
    /// </summary>
    public partial class StorekeeperMain : Window
    {
        public Пользователь user;
        public StorekeeperMain(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        private void Fabric_list_Click(object sender, RoutedEventArgs e)
        {
            List_fabric list_Fabric = new List_fabric(user);
            list_Fabric.Show();
            this.Hide();
        }
        private void Furniture_list_Click(object sender, RoutedEventArgs e)
        {
            List_furniture list_Fabric = new List_furniture(user);
            list_Fabric.Show();
            this.Hide();
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            Entrance_fabric entrance_Fabric = new Entrance_fabric(user);
            entrance_Fabric.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entrance_furniture entrance_Furniture = new Entrance_furniture(user);
            entrance_Furniture.Show();
            this.Hide();
        }
    }
}
