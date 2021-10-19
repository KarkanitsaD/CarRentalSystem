using Data.Models;
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

            builder.HasOne(rp => rp.Location)
                .WithOne(l => l.RentalPoint)
                .HasForeignKey<RentalPointEntity>(rp => rp.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.Orders)
                .WithOne(o => o.RentalPoint)
                .HasForeignKey(o => o.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(rp => rp.Cars)
                .WithOne(c => c.RentalPoint)
                .HasForeignKey(c => c.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
