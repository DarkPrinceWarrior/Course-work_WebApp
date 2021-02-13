﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourAgency1._0.Data;

namespace TourAgency1._0.Migrations
{
    [DbContext(typeof(TourAgencyContext))]
    [Migration("20210208203132_IdentityForBooking")]
    partial class IdentityForBooking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TourAgency1.Models.AirCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AirCompName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AirCompName")
                        .IsUnique();

                    b.ToTable("airCompany");
                });

            modelBuilder.Entity("TourAgency1.Models.AirLines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AirCompId")
                        .HasColumnType("int");

                    b.Property<string>("AirLineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityBoardingId")
                        .HasColumnType("int");

                    b.Property<int?>("CityLandingId")
                        .HasColumnType("int");

                    b.Property<decimal>("TheSum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AirCompId");

                    b.HasIndex("CityBoardingId");

                    b.HasIndex("CityLandingId");

                    b.ToTable("AirLines");
                });

            modelBuilder.Entity("TourAgency1.Models.Booking", b =>
                {
                    b.Property<int>("Number_of_days")
                        .HasColumnType("int");

                    b.Property<int>("Number_of_people")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumberId")
                        .HasColumnType("int");

                    b.Property<int?>("AirLineId")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int>("TouristId")
                        .HasColumnType("int");

                    b.HasKey("Number_of_days", "Number_of_people", "RoomNumberId");

                    b.HasIndex("AirLineId");

                    b.HasIndex("RoomNumberId");

                    b.HasIndex("TouristId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("TourAgency1.Models.CityLanding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("City")
                        .IsUnique();

                    b.ToTable("cityLanding");
                });

            modelBuilder.Entity("TourAgency1.Models.City_From", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("City")
                        .IsUnique();

                    b.ToTable("city_From");
                });

            modelBuilder.Entity("TourAgency1.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoomType")
                        .IsUnique();

                    b.ToTable("hotelRoom");
                });

            modelBuilder.Entity("TourAgency1.Models.Hotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FreePlaces")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Hotel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("NightPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Pictures")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Resources\\Photos\\deffaultPic.jpg");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<string>("descrip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Hotel_Name")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TourAgency1.Models.Roles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TourAgency1.Models.RoomNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<decimal>("RoomSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("roomNumber")
                        .HasColumnType("int");

                    b.Property<int?>("roomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("roomTypeId");

                    b.ToTable("roomNumber");
                });

            modelBuilder.Entity("TourAgency1.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pictures")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Resources\\Photos\\deffaultPic.jpg");

                    b.Property<string>("Tour_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("descrip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("City")
                        .IsUnique();

                    b.HasIndex("Tour_Name")
                        .IsUnique();

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourAgency1.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("series")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FIO")
                        .IsUnique();

                    b.HasIndex("PNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("series")
                        .IsUnique();

                    b.ToTable("userData");
                });

            modelBuilder.Entity("TourAgency1.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("password")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TourAgency1.Models.AirLines", b =>
                {
                    b.HasOne("TourAgency1.Models.AirCompany", "airCompany")
                        .WithMany("airLines")
                        .HasForeignKey("AirCompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency1.Models.City_From", "city_From")
                        .WithMany("airLines")
                        .HasForeignKey("CityBoardingId");

                    b.HasOne("TourAgency1.Models.CityLanding", "cityLanding")
                        .WithMany("airLines")
                        .HasForeignKey("CityLandingId");

                    b.Navigation("airCompany");

                    b.Navigation("city_From");

                    b.Navigation("cityLanding");
                });

            modelBuilder.Entity("TourAgency1.Models.Booking", b =>
                {
                    b.HasOne("TourAgency1.Models.AirLines", "airLines")
                        .WithMany("booking")
                        .HasForeignKey("AirLineId");

                    b.HasOne("TourAgency1.Models.RoomNumber", "roomNumber")
                        .WithMany("booking")
                        .HasForeignKey("RoomNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency1.Models.Users", "users")
                        .WithMany("booking")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("airLines");

                    b.Navigation("roomNumber");

                    b.Navigation("users");
                });

            modelBuilder.Entity("TourAgency1.Models.Hotels", b =>
                {
                    b.HasOne("TourAgency1.Models.Tour", "tours")
                        .WithMany("Hotel")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tours");
                });

            modelBuilder.Entity("TourAgency1.Models.RoomNumber", b =>
                {
                    b.HasOne("TourAgency1.Models.Hotels", "hotels")
                        .WithMany("roomNumber")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency1.Models.HotelRoom", "hotelRoom")
                        .WithMany("roomNumber")
                        .HasForeignKey("roomTypeId");

                    b.Navigation("hotelRoom");

                    b.Navigation("hotels");
                });

            modelBuilder.Entity("TourAgency1.Models.UserData", b =>
                {
                    b.HasOne("TourAgency1.Models.Users", "users")
                        .WithOne("userData")
                        .HasForeignKey("TourAgency1.Models.UserData", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("TourAgency1.Models.Users", b =>
                {
                    b.HasOne("TourAgency1.Models.Roles", "roles")
                        .WithMany("user")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("TourAgency1.Models.AirCompany", b =>
                {
                    b.Navigation("airLines");
                });

            modelBuilder.Entity("TourAgency1.Models.AirLines", b =>
                {
                    b.Navigation("booking");
                });

            modelBuilder.Entity("TourAgency1.Models.CityLanding", b =>
                {
                    b.Navigation("airLines");
                });

            modelBuilder.Entity("TourAgency1.Models.City_From", b =>
                {
                    b.Navigation("airLines");
                });

            modelBuilder.Entity("TourAgency1.Models.HotelRoom", b =>
                {
                    b.Navigation("roomNumber");
                });

            modelBuilder.Entity("TourAgency1.Models.Hotels", b =>
                {
                    b.Navigation("roomNumber");
                });

            modelBuilder.Entity("TourAgency1.Models.Roles", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("TourAgency1.Models.RoomNumber", b =>
                {
                    b.Navigation("booking");
                });

            modelBuilder.Entity("TourAgency1.Models.Tour", b =>
                {
                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TourAgency1.Models.Users", b =>
                {
                    b.Navigation("booking");

                    b.Navigation("userData");
                });
#pragma warning restore 612, 618
        }
    }
}
