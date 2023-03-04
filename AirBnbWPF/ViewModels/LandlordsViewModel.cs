
using AirBnb.Model;
using AirBnbWPF.Model;
using Castle.Components.DictionaryAdapter;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirBnbWPF.ViewModels
{
    public class LandlordsViewModel : INotifyPropertyChanged
    {
        private Landlord _landlord;
        public Landlord Landlord { get => _landlord; set { _landlord = value; Notify("Landlord"); } }

        private Property _property;
        public Property Property { get => _property; set { _property = value; Notify("Property"); } }

        private Property _selectedproperty;
        private ObservableCollection<Property> allProperties;

        public Property SelectedProperty { get => _selectedproperty; set { _selectedproperty = value; Notify("Property"); } }
        
        public ObservableCollection<Property> AllProperties { get => allProperties; set { allProperties = value; Notify("AllProperties"); } }
        public AirBnbContext Db { get; set; }

        // All ICommands
        public ICommand SaveClick { get; set; }
        public ICommand UnlinkPropertyClick { get; set; }
        public ICommand LinkPropertyClick { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LandlordsViewModel()

        {
            //All relaycommands bindings
            SaveClick = new RelayCommand(Save);
            UnlinkPropertyClick = new RelayCommand(UnlinkProperty);
            LinkPropertyClick = new RelayCommand(LinkProperty);
        }

        // All functions
        private void Save()
        {
            Db.SaveChanges();
        }

        private void LinkProperty()
        {

            Landlord.Properties.Add(Property);
            //Db.Add(Property.Landlord);


        }

        private void UnlinkProperty()
        {

            Landlord.Properties.Remove(Property);
            //Db.Remove(Property.Landlord);



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
