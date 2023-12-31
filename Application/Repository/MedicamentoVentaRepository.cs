
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class MedicamentoVentaRepository : GenericRepository<MedicamentoVenta>, IMedicamentoVenta
{
    public MedicamentoVentaRepository(DotNetFarmaContext context) : base(context)
    { 
    }
    public override async Task
    <(
        int totalRegistros, 
        IEnumerable<MedicamentoVenta> registros
    )> 
    GetAllAsync
    (
        int pageIndex, 
        int pageSize, 
        string search
    )
    {
        var query = _context.MedicamentoVentas as IQueryable<MedicamentoVenta>;
        if(!string.IsNullOrEmpty(search))
        {
            // query = query.Where(x => x.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<int> GetAllVentasMedicamentoById(int id)
    {
        return   _context.MedicamentoVentas.Count( medicamentoVenta => medicamentoVenta.MedicamentoId == id);
    }

    public async Task<MedicamentoVenta> GetByIdVenta(int id)
    {
          return await _context.MedicamentoVentas
                                 .Where(x => x.VentaId == id)
                                 .FirstAsync();
    }

    public async Task<dynamic> GetMedicamentosNoVendidos()
    {
         return await _context.Medicamentos
                                 .Where(medicamento =>
                                    !_context.MedicamentoVentas
                                 .Any(venta => venta.MedicamentoId == medicamento.MedicamentoId))
                                 .ToListAsync();
    }

    public async Task<decimal> GetTotalRecaudadoVentas()
    {
        return  _context.MedicamentoVentas.Sum(x =>x.PrecioVenta);
    }
}
