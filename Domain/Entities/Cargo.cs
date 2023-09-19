
namespace Domain.Entities;

public class Cargo
{
    public int CargoId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}
