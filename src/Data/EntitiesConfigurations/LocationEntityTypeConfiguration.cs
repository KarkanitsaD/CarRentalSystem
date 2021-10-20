using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .IsRequired();

            builder.Property(l => l.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(l => l.RentalPoint)
                .WithOne(rp => rp.Location)
                .HasForeignKey<LocationEntity>(l => l.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
