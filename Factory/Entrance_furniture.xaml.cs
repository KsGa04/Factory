using System;
using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class Entrance_furniture : Window
    {
        public Пользователь пользователь;
        private praktikaEntities _db = new praktikaEntities();
        public Entrance_furniture(Пользователь пользователь)
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
        /// Поступление фурнитуры
        /// </summary>
        private void entrance_fabric_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var good = goods.SelectedItem.ToString();
                Фурнитура ткани = db.Фурнитура.Where(x => x.Артикул == good).FirstOrDefault();
                ткани.Ширина = Convert.ToDouble(width.Text);
                ткани.Цена = Convert.ToDecimal(price.Text);
                ткани.Длина = Convert.ToDouble(length.Text);
                ткани.Количество = Convert.ToInt32(count.Text);
                db.SaveChanges();
                MessageBox.Show("Данные успешно обновлены");
            }

        }
    }
}
