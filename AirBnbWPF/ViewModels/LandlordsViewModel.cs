
using AirBnb.Model;
using AirBnbWPF.Model;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class LandlordsViewModel : INotifyPropertyChanged
    {
        private Landlord _landlord;
        public Landlord Landlord { get => _landlord; set { _landlord = value; Notify("Landlord"); } }
       
        public AirBnbContext Db { get; set; }
        public ICommand SaveClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LandlordsViewModel()
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
