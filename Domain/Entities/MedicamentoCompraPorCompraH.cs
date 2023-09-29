namespace Domain.Entities;


public class MedicamentoCompraPorCompraH
{

    public int MedicamentoCompraId { get; set; }
    public int CantidadComprada { get; set; }
    public decimal PrecioCompra { get; set; }
    public DateTime  FechaCompra { get; set; }
    public string  NombreMedicamento { get; set; }
    public int  MedicamentoId { get; set; }
                            
}