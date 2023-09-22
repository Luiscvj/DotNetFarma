
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

    
}
