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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new RoleEntityTypeConfiguration())
                .ApplyConfiguration(new RentalPointEntityTypeConfiguration())
                .ApplyConfiguration(new BookingEntityTypeConfiguration())
                .ApplyConfiguration(new CarEntityTypeConfiguration())
                .ApplyConfiguration(new CityEntityTypeConfiguration())
                .ApplyConfiguration(new CountryEntityTypeConfiguration());
        }
    }
}