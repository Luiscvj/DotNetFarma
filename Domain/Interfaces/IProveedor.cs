using Domain.Entities;

namespace Domain.Interfaces;

public interface IProveedor : IGenericRepository<Proveedor>
{
   Task<List<ProveedorMedicamentoCompraH>> GetCantidadMedicamentosVendidosProveedor();
   Task<IEnumerable<Proveedor>> ProveedoresMedicamentos50U();
   Task<List<Proveedor>> GetProveedores5MedicamentosDiferentes2023();
}