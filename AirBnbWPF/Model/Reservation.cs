using AirBnb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AirBnbWPF.Model
{
    public class Reservation : INotifyPropertyChanged
    {
        private DateTime _endDate;
        private DateTime _startDate;
        private int _id;

        public event PropertyChangedEventHandler? PropertyChanged;
        public int Id { get => _id; set { _id = value; Notify("Id"); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; Notify("StartDate"); } }

        public DateTime EndDate { get => _endDate; set { _endDate = value; Notify("EndDate"); } }

        public virtual User? User { get; set; }

        public virtual Property? Property { get; set; }

        public string StartDateAsString { get => StartDate.ToShortDateString(); }
        public string EndDateAsString { get => EndDate.ToShortDateString(); }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
