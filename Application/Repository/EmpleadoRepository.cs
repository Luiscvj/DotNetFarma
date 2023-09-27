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

    public async Task<List<Empleado>> GetEmpleadosConMayorCantidadMedicamentosEn2023()
    {
        var empleadosConMayorCantidad = await _context.Ventas
            .Where(venta => venta.FechaVenta.Year == 2023)
            .GroupBy(venta => venta.EmpleadoId)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .ToListAsync();

        if (empleadosConMayorCantidad == null || !empleadosConMayorCantidad.Any())
        {
            return new List<Empleado>(); // Devolver una lista vacía si no se encontraron empleados.
        }

        // Obtener la lista de empleados correspondientes a los IDs encontrados.
        var empleados = await _context.Empleados
            .Where(e => empleadosConMayorCantidad.Contains(e.EmpleadoId))
            .ToListAsync();

        return empleados;
    }

    public async Task<List<Empleado>> EmpleadosSinVentasAbril()
    {
        var fechaInicial = new DateTime(2023, 4, 1); // 1 de abril de 2023
        var fechaFinal = new DateTime(2023, 4, 30); // 30 de abril de 2023

        var empleadosSinVentasAbril = await _context.Empleados
            .Where(e => e.Ventas
                .All(v => v.FechaVenta < fechaInicial || v.FechaVenta > fechaFinal))
            .ToListAsync();

        return empleadosSinVentasAbril;
    }
}
