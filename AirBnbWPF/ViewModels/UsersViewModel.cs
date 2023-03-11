
using AirBnb.Model;
using AirBnbWPF.Model;
using AirBnbWPF.Views;
using Castle.Components.DictionaryAdapter;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        AirBnbContext _db = new AirBnbContext();

        private User _user;
        public User User { get => _user; set { _user = value; Notify("User"); } }

        private Reservation _reservation;
        public Reservation Reservation { get => _reservation; set { _reservation = value; Notify("Reservation"); } }

        private Reservation _selectedReservation;
        private ObservableCollection<Reservation> allReservations;

        public Reservation SelectedReservation { get => _selectedReservation; set { _selectedReservation = value; Notify("Reservation"); } }
        
        public ObservableCollection<Reservation> AllReservations { get => allReservations; set { allReservations = value; Notify("AllReservations"); } }
        public AirBnbContext Db { get; set; }

        // All ICommands
        public ICommand SaveClick { get; set; }
        public ICommand OpenReservationClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public UsersViewModel()

        {
            //All relaycommands bindings
            SaveClick = new RelayCommand(Save);
            OpenReservationClick = new RelayCommand(OpenReservation);
        }

        // All functions
        private void Save()
        {
            Db.SaveChanges();
        }

 

        private void OpenReservation()
        {
            ReservationsView popup = new ReservationsView();
            popup.Show();





            ((ReservationsViewModel)popup.DataContext).Reservation = Reservation;
            ((ReservationsViewModel)popup.DataContext).Db = _db;

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
