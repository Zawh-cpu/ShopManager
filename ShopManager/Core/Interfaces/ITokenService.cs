using ShopManager.Core.Entities;

namespace ShopManager.Core.Interfaces;

public interface ITokenService
{
    Task<bool> IsTokenValid(Guid tokenId);
    Token GenerateToken(Guid userId, TokenType tokenType);
    Task<Token?> GetTokenByIdAsync(Guid tokenId);
}