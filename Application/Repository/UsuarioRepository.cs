
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(DotNetFarmaContext context) : base(context)
    {
    }
     public override async Task<(int totalRegistros,IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Usuarios as IQueryable<Usuario>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Email.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.RefreshTokens)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}
