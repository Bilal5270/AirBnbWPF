using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AirBnb.Model;
using AirBnbWPF.Model;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using AirBnbWPF.ViewModels;
using AirBnbWPF.Views;

namespace AirBnbWPF.ViewModels
{
    public class MainWindowViewModel
    {
        public User SelectedUser { get; set; }
        public Landlord SelectedLandlord { get; set; }
        public Reservation SelectedReservation { get; set; }
        public Property SelectedProperty { get; set; }
        public ObservableCollection<User> AllUsers { get; set; }
        public ObservableCollection<Property> AllProperties { get; set; }

        public ObservableCollection<Landlord> AllLandlords { get; set; }

        public ObservableCollection<Reservation> AllReservations { get; set; }
        public ICommand NewPropertyClick { get; set; }
        public ICommand NewLandlordClick { get; set; }
        public ICommand DeletePropertyClick { get; set; }
        public ICommand DeleteLandlordClick { get; set; }
        public ICommand OpenPropertyClick { get; set; }
        public ICommand LinkPropertyClick { get; set; }
        public ICommand OpenLandlordClick { get; set; }
        public ICommand UnlinkPropertyClick { get; set; }
        public ICommand OpenUserClick { get; set; }
        public ICommand DeleteUserClick { get; set; }
        public ICommand AddUserClick { get; set; }
        public ICommand SaveClick { get; set; }
        public ICommand OpenReservationClick { get; set; }
        public ICommand AddNewReservationClick { get; set; }
        public ICommand DeleteReservationClick { get; set; }
        public ICommand UnlinkReservationClick { get; set; }
        public ICommand LinkReservationClick { get; set; }

        AirBnbContext _db = new AirBnbContext();

        public MainWindowViewModel()
        {
            // ALL DATA LOADING
            _db.Users.Include(c => c.Reservations).Load();
            AllUsers = _db.Users.Local.ToObservableCollection();

            _db.Reservations.Include(c => c.User).Load();
            AllReservations = _db.Reservations.Local.ToObservableCollection();
            
            _db.Landlords.Include(c => c.Properties).Load();
            AllLandlords = _db.Landlords.Local.ToObservableCollection();

            _db.Properties.Include(c => c.Landlord).Load();
            AllProperties = _db.Properties.Local.ToObservableCollection();


            //ALL RELAY COMMANDS

            NewPropertyClick = new RelayCommand(AddNewProperty);
            DeletePropertyClick = new RelayCommand(DeleteProperty); 
            DeleteLandlordClick = new RelayCommand(DeleteLandlord);
            OpenPropertyClick = new RelayCommand(OpenProperty);
            UnlinkPropertyClick = new RelayCommand(UnlinkProperty);
            LinkPropertyClick = new RelayCommand(LinkProperty);
            OpenLandlordClick = new RelayCommand(OpenLandlord);
            NewLandlordClick = new RelayCommand(AddNewLandlord);
            OpenUserClick = new RelayCommand(OpenUser);
            DeleteUserClick = new RelayCommand(DeleteUser);
            AddUserClick = new RelayCommand(AddNewUser);
            OpenReservationClick = new RelayCommand(OpenReservation);
            DeleteReservationClick = new RelayCommand(DeleteReservation);
            AddNewReservationClick = new RelayCommand(AddNewReservation);
            UnlinkReservationClick = new RelayCommand(UnlinkReservation);
            LinkReservationClick = new RelayCommand(LinkReservation);
            SaveClick = new RelayCommand(Save);
        }

        private void AddNewProperty()
        {
            AllProperties.Add(new Property
            {
                Address = "NEW PROPERTY",
                Landlord = SelectedLandlord
            });
        }
        private void AddNewUser()
        {
            AllUsers.Add(new User
            {
                FirstName = "NEW USER",

            });
        }

