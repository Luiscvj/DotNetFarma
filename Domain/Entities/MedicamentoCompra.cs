namespace Domain.Entities;



public class MedicamentoCompra
{
    public int MedicamentoCompraId { get; set; }
    public int CantidadComprada { get; set; }
    public decimal PrecioCompra { get; set; }
    public int CompraId { get; set; }
    public Compra Compra { get; set; }
    public int MedicamentoId { get; set; }
    public Medicamento Medicamento { get; set; }

    
}