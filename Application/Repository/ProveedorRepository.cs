
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    public ProveedorRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
