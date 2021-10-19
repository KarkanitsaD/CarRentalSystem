using Data.Models;
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
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<AdditionalServiceEntity> AdditionalServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new RoleEntityTypeConfiguration())
                .ApplyConfiguration(new RentalTimeSpanEntityTypeConfiguration())
                .ApplyConfiguration(new RentalPointEntityTypeConfiguration())
                .ApplyConfiguration(new OrderEntityTypeConfiguration())
                .ApplyConfiguration(new LocationEntityTypeConfiguration())
                .ApplyConfiguration(new CarEntityTypeConfiguration())
                .ApplyConfiguration(new AdditionalServiceEntityTypeConfiguration());
        }
    }
}
