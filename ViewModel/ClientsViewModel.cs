using MainSaloon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainSaloon.ViewModel
{
    public class ClientsViewModel
    {
        public static SaloneButEntities salone { get; set; }
        public ObservableCollection<Client> FillCollection(ObservableCollection<Client> MainCollection)
        {
            salone = new SaloneButEntities();
            var b = salone.Client;
            var a = from Client in b select Client;
            MainCollection.Clear();
            foreach (var item in a)
            {
                MainCollection.Add(item);
            }
            return MainCollection;
        }
        public void Add(object SelectedClientItem, object SelectedServiceItem, DateTime StartTime)
        {
            var a = SelectedClientItem as Client;
            var u = SelectedServiceItem as Service;
            var b = salone.Client.FirstOrDefault(x => x.ID == a.ID);
            var c = salone.Service.FirstOrDefault(x => x.ID == u.ID);
            ClientService client = new ClientService()
            {
                StartTime = StartTime,
                ClientID = b.ID,
                ServiceID = u.ID,
            };
            salone.ClientService.Add(client);
            salone.SaveChanges();
        }

        public ObservableCollection<ClientService> FillSigns(ObservableCollection<ClientService> MainCollection)
        {
            salone = new SaloneButEntities();
            var b = salone.ClientService;
            var a = from ClientService in b select ClientService;
            MainCollection.Clear();
            foreach (var item in a)
            {
                MainCollection.Add(item);
            }
            return MainCollection;
        }

        public void Delete(object SelectedItem)
        {
            var ab = SelectedItem as Client;
            if (SelectedItem != null)
            {

            }
            else { MessageBox.Show("Выберите элемент!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
