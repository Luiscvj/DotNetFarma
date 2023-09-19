
namespace Domain.Entities;

public class Paciente
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public ICollection<Venta> Ventas { get; set; }
}
