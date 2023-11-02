using System.Linq;
using System.Windows;

namespace Factory
{
    public partial class List_goods : Window
    {
        public Пользователь пользователь;
        public List_goods(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
            ListViewLoad();
        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        /// <summary>
        /// Заполение ListView данными из таблицы Изделия
        /// </summary>
        public void ListViewLoad()
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var categories = db.Изделия.ToList();

                Fabric.ItemsSource = categories;
            }
        }
        /// <summary>
        /// Нахождение изделий по наименованию
        /// </summary>
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            string searchText = Find.Text;
            using (praktikaEntities db = new praktikaEntities())
            {
                var query = from data in db.Изделия
                            where data.Наименование.Contains(searchText)
                            select data;
                Fabric.ItemsSource = query.ToList();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DirectorateMain storekeeperMain = new DirectorateMain(пользователь);
            storekeeperMain.Show();
            this.Hide();
        }
    }
}
