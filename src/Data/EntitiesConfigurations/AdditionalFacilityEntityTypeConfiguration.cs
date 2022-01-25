using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class AdditionalFacilityEntityTypeConfiguration : IEntityTypeConfiguration<AdditionalFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();

            builder.Property(b => b.Title)
                .IsRequired();

            builder.HasOne(b => b.RentalPoint)
                .WithMany(p => p.AdditionalFacilities)
                .HasForeignKey(b => b.RentalPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}