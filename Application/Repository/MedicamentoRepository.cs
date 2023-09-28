
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

    public async Task<Medicamento> MedicamentoMasCaro()
    {
        double precio = _context.Medicamentos.Max(x => x.Precio);
       return  await _context.Medicamentos.FirstOrDefaultAsync( x => x.Precio == precio);
    }

    public async Task<int> NumeroMedicamentosPorProveedor(int idProveedor)
    {
           var  num =  from i in _context.Medicamentos
                    where i.ProveedorId == idProveedor
                    select i.MedicamentoId;
                    
           return   num.Count();    
    }

    public async Task<List<Medicamento>> GetExpiran2024()
    {
        DateTime fechaInicial = new(2024, 01, 01);
            DateTime fechaLimite = new(2024, 12, 31);

            return await _context.Medicamentos 
                                 .Where(x => x.FechaExpiracion > fechaInicial && x.FechaExpiracion <= fechaLimite)
                                 .ToListAsync();
    }

    public async  Task<dynamic> GetPacientesCompraronParacetamol()
    {
         int yearToFilter = 2023; // Año que deseas filtrar
            string medicamentoNombre = "paracetamol";

            return await _context.Pacientes
            .Where(paciente =>
                _context.Ventas
                    .Any(venta =>
                        venta.PacienteId == paciente.PacienteId &&
                        venta.FechaVenta.Year == yearToFilter &&
                        _context.MedicamentoVentas
                            .Any(medicamentoVenta =>
                                medicamentoVenta.VentaId == venta.VentaId &&
                                _context.Medicamentos
                                    .Any(medicamento =>
                                        medicamentoVenta.MedicamentoId == medicamento.MedicamentoId &&
                                        medicamento.NombreMedicamento.ToLower() == medicamentoNombre))))
            .ToListAsync();
    }

    public async Task<dynamic> GetMedicamentoMenosVendido()
    {
        int yearToFilter = 2023;

            return await _context.Medicamentos
                .GroupJoin(
                    _context.MedicamentoVentas
                        .Where(medicamentoVenta => medicamentoVenta.Venta.FechaVenta.Year == yearToFilter), // Filtra las ventas por el año 2023
                    medicamento => medicamento.MedicamentoId,
                    medicamentoVenta => medicamentoVenta.MedicamentoId,
                    (medicamento, ventas) => new
                    {
                        Medicamento = medicamento,
                        CantidadVentas = ventas.Count()
                    })
                .OrderBy(resultado => resultado.CantidadVentas)
                .FirstOrDefaultAsync();
    }

    public async Task<dynamic> GetTotalMedicamentosVendidosxMes()
    {
        int yearToFilter = 2023;

            var medicamentosVendidosPorMesEn2023 = Enumerable.Range(1, 12)
                .Select(month => new
                {
                    Mes = month,
                    TotalMedicamentosVendidos = _context.Ventas
                        .Where(venta => venta.FechaVenta.Year == yearToFilter && venta.FechaVenta.Month == month)
                        .Join(
                            _context.MedicamentoVentas,
                            venta => venta.VentaId,
                            medicamentoVenta => medicamentoVenta.VentaId,
                            (venta, medicamentoVenta) => medicamentoVenta.CantidadVendida)
                        .Sum()
                })
                .ToList();

            return medicamentosVendidosPorMesEn2023;
    }

    public Task<int> TotalMedicamentosVendidosPrimerTrimestre()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<int, List<Medicamento>>> GetMedicamentosVendidosPorMes2023()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<int, int>> GetTotalMedicamentosVendidosPorMes2023()
    {
        throw new NotImplementedException();
    }
}
