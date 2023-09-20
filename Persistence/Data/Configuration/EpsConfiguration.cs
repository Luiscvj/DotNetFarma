
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EpsConfiguration : IEntityTypeConfiguration<Eps>
{
    public void Configure(EntityTypeBuilder<Eps> builder)
    {
        builder.ToTable("eps");

        builder.Property(x => x.Nombre)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Telefono)
               .HasMaxLength(20)
               .IsRequired();  

        builder.Property(x => x.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Direccion)
               .IsRequired();
    }
}
