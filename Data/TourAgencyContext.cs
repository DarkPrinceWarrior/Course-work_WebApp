using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TourAgency1.Models;

namespace TourAgency1._0.Data
{
    public class TourAgencyContext : DbContext
    {
        //private readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);

        public TourAgencyContext(DbContextOptions<TourAgencyContext> options)
            : base(options)
        {
            //Database.EnsureCreated();

        }
        

        //логирование
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);



        }

        //public override void Dispose()
        //{
            
        //    base.Dispose();
        //    logStream.Dispose();

        //}

        //public override async ValueTask DisposeAsync()
        //{
            
        //    await base.DisposeAsync();
        //    await logStream.DisposeAsync();

        //}


        public DbSet<Tour> Tours { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<AirLines> AirLines { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<HotelRoom> hotelRoom { get; set; }
        public DbSet<UserData> userData { get; set; }
        public DbSet<RoomNumber> roomNumber { get; set; }
        public DbSet<AirCompany> airCompany { get; set; }
        public DbSet<City_From> city_From { get; set; }
        public DbSet<CityLanding> cityLanding { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new HotelsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new AirLinesConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new HotelRoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());
            modelBuilder.ApplyConfiguration(new RoomNumberConfiguration());
            modelBuilder.ApplyConfiguration(new AirCompConfiguration());
            modelBuilder.ApplyConfiguration(new CityFromConfiguration());
            modelBuilder.ApplyConfiguration(new CityLandingConfiguration());


        }

        
    }

    public class AirCompConfiguration : IEntityTypeConfiguration<AirCompany>
    {
        public void Configure(EntityTypeBuilder<AirCompany> builder)
        {

            builder.HasIndex(u => u.AirCompName).IsUnique();


        }
    }




    public class CityFromConfiguration : IEntityTypeConfiguration<City_From>
    {
        public void Configure(EntityTypeBuilder<City_From> builder)
        {

            builder.HasIndex(u => u.City).IsUnique();


        }
    }




    public class CityLandingConfiguration : IEntityTypeConfiguration<CityLanding>
    {
        public void Configure(EntityTypeBuilder<CityLanding> builder)
        {

            builder.HasIndex(u => u.City).IsUnique();


        }
    }



   

    public class RoomNumberConfiguration : IEntityTypeConfiguration<RoomNumber>
    {
        public void Configure(EntityTypeBuilder<RoomNumber> builder)
        {

       

            builder.HasOne(p => p.hotelRoom)
            .WithMany(t => t.roomNumber)
            .HasForeignKey(p => p.roomTypeId);

            builder.HasOne(p => p.hotels)
           .WithMany(t => t.roomNumber)
           .HasForeignKey(p => p.HotelId);



        }
    }






    public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            
            builder.HasIndex(u => u.FIO).IsUnique();
            builder.HasIndex(u => u.series).IsUnique();
            builder.HasIndex(u => u.PNumber).IsUnique();


            //Foreign key
            builder.HasOne(p => p.users)
            .WithOne(t => t.userData)
            .HasForeignKey<UserData>(p =>p.UserId);


        }
    }




    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(u => u.Pictures).HasDefaultValue("Resources\\Photos\\deffaultPic.jpg");
            builder.HasIndex(u => u.City).IsUnique();
            builder.HasIndex(u => u.Tour_Name).IsUnique();



        }
    }

    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.HasIndex(u => u.RoomType).IsUnique();


        }
    }



    public class HotelsConfiguration : IEntityTypeConfiguration<Hotels>
    {
        public void Configure(EntityTypeBuilder<Hotels> builder)
        {
            builder.Property(u => u.Pictures).HasDefaultValue("Resources\\Photos\\deffaultPic.jpg");
            builder.HasIndex(u => u.Hotel_Name).IsUnique();
            builder.Property(u => u.NightPrice).HasDefaultValue(0);
            builder.Property(u => u.FreePlaces).HasDefaultValue(0);


            ////Foreign key
            builder.HasOne(p => p.tours)
            .WithMany(t => t.Hotel)
            .HasForeignKey(p => p.TourId);

        }
    }

    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasIndex(u => u.Login).IsUnique();
            builder.HasIndex(u => u.email).IsUnique();
            builder.HasIndex(u => u.password).IsUnique();

            ////Foreign key
            builder.HasOne(p => p.roles)
            .WithMany(t => t.user)
            .HasForeignKey(p => p.RoleId);


        }
    }
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(u => new {u.Id, u.Number_of_days, u.Number_of_people, u.RoomNumberId });


            //Foreign key
            builder.HasOne(p => p.airLines)
            .WithMany(t => t.booking)
            .HasForeignKey(p => p.AirLineId);

            //////Foreign key
            builder.HasOne(p => p.users)
            .WithMany(t => t.booking)
            .HasForeignKey(p => p.TouristId);

            ////Foreign key
            builder.HasOne(p => p.roomNumber)
            .WithMany(t => t.booking)
            .HasForeignKey(p => p.RoomNumberId);





        }
    }

    public class AirLinesConfiguration : IEntityTypeConfiguration<AirLines>
    {
        public void Configure(EntityTypeBuilder<AirLines> builder)
        {

            

            builder.HasOne(p => p.city_From)
          .WithMany(t => t.airLines)
          .HasForeignKey(p => p.CityBoardingId);

            builder.HasOne(p => p.airCompany)
         .WithMany(t => t.airLines)
         .HasForeignKey(p => p.AirCompId);

            builder.HasOne(p => p.cityLanding)
         .WithMany(t => t.airLines)
         .HasForeignKey(p => p.CityLandingId);



        }
    }
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasIndex(u => u.RoleName).IsUnique();
        }
    }
}
