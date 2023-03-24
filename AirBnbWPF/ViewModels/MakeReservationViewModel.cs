
using AirBnb.Model;
using AirBnbWPF.Model;
using AirBnbWPF.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        private DateTime _startDateSetter { get; set; }
        private DateTime _endDateSetter { get; set; }
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
       
        public DateTime StartDateSetter
        {
            get { return _startDateSetter; }
            set
            {
                _startDateSetter = value;
                Notify("StartDateSetter");
            }
        }
      
        public DateTime EndDateSetter
        {
            get { return _endDateSetter; }
            set
            {
                _endDateSetter = value;
                Notify("EndDateSetter");
            }
        }


        private void Create()
        {
            
            var reservations = AllReservations.Where(reservation => reservation.Property == Property && ((EndDateSetter >= reservation.StartDate && EndDateSetter <= reservation.EndDate) || (StartDateSetter >= reservation.StartDate && StartDateSetter <= reservation.EndDate)));

          

            
            if (reservations.Any())
            {
                return;
            }
            else
            {
                Reservation newReservation = new Reservation
                {
                    StartDate = StartDateSetter,
                    EndDate = EndDateSetter,
                    User = User,
                    Property = Property,

                };
                AllReservations.Add(newReservation);
            }



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
