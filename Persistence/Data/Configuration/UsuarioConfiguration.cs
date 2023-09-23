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

               builder.HasMany(x => x.Roles)
                   .WithMany(x => x.Usuarios)
                   .UsingEntity<UsuarioRoles>(
                   
                   j => j
                   .HasOne(pt => pt.Rol)
                   .WithMany(t => t.UsuarioRoles)
                   .HasForeignKey(ut => ut.RolId),

                   j => j
                   .HasOne(et => et.Usuario)
                   .WithMany(et => et.UsuarioRoles)
                   .HasForeignKey(el => el.UsuarioId),


                    j =>
                    
                    {
                         j. HasKey(t => new {t.RolId,t.UsuarioId});
                    }
                          
                   );  


                   builder.HasMany(x => x.RefreshTokens)
                          .WithOne( r => r.Usuario)
                          .HasForeignKey( x => x.UsuarioId);                       
        }
    }