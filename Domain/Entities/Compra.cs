
namespace Domain.Entities;

public class Compra
{
    public int CompraId { get; set; }
    public DateTime FechaCompra { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }

    public List<MedicamentoCompra> MedicamentoCompras {get;set;}
    
}