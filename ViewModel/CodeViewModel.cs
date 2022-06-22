using MainSaloon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSaloon.ViewModel
{
    public class CodeViewModel
    {
        public ObservableCollection<Service> ServicesCollection { get; set; }
        public string pass { get; set; }
        public bool IsAdmin
        {
            get
            {
                if (pass == "0000")
                    return true;
                else return false;
            }
            set
            {
                pass = value.ToString();
            }
        }
    }
}
