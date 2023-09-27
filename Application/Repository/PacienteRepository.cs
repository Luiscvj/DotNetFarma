
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class PacienteRepository : GenericRepository<Paciente>, IPaciente
{ 
    public PacienteRepository(DotNetFarmaContext context) : base(context)
    { 
    }
     public override async Task<(int totalRegistros,IEnumerable<Paciente> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Pacientes as IQueryable<Paciente>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Ventas)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }

    public async Task<List<Paciente>> PacientesParacetamol()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

        var pacientesParacetamol = await _context.Ventas
            .Where(v => v.FechaVenta >= fechaInicial && v.FechaVenta <= fechaFinal)
            .Join(_context.MedicamentoVentas,
                venta => venta.VentaId,
                medicamentoVenta => medicamentoVenta.VentaId,
                (venta, medicamentoVenta) => new { Venta = venta, MedicamentoVenta = medicamentoVenta })
            .Join(_context.Medicamentos,
                vm => vm.MedicamentoVenta.MedicamentoId,
                medicamento => medicamento.MedicamentoId,
                (vm, medicamento) => new { Venta = vm.Venta, Medicamento = medicamento })
            .Where(vm => vm.Medicamento.NombreMedicamento == "Paracetamol")
            .Select(vm => vm.Venta.Paciente)
            .Distinct()
            .ToListAsync();

        return pacientesParacetamol;
    }

    public async Task<List<Paciente>> PacientesSinComprasEn2023()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

        var pacientesConComprasEn2023 = await _context.Ventas
            .Where(c => c.FechaVenta >= fechaInicial && c.FechaVenta <= fechaFinal)
            .Select(c => c.Paciente)
            .Distinct()
            .ToListAsync();

        var todosLosPacientes = await _context.Pacientes.ToListAsync();

        var pacientesSinComprasEn2023 = todosLosPacientes.Except(pacientesConComprasEn2023).ToList();

        return pacientesSinComprasEn2023;
    }

    public async Task<Dictionary<string, decimal>> TotalGastadoPorPacienteEn2023()
    {
        var fechaInicial = new DateTime(2023, 1, 1);
        var fechaFinal = new DateTime(2023, 12, 31);

        var gastoPorPaciente = await _context.Ventas
            .Where(v => v.FechaVenta >= fechaInicial && v.FechaVenta <= fechaFinal)
            .GroupBy(v => v.Paciente.Nombre)
            .Select(g => new
            {
                Paciente = g.Key,
                TotalGastado = g.Sum(v => v.MedicamentoVentas.Sum(m => m.PrecioVenta))
            })
            .ToDictionaryAsync(g => g.Paciente, g => g.TotalGastado);

        return gastoPorPaciente;
    }


}
