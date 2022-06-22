using MainSaloon.View.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainSaloon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CodeViewModel code { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoToServices(object sender, RoutedEventArgs e)
        {
            CodeViewModel codeView = new CodeViewModel();

            if (CodePassword.Password == "0000")
            {
                codeView.pass = "0000";
                ServicesPage SP = new ServicesPage(codeView);
                MainFrame.Navigate(SP);
            }
            else
            {
                codeView.pass = CodePassword.Password;
                ServicesPage SP = new ServicesPage(codeView);
                MainFrame.Navigate(SP);
            }
        }

        private void PasswordChanging(object sender, RoutedEventArgs e)
        {
            CodeViewModel codeView = new CodeViewModel();

            if (CodePassword.Password == "0000")
            {
                codeView.pass = "0000";
                ServicesPage SP = new ServicesPage(codeView);
                MainFrame.Navigate(SP);
            }
            else
            {
                codeView.pass = CodePassword.Password;
                ServicesPage SP = new ServicesPage(codeView);
                MainFrame.Navigate(SP);
            }
        }
    }
}
