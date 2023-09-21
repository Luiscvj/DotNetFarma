using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class CompraRepository : GenericRepository<Compra>, ICompra
{
    public CompraRepository(DotNetFarmaContext context) : base(context)
    {
    }

     public override async Task<(int totalRegistros,IEnumerable<Compra> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Compras as IQueryable<Compra>;
        if(!string.IsNullOrEmpty(search))
        {
            //query  = query.Where(p => p.FechaCompra.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}
