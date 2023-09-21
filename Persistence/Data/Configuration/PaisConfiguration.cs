using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            // Configure entity here
            builder.ToTable("pais");
               
            builder.Property(x => x.Nombre)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }