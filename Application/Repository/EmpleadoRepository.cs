using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    public EmpleadoRepository(DotNetFarmaContext context) : base(context)
    { 
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





     public async Task<IEnumerable<Empleado>> EmpleadoConMenosDe5Ventas()
     {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

       var empleadosConMenosDe5Ventas = await _context.Empleados
        .Where(e => e.Ventas
        .Count(v => v.FechaVenta >= fechaInicial && v.FechaVenta <= fechaFinal) < 5)
        .ToListAsync();

        return empleadosConMenosDe5Ventas;
           


     }
}
