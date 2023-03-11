
using AirBnb.Model;
using AirBnbWPF.Model;
using AirBnbWPF.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class MakeReservationViewModel : INotifyPropertyChanged
    {
        private Reservation _reservation;
        private User _user;
        private Property _property;
        private ObservableCollection<Property> allProperties;
        private ObservableCollection<User> allUsers;
        private ObservableCollection<Reservation> allReservations;
        public Reservation Reservation { get => _reservation; set { _reservation = value; Notify("Reservation"); } }
        public User User { get => _user; set { _user = value; Notify("User"); } }
        public Property Property { get => _property; set { _property = value; Notify("Property"); } }
        public ObservableCollection<User> AllUsers { get => allUsers; set { allUsers = value; Notify("AllUsers"); } }
        public ObservableCollection<Property> AllProperties { get => allProperties; set { allProperties = value; Notify("AllProperties"); } }

        public ObservableCollection<Reservation> AllReservations { get => allReservations; set { allReservations= value; Notify("AllReservations"); } }
        public AirBnbContext Db { get; set; }
        public ICommand SaveClick { get; set; }
        public ICommand CreateClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MakeReservationViewModel()
        {
            SaveClick = new RelayCommand(Save);
            CreateClick = new RelayCommand(Create);
        }
        private void Create()
        {

            AllReservations.Add(new Reservation
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                User = User,
                Property = Property,

            });
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
