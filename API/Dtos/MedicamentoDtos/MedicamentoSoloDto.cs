using API.Dtos.VentaDtos;

namespace API.Dtos.MedicamentoDtos;

public class MedicamentoSoloDto
{
    public string NombreMedicamento { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaExpiracion { get; set; }
}