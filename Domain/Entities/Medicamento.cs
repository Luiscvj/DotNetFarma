
namespace Domain.Entities;

public class Medicamento
{
    public int MedicamentoId { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public ICollection<Compra> Compras { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<MedicamentoCompra> MedicamentoCompras { get; set; }
    public List<MedicamentoVenta> MedicamentoVentas {get;set;}
}
