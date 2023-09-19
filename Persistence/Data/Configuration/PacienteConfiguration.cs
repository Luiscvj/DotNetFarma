using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            // Configure entity here
               builder.ToTable("paciente");
  /* public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public ICollection<Venta> Ventas { get; set; } */
               builder.Property(x => x.Nombre)
                       .HasMaxLength(50);
               builder.Property(x => x.Apellidos)
                       .HasMaxLength(100);
              builder.Property(x => x.Telefono)
                      .HasMaxLength(20);
              
               
               
        }
    }