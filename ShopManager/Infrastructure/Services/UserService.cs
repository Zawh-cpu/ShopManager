using System.Security.Claims;
using ShopManager.Core.Entities;
using ShopManager.Core.Interfaces;

namespace ShopManager.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IBaseRepository _baseRepository;

    public UserService(IBaseRepository baseRepository)
    {
        _baseRepository = baseRepository;
    }
    
    public async Task<User?> GetUserFromContext(ClaimsPrincipal principal)
    {
        // principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? 
        // principal.FindFirst("sub")?.Value;
        string? rawJti = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(rawJti, out Guid jti)) return null;
        
        return await _baseRepository.GetUserByIdAsync(jti);
    }
}