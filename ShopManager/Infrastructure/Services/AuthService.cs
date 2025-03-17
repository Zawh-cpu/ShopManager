using Ardalis.Result;
using ShopManager.Core.Entities;
using ShopManager.Core.Interfaces;

namespace ShopManager.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IBaseRepository _baseRepository;

    public AuthService(ITokenService tokenService, IBaseRepository baseRepository)
    {
        _tokenService = tokenService;
        _baseRepository = baseRepository;
    }

    public async Task<Result<SignUpResult>> SignUp(string firstName, string lastName, string phoneNumber,
        string email, string login, string password, string? userAgent, string? ipAddress)
    {
        try
        {
            await _baseRepository.BeginTransactionAsync();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Login = login,
                Email = email,
                Password = password,
            };

            await _baseRepository.AddEntityAsync(user);

            var refreshToken = _tokenService.GenerateToken(user.Id, TokenType.Refresh);
            var actionToken = _tokenService.GenerateToken(user.Id, TokenType.Action);

            await _baseRepository.AddEntityAsync(refreshToken);
            await _baseRepository.AddEntityAsync(actionToken);
            
            user.LastLogin = refreshToken.CreatedAt;
            var loginLog = new LoginHistory()
            {
                UserId = user.Id,
                TokenId = refreshToken.Id,
                Ipv4Address = ipAddress,
                LoginTimeStamp = refreshToken.CreatedAt,
                DeviceInfo = userAgent
            };
            await _baseRepository.AddEntityAsync(loginLog);
            
            await _baseRepository.CommitTransactionAsync();

            return new SignUpResult(user.Id, actionToken.TokenData, refreshToken.TokenData);
        }
        catch (Exception ex)
        {
            await _baseRepository.RollbackTransactionAsync();
            return Result.Conflict(ex.Message);
        }
    }

    public async Task<Result<SignInResult>> SignIn(string login, string password, string? userAgent, string? ipAddress)
    {
        var user = await _baseRepository.GetUserByLoginOrEmail(login);
        if (user == null) return Result.Forbidden();
        if (!user.Password.Equals(password)) return Result.Forbidden();
        
        var refreshToken = _tokenService.GenerateToken(user.Id, TokenType.Refresh);
        var actionToken = _tokenService.GenerateToken(user.Id, TokenType.Action);

        await _baseRepository.AddEntityAsync(refreshToken);
        await _baseRepository.AddEntityAsync(actionToken);
        
        user.LastLogin = refreshToken.CreatedAt;
        var loginLog = new LoginHistory()
        {
            UserId = user.Id,
            TokenId = refreshToken.Id,
            Ipv4Address = ipAddress,
            LoginTimeStamp = refreshToken.CreatedAt,
            DeviceInfo = userAgent
        };
        await _baseRepository.AddEntityAsync(loginLog);
        
        await _baseRepository.SaveAsync();
        
        return new SignInResult(user.Id, actionToken.TokenData, refreshToken.TokenData);
    }
}