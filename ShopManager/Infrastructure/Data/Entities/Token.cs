using System.ComponentModel.DataAnnotations;

namespace ShopManager.Infrastructure.Data.Entities;

public enum TokenType
{
    Manual,
    Refresh
}

public class Token
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public required Guid UserId { get; set; }
    
    public required TokenType TokenType { get; set; }
    public required string TokenData { get; set; }
    
    public DateTime Expiry { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRevoked { get; set; } = false;
    
    public User? User { get; set; }
}