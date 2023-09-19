
namespace Domain.Entities;

public class Departamento
{
    public int DepartamentoId { get; set; }
    public string Nombre { get; set; }
    public int PaisId { get; set; }
    public Pais Pais { get; set; }
    public ICollection<Ciudad> Ciudades { get; set; }
}