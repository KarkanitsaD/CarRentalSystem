using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .IsRequired();

            builder.Property(b => b.CustomerName);

            builder.Property(b => b.CustomerSurname);

            builder.Property(b => b.CustomerEmail);

            builder.Property(b => b.PhoneNumber);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.RentalPoint)
                .WithMany(rp => rp.Bookings)
                .HasForeignKey(o => o.RentalPointId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Car)
                .WithMany(c => c.Bookings)
                .HasForeignKey(o => o.CarId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(o => o.KeyReceivingTime)
                .IsRequired();

            builder.Property(o => o.KeyHandOverTime)
                .IsRequired();

            builder.Property(o => o.BookingTime)
                .IsRequired();
        }
    }
}