
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
    public RefreshTokenRepository(DotNetFarmaContext context) : base(context)
    { 
    }
}
