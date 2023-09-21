
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{ 
    public DepartamentoRepository(DotNetFarmaContext context) : base(context)
    {
    }
     public override async Task<(int totalRegistros,IEnumerable<Departamento> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Departamentos as IQueryable<Departamento>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Ciudades)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}