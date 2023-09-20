
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    public CiudadRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
