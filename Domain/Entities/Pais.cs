
namespace Domain.Entities;

public class Pais
{
    public int PaisId { get; set; }
    public string Nombre { get; set; }
    public ICollection<Departamento> Departamentos { get; set; }   
}
