using MainSaloon.Model;
using MainSaloon.ViewModel;
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

namespace MainSaloon.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        public dynamic imgSourse;
        public Service MainService { get; set; }
        public ServicesViewModel SVM;
        public EditServiceWindow(object SelectedItem)
        {
            MainService = (Service)SelectedItem;
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            SVM = new ServicesViewModel();
            int a = MainService.DurationInSeconds;
            double? b = Math.Round(Convert.ToDouble(MainService.Discount), 2) * 100;
            Title.Text = MainService.Title;
            Cost.Text = Math.Round(MainService.Cost).ToString();
            Discount.Text = b.ToString();
            Description.Text = MainService.Description;
            Duration.Text = a.ToString();
        }

        private void EditImage(object sender, RoutedEventArgs e)
        {
            //imgSourse = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                imgSourse = dlg.FileName;
            }

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Cost.Text, out int res) && int.TryParse(Duration.Text, out int ab) && int.TryParse(Discount.Text, out int bab))
            {
                if (!string.IsNullOrEmpty(Title.Text) && int.Parse(Cost.Text) != 0 &&
                int.Parse(Duration.Text) != 0 &&
                int.Parse(Discount.Text) != 0)
                {

                    if (int.Parse(Discount.Text) < 100 && int.Parse(Cost.Text) < 99999 && int.Parse(Duration.Text) < 300)
                    {
                        if (imgSourse == null)
                        {
                            MainService.MainImagePath = MainService.MainImagePath;
                        }
                        else { MainService.MainImagePath = imgSourse; }
                        MainService.Description = Description.Text;
                        MainService.DurationInSeconds = int.Parse(Duration.Text);
                        MainService.Cost = int.Parse(Cost.Text);
                        MainService.Discount = Convert.ToDouble(Discount.Text) / 100;
                        MainService.Title = Title.Text;
                        SVM.Edit(MainService);
                        this.Close();
                    }
                    else MessageBox.Show("Введенные данные некорректны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введенные данные некорректны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
