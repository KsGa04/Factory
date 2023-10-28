﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public static void Reg(string login, string password)
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                Пользователь user = new Пользователь(login, password, 1);
                db.Пользователь.Add(user);
                db.SaveChanges();
                MainWindow glavnay = new MainWindow();
                glavnay.Show();
            }
        }
        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            if (password.Password.Length < 8)
            {
                MessageBox.Show("Неправильная длина пароля");
            }
            else
            {
                using (praktikaEntities db = new praktikaEntities())
                {
                    Reg(login.Text, password.Password);
                    MessageBox.Show("Аккаунт " + login.Text + " зарегистрирован");
                    login.Clear();
                    password.Clear();
                    this.Hide();

                }
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
