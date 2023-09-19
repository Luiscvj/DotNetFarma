using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Configure entity here
               builder.ToTable("usuario");
                 /* public int UsuarioId { get; set; }
    public string Username   { get; set; }
    public string Email  { get; set; }
    public string Password { get; set; }
    public int RolId { get; set; }
    public Rol  Rol { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }  */
               builder.Property(x => x.Username)
                       .HasMaxLength(200)
                       .IsRequired();

               builder.Property(x => x.Email)
                       .HasMaxLength(200)
                       .IsRequired();

               builder.Property(x => x.Password)
                       .HasMaxLength(255)
                       .IsRequired();
                  
               builder.HasIndex(e => e.Username).IsUnique();//Sirve para verificar que  el mismo usuario no este duplicado
               builder.HasIndex(e => e.Email).IsUnique();

               builder.HasOne(u => u.Rol)
                      .WithMany(r => r.Usuarios)
                      .HasForeignKey(u => u.RolId);
                
               
             
                       
                       
               

               
                             
        }
    }