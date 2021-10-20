using Data.Entities;
using Data.EntitiesConfigurations;
using Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public ApplicationContext()
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<RentalPointEntity> RentalPoints { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<AdditionalFacilityEntity> AdditionalFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new RoleEntityTypeConfiguration())
                .ApplyConfiguration(new RentalPointEntityTypeConfiguration())
                .ApplyConfiguration(new BookingEntityTypeConfiguration())
                .ApplyConfiguration(new LocationEntityTypeConfiguration())
                .ApplyConfiguration(new CarEntityTypeConfiguration())
                .ApplyConfiguration(new AdditionalFacilityEntityTypeConfiguration());

            modelBuilder.Seed();
        }
    }
}
