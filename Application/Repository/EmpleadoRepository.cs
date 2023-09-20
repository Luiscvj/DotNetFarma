using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly DotNetFarmaContext _context;
    public EmpleadoRepository(DotNetFarmaContext context) : base(context)
    {
        _context =  context;
    }

     public override async Task<(int totalRegistros,IEnumerable<Empleado> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Empleados as IQueryable<Empleado>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombres.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}
