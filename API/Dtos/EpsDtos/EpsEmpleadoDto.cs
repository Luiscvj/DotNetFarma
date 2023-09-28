using API.Dtos.EmpleadoDtos;

namespace API.Dtos.EpsDtos;

 public class EpsEmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public ICollection<EmpleadoDto> Empleados { get; set; }
    }