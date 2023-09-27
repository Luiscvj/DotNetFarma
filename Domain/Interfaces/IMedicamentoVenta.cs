
using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamentoVenta : IGenericRepository<MedicamentoVenta>
{
    Task<int> GetAllVentasMedicamentoById(int id);
    Task<decimal> GetTotalRecaudadoVentas();
}
