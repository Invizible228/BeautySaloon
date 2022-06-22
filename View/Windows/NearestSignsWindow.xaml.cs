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
using System.Windows.Threading;

namespace MainSaloon.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для NearestSignsWindow.xaml
    /// </summary>
    public partial class NearestSignsWindow : Window
    {
        public static SaloneButEntities salone { get; set; }
        public ClientsViewModel CVM;
        public ObservableCollection<ClientService> CS { get; set; }
        public TimeSpan ToStart { get; set; }
        public NearestSignsWindow()
        {
            ToStart = new TimeSpan();
            CVM = new ClientsViewModel();
            CS = new ObservableCollection<ClientService>();
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //_time = TimeSpan.FromSeconds(10);
            //_timer = new DispatcherTimer(TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            //{
            //   ToStart.Text
            //}, Application.Current.Dispatcher);
            
            CVM.FillSigns(CS);
        }

        //private void Information(object sender, RoutedEventArgs e)
        //{
        //    var ab = MainListBox.SelectedItem as ClientService;
        //    DateTime B = DateTime.Now;
        //    if (ab != null)
        //    {
        //        var h = salone.ClientService.FirstOrDefault(x => x.ID == ab.ID);
        //        ToStart = B.Subtract(h.StartTime);
        //    }
        //}

        //private void Aboba(object sender, SelectionChangedEventArgs e)
        //{
        //    var ab = MainListBox.SelectedItem as ClientService;
        //    DateTime B = DateTime.Now;
        //    if (ab != null)
        //    {
        //        var h = salone.ClientService.FirstOrDefault(x => x.ID == ab.ID);
        //        ToStart = B.Subtract(h.StartTime);
        //    }
        //}
    }
}
