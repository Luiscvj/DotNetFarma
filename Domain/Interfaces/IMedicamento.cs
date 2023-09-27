
using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{

    Task<IEnumerable<Medicamento>> MedicamentoMas50();

    Task<List<MedicamentoInformacionProveedorH>> MedicamentosInformacionProveedores();

    Task<IEnumerable<Medicamento>> MedicamentosPorProveedor(string NombreProveedor);

    Task<IEnumerable<Medicamento>> MedicamentosNoVendidos();

    Task<Medicamento> MedicamentoMasCaro();

    Task<int>  NumeroMedicamentosPorProveedor(int idProveedor);
    Task<List<Medicamento>> GetExpiran2024();
    Task<dynamic> GetPacientesCompraronParacetamol();
    Task<dynamic> GetMedicamentoMenosVendido();
    Task<dynamic> GetTotalMedicamentosVendidosxMes();

}
