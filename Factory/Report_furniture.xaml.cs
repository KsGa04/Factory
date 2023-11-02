using System;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Factory
{
    /// <summary>
    /// Логика взаимодействия для Report_furniture.xaml
    /// </summary>
    public partial class Report_furniture : Window
    {
        public Пользователь пользователь;
        public object allWorkers;
        public Report_furniture(Пользователь пользователь)
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
        /// <summary>
        /// Заполение ListView данными из таблицы Ткани
        /// </summary>
        public void ListViewLoad()
        {
            using (praktikaEntities db = new praktikaEntities())
            {
                var categories = db.Фурнитура.ToList();

                Fabric.ItemsSource = categories;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DirectorateMain storekeeperMain = new DirectorateMain(пользователь);
            storekeeperMain.Show();
            this.Hide();
        }
        /// <summary>
        /// Создание отчета (excel файла) с содержанием данных таблицы Фурнитура
        /// </summary>
        private void report_Click(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, List<Фурнитура>> ByData = new Dictionary<string, List<Фурнитура>>();
            //using (praktikaEntities usersEntities = new praktikaEntities())
            //{
            //    allWorkers = usersEntities.Фурнитура.ToList();
            //}
            //var app = new Excel.Application();
            //Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //app.Visible = true;
            //    Excel.Worksheet worksheet = app.Worksheets.Add();

            //        worksheet.Name = "List1";

            //        worksheet.Cells[1, 1] = "Артикул";
            //        worksheet.Cells[1, 2] = "Наименование";
            //        worksheet.Cells[1, 3] = "Длина";
            //        worksheet.Cells[1, 4] = "Ширина";
            //        worksheet.Cells[1, 5] = "Цена";
            //        worksheet.Cells[1, 6] = "Количество";
            //        worksheet.Cells[1, 7] = "Вес";
            //    int rowIndex = 2;

            //    foreach (Фурнитура work in allWorkers.)
            //    {
            //        worksheet.Cells[rowIndex, 1] = work.Артикул;
            //        worksheet.Cells[rowIndex, 2] = work.Наименование;
            //        worksheet.Cells[rowIndex, 3] = work.Длина;
            //        worksheet.Cells[rowIndex, 4] = work.Ширина;
            //        worksheet.Cells[rowIndex, 5] = work.Цена;
            //        worksheet.Cells[rowIndex, 6] = work.Количество;
            //        worksheet.Cells[rowIndex, 7] = work.Вес;
            //        rowIndex++;
            //    }
        }
    }
}
