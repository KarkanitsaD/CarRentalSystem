using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.Property(c => c.TimeOffset);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.RentalPointEntities)
                .WithOne(r => r.City)
                .HasForeignKey(r => r.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}