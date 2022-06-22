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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public ServicesViewModel SVM;
        public string imgSourse = "";
        public AddServiceWindow()
        {
            SVM = new ServicesViewModel();
            InitializeComponent();
        }
        private void AddElement(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Cost.Text, out int res) && int.TryParse(Duration.Text, out int ab) && int.TryParse(Discount.Text, out int bab))
            {
                if (!string.IsNullOrEmpty(Title.Text) && int.Parse(Cost.Text) != 0 && 
                int.Parse(Duration.Text) != 0 &&
                int.Parse(Discount.Text) != 0)
            {
                
                    if (int.Parse(Discount.Text) < 100 && int.Parse(Cost.Text) < 99999 && int.Parse(Duration.Text) < 300)
                    {
                        //try
                        //{
                            int a = int.Parse(Duration.Text) * 60;
                            float b = float.Parse(Discount.Text) / 100;
                            SVM.Add(Title.Text, int.Parse(Cost.Text), a, Description.Text, b, imgSourse);
                            this.Close();
                        //}
                        //catch { MessageBox.Show("Введенные данные некорректны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
                    } 
                    else MessageBox.Show("Введенные данные некорректны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else MessageBox.Show("Введенные данные некорректны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            imgSourse = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                imgSourse = dlg.FileName;
            }
        }
    }
}
