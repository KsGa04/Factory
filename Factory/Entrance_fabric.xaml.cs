using System;
using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class Entrance_fabric : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Пользователь пользователь;
        public Entrance_fabric(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
            foreach (var d in _db.Ткани)
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
        /// Поступление тканей
        /// </summary>
        private void entrance_fabric_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db= new praktikaEntities())
            {
                var good = goods.SelectedItem.ToString();
                Ткани ткани = db.Ткани.Where(x => x.Артикул == good).FirstOrDefault();
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
