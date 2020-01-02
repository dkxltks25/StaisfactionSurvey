using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Survey.Model
{
    public class AdminModel : INotifyPropertyChanged
    {
        //INotifyEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        private string Id;
        public string AdminId
        {
            get { return Id; }
            set { Id = value; AdminPropertyChanged("AdminId"); }

        }
        private void AdminPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
