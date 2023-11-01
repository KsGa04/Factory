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
    /// Логика взаимодействия для DirectorateMain.xaml
    /// </summary>
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
