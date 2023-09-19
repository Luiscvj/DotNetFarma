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
/* 
    public int TokenId { get; set; }
    public string Token { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaExpiracion { get; set; }
    public bool Revocado { get; set; } */

    builder.Property(x => x.TokenId)
            .IsRequired();

    builder.Property(x => x.FechaCreacion)
            .HasColumnType("timestamp");//Posible a cambio
    builder.Property(x => x.FechaExpiracion)
            .HasColumnType("date");
    builder.Property(x => x.Revocado)
            .HasColumnType("date");
    builder.Property(x => x.IsActive)
            .HasColumnType("boolean");
    builder.Property(x => x.IsExpired)
            .HasColumnType("boolean");
    builder.HasOne(x => x.Usuario)
        .WithMany(x => x.RefreshTokens)
        .HasForeignKey(x => x.UsuarioId);
    
  
    
    
    
    
    
    
    




        }
    }