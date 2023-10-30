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
    /// Логика взаимодействия для Create_order.xaml
    /// </summary>
    public partial class Create_order : Window
    {
        private praktikaEntities _db = new praktikaEntities();
        public Пользователь пользователь;
        public Create_order(Пользователь пользователь)
        {
            InitializeComponent();
            price.IsReadOnly = true;
            total_sum.IsReadOnly = true;
            this.пользователь = пользователь;

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
            using (praktikaEntities db = new praktikaEntities())
            {
                string selectedItem = goods.SelectedItem.ToString();
                string[] good = selectedItem.Split(new char[] { '-' });
                string Name = good[1];
                Изделия изделия = db.Изделия.Where(x => x.Артикул == Name).FirstOrDefault();
                price.Text = изделия.Цена.ToString();
                int count_good = Convert.ToInt32(count.Text);
                int sum = Convert.ToInt32(total_sum.Text);
                Заказ заказ = new Заказ(System.DateTime.Now, "Новый");
                db.Заказ.Add(заказ);
                Заказанные_изделия заказанные_Изделия = new Заказанные_изделия(заказ.Номер,изделия.Артикул, count_good);
                db.Заказанные_изделия.Add(заказанные_Изделия);
                db.SaveChanges();
            }
        }

        private void goods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                string selectedItem = goods.SelectedItem.ToString();
                string[] good = selectedItem.Split(new char[] { '-' });
                string Name = good[1];
                Изделия изделия = db.Изделия.Where(x => x.Артикул == Name).FirstOrDefault();
                price.Text = изделия.Цена.ToString();
                total_sum.Text = "0";
            }
        }

        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                string selectedItem = goods.SelectedItem.ToString();
                string[] good = selectedItem.Split(new char[] { '-' });
                string Name = good[1];
                Изделия изделия = db.Изделия.Where(x => x.Артикул == Name).FirstOrDefault();
                price.Text = изделия.Цена.ToString();
                if (count.Text == null)
                {
                    count.Text = "0";
                    total_sum.Text = "0";
                }
                else
                {
                    int count_good = Convert.ToInt32(count.Text);
                    total_sum.Text = (изделия.Цена * count_good).ToString();
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CustomerMain customerMain = new CustomerMain(пользователь);
            customerMain.Show();
            this.Hide();
        }
    }
}
