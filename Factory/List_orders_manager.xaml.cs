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
    /// Логика взаимодействия для List_orders_manager.xaml
    /// </summary>
    public partial class List_orders_manager : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Пользователь пользователь;
        public List_orders_manager(Пользователь пользователь)
        {
            InitializeComponent();
            foreach (var d in _db.Заказ)
            {
                orders.Items.Add(d.Номер);
            }
            ListViewLoad();
        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
        /// <summary>
        /// Заполение ListView данными из таблицы Заказы
        /// </summary>
        public void ListViewLoad()
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var orders = db.Заказ.ToList();
                var orders_goods = db.Заказанные_изделия.ToList();

                Fabric.ItemsSource = orders;
                Fabric.ItemsSource = orders_goods;
            }
        }
        /// <summary>
        /// Изменение статуса заказа
        /// </summary>
        private void Save_changes_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var id = Convert.ToInt32(orders.SelectedItem);
                Заказ заказ = db.Заказ.Where(x => x.Номер == id).FirstOrDefault();
                var status_order = status.SelectedItem.ToString();
                заказ.Этап_выполнения = status_order;
                db.SaveChanges();
                MessageBox.Show("Статус заказа изменен");
                ListViewLoad();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerMain customerMain = new ManagerMain(пользователь);
            customerMain.Show();
            this.Hide();
        }
    }
}
