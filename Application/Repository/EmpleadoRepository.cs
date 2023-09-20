using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    public EmpleadoRepository(DotNetFarmaContext context) : base(context)
    {
    }
}