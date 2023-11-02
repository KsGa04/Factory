using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace Factory
{
    public partial class Report_fabric : Window
    {
        public Пользователь пользователь;
        public Report_fabric(Пользователь пользователь)
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
                var categories = db.Ткани.ToList();

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
        /// Создание отчета (excel файла) с содержанием данных таблицы Ткани
        /// </summary>
        private void report_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Ткани>> ByData = new Dictionary<string, List<Ткани>>();
            using (praktikaEntities usersEntities = new praktikaEntities())
            {
                var allWorkers = usersEntities.Ткани.ToList().GroupBy(w => w.Наименование);
                foreach (var group in allWorkers)
                {
                    ByData[group.Key] = group.ToList();
                }
            }
            var app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            app.Visible = true;

            foreach (var worker in ByData)
            {
                string type = worker.Key;
                List<Ткани> workers = worker.Value;
                Excel.Worksheet worksheet = app.Worksheets.Add();

                if (type != "")
                {
                    worksheet.Name = type;

                    worksheet.Cells[1, 1] = "Артикул";
                    worksheet.Cells[1, 2] = "Наименование";
                    worksheet.Cells[1, 3] = "Длина";
                    worksheet.Cells[1, 4] = "Ширина";
                    worksheet.Cells[1, 5] = "Цена";
                    worksheet.Cells[1, 6] = "Количество";
                }
                int rowIndex = 2;

                foreach (Ткани work in workers)
                {
                    worksheet.Cells[rowIndex, 1] = work.Артикул;
                    worksheet.Cells[rowIndex, 2] = work.Наименование;
                    worksheet.Cells[rowIndex, 3] = work.Длина;
                    worksheet.Cells[rowIndex, 4] = work.Ширина;
                    worksheet.Cells[rowIndex, 5] = work.Цена;
                    worksheet.Cells[rowIndex, 6] = work.Количество;
                    rowIndex++;
                }
            }
        }
    }
}
