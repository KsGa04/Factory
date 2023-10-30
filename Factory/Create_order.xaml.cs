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
    /// Логика взаимодействия для Create_order.xaml
    /// </summary>
    public partial class Create_order : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Create_order()
        {
            InitializeComponent();
            foreach (var d in _db.Изделия)
            {
                goods.Items.Add(d.Наименование + "-" + d.Артикул);
            }
        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
        private void Create_Order_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities  db = new praktikaEntities())
            {
                string[] good = goods.SelectedItem.ToString().Split(new char[] { '-' });
                MessageBox.Show(good[0]);
            }
        }
    }
}
