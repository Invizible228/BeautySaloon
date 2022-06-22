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
    public class ServicesViewModel
    {
        public static SaloneButEntities salone { get; set; }
        public ObservableCollection<Service> FillCollection(ObservableCollection<Service> MainCollection)
        {
            salone = new SaloneButEntities();
            var b = salone.Service;
            var a = from Service in b select Service;
            MainCollection.Clear();
            foreach (var item in a)
            {
                var test = new Service
                {
                    Title = item.Title,
                    DurationInSeconds = item.DurationInSeconds / 60,
                    Description = item.Description,
                    Discount = item.Discount,
                    Cost = Math.Round(item.Cost),
                    MainImagePath = item.MainImagePath,
                    ID = item.ID
                };
                MainCollection.Add(test);
            }
            return MainCollection;
        }

        public void Delete(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                var a = MessageBox.Show("Удалить", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (a == MessageBoxResult.Yes)
                {
                    
                    Service service = SelectedItem as Service;
                    if (salone.ClientService.Where(x => x.ServiceID == service.ID).Count() == 0)
                    {
                        var b = salone.Service.Find(service.ID);
                        salone.Service.Remove(b);
                        salone.SaveChanges();
                    }
                    else { MessageBox.Show("На данную услугу имеется заявка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
            }
            else { MessageBox.Show("Выберите услугу!"); }
        }

        public void Add(string title, decimal cost, int duration, string desciption, float discount, string imagep)
        {
            Service ser = new Service
            {
                Title = title,
                Cost = cost,
                DurationInSeconds = duration,
                Description = desciption,
                Discount = discount,
                MainImagePath = imagep
            };
            var b = salone.Service.FirstOrDefault(x => x.Title == ser.Title);
            if (b == null)
            {
                salone.Service.Add(ser);
                salone.SaveChanges();
            }
            else { MessageBox.Show("Данная услуга уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        public void Edit(object SelectedItem)
        {
            var ab = SelectedItem as Service;
            var b = salone.Service.FirstOrDefault(x => x.ID == ab.ID);
            if (b != null)
            {
                b.Title = ab.Title;
                b.Cost = ab.Cost;
                b.Description = ab.Description;
                b.Discount = ab.Discount;
                b.MainImagePath = ab.MainImagePath;
                b.DurationInSeconds = ab.DurationInSeconds * 60;
            }
            salone.SaveChanges();
        }
    }
}
