using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmpleado : IGenericRepository<Empleado>
{
 

    Task<IEnumerable<Empleado>> EmpleadoConMenosDe5Ventas();
    Task<List<Empleado>> GetEmpleadosConMayorCantidadMedicamentosEn2023();
    Task<List<Empleado>> EmpleadosSinVentasAbril();
    Task<List<int>> GetIdEmpleados();
    Task<dynamic> GetVentasxEmpleado();
    Task<dynamic> GetEmpleados5Ventas();
    Task<dynamic> GetEmpleadosNoVentas();
}

