using System.Security.Claims;
using ShopManager.Core.Entities;

namespace ShopManager.Core.Interfaces;

public interface IUserService
{
    Task<User?> GetUserFromContext(ClaimsPrincipal principal);
}