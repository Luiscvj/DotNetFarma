using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargo
{
    public CargoRepository(DotNetFarmaContext context) : base(context)
    {
    }
}