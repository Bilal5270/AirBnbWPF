using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Listing : INotifyPropertyChanged


    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public virtual Property Property { get; set; }
        
    }
}
