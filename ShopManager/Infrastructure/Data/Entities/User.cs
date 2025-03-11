using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Infrastructure.Data.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public required string Login { get; set; }
    public required string Password { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? LastLogin { get; set; }
    
    public bool IsActive { get; set; } = true;
    public uint RoleId { get; set; } = 0;
    

}