namespace API.Dtos.MedicamentoDtos;

public class MedicamentoDto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public int ProveedorId { get; set; }
}