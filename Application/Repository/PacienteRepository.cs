
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


     public async Task<List<MedicamentoPorPacienteH>> MedicamentoPacientePorNombreMedicamento(string NombreMedicamento)
     {
        List<MedicamentoPorPacienteH> pacienteCompra2  = new List<MedicamentoPorPacienteH>();
      
        Medicamento medicamentoBuscado = await _context.Medicamentos.FirstOrDefaultAsync(x => x.Nombre.ToLower() == NombreMedicamento.ToLower()); 

       
        IEnumerable<Paciente> lstPaciente = await _context.Pacientes.Include(x => x.Ventas)    
                                         .ThenInclude(v => v.MedicamentoVentas)
                                         .ToListAsync();

        
            foreach(Paciente paciente in lstPaciente)
            {
                 var  pacienteCompra3 =  paciente.Ventas
                                     .SelectMany(ventas => ventas.MedicamentoVentas)
                                     .Where(ventaMedicamento => ventaMedicamento.MedicamentoId == medicamentoBuscado.MedicamentoId )
                                     .Select( datos => new 
                                     MedicamentoPorPacienteH
                                     {   
                                       IdVenta = datos.VentaId,
                                       NombrePaciente = paciente.Nombre,
                                       CantidadVendida = datos.CantidadVendida,
                                       PrecioVenta = datos.PrecioVenta
                                       
                                       
                                     }).ToList();//Me sirve para aplanar los datos , pues sino me retorna una secuencia de secuencia de objetos por lo que estpy en el bucle

        
              pacienteCompra2.AddRange(pacienteCompra3);
            }

            return pacienteCompra2;

     }
}
