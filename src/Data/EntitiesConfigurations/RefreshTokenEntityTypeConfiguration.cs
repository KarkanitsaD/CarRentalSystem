using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfigurations
{
    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithOne(u => u.RefreshToken)
                .HasForeignKey<RefreshTokenEntity>(t => t.UserId);
            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.Token)
                .IsRequired();

            builder.Property(t => t.ExpirationTime)
                .IsRequired();
        }
    }
}