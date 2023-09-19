namespace Domain.Entities;

public class Rol 
{
    public int RolId { get; set; }
    public string NombreRol { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}