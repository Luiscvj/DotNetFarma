
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class PacienteRepository : GenericRepository<Paciente>, IPaciente
{
    public PacienteRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
