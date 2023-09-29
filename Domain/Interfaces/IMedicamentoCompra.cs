
using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamentoCompra : IGenericRepository<MedicamentoCompra>
{

       Task<List<MedicamentoCompraPorCompraH>> VerMedicamentoComprasFecha();
}
