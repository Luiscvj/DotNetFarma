namespace Domain.Entities;

public class MedicamentoVenta
{
    public int MedicamentoVentaId { get; set; }
    public int CantidadVendida { get; set; }
    public decimal PrecioVenta { get; set; }
    public int VentaId { get; set; }
    public Venta Venta { get; set; }
    public int MedicamentoId { get; set; }
    public Medicamento Medicamento { get; set; }
}