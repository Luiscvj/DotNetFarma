
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class ArlRepository : GenericRepository<Arl>, IArl
{
    public ArlRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
