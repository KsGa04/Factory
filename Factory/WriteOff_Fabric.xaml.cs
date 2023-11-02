using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class WriteOff_Fabric : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Пользователь пользователь;
        public WriteOff_Fabric(Пользователь пользователь)
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
        /// Списание тканей
        /// </summary>
        private void writeOff_fabric_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var good = goods.SelectedItem.ToString();
                Ткани ткани = db.Ткани.Where(x => x.Артикул == good).FirstOrDefault();
                ткани.Ширина = 0;
                ткани.Цена = 0;
                ткани.Количество = 0;
                db.SaveChanges();
                MessageBox.Show("Данные успешно списаны");
            }
        }
    }
}
