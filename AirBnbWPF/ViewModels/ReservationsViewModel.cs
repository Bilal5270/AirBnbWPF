
using AirBnb.Model;
using AirBnbWPF.Model;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private Reservation _reservation;
        public Reservation Reservation { get => _reservation; set { _reservation = value; Notify("Reservation"); } }
       
        public AirBnbContext Db { get; set; }
        public ICommand SaveClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReservationsViewModel()
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
