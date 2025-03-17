using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Core.Entities;

public enum TokenType
{
    Action,
    Refresh
}

public static class TokenTypeExtensions
{
    public static TimeSpan GetLifetime(this TokenType tokenType)
    {
        return tokenType switch
        {
            TokenType.Action => TimeSpan.FromMinutes(15),
            TokenType.Refresh => TimeSpan.FromDays(30),
            _ => throw new ArgumentOutOfRangeException(nameof(tokenType), "Unknown token type")
        };
    }
}

public class Token
{
    [Key] public Guid Id { get; set; }

    [Required] public required Guid UserId { get; set; }

    public required TokenType TokenType { get; set; }
    
    [NotMapped]
    public required string TokenData { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime Expiry { get; set; }
    public bool IsRevoked { get; set; } = false;

    public User? User { get; set; }
}