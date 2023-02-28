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
        public ICommand NewUserClick { get; set; }
        public ICommand ResetUserClick { get; set; }
        public ICommand OpenPropertyClick { get; set; }
        public ICommand LinkPropertyClick { get; set; }
        public ICommand SaveClick { get; set; }

        AirBnbContext _db = new AirBnbContext();

        public MainWindowViewModel()
        {
            _db.Users.Load();
            AllUsers = _db.Users.Local.ToObservableCollection();

            _db.Reservations.Load();
            AllReservations = _db.Reservations.Local.ToObservableCollection();
            
            _db.Landlords.Include(c => c.Properties).Load();
            AllLandlords = _db.Landlords.Local.ToObservableCollection();

            _db.Properties.Include(c => c.Landlord).Load();
            AllProperties = _db.Properties.Local.ToObservableCollection();




            //NewUserClick = new RelayCommand(AddNewStudent);
            //ResetUserClick = new RelayCommand(ResetStudent);
            OpenPropertyClick = new RelayCommand(OpenProperty);
            LinkPropertyClick = new RelayCommand(LinkProperty);
            SaveClick = new RelayCommand(Save);
        }

        //private void AddNewStudent()
        //{
        //    AllStudents.Add(new Student
        //    {
        //        FirstName = "NEW",
        //        LastName = "STUDENT",
        //        Number = "aaaa",
        //        Age = 44
        //    });
        //}

        private void LinkProperty()
        {
          
            SelectedLandlord.Properties.Add(SelectedProperty); 
            
           

            
        }

        private void UnlinkProperty()
        {

            SelectedLandlord.Properties.Remove(SelectedProperty);


        }

        //private void ResetStudent()
        //{
        //    SelectedUser.FirstName = "-----------";
        //    SelectedUser.LastName = "-----------";
        //}

        private void Save()
        {
            _db.SaveChanges();
        }

        private void OpenProperty()
        {
            Properties popup = new Properties();
            popup.Show();



            ((PropertiesViewModel)popup.DataContext).Property = SelectedProperty;
            ((PropertiesViewModel)popup.DataContext).Db = _db;
        }
    }
}
