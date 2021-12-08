using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class CarLockEntityTypeConfiguration : IEntityTypeConfiguration<CarLockEntity>
    {
        public void Configure(EntityTypeBuilder<CarLockEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .IsRequired();

            builder.Property(l => l.LockTime)
                .IsRequired();

            builder.HasOne(l => l.User)
                .WithOne(u => u.CarLockEntity)
                .HasForeignKey<CarLockEntity>(l => l.UserId);
            builder.Property(l => l.UserId)
                .IsRequired();

            builder.HasOne(l => l.Car)
                .WithOne(c => c.CarLockEntity)
                .HasForeignKey<CarLockEntity>(l => l.CarId);
            builder.Property(l => l.CarId)
                .IsRequired();
        }
    }
}