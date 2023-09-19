
namespace Domain.Entities;

public class Eps
{
    public int EpsId { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}
