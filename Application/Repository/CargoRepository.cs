using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargo
{
   
    public CargoRepository(DotNetFarmaContext context) : base(context)
    { 
    }
    public override async Task<(int totalRegistros,IEnumerable<Cargo> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
    {
        var query = _context.Cargos as IQueryable<Cargo>;
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
