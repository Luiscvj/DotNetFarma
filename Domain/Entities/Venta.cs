
namespace Domain.Entities;

public class Venta
{
    public int VentaId { get; set; }
    public DateTime FechaVenta { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; }
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }
    public ICollection<MedicamentoVenta> MedicamentoVentas {get;set;}
}
