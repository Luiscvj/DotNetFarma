
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(x => x.Nombre)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasOne(a => a.Departamento)
               .WithMany(e => e.Ciudades)
               .HasForeignKey(i => i.DepartamentoId)
               .IsRequired();
    }
}