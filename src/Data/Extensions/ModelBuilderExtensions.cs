using System;
using System.Collections.Generic;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity[]
            {
                new LocationEntity()
                {
                    Id = 1,
                    Country = "Belarus",
                    City = "Grodno",
                    Address = "Lenina 1",
                },
                new LocationEntity()
                {
                    Id = 2,
                    Country = "Spain",
                    City = "Madrid",
                    Address = "Real 1",
                },
                new LocationEntity()
                {
                    Id = 3,
                    Country = "Spain",
                    City = "Barcelona",
                    Address = "Sun 33a",
                },
                new LocationEntity()
                {
                    Id = 4,
                    Country = "Russia",
                    City = "Moscow",
                    Address = "Red Square 56",
                },
            });

            modelBuilder.Entity<RentalPointEntity>().HasData(new RentalPointEntity[]
            {
                new RentalPointEntity()
                {
                    Id = 1,
                    Title = "Best cars",
                    LocationId = 1
                },
                new RentalPointEntity()
                {
                    Id = 2,
                    Title = "Best cars2",
                    LocationId = 2
                },
                new RentalPointEntity()
                {
                    Id = 3,
                    Title = "Best cars3",
                    LocationId = 3
                },
                new RentalPointEntity()
                {
                    Id = 4,
                    Title = "Best cars4",
                    LocationId = 4
                }
            });

            modelBuilder.Entity<CarEntity>().HasData(new CarEntity[]
            {
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    CarBrand = "Audi A4",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 1,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    CarBrand = "Car 2",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 1,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    CarBrand = "Car 3",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 1,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    CarBrand = "Car 4",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 1,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    CarBrand = "Car 5",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 1,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    CarBrand = "Car 2",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 2,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000007"),
                    CarBrand = "Car 3",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 2,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000008"),
                    CarBrand = "Car 4",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 3,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
                new CarEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000009"),
                    CarBrand = "Car 5",
                    FuelConsumptionPerHundredKilometers = new decimal(7.44),
                    TransmissionType = "Automate",
                    NumberOfSeats = 5,
                    Color = "Green",
                    VehicleNumber = "7300EK-4",
                    RentalPointId = 4,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = new decimal(20.50)
                },
            });

            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity[]
            {
                new RoleEntity()
                {
                    Id = 1,
                    Title = "Admin",
                },
                new RoleEntity()
                {
                    Id = 2,
                    Title = "User"
                }
            });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity[]
            {
                new UserEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Dima",
                    Surname = "Karkanitsa",
                    Email = "aakarkanica@gmail.com",
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                },
                new UserEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "User 1",
                    Surname = "Karkanitsa",
                    Email = "mail1@gmail.com",
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                },
                new UserEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "User 2",
                    Surname = "Karkanitsa",
                    Email = "mail2@gmail.com",
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                },
                new UserEntity()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Name = "User 3",
                    Surname = "Karkanitsa",
                    Email = "mail3@gmail.com",
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                }
            });

            modelBuilder.Entity<AdditionalFacilityEntity>().HasData(new AdditionalFacilityEntity[]
            {
                new AdditionalFacilityEntity()
                {
                    Id = 1,
                    Title = "Moika mashiny",
                    Price = new decimal(3.60)
                },
                new AdditionalFacilityEntity()
                {
                    Id = 2,
                    Title = "Water to car",
                    Price = new decimal(2.50)
                },
                new AdditionalFacilityEntity()
                {
                    Id = 3,
                    Title = "Vacuum cleaning",
                    Price = new decimal(3.60)
                },
            });
        }
    }
}
