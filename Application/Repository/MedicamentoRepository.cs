
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    public MedicamentoRepository(DotNetFarmaContext context) : base(context)
    { 
    }

    public  async Task<IEnumerable<Medicamento>> MedicamentoMas50()
    {
        return  await _context.Medicamentos.Where(medicamento => medicamento.Stock < 50).ToListAsync();
    }
    /*  public override async Task<(int totalRegistros,IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
{
   var query = _context.Medicamentos as IQueryable<Medicamento>;
   if(!string.IsNullOrEmpty(search))
   {
       query  = query.Where(p => p.Nombre.ToLower().Contains(search));
   }

   var totalRegistros = await query.CountAsync();
   var registros = await query
                           .Skip((pageIndex-1)*pageSize)
                           .Take(pageSize)
                           .ToListAsync();
   return ( totalRegistros, registros);
} */


}
