
using Domain.Entities;

namespace Domain.Interfaces;

public interface IVenta : IGenericRepository<Venta>
{
    Task<int> GetCountVentasMedicamentoByName(string Nombre);
    Task<List<int>> GetVentasMarzo();  
    Task<dynamic> GetPromedioMedicamentosVendidos();
}
