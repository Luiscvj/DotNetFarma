
namespace Domain.Entities;

public class Empleado
{
    public int EmpleadoId { get; set; }
    public int CargoId { get; set; }
    public Cargo Cargo { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaContratacion { get; set; }
    public int CiudadId { get; set; }
    public Ciudad Ciudad { get; set; }
    public int ArlId { get; set; }
    public Arl Arl { get; set; }
    public int EpsId { get; set; }
    public Eps Eps { get; set; }
    public ICollection<Venta> Ventas { get; set; }
}
