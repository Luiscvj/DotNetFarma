
namespace Domain.Entities;

public class Ciudad
{
    public int CiudadId { get; set; }
    public string Nombre { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}