        private void AddNewLandlord()
        {
            AllLandlords.Add(new Landlord
            {
                FirstName = "NEW LANDLORD",
                
            });
        }
        private void AddNewReservation()
        {
            
;


           

            MakeReservationView popup = new MakeReservationView();
            popup.Show();





            ((MakeReservationViewModel)popup.DataContext).AllUsers = AllUsers;
            ((MakeReservationViewModel)popup.DataContext).AllProperties = AllProperties;
            ((MakeReservationViewModel)popup.DataContext).AllReservations= AllReservations;
            ((MakeReservationViewModel)popup.DataContext).Reservation = SelectedReservation;
            ((MakeReservationViewModel)popup.DataContext).User = SelectedUser;
            ((MakeReservationViewModel)popup.DataContext).Property = SelectedProperty;
            ((MakeReservationViewModel)popup.DataContext).Db = _db;
        }

        private void LinkProperty()
        {
            if (SelectedLandlord.Properties.Contains(SelectedProperty))
                return;
            var findProperty = AllLandlords.FirstOrDefault(AllLandlords => AllLandlords.Properties.Any(Property => Property == SelectedProperty));
            if (findProperty == null)
            {
                SelectedLandlord.Properties.Add(SelectedProperty);
                SelectedProperty.Landlord = SelectedLandlord;
            }
            else
            {
                return;
            }
               





        }

        private void UnlinkProperty()
        {

            SelectedLandlord.Properties.Remove(SelectedProperty);

            SelectedProperty.Landlord = null;



        }

        private void LinkReservation()
        {
    
                SelectedUser.Reservations.Add(SelectedReservation);
                SelectedProperty.Reservations.Add(SelectedReservation);
            //Db.Add(Property.Landlord);
            //Reservation.User = User;


        }

        private void UnlinkReservation()
        {

            SelectedUser.Reservations.Remove(SelectedReservation);
            SelectedProperty.Reservations.Remove(SelectedReservation);
            //Db.Remove(Property.Landlord);
            //Reservation.User = null;


        }

        private void DeleteProperty()
        {
            _db.Remove(SelectedProperty);
        }
        private void DeleteLandlord()
        {
            _db.Remove(SelectedLandlord);
        }
        private void DeleteUser()
        {
            _db.Remove(SelectedUser);
        }
        private void DeleteReservation()
        {
            _db.Remove(SelectedReservation);
        }


        private void Save()
        {
            _db.SaveChanges();
        }

        private void OpenProperty()
        {
            PropertiesView popup = new PropertiesView();
            popup.Show();





            ((PropertiesViewModel)popup.DataContext).Property = SelectedProperty;
            ((PropertiesViewModel)popup.DataContext).Reservation = SelectedReservation;
            ((PropertiesViewModel)popup.DataContext).AllReservations = AllReservations;
            ((PropertiesViewModel)popup.DataContext).Db = _db;

        }
        private void OpenLandlord()
        {
            LandlordsView popup = new LandlordsView();
            popup.Show();





            ((LandlordsViewModel)popup.DataContext).Landlord = SelectedLandlord;
            ((LandlordsViewModel)popup.DataContext).Property = SelectedProperty;
            ((LandlordsViewModel)popup.DataContext).AllProperties = AllProperties;
            ((LandlordsViewModel)popup.DataContext).AllLandlords = AllLandlords;
            ((LandlordsViewModel)popup.DataContext).Db = _db;

        }

        private void OpenUser()
        {
            UsersView popup = new UsersView();
            popup.Show();





            ((UsersViewModel)popup.DataContext).User = SelectedUser;
            ((UsersViewModel)popup.DataContext).Reservation = SelectedReservation;
            ((UsersViewModel)popup.DataContext).AllReservations = AllReservations;
            ((UsersViewModel)popup.DataContext).Db = _db;

        }
        private void OpenReservation()
        {
            ReservationsView popup = new ReservationsView();
            popup.Show();





            ((ReservationsViewModel)popup.DataContext).Reservation = SelectedReservation;
            ((ReservationsViewModel)popup.DataContext).Db = _db;

        }
    }
}
