using API.Dtos.EmpleadoDtos;

namespace API.Dtos.CiudadDtos;
public class CiudadEmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public List<EmpleadoDto> Empleados { get; set; }
    }