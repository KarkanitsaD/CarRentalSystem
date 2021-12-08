﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Brand)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.FuelConsumptionPerHundredKilometers)
                .IsRequired();

            builder.Property(c => c.TransmissionType)
                .HasMaxLength(50);

            builder.Property(c => c.NumberOfSeats)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasMaxLength(50);

            builder.Property(c => c.PricePerDay)
                .IsRequired();

            builder.Property(c => c.Description);

            builder.HasOne(c => c.RentalPoint)
                .WithMany(r => r.Cars)
                .HasForeignKey(c => c.RentalPointId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CarLockEntity)
                .WithOne(l => l.Car)
                .HasForeignKey<CarLockEntity>(l => l.CarId);

            builder.Property(c => c.LastViewTime)
                .IsRequired();

            builder.HasMany(c => c.Bookings)
                .WithOne(o => o.Car)
                .HasForeignKey(c => c.CarId);

            builder.HasOne(c => c.Picture)
                .WithOne(p => p.Car)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}