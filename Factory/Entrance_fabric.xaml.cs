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
    /// Логика взаимодействия для Entrance_fabric.xaml
    /// </summary>
    public partial class Entrance_fabric : Window
    {
        public Пользователь пользователь;
        public Entrance_fabric(Пользователь пользователь)
        {
            InitializeComponent();
            this.пользователь = пользователь;
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
    }
}
