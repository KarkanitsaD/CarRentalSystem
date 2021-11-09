using System;
using Data.Entities;
using Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarRentalSystemContext : DbContext
    {
        public CarRentalSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public CarRentalSystemContext()
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<RentalPointEntity> RentalPoints { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new RoleEntityTypeConfiguration())
                .ApplyConfiguration(new RentalPointEntityTypeConfiguration())
                .ApplyConfiguration(new BookingEntityTypeConfiguration())
                .ApplyConfiguration(new CarEntityTypeConfiguration())
                .ApplyConfiguration(new CityEntityTypeConfiguration())
                .ApplyConfiguration(new CountryEntityTypeConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var firstCountryId = Guid.NewGuid();
            var secondCountryId = Guid.NewGuid();

            modelBuilder.Entity<CountryEntity>().HasData(new CountryEntity[]
            {
                new CountryEntity() { Id = firstCountryId, Title = "Belarus"},
                new CountryEntity() { Id = secondCountryId, Title = "Poland"}
            });

            var firstCityId = Guid.NewGuid();
            var secondCityId = Guid.NewGuid();
            modelBuilder.Entity<CityEntity>().HasData(new CityEntity[]
            {
                new CityEntity() { Id = firstCityId, CountryId = firstCountryId, Title = "Minsk"},
                new CityEntity() { Id = secondCityId, CountryId = secondCountryId, Title = "Warsaw"},
            });

            var firstRentalPointId = Guid.NewGuid();
            var secondRentalPointId = Guid.NewGuid();
            modelBuilder.Entity<RentalPointEntity>().HasData(new RentalPointEntity[]
            {
                new RentalPointEntity(){ Id = firstRentalPointId, CountryId = firstCountryId, CityId = firstCityId, Title = "Title 1!" },
                new RentalPointEntity(){ Id = secondRentalPointId, CountryId = secondCountryId, CityId = secondCityId, Title = "Title 2!"},
            });

            var firstCarId = Guid.NewGuid();
            var secondCarId = Guid.NewGuid();
            var thirdCarId = Guid.NewGuid();
            var fourthCarId = Guid.NewGuid();
            modelBuilder.Entity<CarEntity>().HasData(new CarEntity[]
            {
                new CarEntity()
                {
                    Id = firstCarId,
                    RentalPointId = firstRentalPointId,
                    CarBrand = "Porsche 911",
                    FuelConsumptionPerHundredKilometers = 12,
                    TransmissionType = "Automate",
                    NumberOfSeats = 4,
                    Color = "Red",
                    IsBooked = false,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = 150
                },
                new CarEntity()
                {
                    Id = secondCarId,
                    RentalPointId = firstRentalPointId,
                    CarBrand = "Renault Kadjar",
                    FuelConsumptionPerHundredKilometers = 4,
                    TransmissionType = "Mechanic",
                    NumberOfSeats = 5,
                    Color = "Black",
                    IsBooked = false,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = 60
                },
                new CarEntity()
                {
                    Id = thirdCarId,
                    RentalPointId = firstRentalPointId,
                    CarBrand = "Mazda cx 5",
                    FuelConsumptionPerHundredKilometers = new decimal(6.7),
                    TransmissionType = "Mechanic",
                    NumberOfSeats = 5,
                    Color = "Blue",
                    IsBooked = false,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = 65
                },
                new CarEntity()
                {
                    Id = fourthCarId,
                    RentalPointId = secondRentalPointId,
                    CarBrand = "Mazda cx 5",
                    FuelConsumptionPerHundredKilometers = new decimal(6.7),
                    TransmissionType = "Mechanic",
                    NumberOfSeats = 5,
                    Color = "Red",
                    IsBooked = false,
                    LastViewTime = DateTime.MinValue,
                    PricePerDay = 65
                },
            });

            var userRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity[]
            {
                new RoleEntity(){ Id = adminRoleId, Title = "Admin" },
                new RoleEntity(){ Id = userRoleId, Title = "User" },
            });


            var userId = Guid.NewGuid();
            var adminId = Guid.NewGuid();
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity[]
            {
                new UserEntity(){ Id = adminId, Email = "admin@mail.ru", PasswordHash = "123456" }, 
                new UserEntity(){ Id = userId, Email = "user@mail.ru", PasswordHash = "123456" }, 
            });
        }
    }
}