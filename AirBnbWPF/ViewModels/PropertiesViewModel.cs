
using AirBnb.Model;
using AirBnbWPF.Model;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class PropertiesViewModel : INotifyPropertyChanged
    {
        private Property _property;
        public Property Property { get => _property; set { _property = value; Notify("Property"); } }
       
        public AirBnbContext Db { get; set; }
        public ICommand SaveClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PropertiesViewModel()
        {
            SaveClick = new RelayCommand(Save);
        }

        private void Save()
        {
            Db.SaveChanges();
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
