
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ArlRepository : GenericRepository<Arl>, IArl
{
    public ArlRepository(DotNetFarmaContext context) : base(context)
    {
    }
    public override async Task<(int totalRegistros,IEnumerable<Arl> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
    {
        var query = _context.Arls as IQueryable<Arl>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Empleados)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
    }
}
