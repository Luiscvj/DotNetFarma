
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    public DepartamentoRepository(DotNetFarmaContext context) : base(context)
    {
    }
}