namespace API.Dtos.EmpleadoDtos;

public class EmpleadoDto
{
    public int EmpleadoId { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaContratacion { get; set; }
    public int ArlId { get; set; }
    public int EpsId { get; set; }
    public int CargoId { get; set; }
    public int CiudadId { get; set; }
};
