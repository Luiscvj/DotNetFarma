namespace API.Dtos.EmpleadoDto;
public class EmpleadoDto
{
    public int EmpleadoId { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaContratacion { get; set; }
};