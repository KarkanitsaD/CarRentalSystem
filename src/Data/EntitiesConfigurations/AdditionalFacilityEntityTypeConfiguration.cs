using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class AdditionalFacilityEntityTypeConfiguration : IEntityTypeConfiguration<AdditionalFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityEntity> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasMany(s => s.Bookings)
                .WithMany(o => o.AdditionalFacilities);
        }
    }
}