using MainSaloon.Model;
using MainSaloon.View.Windows;
using MainSaloon.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MainSaloon.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesViewModel SVM;
        public ObservableCollection<Service> ServicesCollection { get; set; }
        public CodeViewModel codeView { get; set; }
        public ServicesPage(CodeViewModel s)
        {
            if (s == null)
            {
                s = new CodeViewModel();
                s.pass = "1111";
                codeView = s;
                codeView.ServicesCollection = new ObservableCollection<Service>();
            }
            else
            {
                codeView = new CodeViewModel()
                {
                    pass = s.pass,
                    ServicesCollection = new ObservableCollection<Service>(),
                };
            }

            SVM = new ServicesViewModel();
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            SVM.FillCollection(codeView.ServicesCollection);
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (MainListBox.SelectedItem != null)
            {
                SVM.Delete(MainListBox.SelectedItem);
                SVM.FillCollection(codeView.ServicesCollection);
            }
            else MessageBox.Show("Выберите элемент!");
        }

        private void AddNewElement(object sender, RoutedEventArgs e)
        {
            AddServiceWindow ASW = new AddServiceWindow();
            ASW.ShowDialog();
            SVM.FillCollection(codeView.ServicesCollection);
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (MainListBox.SelectedItem != null)
            {
                EditServiceWindow ASW = new EditServiceWindow(MainListBox.SelectedItem);
                ASW.ShowDialog();
                SVM.FillCollection(codeView.ServicesCollection);
            }
            else MessageBox.Show("Выберите элемент!");
        }

        private void SignClientGo(object sender, RoutedEventArgs e)
        {
            if (MainListBox.SelectedItem != null)
            {
                SignClientsWindow ASW = new SignClientsWindow(MainListBox.SelectedItem);
                ASW.ShowDialog();
            }
            else MessageBox.Show("Выберите элемент!");
        }

        private void GoToSigns(object sender, RoutedEventArgs e)
        {
            NearestSignsWindow ASW = new NearestSignsWindow();
            ASW.ShowDialog();
        }
    }
}
