
using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{
    Task<IEnumerable<Medicamento>> MedicamentoMas50();
    Task<List<MedicamentoInformacionProveedorH>> MedicamentosInformacionProveedores();
    Task<IEnumerable<Medicamento>> MedicamentosPorProveedor(string NombreProveedor);
    Task<List<Medicamento>> GetMedicamentosPrecioMayorA50YStockMenorA100();
    Task<IEnumerable<Medicamento>> MedicamentosNoVendidos();
    /* Task<List<Medicamento>> TotalMedicamentosVendidosPorMes(); */
    Task<int> TotalMedicamentosVendidosPrimerTrimestre();
    Task<Dictionary<int, List<Medicamento>>> GetMedicamentosVendidosPorMes2023();
    Task<Dictionary<int, int>> GetTotalMedicamentosVendidosPorMes2023();

    Task<Medicamento> MedicamentoMasCaro();

    Task<int>  NumeroMedicamentosPorProveedor(int idProveedor);
    Task<List<Medicamento>> GetExpiran2024();
    Task<dynamic> GetPacientesCompraronParacetamol();
    Task<dynamic> GetMedicamentoMenosVendido();
    Task<dynamic> GetTotalMedicamentosVendidosxMes();

}
