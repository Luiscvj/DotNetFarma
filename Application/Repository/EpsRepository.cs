
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EpsRepository : GenericRepository<Eps>, IEps
{ private readonly DotNetFarmaContext _context;
    public EpsRepository(DotNetFarmaContext context) : base(context)
    {
        _context = context;
    }
     public override async Task<(int totalRegistros,IEnumerable<Eps> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Epss as IQueryable<Eps>;
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
