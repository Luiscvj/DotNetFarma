using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;


public class PaisRepository : GenericRepository<Pais>, IPais
{
    private  readonly DotNetFarmaContext _context;
    public PaisRepository(DotNetFarmaContext context) : base(context)
    {
        _context = context;
    }

      public override async Task<(int totalRegistros,IEnumerable<Pais> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Paises as IQueryable<Pais>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Departamentos)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }

}