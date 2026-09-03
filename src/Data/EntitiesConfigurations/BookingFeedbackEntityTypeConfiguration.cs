using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class BookingFeedbackEntityTypeConfiguration : IEntityTypeConfiguration<BookingFeedbackEntity>
    {
        public void Configure(EntityTypeBuilder<BookingFeedbackEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Rating)
                .IsRequired();

            builder.Property(b => b.Comment)
                .IsRequired();

            builder.HasOne(b => b.Booking)
                .WithOne(b => b.BookingFeedback)
                .HasForeignKey<BookingFeedbackEntity>(b => b.BookingId);

            builder.HasOne(b => b.User)
                .WithMany(u => u.BookingFeedbacks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Car)
                .WithMany(c => c.BookingFeedbacks)
                .HasForeignKey(b => b.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}