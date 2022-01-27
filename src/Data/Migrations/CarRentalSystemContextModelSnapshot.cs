﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(CarRentalSystemContext))]
    partial class CarRentalSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AdditionalFacilityBookingEntity", b =>
                {
                    b.Property<Guid>("AdditionalFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AdditionalFacilityId", "BookingId");

                    b.HasIndex("BookingId");

                    b.ToTable("AdditionalFacilityBookings");
                });

            modelBuilder.Entity("Data.Entities.AdditionalFacilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RentalPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RentalPointId");

                    b.ToTable("AdditionalFacilities");
                });

            modelBuilder.Entity("Data.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KeyHandOverTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KeyReceivingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("RentalPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("RentalPointId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Data.Entities.BookingFeedbackEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("BookingFeedbacks");
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FuelConsumptionPerHundredKilometers")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LastViewTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RentalPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransmissionType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RentalPointId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Data.Entities.CarLockEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LockTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CarLocks");
                });

            modelBuilder.Entity("Data.Entities.CarPictureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("CarPictureEntities");
                });

            modelBuilder.Entity("Data.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("TimeOffset")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Data.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Title");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Data.Entities.RefreshTokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Data.Entities.RentalPointEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("LocationX")
                        .HasColumnType("real");

                    b.Property<float?>("LocationY")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("RentalPoints");
                });

            modelBuilder.Entity("Data.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entities.AdditionalFacilityBookingEntity", b =>
                {
                    b.HasOne("Data.Entities.AdditionalFacilityEntity", "AdditionalFacility")
                        .WithMany("AdditionalFacilityBookings")
                        .HasForeignKey("AdditionalFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.BookingEntity", "Booking")
                        .WithMany("AdditionalFacilityBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Data.Entities.AdditionalFacilityEntity", b =>
                {
                    b.HasOne("Data.Entities.RentalPointEntity", "RentalPoint")
                        .WithMany("AdditionalFacilities")
                        .HasForeignKey("RentalPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalPoint");
                });

            modelBuilder.Entity("Data.Entities.BookingEntity", b =>
                {
                    b.HasOne("Data.Entities.CarEntity", "Car")
                        .WithMany("Bookings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.Entities.RentalPointEntity", "RentalPoint")
                        .WithMany("Bookings")
                        .HasForeignKey("RentalPointId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.Entities.UserEntity", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("RentalPoint");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.BookingFeedbackEntity", b =>
                {
                    b.HasOne("Data.Entities.BookingEntity", "Booking")
                        .WithOne("BookingFeedback")
                        .HasForeignKey("Data.Entities.BookingFeedbackEntity", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.CarEntity", "Car")
                        .WithMany("BookingFeedbacks")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.UserEntity", "User")
                        .WithMany("BookingFeedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.HasOne("Data.Entities.RentalPointEntity", "RentalPoint")
                        .WithMany("Cars")
                        .HasForeignKey("RentalPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RentalPoint");
                });

            modelBuilder.Entity("Data.Entities.CarLockEntity", b =>
                {
                    b.HasOne("Data.Entities.CarEntity", "Car")
                        .WithOne("CarLockEntity")
                        .HasForeignKey("Data.Entities.CarLockEntity", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.UserEntity", "User")
                        .WithOne("CarLockEntity")
                        .HasForeignKey("Data.Entities.CarLockEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.CarPictureEntity", b =>
                {
                    b.HasOne("Data.Entities.CarEntity", "Car")
                        .WithOne("Picture")
                        .HasForeignKey("Data.Entities.CarPictureEntity", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Data.Entities.CityEntity", b =>
                {
                    b.HasOne("Data.Entities.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Entities.RefreshTokenEntity", b =>
                {
                    b.HasOne("Data.Entities.UserEntity", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Data.Entities.RefreshTokenEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.RentalPointEntity", b =>
                {
                    b.HasOne("Data.Entities.CityEntity", "City")
                        .WithMany("RentalPointEntities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.CountryEntity", "Country")
                        .WithMany("RentalPoints")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.HasOne("Data.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Entities.AdditionalFacilityEntity", b =>
                {
                    b.Navigation("AdditionalFacilityBookings");
                });

            modelBuilder.Entity("Data.Entities.BookingEntity", b =>
                {
                    b.Navigation("AdditionalFacilityBookings");

                    b.Navigation("BookingFeedback");
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Navigation("BookingFeedbacks");

                    b.Navigation("Bookings");

                    b.Navigation("CarLockEntity");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("Data.Entities.CityEntity", b =>
                {
                    b.Navigation("RentalPointEntities");
                });

            modelBuilder.Entity("Data.Entities.CountryEntity", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("RentalPoints");
                });

            modelBuilder.Entity("Data.Entities.RentalPointEntity", b =>
                {
                    b.Navigation("AdditionalFacilities");

                    b.Navigation("Bookings");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Data.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.Navigation("BookingFeedbacks");

                    b.Navigation("Bookings");

                    b.Navigation("CarLockEntity");

                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
