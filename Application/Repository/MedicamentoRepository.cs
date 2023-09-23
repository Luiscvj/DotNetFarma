
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

    public  async  Task<List<MedicamentoInformacionProveedorH>> MedicamentosInformacionProveedores()
    {
        IEnumerable<Medicamento> medicamentos = await _context.Medicamentos.ToListAsync();
        IEnumerable<Proveedor> proveedores = from i in _context.Proveedores
                                             select   i;
      var unionMedicamentosProveedores =  medicamentos.Join(proveedores ,m => m.ProveedorId, p => p.ProveedorId,(m,p)=> new MedicamentoInformacionProveedorH
      {
        MedicamentoId = m.MedicamentoId,
        NombreMedicamento = m.Nombre,
        ProveedorNombre = p.Nombre,
        ProveedorTelefono = p.Telefono

        
        
      }).ToList();  

      return unionMedicamentosProveedores;

                          
     



      

    }

      public async Task<IEnumerable<Medicamento>> MedicamentosPorProveedor(string NombreProveedor)
    {
        Proveedor proveedorBuscado = await _context.Proveedores.FirstOrDefaultAsync( proveedor => proveedor.Nombre.ToLower() == NombreProveedor.ToLower());

        IEnumerable<Medicamento> medicamentosPorProveedor = await _context.Medicamentos.Where(medicamento => medicamento.ProveedorId == proveedorBuscado.ProveedorId).ToListAsync();


        return medicamentosPorProveedor;
    }

   




        public override async Task<(int totalRegistros,IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
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
        }

    public async  Task<IEnumerable<Medicamento>> MedicamentosNoVendidos()
    {
        List<Medicamento> medicamentosNoVendidos = new List<Medicamento>();
        IEnumerable<Medicamento> medicamentos = await _context.Medicamentos.ToListAsync();

        foreach(Medicamento med in medicamentos)
        {

          bool MedicamentoVendido =   _context.MedicamentoVentas.Any( x => x.MedicamentoId == med.MedicamentoId);
          if (!MedicamentoVendido) medicamentosNoVendidos.Add(med);
        }

        return medicamentosNoVendidos;


    }

    public async Task<Medicamento> MedicamentoMasCaro()
    {
        double precio = _context.Medicamentos.Max(x => x.Precio);
       return  await _context.Medicamentos.FirstOrDefaultAsync( x => x.Precio == precio);
    }

    public async Task<int> NumeroMedicamentosPorProveedor(int idProveedor)
    {
           var  num =  from i in _context.Medicamentos
                    where i.ProveedorId == idProveedor
                    select i.MedicamentoId;
                    
           return   num.Count();    
    }
}
