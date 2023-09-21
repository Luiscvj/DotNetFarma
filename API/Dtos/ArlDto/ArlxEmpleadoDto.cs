
using API.Dtos.EmpleadoDto;

namespace API.Dtos.ArlDto;

public class ArlxEmpleadoDto
{
    public int ArlId { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public List<EmpleadoDtos> Empleados { get; set; }
}
