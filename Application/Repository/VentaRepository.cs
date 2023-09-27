
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{          
    public VentaRepository(DotNetFarmaContext context) : base(context)
    {
    }
     public override async Task<(int totalRegistros,IEnumerable<Venta> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Ventas as IQueryable<Venta>;
        if(!string.IsNullOrEmpty(search))
        {
            //query  = query.Where(p => p..ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                               
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }

    public async  Task<int> GetCountVentasMedicamentoByName(string Nombre)
    {
         Medicamento medicamento = await _context.Medicamentos.FirstOrDefaultAsync(medicamento => medicamento.Nombre.ToLower() == Nombre );
        if (medicamento == null ) return -1;
       

        int numeroMedicamentosVendidos = _context.MedicamentoVentas.Count(venta => venta.MedicamentoVentaId == medicamento.MedicamentoId);

        return numeroMedicamentosVendidos; 

       
    }

    public async  Task<dynamic> GetPromedioMedicamentosVendidos()
    {
        return await _context.Ventas
                .Select(venta => new
                {
                    Venta = venta,
                    CantidadMedicamentos = _context.MedicamentoVentas
                        .Where(medicamentoVenta => medicamentoVenta.VentaId == venta.VentaId)
                        .Sum(medicamentoVenta => medicamentoVenta.CantidadVendida)
                })
                .AverageAsync(resultado => resultado.CantidadMedicamentos);
    }

    public async Task<List<int>> GetVentasMarzo()
    {
       DateTime fechaInicio = new(2023, 03, 01);
            DateTime fechaLimite = new(2023, 03, 31);

            return await _context.Ventas
                                 .Where(x => x.FechaVenta >= fechaInicio && x.FechaVenta <= fechaLimite)
                                 .Select(x => x.VentaId)
                                 .ToListAsync();
    }
}
