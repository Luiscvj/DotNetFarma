
using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{

    Task<IEnumerable<Medicamento>> MedicamentoMas50();

    Task<List<MedicamentoInformacionProveedor>> MedicamentosInformacionProveedores();

    Task<IEnumerable<Medicamento>> MedicamentosPorProveedor(string NombreProveedor);

}
