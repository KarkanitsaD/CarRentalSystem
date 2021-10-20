using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.RentalPoint)
                .WithMany(rp => rp.Orders)
                .HasForeignKey(o => o.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Car)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CarId);

            builder.Property(o => o.KeyReceivingTime)
                .IsRequired();

            builder.Property(o => o.KeyHandOverTime)
                .IsRequired();

            builder.Property(o => o.OrderTime)
                .IsRequired();
        }
    }
}
