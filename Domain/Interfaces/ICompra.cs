using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompra : IGenericRepository<Compra>
{
    Task<int> TotalProveedores2023Suministran();
}
