
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(DotNetFarmaContext context) : base(context)
    {
    }
}
