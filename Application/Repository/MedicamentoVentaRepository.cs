
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

    public async Task<decimal> GetTotalRecaudadoVentas()
    {
        return  _context.MedicamentoVentas.Sum(x =>x.PrecioVenta);
    }

    public async Task<IEnumerable<MedicamentoVenta>> GetMedicamentosNoVendidos()
    {
        var medicamentos = await (
            from medicamentoVenta in _context.MedicamentoVentas
            where medicamentoVenta.CantidadVendida == 0
            select medicamentoVenta
        ).ToListAsync();

        return medicamentos;
    }

}
