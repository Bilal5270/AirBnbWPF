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
        public ICommand DeletePropertyClick { get; set; }
        public ICommand DeleteLandlordClick { get; set; }
        public ICommand OpenPropertyClick { get; set; }
        public ICommand LinkPropertyClick { get; set; }
        public ICommand OpenLandlordClick { get; set; }
        public ICommand UnlinkPropertyClick { get; set; }
        public ICommand OpenUserClick { get; set; }
        public ICommand SaveClick { get; set; }

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
            OpenUserClick = new RelayCommand(OpenUser);
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

        private void LinkProperty()
        {
          
            SelectedLandlord.Properties.Add(SelectedProperty); 
            
           

            
        }

        private void UnlinkProperty()
        {

            SelectedLandlord.Properties.Remove(SelectedProperty);
          
            
                

        }

        private void DeleteProperty()
        {
            _db.Remove(SelectedProperty);
        }
        private void DeleteLandlord()
        {
            _db.Remove(SelectedLandlord);
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
            ((PropertiesViewModel)popup.DataContext).Db = _db;

        }
        private void OpenLandlord()
        {
            LandlordsView popup = new LandlordsView();
            popup.Show();





            ((LandlordsViewModel)popup.DataContext).Landlord = SelectedLandlord;
            ((LandlordsViewModel)popup.DataContext).Property = SelectedProperty;
            ((LandlordsViewModel)popup.DataContext).AllProperties = AllProperties;
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
    }
}
