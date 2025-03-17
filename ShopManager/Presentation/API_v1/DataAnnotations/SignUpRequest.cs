using System.ComponentModel.DataAnnotations;

namespace ShopManager.Presentation.API_v1.DataAnnotations;

public class SignUpRequest
{
    [Required] public required string FirstName { get; set; }
    [Required] public required string LastName { get; set; }

    [Required] public required string PhoneNumber { get; set; }
    
    [Required] [EmailAddress] public required string Email { get; set; }
    
    [Required] public required string Login { get; set; }
    [Required] public required string Password { get; set; }
}