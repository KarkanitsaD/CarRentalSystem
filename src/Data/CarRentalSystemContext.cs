using System;
using Data.Entities;
using Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarRentalSystemContext : DbContext
    {
        public CarRentalSystemContext(DbContextOptions<CarRentalSystemContext> options)
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
        public DbSet<CarPictureEntity> CarPictureEntities { get; set; }
        public DbSet<CarLockEntity> CarLocks { get; set; }
        public DbSet<BookingFeedbackEntity> BookingFeedbacks { get; set; }
        public DbSet<AdditionalFacilityEntity> AdditionalFacilities { get; set; }
        public DbSet<AdditionalFacilityBookingEntity> AdditionalFacilityBookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new RoleEntityTypeConfiguration())
                .ApplyConfiguration(new RentalPointEntityTypeConfiguration())
                .ApplyConfiguration(new BookingEntityTypeConfiguration())
                .ApplyConfiguration(new CarEntityTypeConfiguration())
                .ApplyConfiguration(new CityEntityTypeConfiguration())
                .ApplyConfiguration(new CountryEntityTypeConfiguration())
                .ApplyConfiguration(new RefreshTokenEntityTypeConfiguration())
                .ApplyConfiguration(new CarPictureEntityTypeConfiguration())
                .ApplyConfiguration(new BookingFeedbackEntityTypeConfiguration())
                .ApplyConfiguration(new AdditionalFacilityEntityTypeConfiguration())
                .ApplyConfiguration(new AdditionalFacilityBookingEntityTypeConfiguration());
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
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
                new UserEntity(){ Id = adminId, Email = "admin@mail.ru", PasswordHash = "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", Name = "Dima", Surname = "Karkanitsa"}, 
                new UserEntity(){ Id = userId, Email = "user@mail.ru", PasswordHash = "a1e48daec54145146b89d816a089ba3294d2748796b8491e9a719d54d2ca0b8aHpd_7foo.ss]jr4F-nNMes31", Name = "Vova", Surname = "Petrov"}, 
            });
        }
    }
}