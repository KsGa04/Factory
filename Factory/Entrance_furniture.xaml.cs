﻿using System;
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
    /// Логика взаимодействия для Entrance_furniture.xaml
    /// </summary>
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

        private void goods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void entrance_fabric_Click(object sender, RoutedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var good = goods.SelectedItem.ToString();
                Фурнитура ткани = db.Фурнитура.Where(x => x.Артикул == good).FirstOrDefault();
                ткани.Ширина = Convert.ToDouble(length.Text);
                ткани.Цена = Convert.ToDecimal(price.Text);
                db.SaveChanges();
                MessageBox.Show("Данные успешно обновлены");
            }

        }
    }
}
