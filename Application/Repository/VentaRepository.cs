
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{ 
    public VentaRepository(DotNetFarmaContext context) : base(context)
    {
    }
     public override async Task<(int totalRegistros,IEnumerable<Venta> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Ventas as IQueryable<Venta>;
        if(!string.IsNullOrEmpty(search))
        {
            //query  = query.Where(p => p..ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                               
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}
