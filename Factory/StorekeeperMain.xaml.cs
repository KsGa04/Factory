using System.Windows;

namespace Factory
{
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

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            Inventory inventory = new Inventory(user);
            inventory.Show();
            this.Hide();
        }

        private void WriteOff_furniture_Click(object sender, RoutedEventArgs e)
        {
            WriteOff_furniture writeOff_Furniture = new WriteOff_furniture(user);
            writeOff_Furniture.Show();
            this.Hide();

        }

        private void WriteOff_fabric_Click(object sender, RoutedEventArgs e)
        {
          
            WriteOff_Fabric writeOff_Fabric = new WriteOff_Fabric(user);
            writeOff_Fabric.Show();
            this.Hide();
        }
    }
}
