
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    public MedicamentoRepository(DotNetFarmaContext context) : base(context)
    { 
    }

    public  async Task<IEnumerable<Medicamento>> MedicamentoMas50()
    {
        return  await _context.Medicamentos.Where(medicamento => medicamento.Stock < 50).ToListAsync();
    }

    public  async  Task<List<MedicamentoInformacionProveedorH>> MedicamentosInformacionProveedores()
    {
        IEnumerable<Medicamento> medicamentos = await _context.Medicamentos.ToListAsync();
        IEnumerable<Proveedor> proveedores = from i in _context.Proveedores
                                             select   i;
      var unionMedicamentosProveedores =  medicamentos.Join(proveedores ,m => m.ProveedorId, p => p.ProveedorId,(m,p)=> new MedicamentoInformacionProveedorH
      {
        MedicamentoId = m.MedicamentoId,
        NombreMedicamento = m.NombreMedicamento,
        ProveedorNombre = p.Nombre,
        ProveedorTelefono = p.Telefono

        
        
      }).ToList();  

      return unionMedicamentosProveedores;

                          
     



      

    }

      public async Task<IEnumerable<Medicamento>> MedicamentosPorProveedor(string NombreProveedor)
    {
        Proveedor proveedorBuscado = await _context.Proveedores.FirstOrDefaultAsync( proveedor => proveedor.Nombre.ToLower() == NombreProveedor.ToLower());

        IEnumerable<Medicamento> medicamentosPorProveedor = await _context.Medicamentos.Where(medicamento => medicamento.ProveedorId == proveedorBuscado.ProveedorId).ToListAsync();


        return medicamentosPorProveedor;
    }

   




    public override async Task<(int totalRegistros,IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
    {
            var query = _context.Medicamentos as IQueryable<Medicamento>;
            if(!string.IsNullOrEmpty(search))
            {
            query  = query.Where(p => p.NombreMedicamento.ToLower().Contains(search));
            }

            var totalRegistros = await query.CountAsync();
            var registros = await query
                            .Skip((pageIndex-1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            return ( totalRegistros, registros);
    }


    public async Task<List<Medicamento>> GetMedicamentosPrecioMayorA50YStockMenorA100()
    {
        var medicamentos = await _context.Medicamentos
            .Where(medicamento => medicamento.Precio > 50 && medicamento.Stock < 100)
            .ToListAsync();

        return medicamentos;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosNoVendidos()
    {
        var medicamentosNoVendidos = await _context.Medicamentos
            .Where(medicamento => !_context.MedicamentoVentas
                .Any(venta => venta.MedicamentoId == medicamento.MedicamentoId &&
                            venta.Venta.FechaVenta.Year == 2023))
            .ToListAsync();

        return medicamentosNoVendidos;
    }

    public async Task<int> TotalMedicamentosVendidosPrimerTrimestre()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 3, 31);

        var totalMedicamentosPrimerTrimestre = await _context.MedicamentoVentas
            .Where(mv => mv.Venta.FechaVenta >= fechaInicial && mv.Venta.FechaVenta <= fechaFinal)
            .SumAsync(mv => mv.CantidadVendida);

        return totalMedicamentosPrimerTrimestre;
    }


    public async Task<Dictionary<int, List<Medicamento>>> GetMedicamentosVendidosPorMes2023()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

        var medicamentosVendidosPorMes = await _context.MedicamentoVentas
            .Where(mv => mv.Venta.FechaVenta >= fechaInicial && mv.Venta.FechaVenta <= fechaFinal)
            .GroupBy(mv => new { mv.MedicamentoId, mv.Venta.FechaVenta.Year, mv.Venta.FechaVenta.Month })
            .Select(group => new
            {
                MedicamentoId = group.Key.MedicamentoId,
                Year = group.Key.Year,
                Month = group.Key.Month
            })
            .Where(v => v.Year == 2023)
            .ToListAsync();

        // Crear un diccionario donde las claves son los meses y los valores son las listas de medicamentos vendidos
        var medicamentosPorMes = new Dictionary<int, List<Medicamento>>();

        for (int mes = 1; mes <= 12; mes++)
        {
            var medicamentoIdsMes = medicamentosVendidosPorMes
                .Where(v => v.Month == mes)
                .Select(v => v.MedicamentoId)
                .ToList();

            var medicamentosMes = await _context.Medicamentos
                .Where(m => medicamentoIdsMes.Contains(m.MedicamentoId))
                .ToListAsync();

            medicamentosPorMes.Add(mes, medicamentosMes);
        }

        return medicamentosPorMes;
    }

    public async Task<Dictionary<int, int>> GetTotalMedicamentosVendidosPorMes2023()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

        var totalMedicamentosPorMes = await _context.MedicamentoVentas
            .Where(mv => mv.Venta.FechaVenta >= fechaInicial && mv.Venta.FechaVenta <= fechaFinal)
            .GroupBy(mv => new { mv.Venta.FechaVenta.Month })
            .Select(group => new
            {
                Month = group.Key.Month,
                TotalVentas = group.Sum(mv => mv.CantidadVendida)
            })
            .ToListAsync();

        // Crear un diccionario donde las claves son los meses (del 1 al 12) y los valores son los totales de medicamentos vendidos
        var totalMedicamentosPorMesDict = new Dictionary<int, int>();

        // Rellenar el diccionario con todos los meses del 1 al 12
        for (int mes = 1; mes <= 12; mes++)
        {
            var mesEncontrado = totalMedicamentosPorMes.FirstOrDefault(item => item.Month == mes);
            totalMedicamentosPorMesDict[mes] = mesEncontrado != null ? mesEncontrado.TotalVentas : 0;
        }

        return totalMedicamentosPorMesDict;
    }

}
