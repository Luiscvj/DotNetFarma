
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    public VentaRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
