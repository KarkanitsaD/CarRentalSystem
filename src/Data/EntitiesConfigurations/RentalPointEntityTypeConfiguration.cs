using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class RentalPointEntityTypeConfiguration : IEntityTypeConfiguration<RentalPointEntity>
    {
        public void Configure(EntityTypeBuilder<RentalPointEntity> builder)
        {
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.Id)
                .IsRequired();

            builder.Property(rp => rp.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(rp => rp.Address)
                .IsRequired(false);

            builder.Property(rp => rp.LocationX)
                .IsRequired(false);
            builder.Property(rp => rp.LocationY)
                .IsRequired(false);

            builder.HasOne(rp => rp.City)
                .WithMany(c => c.RentalPointEntities)
                .HasForeignKey(rp => rp.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rp => rp.Country)
                .WithMany(c => c.RentalPoints)
                .HasForeignKey(rp => rp.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.Bookings)
                .WithOne(o => o.RentalPoint)
                .HasForeignKey(o => o.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(rp => rp.Cars)
                .WithOne(c => c.RentalPoint)
                .HasForeignKey(c => c.RentalPointId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}