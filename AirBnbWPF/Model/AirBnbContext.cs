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
        //DbSet<Listing> Listings { get; set; }
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
                new { Address = "Beeldhouwerpad 156 ", PostalCode = "1315KB", Id = 1, City = "Almere",  AmountOfRooms = 4, PricePerNight = 50, LandlordId = 1 },
                new { Address = "Kasteellaan 100", PostalCode = "8225LL", Id = 2, City = "Lelystad",  AmountOfRooms = 40, PricePerNight = 500 , LandlordId = 1}
            );

            modelBuilder.Entity<Landlord>().HasData(
                new { FirstName = "Karim", LastName = "Ayachi", Id = 1},
                new { FirstName = "Yousry", LastName = "Yousef", Id = 2 }

            );

            modelBuilder.Entity<Reservation>().HasData(
               new  { Id = 1, StartDate = "27-02-2023", EndDate = "31-03-2023", UserId = 1 , PropertyId = 1 }

           );

            

        }
    }
}
