using MainSaloon.Model;
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
using System.Windows.Shapes;

namespace MainSaloon.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignClientsWindow.xaml
    /// </summary>
    public partial class SignClientsWindow : Window
    {
        public ClientsViewModel CVM;
        public ObservableCollection<Client> ClientCollection { get; set; }
        public Service service { get; set; }
        public SignClientsWindow(object SelectedItem)
        {
            service = SelectedItem as Service;
            ClientCollection = new ObservableCollection<Client>();
            CVM = new ClientsViewModel();
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Date.DisplayDateStart = DateTime.Now;
            CVM.FillCollection(ClientCollection);
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {   
            string u = Date.SelectedDate.Value.Date.ToShortDateString();
            string aboba = u + " " + Time.Text;

            CVM.Add(MainListBox.SelectedItem, service, DateTime.Parse(aboba));
            MessageBox.Show("Запись успешно добавлена! :)");
        }
    }
}
