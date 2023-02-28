using AirBnb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnbWPF.Model
{
    public class Reservation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public virtual User User { get; set; }

        public virtual Property Property { get; set; }
       
    }
}
