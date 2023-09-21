
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    public RolRepository(DotNetFarmaContext context) : base(context)
    { 
    }
}
