namespace API.Dtos.MedicamentoVentaDtos;


public class MedicamentoVentaDto
{
    public int CantidadVendida { get; set; }
    public decimal PrecioVenta { get; set; }
    public int VentaId { get; set; }
    public int MedicamentoId { get; set; }
    public DateTime FechaVenta { get; set; }
}