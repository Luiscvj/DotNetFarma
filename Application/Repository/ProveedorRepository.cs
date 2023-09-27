
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{               
    public ProveedorRepository(DotNetFarmaContext context) : base(context)
    { 
    }
     public override async Task<(int totalRegistros,IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Proveedores as IQueryable<Proveedor>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Medicamentos)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }


     public async Task<List<ProveedorMedicamentoCompraH>> GetCantidadMedicamentosVendidosProveedor()
     {
        List<ProveedorMedicamentoCompraH> ListaProveedorMedicamentoCompraH = new List<ProveedorMedicamentoCompraH>();
        IEnumerable<Proveedor> proveedor = await _context.Proveedores.Include(x => x.Compras)
                                                                     .ThenInclude(x =>x.MedicamentoCompras)
                                                                     .ToListAsync(); 
            
        foreach (Proveedor pro in  proveedor)
        {
            int cantidadVendido = pro.Compras
                                 .SelectMany(compra => compra.MedicamentoCompras)
                                 .Sum(medicamentoCompra => medicamentoCompra.CantidadComprada);



         ProveedorMedicamentoCompraH proveedorMedicamentoCompraHs = new ProveedorMedicamentoCompraH()
         {
            ProveedorId = pro.ProveedorId,
            NombreProveedor = pro.Nombre,
            MedicamentoVendido = cantidadVendido
         };

         ListaProveedorMedicamentoCompraH.Add(proveedorMedicamentoCompraHs);
                                 
        }
        return ListaProveedorMedicamentoCompraH;
     }

    public async Task<IEnumerable<Proveedor>> ProveedoresMedicamentos50U()
     {
        var proveedor = await  _context.Proveedores.Where(e => e.Medicamentos.Any(medicamento => medicamento.Stock <50)).ToListAsync(); 

        return proveedor;
     }

     public async Task<List<Proveedor>> GetProveedores5MedicamentosDiferentes2023()
   {
      var fechaInicial = new DateTime(2023, 1, 1);
      var fechaFinal = new DateTime(2023, 12, 31);

      var proveedoresCon5MedicamentosDiferentes = _context.Proveedores
         .Where(p =>
            p.Compras
                  .Where(c =>
                     c.FechaCompra >= fechaInicial && c.FechaCompra <= fechaFinal)
                  .SelectMany(c => c.MedicamentoCompras)
                  .Select(mc => mc.MedicamentoId)
                  .Distinct()
                  .Count() >= 5)
         .ToList();

      return proveedoresCon5MedicamentosDiferentes;

   }

   /* public async Task<List<Proveedor>> GetProveedores5MedicamentosDiferentes2023()
{
    var fechaInicial = new DateTime(2023, 1, 1);
    var fechaFinal = new DateTime(2023, 12, 31);

    var proveedores = await _context.Proveedores
        .Where(p =>
            p.Compras
                .Where(c =>
                    c.FechaCompra >= fechaInicial && c.FechaCompra <= fechaFinal)
                .SelectMany(c => c.MedicamentoCompras)
                .GroupBy(mc => mc.MedicamentoId) // Agrupa por ID del medicamento
                .Where(group => group.Count() >= 5) // Filtra grupos con al menos 5 elementos
                .Any()) // Verifica si hay al menos un grupo con 5 elementos
        .ToListAsync();

    return proveedores;
}
 */


}
