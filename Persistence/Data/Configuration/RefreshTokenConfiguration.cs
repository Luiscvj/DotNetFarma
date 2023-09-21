using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
                // Configure entity here
                builder.ToTable("refresh_token");

                builder.Property(x => x.Token)
                       .IsRequired();

                builder.Property(x => x.IsExpired)
                       .IsRequired();

                builder.Property(x => x.FechaExpiracion)
                       .HasColumnType("datetime")
                       .IsRequired();

                builder.Property(x => x.Revocado)
                       .IsRequired();

                builder.Property(x => x.IsActive)
                       .IsRequired();

                builder.HasOne(x => x.Usuario)
                       .WithMany(x => x.RefreshTokens)
                       .HasForeignKey(x => x.UsuarioId);
        }
    }