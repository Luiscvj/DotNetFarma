
using API.Dtos.EmpleadoDtos;

namespace API.Dtos.ArlDto;

public class ArlxEmpleadoDto
{
    public int ArlId { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public List<EmpleadoDto> Empleados { get; set; }
}
