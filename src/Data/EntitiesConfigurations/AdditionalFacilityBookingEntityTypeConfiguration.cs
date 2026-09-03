using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class AdditionalFacilityBookingEntityTypeConfiguration : IEntityTypeConfiguration<AdditionalFacilityBookingEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityBookingEntity> builder)
        {
            builder.HasKey(b => new {b.AdditionalFacilityId, b.BookingId});

            builder.HasOne(b => b.Booking)
                .WithMany(b => b.AdditionalFacilityBookings)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.AdditionalFacility)
                .WithMany(b => b.AdditionalFacilityBookings)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}