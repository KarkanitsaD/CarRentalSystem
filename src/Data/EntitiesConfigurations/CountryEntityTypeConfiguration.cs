using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired();

            builder.HasAlternateKey(c => c.Title);
            builder.Property(c => c.Title)
                .IsRequired();

            builder.HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.RentalPointEntities)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId);
        }
    }
}