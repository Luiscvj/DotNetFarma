using Domain.Entities;

namespace Domain.Interfaces;

public interface IProveedor : IGenericRepository<Proveedor>
{
   Task<List<ProveedorMedicamentoCompraH>> GetCantidadMedicamentosVendidosProveedor();
   Task<IEnumerable<Proveedor>> ProveedoresMedicamentos();
   Task<dynamic> GetTotalGananciaProveedor();
   Task<dynamic> GetProveedoresMasHanSuministrado();
   Task<List<Proveedor>> GetProveedoresSinVenderMedicamentosUltimoAño();
   Task<List<Proveedor>> GetProveedores5MedicamentosDiferentes2023();
   Task<IEnumerable<Proveedor>> ProveedoresMedicamentos50U();

}