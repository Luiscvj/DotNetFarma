using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class CompraRepository : GenericRepository<Compra>, ICompra
{
    public CompraRepository(DotNetFarmaContext context) : base(context)
    {
    }
}