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
                .HasForeignKey<UserEntity>(u => u.RefreshTokenId);

            builder.Property(t => t.Token);

            builder.Property(t => t.CreationTime);

            builder.Property(t => t.IsRevoked);
        }
    }
}