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
    /// Логика взаимодействия для List_furniture.xaml
    /// </summary>
    public partial class List_furniture : Window
    {
        public Пользователь пользователь;
        public List_furniture(Пользователь пользователь)
        {
            InitializeComponent();
            ListViewLoad();
            this.пользователь = пользователь;
        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        public void ListViewLoad()
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var categories = db.Фурнитура.ToList();

                Fabric.ItemsSource = categories;
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            string searchText = Find.Text;
            using (praktikaEntities db = new praktikaEntities())
            {
                var query = from data in db.Фурнитура
                            where data.Наименование.Contains(searchText)
                            select data;
                Fabric.ItemsSource = query.ToList();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StorekeeperMain storekeeperMain = new StorekeeperMain(пользователь);
            storekeeperMain.Show();
            this.Hide();
        }
    }
}
