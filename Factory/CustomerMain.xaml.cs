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
    /// Логика взаимодействия для CustomerMain.xaml
    /// </summary>
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
    }
}
