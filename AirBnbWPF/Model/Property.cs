using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Property : INotifyPropertyChanged
    {
        private string _address;
        private string _city;
        private string _postalCode;
        private int _amountOfRooms;
        private int _pricePerNight;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }
        public string Address { get => _address; set { _address = value; Notify("Address"); } }
        public string City { get => _city; set { _city = value; Notify("City"); } }
        public string PostalCode { get => _postalCode; set { _postalCode = value; Notify("PostalCode"); } }

        public int AmountOfRooms { get => _amountOfRooms; set { _amountOfRooms = value; Notify("AmountOfRooms"); } }

        public int PricePerNight { get => _pricePerNight; set { _pricePerNight = value; Notify("PricePerNight"); } }



        public  virtual Landlord? Landlord { get; set; }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
