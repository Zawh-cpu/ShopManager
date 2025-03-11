using Microsoft.EntityFrameworkCore;
using ShopManager.Infrastructure.Data;
using ShopManager.Infrastructure.Interfaces;

namespace ShopManager.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    
    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> IsTokenValid(Guid tokenId)
    {
        return await _context.Tokens.Where(x => x.Id == tokenId && x.IsRevoked == false).AnyAsync();
    }
}