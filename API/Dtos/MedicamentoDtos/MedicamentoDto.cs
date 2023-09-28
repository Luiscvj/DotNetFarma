namespace API.Dtos.MedicamentoDtos;

public class MedicamentoDto
{   
    public int MedicamentoId { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public int ProveedorId { get; set; }
    public DateTime FechaExpiracion { get; set; }
}