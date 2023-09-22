namespace API.Dtos.MedicamentoDtos;

public class MedicamentoExpiracionDto
{
    public int MedicamentoId { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaExpiracion { get; set; }
}