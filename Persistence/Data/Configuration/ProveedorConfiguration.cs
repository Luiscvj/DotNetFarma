using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {

  
               builder.ToTable("proveedor");

               builder.Property(x => x.Nombre)
                       .HasMaxLength(100);

               builder.Property(x => x.Telefono)
                        .HasMaxLength(20);
               builder.Property(x => x.Email)
                       .HasMaxLength(120);
               
               
                
               

        }
    }