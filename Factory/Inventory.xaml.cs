using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;

namespace Factory
{
    public partial class Inventory : Window
    {
        public Пользователь пользователь;
        public Inventory(Пользователь пользователь)
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
        private void write_save_Click(object sender, RoutedEventArgs e)
        {
            if (Count.Text == "")
            {
                MessageBox.Show("Введите количество материала");
            }
            else if (ListOfMaterials.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите материал");
            }
            else
            {
                using (praktikaEntities db = new praktikaEntities())
                {
                    if (TypeSelect.SelectedIndex == 0)
                    {
                        var material = db.Ткани.Where(x => x.Артикул.Equals(((Ткани)ListOfMaterials.SelectedItem).Артикул)).First();
                        var percent = Math.Abs((float)(material.Количество - Convert.ToInt32(Count.Text)) / Convert.ToInt32(Count.Text));
                        if (percent <= 0.20)
                        {
                            material.Количество = Convert.ToInt32(Count.Text);
                            db.SaveChanges();
                        }
                        else
                        {
                            var app = new Word.Application();
                            Word.Document document = app.Documents.Add();

                            Word.Paragraph paragraph = document.Paragraphs.Add();
                            Word.Range range = paragraph.Range;
                            range.Font.Size = 16;
                            range.Font.Bold = 1;
                            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            range.Text = "Документ о неверной инвентаризации";
                            range.InsertParagraphAfter();

                            Word.Paragraph materialInfoParagraph = document.Paragraphs.Add();
                            Word.Range materialInfoRange = materialInfoParagraph.Range;
                            materialInfoRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                            materialInfoRange.Font.Size = 14;
                            materialInfoRange.Text = $"Артикул: {material.Артикул}\nНаименование: {material.Наименование}\n" +
                                $"Реальные данные: {Count.Text}\nУчетные данные: {material.Количество}";
                            app.Visible = true;
                            document.SaveAs2(@"C:\Users\Almaz\OneDrive\Документы");
                        }
                    }
                    else if (TypeSelect.SelectedIndex == 1)
                    {
                        var material = db.Фурнитура.Where(x => x.Артикул.Equals(((Фурнитура)ListOfMaterials.SelectedItem).Артикул)).First();
                        if (Math.Abs((sbyte)((material.Количество - Convert.ToInt32(Count.Text)) / Convert.ToInt32(Count.Text))) <= 0.20)
                        {
                            material.Количество = Convert.ToInt32(Count.Text);
                            db.SaveChanges();
                        }
                        else
                        {
                            var app = new Word.Application();
                            Word.Document document = app.Documents.Add();

                            Word.Paragraph paragraph = document.Paragraphs.Add();
                            Word.Range range = paragraph.Range;
                            range.Font.Size = 16;
                            range.Font.Bold = 1;
                            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            range.Text = "Документ о неверной инвентаризации";
                            range.InsertParagraphAfter();

                            Word.Paragraph materialInfoParagraph = document.Paragraphs.Add();
                            Word.Range materialInfoRange = materialInfoParagraph.Range;
                            materialInfoRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                            materialInfoRange.Font.Size = 14;
                            materialInfoRange.Text = $"Артикул: {material.Артикул}\nНаименование: {material.Наименование}\n" +
                                $"Реальные данные: {Count.Text}\nУчетные данные: {material.Количество}";
                            app.Visible = true;
                            document.SaveAs2(@"C:\Users\Almaz\OneDrive\Документы");
                        }
                    }
                }
            }
        }
        private void TypeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeSelect.SelectedIndex == 0)
            {
                if (MaterialName != null)
                    MaterialName.Text = "";

                List<Ткани> clothes = new List<Ткани>();
                using (praktikaEntities db = new praktikaEntities())
                {
                    clothes = db.Ткани.ToList();
                }

                ListOfMaterials.ItemsSource = clothes;
            }
            else if (TypeSelect.SelectedIndex == 1)
            {
                if (MaterialName != null)
                    MaterialName.Text = "";

                List<Фурнитура> furniture = new List<Фурнитура>();
                using (praktikaEntities db = new praktikaEntities())
                {
                    furniture = db.Фурнитура.ToList();
                }

                ListOfMaterials.ItemsSource = furniture;
            }
        }

        private void MaterialName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TypeSelect.SelectedIndex == 0)
            {
                List<Ткани> clothes = new List<Ткани>();
                using (praktikaEntities db = new praktikaEntities())
                {
                    clothes = db.Ткани.Where(x => x.Наименование.Contains(MaterialName.Text) || x.Артикул.Contains(MaterialName.Text)).ToList();
                }

                ListOfMaterials.ItemsSource = clothes;
            }
            else if (TypeSelect.SelectedIndex == 1)
            {
                List<Фурнитура> furniture = new List<Фурнитура>();
                using (praktikaEntities db = new praktikaEntities())
                {
                    furniture = db.Фурнитура.Where(x => x.Наименование.Contains(MaterialName.Text) || x.Артикул.Contains(MaterialName.Text)).ToList();
                }

                ListOfMaterials.ItemsSource = furniture;
            }
        }
        private void Count_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                e.Handled = true;
            }
        }
    }
}
