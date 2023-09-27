
namespace Domain.Entities;

public class Medicamento
{
    public readonly DateTime FechaVenta;

    public int MedicamentoId { get; set; }
    public string NombreMedicamento { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public ICollection<MedicamentoCompra> MedicamentoCompras { get; set; }
    public ICollection<MedicamentoVenta> MedicamentoVentas {get;set;}
}
