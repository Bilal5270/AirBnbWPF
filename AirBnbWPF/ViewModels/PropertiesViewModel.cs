
using AirBnb.Model;
using AirBnbWPF.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class PropertiesViewModel : INotifyPropertyChanged
    {
        private Property _property;
        public Property Property { get => _property; set { _property = value; Notify("Property"); } }

        private Reservation _reservation;
        public Reservation Reservation { get => _reservation; set { _reservation = value; Notify("Reservation"); } }

        private Reservation _selectedReservation;
        private ObservableCollection<Reservation> allReservations;

        public Reservation SelectedReservation { get => _selectedReservation; set { _selectedReservation = value; Notify("Reservation"); } }

        public ObservableCollection<Reservation> AllReservations { get => allReservations; set { allReservations = value; Notify("AllReservations"); } }

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
