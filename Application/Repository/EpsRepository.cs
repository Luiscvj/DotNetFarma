
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class EpsRepository : GenericRepository<Eps>, IEps
{
    public EpsRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
