using Microsoft.EntityFrameworkCore;
using ShopManager.Core.Entities;
using ShopManager.Core.Interfaces;
using ShopManager.Infrastructure.Data;

namespace ShopManager.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    
    public TokenService(ApplicationDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }
    public async Task<bool> IsTokenValid(Guid tokenId)
    {
        return await _context.Tokens.Where(x => x.Id == tokenId && x.IsRevoked == false).AnyAsync();
    }

    public Token GenerateToken(Guid userId, TokenType tokenType)
    {
        var timeNow = DateTime.UtcNow;
        var expiryTime = timeNow.Add(tokenType.GetLifetime());
        var tokenId = Guid.NewGuid();
        
        var token = new Token()
        {
            Id = tokenId,
            UserId = userId,
            TokenType = tokenType,
            TokenData = _jwtService.GenerateJwt(tokenId, userId.ToString(), timeNow, expiryTime),
            CreatedAt = timeNow,
            Expiry = expiryTime,
        };
        
        return token;
    }

    public async Task<Token?> GetTokenByIdAsync(Guid tokenId)
    {
        return await _context.Tokens.FindAsync(tokenId);
    }
}