using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class CarPictureEntityTypeConfiguration : IEntityTypeConfiguration<CarPictureEntity>
    {
        public void Configure(EntityTypeBuilder<CarPictureEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.ShortName)
                .IsRequired();

            builder.Property(p => p.Extension)
                .IsRequired();

            builder.Property(p => p.Content)
                .IsRequired();

            builder.HasOne(p => p.Car)
                .WithOne(c => c.Picture)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}