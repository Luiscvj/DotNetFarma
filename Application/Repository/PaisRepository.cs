using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;


public class PaisRepository : GenericRepository<Pais>, IPais
{
    public PaisRepository(DotNetFarmaContext context) : base(context)
    {
    }
}