
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Repository;

public class MedicamentoCompraRepository : GenericRepository<MedicamentoCompra>, IMedicamentoCompra
{
    public MedicamentoCompraRepository(DotNetFarmaContext context) : base(context)
    { 
    }
    public override async Task
    <(
        int totalRegistros, 
        IEnumerable<MedicamentoCompra> registros
    )> 
    GetAllAsync
    (
        int pageIndex, 
        int pageSize, 
        string search
    )
    {
        var query = _context.MedicamentoCompras as IQueryable<MedicamentoCompra>;
        if(!string.IsNullOrEmpty(search))
        {
            // query = query.Where(x => x.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        return (totalRegistros, registros);
    }


    public async Task<List<MedicamentoCompraPorCompraH>> VerMedicamentoComprasFecha()
    {
        var registros = await  _context.MedicamentoCompras  
                        .Include(mc => mc.Compra)
                        .Include(c => c.Medicamento)
                        .Select( mc => new  MedicamentoCompraPorCompraH
                        {
                            MedicamentoCompraId = mc.MedicamentoCompraId,
                            CantidadComprada = mc.CantidadComprada,
                            PrecioCompra = mc.PrecioCompra,
                            FechaCompra = mc.Compra.FechaCompra,
                            NombreMedicamento = mc.Medicamento.Nombre,
                            MedicamentoId = mc.MedicamentoId,
                            

                        }).ToListAsync();




        return registros;
    }
}
