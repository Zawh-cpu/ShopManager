using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopManager.Core.Entities;

[Index(nameof(Login), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public Guid Id { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? LastLogin { get; set; }
    
    public bool IsActive { get; set; } = true;
    public uint RoleId { get; set; } = 0;
    

}