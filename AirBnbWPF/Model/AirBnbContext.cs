using AirBnb.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirBnbWPF.Model


{   
    public class AirBnbContext : DbContext
    {
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AirBnbWPFDatabase;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { FirstName = "Bilal", LastName = "Yousef", Id = 1  },
                new User { FirstName = "Max", LastName = "Metz", Id = 2 }
            );

            modelBuilder.Entity<Property>().HasData(
                new { Address = "Beeldhouwerpad 156 ", PostalCode = "1315KB", Id = 1, City = "Almere",  AmountOfRooms = 4, PricePerNight = 50, LandlordId = 1},
                new { Address = "Kasteellaan 100", PostalCode = "8225LL", Id = 2, City = "Lelystad",  AmountOfRooms = 40, PricePerNight = 500 , LandlordId = 1},
                new { Address = "Rotterdamsestraat 21", PostalCode = "3011LL", Id = 3, City = "Rotterdam", AmountOfRooms = 3, PricePerNight = 150, LandlordId = 2 },
                new { Address = "Runmolenstraat 46", PostalCode = "1333AR", Id = 4, City = "Almere", AmountOfRooms = 4, PricePerNight = 40, LandlordId = 2 },
                new { Address = "De Wallen", PostalCode = "1063XO", Id = 5, City = "Amsterdam", AmountOfRooms = 1, PricePerNight = 200, LandlordId = 2},
                new { Address = "Prinsengracht 123", PostalCode = "1015DK", Id = 6, City = "Amsterdam", AmountOfRooms = 2, PricePerNight = 100, LandlordId = 1 },
                new { Address = "Zeedijk 101", PostalCode = "1012AX", Id = 7, City = "Amsterdam", AmountOfRooms = 3, PricePerNight = 120, LandlordId = 2 },
                new { Address = "Keizersgracht 456", PostalCode = "1017EG", Id = 8, City = "Amsterdam", AmountOfRooms = 5, PricePerNight = 200, LandlordId = 1 },
                new { Address = "Groningerstraat 78", PostalCode = "9718PT", Id = 9, City = "Groningen", AmountOfRooms = 4, PricePerNight = 80, LandlordId = 2 },
                new { Address = "Vrijthof 55", PostalCode = "6211LE", Id = 10, City = "Maastricht", AmountOfRooms = 6, PricePerNight = 250, LandlordId = 3 }
            );

            modelBuilder.Entity<Landlord>().HasData(
                new { FirstName = "Karim", LastName = "Ayachi", Id = 1},
                new { FirstName = "Yousry", LastName = "Yousef", Id = 2 },
                new { FirstName = "Atal", LastName = "Burhani", Id = 3}

            );

            modelBuilder.Entity<Reservation>().HasData(
               new { Id = 1, StartDate = new DateTime (2022, 6, 1), EndDate = new DateTime(2022, 7, 1), UserId = 1 , PropertyId = 1 },
               new { Id = 2, StartDate = new DateTime(2022, 3, 7), EndDate = new DateTime(2022, 3, 8), UserId = 2, PropertyId = 2 }

           );

            

        }
    }
}
