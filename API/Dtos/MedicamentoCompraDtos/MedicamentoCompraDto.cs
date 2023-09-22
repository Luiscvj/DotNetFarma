namespace API.Dtos.MedicamentoCompraDtos;

public class MedicamentoCompraDto
{
    public int CantidadComprada { get; set; }
    public decimal PrecioCompra { get; set; }
    public int CompraId { get; set; }
    public int MedicamentoId { get; set; }
}