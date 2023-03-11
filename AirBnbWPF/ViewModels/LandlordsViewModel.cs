
using AirBnb.Model;
using AirBnbWPF.Model;
using AirBnbWPF.Views;
using Castle.Components.DictionaryAdapter;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class LandlordsViewModel : INotifyPropertyChanged
    {
        AirBnbContext _db = new AirBnbContext();

        private Landlord _landlord;
        private ObservableCollection<Landlord> _allLandlords;
        public Landlord Landlord { get => _landlord; set { _landlord = value; Notify("Landlord"); } }

        private Property _property;
        public Property Property { get => _property; set { _property = value; Notify("Property"); } }

        private Property _selectedproperty;
        private ObservableCollection<Property> allProperties;

        public Property SelectedProperty { get => _selectedproperty; set { _selectedproperty = value; Notify("SelectedProperty"); } }
        
        public ObservableCollection<Property> AllProperties { get => allProperties; set { allProperties = value; Notify("AllProperties"); } }

        public ObservableCollection<Landlord> AllLandlords { get => _allLandlords; set { _allLandlords = value; Notify("AllLAndlords"); } }
        private Reservation _selectedReservation;
        private ObservableCollection<Reservation> allReservations;

        public Reservation SelectedReservation { get => _selectedReservation; set { _selectedReservation = value; Notify("Reservation"); } }

        public ObservableCollection<Reservation> AllReservations { get => allReservations; set { allReservations = value; Notify("AllReservations"); } }
        public AirBnbContext Db { get; set; }

        // All ICommands
        public ICommand SaveClick { get; set; }
        public ICommand UnlinkPropertyClick { get; set; }
        public ICommand LinkPropertyClick { get; set; }
        public ICommand DeletePropertyClick { get; set; }
        
        public ICommand OpenPropertyClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LandlordsViewModel()

        {
            //All relaycommands bindings
            SaveClick = new RelayCommand(Save);
            UnlinkPropertyClick = new RelayCommand(UnlinkProperty);
            LinkPropertyClick = new RelayCommand(LinkProperty);
            OpenPropertyClick = new RelayCommand(OpenProperty);
            DeletePropertyClick = new RelayCommand(DeleteProperty);
        }

        // All functions
        private void Save()
        {
            Db.SaveChanges();
        }
        private void LinkProperty()
        {
            if (Landlord.Properties.Contains(Property)) 
            {
                return;
            }     
            var findProperty = AllLandlords.FirstOrDefault(AllLandlords => AllLandlords.Properties.Any(Property => Property == SelectedProperty));
            if (findProperty == null) 
            {
                Landlord.Properties.Add(Property);
                Property.Landlord = Landlord;
            }

            else
            {
                return;
            }

           





        }
        private void DeleteProperty()
        {
            Db.Remove(Property);
        }
        private void OpenProperty()
        {
            PropertiesView popup = new PropertiesView();
            popup.Show();





            ((PropertiesViewModel)popup.DataContext).Property = Property;
            ((PropertiesViewModel)popup.DataContext).Reservation = SelectedReservation;
            ((PropertiesViewModel)popup.DataContext).AllReservations = AllReservations;
            ((PropertiesViewModel)popup.DataContext).Db = _db;

        }
        private void UnlinkProperty()
        {
            Property.Landlord = null;
            Landlord.Properties.Remove(Property);
         



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
