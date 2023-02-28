using AirBnbWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class User :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }

        private string _firstName;
        public string FirstName { get => _firstName; set { _firstName = value; Notify("FirstName"); } }

        private string _lastName;
        public string LastName { get => _lastName; set { _lastName = value; Notify("LastName"); } }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual  ObservableCollection <Reservation>? Reservations { get; set; }

        public User()
        {
            Reservations = new ObservableCollection<Reservation>();
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
