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
    /// Логика взаимодействия для WriteOff_furniture.xaml
    /// </summary>
    public partial class WriteOff_furniture : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Пользователь пользователь;
        public WriteOff_furniture(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
            foreach (var d in _db.Фурнитура)
            {
                goods.Items.Add(d.Артикул);
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
            StorekeeperMain storekeeperMain = new StorekeeperMain(пользователь);
            storekeeperMain.Show();
            this.Hide();
        }
        /// <summary>
        /// Списание фурнитуры
        /// </summary>
        private void writeOff_furniture_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var good = goods.SelectedItem.ToString();
                Фурнитура фурнитура = db.Фурнитура.Where(x => x.Артикул == good).FirstOrDefault();
                фурнитура.Ширина = 0;
                фурнитура.Длина = 0;
                фурнитура.Цена = 0;
                фурнитура.Количество = 0;
                db.SaveChanges();
                MessageBox.Show("Данные успешно списаны");
            }
        }
    }
}
