using Ardalis.Result;

namespace ShopManager.Core.Interfaces;

public record SignUpResult(Guid UserId, string ActionToken, string RefreshToken);

public record SignInResult(Guid UserId, string ActionToken, string RefreshToken);

public interface IAuthService
{
    Task<Result<SignUpResult>> SignUp(string firstName, string lastName, string phoneNumber,
        string email, string login, string password, string? userAgent, string? ipAddress);

    Task<Result<SignInResult>> SignIn(string login, string password, string? userAgent, string? ipAddress);
}