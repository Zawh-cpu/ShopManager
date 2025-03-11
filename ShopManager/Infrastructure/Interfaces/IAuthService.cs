namespace ShopManager.Infrastructure.Interfaces;

public interface IAuthService
{
    Task<bool> IsTokenValid(Guid tokenId);
}