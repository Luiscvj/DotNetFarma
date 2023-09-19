using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;


public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly DotNetFarmaContext _dotNetFarmaContext;
    public PaisRepository(DotNetFarmaContext context) : base(context)
    {
        _dotNetFarmaContext = context;
    }
}